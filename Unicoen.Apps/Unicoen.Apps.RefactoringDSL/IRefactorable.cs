using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.EncapsulateField {
	public interface IRefactorable {
		UnifiedProgram Refactor();
	}
}
