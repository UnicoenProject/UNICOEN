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
using System.Text;
using Paraiba.Text;
using Unicoen.CodeGenerators;
using Unicoen.Model;

namespace Unicoen.ProgramGenerators {
    public abstract class UnifiedProgramGenerator {
        /// <summary>
        ///   解析対象の言語のソースコードの拡張子を取得します．
        /// </summary>
        public abstract IEnumerable<string> Extensions { get; }

        /// <summary>
        ///   解析対象の言語のソースコードのコード生成器を取得します．
        /// </summary>
        public abstract UnifiedCodeGenerator CodeGenerator { get; }

        public abstract UnifiedProgram GenerateWithoutNormalizing(string code);

        public virtual UnifiedProgram GenerateFromFile(
                string filePath, Encoding encoding) {
            var code = File.ReadAllText(filePath, encoding);
            return Generate(code);
        }

        public virtual UnifiedProgram GenerateFromFile(string filePath) {
            var code = GuessEncoding.ReadAllText(filePath);
            return Generate(code);
        }

        public UnifiedProgram Generate(string code) {
            if (string.IsNullOrWhiteSpace(code)) {
                return UnifiedProgram.Create(UnifiedBlock.Create());
            }
            var model = GenerateWithoutNormalizing(code);
            model.Normalize();
            return model;
        }
    }
}