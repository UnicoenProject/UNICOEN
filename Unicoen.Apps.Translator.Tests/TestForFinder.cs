using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Languages.Java;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Translator.Tests {
	public class TestForFinder {
		
		private UnifiedProgram _program;
		
		[SetUp]
		public void SetUp() {
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			_program = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void 関数をすべて取得できる() {
			var functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			Assert.That(functions.Count, Is.EqualTo(3));
		}



	}
}
