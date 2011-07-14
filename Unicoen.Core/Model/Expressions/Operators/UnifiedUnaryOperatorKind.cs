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

namespace Unicoen.Core.Model {
	/// <summary>
	///   単項演算子の種類を表します。
	///   http://msdn.microsoft.com/ja-jp/library/bb361179.aspx
	/// </summary>
	public enum UnifiedUnaryOperatorKind {
		/// <summary>
		///   種類が不明
		/// </summary>
		Unknown,

		/// <summary>
		///   e.g. ++a
		/// </summary>
		PreIncrementAssign,

		/// <summary>
		///   e.g. --a
		/// </summary>
		PreDecrementAssign,

		/// <summary>
		///   e.g. a++
		/// </summary>
		PostIncrementAssign,

		/// <summary>
		///   e.g. a--
		/// </summary>
		PostDecrementAssign,

		/// <summary>
		///   e.g. +a
		/// </summary>
		UnaryPlus,

		/// <summary>
		///   e.g. -a
		/// </summary>
		Negate,

		/// <summary>
		///   e.g. !a
		/// </summary>
		Not,

		/// <summary>
		///   e.g. ~a
		/// </summary>
		OnesComplement,

		/// <summary>
		///   e.g. &a
		/// </summary>
		Address,

		/// <summary>
		///   e.g. *a
		/// </summary>
		Indirect,
	}
}