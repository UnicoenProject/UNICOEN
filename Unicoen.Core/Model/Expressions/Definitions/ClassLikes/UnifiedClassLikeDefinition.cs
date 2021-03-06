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

using System;
using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	public abstract class UnifiedClassLikeDefinition
			: UnifiedExpression {
		protected UnifiedSet<UnifiedAnnotation> _annotations;
		protected UnifiedSet<UnifiedModifier> _modifiers;
		protected UnifiedExpression _name;
		protected UnifiedSet<UnifiedGenericParameter> _genericParameters;
		protected UnifiedSet<UnifiedTypeConstrain> _constrains;
		protected UnifiedBlock _body;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		/// <summary>
		///   修飾子の集合を取得もしくは設定します。 e.g. Java, C#における <c>public class A { ... }</c> の <c>public</c>
		/// </summary>
		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		///   名前を取得もしくは設定します。 e.g. Java, C#における <c>public class A { ... }</c> の <c>A</c>
		/// </summary>
		public UnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		/// <summary>
		///   総称型（ジェネリクスタイプ）のパラメータやテンプレートのパラメータを取得もしくは設定します。 e.g. Java, C#における <c>class A&lt;T&gt;</c> の <c>&lt;T&gt;</c>
		/// </summary>
		public UnifiedSet<UnifiedGenericParameter> GenericParameters {
			get { return _genericParameters; }
			set { _genericParameters = SetChild(value, _genericParameters); }
		}

		/// <summary>
		///   継承関係を取得もしくは設定します。 e.g. Javaにおける <c>class A extends B { }</c> の <c>extends B</c>
		/// </summary>
		public UnifiedSet<UnifiedTypeConstrain> Constrains {
			get { return _constrains; }
			set { _constrains = SetChild(value, _constrains); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}
			}

	public abstract class UnifiedBlockDefinition<T>
			: UnifiedClassLikeDefinition, IUnifiedCreatable<T>
			where T : UnifiedBlockDefinition<T> {
		public static T Create(
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedExpression name = null,
				UnifiedSet<UnifiedGenericParameter> genericParameters = null,
				UnifiedSet<UnifiedTypeConstrain> constrains = null,
				UnifiedBlock body = null) {
			var ret = UnifiedFactory<T>.Create();
			ret.Annotations = annotations;
			ret.Modifiers = modifiers;
			ret.Name = name;
			ret.GenericParameters = genericParameters;
			ret.Constrains = constrains;
			ret.Body = body;
			return ret;
		}

		public abstract T CreateSelf();

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException(
					"You should override this method.");
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException(
					"You should override this method.");
		}
			}
}