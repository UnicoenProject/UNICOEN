using System.Collections.Generic;
using NUnit.Framework;
using Ucpf.Core.Model;

namespace Ucpf.Core.Tests {
	[TestFixture]
	public class StructuralEqualityComparerTestForPrimitive {
		[Test]
		public void compares_null_null() {
			object o1 = null;
			object o2 = null;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_equal_strings() {
			var o1 = "abc";
			var o2 = "abc";
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_strings() {
			var o1 = "abc";
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_types() {
			var o1 = "abc";
			var o2 = new object();
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_null_string() {
			object o1 = null;
			var o2 = "abc";
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_string_null() {
			var o1 = "abc";
			object o2 = null;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_different_strings() {
			var o1 = "abc";
			var o2 = "abcd";
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_ints() {
			var o1 = 0;
			var o2 = 0;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_ints() {
			var o1 = 1;
			var o2 = -1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_intLists() {
			var o1 = new List<int> { 1, 2 };
			var o2 = new List<int> { 1, 2 };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_intLists() {
			var o1 = new List<int> { 1, 2 };
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_intLists() {
			var o1 = new List<int> { 1, 2 };
			var o2 = new List<int> { 1, 3 };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_intLists_subIntLists() {
			var o1 = new List<int> { 1, 2 };
			var o2 = new List<int> { 1, 2, 3 };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_stringLists() {
			var o1 = new List<string> { "1", "2" };
			var o2 = new List<string> { "1", "2" };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_stringLists() {
			var o1 = new List<string> { "1", "2" };
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_stringLists() {
			var o1 = new List<string> { "1", "2" };
			var o2 = new List<string> { "1", "3" };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_stringLists_subLists() {
			var o1 = new List<string> { "1", "2" };
			var o2 = new List<string> { "1", "2", "3" };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_equal_intListLists() {
			var o1 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2, 4 } };
			var o2 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2, 4 } };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_same_intListLists() {
			var o1 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2, 4 } };
			var o2 = o1;
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.True);
		}

		[Test]
		public void compares_different_intListLists() {
			var o1 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2, 4 } };
			var o2 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 3, 4 } };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}

		[Test]
		public void compares_intListLists_subintListLists() {
			var o1 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2, 4 } };
			var o2 = new List<List<int>>
			{ new List<int> { 1, 2 }, new List<int> { 1, 2 } };
			Assert.That(StructuralEqualityComparer.StructuralEquals(o1, o2),
				Is.False);
		}
	}
}