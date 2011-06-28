using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Mocomoco.Linq {
	public static class BigIntegerExtensions {
		public static byte ToForceByte(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 8; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (byte)result;
		}

		public static short ToForceInt16(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 16; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (short)result;
		}

		public static int ToForceInt32(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 32; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return result;
		}

		public static int ToForceInt64(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 64; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return result;
		}
	}
}
