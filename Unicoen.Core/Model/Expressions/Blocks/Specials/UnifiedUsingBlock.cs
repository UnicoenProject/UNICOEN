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
	///   C#におけるusing文，Pythonにおけるwith文を表します．
	///   e.g. C#における<c>using(var r = new StreamReader(path)){...}</c>
	///   e.g. Pythonにおける<c>with file(p1) as f1, file(p2) as f2:</c>
	/// </summary>
	public class UnifiedUsing
			: UnifiedExpressionBlock {
		private UnifiedMatcherCollection _matchers;

		/// <summary>
		///   リソース解放の対象となる変数を表します．
		///   e.g. C#における<c>using(var r = new StreamReader(path)){...}</c>の<c>var r = new StreamReader(path)</c>
		///   e.g. Pythonにおける<c>with file(p1) as f1, file(p2) as f2:</c>の<c>file(p1) as f1, file(p2) as f2</c>
		/// </summary>
		public UnifiedMatcherCollection Matchers {
			get { return _matchers; }
			set { _matchers = SetChild(value, _matchers); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public override UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private UnifiedUsing() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedUsing Create2(
				UnifiedMatcherCollection matchers = null,
				UnifiedBlock body = null) {
			return new UnifiedUsing {
					Matchers = matchers,
					Body = body,
			};
		}
			}
}