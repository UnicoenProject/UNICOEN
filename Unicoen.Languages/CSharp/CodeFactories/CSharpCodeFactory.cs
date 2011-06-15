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
using System.IO;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.CSharp.CodeFactories {
	public class CSharpCodeFactory : CodeFactory {
		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}

		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			return Generate(model, writer, new CSharpCodeStyle { Indent = indentSign });

		}

		public string Generate(IUnifiedElement model, TextWriter writer, CSharpCodeStyle style) {
			var visitor = new CSharpCodeFactoryVisitor(style);
			model.Accept(visitor);
			return writer.ToString();
		}
	}
}