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
			: UnifiedExpressionWithBlock<UnifiedWhile> {
		private IUnifiedExpression _condition;

		/// <summary>
		///   条件式を表します
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

		private UnifiedWhile() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedWhile Create(
				IUnifiedExpression condition, UnifiedBlock body, UnifiedBlock elseBody) {
			return new UnifiedWhile {
					Condition = condition,
					Body = body,
					ElseBody = elseBody,
			};
		}

		public static UnifiedWhile Create(
				IUnifiedExpression condition, UnifiedBlock body) {
			return Create(condition, body, null);
		}

		public static UnifiedWhile Create(IUnifiedExpression condition) {
			return Create(condition, null, null);
		}
			}
}