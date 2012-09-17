#region License

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
	/// <summary>
	/// A class representing an event declaration for C#.
	/// e.g. <c>public event KeyboadEventHandler OnKeyDown { add {} remove {} }</c>
	/// for C#.
	/// </summary>
	public class UnifiedEventDefinition : UnifiedExpression {
		#region fields & properties

		private UnifiedSet<UnifiedAnnotation> _annotations;
		private UnifiedSet<UnifiedModifier> _modifiers;
		private UnifiedType _type;
		private UnifiedSet<UnifiedIdentifier> _names;
		private UnifiedPropertyDefinitionPart _adder;
		private UnifiedPropertyDefinitionPart _remover;

		/// <summary>
		/// 付与されているアノテーションを取得もしくは設定します．
		/// e.g. <c>[Pure]</c> in 
		/// <c>[Pure] public event KeyboadEventHandler OnKeyDown</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		/// <summary>
		/// 付与されている修飾子の集合を取得もしくは設定します．
		/// e.g. <c>public</c> in 
		/// <c>[Pure] public event KeyboadEventHandler OnKeyDown</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		/// プロパティが表す値の型を取得もしくは設定します．
		/// e.g. <c>KeyboadEventHandler</c> in 
		/// <c>[Pure] public event KeyboadEventHandler OnKeyDown</c>
		/// for C#.
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		/// <summary>
		/// 名前を取得もしくは設定します．
		/// e.g. <c>OnKeyDown, OnKeyPush</c>
		/// in <c>[Pure] public event KeyboadEventHandler OnKeyDown, OnKeyPush</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedIdentifier> Names {
			get { return _names; }
			set { _names = SetChild(value, _names); }
		}

		/// <summary>
		/// イベントの追加処理の定義を取得もしくは設定します．
		/// e.g. <c>add {}</c>
		/// in <c>OnKeyDown { add {} remove {} }</c>
		/// for C#.
		/// </summary>
		public UnifiedPropertyDefinitionPart Adder {
			get { return _adder; }
			set { _adder = SetChild(value, _adder); }
		}

		/// <summary>
		/// イベントの追加処理の定義を取得もしくは設定します．
		/// e.g. <c>remove {}</c>
		/// in <c>OnKeyDown { add {} remove {} }</c>
		/// for C#.
		/// </summary>
		public UnifiedPropertyDefinitionPart Remover {
			get { return _remover; }
			set { _remover = SetChild(value, _remover); }
		}

		#endregion

		protected UnifiedEventDefinition() {}

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

		public static UnifiedEventDefinition Create(
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedType type = null,
				UnifiedSet<UnifiedIdentifier> names = null,
				UnifiedPropertyDefinitionPart adder = null,
				UnifiedPropertyDefinitionPart remover = null) {
			return new UnifiedEventDefinition {
					Annotations = annotations,
					Modifiers = modifiers,
					Type = type,
					Names = names,
					Adder = adder,
					Remover = remover,
			};
		}
	}
}