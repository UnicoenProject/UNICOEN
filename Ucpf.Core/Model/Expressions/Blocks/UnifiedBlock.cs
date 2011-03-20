using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedBlock : UnifiedExpression, IEnumerable<UnifiedExpression>, INormalizable {
		private readonly List<UnifiedExpression> _statements;

		public UnifiedBlock() {
			_statements = new List<UnifiedExpression>();
		}

		public UnifiedBlock(IEnumerable<UnifiedExpression> expressions) {
			_statements = expressions.ToList();
		}

		public UnifiedExpression this[int index] {
			get { return _statements[index]; }
			set { _statements[index] = value; }
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
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(this[i], v => this[i] = (UnifiedExpression)v);
			}
		}

		UnifiedElement INormalizable.Normalize() {
			if (_statements.Count == 1) {
				var block = _statements[0] as UnifiedBlock;
				if (block != null)
					return block;
			}
			return this;
		}
	}
}