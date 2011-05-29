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
	public static class ModelFactoryForModel {
		public static UnifiedArgument ToArgument(this IUnifiedExpression expression) {
			return UnifiedArgument.Create(expression);
		}

		public static UnifiedFunctionDefinition ToFunctionDefinition(this string name) {
			return UnifiedFunctionDefinition.CreateFunction(name);
		}

		public static UnifiedWhile ToWhile(this IUnifiedExpression condition) {
			return UnifiedWhile.Create(condition);
		}

		public static UnifiedDoWhile ToDoWhile(this IUnifiedExpression condition) {
			return UnifiedDoWhile.Create(condition);
		}

		public static UnifiedForeach ToForeach(
				this IUnifiedExpression set,
				UnifiedType variableType,
				string variableName) {
			return UnifiedForeach.Create(
					DeprecatedUnifiedVariableDefinition.CreateSingle(
							variableType, variableName),
					set
					);
		}

		public static UnifiedIf ToIf(this IUnifiedExpression condition) {
			return UnifiedIf.Create(condition);
		}

		public static UnifiedSpecialExpression ToReturn(this IUnifiedExpression value) {
			return UnifiedSpecialExpression.CreateReturn(value);
		}

		public static UnifiedCase ToCase(this IUnifiedExpression condtion) {
			return UnifiedCase.Create(condtion, UnifiedBlock.Create());
		}

		public static UnifiedSwitch ToSwitch(this IUnifiedExpression value) {
			return UnifiedSwitch.Create(value);
		}

		public static UnifiedTypeArgument ToTypeParameter(
				this IUnifiedExpression value) {
			return UnifiedTypeArgument.Create(value);
		}

		public static UnifiedNew ToNew(this UnifiedType type) {
			return UnifiedNew.Create(type);
		}
	}
}