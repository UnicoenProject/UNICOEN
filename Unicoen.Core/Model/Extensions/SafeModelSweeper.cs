using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Unicoen.Core.Model
{
	public static class SafeModelSweeper
	{
		/// <summary>
		/// レシーバーがnullでも動作するParentプロパティです．
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static IUnifiedElement SafeParent(this IUnifiedElement element) {
			Contract.Requires(element != null);
			if (element == null)
				return null;
			return element.Parent;
		}
	}
}
