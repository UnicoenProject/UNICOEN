using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Apps.RefactoringDSL.Java;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL {
	public class EncapsulateCollection{
		private UnifiedProgram Program { get; set; }

		// コンストラクタ
		public EncapsulateCollection(UnifiedProgram program) {
			this.Program = program;
		}

		public UnifiedProgram Refactor(string className) {
			var model = Program.DeepCopy();
			var targetClass = FindUtil.FindClassByClassName(model, className).First();
			if(targetClass == null) {
				throw new ClassNotFoundException();
			}
			var genericParameters = FindUtil.FindGenericsField(model, "List");

			var list = targetClass.Body.DeepCopy();
			var collections = FindUtil.FindGenericsField(list, "List");
			var rfs = EncapsulateCollectionHelper.FindReturningCollectionFunction(list, collections);

			// コレクションをそのまま返却している関数を削除
			var count = rfs.Count();
			for (var i = 0; i < count; i++) {
				rfs.First().RemoveSelf();
			}
			
			// コレクションを丸ごとセットしている関数を削除
			var sfs = EncapsulateCollectionHelper.FindSettingCollectionFunction(list, collections);
			count = sfs.Count();
			for (var i = 0; i < count; i++ ) {
				sfs.First().RemoveSelf();
			}

			// add / remove / colne メソッドを追加
			foreach (var gp in genericParameters) {
				var addingProcedure = EncapsulateCollectionHelperForJava.GenerateAddingProcedureForList((UnifiedVariableDefinition)gp);
				var removingProcedure = EncapsulateCollectionHelperForJava.GenerateRemovingProcedureForList((UnifiedVariableDefinition)gp);

				var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(gp, "addItem", addingProcedure);
				var removeMethod = EncapsulateCollectionHelper.GenerateRemoveMethod(gp, "removeItem", removingProcedure);
				var collectionFieldGetter = EncapsulateCollectionHelper.GenerateClonedFieldGetter((UnifiedVariableDefinition)gp);

				list.Add(addMethod);
				list.Add(removeMethod);
				list.Add(collectionFieldGetter);
			}


			targetClass.Body = list;

			return model;

		}
	}

	public class ClassNotFoundException : Exception {}
}
