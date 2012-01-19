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

using Unicoen.Languages.CSharp.CodeGenerators;
using Unicoen.Languages.CSharp.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Languages.CSharp {
    public static class CSharpFactory {
        public static readonly CSharpCodeGenerator CodeGenerator;
        public static readonly CSharpProgramGenerator ProgramGenerator;

        static CSharpFactory() {
            CodeGenerator = new CSharpCodeGenerator();
            ProgramGenerator = new CSharpProgramGenerator();
        }

        public static string GenerateCode(IUnifiedElement model) {
            return CodeGenerator.Generate(model);
        }

        public static UnifiedProgram GenerateModel(string code) {
            return ProgramGenerator.Generate(code);
        }
    }
}