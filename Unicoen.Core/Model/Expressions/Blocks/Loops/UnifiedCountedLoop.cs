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
	/// loop文を表します。
	/// e.g. Javaにおける <c>for(int i = 0; i &lt; 10; i++){...}</c>
	/// </summary>
	public class UnifiedCountedLoop : UnifiedExpression {
		private UnifiedExpression _count;
		private UnifiedBlock _body;


		/// <summary>
		/// 　ループの継続の回数を表します。
		///  e.g. Rubyにおける <c>3.times</c> の <c>3</c>
		/// </summary>
		public UnifiedExpression Count {
			get { return _count; }
			set { _count = SetChild(value, _count); }
		}

		/// <summary>
		///   ループ中に実行するブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private UnifiedCountedLoop() {}

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

		public static UnifiedCountedLoop Create(
				UnifiedExpression count,
				UnifiedBlock body) {
			return new UnifiedCountedLoop {
				Count = count,
				Body =  body
			};
		}
	}
}