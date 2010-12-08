using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Languages.C.CodeModel;
using Ucpf.Languages.C.CodeModel.Expressions;
using Ucpf.Languages.C.CodeModel.Expressions.PrimaryExpressions;
using Ucpf.Languages.C.CodeModel.Statements;

namespace Ucpf.Languages.C.Tests
{
	public class CCodeModelTest
	{
		// function definition : private fields
		private XElement _ast;
		private XElement _root;
		private CFunction _func;

		[SetUp]
		public void SetUp() {
			_ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			_root = _ast.Descendants("function_definition").First();
			_func = new CFunction(_root);
		}
		
		[Test]
		public void メソッド返却値タイプが正しい()
		{
			Assert.That(_func.ReturnType.Name, Is.EqualTo("int"));
		}

		[Test]
		public void メソッド名が正しい()
		{
			Assert.That(_func.Name, Is.EqualTo("fibonacci"));
		}

		// test whether the first parameter equals to (int, "n")
		[Test]
		public void パラメータリストが正しい()
		{
			Assert.That(_func.Parameters.ElementAt(0).Name, Is.EqualTo("n"));
			Assert.That(_func.Parameters.ElementAt(0).Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void If文の条件式が正しい()
		{
			// キャストに失敗すると例外が発生してテストも失敗
			var ifStatement = (CIfStatement)_func.Body.Statements.ElementAt(0);
			var conditionalExpression = (CBinaryExpression)ifStatement.ConditionalExpression;
			var leftExp = conditionalExpression.LeftExpression;
			var rightExp = conditionalExpression.RightExpression;
			var ope = conditionalExpression.Operator;
			
			Assert.That(ope.ToString(), Is.EqualTo("<"));
			Assert.That(leftExp.ToString(), Is.EqualTo("n"));
			Assert.That(rightExp.ToString(), Is.EqualTo("2"));
			Assert.That(conditionalExpression.ToString(), Is.EqualTo("n<2"));

		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
			var firstStatement = ((CIfStatement)(_func.Body.Statements.ElementAt(0)))
				.TrueBlock
				.Statements
				.ElementAt(0);
			Assert.That(firstStatement is CJumpStatement);		// assert type
			Assert.That(firstStatement.Expressions.ElementAt(0).ToString(), Is.EqualTo("n"));		// assert body
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var firstStatemenet = ((CIfStatement)(_func.Body.Statements.ElementAt(0)))
				.ElseBlock
				.Statements
				.ElementAt(0);
			var exp = (CBinaryExpression)firstStatemenet.Expressions.ElementAt(0);
			Assert.That(firstStatemenet is CJumpStatement);
			var leftExpression = exp.LeftExpression;
			var rightExpression = exp.RightExpression;

			// assert whether left / right expression are 'MethodInvocation'
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
			Assert.That(rightArg.RightExpression is CNumber);

			Assert.That(exp.ToString(), Is.EqualTo("fibonacci(n-2)+fibonacci(n-1)"));

		}

	}
}
