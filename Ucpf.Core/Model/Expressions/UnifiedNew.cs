using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   新しいインスタンスの生成部分を表します。
	/// </summary>
	public class UnifiedNew : UnifiedExpressionWithBlock<UnifiedNew>
	{
		private UnifiedType _type;

		public UnifiedType Type
		{
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments
		{
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedNew() {}

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
			yield return Type;
			yield return Arguments;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedNew Create(UnifiedType type)
		{
			return new UnifiedNew {
				Type = type,
				Arguments = UnifiedArgumentCollection.Create(),
				Body = null,
			};
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedArgumentCollection arguments)
		{
			return new UnifiedNew {
				Type = type,
				Arguments = arguments,
				Body = null,
			};
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedArgumentCollection arguments,
		                                UnifiedBlock body)
		{
			return new UnifiedNew {
				Type = type,
				Arguments = arguments,
				Body = body,
			};
		}
	}
}