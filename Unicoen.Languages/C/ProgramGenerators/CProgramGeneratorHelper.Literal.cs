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

using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Unicoen.Model;
using Unicoen.Processor;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ProgramGenerators {
	public static partial class CProgramGeneratorHelper {
		// literals
		public static UnifiedIntegerLiteral CreateHexLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "HEX_LITERAL");
			/*
			 * HEX_LITERAL : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;
			 */
			var result =
					LiteralFuzzyParser.ParseHexicalBigInteger(
							node.Value.Substring(2));
			return UnifiedIntegerLiteral.CreateInt32(result);
		}

		public static UnifiedIntegerLiteral CreateOctalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "OCTAL_LITERAL");
			/*
			 * OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;
			 */
			var result =
					LiteralFuzzyParser.ParseOcatleBigInteger(
							node.Value.Substring(1));
			return UnifiedIntegerLiteral.CreateInt32(result);
		}

		public static UnifiedIntegerLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "DECIMAL_LITERAL");
			/*
			 * DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;
			 */
			var result = LiteralFuzzyParser.ParseBigInteger(node.Value);
			return UnifiedIntegerLiteral.CreateInt32(result);
		}

		public static UnifiedLiteral CreateCharacterLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "CHARACTER_LITERAL");
			/*
			 * CHARACTER_LITERAL
			 * :   '\'' ( EscapeSequence | ~('\''|'\\') ) '\'' ;
			 */
			// TODO シングルクォーテーションの中だけ取得するのか確認
			return
					UnifiedCharLiteral.Create(
							node.Value.Substring(1, node.Value.Length - 2));
		}

		public static UnifiedLiteral CreateStringLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "STRING_LITERAL");
			/*
			 * STRING_LITERAL
			 * :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'	;
			 */
			// TODO ダブルクォーテーションの中だけ取得するのか確認
			return
					UnifiedStringLiteral.Create(
							node.Value.Substring(1, node.Value.Length - 2));
		}

		public static IUnifiedExpression CreateFloatingPointLiteral(
				XElement node) {
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
			// TODO UnifiedFractionLiteralKind.Doubleはダブルで大丈夫か？
			return UnifiedFractionLiteral.Create(
					double.Parse(node.Value), UnifiedFractionLiteralKind.Double);
		}
	}
}