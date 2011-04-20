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
	///   単項式を表します。
	/// </summary>
	public class UnifiedUnaryExpression : UnifiedElement, IUnifiedExpression {
		private UnifiedUnaryOperator _operator;

		public UnifiedUnaryOperator Operator {
			get { return _operator; }
			set { _operator = SetParentOfChild(value, _operator); }
		}

		private IUnifiedExpression _operand;

		public IUnifiedExpression Operand {
			get { return _operand; }
			set { _operand = SetParentOfChild(value, _operand); }
		}

		private UnifiedUnaryExpression() {}

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
			yield return Operator;
			yield return Operand;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Operator, v => Operator = (UnifiedUnaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Operand, v => Operand = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_operator, v => _operator = (UnifiedUnaryOperator)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_operand, v => _operand = (IUnifiedExpression)v);
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