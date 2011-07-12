using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Unicoen.Processor {
	public static class LiteralParser {
		private static readonly int[] Char2Int;

		static LiteralParser() {
			Char2Int = new int[128];
			Char2Int['0'] = 0;
			Char2Int['1'] = 1;
			Char2Int['2'] = 2;
			Char2Int['3'] = 3;
			Char2Int['4'] = 4;
			Char2Int['5'] = 5;
			Char2Int['6'] = 6;
			Char2Int['7'] = 7;
			Char2Int['8'] = 8;
			Char2Int['9'] = 9;
			Char2Int['a'] = 10;
			Char2Int['A'] = 10;
			Char2Int['b'] = 11;
			Char2Int['B'] = 11;
			Char2Int['c'] = 12;
			Char2Int['C'] = 12;
			Char2Int['d'] = 13;
			Char2Int['D'] = 13;
			Char2Int['e'] = 14;
			Char2Int['E'] = 14;
			Char2Int['f'] = 15;
			Char2Int['F'] = 15;
			Char2Int['+'] = 0;
			Char2Int['-'] = 0;
		}

		public static BigInteger ParseFuzzyNumber(string number, int factor) {
			BigInteger result = 0;
			foreach (var ch in number) {
				result = result * factor + Char2Int[ch];
			}
			if (number[0] == '-')
				return -result;
			return result;
		}

		public static BigInteger ParseNumber(string number) {
			return ParseFuzzyNumber(number, 10);
		}

		public static BigInteger ParseOcatleNumber(string number) {
			return ParseFuzzyNumber(number, 8);
		}

		public static BigInteger ParseHexicalNumber(string number) {
			return ParseFuzzyNumber(number, 16);
		}
	}
}
