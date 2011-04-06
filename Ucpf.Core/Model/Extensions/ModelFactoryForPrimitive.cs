using System;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelFactoryForPrimitive {
		public static UnifiedVariable ToVariable(this string name) {
			return UnifiedVariable.Create(name);
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name) {
			return new UnifiedVariableDefinition {
					Name = name,
			};
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             UnifiedType type) {
			return new UnifiedVariableDefinition {
					Type = type,
					Name = name,
			};
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             IUnifiedExpression
		                                                             		initialValue) {
			return new UnifiedVariableDefinition {
					Name = name,
					InitialValue = initialValue,
			};
		}

		public static UnifiedVariableDefinition ToVariableDefinition(this string name,
		                                                             UnifiedType type,
		                                                             IUnifiedExpression
		                                                             		initialValue) {
			return new UnifiedVariableDefinition {
					Type = type,
					Name = name,
					InitialValue = initialValue,
			};
		}

		public static UnifiedType ToType(this string name) {
			return UnifiedType.Create(name);
		}

		public static UnifiedClassDefinition ToClassDefinition(this string name) {
			return UnifiedClassDefinition.Create(name);
		}

		public static UnifiedBooleanLiteral ToLiteral(this bool literal) {
			return new UnifiedBooleanLiteral {
					Value = literal ? UnifiedBoolean.True : UnifiedBoolean.False,
			};
		}

		public static UnifiedIntegerLiteral ToLiteral(this int value) {
			return new UnifiedIntegerLiteral {
					Value = value,
			};
		}

		public static UnifiedDecimalLiteral ToLiteral(this double value) {
			return new UnifiedDecimalLiteral {
					Value = (Decimal)value,
			};
		}
	}
}