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
	public class UnifiedVariableDefinitionList
			: UnifiedElementCollection
			  		<DeprecatedUnifiedVariableDefinition, UnifiedVariableDefinitionList>,
			  IUnifiedExpression {
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

		private UnifiedVariableDefinitionList() {}

		private UnifiedVariableDefinitionList(
				IEnumerable<DeprecatedUnifiedVariableDefinition> elements)
				: base(elements) {}

		public static UnifiedVariableDefinitionList Create() {
			return new UnifiedVariableDefinitionList();
		}

		public static UnifiedVariableDefinitionList Create(
				params DeprecatedUnifiedVariableDefinition[] elements) {
			return new UnifiedVariableDefinitionList(elements);
		}

		public static UnifiedVariableDefinitionList Create(
				IEnumerable<DeprecatedUnifiedVariableDefinition> elements) {
			return new UnifiedVariableDefinitionList(elements);
		}
			  }
}