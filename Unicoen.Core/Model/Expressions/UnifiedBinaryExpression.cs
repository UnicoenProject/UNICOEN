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
	///   二項式を表します。
	///   e.g. JavaやCにおける<c>a + b</c>など
	/// </summary>
	public class UnifiedBinaryExpression : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _leftHandSide;

		/// <summary>
		/// 第1オペランドを表します
		/// e.g. <c>a + b</c>の<c>a</c>
		/// </summary>
		public IUnifiedExpression LeftHandSide {
			get { return _leftHandSide; }
			set { _leftHandSide = SetParentOfChild(value, _leftHandSide); }
		}

		private UnifiedBinaryOperator _operator;

		/// <summary>
		/// 演算子を表します
		/// e.g. <c>a + b</c>の<c>+</c>
		/// </summary>
		public UnifiedBinaryOperator Operator {
			get { return _operator; }
			set { _operator = SetParentOfChild(value, _operator); }
		}

		private IUnifiedExpression _rightHandSide;

		/// <summary>
		/// 第2オペランドを表します
		/// e.g. <c>a + b</c>の<c>b</c>
		/// </summary>
		public IUnifiedExpression RightHandSide {
			get { return _rightHandSide; }
			set { _rightHandSide = SetParentOfChild(value, _rightHandSide); }
		}

		private UnifiedBinaryExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return LeftHandSide;
			yield return Operator;
			yield return RightHandSide;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(LeftHandSide, v => LeftHandSide = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Operator, v => Operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(RightHandSide, v => RightHandSide = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_leftHandSide, v => _leftHandSide = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_operator, v => _operator = (UnifiedBinaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_rightHandSide, v => _rightHandSide = (IUnifiedExpression)v);
		}

		public static UnifiedBinaryExpression Create(
				IUnifiedExpression leftHandSide,
				UnifiedBinaryOperator
						binaryOperator,
				IUnifiedExpression rightHandSide) {
			return new UnifiedBinaryExpression {
					LeftHandSide = leftHandSide,
					Operator = binaryOperator,
					RightHandSide = rightHandSide,
			};
		}
	}
}