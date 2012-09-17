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
	///   配列の生成を含むコンストラクタ呼び出しを表します。 e.g. Javaにおける <c>Object o = new Object();</c> の <c>new Object()</c> の部分
	/// </summary>
	public class UnifiedNew : UnifiedExpression {
		private UnifiedExpression _target;
		private UnifiedSet<UnifiedArgument> _arguments;
		private UnifiedSet<UnifiedGenericArgument> _genericArguments;
		private UnifiedArrayLiteral _initialValue;
		private UnifiedBlock _body;

		public UnifiedExpression Target {
			get { return _target; }
			set { _target = SetChild(value, _target); }
		}

		public UnifiedSet<UnifiedArgument> Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		public UnifiedSet<UnifiedGenericArgument> GenericArguments {
			get { return _genericArguments; }
			set { _genericArguments = SetChild(value, _genericArguments); }
		}

		/// <summary>
		///   配列生成時の初期値を表します。 e.g. Javaにおける <c>new int[10] { 0, 1 }</c> の <c>{ 0, 1 }</c> 部分
		/// </summary>
		public UnifiedArrayLiteral InitialValue {
			get { return _initialValue; }
			set { _initialValue = SetChild(value, _initialValue); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private UnifiedNew() {}

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

		public static UnifiedNew Create(
				UnifiedExpression target = null,
				UnifiedSet<UnifiedArgument> arguments = null,
				UnifiedSet<UnifiedGenericArgument> genericArguments = null,
				UnifiedArrayLiteral initialValues = null,
				UnifiedBlock body = null) {
			return new UnifiedNew {
					Target = target,
					Arguments = arguments,
					GenericArguments = genericArguments,
					InitialValue = initialValues,
					Body = body,
			};
		}
	}
}