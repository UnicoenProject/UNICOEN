namespace Ucpf.Core.Model.Extensions {
	public static class ModelFactoryForModel {
		public static UnifiedFunctionDefinition ToFunctionDefinition(this string name) {
			return new UnifiedFunctionDefinition {
					Name = name,
			};
		}

		public static UnifiedWhile ToWhile(this IUnifiedExpression condition) {
			return new UnifiedWhile {
					Condition = condition,
			};
		}

		public static UnifiedDoWhile ToDoWhile(this IUnifiedExpression condition) {
			return new UnifiedDoWhile {
					Condition = condition,
			};
		}

		public static UnifiedForeach ToForeach(this IUnifiedExpression set,
		                                       UnifiedType variableType,
		                                       string variableName) {
			return new UnifiedForeach {
					Element = new UnifiedVariableDefinition {
							Type = variableType,
							Name = variableName,
					},
					Set = set,
			};
		}

		public static UnifiedIf ToIf(this IUnifiedExpression condition) {
			return new UnifiedIf {
					Condition = condition,
			};
		}

		public static UnifiedJump ToReturn(this IUnifiedExpression value) {
			return UnifiedJump.CreateReturn( value);
		}

		public static UnifiedCase ToCase(this IUnifiedExpression condtion) {
			return new UnifiedCase {
					Condition = condtion,
			};
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