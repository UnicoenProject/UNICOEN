﻿#region License

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
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.CodeGenerators;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

namespace Unicoen.Languages.JavaScript.ProgramGenerators {
	[Export(typeof(UnifiedProgramGenerator))]
	public class JavaScriptProgramGenerator : UnifiedProgramGenerator {
		public static JavaScriptProgramGenerator Instance = new JavaScriptProgramGenerator();

		public override IEnumerable<string> Extensions {
			get { return JavaScriptCodeToXml.Instance.TargetExtensions; }
		}

		public override UnifiedCodeGenerator CodeGenerator {
			get { return JavaScriptFactory.CodeGenerator; }
		}

		public override UnifiedProgram GenerateWithoutNormalizing(string code) {
			var ast = JavaScriptCodeToXml.Instance.Generate(code, true);
			return JavaScriptProgramGeneratorHelper.CreateProgram(ast);
		}
	}
}