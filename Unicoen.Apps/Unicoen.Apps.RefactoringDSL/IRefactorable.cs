using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL{
	public interface IRefactorable {
		UnifiedProgram Refactor();
	}
}
