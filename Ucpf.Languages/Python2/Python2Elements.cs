using System.Collections.Generic;
using System.Xml.Linq;

namespace OpenCodeProcessorFramework.Languages.Python2
{
	public static class Python2Elements
	{
		// withはusingのようなもの．Loneパターン．

		public static IEnumerable<XElement> If(XElement root)
		{
			return root.Descendants("if_stmt");
		}

		public static IEnumerable<XElement> IfAndElseProcesses(XElement root)
		{
			return root.Elements("suite");
		}

		public static IEnumerable<XElement> While(XElement root)
		{
			return root.Descendants("while_stmt");
		}

		public static IEnumerable<XElement> WhileAndElseProcesses(XElement root)
		{
			return root.Elements("suite");
		}

		public static IEnumerable<XElement> For(XElement root)
		{
			return root.Descendants("for_stmt");
		}

		public static IEnumerable<XElement> ForAndElseProcesses(XElement root)
		{
			return root.Elements("suite");
		}
	}
}
