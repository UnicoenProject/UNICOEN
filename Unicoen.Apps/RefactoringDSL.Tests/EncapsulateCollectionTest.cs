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
		public void リファクタリングエンジンを使ってリファクタリングしてみるテスト() {
			var className = "Bar";
			var engine = new EncapsulateCollection(_model);
			var refactored = engine.Refactor(className);

			Console.WriteLine(JavaFactory.GenerateCode(refactored));

		}

		// ---------------------- 以下サンドボックス（あとでどこかに引き上げる
		[Test]
		public void コレクションフィールドをそのまま返却している関数を探す() {
			
		}

		[Test]
		public void コレクションフィールドをセットしている関数を探す() {
			
		}



	}
}
