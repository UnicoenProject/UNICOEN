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
			var ast = CAstGeneratorOld.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void パラメータリストが正しい()
		{
			var ast = CAstGeneratorOld.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Arguments.ElementAt(0).Name, Is.EqualTo("n"));
			Assert.That(func.Arguments.ElementAt(0).Type.Name, Is.EqualTo("int"));
		}

		[Test]
		public void IF文がうまく拾えている()
		{
			var ast = CAstGeneratorOld.Instance.GenerateFromFile("fibonacci.c");
			var root = ast.Descendants("function_definition").First();
			var func = new CFunction(root);
			Assert.That(func.Body.Statements.ElementAt(0).Type, Is.EqualTo("if"));
		}
	}
}
