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
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   パターンマッチで利用されるパターンと代入先の組を表します．
	///   catch文, switch文，using文，パターンマッチ文などで利用されます．
	///   e.g. Javaにおける<c>catch(Exception e) { ... }</c>の<c>Exception e</c>
	/// </summary>
	public class UnifiedMatcher : UnifiedElement {
		private UnifiedAnnotationCollection _annotations;
		private UnifiedModifierCollection _modifiers;
		private IUnifiedExpression _matcher;
		private IUnifiedExpression _assign;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		/// <summary>
		/// 修飾子を取得もしくは設定します．
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		///   マッチングを行うパターン（型や式）を取得もしくは設定します．
		///   e.g. Javaにおける<c>catch(Exception e) { ... }</c>の<c>Exception</c>
		/// </summary>
		public IUnifiedExpression Matcher {
			get { return _matcher; }
			set { _matcher = SetChild(value, _matcher); }
		}

		/// <summary>
		///   マッチした値を設定する左辺式や変数宣言を取得もしくは設定します．
		///   e.g. Javaにおける<c>catch(Exception e) { ... }</c>の<c>e</c>
		/// </summary>
		public IUnifiedExpression Assign {
			get { return _assign; }
			set { _assign = SetChild(value, _assign); }
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
				IUnifiedExpression assign = null) {
			return new UnifiedMatcher {
					Annotations = annotations,
					Modifiers = modifiers,
					Matcher = matcher,
					Assign = assign,
			};
		}
	}
}