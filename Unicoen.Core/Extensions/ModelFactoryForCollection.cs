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
			return UnifiedBlock.Create(singleton);
		}

		public static UnifiedProgram ToProgram(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedProgram.Create(collection);
		}

		public static UnifiedProgram ToProgram(this IUnifiedExpression singleton) {
			return UnifiedProgram.Create(singleton);
		}

		public static UnifiedAnnotationCollection ToCollection(
				this IEnumerable<UnifiedAnnotation> collection) {
			return UnifiedAnnotationCollection.Create(collection);
		}

		public static UnifiedAnnotationCollection ToCollection(
				this UnifiedAnnotation singleton) {
			return UnifiedAnnotationCollection.Create(singleton);
		}

		public static UnifiedArgumentCollection ToCollection(
				this IEnumerable<UnifiedArgument> collection) {
			return UnifiedArgumentCollection.Create(collection);
		}

		public static UnifiedArgumentCollection ToCollection(
				this UnifiedArgument singleton) {
			return UnifiedArgumentCollection.Create(singleton);
		}

		public static UnifiedCaseCollection ToCollection(
				this IEnumerable<UnifiedCase> collection) {
			return UnifiedCaseCollection.Create(collection);
		}

		public static UnifiedCaseCollection ToCollection(this UnifiedCase singleton) {
			return UnifiedCaseCollection.Create(singleton);
		}

		public static UnifiedCatchCollection ToCollection(
				this IEnumerable<UnifiedCatch> collection) {
			return UnifiedCatchCollection.Create(collection);
		}

		public static UnifiedCatchCollection ToCollection(this UnifiedCatch singleton) {
			return UnifiedCatchCollection.Create(singleton);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedExpressionCollection.Create(collection);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IUnifiedExpression singleton) {
			return UnifiedExpressionCollection.Create(singleton);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this IEnumerable<UnifiedIdentifier> collection) {
			return UnifiedIdentifierCollection.Create(collection);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this UnifiedIdentifier singleton) {
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
			return singleton;
		}

		public static UnifiedMatcherCollection ToCollection(
				this IEnumerable<UnifiedMatcher> collection) {
			return UnifiedMatcherCollection.Create(collection);
		}

		public static UnifiedMatcherCollection ToCollection(
				this UnifiedMatcher singleton) {
			return UnifiedMatcherCollection.Create(singleton);
		}

		public static UnifiedModifierCollection ToCollection(
				this IEnumerable<UnifiedModifier> collection) {
			return UnifiedModifierCollection.Create(collection);
		}

		public static UnifiedModifierCollection ToCollection(
				this UnifiedModifier singleton) {
			return UnifiedModifierCollection.Create(singleton);
		}

		public static UnifiedParameterCollection ToCollection(
				this IEnumerable<UnifiedParameter> collection) {
			return UnifiedParameterCollection.Create(collection);
		}

		public static UnifiedParameterCollection ToCollection(
				this UnifiedParameter singleton) {
			return UnifiedParameterCollection.Create(singleton);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this IEnumerable<UnifiedGenericArgument> collection) {
			return UnifiedGenericArgumentCollection.Create(collection);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this UnifiedGenericArgument singleton) {
			return UnifiedGenericArgumentCollection.Create(singleton);
		}

		public static UnifiedTypeCollection ToCollection(
				this IEnumerable<UnifiedType> collection) {
			return UnifiedTypeCollection.Create(collection);
		}

		public static UnifiedTypeCollection ToCollection(this UnifiedType singleton) {
			return UnifiedTypeCollection.Create(singleton);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this IEnumerable<UnifiedTypeConstrain> collection) {
			return UnifiedTypeConstrainCollection.Create(collection);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this UnifiedTypeConstrain singleton) {
			return UnifiedTypeConstrainCollection.Create(singleton);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this IEnumerable<UnifiedTypeParameter> collection) {
			return UnifiedGenericParameterCollection.Create(collection);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this UnifiedTypeParameter singleton) {
			return UnifiedGenericParameterCollection.Create(singleton);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this IEnumerable<UnifiedVariableDefinition> collection) {
			return UnifiedVariableDefinitionList.Create(collection);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this UnifiedVariableDefinition singleton) {
			return UnifiedVariableDefinitionList.Create(singleton);
		}

		public static UnifiedList ToListLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedList.Create(collection);
		}

		public static UnifiedList ToListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(expressions);
		}

		public static UnifiedList ToListLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(singleton);
		}

		public static UnifiedArray ToArrayLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedArray.Create(collection);
		}

		public static UnifiedArray ToArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedArray.Create(expressions);
		}

		public static UnifiedArray ToArrayLiteral(this IUnifiedExpression singleton) {
			return UnifiedArray.Create(singleton);
		}

		public static UnifiedSet ToSetLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedSet.Create(collection);
		}

		public static UnifiedSet ToSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedSet.Create(expressions);
		}

		public static UnifiedSet ToSetLiteral(this IUnifiedExpression singleton) {
			return UnifiedSet.Create(singleton);
		}

		public static UnifiedIterable ToLazyListLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedIterable.Create(collection);
		}

		public static UnifiedIterable ToLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedIterable.Create(expressions);
		}

		public static UnifiedIterable ToLazyListLiteral(
				this IUnifiedExpression singleton) {
			return UnifiedIterable.Create(singleton);
		}

		public static UnifiedTuple ToTupleLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedTuple.Create(collection);
		}

		public static UnifiedTuple ToTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedTuple.Create(expressions);
		}

		public static UnifiedTuple ToTupleLiteral(this IUnifiedExpression singleton) {
			return UnifiedTuple.Create(singleton);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedList.Create(collection);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(list);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedArray.Create(collection);
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedArray.Create(list);
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedSet.Create(collection);
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedSet.Create(list);
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedIterable.Create(collection);
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedIterable.Create(list);
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedTuple.Create(collection);
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedTuple.Create(list);
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}
	}
}