using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
	public class CEmptyStatement : CExpressionStatement, IEmptyStatement {
		#region IEmptyStatement Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public override string ToString() {
			return ";";
		}
	}
}