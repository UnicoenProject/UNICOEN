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

namespace Unicoen.Apps.Translator{
	public class Util {
		
		// 言語に応じた拡張子を取得する
		public static string GetExtention(LanguageType type) {
			switch (type) {
			case LanguageType.C:
				return "c";
			case LanguageType.Java:
				return "java";
			case LanguageType.CSharp:
				return "cs";
			case LanguageType.Ruby:
				return "rb";
			case LanguageType.Python:
				return "py";
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public enum LanguageType {
		C,
		Java,
		CSharp,
		Ruby,
		Python,
	}
}