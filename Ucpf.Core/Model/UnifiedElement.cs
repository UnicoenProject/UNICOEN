using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public abstract class UnifiedElement : IUnifiedElement {
		/// <summary>
		///   親のコードモデルの要素を取得もしくは設定します。
		/// </summary>
		public UnifiedElement Parent { get; protected internal set; }

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		public abstract void Accept(IUnifiedModelVisitor visitor);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <typeparam name = "TData"></typeparam>
		/// <typeparam name = "TResult"></typeparam>
		/// <param name = "visitor"></param>
		/// <param name = "data"></param>
		/// <returns></returns>
		public abstract TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data);

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public abstract IEnumerable<UnifiedElement> GetElements();

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public abstract IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters();

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public abstract IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters();

		/// <summary>
		///   コードモデルを正規化します。
		///   正規化の内容は以下のとおりです。
		///   ・子要素がUnifiedBlockだけのUnifiedBlockを削除
		///   ・-1や+1などの単項式を定数に変換
		/// </summary>
		public virtual UnifiedElement Normalize() {
			NormalizeChildren();
			return this;
		}

		/// <summary>
		///   子要素に対して正規化を再帰的に行います。
		/// </summary>
		protected void NormalizeChildren() {
			foreach (var elemAndSetter in GetElementAndDirectSetters()) {
				if (elemAndSetter.Item1 != null) {
					var child = elemAndSetter.Item1.Normalize();
					elemAndSetter.Item2(child);
					child.Parent = this;
				}
			}
		}

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		public virtual UnifiedElement DeepCopy() {
			var ret = (UnifiedElement)MemberwiseClone();
			ret.Parent = null;
			foreach (var elemAndSetter in ret.GetElementAndDirectSetters()) {
				if (elemAndSetter.Item1 != null) {
					elemAndSetter.Item2(elemAndSetter.Item1.DeepCopy());
				}
			}
			return ret;
		}

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		public virtual T DeepCopy<T>()
				where T : UnifiedElement {
			return (T)DeepCopy();
		}

		/// <summary>
		///   Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		///   A new object that is a copy of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public object Clone() {
			return DeepCopy();
		}

		/// <summary>
		/// 指定した子要素を削除します。
		/// </summary>
		/// <param name="target">自分自身</param>
		/// <returns></returns>
		public virtual UnifiedElement RemoveChild(UnifiedElement target) {
			Contract.Requires(target != null);
			var elem = GetElementAndDirectSetters()
					.First(e => ReferenceEquals(target, e.Item1));
			elem.Item2(null);
			target.Parent = null;
			return this;
		}

		/// <summary>
		///   親要素から自分自身を削除します。
		/// </summary>
		/// <returns>親要素</returns>
		public UnifiedElement Remove() {
			Contract.Requires(Parent != null, "親要素がない状態でRemoveメソッドを実行できません。");
			return Parent.RemoveChild(this);
		}

		/// <summary>
		///   指定した子要素の親を指定した要素に設定します。
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "child">新たに設定する子要素</param>
		/// <param name="parent">親となる要素</param>
		/// <param name="oldChild">元の子要素</param>
		/// <returns></returns>
		public static T SetParentOfChild<T>(T child, UnifiedElement parent, UnifiedElement oldChild)
				where T : UnifiedElement {
			if (child != null) {
				if (child.Parent != null) {
					throw new InvalidOperationException("既に親要素が設定されている要素を設定できません。");
				}
				child.Parent = parent;
			} else if (parent.Parent != null) {
				oldChild.Remove();
			}
			return child;
		}

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
				// TODO: 集合を表現する要素は他のプロパティを持たないはず
				return;
			}
			// write properties without indexer
			var values = elem.GetType().GetProperties()
					.Where(prop => prop.Name != "Parent")
					// TODO: 集合を表現する要素は他のプロパティを持たないはず
					//.Where(prop => prop.GetIndexParameters().Length == 0)
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