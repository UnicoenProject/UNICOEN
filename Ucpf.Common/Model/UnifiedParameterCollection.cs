﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {

	public class UnifiedParameterCollection : UnifiedElement, IEnumerable<UnifiedParameter> {

		private readonly List<UnifiedParameter> _parameters;

		public UnifiedParameterCollection() {
			_parameters = new List<UnifiedParameter>();
		}

		public UnifiedParameterCollection(IEnumerable<UnifiedParameter> parameters) {
			_parameters = parameters.ToList();
		}

		public void Add(UnifiedParameter param) {
			_parameters.Add(param);
		}

		public IEnumerator<UnifiedParameter> GetEnumerator() {
			return _parameters.GetEnumerator();
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
