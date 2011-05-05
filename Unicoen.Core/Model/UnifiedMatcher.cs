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
	public class UnifiedMatcher : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private IUnifiedExpression _matcher;

		public IUnifiedExpression Matcher {
			get { return _matcher; }
			set { _matcher = SetParentOfChild(value, _matcher); }
		}

		private IUnifiedExpression _as;

		public IUnifiedExpression As {
			get { return _as; }
			set { _as = SetParentOfChild(value, _as); }
		}

		private UnifiedMatcher() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor, TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Matcher;
			yield return As;
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Matcher, v => Matcher = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => As, v => As = (IUnifiedExpression)v);
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield return ElementReference.Create
					(() => _modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => _matcher, v => _matcher = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _as, v => _as = (IUnifiedExpression)v);
		}

		public static UnifiedMatcher Create(
				IUnifiedExpression matcher, IUnifiedExpression asExp) {
			return Create(null, matcher, asExp);
		}

		public static UnifiedMatcher Create(
				UnifiedModifierCollection modifiers, IUnifiedExpression matcher,
				IUnifiedExpression asExp) {
			return new UnifiedMatcher {
					Modifiers = modifiers,
					Matcher = matcher,
					As = asExp,
			};
		}
	}
}