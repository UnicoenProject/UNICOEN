using System.Text;

namespace UniUni.Text.Gauche {
	public static partial class GaucheGuess {
		public static readonly Encoding EucJp =
				Encoding.GetEncoding("EUC-JP");

		public static readonly Encoding ShiftJis =
				Encoding.GetEncoding("Shift_JIS");

		public static readonly Encoding Iso2022Jp =
				Encoding.GetEncoding("iso-2022-jp");

		public static readonly Encoding Utf8 = Encoding.UTF8;

		private static GuessDfa InitializeDfa(sbyte[,] states, GuessArc[] arcs) {
			return new GuessDfa {
					States = states,
					Arcs = arcs,
					State = 0,
					Score = 1.0,
			};
		}

		private static void CalculateNextDfa(GuessDfa dfa, int ch) {
			if (dfa.State < 0) return;
			var arc = dfa.States[dfa.State, ch];
			if (arc < 0) {
				dfa.State = -1;
			} else {
				dfa.State = dfa.Arcs[arc].Next;
				dfa.Score *= dfa.Arcs[arc].Score;
			}
		}

		private static bool IsAliveDfa(GuessDfa dfa) {
			return dfa.State >= 0;
		}

		public static Encoding GuessEncodings(byte[] bytes) {
			int i;
			var eucj = InitializeDfa(GuessEucjSt, GuessEucjAr);
			var sjis = InitializeDfa(GuessSjisSt, GuessSjisAr);
			var utf8 = InitializeDfa(GuessUtf8St, GuessUtf8Ar);
			GuessDfa top = null;

			for (i = 0; i < bytes.Length; i++) {
				int c = bytes[i];

				/* special treatment of jis escape sequence */
				if (c == 0x1b) {
					if (i < bytes.Length - 1) {
						c = bytes[++i];
						if (c == '$' || c == '(') {
							return Iso2022Jp;
						}
					}
				}

				if (IsAliveDfa(eucj)) {
					if (!IsAliveDfa(sjis) && !IsAliveDfa(utf8))
						return EucJp;
					CalculateNextDfa(eucj, c);
				}
				if (IsAliveDfa(sjis)) {
					if (!IsAliveDfa(eucj) && !IsAliveDfa(utf8))
						return ShiftJis;
					CalculateNextDfa(sjis, c);
				}
				if (IsAliveDfa(utf8)) {
					if (!IsAliveDfa(sjis) && !IsAliveDfa(eucj))
						return Utf8;
					CalculateNextDfa(utf8, c);
				}

				if (!IsAliveDfa(eucj) && !IsAliveDfa(sjis) && !IsAliveDfa(utf8)) {
					/* we ran out the possibilities */
					return null;
				}
			}

			/* Now, we have ambigous code.  Pick the highest score.
			 * If more than one candidate tie, pick the default encoding.
			 */
			if (IsAliveDfa(eucj)) top = eucj;
			if (IsAliveDfa(utf8)) {
				if (top != null) {
					if (top.Score <= utf8.Score) top = utf8;
				} else {
					top = utf8;
				}
			}
			if (IsAliveDfa(sjis)) {
				if (top != null) {
					if (top.Score < sjis.Score) top = sjis;
				} else {
					top = sjis;
				}
			}

			if (top == eucj) return EucJp;
			if (top == utf8) return Utf8;
			if (top == sjis) return ShiftJis;
			return null;
		}
	}
}