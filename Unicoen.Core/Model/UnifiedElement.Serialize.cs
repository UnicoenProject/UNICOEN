#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Unicoen.Model {
	public abstract partial class UnifiedElement {
		#region Methods for ToString()

		// ToString() のためのユーティリティ
		private static void Write(
				object obj, string content, StringBuilder buffer, int depth) {
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

		private static void WriteTypeWithoutContent(
				object obj, StringBuilder buffer, int depth) {
			Write(obj, "", buffer, depth);
		}

		private static void WriteTypeAndContent(
				object obj, StringBuilder buffer, int depth) {
			Write(obj, obj + "", buffer, depth);
		}

		private static readonly string[] IgnorePropertyNames =
				new[] { "Parent", "PropertyInfos", "FieldInfos" };

		private static void WriteUnifiedElement(
				UnifiedElement elem, StringBuilder buffer, int depth) {
			WriteTypeWithoutContent(elem, buffer, depth);
			// write items of enumerable
			var seq = elem as IEnumerable;
			if (seq != null) {
				foreach (var item in seq) {
					ToStringRecursively(item, buffer, depth + 1);
				}
				Debug.Assert(elem.GetType().GetProperties()
					.Where(prop => prop.Name.StartsWith("Unified") || prop.Name.StartsWith("IUnified"))
					.Where(prop => !IgnorePropertyNames.Contains(prop.Name))
					.Where(prop => prop.GetIndexParameters().Length == 0)
					.Select(prop => prop.GetValue(elem, null)).Count() == 0);
				return;
			}

			// write properties without indexer
			var values = elem.GetType().GetProperties()
					.Where(prop => !IgnorePropertyNames.Contains(prop.Name))
					.Where(prop => prop.GetIndexParameters().Length == 0)
					.Select(prop => prop.GetValue(elem, null));
			foreach (var value in values) {
				ToStringRecursively(value, buffer, depth + 1);
			}
		}

		private static void WriteNonUnifiedElement(
				object obj, StringBuilder buffer, int depth) {
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

		private static void ToStringRecursively(
				object obj, StringBuilder buffer, int depth) {
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

		#endregion

		#region Methods for ToXml()

		private static readonly string[] XmlIgnorePropertyNames =
				new[] { "Parent", "PropertyInfos", "FieldInfos", "Count", "IsReadOnly" };

		private static void PrintTabs(int depth, StringBuilder buffer) {
			for (int i = 0; i < depth; i++) {
				buffer.Append("\t");
			}
		}

		private static void XmlWrite(
				object obj, string content, StringBuilder buffer, int depth) {
			if (obj != null) {
				if (!content.Equals("")) {
					PrintTabs(1, buffer);
					buffer.AppendLine(content);
				}
			}
		}

		private static void XmlWriteTypeWithoutContent(
				object obj, StringBuilder buffer, int depth) {
			XmlWrite(obj, "", buffer, depth);
		}

		private static void XmlWriteTypeAndContent(
				object obj, StringBuilder buffer, int depth) {
			XmlWrite(obj, obj + "", buffer, depth);
		}

		private static void XmlWriteUnifiedElement(
				UnifiedElement elem, StringBuilder buffer, int depth) {
			// write items of enumerable
			var seq = elem as IEnumerable;
			if (seq != null) {
				foreach (var item in seq) {
					ToXmlRecursively(item, buffer, depth + 1);
				}
			}

			// write properties without indexer
			var values = elem.GetType().GetProperties()
					.Where(prop => !XmlIgnorePropertyNames.Contains(prop.Name))
					.Where(prop => prop.GetIndexParameters().Length == 0)
					.Select(prop => prop.GetValue(elem, null));
			foreach (var value in values) {
				ToXmlRecursively(value, buffer, depth + 1);
			}
		}

		private static void XmlWriteNonUnifiedElement(
				object obj, StringBuilder buffer, int depth) {
			PrintTabs(depth, buffer);

			var seq = obj as IEnumerable;
			if (!(seq is string) && seq != null) {
				XmlWriteTypeWithoutContent(obj, buffer, depth);
				foreach (var item in seq) {
					ToXmlRecursively(item, buffer, depth);
				}
			} else {
				XmlWriteTypeAndContent(obj, buffer, depth);
			}
		}

		private static void ToXmlRecursively(
				object obj, StringBuilder buffer, int depth) {
			if (obj != null) {
				var nodeName = obj.GetType().Name;
				PrintTabs(depth, buffer);
				buffer.AppendLine("<" + nodeName + ">");

				var elem = obj as UnifiedElement;
				if (elem != null) {
					XmlWriteUnifiedElement(elem, buffer, depth);
				} else {
					XmlWriteNonUnifiedElement(obj, buffer, depth);
				}

				PrintTabs(depth, buffer);
				buffer.AppendLine("</" + nodeName + ">");
			}
		}

		public string ToXml() {
			var buffer = new StringBuilder();
			const string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
			buffer.AppendLine(header);
			ToXmlRecursively(this, buffer, 0);
			return buffer.ToString();
		}
	}

	#endregion
}