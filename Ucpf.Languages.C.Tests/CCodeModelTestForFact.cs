using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForFact {
		private CFunction _function;
		private static readonly string InputPath =
			Fixture.GetInputPath("C", "fact.c");

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
			Assert.That(_function.Name, Is.EqualTo("fact"));
		}

		// test whether the first parameter equals to (int, "n")
		[Test]
		public void パラメータリストが正しい()
		{
			Assert.That(_function.Parameters.ElementAt(0).Name, Is.EqualTo("n"));
			Assert.That(_function.Parameters.ElementAt(0).Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void IF文の条件式が正しい()
		{
			var ifStatement = (CIfStatement)_function.Body.Statements.ElementAt(0);
			var conditionalExpression = (CBinaryExpression)ifStatement.ConditionalExpression;
			var leftExp = conditionalExpression.LeftExpression;
			var rightExp = conditionalExpression.RightExpression;
			var ope = conditionalExpression.Operator;
			
			Assert.That(ope.Type, Is.EqualTo(BinaryOperatorType.LesserEqual));
			Assert.That(leftExp.ToString(), Is.EqualTo("n"));
			Assert.That(rightExp.ToString(), Is.EqualTo("1"));
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n<=1"));

		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
			var firstStatement = ((CIfStatement)(_function.Body.Statements.ElementAt(0)))
				.TrueBlock
				.Statements
				.ElementAt(0)
				as CReturnStatement;
			// Assert.That(firstStatement is CReturnStatement);		// assert type
			Assert.That(firstStatement.Expression.ToString(), Is.EqualTo("1"));		// assert body
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var firstStatemenet = ((CIfStatement)(_function.Body.Statements.ElementAt(0)))
				.ElseBlock
				.Statements
				.ElementAt(0)
				as CReturnStatement;
			var exp = firstStatemenet.Expression as CBinaryExpression;
			// Assert.That(firstStatemenet is CReturnStatement);
			var leftExpression = exp.LeftExpression;
			var rightExpression = exp.RightExpression;
			var ope = exp.Operator;

			Assert.That(leftExpression is CPrimaryExpression);
			Assert.That(rightExpression is CInvocationExpression);

			Assert.That(leftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(ope.Type, Is.EqualTo(BinaryOperatorType.Multiplication));

			var rightFuncName = ((CInvocationExpression)rightExpression).FunctionName;
			var rightArg = (CBinaryExpression)((CInvocationExpression)rightExpression).Arguments.ElementAt(0);

			Assert.That(rightFuncName, Is.EqualTo("fact"));
			Assert.That(rightArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(rightArg.Operator.ToString(), Is.EqualTo("-"));
			Assert.That(rightArg.RightExpression.ToString(), Is.EqualTo("1"));
			Assert.That(rightArg.RightExpression is CPrimaryExpression);

			Assert.That(exp.ToString(), Is.EqualTo("n*fact(n-1)"));
		}

	}
}
