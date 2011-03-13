using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Expressions;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelFactoryForPrimitive {
		public static UnifiedVariable ToVariable(this string name) {
			return UnifiedVariable.Create(name);
		}

		public static UnifiedType ToType(this string name) {
			return UnifiedType.Create(name);
		}

		public static UnifiedClassDefinition ToClassDefinition(this string name) {
			return new UnifiedClassDefinition {
				Name = name,
			};
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
