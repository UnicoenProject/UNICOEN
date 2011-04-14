using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   使用する名前空間の指定や外部ファイルの読み込みを表します。
	/// </summary>
	public class UnifiedImport : UnifiedElement, IUnifiedExpression
	{
		private UnifiedProperty _name;

		// TODO: A.B.C を UnifiedPropertyで表現
		public UnifiedProperty Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedImport() {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Name;
			yield return Modifiers;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedProperty)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedProperty)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
		}

		public static UnifiedImport Create(UnifiedProperty name, UnifiedModifierCollection modifiers)
		{
			return new UnifiedImport {
				Name = name,
				Modifiers = modifiers,
			};
		}

	}
}