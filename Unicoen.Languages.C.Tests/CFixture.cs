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
using System.Linq;
using NUnit.Framework;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.ModelFactories;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.C.Tests {
	public class CFixture : Fixture {
		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".c"; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public override ModelFactory ModelFactory {
			get { return CFactory.ModelFactory; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override CodeFactory CodeFactory {
			get { return CFactory.CodeFactory; }
		}

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				var statements = new[] {
						"{ main(); }",
				}.Select(s => new TestCaseData(DecorateToCompile(s)));

				var codes = new[] {
						"int main() { return 0; }",
				}.Select(s => new TestCaseData(s));

				return statements.Concat(codes);
			}
		}

		private static string DecorateToCompile(string statement) {
			return "int main() {" + statement + "} }";
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"Fibonacci",
				}
						.Select(
								s =>
								new TestCaseData(FixtureUtil.GetInputPath("C", s + Extension)));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイルのコマンドの組み合わせの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestDirectoryPathes {
			get {
				yield break;
				//				return new[] {
				//						new { DirName = "default", Command = "javac", Arguments = "*.java" },
				//						new { DirName = "NewTestFiles", Command = "javac", Arguments = "*.java" },
				//				}
				//						.Select(
				//								o => new TestCaseData(
				//								     		Fixture.GetInputPath("Java", o.DirName),
				//								     		o.Command, o.Arguments));
			}
		}

		public override void Compile(string workPath, string fileName) {}

		public override IEnumerable<object[]> GetAllCompiledCode(string workPath) {
			return null;
		}

		public override void CompileWithArguments(
				string workPath, string command, string arguments) {}
	}
}