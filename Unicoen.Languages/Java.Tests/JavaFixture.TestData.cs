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
using NUnit.Framework;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Languages.Java.Tests {
    /// <summary>
    ///   テストに必要なデータを提供します．
    /// </summary>
    public partial class JavaFixture : Fixture {
        /// <summary>
        ///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。 Java言語であれば， <c>class A { public void M1() { ... } }</c> の...部分に このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
        /// </summary>
        public override IEnumerable<TestCaseData> TestCodes {
            get {
                var statements = new[] {
                        "double MAX_VALUE = 0x1.fffffffffffffP+1023; // 1.7976931348623157e+308"
                        ,
                        "double MIN_NORMAL = 0x1.0p-1022; // 2.2250738585072014E-308"
                        ,
                        "double MIN_VALUE = 0x0.0000000000001P-1022; // 4.9e-324"
                        , // 4.94065645841247E-324
                        "M1();",
                        "new A();",
                        "int[] a[][] = new int[1][1][1]; System.out.println(a);"
                        ,
                        "int[] a[] = new int[10][10], b[][] = new int[10][10][10];"
                        ,
                        "int i; for (i = 0; i < 0; i++) System.out.println(1);",
                        "Integer i; if ((i = 0).toString() != null) { }",
                        "int mask = 0x80000000;",
                        "System.out.println(0x1E.ep0); System.out.println(0x1E.eP+1);"
                        ,
                }.Select(s => new TestCaseData(DecorateToCompile(s)));

                var codes = new[] {
                        "class A { void execute(String ... str) { } }",
                        "class A { public @interface M1 { String value(); } }",
                        "class A { void m() { for (final int a = 0, b = 1; ; ) System.out.println(a + b); } }"
                        ,
                        "import java.util.List;",
                        "class A { int a = 0; }",
                }.Select(s => new TestCaseData(s));

                return statements.Concat(codes);
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
                }
                        .Select(
                                s =>
                                FixtureUtil.GetInputPath(
                                        LanguageName, s + Extension))
                        .Select(s => new TestCaseData(s));
            }
        }

        /// <summary>
        ///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
        /// </summary>
        public override IEnumerable<TestCaseData> TestProjectInfos {
            get {
                const string cmd = CompileCommand;
                const string args = "*.java";
                return new[] {
                        new {
                                DirName = "default", Command = cmd,
                                Arguments = args
                        },
                        new {
                                DirName = "NewTestFiles", Command = cmd,
                                Arguments = args
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
                        .Concat(SetUpJUnit())
                        //.Concat(SetUpCraftBukkit())
                        .Concat(SetUpBukkit())
                        .Concat(SetUpGameOfLife())
                        .Concat(SetUpJedis())
                        .Concat(SetUpZoie())
                        ;
            }
        }

        public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
            get {
                return SetUpJdk()
                        .Concat(SetUpJenkins())
                        ;
            }
        }

    }
}