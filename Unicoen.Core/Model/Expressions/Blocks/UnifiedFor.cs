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
	///   for文を表します。
	///   e.g. Javaにおける<c>for(int i = 0; i &lt; 10; i++){...}</c>
	/// </summary>
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor> {
		private IUnifiedExpression _initializer;

		/// <summary>
		///   初期条件を表します
		///   e.g. Javaにおける<c>for(int i = 0; i &lt; 10; i++){...}</c><c>int i = 0</c>
		/// </summary>
		public IUnifiedExpression Initializer {
			get { return _initializer; }
			set { _initializer = SetParentOfChild(value, _initializer); }
		}

		private IUnifiedExpression _condition;

		/// <summary>
		///   実行条件を表します
		///   e.g. Javaにおける<c>for(int i = 0; i &lt; 10; i++){...}</c>の<c>i &lt; 10</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private IUnifiedExpression _step;

		/// <summary>
		///   ステップを表します
		///   e.g. Javaにおける<c>for(int i = 0; i &lt; 10; i++){...}</c>の<c>i++</c>
		/// </summary>
		public IUnifiedExpression Step {
			get { return _step; }
			set { _step = SetParentOfChild(value, _step); }
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set { _falseBody = SetParentOfChild(value, _falseBody); }
		}

		private UnifiedFor() {}

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
			yield return Initializer;
			yield return Condition;
			yield return Step;
			yield return FalseBody;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Initializer, v => Initializer = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Step, v => Step = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(FalseBody, v => FalseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_initializer, v => _initializer = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_step, v => _step = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_falseBody, v => _falseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedFor Create(
				IUnifiedExpression initializer,
				IUnifiedExpression condition,
				IUnifiedExpression step,
				UnifiedBlock body) {
			return new UnifiedFor {
					Initializer = initializer,
					Condition = condition,
					Step = step,
					Body = body,
			};
		}
	}
}