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
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   switch文におけるcase式を表します。
	///   e.g. Javaにおける<c>switch(sw){case 1: BLOCK1 ...}</c>の<c>case 1: BLOCK1</c>
	/// </summary>
	public class UnifiedCase : UnifiedElement {
		private IUnifiedExpression _condition;

		/// <summary>
		///   case式の分岐条件を表します
		///   e.g. Javaにおける<c>switch(sw){case 1: EXPRESSION1 ...}</c>の<c>1</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		private UnifiedBlock _body;

		/// <summary>
		///   case式の分岐に対応する内容を表します
		///   e.g. Javaにおける<c>switch(sw){case 1: BLOCK1 ...}</c>の<c>BLOCK1</c>
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private UnifiedCase() {}

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

		public UnifiedCase AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}

		public static UnifiedCase Create(
				IUnifiedExpression condtion = null,
				UnifiedBlock body = null) {
			return new UnifiedCase {
					Body = body,
					Condition = condtion,
			};
		}

		public static UnifiedCase CreateDefault(
				UnifiedBlock body = null) {
			return new UnifiedCase {
					Body = body,
			};
		}
	}
}