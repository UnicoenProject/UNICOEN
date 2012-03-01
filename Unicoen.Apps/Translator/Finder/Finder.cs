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
using Unicoen.Model;

namespace Unicoen.Apps.Translator.Finder {
	// モデルの検索に関するクラス
	public class Finder {
		// 関数が与えられたパラメータを持っているか
		public Boolean HasParameter(
				UnifiedFunctionDefinition func, Parameter param) {
			if (func.Name.Equals(param.Name)
				&& func.Type.BasicTypeName.Equals(param.TypeName)) {
				return true;
			}
			return false;
		}

		/// <summary>
		///   programに含まれるT型の要素をすべて取得する
		/// </summary>
		/// <example>
		///   <c>var functionList = GetAllElements&lt;UnifiedFunction&gt;(program);</c>
		/// </example>
		/// <typeparam name="T"> </typeparam>
		/// <param name="program"> </param>
		/// <returns> </returns>
		public static List<T> GetAllElements<T>(UnifiedProgram program)
				where T : UnifiedElement
		{
			var elements = program.Elements();
			var list = new List<T>();

			foreach (var element in elements) {
				GetAllElement(element, list);
			}

			return list;
		}

		private static void GetAllElement<T>(
				UnifiedElement element, List<T> list)
				where T : UnifiedElement
		{
			if (element == null) {
				return;
			}

			var elements = element.Elements();
			if (elements == null) {
				return;
			}
			foreach (var e in elements) {
				if (e != null) {
					if (e is T) {
						list.Add((T)e);
					}
					GetAllElement(e, list);
				}
			}
		}
	}

	public class Parameter {
		public string Name { get; set; }
		public string TypeName { get; set; }
	}
}