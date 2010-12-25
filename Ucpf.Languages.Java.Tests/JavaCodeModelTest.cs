using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Languages.Java.CodeModel;

namespace Ucpf.Languages.Java.Tests
{
	[TestFixture]
    public class JavaCodeModelTest
    {
        [Test]
        public void JavaFunctionを生成できる()
        {
            var ast = JavaAstGenerator.Instance.GenerateFromFile("fibonacci.java");
            var root = ast.Descendants("methodDeclaration").First();
            var func = new JavaFunction(root);
            Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
        }

    }
}
