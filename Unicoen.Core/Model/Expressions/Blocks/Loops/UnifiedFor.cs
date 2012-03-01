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
	///   for文を表します。 e.g. Javaにおける <c>for(int i = 0; i &lt; 10; i++){...}</c>
	/// </summary>
	public class UnifiedFor : UnifiedExpression {
		private UnifiedExpression _initializer;
		private UnifiedExpression _condition;
		private UnifiedExpression _step;
		private UnifiedBlock _body;
		private UnifiedBlock _falseBody;

		/// <summary>
		///   初期条件を表します e.g. Javaにおける <c>for(int i = 0; i &lt; 10; i++){...}</c> <c>int i = 0</c>
		/// </summary>
		public UnifiedExpression Initializer {
			get { return _initializer; }
			set { _initializer = SetChild(value, _initializer); }
		}

		/// <summary>
		///   ループの継続の条件式を表します e.g. Javaにおける <c>for(int i = 0; i &lt; 10; i++){...}</c> の <c>i &lt; 10</c>
		/// </summary>
		public UnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		/// <summary>
		///   ステップを表します e.g. Javaにおける <c>for(int i = 0; i &lt; 10; i++){...}</c> の <c>i++</c>
		/// </summary>
		public UnifiedExpression Step {
			get { return _step; }
			set { _step = SetChild(value, _step); }
		}

		/// <summary>
		///   ループ中に実行するブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set { _falseBody = SetChild(value, _falseBody); }
		}

		private UnifiedFor() {}

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

		public static UnifiedFor Create(
				UnifiedExpression initializer = null,
				UnifiedExpression condition = null,
				UnifiedExpression step = null,
				UnifiedBlock body = null) {
			return new UnifiedFor {
					Initializer = initializer,
					Condition = condition,
					Step = step,
					Body = body,
			};
		}
	}
}