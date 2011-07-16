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

using System.IO;
using Unicoen.Model;

namespace Unicoen.CodeFactories {
	public abstract class CodeFactory {
		public abstract void Generate(
				IUnifiedElement codeObject, TextWriter writer, string indentSign);

		public abstract void Generate(IUnifiedElement codeObject, TextWriter writer);

		public string Generate(IUnifiedElement codeObject) {
			var writer = new StringWriter();
			Generate(codeObject, writer);
			return writer.ToString();
		}

		public string GenerateOrEmpty(IUnifiedElement model) {
			if (model == null)
				return string.Empty;
			var writer = new StringWriter();
			Generate(model, writer);
			return writer.ToString();
		}
	}
}