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

using System.Linq;
using Unicoen.Model;

namespace Unicoen.Processor {
	public static class SemanticAnalyzer {
		public static UnifiedVariableDefinition FindDefinition(
				UnifiedIdentifier variable) {
			var blocks = variable.Ancestors<UnifiedBlock>();
			var name = variable.Name;
			IUnifiedElement endElement = variable;

			foreach (var block in blocks) {
				var definition = block
						.Descendants()
						.TakeWhile(e => e != endElement)
						.OfType<UnifiedVariableDefinition>()
						.FirstOrDefault(e => e.Name.Name == name);
				if (definition != null)
					return definition;

				endElement = block;
			}
			return null;
		}
	}
}