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
using Unicoen.Core.Model;

namespace Unicoen.Core.Processor {
	internal class CodeFactoryHelper {
		internal static string Generate(ICodeFactory factory, IUnifiedElement model) {
			var writer = new StringWriter();
			factory.Generate(model, writer);
			return writer.ToString();
		}

		internal static string GenerateOrEmpty(
				ICodeFactory factory, IUnifiedElement model) {
			if (model == null)
				return string.Empty;
			var writer = new StringWriter();
			factory.Generate(model, writer);
			return writer.ToString();
		}
	}

	public interface ICodeFactory {
		void Generate(
				IUnifiedElement model, TextWriter writer, string indentSign);

		void Generate(IUnifiedElement model, TextWriter writer);
		string Generate(IUnifiedElement model);
		string GenerateOrEmpty(IUnifiedElement model);
	}

	public abstract class CodeFactory : ICodeFactory {
		public abstract void Generate(
				IUnifiedElement model, TextWriter writer, string indentSign);

		public abstract void Generate(IUnifiedElement model, TextWriter writer);

		public string Generate(IUnifiedElement model) {
			return CodeFactoryHelper.Generate(this, model);
		}

		public string GenerateOrEmpty(IUnifiedElement model) {
			return CodeFactoryHelper.GenerateOrEmpty(this, model);
		}
	}

	public abstract class CodeFactoryWithVisitor
			: ExplicitDefaultUnifiedVisitor<bool, VisitorArgument>, ICodeFactory {
		public abstract void Generate(
				IUnifiedElement model, TextWriter writer, string indentSign);

		public abstract void Generate(IUnifiedElement model, TextWriter writer);

		public string Generate(IUnifiedElement model) {
			return CodeFactoryHelper.Generate(this, model);
		}

		public string GenerateOrEmpty(IUnifiedElement model) {
			return CodeFactoryHelper.GenerateOrEmpty(this, model);
		}
			}
}