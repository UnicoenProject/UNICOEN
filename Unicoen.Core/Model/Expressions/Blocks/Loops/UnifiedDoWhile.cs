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
	///   do-while文を表します。
	///   e.g. Javaにおける<c>do { ... } while(cond);</c>
	/// </summary>
	public class UnifiedDoWhile : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;
		private UnifiedBlock _body;
		private UnifiedBlock _falseBody;

		/// <summary>
		///   ループの継続を判定する条件式を取得もしくは設定します．
		///   e.g. Javaにおける<c>do{...}while(cond)</c>の<c>cond</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		/// <summary>
		///   ループ中に実行するブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		/// <summary>
		///   条件式が満たされない際に一度だけ実行されるブロックを取得もしくは設定します．
		///   今のところ該当する言語が存在しません．
		/// </summary>
		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set { _falseBody = SetChild(value, _falseBody); }
		}

		private UnifiedDoWhile() {}

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

		public static UnifiedDoWhile Create(
				UnifiedBlock body = null,
				IUnifiedExpression condition = null,
				UnifiedBlock falseBody = null) {
			return new UnifiedDoWhile {
					Body = body,
					Condition = condition,
					FalseBody = falseBody,
			};
		}
	}
}