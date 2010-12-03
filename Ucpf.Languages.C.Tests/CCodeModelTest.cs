using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;

namespace Ucpf.Languages.C.Tests
{
	public class CCodeModelTest
	{
		// function definition : public-static fields
		public static XElement ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
		public static XElement root = ast.Descendants("function_definition").First();
		CFunction func = new CFunction(root);
		
		[Test]
		public void メソッド返却値タイプが正しい()
		{
			Assert.That(func.ReturnType.Name, Is.EqualTo("int"));
		}
		[Test]
		public void メソッド名が正しい()
		{
			Assert.That(func.Name, Is.EqualTo("fibonacci"));
		}

		// test whether the first parameter equals to (int, "n")
		[Test]
		public void パラメータリストが正しい()
		{
			Assert.That(func.Parameters.ElementAt(0).Name, Is.EqualTo("n"));
			Assert.That(func.Parameters.ElementAt(0).Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void IF文の条件式が正しい()
		{
			CIfStatement ifStatement = (CIfStatement)func.Body.Statements.ElementAt(0);
			CBinaryExpression conditionalExpression = (CBinaryExpression)ifStatement.ConditionalExpression;
			Assert.That(ifStatement.Type, Is.EqualTo("if"));
			Assert.That(conditionalExpression.Type, Is.EqualTo("binary"));
			CExpression leftExp = conditionalExpression.LeftExpression;
			CExpression rightExp = conditionalExpression.RightExpression;
			COperator ope = conditionalExpression.Operator;
			
			Assert.That(ope.ToString(), Is.EqualTo("<"));
			Assert.That(leftExp.ToString(), Is.EqualTo("n"));
			Assert.That(rightExp.ToString(), Is.EqualTo("2"));
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n<2"));

		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
			var firstStatement = ((CIfStatement)(func.Body.Statements.ElementAt(0)))
				.TrueBlock
				.Statements
				.ElementAt(0);
			Assert.That(firstStatement.Type, Is.EqualTo("jump"));		// assert type
			Assert.That(firstStatement.Expressions.ElementAt(0).ToString(), Is.EqualTo("n"));		// assert body
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var firstStatemenet = ((CIfStatement)(func.Body.Statements.ElementAt(0)))
				.ElseBlock
				.Statements
				.ElementAt(0);
			CBinaryExpression exp = (CBinaryExpression)firstStatemenet.Expressions.ElementAt(0);
			Assert.That(firstStatemenet is CJumpStatement);
			CExpression leftExpression = exp.LeftExpression;
			CExpression rightExpression = exp.RightExpression;

			Assert.That(leftExpression is CInvocationExpression);
			Assert.That(rightExpression is CInvocationExpression);

			var leftFuncName = ((CInvocationExpression)leftExpression).FunctionName;
			var leftArg = (CBinaryExpression)((CInvocationExpression)leftExpression).Arguments.ElementAt(0);

			Assert.That(leftFuncName, Is.EqualTo("fibonacci"));
			Assert.That(leftArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(leftArg.Operator.ToString(), Is.EqualTo("-"));
			Assert.That(leftArg.RightExpression.ToString(), Is.EqualTo("2"));

			var rightFuncName = ((CInvocationExpression)rightExpression).FunctionName;
			var rightArg = (CBinaryExpression)((CInvocationExpression)rightExpression).Arguments.ElementAt(0);

			Assert.That(rightFuncName, Is.EqualTo("fibonacci"));
			Assert.That(rightArg.LeftExpression.ToString(), Is.EqualTo("n"));
			Assert.That(rightArg.Operator.ToString(), Is.EqualTo("-"));
			Assert.That(rightArg.RightExpression.ToString(), Is.EqualTo("1"));

			Assert.That(exp.ToString(), Is.EqualTo("fibonacci(n-2)+fibonacci(n-1)"));

		}

	}
}
