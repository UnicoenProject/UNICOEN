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
	///   仮引数の集合を表します。
	///   e.g. Javaにおける<c>int method(int a, double b){....}</c>の<c>(int a, double b)</c>
	/// </summary>
	public class UnifiedParameterCollection
			: UnifiedElementCollection<UnifiedParameter, UnifiedParameterCollection> {
		private UnifiedParameterCollection() {}

		private UnifiedParameterCollection(IEnumerable<UnifiedParameter> elements)
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

		public static UnifiedParameterCollection Create() {
			return new UnifiedParameterCollection();
		}

		public static UnifiedParameterCollection Create(
				params UnifiedParameter[] elements) {
			return new UnifiedParameterCollection(elements);
		}

		public static UnifiedParameterCollection Create(
				IEnumerable<UnifiedParameter> elements) {
			return new UnifiedParameterCollection(elements);
		}
			}
}