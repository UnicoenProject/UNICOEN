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
	///   関数やメソッドなどのサブルーチンの定義部分を表します。
	///   e.g. Javaにおける<c>public void method(int a){...}</c>
	/// </summary>
	public class UnifiedFunctionDefinition : UnifiedExpressionWithBlock {
		
		/// <summary>
		///   サブルーチン定義の種類を表します．
		/// </summary>
		public UnifiedFunctionDefinitionKind Kind { get; set; }

		#region fields

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
		///   メソッドにつく修飾子の集合を表します
		///   e.g. Javaにおける<c>public static void method(int a){...}</c>の<c>public static</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   メソッドの名前を表します
		///   e.g. Javaにおける<c>public void method(int a){...}</c>の<c>method</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetChild(value, _typeParameters); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		private UnifiedTypeCollection _throws;

		public UnifiedTypeCollection Throws {
			get { return _throws; }
			set { _throws = SetChild(value, _throws); }
		}

		#endregion

		private UnifiedFunctionDefinition() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedFunctionDefinition Create(
				UnifiedFunctionDefinitionKind kind,
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedType type = null,
				UnifiedTypeParameterCollection typeParameters = null,
				UnifiedIdentifier name = null,
				UnifiedParameterCollection parameters = null,
				UnifiedTypeCollection throws = null,
				UnifiedBlock body = null) {
			return new UnifiedFunctionDefinition {
				Kind = kind,
				Name = name,
				Annotations = annotations,
				Type = type,
				TypeParameters = typeParameters,
				Modifiers = modifiers,
				Parameters = parameters,
				Throws = throws,
				Body = body,
			};
		}
	}
}