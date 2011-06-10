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

using System.Collections.Generic;
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
			var first = collection.First();
			if (collection.Count() == 1) {
				return first;
			}
			return collection.Skip(1).Aggregate(
					first,
					(l, r) => UnifiedProperty.Create(l, r, delimiter));
		}

		public static IUnifiedExpression ToProperty(
				this UnifiedIdentifier singleton) {
			return singleton;
		}

		public static UnifiedKeyValueCollection ToCollection(
				this IEnumerable<UnifiedKeyValue> collection) {
			return UnifiedKeyValueCollection.Create(collection);
		}

		public static UnifiedKeyValueCollection ToCollection(
				this UnifiedKeyValue singleton) {
			return UnifiedKeyValueCollection.Create(singleton);
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

		public static UnifiedTypeArgumentCollection ToCollection(
				this IEnumerable<UnifiedTypeArgument> collection) {
			return UnifiedTypeArgumentCollection.Create(collection);
		}

		public static UnifiedTypeArgumentCollection ToCollection(
				this UnifiedTypeArgument singleton) {
			return UnifiedTypeArgumentCollection.Create(singleton);
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

		public static UnifiedTypeParameterCollection ToCollection(
				this IEnumerable<UnifiedTypeParameter> collection) {
			return UnifiedTypeParameterCollection.Create(collection);
		}

		public static UnifiedTypeParameterCollection ToCollection(
				this UnifiedTypeParameter singleton) {
			return UnifiedTypeParameterCollection.Create(singleton);
		}

		public static UnifiedTypeSupplementCollection ToCollection(
				this IEnumerable<UnifiedTypeSupplement> collection) {
			return UnifiedTypeSupplementCollection.Create(collection);
		}

		public static UnifiedTypeSupplementCollection ToCollection(
				this UnifiedTypeSupplement singleton) {
			return UnifiedTypeSupplementCollection.Create(singleton);
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
			return UnifiedList.Create(UnifiedListKind.List, collection);
		}

		public static UnifiedList ToListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(UnifiedListKind.List, expressions.ToCollection());
		}

		public static UnifiedList ToListLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(UnifiedListKind.List, singleton.ToCollection());
		}

		public static UnifiedList ToArrayLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedList.Create(UnifiedListKind.Array, collection);
		}

		public static UnifiedList ToArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(UnifiedListKind.Array, expressions.ToCollection());
		}

		public static UnifiedList ToArrayLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(UnifiedListKind.Array, singleton.ToCollection());
		}

		public static UnifiedList ToSetLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedList.Create(UnifiedListKind.Set, collection);
		}

		public static UnifiedList ToSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(UnifiedListKind.Set, expressions.ToCollection());
		}

		public static UnifiedList ToSetLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(UnifiedListKind.Set, singleton.ToCollection());
		}

		public static UnifiedList ToLazyListLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedList.Create(UnifiedListKind.LazyList, collection);
		}

		public static UnifiedList ToLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(UnifiedListKind.LazyList, expressions.ToCollection());
		}

		public static UnifiedList ToLazyListLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(UnifiedListKind.LazyList, singleton.ToCollection());
		}

		public static UnifiedList ToTupleLiteral(
				this UnifiedExpressionCollection collection) {
			return UnifiedList.Create(UnifiedListKind.Tuple, collection);
		}

		public static UnifiedList ToTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedList.Create(UnifiedListKind.Tuple, expressions.ToCollection());
		}

		public static UnifiedList ToTupleLiteral(this IUnifiedExpression singleton) {
			return UnifiedList.Create(UnifiedListKind.Tuple, singleton.ToCollection());
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this UnifiedExpressionCollection collection) {
			if (collection.Count == 1) {
				var expression = collection[0];
				expression.Remove();
				return expression;
			}
			return UnifiedList.Create(UnifiedListKind.List, collection);
		}

		public static IUnifiedExpression ToSmartListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(UnifiedListKind.List, list.ToCollection());
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
			return UnifiedList.Create(UnifiedListKind.Array, collection);
		}

		public static IUnifiedExpression ToSmartArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(UnifiedListKind.Array, list.ToCollection());
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
			return UnifiedList.Create(UnifiedListKind.Set, collection);
		}

		public static IUnifiedExpression ToSmartSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(UnifiedListKind.Set, list.ToCollection());
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
			return UnifiedList.Create(UnifiedListKind.LazyList, collection);
		}

		public static IUnifiedExpression ToSmartLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(UnifiedListKind.LazyList, list.ToCollection());
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
			return UnifiedList.Create(UnifiedListKind.Tuple, collection);
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1)
				return list[0];
			return UnifiedList.Create(UnifiedListKind.Tuple, list.ToCollection());
		}

		public static IUnifiedExpression ToSmartTupleLiteral(
				this IUnifiedExpression singleton) {
			return singleton;
		}
	}
}