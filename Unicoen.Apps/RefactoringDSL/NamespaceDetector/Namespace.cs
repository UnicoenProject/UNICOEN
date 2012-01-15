using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	/// <summary>
	/// 名前空間を表すクラス
	/// </summary>
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

		/// <summary>
		/// 自分を含めて親をすべてたどり，名前空間文字列を結合することで，完全修飾名を取得します
		/// </summary>
		/// <param name="originalDelimiter">名前空間のデリミタ（デフォルトはピリオド）</param>
		/// <returns>完全修飾名</returns>
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

		/// <summary>
		/// 詳細な完全修飾名（各名前空間のタイプを併記）を取得します
		/// </summary>
		/// <param name="originalDelimiter">名前空間のデリミタ（デフォルトはピリオド）</param>
		/// <returns>詳細完全修飾名</returns>
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

		/// <summary>
		/// 自分の親の名前空間（上位名前空間）を yield return していきます
		/// </summary>
		/// <example>
		/// <code>
		/// foreach(var p in node.YieldParents()){...}
		/// </code>
		/// </example>
		/// <returns>自分の親</returns>
		public IEnumerable<Namespace> YieldParents() {
			var node = this;
			while(node != null) {
				yield return node;
				node = node.Parent;
			}
		}
	}
}
