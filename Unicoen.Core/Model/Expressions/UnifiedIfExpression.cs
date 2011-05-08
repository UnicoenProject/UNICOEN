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
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   if文を表します。
	///   e.g. Javaにおける<c>if(cond){...}else{...}</c>
	/// </summary>
	public class UnifiedIfExpression : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;

		/// <summary>
		///   条件式を表します
		///   <c>if(cond){...}else{...}</c>の<c>con</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private IUnifiedExpression _expression;

		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetParentOfChild(value, _expression); }
		}

		private IUnifiedExpression _elseExpression;

		public IUnifiedExpression ElseExpression {
			get { return _elseExpression; }
			set { _elseExpression = SetParentOfChild(value, _elseExpression); }
		}

		private UnifiedIfExpression() {}

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

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Condition;
			yield return ElseExpression;
			yield return Expression;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Condition, v => Condition = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => ElseExpression, v => ElseExpression = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => Expression, v => Expression = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _condition, v => _condition = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _elseExpression, v => _elseExpression = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => _expression, v => _expression = (UnifiedBlock)v);
		}

		public static UnifiedIfExpression Create(
				IUnifiedExpression condition, IUnifiedExpression expression) {
			return new UnifiedIfExpression {
					Expression = expression,
					Condition = condition,
			};
		}

		public static UnifiedIfExpression Create(
				IUnifiedExpression condition, IUnifiedExpression expression,
				IUnifiedExpression elseExpression) {
			return new UnifiedIfExpression {
					Condition = condition,
					Expression = expression,
					ElseExpression = elseExpression,
			};
		}
	}
}