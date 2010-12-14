using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Languages.C.CodeModel;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForFibonacci
	{
		// function definition : public-static fields
		private CFunction _function;

		[SetUp]
		public void SetUp() {
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
			CIfStatement ifStatement = (CIfStatement)_function.Body.Statements.ElementAt(0);
			CBinaryExpression conditionalExpression = (CBinaryExpression)ifStatement.ConditionalExpression;
			Assert.That(ifStatement is CIfStatement);
			Assert.That(conditionalExpression is CBinaryExpression);
			CExpression leftExp = conditionalExpression.LeftExpression;
			CExpression rightExp = conditionalExpression.RightExpression;
			COperator ope = conditionalExpression.Operator;
			Assert.That(ope is CLessOperator);
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
				.ElementAt(0);
			Assert.That(firstStatement is CReturnStatement);		// assert type
			Assert.That(firstStatement.Expressions.ElementAt(0).ToString(), Is.EqualTo("n"));		// assert body
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var firstStatemenet = ((CIfStatement)(_function.Body.Statements.ElementAt(0)))
				.ElseBlock
				.Statements
				.ElementAt(0);
			CBinaryExpression exp = (CBinaryExpression)firstStatemenet.Expressions.ElementAt(0);
			Assert.That(firstStatemenet is CReturnStatement);
			CExpression leftExpression = exp.LeftExpression;
			CExpression rightExpression = exp.RightExpression;

			// assert whether left / right expression are 'MethodInvocation'
			Assert.That(leftExpression is CInvocationExpression);
			Assert.That(rightExpression is CInvocationExpression);

			var leftFuncName = ((CInvocationExpression)leftExpression).FunctionName;
			var leftArg = (CBinaryExpression)((CInvocationExpression)leftExpression).Arguments.ElementAt(0);

			Assert.That(leftFuncName, Is.EqualTo("fibonacci"));
			Assert.That(leftArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(leftArg.Operator is CMinusOperator);
			Assert.That(leftArg.RightExpression.ToString(), Is.EqualTo("2"));

			var rightFuncName = ((CInvocationExpression)rightExpression).FunctionName;
			var rightArg = (CBinaryExpression)((CInvocationExpression)rightExpression).Arguments.ElementAt(0);

			Assert.That(rightFuncName, Is.EqualTo("fibonacci"));
			Assert.That(rightArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(rightArg.Operator is CMinusOperator);
			Assert.That(rightArg.RightExpression.ToString(), Is.EqualTo("1"));
			Assert.That(rightArg.RightExpression is CNumber);

			Assert.That(exp.ToString(), Is.EqualTo("fibonacci(n-2)+fibonacci(n-1)"));

		}

	}
}
