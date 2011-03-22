using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedType : UnifiedExpression {
		public string Name { get; set; }
		private UnifiedTypeParameterCollection _parameters;

		public UnifiedTypeParameterCollection Parameters {
			get { return _parameters; }
			set {
				_parameters = value;
				if (value != null) value.Parent = this;
			}
		}

		public UnifiedType() {
			Parameters = new UnifiedTypeParameterCollection();
		}

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}

		public UnifiedType AddToParameters(UnifiedExpression expression) {
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

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Parameters;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Parameters, v => Parameters = (UnifiedTypeParameterCollection)v);
		}
	}
}