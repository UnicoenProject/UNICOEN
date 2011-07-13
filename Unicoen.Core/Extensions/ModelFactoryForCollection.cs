#region License

// Copyright (C) 2011 The Unicoen Project
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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Core.Model {
	public static class ModelFactoryForCollection {
		public static UnifiedBlock ToBlock(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedBlock.Create(collection);
		}

		public static UnifiedBlock ToBlock(this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedBlock.Create(singleton);
		}

		public static UnifiedProgram ToProgram(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedProgram.Create(collection.ToBlock());
		}

		public static UnifiedProgram ToProgram(this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedProgram.Create(singleton.ToBlock());
		}

		public static UnifiedAnnotationCollection ToCollection(
				this IEnumerable<UnifiedAnnotation> collection) {
			return UnifiedAnnotationCollection.Create(collection);
		}

		public static UnifiedAnnotationCollection ToCollection(
				this UnifiedAnnotation singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedAnnotationCollection.Create(singleton);
		}

		public static UnifiedArgumentCollection ToCollection(
				this IEnumerable<UnifiedArgument> collection) {
			return UnifiedArgumentCollection.Create(collection);
		}

		public static UnifiedArgumentCollection ToCollection(
				this UnifiedArgument singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedArgumentCollection.Create(singleton);
		}

		public static UnifiedCaseCollection ToCollection(
				this IEnumerable<UnifiedCase> collection) {
			return UnifiedCaseCollection.Create(collection);
		}

		public static UnifiedCaseCollection ToCollection(this UnifiedCase singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedCaseCollection.Create(singleton);
		}

		public static UnifiedCatchCollection ToCollection(
				this IEnumerable<UnifiedCatch> collection) {
			return UnifiedCatchCollection.Create(collection);
		}

		public static UnifiedCatchCollection ToCollection(this UnifiedCatch singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedCatchCollection.Create(singleton);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedExpressionCollection.Create(collection);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedExpressionCollection.Create(singleton);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this IEnumerable<UnifiedIdentifier> collection) {
			return UnifiedIdentifierCollection.Create(collection);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this UnifiedIdentifier singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedIdentifierCollection.Create(singleton);
		}

		public static IUnifiedExpression ToProperty(
				this IEnumerable<IUnifiedExpression> collection, string delimiter) {
			return collection.ToList().ToProperty(delimiter);
		}

		public static IUnifiedExpression ToProperty(
				this IList<IUnifiedExpression> list, string delimiter) {
			Contract.Requires<ArgumentNullException>(list != null);
			Contract.Requires<ArgumentException>(list.Count >= 1);
			if (list.Count == 1) {
				return list[0];
			}
			return list.Skip(1).Aggregate(
					list[0],
					(l, r) => UnifiedProperty.Create(delimiter, l, r));
		}

		public static IUnifiedExpression ToProperty(
				this UnifiedIdentifier singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return singleton;
		}

		public static UnifiedMatcherCollection ToCollection(
				this IEnumerable<UnifiedMatcher> collection) {
			return UnifiedMatcherCollection.Create(collection);
		}

		public static UnifiedMatcherCollection ToCollection(
				this UnifiedMatcher singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedMatcherCollection.Create(singleton);
		}

		public static UnifiedModifierCollection ToCollection(
				this IEnumerable<UnifiedModifier> collection) {
			return UnifiedModifierCollection.Create(collection);
		}

		public static UnifiedModifierCollection ToCollection(
				this UnifiedModifier singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedModifierCollection.Create(singleton);
		}

		public static UnifiedParameterCollection ToCollection(
				this IEnumerable<UnifiedParameter> collection) {
			return UnifiedParameterCollection.Create(collection);
		}

		public static UnifiedParameterCollection ToCollection(
				this UnifiedParameter singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedParameterCollection.Create(singleton);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this IEnumerable<UnifiedGenericArgument> collection) {
			return UnifiedGenericArgumentCollection.Create(collection);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this UnifiedGenericArgument singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedGenericArgumentCollection.Create(singleton);
		}

		public static UnifiedThrowsTypeCollection ToCollection(
				this IEnumerable<UnifiedType> collection) {
			return UnifiedThrowsTypeCollection.Create(collection);
		}

		public static UnifiedThrowsTypeCollection ToCollection(
				this UnifiedType singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedThrowsTypeCollection.Create(singleton);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this IEnumerable<UnifiedTypeConstrain> collection) {
			return UnifiedTypeConstrainCollection.Create(collection);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this UnifiedTypeConstrain singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedTypeConstrainCollection.Create(singleton);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this IEnumerable<UnifiedGenericParameter> collection) {
			return UnifiedGenericParameterCollection.Create(collection);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this UnifiedGenericParameter singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedGenericParameterCollection.Create(singleton);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this IEnumerable<UnifiedVariableDefinition> collection) {
			return UnifiedVariableDefinitionList.Create(collection);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this UnifiedVariableDefinition singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedVariableDefinitionList.Create(singleton);
		}

		public static UnifiedListLiteral ToListLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedListLiteral.Create(collection);
		}

		public static UnifiedListLiteral ToListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedListLiteral.Create(expressions);
		}

		public static UnifiedListLiteral ToListLiteral(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedListLiteral.Create(singleton);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedArrayLiteral.Create(collection);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedArrayLiteral.Create(expressions);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedArrayLiteral.Create(singleton);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedSetLiteral.Create(collection);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedSetLiteral.Create(expressions);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedSetLiteral.Create(singleton);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedIterableLiteral.Create(collection);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedIterableLiteral.Create(expressions);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedIterableLiteral.Create(singleton);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedTupleLiteral.Create(collection);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedTupleLiteral.Create(expressions);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this IUnifiedExpression singleton) {
			Contract.Requires<ArgumentNullException>(singleton != null);
			return UnifiedTupleLiteral.Create(singleton);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.RemoveSelf();
				return expression;
			}
			return UnifiedListLiteral.Create(collection);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedListLiteral.Create(list);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.RemoveSelf();
				return expression;
			}
			return UnifiedArrayLiteral.Create(collection);
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedArrayLiteral.Create(list);
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.RemoveSelf();
				return expression;
			}
			return UnifiedSetLiteral.Create(collection);
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedSetLiteral.Create(list);
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.RemoveSelf();
				return expression;
			}
			return UnifiedIterableLiteral.Create(collection);
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedIterableLiteral.Create(list);
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.RemoveSelf();
				return expression;
			}
			return UnifiedTupleLiteral.Create(collection);
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedTupleLiteral.Create(list);
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}
	}
}