using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Languages.CSharp.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaSpecificationTest {
		[Test]
		public void CreateSimpleWhile() {
			const string code = @"
class A { void M1() {
	while(true) return;
} }";

			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.WhileModel)
					.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateWhile() {
			const string code = @"
class A { void M1() {
	while(true) { return; }
} }";

			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.WhileModel)
					.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateDoWhile() {
			const string code = @"
class A { void M1() {
	do { return; } while(true)
} }";

			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.DoWhileModel)
					.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateFor() {
			const string code = @"
class A { void M1() {
	for (int i = 0; i < 1; i++) { break; }
} }";

			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.ForModel)
					.Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		public void CreateForeach() {
			const string code = @"
class A { void M1() {
	for (int i : new int[] { 1 }) { continue; }
} }";

			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.ForeachModel)
					.Using(StructuralEqualityComparer.Instance));
		}
	}
}
