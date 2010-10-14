using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace OpenCodeProcessorFramework.Languages.Java
{
	public static class JavaElements
	{
		public static IEnumerable<XElement> Statement(XElement root)
		{
			return root.Descendants("statement");
		}

		public static IEnumerable<XElement> If(XElement root)
		{
			return root.Descendants("statement")
				.Where(e => e.FirstElement().Value == "if");
		}

		public static IEnumerable<XElement> IfAndElseProcesses(XElement root)
		{
			return root.Elements("statement");
		}

		public static IEnumerable<XElement> While(XElement root)
		{
			return root.Descendants("statement")
				.Where(e => e.FirstElement().Value == "while");
		}

		public static XElement WhileProcess(XElement element)
		{
			return element.ElementAt(2);
		}

		public static IEnumerable<XElement> DoWhile(XElement root)
		{
			return root.Descendants("statement")
				.Where(e => e.FirstElement().Value == "do");
		}

		public static XElement DoWhileProcess(XElement element)
		{
			return element.ElementAt(1);
		}

		public static IEnumerable<XElement> For(XElement root)
		{
			return root.Descendants("forstatement");
		}

		public static XElement ForProcess(XElement element)
		{
			return element.Element("statement");
		}
	}
}
