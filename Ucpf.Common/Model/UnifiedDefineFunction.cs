﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedDefineFunction : UnifiedStatement {
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Block { get; set; }
	}
}
