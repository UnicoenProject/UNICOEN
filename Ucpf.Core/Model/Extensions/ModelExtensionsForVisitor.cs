using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Extensions
{
	public static class ModelExtensionsForVisitor
	{
		public static void TryAccept<T>(this T element, IUnifiedModelVisitor visitor)
			where T : class, IUnifiedElement
		{
			if (element != null)
				element.Accept(visitor);
		}
	}
}
