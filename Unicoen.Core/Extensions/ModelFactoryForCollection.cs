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
			if (singleton == null) return UnifiedBlock.Create();
			return UnifiedBlock.Create(singleton);
		}

		public static UnifiedProgram ToProgram(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedProgram.Create(collection.ToBlock());
		}

		public static UnifiedProgram ToProgram(this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedProgram.Create(UnifiedBlock.Create());
			return UnifiedProgram.Create(singleton.ToBlock());
		}

		public static UnifiedAnnotationCollection ToCollection(
				this IEnumerable<UnifiedAnnotation> collection) {
			return UnifiedAnnotationCollection.Create(collection);
		}

		public static UnifiedAnnotationCollection ToCollection(
				this UnifiedAnnotation singleton) {
			if (singleton == null) return UnifiedAnnotationCollection.Create();
			return UnifiedAnnotationCollection.Create(singleton);
		}

		public static UnifiedArgumentCollection ToCollection(
				this IEnumerable<UnifiedArgument> collection) {
			return UnifiedArgumentCollection.Create(collection);
		}

		public static UnifiedArgumentCollection ToCollection(
				this UnifiedArgument singleton) {
			if (singleton == null) return UnifiedArgumentCollection.Create();
			return UnifiedArgumentCollection.Create(singleton);
		}

		public static UnifiedCaseCollection ToCollection(
				this IEnumerable<UnifiedCase> collection) {
			return UnifiedCaseCollection.Create(collection);
		}

		public static UnifiedCaseCollection ToCollection(this UnifiedCase singleton) {
			if (singleton == null) return UnifiedCaseCollection.Create();
			return UnifiedCaseCollection.Create(singleton);
		}

		public static UnifiedCatchCollection ToCollection(
				this IEnumerable<UnifiedCatch> collection) {
			return UnifiedCatchCollection.Create(collection);
		}

		public static UnifiedCatchCollection ToCollection(this UnifiedCatch singleton) {
			if (singleton == null) return UnifiedCatchCollection.Create();
			return UnifiedCatchCollection.Create(singleton);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IEnumerable<IUnifiedExpression> collection) {
			return UnifiedExpressionCollection.Create(collection);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedExpressionCollection.Create();
			return UnifiedExpressionCollection.Create(singleton);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this IEnumerable<UnifiedIdentifier> collection) {
			return UnifiedIdentifierCollection.Create(collection);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this UnifiedIdentifier singleton) {
			if (singleton == null) return UnifiedIdentifierCollection.Create();
			return UnifiedIdentifierCollection.Create(singleton);
		}

		public static UnifiedMatcherCollection ToCollection(
				this IEnumerable<UnifiedMatcher> collection) {
			return UnifiedMatcherCollection.Create(collection);
		}

		public static UnifiedMatcherCollection ToCollection(
				this UnifiedMatcher singleton) {
			if (singleton == null) return UnifiedMatcherCollection.Create();
			return UnifiedMatcherCollection.Create(singleton);
		}

		public static UnifiedModifierCollection ToCollection(
				this IEnumerable<UnifiedModifier> collection) {
			return UnifiedModifierCollection.Create(collection);
		}

		public static UnifiedModifierCollection ToCollection(
				this UnifiedModifier singleton) {
			if (singleton == null) return UnifiedModifierCollection.Create();
			return UnifiedModifierCollection.Create(singleton);
		}

		public static UnifiedParameterCollection ToCollection(
				this IEnumerable<UnifiedParameter> collection) {
			return UnifiedParameterCollection.Create(collection);
		}

		public static UnifiedParameterCollection ToCollection(
				this UnifiedParameter singleton) {
			if (singleton == null) return UnifiedParameterCollection.Create();
			return UnifiedParameterCollection.Create(singleton);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this IEnumerable<UnifiedGenericArgument> collection) {
			return UnifiedGenericArgumentCollection.Create(collection);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this UnifiedGenericArgument singleton) {
			if (singleton == null) return UnifiedGenericArgumentCollection.Create();
			return UnifiedGenericArgumentCollection.Create(singleton);
		}

		public static UnifiedThrowsTypeCollection ToCollection(
				this IEnumerable<UnifiedType> collection) {
			return UnifiedThrowsTypeCollection.Create(collection);
		}

		public static UnifiedThrowsTypeCollection ToCollection(
				this UnifiedType singleton) {
			if (singleton == null) return UnifiedThrowsTypeCollection.Create();
			return UnifiedThrowsTypeCollection.Create(singleton);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this IEnumerable<UnifiedTypeConstrain> collection) {
			return UnifiedTypeConstrainCollection.Create(collection);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this UnifiedTypeConstrain singleton) {
			if (singleton == null) return UnifiedTypeConstrainCollection.Create();
			return UnifiedTypeConstrainCollection.Create(singleton);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this IEnumerable<UnifiedGenericParameter> collection) {
			return UnifiedGenericParameterCollection.Create(collection);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this UnifiedGenericParameter singleton) {
			if (singleton == null) return UnifiedGenericParameterCollection.Create();
			return UnifiedGenericParameterCollection.Create(singleton);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this IEnumerable<UnifiedVariableDefinition> collection) {
			return UnifiedVariableDefinitionList.Create(collection);
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this UnifiedVariableDefinition singleton) {
			if (singleton == null) return UnifiedVariableDefinitionList.Create();
			return UnifiedVariableDefinitionList.Create(singleton);
		}

		public static UnifiedListLiteral ToListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedListLiteral.Create(expressions);
		}

		public static UnifiedListLiteral ToListLiteral(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedListLiteral.Create();
			return UnifiedListLiteral.Create(singleton);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedArrayLiteral.Create(expressions);
		}

		public static UnifiedArrayLiteral ToArrayLiteral(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedArrayLiteral.Create();
			return UnifiedArrayLiteral.Create(singleton);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedSetLiteral.Create(expressions);
		}

		public static UnifiedSetLiteral ToSetLiteral(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedSetLiteral.Create();
			return UnifiedSetLiteral.Create(singleton);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedIterableLiteral.Create(expressions);
		}

		public static UnifiedIterableLiteral ToLazyListLiteral(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedIterableLiteral.Create();
			return UnifiedIterableLiteral.Create(singleton);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedTupleLiteral.Create(expressions);
		}

		public static UnifiedTupleLiteral ToTupleLiteral(
				this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedTupleLiteral.Create();
			return UnifiedTupleLiteral.Create(singleton);
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