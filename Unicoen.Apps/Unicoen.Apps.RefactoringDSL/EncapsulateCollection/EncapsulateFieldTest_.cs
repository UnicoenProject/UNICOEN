using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL.EncapsulateCollection {
	public class EncapsulateFieldTest_ {
		private UnifiedProgram _model;
		private UnifiedProgram _after;

		[SetUp]
		public void SetUp() {
			var inPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);

			inPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection_After.java");
			code = File.ReadAllText(inPath, Encoding.Default);
			_after = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Sandbox() {
			var inPath = FixtureUtil.GetInputPath("Java", "default", "en.rb");
			var code = File.ReadAllText(inPath, Encoding.Default);
			var model = Ruby18ModelFactory.Instance.Generate(code);
			Console.WriteLine(model.ToXml());
		}



	}
}
