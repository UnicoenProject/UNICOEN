using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedNew : UnifiedElement, IUnifiedExpression {
		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set {
				_type = SetParentOfChild(value, _type);
			}
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set {
				_arguments = SetParentOfChild(value, _arguments);
			}
		}

		private UnifiedNew() {
			Arguments = UnifiedArgumentCollection.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Type;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
		}

		public static UnifiedNew Create(UnifiedType type) {
			return new UnifiedNew {
					Type = type,
			};
		}

		public static UnifiedNew Create(UnifiedType type, UnifiedArgumentCollection arguments) {
			return new UnifiedNew {
				Type = type,
				Arguments = arguments,
			};
		}
	}
}