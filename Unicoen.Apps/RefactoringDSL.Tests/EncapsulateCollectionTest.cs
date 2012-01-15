using System;//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.RefactoringDSL.Java;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.RefactoringDSL.Util;

namespace Unicoen.Apps.RefactoringDSL.Tests {
	public class EncapsulateCollectionTest {
		protected UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void リファクタリングエンジンを使ってリファクタリングしてみるテスト() {
			var className = "Bar";
			var engine = new EncapsulateCollection(_model);
			var refactored = engine.Refactor(className);

			Console.WriteLine(JavaFactory.GenerateCode(refactored));
		}
	}
}

