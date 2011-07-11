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
using Unicoen.CodeFactories;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.CSharp.CodeFactories {
	public class CSharpCodeFactoryVisitor : JavaLikeCodeFactoryVisitor {
		public CSharpCodeFactoryVisitor(TextWriter writer) : base(writer) {
			ForeachKeyword = "foreach";
			ForeachDelimiter = " in ";
			ImportKeyword = "using ";
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			Writer.Write(" ");
			element.Name.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Throws.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		public override bool Visit(UnifiedLambda element, VisitorArgument arg) {
			element.Parameters.TryAccept(this, arg);
			Writer.Write(" => ");
			element.Body.Accept(this, arg);
			return true;
		}

		public override bool Visit(
				UnifiedNamespaceDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			Writer.Write("namespace ");
			element.Name.Accept(this, arg);
			Writer.Write(" ");
			element.Body.Accept(this, arg.Set(ForBlock));
			return false;
		}
	}
}