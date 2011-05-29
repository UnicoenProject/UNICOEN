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

using NUnit.Framework;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.C.Tests {
	[Ignore, TestFixture]
	public class CModelFeatureTest : ModelFeatureTest {
		private readonly Fixture _fixture = new CFixture();

		/// <summary>
		///   テストフィクスチャを取得します．
		/// </summary>
		protected override Fixture Fixture {
			get { return _fixture; }
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyDeepCopyUsingCode(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyDeepCopyUsingFile(string path) {
			base.VerifyDeepCopyUsingFile(path);
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyDeepCopyUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyDeepCopyUsingProject(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementsUsingCode(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementsUsingFile(string path) {
			base.VerifyGetElementsUsingFile(path);
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyGetElementsUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementsUsingProject(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementReferencesUsingCode(string code) {
			base.VerifyGetElementReferencesUsingCode(code);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementReferencesUsingFile(string path) {
			base.VerifyGetElementReferencesUsingFile(path);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyGetElementReferencesUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementReferencesUsingProject(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementReferenecesOfFieldsUsingCode(string code) {
			base.VerifyGetElementReferenecesOfFieldsUsingCode(code);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementReferenecesOfFieldsUsingFile(string path) {
			base.VerifyGetElementReferenecesOfFieldsUsingFile(path);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyGetElementReferenecesOfFieldsUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementReferenecesOfFieldsUsingProject(
					dirPath, command, arguments);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyParentPropertyUsingCode(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyParentPropertyUsingFile(string path) {
			base.VerifyParentPropertyUsingFile(path);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyParentPropertyUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyParentPropertyUsingProject(dirPath, command, arguments);
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyToStringUsingCode(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyToStringUsingFile(string path) {
			base.VerifyToStringUsingFile(path);
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void VerifyToStringUsingProject(
				string dirPath, string command, string arguments) {
			base.VerifyToStringUsingProject(dirPath, command, arguments);
		}
	}
}