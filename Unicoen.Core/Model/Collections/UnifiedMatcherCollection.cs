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
	///   パターンマッチ（条件や型，式，変数）の集合を表します．
	///   e.g. JavaやC#における<c>catch(Exception e){...}</c>の<c>Exception e</c>
	///   e.g. Pythonにおける<c>with file(p1) as f1, file(p2) as f2:</c>の<c>file(p1) as f1, file(p2) as f2</c>
	/// </summary>
	public class UnifiedMatcherCollection
			: UnifiedElementCollection<UnifiedMatcher, UnifiedMatcherCollection> {
		public override UnifiedMatcherCollection CreateSelf() {
			return new UnifiedMatcherCollection();
		}

		protected UnifiedMatcherCollection() {}

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
			}
}