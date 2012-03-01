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
	///   while文を表します。 e.g. Javaにおける <c>while(cond){...}</c>
	/// </summary>
	public class UnifiedWhile
			: UnifiedExpression {
		private UnifiedExpression _condition;
		private UnifiedBlock _body;
		private UnifiedBlock _elseBody;

		/// <summary>
		///   ループの継続の条件式を表します e.g. Javaにおける <c>while(cond){...}</c> の <c>cond</c>
		/// </summary>
		public UnifiedExpression Condition {
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

		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetChild(value, _elseBody); }
		}

		private UnifiedWhile() {}

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

		public static UnifiedWhile Create(
				UnifiedExpression condition = null,
				UnifiedBlock body = null,
				UnifiedBlock elseBody = null) {
			return new UnifiedWhile {
					Condition = condition,
					Body = body,
					ElseBody = elseBody,
			};
		}
			}
}