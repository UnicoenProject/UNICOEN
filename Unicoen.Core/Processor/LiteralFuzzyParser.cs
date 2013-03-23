#region License

// Copyright (C) 2011-2012 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Numerics;

namespace Unicoen.Processor {
	public static class LiteralFuzzyParser {
		private static readonly int[] Char2Int;

		static LiteralFuzzyParser() {
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

		public static Int32 ParseInt32(string number, int factor) {
			Int32 result = 0;
			foreach (var ch in number) {
				result = result * factor + Char2Int[ch];
			}
			if (number[0] == '-') {
				return -result;
			}
			return result;
		}

		public static Int32 ParseInt32(string number) {
			return ParseInt32(number, 10);
		}

		public static Int32 ParseOcatleInt32(string number) {
			return ParseInt32(number, 8);
		}

		public static Int32 ParseHexicalInt32(string number) {
			return ParseInt32(number, 16);
		}

		public static BigInteger ParseBigInteger(string number, int factor) {
			BigInteger result = 0;
			foreach (var ch in number) {
				result = result * factor + Char2Int[ch];
			}
			if (number[0] == '-') {
				return -result;
			}
			return result;
		}

		public static BigInteger ParseBigInteger(string number) {
			return ParseBigInteger(number, 10);
		}

		public static BigInteger ParseOcatleBigInteger(string number) {
			return ParseBigInteger(number, 8);
		}

		public static BigInteger ParseHexicalBigInteger(string number) {
			return ParseBigInteger(number, 16);
		}

		public static Double ParseIntegerDouble(string number, double factor) {
			Double result = 0;
			foreach (var ch in number) {
				result = result * factor + Char2Int[ch];
			}
			if (number[0] == '-') {
				return -result;
			}
			return result;
		}

		public static Double ParseIntegerDouble(string number) {
			return ParseIntegerDouble(number, 10);
		}

		public static Double ParseOcatleIntegerDouble(string number) {
			return ParseIntegerDouble(number, 8);
		}

		public static Double ParseHexicalIntegerDouble(string number) {
			return ParseIntegerDouble(number, 16);
		}

		public static Double ParseFractionDouble(string number, double factor) {
			Double result = 0;
			for (int i = number.Length - 1; i >= 0; i--) {
				result = (result + Char2Int[number[i]]) * factor;
			}
			if (number[0] == '-') {
				return -result;
			}
			return result;
		}

		public static Double ParseFractionDouble(string number) {
			return ParseFractionDouble(number, 1.0 / 10);
		}

		public static Double ParseOcatleFractionDouble(string number) {
			return ParseFractionDouble(number, 1.0 / 8);
		}

		public static Double ParseHexicalFractionDouble(string number) {
			return ParseFractionDouble(number, 1.0 / 16);
		}
	}
}