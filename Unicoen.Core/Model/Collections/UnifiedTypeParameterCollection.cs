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
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   ジェネリックタイプにおける仮引数の集合を表します。
	///   クラスやメソッドを宣言する際に型パラメータを宣言するために利用します。
	///   e.g. Javaにおける<c>class A&lt;T1, T2&gt; {  }</c>の<c>&lt;T1, T2&gt;</c>
	/// </summary>
	public class UnifiedTypeParameterCollection
			: UnifiedElementCollection
			  		<UnifiedTypeParameter, UnifiedTypeParameterCollection> {
		private UnifiedTypeParameterCollection() {}

		private UnifiedTypeParameterCollection(
				IEnumerable<UnifiedTypeParameter> elements)
				: base(elements) {}

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

		public static UnifiedTypeParameterCollection Create() {
			return new UnifiedTypeParameterCollection();
		}

		public static UnifiedTypeParameterCollection Create(
				params UnifiedTypeParameter[] elements) {
			return new UnifiedTypeParameterCollection(elements);
		}

		public static UnifiedTypeParameterCollection Create(
				IEnumerable<UnifiedTypeParameter> elements) {
			return new UnifiedTypeParameterCollection(elements);
		}
			  		}
}