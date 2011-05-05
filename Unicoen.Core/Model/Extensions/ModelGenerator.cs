using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Core.Model
{
	public static class ModelGenerator
	{
		/// <summary>
		/// 深いコピーを取得します．
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T self)
			where T : IUnifiedElement {
			return (T)self.PrivateDeepCopy();
		}
	}
}
