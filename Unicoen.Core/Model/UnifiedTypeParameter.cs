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

using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   ジェネリクスパラメータなど型に対する仮引数を表します。
	///   e.g. Javaにおける<code>public &lt;T&gt; void method(){...}</code>
	///   e.g. C#における<code>public void method&lt;T&gt;(){...}</code>
	/// </summary>
	public class UnifiedTypeParameter : UnifiedElement {
		private UnifiedType _type;

		/// <summary>
		///   仮引数の型を表します
		///   e.g. Javaにおける<code>public &lt;T&gt; void method(){...}</code>の<code>T</code>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		/// <summary>
		///   型が持つ制約の集合を表します
		/// </summary>
		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetParentOfChild(value, _constrains); }
		}

		private UnifiedTypeParameter() {}

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
			yield return Type;
			yield return Constrains;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Type, v => Type = (UnifiedType)v);
			yield return ElementReference.Create
					(() => Constrains, v => Constrains = (UnifiedTypeConstrainCollection)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _type, v => _type = (UnifiedType)v);
			yield return ElementReference.Create
					(() => _constrains, v => _constrains = (UnifiedTypeConstrainCollection)v);
		}

		public static UnifiedTypeParameter Create(
				UnifiedType type,
				UnifiedTypeConstrainCollection
						constrains) {
			return new UnifiedTypeParameter {
					Type = type,
					Constrains = constrains,
			};
		}

		public static UnifiedTypeParameter Create(UnifiedType type) {
			return Create(type, null);
		}
	}
}