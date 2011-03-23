using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBlock : UnifiedExpression, IEnumerable<UnifiedExpression> {
		private List<UnifiedExpression> _statements;

		public UnifiedBlock() {
			_statements = new List<UnifiedExpression>();
		}

		public UnifiedBlock(IEnumerable<UnifiedExpression> expressions) {
			_statements = expressions.ToList();
		}

		public UnifiedExpression this[int index] {
			get { return _statements[index]; }
			set {
				if (value != null) {
					if (value.Parent != null)
						value = (UnifiedExpression)value.DeepCopy();
					value.Parent = this;
				}
				_statements[index] = value;
			}
		}

		public int Count {
			get { return _statements.Count; }
		}

		#region IEnumerable<UnifiedExpression> Members

		public IEnumerator<UnifiedExpression> GetEnumerator() {
			return _statements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		public void Add(UnifiedExpression expression) {
			_statements.Add(expression);
			if (expression != null) expression.Parent = this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override UnifiedElement DeepCopy() {
			var ret = (UnifiedBlock)MemberwiseClone();
			ret.Parent = null;
			ret._statements = new List<UnifiedExpression>();
			foreach (var element in this) {
				ret.Add((UnifiedExpression)element.DeepCopy());
			}
			return ret;
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
						(this[i], v => this[i] = (UnifiedExpression)v);
			}
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
						(_statements[i], v => _statements[i] = (UnifiedExpression)v);
			}
		}

		public override UnifiedElement Normalize() {
			NormalizeChildren();
			if (_statements.Count == 1) {
				var block = _statements[0] as UnifiedBlock;
				if (block != null)
					return block;
			}
			return this;
		}
	}
}