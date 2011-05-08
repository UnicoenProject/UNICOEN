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
using Paraiba.IO;
using Paraiba.Text;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.Tests {
	/// <summary>
	///   再生成したソースコードが変化していないかテストします。
	///   元コード1→モデル1→コード2→... のように再生成します。
	///   コードは、コンパイルしたclassファイル同士、
	///   もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[TestFixture]
	public class RegenerateTest {
		public IEnumerable<TestCaseData> TestCodes {
			get { return LanguageFixtureLoader.AllTestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes {
			get { return LanguageFixtureLoader.AllTestFilePathes; }
		}

		public IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return LanguageFixtureLoader.AllTestDirectoryPathes; }
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughCompiledCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyCompareCompiledCodeOfSameCode(
				LanguageFixture fixture, string orgPath) {
			var workPath = FixtureUtil.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = FixtureUtil.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			fixture.Compile(workPath, fileName);
			var expected = fixture.GetAllCompiledCode(workPath);
			fixture.Compile(workPath, fileName);
			var actual = fixture.GetAllCompiledCode(workPath);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyCompareModelOfSameCode(
				LanguageFixture fixture, string orgPath) {
			var orgCode = File.ReadAllText(orgPath, XEncoding.SJIS);
			var expected = fixture.ModelFactory.Generate(orgCode);
			var actual = fixture.ModelFactory.Generate(orgCode);
			Assert.That(
					actual, Is.EqualTo(expected)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "orgCode">再生成するソースコード</param>
		/// <param name = "fileName">再生成するソースコードのファイル名</param>
		private static void VerifyCompareCompiledCode(
				LanguageFixture fixture, string orgCode, string fileName) {
			var workPath = FixtureUtil.CleanTemporalPath();
			var srcPath = FixtureUtil.GetTemporalPath(fileName);
			File.WriteAllText(srcPath, orgCode, XEncoding.SJIS);
			fixture.Compile(workPath, fileName);
			var orgByteCode1 = fixture.GetAllCompiledCode(workPath);
			var model1 = fixture.ModelFactory.Generate(orgCode);
			var code2 = fixture.CodeFactory.Generate(model1);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			fixture.Compile(workPath, fileName);
			var byteCode2 = fixture.GetAllCompiledCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   指定したディレクトリ内のコンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		/// <param name = "command">コンパイルに用いるコマンド名</param>
		/// <param name = "arguments">コンパイルに用いる引数リスト</param>
		private static void VerifyCompareCompiledCodeUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var workPath = FixtureUtil.CleanTemporalPath();
			FileUtility.CopyRecursively(dirPath, workPath);
			fixture.CompileWithArguments(workPath, command, arguments);
			var orgByteCode1 = fixture.GetAllCompiledCode(workPath);
			var codePaths = fixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = fixture.ModelFactory.Generate(orgCode1);
				var code2 = fixture.CodeFactory.Generate(model1);
				File.WriteAllText(codePath, code2, XEncoding.SJIS);
			}
			fixture.CompileWithArguments(workPath, command, arguments);
			var byteCode2 = fixture.GetAllCompiledCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "orgCode">再生成するソースコード</param>
		private static void VerifyCompareModel(
				LanguageFixture fixture, string orgCode) {
			var model1 = fixture.ModelFactory.Generate(orgCode);
			var code2 = fixture.CodeFactory.Generate(model1);
			var model2 = fixture.ModelFactory.Generate(code2);
			var code3 = fixture.CodeFactory.Generate(model2);
			var model3 = fixture.ModelFactory.Generate(code3);
			Assert.That(
					model3, Is.EqualTo(model2)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		private static void VerifyCompareModelUsingDirectory(
				LanguageFixture fixture, string dirPath) {
			var codePaths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var codePath in codePaths) {
				var orgCode = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = fixture.ModelFactory.Generate(orgCode);
				var code2 = fixture.CodeFactory.Generate(model1);
				var model2 = fixture.ModelFactory.Generate(code2);
				var code3 = fixture.CodeFactory.Generate(model2);
				var model3 = fixture.ModelFactory.Generate(code3);
				Assert.That(
						model3, Is.EqualTo(model2)
						        		.Using(StructuralEqualityComparerForDebug.Instance));
			}
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareCompiledCodeUsingCode(
				LanguageFixture fixture, string code) {
			VerifyCompareCompiledCode(fixture, code, "A" + fixture.Extension);
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareModelUsingCode(LanguageFixture fixture, string code) {
			VerifyCompareModel(fixture, code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareCompiledCodeUsingFile(
				LanguageFixture fixture, string orgPath) {
			var fileName = Path.GetFileName(orgPath);
			VerifyCompareCompiledCode(
					fixture,
					File.ReadAllText(orgPath, XEncoding.SJIS), fileName);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareModelUsingFile(
				LanguageFixture fixture, string orgPath) {
			VerifyCompareModel(fixture, File.ReadAllText(orgPath, XEncoding.SJIS));
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public void CompareCompiledCodeUsingDirectory(
				LanguageFixture fixture, string orgPath, string command, string arguments) {
			VerifyCompareCompiledCodeUsingDirectory(
					fixture, orgPath, command, arguments);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public void CompareModelUsingDirectory(
				LanguageFixture fixture, string orgPath, string command, string arguments) {
			VerifyCompareModelUsingDirectory(fixture, orgPath);
		}
	}
}