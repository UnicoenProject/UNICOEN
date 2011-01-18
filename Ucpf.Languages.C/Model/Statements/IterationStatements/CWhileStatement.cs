using System.Xml.Linq;

namespace Ucpf.Languages.C.Model {
	public class CWhileStatement : CIterationStatement {
		public CWhileStatement(XElement node) : base(node) {}
	}
}