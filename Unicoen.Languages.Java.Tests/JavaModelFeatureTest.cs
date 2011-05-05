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
using Unicoen.Core.ModelFactories;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	[TestFixture]
	public class JavaModelFeatureTest : ModelFeatureTest {
		private readonly JavaFixture _fixture = new JavaFixture();

		protected override LanguageFixture Fixture {
			get { return _fixture; }
		}

		private readonly JavaModelFactory _modelFactory = new JavaModelFactory();

		protected override ModelFactory ModelFactory {
			get { return _modelFactory; }
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
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
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyDeepCopyUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyDeepCopyUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
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
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementsUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementsUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyGetElementAndSettersUsingCode(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndSettersUsingFile(string path) {
			base.VerifyGetElementAndSettersUsingFile(path);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementAndSettersUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void VerifyGetElementAndDirectSettersUsingCode(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndDirectSettersUsingFile(string path) {
			base.VerifyGetElementAndDirectSettersUsingFile(path);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndDirectSettersUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyGetElementAndDirectSettersUsingDirectory(
					dirPath, command, arguments);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
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
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyParentPropertyUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyParentPropertyUsingDirectory(dirPath, command, arguments);
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
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
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyToStringUsingDirectory(
				string dirPath, string command, string arguments) {
			base.VerifyToStringUsingDirectory(dirPath, command, arguments);
		}
	}
}