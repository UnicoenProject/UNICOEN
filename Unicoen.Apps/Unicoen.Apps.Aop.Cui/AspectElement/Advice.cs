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

namespace Unicoen.Apps.Aop.AspectElement {
	/// <summary>
	///   アドバイスを表します
	///   アドバイスは以下の属性から構成されます
	/// </summary>
	public class Advice : IAspectElement {
		//アドバイスの種類(before or after)
		private string _adviceType;
		//アドバイスのターゲット名
		private string _target;
		//TODO パラメータの実装
		private readonly List<string> _parameters = new List<string>();
		//直前の言語依存ブロックの言語の種類を保存しておくための一時変数
		private string _currentLanguageType;
		//実際に合成されるコード片
		private readonly List<LanguageDependBlock> _fragments =
				new List<LanguageDependBlock>();

		//アドバイスの種類を指定します
		public void SetElementType(string elementType) {
			_adviceType = elementType;
		}

		//アドバイスのターゲットを指定します
		public void SetTarget(string target) {
			_target = target;
		}

		//アドバイスのパラメータを指定します
		public void SetParameter(string param) {
			_parameters.Add(param);
		}

		//コード片の対象言語を指定します
		public void SetLanguageType(string language) {
			_currentLanguageType = language;
		}

		//コード片の内容を指定します
		public void SetContents(string content) {
			foreach (var block in _fragments) {
				//すでに現在の言語に対する言語依存ブロックがある場合
				if (block.GetLanguageType() == _currentLanguageType) {
					block.SetContents(content);
					return;
				}
			}

			//現在の言語に対する言語依存ブロックがなかった場合
			var newBlock = new LanguageDependBlock();
			newBlock.SetLanguageType(_currentLanguageType);
			newBlock.SetContents(content);
			_fragments.Add(newBlock);
		}

		#region Un-use Method

		public void SetName(string name) {
			throw new InvalidOperationException();
		}

		public void SetParameterType(string paramType) {
			throw new InvalidOperationException();
		}

		public void SetType(string type) {
			throw new InvalidOperationException();
		}

		#endregion

		public string GetProperty() {
			var property = "advice type: " + _adviceType + "\n";
			property += "target: " + _target + "\n";
			property += "parameters: ";
			var splitter = "";
			foreach (var parameter in _parameters) {
				property += splitter + parameter;
				splitter = ",";
			}
			property += "\n";
			property += "fragments:\n";
			foreach (var fragment in _fragments) {
				property += "  languege: " + fragment.GetLanguageType() + "\n";
				property += "  contents: " + fragment.GetContents() + "\n";
			}

			return property;
		}

		public string GetAdviceType() {
			return _adviceType;
		}

		public string GetTarget() {
			return _target;
		}

		public List<string> GetParameters() {
			return _parameters;
		}

		public List<LanguageDependBlock> GetFragments() {
			return _fragments;
		}
	}
}