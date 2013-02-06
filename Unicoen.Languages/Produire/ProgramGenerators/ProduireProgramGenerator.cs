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
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using Produire;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

namespace Unicoen.Languages.Produire.ProgramGenerators {
    [Export(typeof(UnifiedProgramGenerator))]
    public class ProduireProgramGenerator : UnifiedProgramGenerator {

	    private static readonly string[] _extensions = new[] { "rdr" };

        public override IEnumerable<string> Extensions {
            get { return _extensions; }
        }

        public override UnifiedCodeGenerator CodeGenerator {
            get { return JavaFactory.CodeGenerator; }
        }

        public override UnifiedProgram GenerateWithoutNormalizing(string code) {
			File.WriteAllText("tmp.rdr", code, Encoding.UTF8);
            var ast = ProduireFile.Load("tmp.rdr");
            return ProduireProgramGeneratorHelper.CreateProgram(ast);
        }
    }
}