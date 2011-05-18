﻿
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

using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   変数宣言における１変数部分を表します。
	///   e.g. Javaにおける<c>int[] a[][], b[], c;</c>の<c>int[] a[][]</c>
	/// </summary>
	public class UnifiedVariableDefinition : UnifiedElement, IUnifiedExpression {
		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得または設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetParentOfChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   変数に付随する修飾子の集合を取得または設定します．
		///   e.g. Javaにおける<c>public static int a</c>の<c>public static</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   変数の型を取得または設定します．
		///   e.g. Javaにおける<c>public static int a[];</c>の<c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedIdentifier _name;

		/// <summary>
		///   変数名を取得または設定します．
		///   e.g. Javaにおける<c>public static int a[];</c>の<c>a</c>
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedTypeSupplementCollection _supplements;

		/// <summary>
		///   変数名に付随する型情報を取得または設定します．
		///   e.g. Javaにおける<c>int[][] a[] = new int[1][1][1];</c>の<c>[]</c>部分
		/// </summary>
		public UnifiedTypeSupplementCollection Supplements {
			get { return _supplements; }
			set { _supplements = SetParentOfChild(value, _supplements); }
		}

		private UnifiedIntegerLiteral _bitField;

		/// <summary>
		///   ビットフィールドを取得または設定します．
		///   e.g. Cにおける<c>struct s { signed b1 : 1; signed b2 : 2; }</c>の<c>1</c>や<c>2</c>の部分
		/// </summary>
		public UnifiedIntegerLiteral BitField {
			get { return _bitField; }
			set { _bitField = SetParentOfChild(value, _bitField); }
		}

		private IUnifiedExpression _initialValue;

		/// <summary>
		///   変数の初期化部分を表します。
		///   e.g. Javaにおける<c>int a[] = { 1 };</c>の<c>{ 1 }</c>部分
		///   e.g. C#, Javaにおける<c>int[] a = { 1 };</c>の<c>{ 1 }</c>部分
		///   e.g. C, C++, C#, Javaにおける<c>int i = 1;</c>の<c>{ 1 }</c>部分
		/// </summary>
		public IUnifiedExpression InitialValue {
			get { return _initialValue; }
			set { _initialValue = SetParentOfChild(value, _initialValue); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   変数の初期化のコンストラクタ呼び出しを表します。
		///   e.g. C++における<c>Class c(1);</c>
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedBlock _body;

		///<summary>
		///  変数に付随するブロックを表します。
		///  e.g. Javaにおけるenumの定数に付随するブロック
		///  <code>
		///    enum E {
		///      E1 {
		///        @override public String toString() { return ""; }
		///      },
		///      E2
		///    }
		///  </code>
		///</summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetParentOfChild(value, _body); }
		}

		private UnifiedVariableDefinition() { }

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
			yield return Annotations;
			yield return Modifiers;
			yield return Type;
			yield return Name;
			yield return Supplements;
			yield return BitField;
			yield return InitialValue;
			yield return Arguments;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Annotations, v => Annotations = (UnifiedAnnotationCollection)v);
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Type, v => Type = (UnifiedType)v);
			yield return ElementReference.Create
					(() => Name, v => Name = (UnifiedIdentifier)v);
			yield return ElementReference.Create
					(() => Supplements, v => Supplements = (UnifiedTypeSupplementCollection)v);
			yield return ElementReference.Create
					(() => BitField, v => BitField = (UnifiedIntegerLiteral)v);
			yield return ElementReference.Create
					(() => InitialValue, v => InitialValue = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => Arguments, v => Arguments = (UnifiedArgumentCollection)v);
			yield return ElementReference.Create
					(() => Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _annotations, v => _annotations = (UnifiedAnnotationCollection)v);
			yield return ElementReference.Create
					(() => _modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => _type, v => _type = (UnifiedType)v);
		}
	}
}