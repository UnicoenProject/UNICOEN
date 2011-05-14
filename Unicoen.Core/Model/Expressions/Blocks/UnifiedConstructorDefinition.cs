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
using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   コンストラクタの定義部分を表します。
	///   e.g. Javaにおける<c>class C{ C(){...} }</c>の<c>C(){...}</c>
	/// </summary>
	public class UnifiedConstructorDefinition
			: UnifiedExpressionWithBlock<UnifiedConstructorDefinition> {
		public UnifiedConstructorDefinitionKind Kind { get; set; }

		private UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetParentOfChild(value, _annotations); }
		}

		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetParentOfChild(value, _typeParameters); }
		}

		private UnifiedTypeCollection _throws;

		public UnifiedTypeCollection Throws {
			get { return _throws; }
			set { _throws = SetParentOfChild(value, _throws); }
		}

		private UnifiedConstructorDefinition() {}

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
			yield return Parameters;
			yield return TypeParameters;
			yield return Throws;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Annotations, v => Annotations = (UnifiedAnnotationCollection)v);
			yield return ElementReference.Create
					(() => Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return ElementReference.Create
					(() => Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return ElementReference.Create
					(
							() => TypeParameters,
							v => TypeParameters = (UnifiedTypeParameterCollection)v);
			yield return ElementReference.Create
					(() => Throws, v => Throws = (UnifiedTypeCollection)v);
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
					(() => _parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return ElementReference.Create
					(
							() => _typeParameters,
							v => _typeParameters = (UnifiedTypeParameterCollection)v)
					;
			yield return ElementReference.Create
					(() => _throws, v => _throws = (UnifiedTypeCollection)v);
			yield return ElementReference.Create
					(() => _body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedConstructorDefinition Create() {
			return new UnifiedConstructorDefinition();
		}

		public static UnifiedConstructorDefinition Create(UnifiedBlock body) {
			return new UnifiedConstructorDefinition {
					Body = body,
			};
		}

		public static UnifiedConstructorDefinition Create(
				UnifiedBlock body,
				UnifiedModifier modifier,
				UnifiedParameterCollection
						parameters,
				UnifiedConstructorDefinitionKind
						kind) {
			return Create(
					body, UnifiedModifierCollection.Create(modifier), parameters,
					null, null,
					kind);
		}

		public static UnifiedConstructorDefinition Create(
				UnifiedBlock body,
				UnifiedModifier modifier,
				UnifiedParameterCollection
						parameters) {
			return Create(
					body, UnifiedModifierCollection.Create(modifier), parameters,
					null, null,
					UnifiedConstructorDefinitionKind.Constructor);
		}

		public static UnifiedConstructorDefinition Create(
				UnifiedBlock body,
				UnifiedModifierCollection
						modifier,
				UnifiedParameterCollection
						parameters) {
			return Create(
					body, modifier, parameters, null, null,
					UnifiedConstructorDefinitionKind.Constructor);
		}

		public static UnifiedConstructorDefinition Create(
				UnifiedBlock body,
				UnifiedModifierCollection
						modifiers,
				UnifiedParameterCollection
						parameters,
				UnifiedTypeParameterCollection
						typeParameters,
				UnifiedTypeCollection throws,
				UnifiedConstructorDefinitionKind
						kind) {
			return new UnifiedConstructorDefinition {
					Body = body,
					Modifiers = modifiers,
					Parameters = parameters,
					TypeParameters = typeParameters,
					Throws = throws,
					Kind = kind,
			};
		}

		public static IUnifiedExpression Create(UnifiedBlock body, UnifiedAnnotationCollection annotations, UnifiedModifierCollection modifiers, UnifiedParameterCollection parameters, UnifiedTypeParameterCollection typeParameters, UnifiedTypeCollection throws, UnifiedConstructorDefinitionKind kind) {
			return new UnifiedConstructorDefinition {
					Body = body,
					Modifiers = modifiers,
					Parameters = parameters,
					TypeParameters = typeParameters,
					Throws = throws,
					Kind = kind,
			};
		}
			}
}