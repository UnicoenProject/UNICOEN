using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL {
	class EncapsulateField {
		private UnifiedProgram _model;
		private UnifiedProgram _after;

		[SetUp]
		public void SetUp() {
			var inPath = FixtureUtil.GetInputPath("Java", "default", "Encapsulate.java");
			var code = File.ReadAllText(inPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
			
			inPath = FixtureUtil.GetInputPath("Java", "default", "Encapsulated.java");
			code = File.ReadAllText(inPath, Encoding.Default);
			_after = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Sandbox() {
			// クラス一覧
			var classes = _model.Descendants<UnifiedClassDefinition>();
			foreach(var classItem in classes) {
				Console.WriteLine((classItem.Name as UnifiedIdentifier).Name);
			}

			foreach(var classNode in classes) {
				var variables = classNode.Descendants<UnifiedVariableDefinition>();
				foreach (var variable in variables) {
					Console.WriteLine(variable.Name);
					
				}
			}
		}

		[Test]
		public void アクセッサ宣言部分を取得するテスト() {
			// var classDefinition = _after.Descendants<UnifiedClassDefinition>().Where(e => (e.Name as UnifiedIdentifier).Name.Equals("Foo")).First();
			var classes = FindByClassName(_after, "Foo");
			foreach (var c in classes) {
				Console.WriteLine((c.Name as UnifiedIdentifier).Name);
			}

			var targetClass = classes.First();
			var functionDefinitions = targetClass.Descendants<UnifiedFunctionDefinition>();
			foreach (var f in functionDefinitions) {
				foreach(var modifier in f.Modifiers) {
					Console.WriteLine(modifier.Name);
				}
				Console.WriteLine(f.Name.Name);
			}

			var code = JavaFactory.GenerateCode(functionDefinitions.First());
			Console.WriteLine(code);
			Console.Write(functionDefinitions.First().ToXml());


		}

		[Test]
		public void 任意にモデルを作ってみるテスト() {
			var func = new UnifiedFunctionDefinition();
			var identifier = UnifiedIdentifier.CreateLabel("getField");
			var modifier = UnifiedModifier.Create("public");
			func.Modifiers = UnifiedModifierCollection.Create(modifier);
			func.Type = UnifiedType.Create("int");

			var returnValue = UnifiedIdentifier.CreateVariable("field");
			var statemenet = UnifiedReturn.Create(returnValue);
			func.Body = UnifiedBlock.Create(statemenet);

			func.Name = identifier;
			Console.WriteLine(JavaFactory.GenerateCode(func));
		}
		public IEnumerable<UnifiedClassDefinition> FindByClassName(UnifiedProgram program, string className) {
			var result =
					program.Descendants<UnifiedClassDefinition>().Where(e => (e.Name as UnifiedIdentifier).Name.Equals(className));
			return result;
		}

	}
}
