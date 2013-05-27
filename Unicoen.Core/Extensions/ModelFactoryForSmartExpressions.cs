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
	public static class ProgramGeneratorForSmartExpressions {
		public static UnifiedExpression ToSmartExpressionList(
				this IEnumerable<UnifiedExpression> collection) {
			var list = collection.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedExpressionList.Create(collection);
		}

		public static UnifiedExpression ToSmartExpressionList(
				this UnifiedExpression singleton) {
			return singleton;
		}

        public static UnifiedExpression ToSmartListLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedListLiteral.Create(list);
		}

		public static UnifiedExpression ToSmartListLiteral(
				this UnifiedExpression singleton) {
			return singleton;
		}

		public static UnifiedExpression ToSmartArrayLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedArrayLiteral.Create(list);
		}

		public static UnifiedExpression ToSmartArrayLiteral(
				this UnifiedExpression singleton) {
			return singleton;
		}

		public static UnifiedExpression ToSmartSetLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedSetLiteral.Create(list);
		}

		public static UnifiedExpression ToSmartSetLiteral(
				this UnifiedExpression singleton) {
			return singleton;
		}

		public static UnifiedExpression ToSmartLazyListLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedIterableLiteral.Create(list);
		}

		public static UnifiedExpression ToSmartLazyListLiteral(
				this UnifiedExpression singleton) {
			return singleton;
		}

		public static UnifiedExpression ToSmartTupleLiteral(
				this IEnumerable<UnifiedExpression> expressions) {
			var list = expressions.ToList();
			if (list.Count == 1) {
				return list[0];
			}
			return UnifiedTupleLiteral.Create(list);
		}

		public static UnifiedExpression ToSmartTupleLiteral(
				this UnifiedExpression singleton) {
			return singleton;
		}
	}
}