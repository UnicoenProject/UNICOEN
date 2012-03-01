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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   変数宣言における１変数部分を表します。 e.g. Javaにおける <c>int[] a[][], b[], c;</c> の <c>int[] a[][]</c>
	/// </summary>
	public class UnifiedVariableDefinition : UnifiedElement {
		private UnifiedAnnotationCollection _annotations;
		private UnifiedModifierCollection _modifiers;
		private UnifiedType _type;
		private UnifiedIdentifier _name;
		private UnifiedIntegerLiteral _bitField;
		private UnifiedExpression _initialValue;
		private UnifiedArgumentCollection _arguments;
		private UnifiedBlock _body;

		/// <summary>
		///   アノテーションの集合を取得または設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		/// <summary>
		///   修飾子の集合を取得または設定します． e.g. Javaにおける <c>public static int a</c> の <c>public static</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		///   変数の型を取得または設定します． e.g. Javaにおける <c>public static int a[];</c> の <c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		/// <summary>
		///   変数名を取得または設定します． e.g. Javaにおける <c>public static int a[];</c> の <c>a</c>
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		/// <summary>
		///   ビットフィールドを取得または設定します． e.g. Cにおける <c>struct s { signed b1 : 1; signed b2 : 2; }</c> の <c>1</c> や <c>2</c> の部分
		/// </summary>
		public UnifiedIntegerLiteral BitField {
			get { return _bitField; }
			set { _bitField = SetChild(value, _bitField); }
		}

		/// <summary>
		///   変数の初期値を表します。 e.g. Javaにおける <c>int a[] = { 1 };</c> の <c>{ 1 }</c> 部分 e.g. C#, Javaにおける <c>int[] a = { 1 };</c> の <c>{ 1 }</c> 部分 e.g. C, C++, C#, Javaにおける <c>int i = 1;</c> の <c>{ 1 }</c> 部分
		/// </summary>
		public UnifiedExpression InitialValue {
			get { return _initialValue; }
			set { _initialValue = SetChild(value, _initialValue); }
		}

		/// <summary>
		///   変数を初期化するコンストラクタ呼び出しの引数を表します。 e.g. C++における <c>Class c(1);</c>
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		///<summary>
		///  変数に付随するブロックを表します。 e.g. Javaにおけるenumの定数に付随するブロック <code>enum E {
		///                                                    E1 {
		///                                                    @override public String toString() { return ""; }
		///                                                    },
		///                                                    E2
		///                                                    }</code>
		///</summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		protected UnifiedVariableDefinition() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedVariableDefinition Create(
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedType type = null,
				UnifiedIdentifier name = null,
				UnifiedExpression initialValue = null,
				UnifiedArgumentCollection arguments = null,
				UnifiedIntegerLiteral bitField = null,
				UnifiedBlock body = null) {
			return new UnifiedVariableDefinition {
					Annotations = annotations,
					Arguments = arguments,
					BitField = bitField,
					Body = body,
					InitialValue = initialValue,
					Modifiers = modifiers,
					Name = name,
					Type = type,
			};
		}
	}
}