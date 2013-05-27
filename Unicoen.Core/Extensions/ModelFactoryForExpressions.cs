#region License

// Copyright (C) 2011-2012 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections.Generic;
using System.Linq;

namespace Unicoen.Model {
	public static class ProgramGeneratorForExpressions {
		public static UnifiedBlock ToBlock(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedBlock.Create(expressions);
		}

		public static UnifiedBlock ToBlock(this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedBlock.Create();
			}
			return UnifiedBlock.Create(singleton);
		}

		public static UnifiedProgram ToProgram(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedProgram.Create(expressions.ToBlock());
		}

		public static UnifiedProgram ToProgram(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedProgram.Create(UnifiedBlock.Create());
			}
			return UnifiedProgram.Create(singleton.ToBlock());
		}

		public static UnifiedExpressionList ToExpressionList(
				this IEnumerable<UnifiedExpression> collection) {
			return UnifiedExpressionList.Create(collection);
		}

		public static UnifiedExpressionList ToExpressionList(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedExpressionList.Create();
			}
			return UnifiedExpressionList.Create(singleton);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this IEnumerable<UnifiedVariableDefinition> expressions) {
			return UnifiedVariableDefinitionList.Create(expressions);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this UnifiedVariableDefinition singleton) {
			if (singleton == null) {
				return UnifiedVariableDefinitionList.Create();
			}
			return UnifiedVariableDefinitionList.Create(singleton);
		}

		public static UnifiedListLiteral ToListLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedListLiteral.Create(expressions);
		}

		public static UnifiedListLiteral ToListLiteral(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedListLiteral.Create();
			}
			return UnifiedListLiteral.Create(singleton);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedArrayLiteral.Create(expressions);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedArrayLiteral.Create();
			}
			return UnifiedArrayLiteral.Create(singleton);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedSetLiteral.Create(expressions);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedSetLiteral.Create();
			}
			return UnifiedSetLiteral.Create(singleton);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedIterableLiteral.Create(expressions);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedIterableLiteral.Create();
			}
			return UnifiedIterableLiteral.Create(singleton);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			return UnifiedTupleLiteral.Create(expressions);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedTupleLiteral.Create();
			}
			return UnifiedTupleLiteral.Create(singleton);
		}

		public static UnifiedLinqExpression ToLinqExpression(
				this IEnumerable<UnifiedLinqQuery> collection) {
			return UnifiedLinqExpression.Create(collection);
		}

		public static UnifiedLinqExpression ToLinqExpression(
				this UnifiedLinqQuery singleton) {
			if (singleton == null) {
				return UnifiedLinqExpression.Create();
			}
			return UnifiedLinqExpression.Create(singleton);
		}
	}
}