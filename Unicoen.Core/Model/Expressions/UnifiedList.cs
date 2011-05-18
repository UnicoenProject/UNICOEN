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

using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   リストやタプル，配列，集合などのリテラルを表します．
	/// </summary>
	public class UnifiedList : UnifiedElement, IUnifiedExpression {
		/// <summary>
		///   リストの種類を表します．
		/// </summary>
		public UnifiedListKind Kind { get; set; }

		private UnifiedExpressionCollection _elements;

		/// <summary>
		///   リストを構成する要素の集合を表します．
		/// </summary>
		public UnifiedExpressionCollection Elements {
			get { return _elements; }
			set { _elements = SetParentOfChild(value, _elements); }
		}

		private UnifiedList() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		private static UnifiedList Create(
				UnifiedListKind kind,
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = kind,
					Elements = elements,
			};
		}

		public static UnifiedList CreateList(
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = UnifiedListKind.List,
					Elements = elements,
			};
		}

		public static UnifiedList CreateLazyList(
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = UnifiedListKind.LazyList,
					Elements = elements,
			};
		}

		public static UnifiedList CreateTuple(
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = UnifiedListKind.Tuple,
					Elements = elements,
			};
		}

		public static UnifiedList CreateArray(
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = UnifiedListKind.Array,
					Elements = elements,
			};
		}

		public static UnifiedList CreateSet(
				UnifiedExpressionCollection elements) {
			return new UnifiedList {
					Kind = UnifiedListKind.Set,
					Elements = elements,
			};
		}
	}
}