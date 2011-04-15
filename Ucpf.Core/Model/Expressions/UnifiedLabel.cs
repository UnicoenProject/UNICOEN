using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	public class UnifiedLabel : UnifiedElement, IUnifiedExpression
	{
		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedLabel() {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data)
		{
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Name;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
		}

		public static IUnifiedExpression Create(string value)
		{
			return new UnifiedLabel {
				Name = UnifiedIdentifier.Create(value, UnifiedIdentifierKind.Unknown),
			};
		}
	}
}