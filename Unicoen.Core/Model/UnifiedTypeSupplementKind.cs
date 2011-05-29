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
	///   UnifiedTypeSupplementの種類を表します。
	/// </summary>
	public enum UnifiedTypeSupplementKind {
		/// <summary>
		///   e.g. C, C++, C#におけるポインタ(<c>int *p;</c>)
		/// </summary>
		Pointer,

		/// <summary>
		///   e.g. C++における参照(<c>int &p = i;</c>)
		/// </summary>
		Reference,

		/// <summary>
		///   e.g. C#, Javaにおける配列(<c>int[] a;</c>)
		///   e.g. C, C++における配列(<c>int[10] a;</c>)
		/// </summary>
		Array,

		/// <summary>
		///   e.g. C#における多次元配列(<c>int[,] a2;</c>)
		/// </summary>
		MultidimensionArray,
	}
}