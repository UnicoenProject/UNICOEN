using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model {
	public interface IWithBlock<out T> where T : UnifiedElement {

		UnifiedBlock Body { get; set; }

		T AddToBody(UnifiedExpression expression);
	}
}
