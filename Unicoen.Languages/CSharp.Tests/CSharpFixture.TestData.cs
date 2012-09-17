#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using System.Linq;
using NUnit.Framework;
using Unicoen.TestUtils;

namespace Unicoen.Languages.CSharp.Tests {
	public partial class CSharpFixture {
		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				var result = Enumerable.Empty<TestCaseData>();
				//result = result.Concat(new[] {
				//        "M1();",
				//        "new A();",
				//}.Select(s => new TestCaseData(DecorateToCompile(s))));

				result = result.Concat(new[] {
						//"class A { }",
						//"public class A { }",
						"public class A { } public class B<T : A> { }",
						"public class A { public event KeyboadEventHandler OnKeyDown; }",
				}.Select(s => new TestCaseData(s)));

				return result;
			}
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePaths {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"Fibonacci",
						"Student",
						"Block1",
						"Block2",
						"Block3",
						"Binary",
						"TypeConstraint",
				}
						.Select(
								s =>
								new TestCaseData(
										FixtureUtil.GetInputPath(
												"CSharp", s + Extension)));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestProjectInfos {
			get { return SetUpUnicoen().Concat(SetUpKurogane()); }
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { yield break; }
		}

		private IEnumerable<TestCaseData> SetUpKurogane() {
			Action<string> compileAction = workDirPath => { };
			return SetUpTestCaseData(
					"Kurogane",
					path =>
					DownloadAndUnzip(
							"https://github.com/irxground/kurogane/zipball/master",
							path),
					compileAction);
		}

		public IEnumerable<TestCaseData> SetUpUnicoen() {
			Action<string> compileActionWithWorkDirPath = workDirPath => { };
			//yield return new TestCaseData(Path.Combine(FixtureUtil.RootPath, "Unicoen.Apps"), compileActionWithWorkDirPath);
			yield return
					new TestCaseData(
							Path.Combine(FixtureUtil.RootPath, "Unicoen.Core"),
							compileActionWithWorkDirPath);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.Core.Tests"),
//							compileActionWithWorkDirPath);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.Languages"),
//							compileActionWithWorkDirPath);
//			yield return
//					new TestCaseData(
//							Path.Combine(FixtureUtil.RootPath, "Unicoen.Utils"),
//							compileActionWithWorkDirPath);
//			yield return
//					new TestCaseData(
//							Path.Combine(
//									FixtureUtil.RootPath, "Unicoen.WebApps"),
//							compileActionWithWorkDirPath);
		}
	}
}