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
	public static class ModelFactoryForExpressions {
		public static UnifiedBlock ToBlock(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedBlock.Create(expressions);
		}

		public static UnifiedBlock ToBlock(this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedBlock.Create();
			return UnifiedBlock.Create(singleton);
		}

		public static UnifiedProgram ToProgram(
				this IEnumerable<IUnifiedExpression> expressions) {
			return UnifiedProgram.Create(expressions.ToBlock());
		}

		public static UnifiedProgram ToProgram(this IUnifiedExpression singleton) {
			if (singleton == null) return UnifiedProgram.Create(UnifiedBlock.Create());
			return UnifiedProgram.Create(singleton.ToBlock());
		}

		public static UnifiedVariableDefinitionList ToVariableDefinitionList(
				this IEnumerable<UnifiedVariableDefinition> expressions) {
			return UnifiedVariableDefinitionList.Create(expressions);
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