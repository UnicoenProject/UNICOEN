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

namespace Unicoen.Languages.Java.Tests {
	[TestFixture]
	public class JavaRegenerateTest : RegenerateTest {
		private readonly Fixture _fixture = new JavaFixture();

		/// <summary>
		///   テストフィクスチャを取得します．
		/// </summary>
		protected override Fixture Fixture {
			get { return _fixture; }
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughCompiledCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareCompiledCodeOfSameCode(string orgPath) {
			base.CompareCompiledCodeOfSameCode(orgPath);
		}

		/// <summary>
		///   再生成を行わずVerifyCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareModelOfSameCode(string orgPath) {
			base.CompareModelOfSameCode(orgPath);
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void CompareCompiledCodeUsingCode(string code) {
			base.CompareCompiledCodeUsingCode(code);
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public override void CompareModelUsingCode(string code) {
			base.CompareModelUsingCode(code);
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "orgPath">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareCompiledCodeUsingFile(string orgPath) {
			base.CompareCompiledCodeUsingFile(orgPath);
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgPath">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareModelUsingFile(string orgPath) {
			base.CompareModelUsingFile(orgPath);
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "dirPath">テスト対象ソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">コンパイルのコマンド</param>
		/// <param name = "arguments">コマンドの引数</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void CompareCompiledCodeUsingProject(
				string dirPath, string command, string arguments) {
			base.CompareCompiledCodeUsingProject(dirPath, command, arguments);
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "dirPath">テスト対象ソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">コンパイルのコマンド</param>
		/// <param name = "arguments">コマンドの引数</param>
		[Test, TestCaseSource("TestProjectInfos")]
		public override void CompareModelUsingProject(
				string dirPath, string command, string arguments) {
			base.CompareModelUsingProject(dirPath, command, arguments);
		}
	}
}