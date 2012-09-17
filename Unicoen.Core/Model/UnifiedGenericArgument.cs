#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   ジェネリクスパラメータなど型に対する実引数を表します。 e.g. Javaにおける <c>HashMap&lt;String, Integer&gt; map;</c> の <c>&lt;String, Integer&gt;</c>
	/// </summary>
	public class UnifiedGenericArgument : UnifiedElement {
		private UnifiedSet<UnifiedModifier> _modifiers;

		/// <summary>
		///   修飾子の集合を表します
		/// </summary>
		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedExpression _value;

		public UnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private UnifiedSet<UnifiedTypeConstrain> _constrains;

		public UnifiedSet<UnifiedTypeConstrain> Constrains {
			get { return _constrains; }
			set { _constrains = SetChild(value, _constrains); }
		}

		private UnifiedGenericArgument() {}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedGenericArgument Create(
				UnifiedExpression type = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedSet<UnifiedTypeConstrain>
						constrains = null) {
			return new UnifiedGenericArgument {
					Value = type,
					Modifiers = modifiers,
					Constrains = constrains
			};
		}
	}
}