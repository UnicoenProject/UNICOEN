using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.RefactoringDSL.Util;

namespace Unicoen.Apps.RefactoringDSL.Tests {
	public class EncapsulateCollectionTest {
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Sandbox() {
			var arrays = SearchArrayField(_model);
			Console.Write(arrays.Count());

		}

		// このテストは，最低限の「手順」しか書かない！ その他の処理はヘルパに委譲する
		[Test]
		public void 下のヘルパたちを使ってリファクタリングしてみるテスト() {
			var arrays = SearchArrayField(_model);
			Console.Write(arrays.Count());
			
		}

		[Test]
		public void AfterXML() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			var model = JavaFactory.GenerateModel(code);

			var targetClass = FindUtil.FindClassByClassName(model, "Bar").First();
			Console.WriteLine(targetClass.ToXml());
		}

		[Test]
		public void TestForSearchArrayField() {
			var className = "Foo";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();

			Console.WriteLine(SearchArrayField(targetClass).Count());
		}

		[Test]
		public void TestForSearchGenericsField() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();

			Console.WriteLine(SearchGenericsField(targetClass, "List", "Integer").Count());
			var genericFields = SearchGenericsField(targetClass, "List", "*");

			Console.WriteLine(genericFields.Count());

			Assert.That(genericFields.Count(), Is.EqualTo(3));

			/*
			Console.WriteLine(((UnifiedVariableIdentifier)(genericFields.First().Descendants<UnifiedGenericType>().First().Type.BasicTypeName)).Name); // => List
			foreach(var arg in (genericFields.First().Descendants<UnifiedGenericType>().First().Arguments)) {
				var typeString = arg.Descendants<UnifiedIdentifier>().First().Name;
				Console.WriteLine(typeString);
			}// => Integer 
			 * */

		}

		[Test]
		public void TestForGenerateAddMethod() {
			
		}

		public UnifiedFunctionDefinition GenerateAddMethod(
			UnifiedFunctionDefinition collectionField,
			string functionName = "addElement", 
			UnifiedParameterCollection parameters = null) {
			var func = UnifiedFunctionDefinition.Create();
			func.Name = UnifiedIdentifier.CreateLabel(functionName);
			func.Modifiers = UnifiedModifierCollection.Create( UnifiedModifier.Create("public"));

			var parameter = UnifiedParameter.Create();
			parameter.Type = UnifiedType.Create("int");
			parameter.Names = UnifiedIdentifierCollection.Create(UnifiedIdentifier.CreateLabel("i"));

			func.Parameters = UnifiedParameterCollection.Create(parameter);

			var body = UnifiedBlock.Create();
			body.Add();
			func.Body = body;


		}

		[Test]
		public void TestForGenerateClonedField() {
			var variable = _model.Descendants<UnifiedVariableDefinition>().First();
			var cloned = GenerateClonedField(variable, "clone()");
			var code = JavaFactory.GenerateCode(cloned);
			Console.WriteLine(code);

		}

		// 入力されたフィールドをクローンしたフィールドを表すモデルを生成します
		// cloningMethodName でクローンに利用するメソッドの名前を指定します
		public static UnifiedElement GenerateClonedField(UnifiedVariableDefinition variable, string cloningMethodName = "clone") {
			var clonedField = UnifiedProperty.Create(
				".",
				variable.Name.DeepCopy(),
				UnifiedIdentifier.CreateLabel(cloningMethodName)
				);
			var cloned = UnifiedCall.Create(clonedField);

			return cloned;
		}


		// コレクションフィールドを検索します
		public static IEnumerable<UnifiedElement> SearchCollectionField(UnifiedProgram program) {
			return null;
		}

		// コレクションフィールドの種類を返します（最終的には適当なデータ構造に変換するよ）
		public static List<String> AllCollectionField(UnifiedProgram program) {
			return null;
		}

		// 配列フィールドの定義を探す
		public static IEnumerable<UnifiedElement> SearchArrayField(UnifiedElement element) {
			var fields = element.Descendants<UnifiedVariableDefinition>();
			return fields.Where(
				f => f.Descendants().Any(e => e is UnifiedArrayType));
		}

		// 指定されたジェネリクスを持つフィールドを探す
		// List<T> => basicType = List, type = T
		public static IEnumerable<UnifiedElement> SearchGenericsField(UnifiedElement element, string basicType, string type = "*") {
			var fields = element.Descendants<UnifiedVariableDefinition>();
			var genericsFields = fields.Where(
					f => f.Descendants().Any(e => e is UnifiedGenericType));

			var result =
					genericsFields.Where(
							f =>
							f.Descendants<UnifiedGenericType>()
							.Select(gt => ((UnifiedVariableIdentifier)gt.Type.BasicTypeName).Name).Contains(basicType));

			if (type != "*") {
				result =
						result.Where(
								f =>
								f.Descendants<UnifiedGenericType>().Select(gt => gt.Arguments).Select(
										arg => arg.Descendants<UnifiedIdentifier>().First().Name).Contains(type));

			}


			return result;

		}



	}
}
