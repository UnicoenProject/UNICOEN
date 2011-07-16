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
	///   仮引数(パラメータ)を表します。
	///   e.g. Javaにおける<code>public void method(int a)</code>の<code>int a</code>
	/// </summary>
	public class UnifiedParameter : UnifiedElement {
		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   仮引数の修飾子を表します
		///   e.g. Javaにおける<code>public void method(final int a)</code>の<code>final</code>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   仮引数の型を表します。
		///   e.g. Javaにおける<code>public void method(int a)</code>の<code>int</code>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		private UnifiedIdentifierCollection _names;

		/// <summary>
		///   仮引数の引数名を表します。
		///   e.g. Javaにおける<c>method(int a)</c>の<c>a</c>
		///   e.g. Pythonにおける<c>def f((a,b)=[1,2], c)</c>の<c>a,b</c>と<c>c</c>
		/// </summary>
		public UnifiedIdentifierCollection Names {
			get { return _names; }
			set { _names = SetChild(value, _names); }
		}

		private IUnifiedExpression _defaultValue;

		/// <summary>
		///   仮引数のデフォルト値を表します。
		///   e.g. C#における<code>method(int a = 0)</code>の<code>0</code>
		/// </summary>
		public IUnifiedExpression DefaultValue {
			get { return _defaultValue; }
			set { _defaultValue = SetChild(value, _defaultValue); }
		}

		private UnifiedParameter() {}

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

		public static UnifiedParameter Create(
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedType type = null,
				UnifiedIdentifierCollection names = null,
				IUnifiedExpression defaultValue = null) {
			return new UnifiedParameter {
					Annotations = annotations,
					Modifiers = modifiers,
					Type = type,
					Names = names,
					DefaultValue = defaultValue,
			};
		}
	}
}