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

using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   変数宣言における修飾子と型を省略した部分を表します。
	///   なお、変数宣言(UnifiedVariableDefinition)は修飾子と型と本クラスの集合クラス(UnifiedVariableDefinitionBodyCollection)によって表現されます。
	///   e.g. Javaにおける<c>final int a = b + c;</c>の<c>a = b + c</c>の部分
	/// </summary>
	public class DeprecatedUnifiedVariableDefinitionBody : UnifiedElement {
		private UnifiedIdentifier _name;

		/// <summary>
		///   変数名を表します。
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedTypeSupplementCollection _supplements;

		/// <summary>
		///   変数名に付随する型情報を表します。
		///   e.g. Javaにおける<c>int[][] a[] = new int[1][1][1];</c>の<c>[]</c>部分
		/// </summary>
		public UnifiedTypeSupplementCollection Supplements {
			get { return _supplements; }
			set { _supplements = SetChild(value, _supplements); }
		}

		private UnifiedIntegerLiteral _bitField;

		/// <summary>
		///   ビットフィールドを取得または設定します．
		///   e.g. Cにおける<c>struct s { signed b1 : 1; signed b2 : 2; }</c>の<c>1</c>や<c>2</c>の部分
		/// </summary>
		public UnifiedIntegerLiteral BitField {
			get { return _bitField; }
			set { _bitField = SetChild(value, _bitField); }
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
			set { _initialValue = SetChild(value, _initialValue); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   変数の初期化のコンストラクタ呼び出しを表します。
		///   e.g. C++における<c>Class c(1);</c>
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedBlock _body;

		///<summary>
		///  変数に付随するブロックを表します。
		///  e.g. Javaにおけるenumの定数に付随するブロック
		///  <code>
		///    enum E {
		///    E1 {
		///    @override public String toString() { return ""; }
		///    },
		///    E2
		///    }
		///  </code>
		///</summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		private DeprecatedUnifiedVariableDefinitionBody() {}

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

		public static DeprecatedUnifiedVariableDefinitionBody Create(string name) {
			return Create(
					UnifiedIdentifier.CreateVariable(name),
					null,
					null,
					null,
					null);
		}

		public static DeprecatedUnifiedVariableDefinitionBody Create(
				string name,
				UnifiedTypeSupplementCollection supplements,
				IUnifiedExpression initialValues) {
			return Create(
					UnifiedIdentifier.CreateVariable(name),
					supplements,
					initialValues,
					null,
					null);
		}

		public static DeprecatedUnifiedVariableDefinitionBody Create(
				UnifiedIdentifier name) {
			return Create(name, null, null, null, null);
		}

		public static DeprecatedUnifiedVariableDefinitionBody Create(
				UnifiedIdentifier name,
				UnifiedTypeSupplementCollection supplements,
				IUnifiedExpression initialValues,
				UnifiedArgumentCollection arguments,
				UnifiedBlock block) {
			return new DeprecatedUnifiedVariableDefinitionBody {
					Name = name,
					Supplements = supplements,
					InitialValue = initialValues,
					Arguments = arguments,
					Body = block,
			};
		}

		public static DeprecatedUnifiedVariableDefinitionBody Create(
				UnifiedIdentifier name,
				UnifiedTypeSupplementCollection supplements,
				UnifiedIntegerLiteral bitField,
				IUnifiedExpression initialValues,
				UnifiedArgumentCollection arguments,
				UnifiedBlock block) {
			return new DeprecatedUnifiedVariableDefinitionBody {
					Name = name,
					Supplements = supplements,
					BitField = bitField,
					InitialValue = initialValues,
					Arguments = arguments,
					Body = block,
			};
		}
	}
}