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
	public class UnifiedMatcher : UnifiedElement {
		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private IUnifiedExpression _matcher;

		public IUnifiedExpression Matcher {
			get { return _matcher; }
			set { _matcher = SetChild(value, _matcher); }
		}

		private IUnifiedExpression _as;

		public IUnifiedExpression As {
			get { return _as; }
			set { _as = SetChild(value, _as); }
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

		public static UnifiedMatcher Create(
				IUnifiedExpression matcher, IUnifiedExpression asExp) {
			return Create(null, null, matcher, asExp);
		}

		public static UnifiedMatcher Create(
				UnifiedAnnotationCollection annotations,
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