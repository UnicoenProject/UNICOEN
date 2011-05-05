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

using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Unicoen.Core.Tests {
	public abstract class LanguageFixture {
		/// <summary>
		///   対応する言語のソースコードの拡張子を表します．
		/// </summary>
		public abstract string Extension { get; }

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestStatements { get; }

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestCodes { get; }

		/// <summary>
		///   テスト時に
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestFilePathes { get; }

		public abstract IEnumerable<TestCaseData> TestDirectoryPathes { get; }

		public IEnumerable<string> GetAllSourceFilePaths(string workPath) {
			return Directory.EnumerateFiles(
					workPath, "*" + Extension,
					SearchOption.AllDirectories);
		}
	}
}