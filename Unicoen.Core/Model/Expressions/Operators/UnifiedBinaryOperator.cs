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
	///   二項演算子を表します。 e.g. <c>a + b</c> の <c>+</c>
	/// </summary>
	public class UnifiedBinaryOperator : UnifiedElement {
		private static readonly bool[] AssignTalbe;

		/// <summary>
		///   演算子の識別子を表します
		/// </summary>
		public string Sign { get; private set; }

		/// <summary>
		///   演算子の種類を表します
		/// </summary>
		public UnifiedBinaryOperatorKind Kind { get; private set; }

		static UnifiedBinaryOperator() {
			AssignTalbe = new bool[256];
			AssignTalbe[(int)UnifiedBinaryOperatorKind.AddAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.AndAlsoAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.ArithmeticLeftShiftAssign
					] = true;
			AssignTalbe[
					(int)UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign] =
					true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.AndAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.Assign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.DivideAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.ExclusiveOrAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.FloorDivideAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.LogicalLeftShiftAssign] =
					true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.LogicalRightShiftAssign]
					= true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.ModuloAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.MultiplyAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.OrAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.OrElseAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.PowerAssign] = true;
			AssignTalbe[(int)UnifiedBinaryOperatorKind.SubtractAssign] = true;
		}

		private UnifiedBinaryOperator() {}

		public bool IsAssignOperator() {
			return AssignTalbe[(int)Kind];
		}

		public static UnifiedBinaryOperator Create(
				string sign,
				UnifiedBinaryOperatorKind kind) {
			return new UnifiedBinaryOperator {
					Sign = sign,
					Kind = kind,
			};
		}

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
	}
}