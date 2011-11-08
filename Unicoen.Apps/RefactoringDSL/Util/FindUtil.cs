using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.Util {
	public class FindUtil {
		/// <summary>
		/// 指定されたクラス名を持つクラスを，プログラム中から検索して取得します
		/// </summary>
		/// <param name="program">（トップノードの）プログラムオブジェクト</param>
		/// <param name="className">検索するクラス名</param>
		/// <returns>検索したクラスの UnifiedClassDefinition オブジェクト（の集合）</returns>
		public static IEnumerable<UnifiedClassDefinition> FindClassByClassName(UnifiedProgram program, string className) {
			var result =
					program.Descendants<UnifiedClassDefinition>().Where(e => ((UnifiedIdentifier)(e.Name)).Name == className);
			return result;
		}
	}
}
