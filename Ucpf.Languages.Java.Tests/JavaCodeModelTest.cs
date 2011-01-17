using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.Java.CodeModel;

namespace Ucpf.Languages.Java.Tests
{
	[TestFixture]
    public class JavaCodeModelTest
    {
		private static readonly string InputPath =
			Fixture.GetInputPath("Java", "fibonacci.java");

		[Test]
        public void JavaFunctionを生成できる()
        {
			var ast = JavaAstGenerator.Instance.GenerateFromFile(InputPath);
            var root = ast.Descendants("methodDeclaration").First();
            var func = new JavaFunction(root);
            Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
        }

    }
}
