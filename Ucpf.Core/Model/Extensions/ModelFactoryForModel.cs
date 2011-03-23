namespace Ucpf.Core.Model.Extensions {
	public static class ModelFactoryForModel {
		public static UnifiedFunctionDefinition ToFunctionDefinition(this string name) {
			return new UnifiedFunctionDefinition {
					Name = name,
			};
		}

		public static UnifiedWhile ToWhile(this UnifiedExpression condition) {
			return new UnifiedWhile {
					Condition = condition,
			};
		}

		public static UnifiedDoWhile ToDoWhile(this UnifiedExpression condition) {
			return new UnifiedDoWhile {
					Condition = condition,
			};
		}

		public static UnifiedForeach ToForeach(this UnifiedExpression set,
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

		public static UnifiedIf ToIf(this UnifiedExpression condition) {
			return new UnifiedIf {
					Condition = condition,
			};
		}

		public static UnifiedReturn ToReturn(this UnifiedExpression value) {
			return new UnifiedReturn {
					Value = value,
			};
		}

		public static UnifiedCase ToCase(this UnifiedExpression condtion) {
			return new UnifiedCase {
					Condition = condtion,
			};
		}

		public static UnifiedSwitch ToSwitch(this UnifiedExpression value) {
			return new UnifiedSwitch {
					Value = value,
			};
		}

		public static UnifiedTypeParameter ToTypeParameter(
				this UnifiedExpression value) {
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