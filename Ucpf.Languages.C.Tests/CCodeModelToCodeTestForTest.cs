using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;
using Ucpf.Languages.C.CodeModel;
using System.IO;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelToCodeTest
	{
		private CCodeModelToCode _cmtc;
		private StringWriter _writer;
		private CFunction _func;

		[SetUp]
		public void SetUp()
		{
			_writer = new StringWriter();
			_cmtc = new CCodeModelToCode(_writer, 0);
			_func = new CFunction(
						CAstGenerator.Instance.GenerateFromFile("assignment.c")
						.Descendants("function_definition")
						.First());		
		}

		[Test]
		public void 型を正しくコードに変換できる()
		{
			var type = new CType("int");
			_cmtc.Generate(type);
			var actual = _writer.ToString();
			Assert.That(actual, Is.EqualTo("int"));
		}
		[Test]
		public void 二項演算式を正しくコードに変換できる()
		{
			CIfStatement ifStatement = (CIfStatement)_func.Body.Statements.ElementAt(0);
			CBinaryExpression conditionalExpression = (CBinaryExpression)ifStatement.ConditionalExpression;
			
			_cmtc.Generate(conditionalExpression);
			Assert.That(_writer.ToString(), Is.EqualTo("n < 2"));
			
		}
		[Test]
		public void ブロックを正しくコードに変換できる()
		{
			var trueBlock = ((CIfStatement)(_func.Body.Statements.ElementAt(0)))
				.TrueBlock;
			_cmtc.Generate(trueBlock);
			var actual = _writer.ToString();
			
			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		// GOAL
		[Test]
		public void 関数が正しくコードに変換できる()
		{
			_cmtc.Generate(_func);
			var actual = _writer.ToString();
//			string expexted;
//			using (var reader = new StreamReader("expected")) {
//				expexted = reader.ReadToEnd();
//			}

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);

		}

	}
}
