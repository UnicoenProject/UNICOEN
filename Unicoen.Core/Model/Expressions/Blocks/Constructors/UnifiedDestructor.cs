﻿#region License

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
	///   コンストラクタの定義を表します． e.g. Javaにおける <c>public T1() { ... }</c>
	/// </summary>
	public class UnifiedDestructor : UnifiedExpression {
		protected UnifiedSet<UnifiedAnnotation> _annotations;
		protected UnifiedSet<UnifiedModifier> _modifiers;
		protected UnifiedBlock _body;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedDestructor Create(
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedBlock body = null) {
			return new UnifiedDestructor {
					Annotations = annotations,
					Modifiers = modifiers,
					Body = body,
			};
		}
	}
}