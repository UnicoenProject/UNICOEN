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
			var genericParameters = FindUtil.SearchGenericsField(model, "List");

			var list = targetClass.Body.DeepCopy();
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
}
