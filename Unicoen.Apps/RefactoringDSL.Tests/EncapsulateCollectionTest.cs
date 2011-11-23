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
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void SearchArrayFieldのテスト() {
			var arrays = FindUtil.SearchArrayField(_model);
			Console.Write(arrays.Count());
		}

		[Ignore]
		public void 生成されたXMLを見るためのテスト() {
			Console.WriteLine(_model.ToXml());
		}

		
		[Test]
		public void 下のヘルパたちを使ってリファクタリングしてみるテスト() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			if(targetClass == null) {
				return;
			}

			var block = targetClass.Body.DeepCopy();

			var collections = FindUtil.SearchGenericsField(targetClass, "List", "*");
			foreach (var collection in collections) {
				var addingProcedure = EncapsulateCollectionHelperForJava.GenerateAddingProcedureForList((UnifiedVariableDefinition)collection);
				var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(collection, "addElement", addingProcedure);
				var removingProcedure = EncapsulateCollectionHelperForJava.GenerateRemovingProcedureForList((UnifiedVariableDefinition)collection);
				var removeMethod = EncapsulateCollectionHelper.GenerateRemoveMethod(collection, "removeElement", removingProcedure);

				block.Add(addMethod);
				block.Add(removeMethod);
			}

			var programBlock = UnifiedBlock.Create();
			var resultClass = targetClass.DeepCopy();
			resultClass.Body = block;

			programBlock.Add(resultClass);
			Console.WriteLine(JavaFactory.GenerateCode(programBlock));


		}

		[Test]
		public void AfterXML() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "EncapsulateCollection.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			var model = JavaFactory.GenerateModel(code);

			var targetClass = FindUtil.FindClassByClassName(model, "Bar").First();
			Console.WriteLine(targetClass.ToXml());}

		[Test]
		public void TestForSearchArrayField() {
			var className = "Foo";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();

			Console.WriteLine(FindUtil.SearchArrayField(targetClass).Count());
		}

		[Test]
		public void TestForSearchGenericsField() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var genericFields = FindUtil.SearchGenericsField(targetClass, "List", "*");

			Assert.That(genericFields.Count(), Is.EqualTo(1));

			/*
			Console.WriteLine(((UnifiedVariableIdentifier)(genericFields.First().Descendants<UnifiedGenericType>().First().Type.BasicTypeName)).Name); // => List
			foreach(var arg in (genericFields.First().Descendants<UnifiedGenericType>().First().Arguments)) {
				var typeString = arg.Descendants<UnifiedIdentifier>().First().Name;
				Console.WriteLine(typeString);
			}// => Integer 
			 * */
		}

		[Test]
		public void TestForGetParameterAsType() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var genericField = FindUtil.SearchGenericsField(targetClass, "List", "*").First();

			var type = FindUtil.GetTypeParameterAsType(
					(UnifiedGenericType)((UnifiedVariableDefinition)genericField).Type);

			Assert.That((type.BasicTypeName as UnifiedIdentifier).Name, Is.EqualTo("Integer"));		
			// Console.WriteLine((type.BasicTypeName as UnifiedIdentifier).Name);
		}


		[Test]
		public void TestForGenerateRemoveMethod() {
			var list = FindUtil.SearchGenericsField(_model, "List").First();
			var removingProcedure = EncapsulateCollectionHelperForJava.GenerateRemovingProcedureForList((UnifiedVariableDefinition)list);
			var removeMethod = EncapsulateCollectionHelper.GenerateRemoveMethod(list, "removeItem", removingProcedure);
			
			Console.WriteLine(JavaFactory.GenerateCode(removeMethod));
		}



		[Test]
		public void TestForGenerateAddMethod() {
			var list = FindUtil.SearchGenericsField(_model, "List").First();
			var addingProcedure = EncapsulateCollectionHelperForJava.GenerateAddingProcedureForList((UnifiedVariableDefinition)list);
			var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(list, "addItem", addingProcedure);
			
			Console.WriteLine(JavaFactory.GenerateCode(addMethod));
			
			
		}

		
		[Test]
		public void TestForGenerateClonedField() {
			var variable = _model.Descendants<UnifiedVariableDefinition>().First();
			var cloned = EncapsulateCollectionHelper.GenerateClonedField(variable, "clone()");
			var code = JavaFactory.GenerateCode(cloned);
			Console.WriteLine(code);

		}

	}
}
