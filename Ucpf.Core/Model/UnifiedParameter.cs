using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   仮引数(パラメータ)を表します。
    /// </summary>
    /// <example>
    ///     <c>int method(double a)</c>の<c>double a</c>
    /// </example>>
	public class UnifiedParameter : UnifiedElement
	{
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///		パラメータの型を表します
		///		e.g. Javaにおける<c>double a</c>の<c>double</c>
		/// </summary>
		public UnifiedType Type
		{
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedIdentifier _name;

		/// <summary>
		///		パラメータの名前を表します
		///		e.g. Javaにおける<c>double a</c>の<c>a</c>
		/// </summary>
		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedParameter()
		{
			Modifiers = UnifiedModifierCollection.Create();
		}

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
			yield return Modifiers;
			yield return Type;
			yield return Name;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
		}

		public static UnifiedParameter Create(string name)
		{
			return new UnifiedParameter {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
			};
		}

		public static UnifiedParameter Create(string name, UnifiedType type)
		{
			return new UnifiedParameter {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				Type = type,
			};
		}

		public static UnifiedParameter Create(string name, UnifiedType type,
		                                      UnifiedModifierCollection modifiers)
		{
			return new UnifiedParameter {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				Type = type,
				Modifiers = modifiers,
			};
		}
	}
}