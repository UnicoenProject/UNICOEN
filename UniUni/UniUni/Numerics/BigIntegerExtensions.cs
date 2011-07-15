#region License

// Copyright (C) 2011 The Unicoen Project
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

using System.Numerics;

namespace UniUni.Numerics {
	public static class BigIntegerExtensions {
		public static byte ToForceUInt8(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 8; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (byte)result;
		}

		public static sbyte ToForceInt8(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 8; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (sbyte)result;
		}

		public static ushort ToForceUInt16(this BigInteger value) {
			int result = 0;
			for (int i = 0; i < 16; i++) {
				var bit = 1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (ushort)result;
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

		public static uint ToForceUInt31(this BigInteger value) {
			uint result = 0;
			for (int i = 0; i < 31; i++) {
				var bit = (uint)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return result;
		}

		public static int ToForceInt31(this BigInteger value) {
			uint result = 0;
			for (int i = 0; i < 31; i++) {
				var bit = (uint)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (int)result;
		}

		public static uint ToForceUInt32(this BigInteger value) {
			uint result = 0;
			for (int i = 0; i < 32; i++) {
				var bit = (uint)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return result;
		}

		public static int ToForceInt32(this BigInteger value) {
			uint result = 0;
			for (int i = 0; i < 32; i++) {
				var bit = (uint)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (int)result;
		}

		public static ulong ToForceUInt64(this BigInteger value) {
			ulong result = 0;
			for (int i = 0; i < 64; i++) {
				var bit = (ulong)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return result;
		}

		public static long ToForceInt64(this BigInteger value) {
			ulong result = 0;
			for (int i = 0; i < 64; i++) {
				var bit = (ulong)1 << i;
				if ((value & bit) != 0)
					result |= bit;
			}
			return (long)result;
		}
	}
}