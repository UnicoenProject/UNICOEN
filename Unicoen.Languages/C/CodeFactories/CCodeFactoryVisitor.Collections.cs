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
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactoryVisitor {
		public override bool Visit(UnifiedVariableDefinitionList element, VisitorArgument arg) {

			foreach (var variableDefinition in element) {
				Writer.Write(variableDefinition.Modifiers.TryAccept(this, arg));
				Writer.Write(" ");
				Writer.Write(variableDefinition.Type.TryAccept(this, arg));
				Writer.Write(" ");
				Writer.Write(variableDefinition.Name.TryAccept(this, arg));

				if (variableDefinition.InitialValue != null) {
					Writer.Write( " = ");
					Writer.Write(variableDefinition.InitialValue);
				}
				Writer.WriteLine(";");
			}

			return true;
		}

		public override bool Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			throw new InvalidOperationException();
		}

		public override bool Visit(
				UnifiedGenericArgumentCollection element, VisitorArgument arg) {
			Writer.WriteLine("/* ElementNotInC */");
			Writer.WriteLine("/* " + element + " */");
			return false;
		}

		public override bool Visit(UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				WriteIndent(arg);
				caseElement.TryAccept(this, arg);
			}

			return false;
		}

		public override bool Visit(UnifiedThrowsTypeCollection element, VisitorArgument arg) {
			Writer.WriteLine("/* ElementNotInC */");
			Writer.WriteLine("/* " + element + " */");
			return false;
		}

		public override bool Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			Writer.WriteLine("/* ElementNotInC */");
			Writer.WriteLine("/* " + element + " */");
			return false;
		}

		public override bool Visit(
				UnifiedGenericParameterCollection element, VisitorArgument arg) {
			Writer.WriteLine("/* ElementNotInC */");
			Writer.WriteLine("/* " + element + " */");
			return false;
		}

		public override bool Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			Writer.WriteLine("/* ElementNotInC */");
			Writer.WriteLine("/* " + element + " */");
			return false;
		}

		public override bool Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			// 親要素が処理するので辿りついてはいけない
			throw new InvalidOperationException();
		}

		public override bool Visit(UnifiedSimpleType element, VisitorArgument arg) {
			element.BasicType.TryAccept(this, arg);
			return true;
		}


	}
}