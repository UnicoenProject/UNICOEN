using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	/// <summary>
	/// 新しい名前区間を作成し得る要素の種類を列挙します
	/// </summary>
	public enum NamespaceType {
		Package, Class, Function, Variable, TemporaryScope,
	}
}
