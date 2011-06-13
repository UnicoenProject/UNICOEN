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

using System;
using System.Collections.Generic;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Translator.Filter {
	public class FunctionFinder {
		// Singleton!
		public static FunctionFinder Instance = new FunctionFinder();

		public List<UnifiedFunction> FindByName(
				String name, List<UnifiedFunction> list) {
			var filteredList = new List<UnifiedFunction>();

			foreach (var f in list) {
				if (f.Name.Value.Equals(name)) {
					filteredList.Add(f);
				}
			}

			return filteredList;
		}

		public List<UnifiedFunction> FindByReturnType(
				UnifiedType type, List<UnifiedFunction> list) {
			var filteredList = new List<UnifiedFunction>();

			throw new NotImplementedException();
		}
	}
}