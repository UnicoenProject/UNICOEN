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
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   case式の集合を表します。
	///   e.g. Javaにおける<c>switch(v){case c1: ... case c2: ...}</c>の<c>case c1: ... case c2: ...</c>
	/// </summary>
	public class UnifiedCaseCollection
			: UnifiedElementCollection<UnifiedCase, UnifiedCaseCollection> {
		private UnifiedCaseCollection() {}

		private UnifiedCaseCollection(IEnumerable<UnifiedCase> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedCaseCollection Create() {
			return new UnifiedCaseCollection();
		}

		public static UnifiedCaseCollection Create(params UnifiedCase[] elements) {
			return new UnifiedCaseCollection(elements);
		}

		public static UnifiedCaseCollection Create(IEnumerable<UnifiedCase> elements) {
			return new UnifiedCaseCollection(elements);
		}
			}
}