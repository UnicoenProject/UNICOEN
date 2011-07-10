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
using System.Diagnostics;
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	public abstract class UnifiedBlockDefinition : UnifiedExpressionBlock {
		protected UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		protected UnifiedModifierCollection _modifiers;

		/// <summary>
		///   クラスの修飾子の集合を表します
		///   <c>public class A{....}</c>の<c>public</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		protected IUnifiedExpression _name;

		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		// generics とか
		protected UnifiedGenericParameterCollection _genericParameters;

		public UnifiedGenericParameterCollection GenericParameters {
			get { return _genericParameters; }
			set { _genericParameters = SetChild(value, _genericParameters); }
		}

		// 継承とか
		protected UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetChild(value, _constrains); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public override UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}
	}

	public abstract class UnifiedDefinitionWithBlock<T>
			: UnifiedBlockDefinition, IUnifiedCreatable<T>
			where T : UnifiedDefinitionWithBlock<T> {
		public static T Create(
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				IUnifiedExpression name = null,
				UnifiedGenericParameterCollection genericParameters = null,
				UnifiedTypeConstrainCollection constrains = null,
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
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			// Deal with the bug of Mono 2.10.2
			throw new InvalidOperationException("You should override this method.");
		}
			}
}