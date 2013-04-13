using Unicoen.CodeGenerators;
using Unicoen.ProgramGenerators;

#region License

// Copyright (C) 2011-2013 The Unicoen Project
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

using Unicoen.Languages.Tests;

namespace Unicoen.Languages.Lua.Tests {
    /// <summary>
    ///   テストに必要なデータを提供します．
    /// </summary>
    public partial class LuaFixture : Fixture {
        public LuaFixture() {}

        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string Extension {
            get { return ".lua"; }
        }

        /// <summary>
        ///   対応する言語のソースコードの拡張子を取得します．
        /// </summary>
        public override string CompiledExtension {
            get { return ".lua"; }
        }

        /// <summary>
        ///   対応する言語のモデル生成器を取得します．
        /// </summary>
        public override UnifiedProgramGenerator ProgramGenerator {
            get { return LuaFactory.ProgramGenerator; }
        }

        /// <summary>
        ///   対応する言語のコード生成器を取得します．
        /// </summary>
        public override UnifiedCodeGenerator CodeGenerator {
            get { return LuaFactory.CodeGenerator; }
        }

        /// <summary>
        ///   指定したファイルのソースコードをデフォルトの設定でコンパイルします．
        /// </summary>
        /// <param name="workPath"> コンパイル時の作業ディレクトリのパス </param>
        /// <param name="srcPath"> コンパイル対象のソースコードのパス </param>
        public override void Compile(string workPath, string srcPath) {}

        /// <summary>
        ///   コンパイル済みのコードのバイト列を取得します．
        /// </summary>
        /// <param name="rootPath">コンパイル済みコードのルートディレクトリ</param>
        /// <param name="path"> コンパイル済みコードのパス </param>
        /// <returns> コンパイル済みのコードのバイト列 </returns>
        public override object GetCompiledByteCode(string rootPath, string path) {
            return null;
        }
    }
}