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
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
            var func = new JSFunctionDeclaration(root);
			var param = func.Parameters;
            Assert.That(param.ElementAt(0).Name, Is.EqualTo("n"));
		}

		[Test]
		public void If文の条件式を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunctionDeclaration(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var cond = (JSBinaryExpression)ifst.ConditionalExpression;
			Assert.That(cond.ToString(), Is.EqualTo("n<2"));
		}
		
		[Test]
		public void 関数内のステートメントを取得する() {
			var ast  = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunctionDeclaration(root);
			var body = func.FunctionBody;
			var stat = body.Statements;
			var str1 = stat.ElementAt(0);
			Assert.That(str1.GetType(), Is.EqualTo(typeof(JSIfStatement)));
		}

		[Test]
		public void 一番最初のreturn文を取得する() {
			var ast  = JavaScriptAstGenerator.Instance.GenerateFromFile("fibonacci.js");
            var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunctionDeclaration(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var trbl = (JSBlock)ifst.TrueBlock;
			var ret  = trbl.Statements.First();
			Assert.That(ret.GetType(), Is.EqualTo(typeof(JSReturnStatement)));
		}
    }
}
