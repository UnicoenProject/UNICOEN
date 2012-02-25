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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Java.Tests;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.Tests;
using Unicoen.Utils;

namespace Unicoen.Languages.JavaScript.Tests {
    public partial class JavaScriptFixture : Fixture {

        /// <summary>
        ///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
        /// </summary>
        public override IEnumerable<TestCaseData> TestCodes {
            get {
                return new[] {
                        "a = 1;",
                        "var a = 1;",
                        "for ( i = 0, length = args.length; i < length; i++ ) { }"
                        ,
                        "a = \"1\" + (1 + 2) + \"2\""
                }.Select(s => new TestCaseData(s));
            }
        }

        /// <summary>
        ///   テスト時に入力するファイルパスの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestFilePaths {
            get {
                // 必要に応じて以下の要素をコメントアウト
                return new[] {
                        //"fibonacci",
                        //"student",
                        "src",
                }
                        .Select(
                                s =>
                                new TestCaseData(
                                        FixtureUtil.GetInputPath(
                                                LanguageName, s + Extension)));
            }
        }

        /// <summary>
        ///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestProjectInfos {
            get {
                var arguments = string.Join(" ", _compileArguments) + " *.js";
                return new[] {
                        new {
                                DirName = "Blocks",
                                Command = CompileCommand,
                                Arguments = arguments,
                        },
                        new {
                                DirName = "Waseda",
                                Command = CompileCommand,
                                Arguments = arguments,
                        },
                }
                        .Select(
                                o => {
                                    Action<string, string> action =
                                            (s1, s2) =>
                                            CompileWithArguments(
                                                    s1, o.Command, o.Arguments);
                                    return
                                            new TestCaseData(
                                                    FixtureUtil.GetInputPath(
                                                            LanguageName,
                                                            o.DirName), action);
                                })
                        .Concat(SetUpjQuery())
                        .Concat(SetUpjQueryMin())
                        .Concat(SetUpProcessing_js())
                        .Concat(SetUpProcessing_jsApi())
                        .Concat(SetUpProcessing_jsApiMin())
                        .Concat(SetUpProcessing_jsMin())
                        .Concat(SetUpDojo())
                        .Concat(SetUpDojoMin())
                        .Concat(SetUpPlay())
                        .Concat(SetUpAIChallenge());
            }
        }

        public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
            get { yield break; }
        }
    }
}