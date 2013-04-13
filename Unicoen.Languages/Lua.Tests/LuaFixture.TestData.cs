using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unicoen.TestUtils;

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

namespace Unicoen.Languages.Lua.Tests {
    /// <summary>
    ///   テストに必要なデータを提供します．
    /// </summary>
    public partial class LuaFixture {
        /// <summary>
        /// テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 
        /// Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に
        /// このプロパティで指定されたコード断片を埋め込んでA.Luaファイルが生成されます。
        /// </summary>
        public override IEnumerable<TestCaseData> TestCodes {
            get {
                var codes = new[] {
                        "a = 1",
                }.Select(s => new TestCaseData(s));

                return codes;
            }
        }

        /// <summary>
        /// テスト時に入力するファイルパスの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestFilePaths {
            get {
                // 必要に応じて以下の要素をコメントアウト
                return new[] {
                        "Block1",
                        "Block2",
                        "Block3",
                }
                        .Select(
                                s =>
                                        FixtureUtil.GetInputPath(
                                                LanguageName, s + Extension))
                        .Select(s => new TestCaseData(s));
            }
        }

        /// <summary>
        /// テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestProjectInfos {
            get {
                const string cmd = "";
                const string args = "*.Lua";
                return new[] {
                        new {
                                DirName = "UNICOEN", Command = cmd,
                                Arguments = args
                        },
                }
                        .Select(
                                o => {
                                    Action<string> action =
                                            workPath =>
                                                    CompileWithArguments(
                                                            workPath, o.Command, o.Arguments);
                                    return
                                            new TestCaseData(
                                                    FixtureUtil.GetInputPath(
                                                            LanguageName,
                                                            o.DirName), new[] { "." }, action);
                                })
                        ;
            }
        }

        public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
            get { yield break; }
        }
    }
}