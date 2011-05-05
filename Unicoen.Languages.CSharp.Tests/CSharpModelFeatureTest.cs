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
using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.CSharp.Tests {

	[Ignore, TestFixture]
	public class CSharpModelFeatureTest : ModelFeatureTest {
		public IEnumerable<TestCaseData> TestStatements {
			get { return CSharpRegenerateTest.TestStatements; }
		}

		public IEnumerable<TestCaseData> TestCodes {
			get { return CSharpRegenerateTest.TestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes {
			get { return CSharpRegenerateTest.TestFilePathes; }
		}

		protected override UnifiedProgram CreateModel(string code) {
			return CSharpFactory.GenerateModel(code);
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyDeepCopyUsingCode(string code) {
			VerifyDeepCopy(code);
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(string path) {
			VerifyDeepCopy(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementsUsingCode(string code) {
			VerifyGetElements(code);
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(string path) {
			VerifyGetElements(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndSettersUsingCode(string code) {
			VerifyGetElementAndSetters(code);
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(string path) {
			VerifyGetElementAndSetters(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyGetElementAndDirectSettersUsingCode(string code) {
			VerifyGetElementAndDirectSetters(code);
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(string path) {
			VerifyGetElementAndDirectSetters(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyParentPropertyUsingCode(string code) {
			VerifyParentProperty(code);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(string path) {
			VerifyParentProperty(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public void VerifyToStringUsingCode(string code) {
			VerifyToString(code);
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(string path) {
			VerifyToString(File.ReadAllText(path, XEncoding.SJIS));
		}
	}
}