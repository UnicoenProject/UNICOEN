using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.CodeModel;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public partial class CCodeModelTestForFibonacci2 {
		private CFunction _function;
		private static readonly string InputPath =
			Path.Combine(Settings.GetInputDirPath("C"), "fibonacci2.c");

		[SetUp]
		public void SetUp() {
			_function = new CFunction(
				CAstGenerator.Instance.GenerateFromFile(InputPath)
				.Descendants("function_definition")
				.First());
		}
		
		[Test]
		public void メソッド返却値タイプが正しい()
		{
			Assert.That(_function.ReturnType.Name, Is.EqualTo("int"));
		}

		[Test]
		public void メソッド名が正しい()
		{
			Assert.That(_function.Name, Is.EqualTo("fibonacci2"));
		}

		// test whether the first parameter equals to (int, "n")
		[Test]
		public void パラメータリストが正しい()
		{
			var fstParam = _function.Parameters.ElementAt(0);
			Assert.That(fstParam.Name, Is.EqualTo("n"));
			Assert.That(fstParam.Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void 最初のIF文の条件式が正しい()
		{
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var conditionalExpression = ifStmt.ConditionalExpression;
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n<0"));
		}
		[Test]
		public void ふたつめのIF文の条件式が正しい(){
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var elseifBlocks = ifStmt.ElseIfBlocks;
			var conditionalExpression = elseifBlocks.ElementAt(0).ConditionalExpression;
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n==1||n==2"));
		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var trueBlock = ifStmt.TrueBlock;
			var stmt = trueBlock.Statements.ElementAt(0) as CInvocationExpression;
			// Assert.That(stmt.Expression is CInvocationExpression);
			Assert.That(stmt.ToString(), Is.EqualTo("printf(\"aaaa\")"));
		}

		[Test]
		public void ElseIfBlockが正しく生成できる()
		{
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var elseifBlocks = ifStmt.ElseIfBlocks;
			var stmt = elseifBlocks.ElementAt(0).Statements.ElementAt(0);
			var exp = ((CReturnStatement)stmt).Expression;
			Assert.That(exp.ToString(), Is.EqualTo("1"));
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var elseBlock = ifStmt.ElseBlock;
			var stmt = elseBlock.Statements.ElementAt(0) as CReturnStatement;
			var exp = stmt.Expression;

			// Assert.That(stmt.ToString(), Is.EqualTo(""));			// (passed)
			// Assert.That(stmt.Expression is CBinaryExpression);
			Assert.That(stmt.ToString(), Is.EqualTo("fibonacci2(n-1)+fibonacci2(n-2)"));
		}
	}
}
