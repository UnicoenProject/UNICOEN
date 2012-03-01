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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   3項式（条件式）を表します． Javaにおける <c>a ? b : c</c>
	/// </summary>
	public class UnifiedTernaryExpression : UnifiedExpression {
		private UnifiedExpression _condition;

		/// <summary>
		///   3項式の第1オペランドを表します e.g. Javaにおける <c>a ? b : c</c> の <c>a</c>
		/// </summary>
		public UnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		private UnifiedExpression _trueExpression;

		/// <summary>
		///   3項式の第2オペランドを表します Javaにおける <c>a ? b : c</c> の <c>b</c>
		/// </summary>
		public UnifiedExpression TrueExpression {
			get { return _trueExpression; }
			set { _trueExpression = SetChild(value, _trueExpression); }
		}

		private UnifiedExpression _falseExpression;

		/// <summary>
		///   3項式の第3オペランドを表します Javaにおける <c>a ? b : c</c> の <c>c</c>
		/// </summary>
		public UnifiedExpression FalseExpression {
			get { return _falseExpression; }
			set { _falseExpression = SetChild(value, _falseExpression); }
		}

		private UnifiedTernaryExpression() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedTernaryExpression Create(
				UnifiedExpression condition,
				UnifiedExpression trueExpression,
				UnifiedExpression falseExpression) {
			return new UnifiedTernaryExpression {
					Condition = condition,
					TrueExpression = trueExpression,
					FalseExpression = falseExpression,
			};
		}
	}
}