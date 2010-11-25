using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Ucpf.Languages.Java.Tests
{
    public class JavaCodeModelTest
    {
        [Test]
        public void JavaFunctionを生成できる()
        {
            var ast = JavaAstGenerator.Instance.GenerateFromFile("fibonacci.java");
            var root = ast.Descendants("methodDeclaration").First();
            var func = new FunctionDeclaration(root);
            //Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
        }

    }
}
