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
	public abstract class RegenerateTest : LanguageTestBase {
		/// <summary>
		///   再生成を行わずVerifyCompareThroughCompiledCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public virtual void CompareCompiledCodeOfSameCode(
				string orgPath) {
			var workPath = FixtureUtil.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = FixtureUtil.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			Fixture.Compile(workPath, fileName);
			var expected = Fixture.GetAllCompiledCode(workPath);
			Fixture.Compile(workPath, fileName);
			var actual = Fixture.GetAllCompiledCode(workPath);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public virtual void CompareModelOfSameCode(
				string orgPath) {
			var orgCode = File.ReadAllText(orgPath, XEncoding.SJIS);
			var expected = Fixture.ModelFactory.Generate(orgCode);
			var actual = Fixture.ModelFactory.Generate(orgCode);
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
		/// <param name = "orgCode">再生成するソースコード</param>
		/// <param name = "fileName">再生成するソースコードのファイル名</param>
		private void VerifyCompareCompiledCode(
				string orgCode, string fileName) {
			var workPath = FixtureUtil.CleanTemporalPath();
			var srcPath = FixtureUtil.GetTemporalPath(fileName);
			File.WriteAllText(srcPath, orgCode, XEncoding.SJIS);
			Fixture.Compile(workPath, fileName);
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			var model1 = Fixture.ModelFactory.Generate(orgCode);
			var code2 = Fixture.CodeFactory.Generate(model1);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			Fixture.Compile(workPath, fileName);
			var byteCode2 = Fixture.GetAllCompiledCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   指定したディレクトリ内のコンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		/// <param name = "command">コンパイルに用いるコマンド名</param>
		/// <param name = "arguments">コンパイルに用いる引数リスト</param>
		private void VerifyCompareCompiledCodeUsingDirectory(
				string dirPath, string command, string arguments) {
			var workPath = FixtureUtil.CleanTemporalPath();
			FileUtility.CopyRecursively(dirPath, workPath);
			Fixture.CompileWithArguments(workPath, command, arguments);
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			var codePaths = Fixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = Fixture.ModelFactory.Generate(orgCode1);
				var code2 = Fixture.CodeFactory.Generate(model1);
				File.WriteAllText(codePath, code2, XEncoding.SJIS);
			}
			Fixture.CompileWithArguments(workPath, command, arguments);
			var byteCode2 = Fixture.GetAllCompiledCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgCode">再生成するソースコード</param>
		private void VerifyCompareModel(
				string orgCode) {
			var model1 = Fixture.ModelFactory.Generate(orgCode);
			var code2 = Fixture.CodeFactory.Generate(model1);
			var model2 = Fixture.ModelFactory.Generate(code2);
			var code3 = Fixture.CodeFactory.Generate(model2);
			var model3 = Fixture.ModelFactory.Generate(code3);
			Assert.That(
					model3, Is.EqualTo(model2)
					        		.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		private void VerifyCompareModelUsingDirectory(
				string dirPath) {
			var codePaths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var codePath in codePaths) {
				var orgCode = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = Fixture.ModelFactory.Generate(orgCode);
				var code2 = Fixture.CodeFactory.Generate(model1);
				var model2 = Fixture.ModelFactory.Generate(code2);
				var code3 = Fixture.CodeFactory.Generate(model2);
				var model3 = Fixture.ModelFactory.Generate(code3);
				Assert.That(
						model3, Is.EqualTo(model2)
						        		.Using(StructuralEqualityComparerForDebug.Instance));
			}
		}

		public virtual void CompareCompiledCodeUsingCode(
				string code) {
			VerifyCompareCompiledCode(code, "A" + Fixture.Extension);
		}

		public virtual void CompareModelUsingCode(string code) {
			VerifyCompareModel(code);
		}

		public virtual void CompareCompiledCodeUsingFile(
				string orgPath) {
			var fileName = Path.GetFileName(orgPath);
			VerifyCompareCompiledCode(
					File.ReadAllText(orgPath, XEncoding.SJIS), fileName);
		}

		public virtual void CompareModelUsingFile(
				string orgPath) {
			VerifyCompareModel(File.ReadAllText(orgPath, XEncoding.SJIS));
		}

		public virtual void CompareCompiledCodeUsingDirectory(
				string orgPath, string command, string arguments) {
			VerifyCompareCompiledCodeUsingDirectory(
					orgPath, command, arguments);
		}

		public virtual void CompareModelUsingDirectory(
				string orgPath, string command, string arguments) {
			VerifyCompareModelUsingDirectory(orgPath);
		}
	}
}