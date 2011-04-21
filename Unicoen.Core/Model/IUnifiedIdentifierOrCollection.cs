using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Core.Model
{
	public interface IUnifiedIdentifierOrCollection : IUnifiedElement, IEnumerable<UnifiedIdentifier>
	{
	}
}
