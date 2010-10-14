using System;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace Ucpf.Languages.Tests.Temp
{
	public static class SemanticAnalyzer
	{
		public static JavaStatement Statement(XElement statement)
		{
			if (statement == null)
				return null;
			var first = statement.FirstElement();

			switch (first.Name.LocalName) {
			case "expression":
				return new JavaExpressionStatement(statement);
			}

			switch (first.Value) {
			case "if":
				return new JavaIfStatement(statement);
			}

			return new JavaStatement(statement);
		}

		public static JavaIfStatement IfStatement()
		{
			throw new NotImplementedException();
		}
	}
}