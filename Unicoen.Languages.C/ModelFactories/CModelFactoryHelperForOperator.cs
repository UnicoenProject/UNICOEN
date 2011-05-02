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
		// Operator
		public static IUnifiedElement CreateUnaryOperator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unary_operator");
			/*
			unary_operator
			: '&'
			| '*'
			| '+'
			| '-'
			| '~'
			| '!'
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignmentOperator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_operator");
			/*
			assignment_operator
			: '='
			| '*='
			| '/='
			| '%='
			| '+='
			| '-='
			| '<<='
			| '>>='
			| '&='
			| '^='
			| '|='
			 */

			throw new NotImplementedException(); //TODO: implement
		}
	}
}
