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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   プロパティの宣言を表す共通表現です。
	///   e.g. C#における<c>public int Value { get; set; }</c>
	/// </summary>
	public class UnifiedPropertyDefinition : UnifiedElement, IUnifiedExpression {
		#region fields & properties

		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		///   e.g. C#における<c>[Pure] int Value { get; set; }</c>の<c>[Pure]</c>
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   付与されている修飾子の集合を取得もしくは設定します．
		///   e.g. C#における<c>public int Value { get; set; }</c>の<c>public</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   プロパティが表す値の型を取得もしくは設定します．
		///   e.g. C#における<c>public int Value { get; set; }</c>の<c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		private UnifiedIdentifier _name;

		/// <summary>
		///   名前を取得もしくは設定します．
		///   e.g. C#における<c>public int Value { get; set; }</c>の<c>Value</c>
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedPropertyBody _get;

		/// <summary>
		///   ゲッターメソッドを取得もしくは設定します．
		///   e.g. C#における<c>public int Value { get; set; }</c>の<c>get;</c>
		/// </summary>
		public UnifiedPropertyBody Get {
			get { return _get; }
			set { _get = SetChild(value, _get); }
		}

		/// <summary>
		///   ゲッターメソッドを取得もしくは設定します．
		///   e.g. C#における<c>public int Value { get; set; }</c>の<c>set;</c>
		/// </summary>
		private UnifiedPropertyBody _set;

		public UnifiedPropertyBody Set {
			get { return _set; }
			set { _set = SetChild(value, _set); }
		}

		private UnifiedPropertyBody _add;

		public UnifiedPropertyBody Add {
			get { return _add; }
			set { _add = SetChild(value, _add); }
		}

		private UnifiedPropertyBody _remove;

		public UnifiedPropertyBody Remove {
			get { return _remove; }
			set { _remove = SetChild(value, _remove); }
		}

		#endregion

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}
	}
}