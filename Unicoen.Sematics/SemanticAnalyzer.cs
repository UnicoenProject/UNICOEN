#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Linq;
using Unicoen.Model;

namespace Unicoen.Sematics {
	public static class SemanticAnalyzer {
		public static UnifiedVariableDefinition FindDefinition(
				UnifiedIdentifier variable) {
			var scopes = variable.Ancestors<UnifiedBlock>();
			var name = variable.Name;
			UnifiedElement searched = variable;

			foreach (var scope in scopes) {
				var definition = scope
						.DescendantsUntil(e2 => e2 is UnifiedBlock)
						.TakeWhile(e => e != searched)
						.OfType<UnifiedVariableDefinition>()
						.FirstOrDefault(e => e.Name.Name == name);
				if (definition != null) {
					return definition;
				}

				searched = scope;
			}
			return null;
		}
	}
}