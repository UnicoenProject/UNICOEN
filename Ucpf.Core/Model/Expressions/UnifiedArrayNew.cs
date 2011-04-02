using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedArrayNew : UnifiedExpression {
		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set {
				_type = SetParentOfChild(value, this, _type);
			}
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set {
				_arguments = SetParentOfChild(value, this, _arguments);
			}
		}

		private UnifiedExpressionCollection _initialValues;

		public UnifiedExpressionCollection InitialValues {
			get { return _initialValues; }
			set {
				_initialValues = SetParentOfChild(value, this, _initialValues);
			}
		}

		public UnifiedArrayNew() {
			Arguments = new UnifiedArgumentCollection();
			InitialValues = new UnifiedExpressionCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Type;
			yield return Arguments;
			yield return InitialValues;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(InitialValues, v => InitialValues = (UnifiedExpressionCollection)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_initialValues, v => _initialValues = (UnifiedExpressionCollection)v);
		}
	}
}