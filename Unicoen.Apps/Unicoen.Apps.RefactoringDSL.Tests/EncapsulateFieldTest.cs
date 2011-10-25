using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL.Tests {
	public class EncapsulateFieldTest {
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inPath = FixtureUtil.GetInputPath("Java", "default", "Encapsulate.java");
			var code = File.ReadAllText(inPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void リファクタリングする() {
			var enc = new EncapsulateField(_model);
			const string targetClassName = "Foo";
			var refactored = enc.Refactor(targetClassName);
			Console.WriteLine(JavaFactory.GenerateCode(refactored));
		}
	}
}
