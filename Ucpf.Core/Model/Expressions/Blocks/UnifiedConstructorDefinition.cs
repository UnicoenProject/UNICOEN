﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedConstructorDefinition
			: UnifiedExpressionWithBlock<UnifiedConstructorDefinition> {
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		public UnifiedConstructorDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Parameters;
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}
			}
}