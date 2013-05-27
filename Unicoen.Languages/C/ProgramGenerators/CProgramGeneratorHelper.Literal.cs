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
using System.Numerics;
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
            var result = NumberParser.ParseHexicalBigInteger(node.Value.Substring(2));
            return CreateIntegerLiteral(node, result);
        }

        public static UnifiedIntegerLiteral CreateOctalLiteral(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "OCTAL_LITERAL");
            /*
			 * OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;
			 */
            var result = NumberParser.ParseOcatleBigInteger(node.Value.Substring(1));
            return CreateIntegerLiteral(node, result);
        }

        public static UnifiedIntegerLiteral CreateDecimalLiteral(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "DECIMAL_LITERAL");
            /*
			 * DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;
			 */
            var result = NumberParser.ParseBigInteger(node.Value);
            return CreateIntegerLiteral(node, result);
        }

        public static UnifiedLiteral CreateCharacterLiteral(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "CHARACTER_LITERAL");
            /*
			 * CHARACTER_LITERAL
			 * :   '\'' ( EscapeSequence | ~('\''|'\\') ) '\'' ;
			 */
            return UnifiedCharLiteral.Create(node.Value);
        }

        public static UnifiedLiteral CreateStringLiteral(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "STRING_LITERAL");
            /*
			 * STRING_LITERAL
			 * :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'	;
			 */
            return UnifiedStringLiteral.Create(node.Value);
        }

        public static UnifiedExpression CreateFloatingPointLiteral(
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
            return CreateFloatLiteral(node, double.Parse(node.Value));
        }

        private static UnifiedIntegerLiteral CreateIntegerLiteral(XElement node, BigInteger integer) {
            var type = node.LastElement();
            if (type.Name() == "IntegerTypeSuffix") {
                switch (type.Value.ToLower()) {
                case "u":
                    return UnifiedIntegerLiteral.CreateUInt32(integer);
                case "ul":
                    return UnifiedIntegerLiteral.CreateUInt32(integer);
                case "ull":
                    return UnifiedIntegerLiteral.CreateUInt64(integer);
                case "l":
                    return UnifiedIntegerLiteral.CreateInt32(integer);
                case "lu":
                    return UnifiedIntegerLiteral.CreateUInt32(integer);
                case "ll":
                    return UnifiedIntegerLiteral.CreateInt64(integer);
                case "llu":
                    return UnifiedIntegerLiteral.CreateUInt64(integer);
                default:
                    throw new InvalidOperationException();
                }
            }
            return UnifiedIntegerLiteral.CreateInt32(integer);
        }

        private static UnifiedFractionLiteral CreateFloatLiteral(XElement node, double number) {
            var type = node.LastElement();
            if (type.Name() == "FloatTypeSuffix") {
                switch (type.Value.ToLower()) {
                case "f":
                    return UnifiedFractionLiteral.Create(number, UnifiedFractionLiteralKind.Single);
                case "l":
                    return UnifiedFractionLiteral.Create(number,
                            UnifiedFractionLiteralKind.Double80);
                default:
                    throw new InvalidOperationException();
                }
            }
            return UnifiedFractionLiteral.Create(number, UnifiedFractionLiteralKind.Double);
        }
    }
}