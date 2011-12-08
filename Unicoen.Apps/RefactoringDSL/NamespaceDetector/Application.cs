using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	public class Application {
		// 名前空間文字列からコードオブジェクトを検索する
		public static IEnumerable<IUnifiedElement> FindUnifiedElementByNamespace(string nsString, IUnifiedElement element) {
			var result = new List<IUnifiedElement>();
			foreach (var e in element.Descendants()) {
				var ns = Detector.Dispatcher(e);
				if(ns != null) {
					if(ns.GetNamespaceString().Equals(nsString)) {
						result.Add(e);
					}
				}
			}

			return result;
		}

	}
}
