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
using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	public class UnifiedUsing
			: UnifiedExpressionWithBlock<UnifiedUsing> {
		private UnifiedMatcherCollection _matchers;

		public UnifiedMatcherCollection Matchers {
			get { return _matchers; }
			set { _matchers = SetParentOfChild(value, _matchers); }
		}

		private UnifiedUsing() {}

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

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Matchers;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Matchers, v => Matchers = (UnifiedMatcherCollection)v);
			yield return ElementReference.Create
					(() => Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _matchers, v => _matchers = (UnifiedMatcherCollection)v);
			yield return ElementReference.Create
					(() => _body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedUsing Create(
				UnifiedMatcherCollection matchers,
				UnifiedBlock body) {
			return new UnifiedUsing {
					Matchers = matchers,
					Body = body,
			};
		}
			}
}