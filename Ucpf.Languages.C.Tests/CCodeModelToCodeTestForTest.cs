using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;

namespace Ucpf.Languages.C.Tests {
	[TestFixture]
	public class CCodeModelToCodeTest {
		#region Setup/Teardown

		[SetUp]
		public void SetUp() {
			_writer = new StringWriter();
			_cmtc = new CModelToCode(_writer, 0);
			_func = new CFunction(
				CAstGenerator.Instance.GenerateFromFile(InputPath)
					.Descendants("function_definition")
					.First());
		}

		#endregion

		private CModelToCode _cmtc;
		private StringWriter _writer;
		private CFunction _func;

		private static readonly string InputPath =
			Fixture.GetInputPath("C", "assignment.c");

		[Test]
		public void ブロックを正しくコードに変換できる() {
			var trueBlock = ((CIfStatement)(_func.Body.Statements.ElementAt(0)))
				.TrueBlock;
			_cmtc.Generate(trueBlock);
			var actual = _writer.ToString();

			// DebugPrint
			Debug.WriteLine(actual);
		}

		[Test]
		public void 二項演算式を正しくコードに変換できる() {
			var ifStatement = (CIfStatement)_func.Body.Statements.ElementAt(0);
			var conditionalExpression =
				(CBinaryExpression)ifStatement.ConditionalExpression;

			_cmtc.Generate(conditionalExpression);
			Assert.That(_writer.ToString(), Is.EqualTo("n == 1"));
		}

		[Test]
		public void 型を正しくコードに変換できる() {
			var type = new CType("int");
			_cmtc.Generate(type);
			var actual = _writer.ToString();
			Assert.That(actual, Is.EqualTo("int"));
		}

		// GOAL
		[Test]
		public void 関数が正しくコードに変換できる() {
			_cmtc.Generate(_func);
			var actual = _writer.ToString();
			//			string expexted;
			//			using (var reader = new StreamReader("expected")) {
			//				expexted = reader.ReadToEnd();
			//			}

			// DebugPrint
			Debug.WriteLine(actual);
		}
	}
}