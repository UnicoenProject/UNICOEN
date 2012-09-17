#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using NUnit.Framework;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.C.Tests {
	[TestFixture]
	public class CHeavyLanguageTest : LanguageTestBase {
		private Fixture _fixture;

		protected override Fixture Fixture {
			get { return _fixture ?? (_fixture = new CFixture()); }
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して， 生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name="dirPath"> 検査対象のソースコードが格納されているディレクトリのパス </param>
		/// <param name="relativePathsForBinaryFiles">使用しません</param>
		/// <param name="compileActionWithWorkDirPath"> 使用しません </param>
		[Test, TestCaseSource("TestProjectInfos")]
		public void VerifyCodeObjectFeatureUsingProject(
				string dirPath, IList<string> relativePathsForBinaryFiles,
				Action<string> compileActionWithWorkDirPath) {
			Test.VerifyCodeObjectFeatureUsingProject(
					dirPath, relativePathsForBinaryFiles, compileActionWithWorkDirPath);
		}

		/// <summary>
		///   指定したディレクトリ内のソースコードから統一コードオブジェクトを生成して， ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name="dirPath"> 検査対象のソースコードが格納されているディレクトリのパス </param>
		/// <param name="relativePathsForBinaryFiles">コンパイル済みコードのルートディレクトリの相対パスの配列</param>
		/// <param name="compileActionWithWorkDirPath"> コンパイル処理 </param>
		[Test, TestCaseSource("TestProjectInfos")]
		public void VerifyRegenerateCodeUsingProject(
				string dirPath, IList<string> relativePathsForBinaryFiles,
				Action<string> compileActionWithWorkDirPath) {
			Test.VerifyRegenerateCodeUsingProject(
					dirPath, relativePathsForBinaryFiles, compileActionWithWorkDirPath);
		}
	}
}