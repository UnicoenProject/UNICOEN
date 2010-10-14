using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace Ucpf.Languages.Tests.Temp {

	public class JavaIfStatement : JavaStatement {

		public JavaStatement IfProcess {
			get { return SemanticAnalyzer.Statement(Node.ElementAt(2)); }
		}

		public JavaStatement ElseProcess {
			get {
				var node = Node.ElementAtOrDefault(4);
				return node != null ? SemanticAnalyzer.Statement(node) : null;
			}
		}

		public JavaIfStatement(XElement statement)
			: base(statement) { }
	}
}