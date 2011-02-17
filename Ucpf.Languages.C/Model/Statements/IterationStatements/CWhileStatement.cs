using System.Xml.Linq;

namespace Ucpf.Languages.C.Model.Statements.IterationStatements {
	public class CWhileStatement : CIterationStatement {
		public CWhileStatement(XElement node) : base(node) {}
	}
}