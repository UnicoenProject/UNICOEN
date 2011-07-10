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

using System.Diagnostics;
using Unicoen.Core.Processor;

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
			set { _type = SetChild(value, _type); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		/// <summary>
		///   型が持つ制約の集合を表します
		/// </summary>
		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetChild(value, _constrains); }
		}

		private UnifiedTypeParameter() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedTypeParameter Create(
				UnifiedType type = null,
				UnifiedTypeConstrainCollection
						constrains = null) {
			return new UnifiedTypeParameter {
					Type = type,
					Constrains = constrains,
			};
		}
	}
}