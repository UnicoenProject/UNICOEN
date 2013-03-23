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

using Unicoen.Languages.Python2.CodeGenerators;
using Unicoen.Languages.Python2.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Languages.Python2 {
    public static class Python2Factory {
        public static readonly Python2CodeGenerator CodeGenerator;
        public static readonly Python2ProgramGenerator ProgramGenerator;

        static Python2Factory() {
            CodeGenerator = new Python2CodeGenerator();
            ProgramGenerator = new Python2ProgramGenerator();
        }

        public static string GenerateCode(UnifiedElement model) {
            return CodeGenerator.Generate(model);
        }

        public static UnifiedProgram GenerateModel(string code) {
            return ProgramGenerator.Generate(code);
        }
    }
}