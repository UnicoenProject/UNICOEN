using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedType : UnifiedElement, IUnifiedExpression {
		public string Name { get; set; }
		private UnifiedTypeParameterCollection _parameters;

		public UnifiedTypeParameterCollection Parameters {
			get { return _parameters; }
			set {
				_parameters = SetParentOfChild(value, _parameters);
			}
		}

		private UnifiedType() {
			Parameters = new UnifiedTypeParameterCollection();
		}

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}

		public static UnifiedType Create(string name, UnifiedTypeParameterCollection parameters) {
			return new UnifiedType {
				Name = name,
				Parameters = parameters,
			};
		}

		public UnifiedType AddToParameters(IUnifiedExpression expression) {
			Parameters.Add(expression.ToTypeParameter());
			return this;
		}

		public UnifiedType AddToParameters(UnifiedTypeParameter parameter) {
			Parameters.Add(parameter);
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Parameters;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Parameters, v => Parameters = (UnifiedTypeParameterCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_parameters, v => _parameters = (UnifiedTypeParameterCollection)v);
		}
	}
}