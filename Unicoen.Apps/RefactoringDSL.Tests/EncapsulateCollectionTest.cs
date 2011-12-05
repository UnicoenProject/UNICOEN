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
			if (targetClass == null) {
				return;
			}

			var block = targetClass.Body.DeepCopy();

			var collections = FindUtil.FindGenericsField(targetClass, "List", "*");
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

			Console.WriteLine(refactored.ToXml());
			Console.WriteLine(JavaFactory.GenerateCode(refactored));

		}

		// ---------------------- 以下サンドボックス（あとでどこかに引き上げる
		[Test]
		public void コレクションフィールドをそのまま返却している関数を探す() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var collections = FindUtil.FindGenericsField(targetClass, "List");

			var func =
					targetClass.Descendants<UnifiedFunctionDefinition>().Where(
							f => f.Body.Count == 1 && f.Body.First() is UnifiedReturn);
			var collectionNames = collections.Select(e => e as UnifiedVariableDefinition).Select(e => e.Name.Name);

			var result = func.Where(
					f => collectionNames.Contains(
							(((UnifiedReturn)f.Body.First()).Value as UnifiedVariableIdentifier).Name));

			// 当該ノードの削除
			result.First().RemoveSelf();


			Console.WriteLine(JavaFactory.GenerateCode(targetClass));

		}

		[Test]
		public void コレクションフィールドにコレクションをセットしている関数を探す() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var collections = FindUtil.FindGenericsField(targetClass, "List");

			var collectionNames = collections.Select(e => e as UnifiedVariableDefinition).Select(e => e.Name.Name);
			var func = targetClass.Descendants<UnifiedFunctionDefinition>()
					.Where(e => e.Body.Count == 1 && e.Body.First() is UnifiedBinaryExpression) // 2項演算式で
					.Where(e => ((UnifiedBinaryExpression)e.Body.First()).Operator.Kind == UnifiedBinaryOperatorKind.Assign)
					.Where(e => collectionNames.Contains((((UnifiedBinaryExpression)e.Body.First()).LeftHandSide as UnifiedVariableIdentifier).Name));  // とりあえずは名前で判断

			Console.WriteLine(func.Count());
			func.First().RemoveSelf();

			Console.WriteLine(JavaFactory.GenerateCode(targetClass));
		}


	}
}

