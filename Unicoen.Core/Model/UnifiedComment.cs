using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	/// コメントを表します．
	/// </summary>
	public class UnifiedComment : UnifiedElement {

		/// <summary>
		/// コメントの文字列表現です．
		/// </summary>
		public string Comment { get; set; }

		private UnifiedComment() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield break;
		}

		public static UnifiedComment Create(string comment) {
			return new UnifiedComment { Comment = comment };
		}
	}
}