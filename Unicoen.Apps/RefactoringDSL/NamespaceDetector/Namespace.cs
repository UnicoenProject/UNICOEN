using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	// 名前空間オブジェクトを表すクラス
	public class Namespace {
		public Namespace Parent { get; set; }
		public string Value { get; set; }
		public NamespaceType NamespaceType { get; set; }

		public override string ToString() {
			return Value;
		}

		public override bool Equals(object obj) {
			if (obj is Namespace) {
				return this.GetNamespaceString().Equals(((Namespace)obj).GetNamespaceString());
			} else {
				return false;
			}
		}

		// 自分を含めて親を全部たどって，名前空間文字列くっつける
		public string GetNamespaceString(string originalDelimiter = ".") {
			var delimiter = "";
			var ns = "";
			var node = this;
			while(node != null) {
				ns = node.Value + delimiter + ns;
				node = node.Parent;
				delimiter = originalDelimiter;
			}

			return ns;
		}

		// 詳細名前空間文字列を生成する
		public string GetDetailedNamespaceString(string originalDelimiter = ".") {
			var delimiter = "";
			var ns = "";
			var node = this;
			while(node != null) {
				ns = node.Value + "[" + node.NamespaceType.ToString() + "]" + delimiter + ns;
				node = node.Parent;
				delimiter = originalDelimiter;
			}

			return ns;
			
		}
	}
}
