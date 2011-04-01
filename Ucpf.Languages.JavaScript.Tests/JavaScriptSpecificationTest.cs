using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.JavaScript.Model;

namespace Ucpf.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptSpecificationTest {

		[Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var actual = JSModelFactory.CreateModel(fragment);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.WhileModel)
					.Using(StructuralEqualityComparer.Instance));
		}
	}
}
