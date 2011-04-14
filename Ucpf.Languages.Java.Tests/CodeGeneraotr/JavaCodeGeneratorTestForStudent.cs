using System;
using System.IO;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.CodeGeneraotr;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests.CodeGeneraotr {
	[TestFixture]
	public class JavaCodeGeneratorTestForTest {
		private string _source;
		private UnifiedProgram _program;
		private string _generated;

		[SetUp]
		public void SetUp() {
			var path = Fixture.GetInputPath("Java", "Student.java");
			_source = File.ReadAllText(path);
			_program = JavaModelFactory.CreateModel(_source);
			_generated = JavaCodeGenerator.Generate(_program);
		}

		[Test]
		public void TestTest() {
			Console.Write(_generated);
		}
	}
}
