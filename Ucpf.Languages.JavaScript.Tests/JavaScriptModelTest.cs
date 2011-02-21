using System;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;
using Ucpf.Languages.JavaScript.AstGenerators;
using Ucpf.Languages.JavaScript.Model;
using Ucpf.Languages.JavaScript.Model.Expressions;
using Ucpf.Languages.JavaScript.Model.Statements;

namespace Ucpf.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptModelTest {
		private static readonly string InputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		[Test, Ignore]
		public void If文の条件式を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = JSModelFactory.CreateFunction(root);//new JSFunction(root);
			var body = func.Block;
			var ifst = (UnifiedIf)body.GetEnumerator().Current;//(JSIfStatement)body.Statements.ElementAt(0);
			var cond = (UnifiedBinaryExpression)ifst.Condition;//(JSBinaryExpression)ifst.ConditionalExpression;
			Assert.That(cond.ToString(), Is.EqualTo("n<2"));
		}

		[Test, Ignore]
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var param = func.Parameters;
			Assert.That(param.ElementAt(0).Name, Is.EqualTo("n"));
		}

		[Test]
		public void 一番最初に宣言されている関数名を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			Assert.That(func.Identifier, Is.EqualTo("fibonacci"));
		}

		[Test, Ignore]
		public void 一番最初のreturn文を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var trbl = (JSBlock)ifst.TrueBlock;
			var ret = trbl.Statements.First();
			Assert.That(ret.GetType(), Is.EqualTo(typeof(JSReturnStatement)));
		}

		[Test, Ignore]
		public void 二項演算子を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var elbl = (JSBlock)ifst.ElseBlock.First();
			var ret = (JSReturnStatement)elbl.Statements.First();
			var exp = (JSBinaryExpression)ret.ReturnExpression;
			Assert.That(exp.Operator.Sign, Is.EqualTo("+"));
		}

		[Test, Ignore]
		public void 呼び出す関数の名前を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var elbl = (JSBlock)ifst.ElseBlock.First();
			var ret = (JSReturnStatement)elbl.Statements.First();
			var exp = (JSBinaryExpression)ret.ReturnExpression;
			var call = (JSCallExpression)exp.Lhs;
			Assert.That(call.Identifier, Is.EqualTo("fibonacci"));
		}

		[Test, Ignore]
		public void 呼び出す関数の引数を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var elbl = (JSBlock)ifst.ElseBlock.First();
			var ret = (JSReturnStatement)elbl.Statements.First();
			var exp = (JSBinaryExpression)ret.ReturnExpression;
			var call = (JSCallExpression)exp.Lhs;
			Assert.That(call.Arguments.First().ToString(), Is.EqualTo("n-1"));
		}

		[Test, Ignore]
		public void 返却される式を取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var ifst = (JSIfStatement)body.Statements.ElementAt(0);
			var elbl = (JSBlock)ifst.ElseBlock.First();
			var ret = (JSReturnStatement)elbl.Statements.First();
			var exp = ret.ReturnExpression;
			Assert.That(exp.ToString(), Is.EqualTo("fibonacci(n-1)+fibonacci(n-2)"));
		}

		[Test, Ignore]
		public void 関数内のステートメントを取得する() {
			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
			var root = ast.Descendants("functionDeclaration").First();
			var func = new JSFunction(root);
			var body = func.FunctionBody;
			var stat = body.Statements;
			var str1 = stat.ElementAt(0);
			Assert.That(str1.GetType(), Is.EqualTo(typeof(JSIfStatement)));
		}
	}
}