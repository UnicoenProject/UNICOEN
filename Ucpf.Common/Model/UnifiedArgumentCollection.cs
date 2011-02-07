using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {

	public class UnifiedArgumentCollection {

		private readonly List<UnifiedArgument> _args = new List<UnifiedArgument>();

		private  void Add(UnifiedArgument arg) {
			_args.Add(arg);
		}
	}
}
