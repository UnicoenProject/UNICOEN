using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedQualifiedIdentifier : UnifiedElement {
		public string Delimiter { get; set; }

		private UnifiedIdentifierCollection _identifiers;

		public UnifiedIdentifierCollection Identifiers {
			get { return _identifiers; }
			set { _identifiers = SetParentOfChild(value, _identifiers); }
		}

		public string Value {
			get {
				var delimiter = "";
				var result = "";
				foreach (var identifier in Identifiers) {
					result += delimiter + identifier.Value;
					delimiter = Delimiter;
				}
				return result;
			}
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Identifiers;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Identifiers, v => Identifiers = (UnifiedIdentifierCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_identifiers, v => _identifiers = (UnifiedIdentifierCollection)v);
		}

		public static UnifiedQualifiedIdentifier Create(
				IEnumerable<UnifiedIdentifier> identifiers, string delimiter) {
			return new UnifiedQualifiedIdentifier {
					Identifiers = UnifiedIdentifierCollection.Create(identifiers),
					Delimiter = delimiter,
			};
		}
	}
}