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

namespace Unicoen.Apps.Translator{
	// 関数に特化した検索器
	public class FunctionFinder {
		// 名前からの検索
		public static List<UnifiedFunctionDefinition> FindByName(
				String name, List<UnifiedFunctionDefinition> list) {
			var filteredList = new List<UnifiedFunctionDefinition>();

			foreach (var f in list) {
				if (f.Name.Name.Equals(name)) {
					filteredList.Add(f);
				}
			}

			return filteredList;
		}

		// 返却値型からの検索
		public static List<UnifiedFunctionDefinition> FindByReturnType(
				UnifiedType type, List<UnifiedFunctionDefinition> list) {
			var filteredList = new List<UnifiedFunctionDefinition>();

			throw new NotImplementedException();
		}
	}
}