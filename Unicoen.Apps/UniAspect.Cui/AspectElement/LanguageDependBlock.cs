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

namespace Unicoen.Apps.UniAspect.Cui.AspectElement {
	/// <summary>
	///   言語依存ブロックを表します
	/// </summary>
	public class LanguageDependBlock {
		/// <summary>
		///   依存する言語の種類
		/// </summary>
		private string _languageType;

		/// <summary>
		///   合成される処理内容
		/// </summary>
		private string _contents;

		public string GetLanguageType() {
			return _languageType;
		}

		public string GetContents() {
			return _contents;
		}

		public void SetLanguageType(string language) {
			_languageType = language;
		}

		public void SetContents(string content) {
			_contents += (content + " ");
		}
	}
}