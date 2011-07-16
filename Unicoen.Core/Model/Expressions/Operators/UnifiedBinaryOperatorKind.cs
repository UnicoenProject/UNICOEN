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

namespace Unicoen.Model {
	/// <summary>
	///   二項演算子の種類を表します。
	///   http://msdn.microsoft.com/ja-jp/library/bb361179.aspx
	/// </summary>
	public enum UnifiedBinaryOperatorKind {
		/// <summary>
		///   種類が不明
		/// </summary>
		Unknown,

		/// <summary>
		///   a + b
		/// </summary>
		Add,

		/// <summary>
		///   a - b
		/// </summary>
		Subtract,

		/// <summary>
		///   a * b
		/// </summary>
		Multiply,

		/// <summary>
		///   a / b
		/// </summary>
		Divide,

		/// <summary>
		///   a % b
		/// </summary>
		Modulo,

		/// <summary>
		///   a ^ b in VB
		///   a ** b in Python
		/// </summary>
		Power,

		/// <summary>
		///   a // b in Python
		/// </summary>
		FloorDivide,

		/// <summary>
		///   nothing in Java
		/// </summary>
		ArithmeticLeftShift,

		/// <summary>
		///   a >> b
		/// </summary>
		ArithmeticRightShift,

		/// <summary>
		///   a &lt;&lt; b
		/// </summary>
		LogicalLeftShift,

		/// <summary>
		///   a >>> b
		/// </summary>
		LogicalRightShift,

		/// <summary>
		///   a > b
		/// </summary>
		GreaterThan,

		/// <summary>
		///   a >= b
		/// </summary>
		GreaterThanOrEqual,

		/// <summary>
		///   a ?? b
		/// </summary>
		Coalesce,

		/// <summary>
		///   a &lt; b
		/// </summary>
		LessThan,

		/// <summary>
		///   a &lt;= b
		/// </summary>
		LessThanOrEqual,

		/// <summary>
		///   a == b
		/// </summary>
		Equal,

		/// <summary>
		///   a != b
		/// </summary>
		NotEqual,

		/// <summary>
		///   e.g. JavaScriptにおける<c>a === b</c>
		///   暗黙の型変換を行わない等価演算子
		/// </summary>
		StrictEqual,

		/// <summary>
		///   e.g. JavaScriptにおける<c>a !== b</c>
		///   暗黙の型変換を行わない等価演算子
		/// </summary>
		StrictNotEqual,

		/// <summary>
		///   a is b in Python
		/// </summary>
		ReferenceEqual,

		/// <summary>
		///   a is not b in Python
		/// </summary>
		ReferenceNotEqual,

		/// <summary>
		///   a in b in Python
		/// </summary>
		In,

		/// <summary>
		///   a not in b in Python
		/// </summary>
		NotIn,

		/// <summary>
		///   a && b
		/// </summary>
		AndAlso,

		/// <summary>
		///   a || b
		/// </summary>
		OrElse,

		/// <summary>
		///   a & b
		/// </summary>
		And,

		/// <summary>
		///   a | b
		/// </summary>
		Or,

		/// <summary>
		///   a ^ b
		/// </summary>
		ExclusiveOr,

		/// <summary>
		///   a = b
		/// </summary>
		Assign,

		/// <summary>
		///   a += b
		/// </summary>
		AddAssign,

		/// <summary>
		///   a -= b
		/// </summary>
		SubtractAssign,

		/// <summary>
		///   a *= b
		/// </summary>
		MultiplyAssign,

		/// <summary>
		///   a /= b
		/// </summary>
		DivideAssign,

		/// <summary>
		///   a %= b
		/// </summary>
		ModuloAssign,

		/// <summary>
		///   a ^= b in VB
		///   a **= b in Python
		/// </summary>
		PowerAssign,

		/// <summary>
		///   a //= b in Python
		/// </summary>
		FloorDivideAssign,

		/// <summary>
		///   nothing in Java
		/// </summary>
		ArithmeticLeftShiftAssign,

		/// <summary>
		///   a &lt;&lt;= b
		/// </summary>
		LogicalLeftShiftAssign,

		/// <summary>
		///   a >>= b
		/// </summary>
		ArithmeticRightShiftAssign,

		/// <summary>
		///   a >>>= b
		/// </summary>
		LogicalRightShiftAssign,

		/// <summary>
		///   a &amp;= b
		/// </summary>
		AndAssign,

		/// <summary>
		///   a |= b
		/// </summary>
		OrAssign,

		/// <summary>
		///   a ^= b
		/// </summary>
		ExclusiveOrAssign,

		/// <summary>
		/// <c>obj instanceof Object</c> in Java,
		/// <c>obj is object</c> in C#
		/// </summary>
		InstanceOf,

		/// <summary>
		/// <c>obj as String</c> in C#
		/// </summary>
		As,

	}
}