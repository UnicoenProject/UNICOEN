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
using Unicoen.CodeGenerators;
using Unicoen.Languages.Tests;
using Unicoen.ProgramGenerators;
using Unicoen.Tests;

namespace Unicoen.Languages.C.Tests {
    public partial class CFixture : Fixture {
        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string Extension {
            get { return ".c"; }
        }

        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string CompiledExtension {
            get { return ".exe"; }
        }

        /// <summary>
        ///   対応する言語のモデル生成器を取得します．
        /// </summary>
        public override UnifiedProgramGenerator ProgramGenerator {
            get { return CFactory.ProgramGenerator; }
        }

        /// <summary>
        ///   対応する言語のコード生成器を取得します．
        /// </summary>
        public override UnifiedCodeGenerator CodeGenerator {
            get { return CFactory.CodeGenerator; }
        }

        private static string DecorateToCompile(string statement) {
            return "int main() {" + statement + "}";
        }

        /// <summary>
        ///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
        /// </summary>
        /// <param name="workPath"> コンパイル対象のソースコードが格納されているディレクトリのパス </param>
        /// <param name="srcPath"> コンパイル対象のソースコードのファイル名 </param>
        public override void Compile(string workPath, string srcPath) {}

        /// <summary>
        ///   セマンティクスの変化がないか比較するためにソースコードを指定したコマンドと引数でコンパイルします．
        /// </summary>
        /// <param name="workPath"> コマンドを実行する作業ディレクトリのパス </param>
        /// <param name="command"> コンパイルのコマンド </param>
        /// <param name="arguments"> コマンドの引数 </param>
        public override void CompileWithArguments(
                string workPath, string command, string arguments) {}
    }
}