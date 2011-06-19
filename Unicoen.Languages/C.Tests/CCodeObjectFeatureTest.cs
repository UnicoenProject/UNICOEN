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
using NUnit.Framework;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.C.Tests {
	[TestFixture]
	public class CCodeObjectFeatureTest : LanguageTestBase {
		private Fixture _fixture;

		protected override Fixture Fixture {
			get { return _fixture ?? (_fixture = new CFixture()); }
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "code">検査対象のソースコード</param>
		[Ignore, Test, TestCaseSource("TestCodes")]
		public void VerifyCodeObjectFeatureUsingCode(string code) {
			Test.VerifyCodeObjectFeatureUsingCode(code);
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "path">検査対象のソースコードのパス</param>
		[Ignore, Test, TestCaseSource("TestFilePathes")]
		public void VerifyCodeObjectFeatureUsingFile(string path) {
			Test.VerifyCodeObjectFeatureUsingFile(path);
		}

		/// <summary>
		///   指定したディレクトリ内のソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "dirPath">検査対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "compileAction">使用しません</param>
		[Ignore, Test, TestCaseSource("TestProjectInfos")]
		public void VerifyCodeObjectFeatureUsingProject(string dirPath, Action<string> compileAction) {
			Test.VerifyCodeObjectFeatureUsingProject(dirPath, compileAction);
		}
	}
}