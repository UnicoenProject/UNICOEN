using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// catch節を表します。
	/// </summary>
	public class UnifiedCatch : UnifiedExpressionWithBlock<UnifiedCatch> {
		private UnifiedTypeCollection _targetTypes;

		public UnifiedTypeCollection TargetTypes {
			get { return _targetTypes; }
			set { _targetTypes = SetParentOfChild(value, _targetTypes); }
		}

		private UnifiedVariableDefinition _variableDefinition;
	
		public UnifiedVariableDefinition VariableDefinition {
			get { return _variableDefinition; }
			set { _variableDefinition = SetParentOfChild(value, _variableDefinition); }
		}

		private UnifiedCatch() {
			TargetTypes = UnifiedTypeCollection.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return TargetTypes;
			yield return VariableDefinition;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>> GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(TargetTypes, v => TargetTypes = (UnifiedTypeCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(VariableDefinition, v => VariableDefinition = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>> GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(TargetTypes, v => _targetTypes = (UnifiedTypeCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(VariableDefinition, v => _variableDefinition = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedCatch Create(UnifiedVariableDefinition definition, UnifiedBlock body) {
			return new UnifiedCatch {
					VariableDefinition = definition,
					TargetTypes = null,
					Body = body,
			};
		}

		public static UnifiedCatch Create(UnifiedTypeCollection types, UnifiedBlock body) {
			return new UnifiedCatch {
				VariableDefinition = null,
				TargetTypes = types,
				Body = body,
			};
		}
	}
}
