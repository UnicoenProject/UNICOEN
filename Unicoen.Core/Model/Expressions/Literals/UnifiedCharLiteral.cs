using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   ������ł��郊�e������\���܂��B
	///   e.g. Java�ɂ�����<c>char str = 'c'</c>��<c>'c'</c>�̕���
	/// </summary>
	public class UnifiedCharLiteral : UnifiedTypedLiteral<string> {
		private UnifiedCharLiteral() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedCharLiteral Create(string value) {
			return new UnifiedCharLiteral {
					Value = value,
			};
		}
	}
}