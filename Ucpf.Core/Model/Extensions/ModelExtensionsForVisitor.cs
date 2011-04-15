using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelExtensionsForVisitor {
		public static void TryAccept<TElement>(this TElement element,
		                                       IUnifiedModelVisitor visitor)
				where TElement : class, IUnifiedElement {
			if (element != null)
				element.Accept(visitor);
		}

		public static TResult TryAccept<TElement, TData, TResult>(
				this TElement element, IUnifiedModelVisitor<TData, TResult> visitor,
				TData data)
				where TElement : class, IUnifiedElement {
			if (element != null)
				return element.Accept(visitor, data);
			return default(TResult);
		}
	}
}