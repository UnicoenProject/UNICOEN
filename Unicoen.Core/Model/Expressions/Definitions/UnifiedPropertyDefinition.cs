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
	///   プロパティの宣言を表す共通表現です。 e.g. C#における <c>public int Value { get; set; }</c>
	/// </summary>
	public class UnifiedPropertyDefinition : UnifiedExpression {
		#region fields & properties

		private UnifiedAnnotationCollection _annotations;
		private UnifiedModifierCollection _modifiers;
		private UnifiedType _type;
		private UnifiedIdentifier _name;
		private UnifiedParameterCollection _parameters;
		private UnifiedPropertyDefinitionPart _getter;
		private UnifiedPropertyDefinitionPart _setter;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します． e.g. C#における <c>[Pure] int Value { get; set; }</c> の <c>[Pure]</c>
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		/// <summary>
		///   付与されている修飾子の集合を取得もしくは設定します． e.g. C#における <c>public int Value { get; set; }</c> の <c>public</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		/// <summary>
		///   プロパティが表す値の型を取得もしくは設定します． e.g. C#における <c>public int Value { get; set; }</c> の <c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		/// <summary>
		///   名前を取得もしくは設定します． e.g. C#における <c>public int Value { get; set; }</c> の <c>Value</c>
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		/// <summary>
		///   パラメータ（仮引数）の集合を取得もしくは設定します． e.g. C#における <c>public int Table[int x, int y] { get; set; }</c> の <c>int x, int y</c>
		/// </summary>
		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		/// <summary>
		///   ゲッターの定義を取得もしくは設定します． e.g. C#における <c>public int Value { get; set; }</c> の <c>get;</c>
		/// </summary>
		public UnifiedPropertyDefinitionPart Getter {
			get { return _getter; }
			set { _getter = SetChild(value, _getter); }
		}

		/// <summary>
		///   セッターの定義を取得もしくは設定します． e.g. C#における <c>public int Value { get; set; }</c> の <c>set;</c>
		/// </summary>
		public UnifiedPropertyDefinitionPart Setter {
			get { return _setter; }
			set { _setter = SetChild(value, _setter); }
		}

		#endregion

		protected UnifiedPropertyDefinition() {}

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

		public static UnifiedPropertyDefinition Create(
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedType type = null, UnifiedIdentifier name = null,
				UnifiedParameterCollection parameters = null,
				UnifiedPropertyDefinitionPart getter = null,
				UnifiedPropertyDefinitionPart setter = null) {
			return new UnifiedPropertyDefinition {
					Annotations = annotations,
					Modifiers = modifiers,
					Type = type,
					Name = name,
					Parameters = parameters,
					Getter = getter,
					Setter = setter,
			};
		}
	}
}