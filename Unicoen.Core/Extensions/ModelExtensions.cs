using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Model {
	public static class ModelExtensions {
		/// <summary>
		/// 指定しオブジェクトのプロパティを再帰的に比較してオブジェクト同士の等価性を判断します．
		/// </summary>
		/// <param name="element"></param>
		/// <param name="that"></param>
		/// <returns></returns>
		public static bool StructuralEquals(this IUnifiedElement element, IUnifiedElement that) {
			return StructuralEqualityComparer.StructuralEquals(element, that);
		}
	}
}
