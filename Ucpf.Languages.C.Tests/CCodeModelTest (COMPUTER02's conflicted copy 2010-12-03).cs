using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Ucpf.Languages.C.Tests
{
	public class CCodeModelTest
	{
		[Test]
		public void CFunctionを生成できる()
		{
			var ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void パラメータリストが正しい()
		{
			var ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Parameters.ElementAt(0).Name, Is.EqualTo("n"));
			Assert.That(func.Parameters.ElementAt(0).Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void If文の条件式が正しい()
		{
			var ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Body.Statements.ElementAt(0).Type, Is.EqualTo("if"));
			Assert.That(((CIfStatement)(func.Body.Statements.ElementAt(0))).ConditionalExpression, Is.EqualTo("n<2"));
		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
			var ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			var firstStatement = ((CIfStatement)(func.Body.Statements.ElementAt(0)))
				.TrueBlock
				.Statements
				.ElementAt(0);
			Assert.That(firstStatement.Type, Is.EqualTo("jump"));		// assert type
			Assert.That(firstStatement.Expressions.ElementAt(0).Type, Is.EqualTo("n"));		// assert body
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
			var ast = CAstGenerator.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			var firstStatemenet = ((CIfStatement)(func.Body.Statements.ElementAt(0)))
				.ElseBlock
				.Statements
				.ElementAt(0);
			Assert.That(firstStatemenet is CJumpStatement);
			// Assert.That(firstStatemenet.Expressions.ElementAt(0).ToString(), Is.EqualTo("fibonacci(n-2)+fibonacci(n-1)"));
		}

	}
}
