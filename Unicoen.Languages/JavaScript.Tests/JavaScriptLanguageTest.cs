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

namespace Unicoen.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptLanguageTest : LanguageTestBase {
		private Fixture _fixture;

		protected override Fixture Fixture {
			get { return _fixture ?? (_fixture = new JavaScriptFixture()); }
		}

		#region TestFilePaths

		/// <summary>
		///   再生成を行わずAssertCompareCompiledCodeが正常に動作するかテストします。 全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name="orgPath"> 再生成するソースコードのパス </param>
		[Test, TestCaseSource("TestFilePaths")]
		public void VerifyAssertCompareCompiledCode(string orgPath) {
			Test.VerifyAssertCompareCompiledCode(orgPath);
		}

		/// <summary>
		///   再生成を行わずAssertCompareModelが正常に動作するかテストします。 全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name="orgPath"> 再生成するソースコードのパス </param>
		[Test, TestCaseSource("TestFilePaths")]
		public void VerifyAssertCompareModel(string orgPath) {
			Test.VerifyAssertCompareModel(orgPath);
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して， ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name="path"> 検査対象のソースコードのパス </param>
		[Test, TestCaseSource("TestFilePaths")]
		public void VerifyRegenerateCodeUsingFile(string path) {
			Test.VerifyRegenerateCodeUsingFile(path);
		}

		#endregion

		#region TestCodes

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して， 生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name="code"> 検査対象のソースコード </param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyCodeObjectFeatureUsingCode(string code) {
			Test.VerifyCodeObjectFeatureUsingCode(code);
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して， ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name="code"> 検査対象のソースコード </param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyRegenerateCodeUsingCode(string code) {
			Test.VerifyRegenerateCodeUsingCode(code);
		}

		#endregion

		#region TestProjectInfos

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

		#endregion
	}
}