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

using System.IO;
using Unicoen.CodeGenerators;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.CSharp.CodeGenerators {
	public class CSharpCodeFactoryVisitor : JavaLikeCodeFactoryVisitor {

		public CSharpCodeFactoryVisitor(TextWriter writer, string indentSign)
				: base(writer, indentSign) {
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

		public override bool Visit(
				UnifiedStructDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "struct");
		}

		// e.g. Foo<T1, T2> where T1 : string
		public override bool Visit(
				UnifiedSet<UnifiedGenericParameter> element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(InequalitySignParen));
			foreach (var genericParameter in element) {
				if (genericParameter.Constrains != null) {
					foreach (var constrain in genericParameter.Constrains) {
						Writer.Write(" where ");
						genericParameter.Type.TryAccept(this, arg);
						constrain.TryAccept(this, arg.Set(ColonDelimiter));
					}
				}
			}
			return false;
		}

		// e.g. <T1, T2>
		public override bool Visit(
				UnifiedGenericParameter element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedSet<UnifiedTypeConstrain> element, VisitorArgument arg) {
			UnifiedTypeConstrain last = null;
			foreach (var current in element) {
				if (last == null) {
					current.TryAccept(this, arg.Set(NullDelimiter));
				} else {
					current.TryAccept(this, arg.Set(ColonDelimiter));
				}
				last = current;
			}
			return false;
		}

		public override bool Visit(
				UnifiedExtendConstrain element, VisitorArgument arg) {
			Writer.Write(arg.Decoration.Delimiter ?? " : ");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedImplementsConstrain element, VisitorArgument arg) {
			Writer.Write(arg.Decoration.Delimiter ?? " : ");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedConstructorConstrain element, VisitorArgument arg) {
			Writer.Write(" : new()");
			return false;
		}

		public override bool Visit(
				UnifiedClassConstrain element, VisitorArgument arg) {
			Writer.Write(" : class");
			return false;
		}

		public override bool Visit(
				UnifiedStructConstrain element, VisitorArgument arg) {
			Writer.Write(" : struct");
			return false;
		}

		#region literal suffix

		public override bool Visit(
				UnifiedBigIntLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(
				UnifiedUInt8Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("u");
			return false;
		}

		public override bool Visit(
				UnifiedUInt16Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("u");
			return false;
		}

		public override bool Visit(
				UnifiedUInt32Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("u");
			return false;
		}

		public override bool Visit(
				UnifiedUInt64Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("ul");
			return false;
		}

		public override bool Visit(
				UnifiedInt64Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("l");
			return false;
		}

		#endregion
	}
}