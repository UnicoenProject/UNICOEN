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

using System;
using System.Diagnostics;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   ブロックを持つ式を表します。
	/// </summary>
	/// <typeparam name = "TSelf"></typeparam>
	public abstract class UnifiedExpressionWithBlock
			: UnifiedElement, IUnifiedExpression {
		protected UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}
			}

	/// <summary>
	///   ブロックを持つ式を表します。
	/// </summary>
	/// <typeparam name = "TSelf"></typeparam>
	public abstract class UnifiedExpressionWithBlock<TSelf>
			: UnifiedExpressionWithBlock
			where TSelf : UnifiedExpressionWithBlock<TSelf> {
		protected UnifiedExpressionWithBlock() {
			Debug.Assert(typeof(TSelf).Equals(GetType()));
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		public TSelf AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return (TSelf)this;
		}
			}
}