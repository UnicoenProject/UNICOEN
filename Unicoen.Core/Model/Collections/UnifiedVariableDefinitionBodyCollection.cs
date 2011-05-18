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
	///   修飾子や型を除いた変数宣言の集合を表します。
	///   e.g. Javaにおける<c>int a, b;</c>の<c>a, b;</c>
	/// </summary>
	public class UnifiedVariableDefinitionBodyCollection
			: UnifiedElementCollection
			  		<DeprecatedUnifiedVariableDefinitionBody,
			  		UnifiedVariableDefinitionBodyCollection> {
		private UnifiedVariableDefinitionBodyCollection() {}

		private UnifiedVariableDefinitionBodyCollection(
				IEnumerable<DeprecatedUnifiedVariableDefinitionBody> elements)
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

		public static UnifiedVariableDefinitionBodyCollection Create() {
			return new UnifiedVariableDefinitionBodyCollection();
		}

		public static UnifiedVariableDefinitionBodyCollection Create(
				params DeprecatedUnifiedVariableDefinitionBody[] elements) {
			return new UnifiedVariableDefinitionBodyCollection(elements);
		}

		public static UnifiedVariableDefinitionBodyCollection Create(
				IEnumerable<DeprecatedUnifiedVariableDefinitionBody> elements) {
			return new UnifiedVariableDefinitionBodyCollection(elements);
		}
			  		}
}