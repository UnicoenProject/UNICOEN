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

using System.Collections.Generic;
using System.Linq;
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   UnifiedTypeSupplement（配列型やポインタ型などを表すために型に付加される修飾子）の集合を表します。
	///   例えば、<c>int** p;</c>の<c>**</c>部分が該当します。
	/// </summary>
	public class UnifiedTypeSupplementCollection
			: UnifiedElementCollection
			  		<UnifiedTypeSupplement, UnifiedTypeSupplementCollection> {
		private UnifiedTypeSupplementCollection() {}

		private UnifiedTypeSupplementCollection(
				IEnumerable<UnifiedTypeSupplement> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedTypeSupplementCollection Create() {
			return new UnifiedTypeSupplementCollection();
		}

		public static UnifiedTypeSupplementCollection Create(
				params UnifiedTypeSupplement[] elements) {
			return new UnifiedTypeSupplementCollection(elements);
		}

		public static UnifiedTypeSupplementCollection Create(
				IEnumerable<UnifiedTypeSupplement> elements) {
			return new UnifiedTypeSupplementCollection(elements);
		}

		/// <summary>
		///   実引数を持たない一次元配列の修飾子を作成します。
		///   e.g. Javaにおける<c>int[]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray() {
			return CreateArray(1);
		}

		/// <summary>
		///   実引数を持たない多次元配列(ジャグ配列)の修飾子を作成します。
		///   e.g. Javaにおける<c>int[][]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray(int dimension) {
			return CreateArray(
					Enumerable.Repeat(UnifiedArgument.Create(null, null, null), dimension));
		}

		/// <summary>
		///   実引数を指定して配列(ジャグ配列)の修飾子を作成します。次元数は実引数の数になります。
		///   e.g. Javaにおける<c>int[1][2]</c>
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplementCollection CreateArray(
				IEnumerable<UnifiedArgument> values) {
			return values.Select(UnifiedTypeSupplement.CreateArray)
					.ToCollection();
		}
			  		}
}