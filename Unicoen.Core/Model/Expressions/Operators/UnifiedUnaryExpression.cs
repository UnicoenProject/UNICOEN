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
	///   単項式を表します。
	///   e.g. Javaにおける<c>a++</c>
	///   e.g. Javaにおける<c>-b</c>
	///   e.g. Javaにおける<c>!c</c>
	/// </summary>
	public class UnifiedUnaryExpression : UnifiedElement, IUnifiedExpression {
		private UnifiedUnaryOperator _operator;

		/// <summary>
		///   単項式の演算式を表します
		///   e.g. Javaにおける<c>a++</c>の<c>++</c>
		/// </summary>
		public UnifiedUnaryOperator Operator {
			get { return _operator; }
			set { _operator = SetChild(value, _operator); }
		}

		private IUnifiedExpression _operand;

		/// <summary>
		///   単項式のオペランドを表します
		///   e.g. Javaにおける<c>a++</c>の<c>a</c>
		/// </summary>
		public IUnifiedExpression Operand {
			get { return _operand; }
			set { _operand = SetChild(value, _operand); }
		}

		private UnifiedUnaryExpression() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData arg) {
			return visitor.Visit(this, arg);
		}

		public override IUnifiedElement Normalize() {
			NormalizeChildren();
			var operand = Operand as UnifiedIntegerLiteral;
			if (operand != null) {
				if (Operator.Kind == UnifiedUnaryOperatorKind.UnaryPlus) {
					return operand;
				}
				if (Operator.Kind == UnifiedUnaryOperatorKind.Negate) {
					operand.Value = -operand.Value;
					return operand;
				}
			}
			return this;
		}

		public static UnifiedUnaryExpression Create(
				IUnifiedExpression operand,
				UnifiedUnaryOperator unaryOperator) {
			return new UnifiedUnaryExpression {
					Operand = operand,
					Operator = unaryOperator,
			};
		}
	}
}