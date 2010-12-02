using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Ucpf.Languages.JavaScript.Tests
{
    public class JavaScriptCodeModelTest
    {
        [Test]
        public void FunctionDeclarationを生成する()
        {
            var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
            var func = new FunctionDeclaration(root);
            Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
        }
    }
}
