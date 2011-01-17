using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;
using System.IO;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForEmpty
	{
		private CModelToCode _cmtc;
		private StringWriter _writer;
		private CFunction _func;
		private static readonly string InputPath =
			Fixture.GetInputPath("C", "empty.c");

		[SetUp]
		public void SetUp()
		{
			_writer = new StringWriter();
			_cmtc = new CModelToCode(_writer, 0);
			_func = new CFunction(
						CAstGenerator.Instance.GenerateFromFile(InputPath)
						.Descendants("function_definition")
						.First());
		}

		[Test]
		public void 空文が正しく処理できる()
		{
			var stmt = _func.Body.Statements.ElementAt(0) as CIfStatement;
			var trueBlock = stmt.TrueBlock;
			var innerStatement = trueBlock.Statements.ElementAt(0);
			Assert.That(innerStatement.ToString(), Is.EqualTo(";"));
		}
	}
}
