using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;
using Ucpf.Languages.C.AstGenerators;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyModelCodeTest {
		#region Setup/Teardown

		[SetUp]
		public void SetUp() {
			_writer = new StringWriter();
			_rmtc = new RubyModelToCode(_writer, 0);
			_func = new CFunction(
				CAstGenerator.Instance.GenerateFromFile(
					Fixture.GetInputPath("C", "fibonacci2.c"))
					.Descendants("function_definition")
					.First());
		}

		#endregion

		private RubyModelToCode _rmtc;
		private StringWriter _writer;
		private CFunction _func;

		[Test]
		public void 型を正しくコードに変換できる() {
			var type = new CType("int");
			_rmtc.Generate(type);
			var actual = _writer.ToString();
			Assert.That(actual, Is.EqualTo(""));
		}

		[Test]
		public void 関数が正しくコードに変換できる() {
			_rmtc.Generate(_func);
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