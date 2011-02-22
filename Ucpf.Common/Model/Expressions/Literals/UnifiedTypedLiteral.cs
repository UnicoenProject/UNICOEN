using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	
	public class UnifiedTypedLiteral<T> : UnifiedLiteral {
		public T TypedValue { get; set; }

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}