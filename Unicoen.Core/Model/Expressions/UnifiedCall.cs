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
	///   関数呼び出しを表します。 e.g. Javaにおける <c>method(a, b, c)</c>
	/// </summary>
	public class UnifiedCall : UnifiedExpression {
		private UnifiedExpression _function;
		private UnifiedSet<UnifiedGenericArgument> _genericArguments;
		private UnifiedSet<UnifiedArgument> _arguments;
		private UnifiedProc _proc;

		public UnifiedExpression Function {
			get { return _function; }
			set { _function = SetChild(value, _function); }
		}

		public UnifiedSet<UnifiedGenericArgument> GenericArguments {
			get { return _genericArguments; }
			set { _genericArguments = SetChild(value, _genericArguments); }
		}

		/// <summary>
		///   実引数の集合を表します e.g. Javaにおける <c>method(a, b, c)</c> の <c>a, b, c</c> の部分
		/// </summary>
		public UnifiedSet<UnifiedArgument> Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		/// <summary>
		///   ブロック付きメソッド呼び出しのブロックを表します e.g. Rubyにおける <c>[].each { |i| p i }</c> の <c>{ |i| p i }</c>
		/// </summary>
		public UnifiedProc Proc {
			get { return _proc; }
			set { _proc = SetChild(value, _proc); }
		}

		private UnifiedCall() {}

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

		public static UnifiedCall Create(
				UnifiedExpression target = null,
				UnifiedSet<UnifiedArgument> args = null,
				UnifiedSet<UnifiedGenericArgument> genericArguments = null,
				UnifiedProc proc = null) {
			return new UnifiedCall {
					Function = target,
					Arguments = args,
					GenericArguments = genericArguments,
					Proc = proc
			};
		}
	}
}