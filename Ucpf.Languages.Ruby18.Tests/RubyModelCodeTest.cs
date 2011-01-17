using System.Linq;
using NUnit.Framework;
using System.IO;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.Ruby18.Tests {
	[TestFixture]
	public class RubyModelCodeTest {
		private RubyModelToCode _rmtc;
		private StringWriter _writer;
		private CFunction _func;

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
			System.Diagnostics.Debug.WriteLine(actual);

		}
	}
}
