﻿#region License

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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   二項式を表します。 e.g. JavaやCにおける <c>a + b</c> など
	/// </summary>
	public class UnifiedBinaryExpression : UnifiedExpression {
		private UnifiedExpression _leftHandSide;

		/// <summary>
		///   第1オペランドを表します e.g. <c>a + b</c> の <c>a</c>
		/// </summary>
		public UnifiedExpression LeftHandSide {
			get { return _leftHandSide; }
			set { _leftHandSide = SetChild(value, _leftHandSide); }
		}

		private UnifiedBinaryOperator _operator;

		/// <summary>
		///   演算子を表します e.g. <c>a + b</c> の <c>+</c>
		/// </summary>
		public UnifiedBinaryOperator Operator {
			get { return _operator; }
			set { _operator = SetChild(value, _operator); }
		}

		private UnifiedExpression _rightHandSide;

		/// <summary>
		///   第2オペランドを表します e.g. <c>a + b</c> の <c>b</c>
		/// </summary>
		public UnifiedExpression RightHandSide {
			get { return _rightHandSide; }
			set { _rightHandSide = SetChild(value, _rightHandSide); }
		}

		private UnifiedBinaryExpression() {}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedBinaryExpression Create(
				UnifiedExpression leftHandSide,
				UnifiedBinaryOperator binaryOperator,
				UnifiedExpression rightHandSide) {
			return new UnifiedBinaryExpression {
					LeftHandSide = leftHandSide,
					Operator = binaryOperator,
					RightHandSide = rightHandSide,
			};
		}

		public static UnifiedBinaryExpression Create() {
			return new UnifiedBinaryExpression();
		}
	}
}