using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace Ucpf.Languages.Tests.Temp
{
	public class JavaPointcut
	{
		public IEnumerable<XElement> StatementElements(XElement root)
		{
			return root.Descendants("statement");
		}

		public IEnumerable<XElement> IfStatementElements(XElement root)
		{
			return StatementElements(root)
				.Where(e => e.FirstElement().Value == "if");
		}

		public IEnumerable<JavaStatement> Statements(XElement root)
		{
			return StatementElements(root)
				.Select(e => new JavaStatement(e));
		}

		public IEnumerable<JavaIfStatement> IfStatements(XElement root)
		{
			return IfStatementElements(root)
				.Select(e => new JavaIfStatement(e));
		}
	}
}