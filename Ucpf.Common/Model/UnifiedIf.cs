using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model
{
    public class UnifiedIf : UnifiedExpression
    {
		public UnifiedExpression Condition { get; set; }
    	public UnifiedBlock TrueBlock { get; set; }
		public UnifiedBlock FalseBlock { get; set; }
    }
}
