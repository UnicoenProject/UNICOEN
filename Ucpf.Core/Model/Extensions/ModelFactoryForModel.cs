using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Expressions;

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
	}
}
