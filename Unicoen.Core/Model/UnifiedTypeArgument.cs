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
	///   ジェネリクスパラメータなど型に対する実引数を表します。
	///   e.g. Javaにおける<c>HashMap&lt;String, Integer&gt; map;</c>の<c>&lt;String, Integer&gt;</c>
	/// </summary>
	public class UnifiedTypeArgument : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   修飾子の集合を表します
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private IUnifiedExpression _value;

		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetParentOfChild(value, _constrains); }
		}

		private UnifiedTypeArgument() {}

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
			yield return Modifiers;
			yield return Value;
			yield return Constrains;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Value, v => Value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => Constrains, v => Constrains = (UnifiedTypeConstrainCollection)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => _value, v => _value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _constrains, v => _constrains = (UnifiedTypeConstrainCollection)v);
		}

		public static UnifiedTypeArgument Create(IUnifiedExpression value) {
			return new UnifiedTypeArgument {
					Value = value,
			};
		}

		public static UnifiedTypeArgument Create(
				UnifiedType type,
				UnifiedModifierCollection modifiers) {
			return new UnifiedTypeArgument {
					Value = type,
					Modifiers = modifiers,
					Constrains = null
			};
		}

		public static UnifiedTypeArgument Create(
				UnifiedType type,
				UnifiedModifierCollection modifiers,
				UnifiedTypeConstrainCollection
						constrains) {
			return new UnifiedTypeArgument {
					Value = type,
					Modifiers = modifiers,
					Constrains = constrains
			};
		}
	}
}