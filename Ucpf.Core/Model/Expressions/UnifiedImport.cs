using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 使用する名前空間の指定や外部ファイルの読み込みを表します。
	/// </summary>
	public class UnifiedImport : UnifiedElement, IUnifiedExpression {
		private UnifiedIdentifier _name;

		// TODO: A.B.C を UnifiedPropertyで表現
		public UnifiedIdentifier Name {
			get { return _name; }
			set {
				_name = SetParentOfChild(value, _name);
			}
		}

		private UnifiedImport() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Name;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (UnifiedIdentifier)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (UnifiedIdentifier)v);
		}

		public static UnifiedImport Create(UnifiedIdentifier name) {
			return new UnifiedImport {
				Name = name,
			};
		}

		public static UnifiedImport Create(string name) {
			return new UnifiedImport {
				Name = UnifiedIdentifier.CreateUnknown(name),
			};
		}
	}
}