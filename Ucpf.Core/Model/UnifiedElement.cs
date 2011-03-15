using System.Collections;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public abstract class UnifiedElement {
		public abstract TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data);

		private static void Write(object obj, string content, StringBuilder buffer,
		                          int depth) {
			for (int i = 0; i < depth; i++) {
				buffer.Append("  ");
			}
			if (obj != null) {
				buffer.Append(obj.GetType().Name + ": ");
				buffer.AppendLine(content);
			} else {
				buffer.Append("null: ");
				buffer.AppendLine(content);
			}
		}

		private static void WriteTypeWithoutContent(object obj, StringBuilder buffer,
		                                            int depth) {
			Write(obj, "", buffer, depth);
		}

		private static void WriteTypeAndContent(object obj, StringBuilder buffer,
		                                        int depth) {
			Write(obj, obj + "", buffer, depth);
		}

		private static void WriteUnifiedElement(UnifiedElement elem,
		                                        StringBuilder buffer, int depth) {
			WriteTypeWithoutContent(elem, buffer, depth);
			// write items of enumerable
			var seq = elem as IEnumerable;
			if (seq != null) {
				foreach (var item in seq) {
					ToStringRecursively(item, buffer, depth + 1);
				}
			}
			// write properties without indexer
			var values = elem.GetType().GetProperties()
				.Where(prop => prop.GetIndexParameters().Length == 0)
				.Select(prop => prop.GetValue(elem, null));
			foreach (var value in values) {
				ToStringRecursively(value, buffer, depth + 1);
			}
		}

		private static void WriteNonUnifiedElement(object obj, StringBuilder buffer,
		                                           int depth) {
			var seq = obj as IEnumerable;
			if (!(seq is string) && seq != null) {
				WriteTypeWithoutContent(obj, buffer, depth);
				foreach (var item in seq) {
					ToStringRecursively(item, buffer, depth + 1);
				}
			} else {
				WriteTypeAndContent(obj, buffer, depth);
			}
		}

		private static void ToStringRecursively(object obj, StringBuilder buffer,
		                                        int depth) {
			var elem = obj as UnifiedElement;
			if (elem != null) {
				WriteUnifiedElement(elem, buffer, depth);
			} else {
				WriteNonUnifiedElement(obj, buffer, depth);
			}
		}

		public override string ToString() {
			var buffer = new StringBuilder();
			ToStringRecursively(this, buffer, 0);
			return buffer.ToString();
		}
	}
}