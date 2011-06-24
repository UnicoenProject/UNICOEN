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
	///   関数呼び出しを表します。
	///   e.g. Javaにおける<c>method(a, b, c)</c>
	/// </summary>
	public class UnifiedCall : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _function;

		public IUnifiedExpression Function {
			get { return _function; }
			set { _function = SetChild(value, _function); }
		}

		private UnifiedGenericArgumentCollection _genericArguments;

		public UnifiedGenericArgumentCollection GenericArguments {
			get { return _genericArguments; }
			set { _genericArguments = SetChild(value, _genericArguments); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   実引数の集合を表します
		///   e.g. Javaにおける<c>method(a, b, c)</c>の<c>a, b, c</c>の部分
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedCall() {}

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

		public static UnifiedCall Create(
				IUnifiedExpression target = null,
				UnifiedArgumentCollection args = null,
				UnifiedGenericArgumentCollection genericArguments = null) {
			return new UnifiedCall {
					Function = target,
					Arguments = args,
					GenericArguments = genericArguments
			};
		}
	}
}