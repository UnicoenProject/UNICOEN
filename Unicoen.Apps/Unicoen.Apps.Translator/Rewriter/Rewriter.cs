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
using Unicoen.Core.Model;

namespace Unicoen.Apps.Translator.Rewriter {
	public class Rewriter {
		public static Rewriter Instance = new Rewriter();

		// targetの Name.Value プロパティを newName に書き換える（関数名を書き換えるなど）
		public void RewiteIdentifierName(string newName, UnifiedElement target) {
			if (target is UnifiedFunction) {
				((UnifiedFunction)target).Name.Value = newName;
				return;
			}
		}

		// ある要素を置き換える
		public void ExchageElement(UnifiedType from, UnifiedType to) {
			var parent = from.Parent;
			var reference =
					parent.GetElementReferences().Where(e => ReferenceEquals(e.Element, from)).
							ElementAt(0);
			reference.Element = to;

			return;
		}

		// ある要素を削除する
		public void DeleteElement(UnifiedElement target) {
			target.Remove();
		}
	}
}