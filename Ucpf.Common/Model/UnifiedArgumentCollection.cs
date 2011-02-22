using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {

	public class UnifiedArgumentCollection : UnifiedElement, IEnumerable<UnifiedArgument> {

		private readonly List<UnifiedArgument> _args;

		public UnifiedArgumentCollection() {
			_args = new List<UnifiedArgument>();
		}

		public UnifiedArgumentCollection(IEnumerable<UnifiedArgument> args) {
			_args = args.ToList();
		}

		public void Add(UnifiedArgument arg) {
			_args.Add(arg);
		}

		public IEnumerator<UnifiedArgument> GetEnumerator() {
			return _args.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}
