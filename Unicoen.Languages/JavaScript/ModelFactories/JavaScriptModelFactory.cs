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

using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.JavaScript.ModelFactories {
	public class JavaScriptModelFactory : ModelFactory {
		public static JavaScriptModelFactory Instance = new JavaScriptModelFactory();

		public override UnifiedProgram GenerateWithouNormalizing(string code) {
			var ast = JavaScriptCodeToXml.Instance.Generate(code, true);
			return JavaScriptModelFactoryHelper.CreateProgram(ast);
		}
	}
}