using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Code2Xml.Languages.C.CodeToXmls;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.C.ModelFactories
{
	public static partial class CModelFactoryHelper
	{
		// literals
		public static IUnifiedElement CreateHexLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "hex_literal");
			/*
			 * hex_literal
			 * : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOctalLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "octal_literal");
			/*
			 * octal_literal: '0' ('0'..'7')+ IntegerTypeSuffix?
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDecimalLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decimal_literal");
			/*
			 * decimal_literal
			 * : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix?
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCharacterLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "character_literal");
			/*
			 * character_literal
			 * : '\'' ( EscapeSequence | ~('\''|'\\') ) '\''
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStringLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "string_literal");
			/*
			 * string_literal
			 * : '"' ( EscapeSequence | ~('\\'|'"') )* '"'
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFloatingPointLiteral(XElement node)
		{
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
