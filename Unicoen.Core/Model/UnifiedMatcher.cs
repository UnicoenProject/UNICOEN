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

using System.Diagnostics;
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   パターンマッチで利用されるパターンと代入先の組を表します．
	///   switch文，using文，パターンマッチ文などで利用されます．
	///   e.g. Pythonにおける<c>with file(p1) as f1, file(p2) as f2:</c>の<c>file(p1) as f1</c>
	/// </summary>
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

		/// <summary>
		///   マッチングを行うパターンを表します．
		///   e.g. Pythonにおける<c>with file(p1) as f1:</c>の<c>file(p1)</c>
		/// </summary>
		public IUnifiedExpression Matcher {
			get { return _matcher; }
			set { _matcher = SetChild(value, _matcher); }
		}

		private IUnifiedExpression _as;

		/// <summary>
		///   マッチした値の代入先を表します．
		///   e.g. Pythonにおける<c>with file(p1) as f1:</c>の<c>f1</c>
		/// </summary>
		public IUnifiedExpression As {
			get { return _as; }
			set { _as = SetChild(value, _as); }
		}

		private UnifiedMatcher() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedMatcher Create(
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				IUnifiedExpression matcher = null,
				IUnifiedExpression asExp = null) {
			return new UnifiedMatcher {
					Annotations = annotations,
					Modifiers = modifiers,
					Matcher = matcher,
					As = asExp,
			};
		}
	}
}