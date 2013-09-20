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
	///   範囲リテラルを表します． e.g. Rubyにおける <c>1..2</c> や <c>1...3</c>
	/// </summary>
	public class UnifiedRange : UnifiedExpression {
		private UnifiedExpression _min, _max;

		public UnifiedExpression Min {
			get { return _min; }
			set { _min = SetChild(value, _min); }
		}

		public UnifiedExpression Max {
			get { return _max; }
			set { _max = SetChild(value, _max); }
		}

		private UnifiedRange() {}

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

		public static UnifiedRange Create(
				UnifiedExpression min = null,
				UnifiedExpression max = null) {
			return new UnifiedRange {
					Min = min,
					Max = max,
			};
		}

		public static UnifiedRange CreateNotContainingMax(
				UnifiedExpression min = null,
				UnifiedExpression max = null) {
			return new UnifiedRange {
					Min = min,
					Max = UnifiedBinaryExpression.Create(
							max,
							UnifiedBinaryOperator.Create(
									"-", UnifiedBinaryOperatorKind.Subtract),
							UnifiedIntegerLiteral.CreateInt32(-1)),
			};
		}
	}
}