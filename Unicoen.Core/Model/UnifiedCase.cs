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
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   switch文におけるcase式を表します。
	///   e.g. Javaにおける<c>switch(sw){case 1: BLOCK1 ...}</c>の<c>case 1: BLOCK1</c>
	/// </summary>
	public class UnifiedCase : UnifiedElement {
		private IUnifiedExpression _condition;

		/// <summary>
		///   case式の分岐条件を表します
		///   e.g. Javaにおける<c>switch(sw){case 1: EXPRESSION1 ...}</c>の<c>1</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private UnifiedBlock _body;

		/// <summary>
		///   case式の分岐に対応する内容を表します
		///   e.g. Javaにおける<c>switch(sw){case 1: BLOCK1 ...}</c>の<c>BLOCK1</c>
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetParentOfChild(value, _body); }
		}

		private UnifiedCase() { }

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
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public UnifiedCase AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}

		public static UnifiedCase Create(UnifiedBlock body) {
			return new UnifiedCase {
					Body = body,
			};
		}

		public static UnifiedCase Create(
				IUnifiedExpression condtion,
				UnifiedBlock body) {
			return new UnifiedCase {
					Body = body,
					Condition = condtion,
			};
		}
	}
}