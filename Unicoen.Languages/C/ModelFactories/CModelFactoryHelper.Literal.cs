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
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using UniUni.Xml.Linq;
using Unicoen.Core.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ModelFactories {
	public static partial class CModelFactoryHelper {
		// literals
		public static UnifiedLiteral CreateHexLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "HEX_LITERAL");
			/*
			 * HEX_LITERAL : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedLiteral CreateOctalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "OCTAL_LITERAL");
			/*
			 * OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "DECIMAL_LITERAL");
			/*
			 * DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;
			 */
			if (node.Element("IntegerTypeSuffix") != null) {
				throw new NotImplementedException(); //TODO: implement
			}
			return UnifiedIntegerLiteral.Create(int.Parse(node.Value),
				UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedLiteral CreateCharacterLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "CHARACTER_LITERAL");
			/*
			 * CHARACTER_LITERAL
			 * :   '\'' ( EscapeSequence | ~('\''|'\\') ) '\'' ;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedLiteral CreateStringLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "STRING_LITERAL");
			/*
			 * STRING_LITERAL
			 * :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'	;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateFloatingPointLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "FLOATING_POINT_LITERAL");
			/*
			 * FLOATING_POINT_LITERAL
			 * :   ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
			 * |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
			 * |   ('0'..'9')+ Exponent FloatTypeSuffix?
			 * |   ('0'..'9')+ Exponent? FloatTypeSuffix
			 * ;
			 */

			throw new NotImplementedException(); //TODO: implement
		}
	}
}