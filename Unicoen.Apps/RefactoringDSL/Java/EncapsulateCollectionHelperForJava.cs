using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.Java {
	public class EncapsulateCollectionHelperForJava {
		// Java におけるリスト要素の追加を作成する例
		public static UnifiedBlock GenerateAddingProcedureForList(UnifiedVariableDefinition list) {
			var name = list.Name;
			var property = UnifiedProperty.Create(
					".",
					name.DeepCopy(),
					UnifiedIdentifier.CreateLabel("add"));
			var call = UnifiedCall.Create();
			call.Function = property;

			var argument = UnifiedArgument.Create(UnifiedIdentifier.CreateLabel("object"));
			var arguments = UnifiedArgumentCollection.Create(argument);
			call.Arguments = arguments;


			var block = UnifiedBlock.Create();
			block.Add(call);
			
			return block;
		}

		// Javaにおけるリスト要素の削除を作成する例
		public static UnifiedBlock GenerateRemovingProcedureForList(UnifiedVariableDefinition list) {
			var name = list.Name;

			var property = UnifiedProperty.Create(
					".",
					name.DeepCopy(),
					UnifiedIdentifier.CreateLabel("remove"));
			var call = UnifiedCall.Create();
			call.Function = property;

			var argument = UnifiedArgument.Create(UnifiedIdentifier.CreateLabel("i"));
			var arguments = UnifiedArgumentCollection.Create(argument);
			call.Arguments = arguments;


			var block = UnifiedBlock.Create();
			block.Add(call);
			
			return block;

		}
	}
}
