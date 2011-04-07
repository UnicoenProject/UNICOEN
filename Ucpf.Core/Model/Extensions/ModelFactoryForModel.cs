namespace Ucpf.Core.Model.Extensions {
	public static class ModelFactoryForModel {
		public static UnifiedFunctionDefinition ToFunctionDefinition(this string name) {
			return UnifiedFunctionDefinition.Create(name);
		}

		public static UnifiedWhile ToWhile(this IUnifiedExpression condition) {
			return UnifiedWhile.Create(condition);
		}

		public static UnifiedDoWhile ToDoWhile(this IUnifiedExpression condition) {
			return UnifiedDoWhile.Create(condition);
		}

		public static UnifiedForeach ToForeach(this IUnifiedExpression set,
		                                       UnifiedType variableType,
		                                       string variableName) {
			return UnifiedForeach.Create(
				UnifiedVariableDefinition.Create(variableType, variableName),
				set
			);
		}

		public static UnifiedIf ToIf(this IUnifiedExpression condition) {
			return UnifiedIf.Create(condition);
		}

		public static UnifiedJump ToReturn(this IUnifiedExpression value) {
			return UnifiedJump.CreateReturn( value);
		}

		public static UnifiedCase ToCase(this IUnifiedExpression condtion) {
			return UnifiedCase.Create(condtion, UnifiedBlock.Create());
		}

		public static UnifiedSwitch ToSwitch(this IUnifiedExpression value) {
			return new UnifiedSwitch {
					Value = value,
			};
		}

		public static UnifiedTypeParameter ToTypeParameter(
				this IUnifiedExpression value) {
			return new UnifiedTypeParameter {
					Value = value,
			};
		}

		public static UnifiedNew ToNew(this UnifiedType type) {
			return new UnifiedNew {
					Type = type,
			};
		}
	}
}