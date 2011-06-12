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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   リスト内包表記式やジェネレータ式などを表します．
	/// </summary>
	public class UnifiedListComprehension : UnifiedElement, IUnifiedExpression {
		/// <summary>
		///   種類を表します．
		/// </summary>
		public UnifiedListKind Kind { get; set; }

		private IUnifiedExpression _element;

		/// <summary>
		///   リスト内包表記によって生成される要素部分の式を表します．
		/// </summary>
		public IUnifiedExpression Element {
			get { return _element; }
			set { _element = SetChild(value, _element); }
		}

		private UnifiedExpressionCollection _generator;

		/// <summary>
		///   リスト内包表記の集合部分の式を表します．
		/// </summary>
		public UnifiedExpressionCollection Generator {
			get { return _generator; }
			set { _generator = SetChild(value, _generator); }
		}

		private UnifiedListComprehension() {}

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

		public static UnifiedListComprehension Create(
				UnifiedListKind kind,
				IUnifiedExpression element,
				UnifiedExpressionCollection generator) {
			return new UnifiedListComprehension {
					Kind = kind,
					Element = element,
					Generator = generator,
			};
		}
	}
}