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
using Code2Xml.Languages.Ruby18.CodeToXmls;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.Ruby18.Model {
	public class Ruby18ModelFactory : ModelFactory {
		public static Ruby18ModelFactory Instance = new Ruby18ModelFactory();

		public override IEnumerable<string> Extensions {
			get { return Ruby18CodeToXml.Instance.TargetExtensions; }
		}

		public override UnifiedProgram GenerateWithouNormalizing(string code) {
			var ast = Ruby18CodeToXml.Instance.Generate(code, true);
			return Ruby18ModelFactoryHelper.CreateProgram(ast);
		}
	}
}