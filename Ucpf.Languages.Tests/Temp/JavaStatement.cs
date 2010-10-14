using System.Xml.Linq;

namespace Ucpf.Languages.Tests.Temp
{
	public class JavaStatement
	{
		private readonly XElement _node;

		public JavaStatement(XElement node)
		{
			_node = node;
		}

		public XElement Node
		{
			get { return _node; }
		}

		public string Code
		{
			get { return Node.Value; }
		}
	}
}