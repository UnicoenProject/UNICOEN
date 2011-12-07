﻿#region License

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unicoen.Processor;

namespace Unicoen.Model {
	public abstract partial class UnifiedElement : IUnifiedElement {
		private IList<PropertyInfo> _propertyInfos;

		/// <summary>
		///   GetElementReferencesの対象となるプロパティのメタ情報を取得します．
		/// </summary>
		public IList<PropertyInfo> PropertyInfos {
			get {
				if (_propertyInfos == null) {
					_propertyInfos = GetPropertyInfos();
				}
				return _propertyInfos;
			}
		}

		protected virtual List<PropertyInfo> GetPropertyInfos() {
			return GetType().GetProperties()
					.Where(p => p.Name != "Parent")
					.Where(p => p.GetIndexParameters().Length == 0)
					.Where(p => typeof(IUnifiedElement).IsAssignableFrom(p.PropertyType))
					.ToList();
		}

		private IList<FieldInfo> _fieldInfos;

		/// <summary>
		///   GetElementReferencesOfFieldsの対象となるプロパティのメタ情報を取得します．
		/// </summary>
		public IList<FieldInfo> FieldInfos {
			get {
				if (_fieldInfos == null) {
					_fieldInfos =
							GetType().GetFields(
									BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField)
									.Where(p => typeof(IUnifiedElement).IsAssignableFrom(p.FieldType))
									.ToList();
				}
				return _fieldInfos;
			}
		}

		/// <summary>
		///   親のコードモデルの要素を取得もしくは設定します。
		/// </summary>
		public IUnifiedElement Parent { get; protected internal set; }

		/// <summary>
		///   ソースコード上の位置情報を取得もしくは設定します．
		/// </summary>
		public CodePosition Position { get; protected internal set; }

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		public abstract void Accept(IUnifiedVisitor visitor);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <param name = "visitor"></param>
		/// <param name = "arg"></param>
		public abstract void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg);

		/// <summary>
		///   ビジターを適用してコードモデルを走査します。
		/// </summary>
		/// <typeparam name = "TArg"></typeparam>
		/// <typeparam name = "TResult"></typeparam>
		/// <param name = "visitor"></param>
		/// <param name = "arg"></param>
		/// <returns></returns>
		public abstract TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg);

		/// <summary>
		///   子要素を列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public virtual IEnumerable<IUnifiedElement> Elements() {
			return FieldInfos.Select(f => (IUnifiedElement)f.GetValue(this));
		}

		/// <summary>
		///   子要素とセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public virtual IEnumerable<ElementReference> ElementReferences() {
			return PropertyInfos.Select(
					p => ElementReference.Create(
							() => (IUnifiedElement)p.GetValue(this, null),
							e => p.SetValue(this, e, null)));
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターのペアを列挙します。
		/// </summary>
		/// <returns>子要素</returns>
		public virtual IEnumerable<ElementReference>
				ElementReferencesOfFields() {
			return FieldInfos.Select(
					f => ElementReference.Create(
							() => (IUnifiedElement)f.GetValue(this),
							e => f.SetValue(this, e)));
		}

		/// <summary>
		///   コードモデルを正規化します。
		///   正規化の内容は以下のとおりです。
		///   ・子要素がUnifiedBlockだけのUnifiedBlockを削除
		///   ・-1や+1などの単項式を定数に変換
		/// </summary>
		public virtual IUnifiedElement Normalize() {
			NormalizeChildren();
			return this;
		}

		/// <summary>
		///   子要素に対して正規化を再帰的に行います。
		/// </summary>
		public void NormalizeChildren() {
			foreach (var reference in ElementReferencesOfFields()) {
				if (reference.Element != null) {
					var child = reference.Element.Normalize();
					reference.Element = child;
					((UnifiedElement)child).Parent = this;
				}
			}
		}

		/// <summary>
		///   深いコピーを取得します。
		/// </summary>
		/// <returns>深いコピー</returns>
		IUnifiedElement IUnifiedElement.PrivateDeepCopy() {
			var ret = (UnifiedElement)MemberwiseClone();
			ret.Parent = null;
			foreach (var reference in ret.ElementReferences()) {
				reference.Element = reference.Element.DeepCopy();
			}
			return ret;
		}

		/// <summary>
		///   Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		///   A new object that is a copy of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public object Clone() {
			return this.DeepCopy();
		}

		/// <summary>
		///   指定した子要素を削除します。
		/// </summary>
		/// <param name = "target">自分自身</param>
		/// <returns></returns>
		public virtual IUnifiedElement RemoveChild(IUnifiedElement target) {
			var reference = ElementReferencesOfFields()
					.First(e => ReferenceEquals(target, e.Element));
			reference.Element = null;
			((UnifiedElement)target).Parent = null;
			return this;
		}

		/// <summary>
		///   親要素から自分自身を削除します。
		/// </summary>
		/// <returns>親要素</returns>
		public IUnifiedElement RemoveSelf() {
			return Parent.RemoveChild(this);
		}

		/// <summary>
		///   指定した子要素の親を指定した要素に設定します。
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "child">新たに設定する子要素</param>
		/// <param name = "oldChild">元の子要素</param>
		/// <returns></returns>
		public T SetChild<T>(T child, IUnifiedElement oldChild)
				where T : class, IUnifiedElement {
			if (child != null) {
				if (child.Parent != null) {
					throw new InvalidOperationException("既に親要素が設定されている要素を設定できません。");
				}
				((UnifiedElement)(IUnifiedElement)child).Parent = this;
			} else if (oldChild != null && Parent != null) {
				oldChild.RemoveSelf();
			}
			return child;
		}
	}
}