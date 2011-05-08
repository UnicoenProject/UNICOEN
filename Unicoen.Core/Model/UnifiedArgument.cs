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
	///   実引数を表します。
	///   e.g. Javaにおける<c>method(a, b, c)</c>の<c>a</c>
	/// </summary>
	public class UnifiedArgument : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   実引数の修飾子を表します．
		///   e.g. C#における<code>method(out v);</code>の<code>out</code>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private IUnifiedExpression _value;

		/// <summary>
		///   実引数の値を表します．
		/// </summary>
		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private IUnifiedExpression _target;

		/// <summary>
		///   実引数の値を表します．
		/// </summary>
		public IUnifiedExpression Target {
			get { return _target; }
			set { _target = SetParentOfChild(Target, _target); }
		}

		private UnifiedArgument() {}

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
			yield return Target;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Value, v => Value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => Target, v => Target = (IUnifiedExpression)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => _value, v => _value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _target, v => _target = (IUnifiedExpression)v);
		}

		public static UnifiedArgument Create(
				UnifiedModifierCollection modifiers, IUnifiedExpression value,
				IUnifiedExpression target) {
			return new UnifiedArgument {
					Modifiers = modifiers,
					Value = value,
					Target = target,
			};
		}

		public static UnifiedArgument Create(
				UnifiedModifierCollection modifiers, IUnifiedExpression value) {
			return Create(modifiers, value, null);
		}

		public static UnifiedArgument Create(IUnifiedExpression value) {
			return Create(null, value, null);
		}
	}
}