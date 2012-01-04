using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.C.CodeGenerators {
	// CCodeFactoryVisitorのうち、型に関する処理を行います
	public partial class CCodeFactoryVisitor {
		// 型(UnifiedBasicType)
		public override bool Visit(UnifiedBasicType element, VisitorArgument arg) {
			element.BasicTypeName.TryAccept(this, arg);
			return false;
		}
	}
}
