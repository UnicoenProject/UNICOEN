using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.Tests
{
	[TestFixture]
    public class JavaScriptCodeModelTest
    {
        [Test]
        public void 一番最初に宣言されている関数名を取得する()
        {
            var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
            var func = new JSFunctionDeclaration(root);
            Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
        }

		[Test]
		public void 一番最初に宣言されている関数のパラメータが正しく取得できる() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
            var func = new JSFunctionDeclaration(root);
			var param = func.Parameters;
            Assert.That(param.ElementAt(0).Name, Is.EqualTo("n"));
		}

		[Test]
		public void if文の条件式が正しく取得できる() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunctionDeclaration(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var cond = (JSBinaryExpression)ifst.ConditionalExpression;
			var op   = cond.Operator;
			Assert.That(op, Is.EqualTo("<"));
		}
    }
}
