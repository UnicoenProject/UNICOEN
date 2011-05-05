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
using Unicoen.Core.CodeFactories;
using Unicoen.Core.ModelFactories;

namespace Unicoen.Core.Tests {
	public abstract class RegenerateTest {
		public abstract LanguageFixture Fixture { get; }
		public abstract CodeFactory CodeFactory { get; }
		public abstract ModelFactory ModelFactory { get; }

		public IEnumerable<TestCaseData> TestStatements {
			get { return Fixture.TestStatements; }
		}

		public IEnumerable<TestCaseData> TestCodes {
			get { return Fixture.TestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes {
			get { return Fixture.TestFilePathes; }
		}

		public IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return Fixture.TestDirectoryPathes; }
		}

		protected abstract void Compile(string workPath, string fileName);

		protected abstract IEnumerable<object[]> GetAllCompiledCode(string workPath);

		protected abstract void CompileWithArguments(
				string workPath, string command, string arguments);

		/// <summary>
		///   再生成を行わずVerifyCompareThroughCompiledCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public virtual void VerifyCompareThroughCompiledCodeForSameCode(
				string orgPath) {
			var workPath = Tests.Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Tests.Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			Compile(workPath, fileName);
			var expected = GetAllCompiledCode(workPath);
			Compile(workPath, fileName);
			var actual = GetAllCompiledCode(workPath);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public virtual void VerifyCompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath, XEncoding.SJIS);
			var expected = ModelFactory.Generate(orgCode);
			var actual = ModelFactory.Generate(orgCode);
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
		private void VerifyCompareThroughCompiledCode(string orgCode, string fileName) {
			var workPath = Tests.Fixture.CleanTemporalPath();
			var srcPath = Tests.Fixture.GetTemporalPath(fileName);
			File.WriteAllText(srcPath, orgCode, XEncoding.SJIS);
			Compile(workPath, fileName);
			var orgByteCode1 = GetAllCompiledCode(workPath);
			var model1 = ModelFactory.Generate(orgCode);
			var code2 = CodeFactory.Generate(model1);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			Compile(workPath, fileName);
			var byteCode2 = GetAllCompiledCode(workPath);
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
		private void VerifyCompareThroughCompiledCodeUsingDirectory(
				string dirPath, string command, string arguments) {
			var workPath = Tests.Fixture.CleanTemporalPath();
			FileUtility.CopyRecursively(dirPath, workPath);
			CompileWithArguments(workPath, command, arguments);
			var orgByteCode1 = GetAllCompiledCode(workPath);
			var codePaths = Fixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = ModelFactory.Generate(orgCode1);
				var code2 = CodeFactory.Generate(model1);
				File.WriteAllText(codePath, code2, XEncoding.SJIS);
			}
			CompileWithArguments(workPath, command, arguments);
			var byteCode2 = GetAllCompiledCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgCode">再生成するソースコード</param>
		private void VerifyCompareThroughModel(string orgCode) {
			var model1 = ModelFactory.Generate(orgCode);
			var code2 = CodeFactory.Generate(model1);
			var model2 = ModelFactory.Generate(code2);
			var code3 = CodeFactory.Generate(model2);
			var model3 = ModelFactory.Generate(code3);
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
		private void VerifyCompareThroughModelUsingDirectory(string dirPath) {
			var codePaths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var codePath in codePaths) {
				var orgCode = File.ReadAllText(codePath, XEncoding.SJIS);
				var model1 = ModelFactory.Generate(orgCode);
				var code2 = CodeFactory.Generate(model1);
				var model2 = ModelFactory.Generate(code2);
				var code3 = CodeFactory.Generate(model2);
				var model3 = ModelFactory.Generate(code3);
				Assert.That(
						model3, Is.EqualTo(model2)
						        		.Using(StructuralEqualityComparerForDebug.Instance));
			}
		}

		public virtual void CompareThroughByteCodeUsingCode(string code) {
			VerifyCompareThroughCompiledCode(code, "A" + Fixture.Extension);
		}

		public virtual void CompareThroughModelUsingCode(string code) {
			VerifyCompareThroughModel(code);
		}

		public virtual void CompareThroughByteCodeUsingFile(string orgPath) {
			var fileName = Path.GetFileName(orgPath);
			VerifyCompareThroughCompiledCode(
					File.ReadAllText(orgPath, XEncoding.SJIS), fileName);
		}

		public virtual void CompareThroughModelUsingFile(string orgPath) {
			VerifyCompareThroughModel(File.ReadAllText(orgPath, XEncoding.SJIS));
		}

		public virtual void CompareThroughByteCodeUsingDirectory(
				string orgPath, string command, string arguments) {
			VerifyCompareThroughCompiledCodeUsingDirectory(orgPath, command, arguments);
		}

		public virtual void CompareThroughModelUsingDirectory(
				string orgPath, string command, string arguments) {
			VerifyCompareThroughModelUsingDirectory(orgPath);
		}
	}
}