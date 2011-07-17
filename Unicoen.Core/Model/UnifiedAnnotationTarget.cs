using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Model {
	public enum UnifiedAnnotationTarget {
		None = 0,
		Assembly,
		Module,
		Type,
		Field,
		Method,
		Event,
		Property,
		Param,
		Return
	}
}
