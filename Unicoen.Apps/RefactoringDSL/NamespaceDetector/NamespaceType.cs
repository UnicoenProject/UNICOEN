using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	// 名前空間を作りうる言語要素
	public enum NamespaceType {
		Package, Class, Function, Variable, TemporaryScope,
	}
}
