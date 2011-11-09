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
using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGeneratos;
using Unicoen.Tests;

namespace Unicoen.Languages.Ruby18.Tests {
	public class Ruby18Fixture : Fixture {
		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".rb"; }
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string CompiledExtension {
			get { return ".rb"; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public override UnifiedProgramGenerator ProgramGenerator {
			get { return Ruby18ProgramGenerator.Instance; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override UnifiedCodeGenerator CodeGenerator {
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				return new[] {
						"a = 1",
				}.Select(s => new TestCaseData(s));
			}
		}

		public override IEnumerable<TestCaseData> TestFilePathes {
			get {
				return Directory.EnumerateFiles(FixtureUtil.GetInputPath(LanguageName), "*.rb", SearchOption.AllDirectories)
				    .Select(s => new TestCaseData(
				        FixtureUtil.GetInputPath(LanguageName, Path.GetFileName(s))));
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"block",
						"Block1",
						"Block2",
						"Block3",
						"Block4",
						"Fibonacci",
						"hierarchy",
						"prime",
						"ruby2ruby_test",
						"sjis",
						"student",
				}
						.Select(
								s =>
								new TestCaseData(FixtureUtil.GetInputPath(LanguageName, s + Extension)));
 }
		}

		public override IEnumerable<TestCaseData> TestProjectInfos {
			get { yield break; }
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { yield break; }
		}

		public override void Compile(string workPath, string srcPath) {
		}
	}
}