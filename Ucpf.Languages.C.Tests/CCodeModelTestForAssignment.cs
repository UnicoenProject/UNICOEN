using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForAssignment
	{
		private CFunction _function;
		private static readonly string InputPath =
			Fixture.GetInputPath("C", "assignment.c");

		[SetUp]
		public void SetUp()
		{
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
			Assert.That(_function.Name, Is.EqualTo("assignment"));
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
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n==1"));
		}

		[Test]
		public void ふたつめのIF文の条件式が正しい()
		{
			var ifStmt = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var elseifBlocks = ifStmt.ElseIfBlocks;
			var conditionalExpression = elseifBlocks.ElementAt(0).ConditionalExpression;
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n==2"));
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
			Assert.That(exp.ToString(), Is.EqualTo("10"));
		}
	}
}
