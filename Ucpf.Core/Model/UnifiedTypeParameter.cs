using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   ジェネリクスパラメータなど型に対する仮引数を表します。
	/// </summary>
	public class UnifiedTypeParameter : UnifiedElement {
		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetParentOfChild(value, _constrains); }
		}

		private UnifiedTypeParameter() {}

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
			yield return Type;
			yield return Constrains;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Constrains, v => Constrains = (UnifiedTypeConstrainCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_constrains, v => _constrains = (UnifiedTypeConstrainCollection)v);
		}

		public static UnifiedTypeParameter Create(UnifiedType type,
		                                          UnifiedTypeConstrainCollection
		                                          		constrains) {
			return new UnifiedTypeParameter {
					Type = type,
					Constrains = constrains,
			};
		}

		public static UnifiedTypeParameter Create(UnifiedType type) {
			return Create(type, null);
		}
	}
}