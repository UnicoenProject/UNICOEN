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
			var body = targetClass.Body.DeepCopy();

			// TODO コレクションタイプの任意・複数指定
			var collections = FindUtil.FindGenericsField(body, "List");
			var rfs = EncapsulateCollectionHelper.FindReturningCollectionFunction(body, collections);

			// コレクションをそのまま返却している関数を削除
			var count = rfs.Count();
			for (var i = 0; i < count; i++) {
				rfs.First().RemoveSelf();
			}
			
			// コレクションを丸ごとセットしているような関数を削除
			var sfs = EncapsulateCollectionHelper.FindSettingCollectionFunction(body, collections);
			count = sfs.Count();
			for (var i = 0; i < count; i++ ) {
				sfs.First().RemoveSelf();
			}

			// add / remove / colne メソッドを追加
			// TODO コレクションタイプの任意・複数指定
			var genericParameters = FindUtil.FindGenericsField(model, "List");
			foreach (var gp in genericParameters) {
				var addingProcedure = EncapsulateCollectionHelperForJava.GenerateAddingProcedureForList((UnifiedVariableDefinition)gp);
				var removingProcedure = EncapsulateCollectionHelperForJava.GenerateRemovingProcedureForList((UnifiedVariableDefinition)gp);

				var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(gp, "addItem", addingProcedure);
				var removeMethod = EncapsulateCollectionHelper.GenerateRemoveMethod(gp, "removeItem", removingProcedure);
				var collectionFieldGetter = EncapsulateCollectionHelper.GenerateClonedFieldGetter((UnifiedVariableDefinition)gp);

				body.Add(addMethod);
				body.Add(removeMethod);
				body.Add(collectionFieldGetter);
			}

			targetClass.Body = body;
			return model;
		}
	}

	public class ClassNotFoundException : Exception {
		public ClassNotFoundException() : base("クラス探したけど見つからなかったorz") {}
	}
}
