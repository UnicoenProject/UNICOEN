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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   ジェネリクスパラメータなど型に対する実引数を表します。
	///   e.g. Javaにおける<c>HashMap&lt;String, Integer&gt; map;</c>の<c>&lt;String, Integer&gt;</c>
	/// </summary>
	public class UnifiedGenericArgument : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   修飾子の集合を表します
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private IUnifiedExpression _value;

		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetChild(value, _constrains); }
		}

		private UnifiedGenericArgument() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedGenericArgument Create(
				IUnifiedExpression type = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedTypeConstrainCollection
						constrains = null) {
			return new UnifiedGenericArgument {
					Value = type,
					Modifiers = modifiers,
					Constrains = constrains
			};
		}
	}
}