using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {

	public class UnifiedParameterCollection :IEnumerable<UnifiedParameter> {

		private readonly List<UnifiedParameter> _parameters = new List<UnifiedParameter>();

		public void Add(UnifiedParameter param) {
			_parameters.Add(param);
		}

		public IEnumerator<UnifiedParameter> GetEnumerator() {
			return _parameters.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
