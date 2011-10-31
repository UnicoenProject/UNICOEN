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

namespace Unicoen.Apps.UniAspect.Cui.AspectElement {
	/// <summary>
	///   インタータイプ宣言を表します
	///   インタータイプ宣言は１つの言語依存ブロックから構成されます
	/// </summary>
	public class Intertype : IAspectElement {
		private readonly LanguageDependBlock _block = new LanguageDependBlock();
		private string _targetClass;

		//織り込み対象となる言語を指定します
		public void SetLanguageType(string language) {
			_block.SetLanguageType(language);
		}

		//織り込み対象に合成する処理を指定します
		public void SetContents(string content) {
			_block.SetContents(content);
		}

		public void SetTarget(string target) {
			_targetClass = target;
		}

		#region Un-use Methods

		public void SetElementType(string elementType) {
			throw new InvalidOperationException();
		}

		public void SetName(string name) {
			throw new InvalidProgramException();
		}

		public void SetParameterType(string paramType) {
			throw new InvalidOperationException();
		}

		public void SetParameter(string param) {
			throw new InvalidOperationException();
		}

		public void SetType(string type) {
			throw new InvalidOperationException();
		}

		#endregion

		public string GetProperty() {
			var property = "language: " + _block.GetLanguageType() + "\n";
			property += "ClassName: " + _targetClass + "\n";
			property += "contents: ";
			foreach (var c in _block.GetContents()) {
				property += c;
			}
			property += "\n";

			return property;
		}

		public string GetLanguageType() {
			return _block.GetLanguageType();
		}

		public string GetContents() {
			return _block.GetContents();
		}

		public string GetTarget() {
			return _targetClass;
		}
	}
}