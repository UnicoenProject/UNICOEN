using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
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
			return CSharpModelFactory.CreateModel(code);
		}

		/// <summary>
		/// 深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyDeepCopyUsingStatement(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		/// 深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyDeepCopyUsingCode(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		/// <summary>
		/// 深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(string path) {
			base.VerifyDeepCopyUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// 子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementsUsingStatement(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		/// 子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementsUsingCode(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		/// <summary>
		/// 子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(string path) {
			base.VerifyGetElementsUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// 子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementAndSettersUsingStatement(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		/// 子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndSettersUsingCode(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		/// <summary>
		/// 子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(string path) {
			base.VerifyGetElementAndSettersUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// 子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyGetElementAndDirectSettersUsingStatement(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		/// 子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndDirectSettersUsingCode(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		/// <summary>
		/// 子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(string path) {
			base.VerifyGetElementAndDirectSettersUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// 親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyParentPropertyUsingStatements(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		/// 親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyParentPropertyUsingCode(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		/// <summary>
		/// 親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(string path) {
			base.VerifyParentPropertyUsingCode(File.ReadAllText(path));
		}

		/// <summary>
		/// 全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestStatements")]
		public void VerifyToStringUsingStatements(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		/// 全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name="code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void VerifyToStringUsingCode(string code) {
			base.VerifyToStringUsingCode(code);
		}

		/// <summary>
		/// 全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(string path) {
			base.VerifyToStringUsingCode(File.ReadAllText(path));
		}
	}
}
