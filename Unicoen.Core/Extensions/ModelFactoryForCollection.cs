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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Model {
	public static class ProgramGeneratorForCollection {
		public static UnifiedAnnotationCollection ToCollection(
				this IEnumerable<UnifiedAnnotation> collection) {
			return UnifiedAnnotationCollection.Create(collection);
		}

		public static UnifiedAnnotationCollection ToCollection(
				this UnifiedAnnotation singleton) {
			if (singleton == null) {
				return UnifiedAnnotationCollection.Create();
			}
			return UnifiedAnnotationCollection.Create(singleton);
		}

		public static UnifiedAnnotationCollection Merge(
				this IEnumerable<UnifiedAnnotationCollection> collections) {
			return collections.ToList().Merge();
		}

		public static UnifiedAnnotationCollection Merge(
				this IList<UnifiedAnnotationCollection> collections) {
			Contract.Requires<InvalidOperationException>(
					collections.All(c => c.Parent == null));
			if (collections.Count == 0) {
				return UnifiedAnnotationCollection.Create();
			}
			var ret = collections[0];
			for (int i = 1; i < collections.Count; i++) {
				ret.AddRange(collections[i].ElementsThenClear());
			}
			return ret;
		}

		public static UnifiedArgumentCollection ToCollection(
				this IEnumerable<UnifiedArgument> collection) {
			return UnifiedArgumentCollection.Create(collection);
		}

		public static UnifiedArgumentCollection ToCollection(
				this UnifiedArgument singleton) {
			if (singleton == null) {
				return UnifiedArgumentCollection.Create();
			}
			return UnifiedArgumentCollection.Create(singleton);
		}

		public static UnifiedCaseCollection ToCollection(
				this IEnumerable<UnifiedCase> collection) {
			return UnifiedCaseCollection.Create(collection);
		}

		public static UnifiedCaseCollection ToCollection(
				this UnifiedCase singleton) {
			if (singleton == null) {
				return UnifiedCaseCollection.Create();
			}
			return UnifiedCaseCollection.Create(singleton);
		}

		public static UnifiedCatchCollection ToCollection(
				this IEnumerable<UnifiedCatch> collection) {
			return UnifiedCatchCollection.Create(collection);
		}

		public static UnifiedCatchCollection ToCollection(
				this UnifiedCatch singleton) {
			if (singleton == null) {
				return UnifiedCatchCollection.Create();
			}
			return UnifiedCatchCollection.Create(singleton);
		}

		public static UnifiedCommentCollection ToCollection(
				this IEnumerable<UnifiedComment> collection) {
			return UnifiedCommentCollection.Create(collection);
		}

		public static UnifiedCommentCollection ToCollection(
				this UnifiedComment singleton) {
			if (singleton == null) {
				return UnifiedCommentCollection.Create();
			}
			return UnifiedCommentCollection.Create(singleton);
		}

		public static UnifiedExpressionCollection ToCollection(
				this IEnumerable<UnifiedExpression> collection) {
			return UnifiedExpressionCollection.Create(collection);
		}

		public static UnifiedExpressionCollection ToCollection(
				this UnifiedExpression singleton) {
			if (singleton == null) {
				return UnifiedExpressionCollection.Create();
			}
			return UnifiedExpressionCollection.Create(singleton);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this IEnumerable<UnifiedIdentifier> collection) {
			return UnifiedIdentifierCollection.Create(collection);
		}

		public static UnifiedIdentifierCollection ToCollection(
				this UnifiedIdentifier singleton) {
			if (singleton == null) {
				return UnifiedIdentifierCollection.Create();
			}
			return UnifiedIdentifierCollection.Create(singleton);
		}

		public static UnifiedModifierCollection ToCollection(
				this IEnumerable<UnifiedModifier> collection) {
			return UnifiedModifierCollection.Create(collection);
		}

		public static UnifiedModifierCollection ToCollection(
				this UnifiedModifier singleton) {
			if (singleton == null) {
				return UnifiedModifierCollection.Create();
			}
			return UnifiedModifierCollection.Create(singleton);
		}

		public static UnifiedParameterCollection ToCollection(
				this IEnumerable<UnifiedParameter> collection) {
			return UnifiedParameterCollection.Create(collection);
		}

		public static UnifiedParameterCollection ToCollection(
				this UnifiedParameter singleton) {
			if (singleton == null) {
				return UnifiedParameterCollection.Create();
			}
			return UnifiedParameterCollection.Create(singleton);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this IEnumerable<UnifiedGenericArgument> collection) {
			return UnifiedGenericArgumentCollection.Create(collection);
		}

		public static UnifiedGenericArgumentCollection ToCollection(
				this UnifiedGenericArgument singleton) {
			if (singleton == null) {
				return UnifiedGenericArgumentCollection.Create();
			}
			return UnifiedGenericArgumentCollection.Create(singleton);
		}

		public static UnifiedTypeCollection ToCollection(
				this IEnumerable<UnifiedType> collection) {
			return UnifiedTypeCollection.Create(collection);
		}

		public static UnifiedTypeCollection ToCollection(
				this UnifiedType singleton) {
			if (singleton == null) {
				return UnifiedTypeCollection.Create();
			}
			return UnifiedTypeCollection.Create(singleton);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this IEnumerable<UnifiedTypeConstrain> collection) {
			return UnifiedTypeConstrainCollection.Create(collection);
		}

		public static UnifiedTypeConstrainCollection ToCollection(
				this UnifiedTypeConstrain singleton) {
			if (singleton == null) {
				return UnifiedTypeConstrainCollection.Create();
			}
			return UnifiedTypeConstrainCollection.Create(singleton);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this IEnumerable<UnifiedGenericParameter> collection) {
			return UnifiedGenericParameterCollection.Create(collection);
		}

		public static UnifiedGenericParameterCollection ToCollection(
				this UnifiedGenericParameter singleton) {
			if (singleton == null) {
				return UnifiedGenericParameterCollection.Create();
			}
			return UnifiedGenericParameterCollection.Create(singleton);
		}

		public static UnifiedSet<T> ToSet<T>(this IEnumerable<T> collection)
				where T : UnifiedElement {
			return UnifiedSet<T>.Create(collection);
		}

		public static UnifiedSet<T> ToSet<T>(this T singleton)
				where T : UnifiedElement {
			if (singleton == null) {
				return UnifiedSet<T>.Create();
			}
			return UnifiedSet<T>.Create(singleton);
		}
	}
}