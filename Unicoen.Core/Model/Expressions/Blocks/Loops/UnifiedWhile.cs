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
	///   while文を表します。
	///   e.g. Javaにおける<c>while(cond){...}</c>
	/// </summary>
	public class UnifiedWhile
			: UnifiedExpressionBlock {
		private IUnifiedExpression _condition;

		/// <summary>
		///   ループの継続の条件式を表します
		///   e.g. Javaにおける<c>while(cond){...}</c>の<c>cond</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		private UnifiedBlock _elseBody;

		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetChild(value, _elseBody); }
		}

		/// <summary>
		/// ブロックを取得します．
		/// </summary>
		public override UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private UnifiedWhile() {}

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

		public static UnifiedWhile Create(
				IUnifiedExpression condition = null,
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