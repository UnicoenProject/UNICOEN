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
	///   関数やメソッドなどのサブルーチンの定義部分を表します。
	///   e.g. Javaにおける<c>public void method(int a){...}</c>
	/// </summary>
	public class UnifiedFunctionDefinition
			: UnifiedExpressionWithBlock<UnifiedFunctionDefinition> {
		/// <summary>
		///   サブルーチン定義の種類を表します．
		/// </summary>
		public UnifiedFunctionDefinitionKind Kind { get; set; }

		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetParentOfChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   メソッドにつく修飾子の集合を表します
		///   e.g. Javaにおける<c>public static void method(int a){...}</c>の<c>public static</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   メソッドの名前を表します
		///   e.g. Javaにおける<c>public void method(int a){...}</c>の<c>method</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetParentOfChild(value, _typeParameters); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		private UnifiedTypeCollection _throws;

		public UnifiedTypeCollection Throws {
			get { return _throws; }
			set { _throws = SetParentOfChild(value, _throws); }
		}

		private UnifiedFunctionDefinition() {}

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
			yield return Modifiers;
			yield return Annotations;
			yield return Type;
			yield return TypeParameters;
			yield return Name;
			yield return Parameters;
			yield return Throws;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Type, v => Type = (UnifiedType)v);
			yield return ElementReference.Create
					(
							() => TypeParameters,
							v => TypeParameters = (UnifiedTypeParameterCollection)v);
			yield return ElementReference.Create
					(() => Name, v => Name = (UnifiedIdentifier)v);
			yield return ElementReference.Create
					(() => Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return ElementReference.Create
					(() => Throws, v => Throws = (UnifiedTypeCollection)v);
			yield return ElementReference.Create
					(() => Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => _type, v => _type = (UnifiedType)v);
			yield return ElementReference.Create
					(
							() => _typeParameters,
							v => _typeParameters = (UnifiedTypeParameterCollection)v)
					;
			yield return ElementReference.Create
					(() => _name, v => _name = (UnifiedIdentifier)v);
			yield return ElementReference.Create
					(() => _parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return ElementReference.Create
					(() => _throws, v => _throws = (UnifiedTypeCollection)v);
			yield return ElementReference.Create
					(() => _body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedFunctionDefinition CreateLambda(
				UnifiedModifierCollection modifiers,
				UnifiedType type,
				UnifiedTypeParameterCollection typeParameters,
				UnifiedIdentifier name,
				UnifiedParameterCollection parameters,
				UnifiedTypeCollection throws,
				UnifiedBlock body) {
			return new UnifiedFunctionDefinition {
					Name = name,
					Type = type,
					TypeParameters = typeParameters,
					Modifiers = modifiers,
					Parameters = parameters,
					Throws = throws,
					Body = body,
			};
		}

		public static UnifiedFunctionDefinition CreateLambda(
				UnifiedParameterCollection parameters,
				UnifiedBlock body) {
			return CreateLambda(
					null,
					null,
					null,
					null,
					parameters,
					null,
					body);
		}

		public static UnifiedFunctionDefinition CreateFunction(
				UnifiedModifierCollection modifiers,
				UnifiedType type,
				UnifiedTypeParameterCollection typeParameters,
				UnifiedIdentifier name,
				UnifiedParameterCollection parameters,
				UnifiedTypeCollection throws,
				UnifiedBlock body) {
			return new UnifiedFunctionDefinition {
					Name = name,
					Type = type,
					TypeParameters = typeParameters,
					Modifiers = modifiers,
					Parameters = parameters,
					Throws = throws,
					Body = body,
			};
		}

		public static UnifiedFunctionDefinition CreateFunction(
				UnifiedModifierCollection modifiers,
				UnifiedType type,
				string name,
				UnifiedParameterCollection parameters,
				UnifiedTypeCollection throws,
				UnifiedBlock body) {
			return CreateFunction(
					modifiers,
					type,
					null,
					UnifiedIdentifier.CreateFunction(name),
					parameters,
					throws,
					body);
		}

		public static UnifiedFunctionDefinition CreateFunction(string name) {
			return CreateFunction(
					UnifiedModifierCollection.Create(),
					null,
					name,
					UnifiedParameterCollection.Create(),
					null,
					UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(
				UnifiedModifierCollection modifiers, UnifiedType type, string name,
				UnifiedParameterCollection parameters) {
			return CreateFunction(
					modifiers,
					type,
					name,
					parameters,
					null,
					UnifiedBlock.Create());
		}

		public static UnifiedFunctionDefinition CreateFunction(
				UnifiedModifierCollection modifiers, UnifiedType type, string name,
				UnifiedParameterCollection parameters, UnifiedBlock body) {
			return CreateFunction(
					modifiers,
					type,
					name,
					parameters,
					null,
					body);
		}

		public static UnifiedFunctionDefinition CreateFunction(
				string name, UnifiedParameterCollection parameters, UnifiedBlock body) {
			return CreateFunction(
					UnifiedModifierCollection.Create(),
					null,
					name, parameters, null, body);
		}

		public static IUnifiedExpression CreateLambda(
				string name, UnifiedParameterCollection parameters, UnifiedBlock body) {
			return CreateLambda(
					null,
					null,
					null,
					UnifiedIdentifier.CreateFunction(name),
					parameters,
					null,
					body);
		}
			}
}