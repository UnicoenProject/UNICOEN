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
	///   catch節を表します。
	///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>の部分
	/// </summary>
	public class UnifiedCatch : UnifiedExpressionBlock {
		private UnifiedMatcherCollection _matchers;

		/// <summary>
		///   catch節内のパターンマッチ（例外を受け取る部分）の集合を取得します．
		///   e.g. <c>catch(Exception e){...}</c>の<c>Exception e</c>
		/// </summary>
		public UnifiedMatcherCollection Matchers {
			get { return _matchers; }
			set { _matchers = SetChild(value, _matchers); }
		}

		/// <summary>
		/// ブロックを取得します．
		/// </summary>
		public override UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		protected UnifiedCatch() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedCatch Create(
				UnifiedMatcherCollection matchers = null,
				UnifiedBlock body = null) {
			return new UnifiedCatch {
					Matchers = matchers,
					Body = body,
			};
		}
	}
}