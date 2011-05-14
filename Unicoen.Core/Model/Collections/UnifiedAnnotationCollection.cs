using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   アノテーションもしくは属性の集合を表します．
	/// e.g. Javaにおける<c>@Override @Deprecated void method() { ... }</c>の<c>@Override @Deprecated</c>
	/// </summary>
	public class UnifiedAnnotationCollection
			: UnifiedElementCollection<UnifiedAnnotation, UnifiedAnnotationCollection> {
		private UnifiedAnnotationCollection() {}

		private UnifiedAnnotationCollection(IEnumerable<UnifiedAnnotation> elements)
				: base(elements) {}

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

		public static UnifiedAnnotationCollection Create() {
			return new UnifiedAnnotationCollection();
		}

		public static UnifiedAnnotationCollection Create(
				params UnifiedAnnotation[] elements) {
			return new UnifiedAnnotationCollection(elements);
		}

		public static UnifiedAnnotationCollection Create(
				IEnumerable<UnifiedAnnotation> elements) {
			return new UnifiedAnnotationCollection(elements);
		}
			}
}
