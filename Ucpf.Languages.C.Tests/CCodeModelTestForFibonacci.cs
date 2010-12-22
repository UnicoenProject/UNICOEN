using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.CodeModel;
using Ucpf.Languages.C.CodeModel;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForFibonacci
	{
		// function definition : public-static fields
		private CFunction _function;

		[SetUp]
		public void SetUp()
		{
			_function = new CFunction(
				CAstGenerator.Instance.GenerateFromFile("fibonacci.c")
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
			Assert.That(_function.Name, Is.EqualTo("fibonacci"));
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

			Assert.That(ope.Sign, Is.EqualTo("<"));
			Assert.That(ope.Type, Is.EqualTo(BinaryOperatorType.Lesser));
			Assert.That(leftExp.ToString(), Is.EqualTo("n"));
			Assert.That(rightExp.ToString(), Is.EqualTo("2"));
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n<2"));

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
			Assert.That(firstStatement.Expression.ToString(), Is.EqualTo("n"));		// assert body
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

			// assert whether left / right expression are 'MethodInvocation'
			Assert.That(leftExpression is CInvocationExpression);
			Assert.That(rightExpression is CInvocationExpression);

			var leftFuncName = ((CInvocationExpression)leftExpression).FunctionName;
			var leftArg = (CBinaryExpression)((CInvocationExpression)leftExpression).Arguments.ElementAt(0);

			Assert.That(leftFuncName, Is.EqualTo("fibonacci"));
			Assert.That(leftArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(leftArg.Operator.Type, Is.EqualTo(BinaryOperatorType.Subtraction));
			Assert.That(leftArg.RightExpression.ToString(), Is.EqualTo("2"));

			var rightFuncName = ((CInvocationExpression)rightExpression).FunctionName;
			var rightArg = (CBinaryExpression)((CInvocationExpression)rightExpression).Arguments.ElementAt(0);

			Assert.That(rightFuncName, Is.EqualTo("fibonacci"));
			Assert.That(rightArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(rightArg.Operator.Type, Is.EqualTo(BinaryOperatorType.Subtraction));
			Assert.That(rightArg.RightExpression.ToString(), Is.EqualTo("1"));
			Assert.That(rightArg.RightExpression is CNumber);

			Assert.That(exp.ToString(), Is.EqualTo("fibonacci(n-2)+fibonacci(n-1)"));

		}

	}
}
