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

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniUni.Collections.Generic;

namespace UniUni.Tests.Collections.Generic {
	[TestFixture]
	public class ListExtensionsTest {
		[Test]
		[TestCase(new int[] { }, 0, Result = 0)]
		[TestCase(new[] { 1, 2 }, 0, Result = 1)]
		[TestCase(new[] { 1, 2 }, 1, Result = 2)]
		[TestCase(new[] { 1, 2 }, 2, Result = 0)]
		public static int ElementAtOrDefault(IList<int> list, int index) {
			return list.ElementAtOrDefault(index);
		}

		[Test]
		[TestCase(new int[] { }, Result = new int[] { })]
		[TestCase(new[] { 1 }, Result = new[] { 1 })]
		[TestCase(new[] { 1, 2 }, Result = new[] { 2, 1 })]
		[TestCase(new[] { 1, 2, 3 }, Result = new[] { 3, 2, 1 })]
		public static IEnumerable<int> Reverse(IList<int> list) {
			return list.Reverse();
		}

		[Test]
		[TestCase(new int[] { }, Result = new[] { 0, 0 })]
		[TestCase(new[] { 1 }, Result = new[] { 1, 0 })]
		[TestCase(new[] { 1, 2 }, Result = new[] { 1, 2 })]
		[TestCase(new[] { 1, 2, 3 }, Result = new[] { 1, 2, 3 })]
		public static IList<int> Extend(IList<int> list) {
			return list.ToList().Extend(2);
		}

		[Test]
		[TestCase(new int[] { }, 9, Result = new[] { 9, 9 })]
		[TestCase(new[] { 1 }, 9, Result = new[] { 1, 9 })]
		[TestCase(new[] { 1, 2 }, 9, Result = new[] { 1, 2 })]
		[TestCase(new[] { 1, 2, 3 }, 9, Result = new[] { 1, 2, 3 })]
		public static IList<int> Extend2(IList<int> list, int defaultElement) {
			return list.ToList().Extend(2, defaultElement);
		}

		[Test]
		[TestCase(new int[] { }, Result = new[] { 0, 1 })]
		[TestCase(new[] { 1 }, Result = new[] { 1, 0 })]
		[TestCase(new[] { 1, 2 }, Result = new[] { 1, 2 })]
		[TestCase(new[] { 1, 2, 3 }, Result = new[] { 1, 2, 3 })]
		public static IList<int> Extend3(IList<int> list) {
			var d = 0;
			return list.ToList().Extend(2, () => d++);
		}

		[Test]
		[TestCase(new int[] { }, 9, Result = new int[] { })]
		[TestCase(new[] { 1 }, 9, Result = new[] { 9 })]
		[TestCase(new[] { 1, 2 }, 9, Result = new[] { 9, 9 })]
		[TestCase(new[] { 1, 2, 3 }, 9, Result = new[] { 9, 9, 9 })]
		public static IList<int> Fill(IList<int> list, int element) {
			return list.Fill(element);
		}

		[Test]
		[TestCase(new int[] { }, Result = new int[] { })]
		[TestCase(new[] { 1 }, Result = new[] { 9 })]
		[TestCase(new[] { 1, 2 }, Result = new[] { 9, 10 })]
		[TestCase(new[] { 1, 2, 3 }, Result = new[] { 9, 10, 11 })]
		public static IList<int> Fill2(IList<int> list) {
			var d = 9;
			return list.Fill(() => d++);
		}

		[Test]
		[TestCase(new int[] { }, Result = new int[] { })]
		[TestCase(new[] { 1 }, Result = new[] { 9 })]
		[TestCase(new[] { 1, 2 }, Result = new[] { 9, 11 })]
		[TestCase(new[] { 1, 2, 3 }, Result = new[] { 9, 11, 13 })]
		public static IList<int> Fill3(IList<int> list) {
			var d = 9;
			return list.Fill(i => i + d++);
		}
	}
}