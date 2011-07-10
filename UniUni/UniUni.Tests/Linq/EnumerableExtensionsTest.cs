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

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniUni.Linq;

namespace UniUni.Tests.Linq {
	[TestFixture]
	public class EnumerableExtensionsTest {
		[Test]
		[TestCase(new int[] { }, ExpectedException = typeof(ArgumentException))]
		[TestCase(new[] { 1 }, Result = "1")]
		[TestCase(new[] { 1, 2 }, Result = "12")]
		[TestCase(new[] { 1, 2, 3 }, Result = "123")]
		public static string AggregateApartFirst(IEnumerable<int> source) {
			return source.AggregateApartFirst(f => f.ToString(), (c, n) => c + "" + n);
		}

		[Test]
		[TestCase(new int[] { }, ExpectedException = typeof(ArgumentException))]
		[TestCase(new[] { 1 }, Result = 1)]
		[TestCase(new[] { 1, 2 }, Result = 12)]
		[TestCase(new[] { 1, 2, 3 }, Result = 123)]
		public static int AggregateApartFirst2(IEnumerable<int> source) {
			return source.AggregateApartFirst(
					f => f.ToString(),
					(c, n) => c + "" + n, int.Parse);
		}

		[Test]
		[TestCase(new[] { 1 }, Result = 1)]
		[TestCase(new[] { 1, 2 }, Result = 2)]
		[TestCase(new[] { 1, 2, 3 }, Result = 6)]
		public static int Aggregate(IEnumerable<int> source) {
			return source.Aggregate((c, n) => c * n);
		}

		[Test]
		[TestCase(new[] { 1 }, Result = 1)]
		[TestCase(new[] { 1, 2 }, Result = 2)]
		[TestCase(new[] { 1, 2, 3 }, Result = 1)]
		public static int AggregateRight(IEnumerable<int> source) {
			return source.AggregateRight((c, n) => c / n);
		}

		[Test]
		[TestCase(new[] { 1 }, Result = 6)]
		[TestCase(new[] { 1, 2 }, Result = 3)]
		[TestCase(new[] { 1, 2, 3 }, Result = 1)]
		public static int AggregateRight2(IEnumerable<int> source) {
			return source.AggregateRight(6, (c, n) => c / n);
		}

		[Test]
		[TestCase(new[] { 1 })]
		[TestCase(new[] { 1, 2, 3 })]
		public static void Split2ForOddCount(IEnumerable<int> source) {
			Assert.That(
					source.Split2().SelectMany(t => new[] { t.Item1, t.Item2 }),
					Is.EqualTo(source.Take(source.Count() - 1)));
		}

		[Test]
		[TestCase(new int[] { })]
		[TestCase(new[] { 1, 2 })]
		[TestCase(new[] { 1, 2, 3, 4 })]
		public static void Split2ForEvenCount(IEnumerable<int> source) {
			Assert.That(
					source.Split2().SelectMany(t => new[] { t.Item1, t.Item2 }),
					Is.EqualTo(source));
		}
	}
}