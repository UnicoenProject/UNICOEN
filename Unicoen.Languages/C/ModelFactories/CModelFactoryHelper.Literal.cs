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
		public static IUnifiedElement CreateHexLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "hex_literal");
			/*
			 * hex_literal
			 * : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOctalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "octal_literal");
			/*
			 * octal_literal: '0' ('0'..'7')+ IntegerTypeSuffix?
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDecimalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decimal_literal");
			/*
			 * decimal_literal
			 * : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix?
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCharacterLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "character_literal");
			/*
			 * character_literal
			 * : '\'' ( EscapeSequence | ~('\''|'\\') ) '\''
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStringLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "string_literal");
			/*
			 * string_literal
			 * : '"' ( EscapeSequence | ~('\\'|'"') )* '"'
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFloatingPointLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "floating_point_literal");
			/*
			 * floating_point_literal
			 * :   ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
			 * |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
			 * |   ('0'..'9')+ Exponent FloatTypeSuffix?
			 * |   ('0'..'9')+ Exponent? FloatTypeSuffix
			 */

			throw new NotImplementedException(); //TODO: implement
		}
	}
}