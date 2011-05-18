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
	///   クラスの定義部分を表します。
	///   e.g. Javaにおける<c>public class A{....}</c>
	/// </summary>
	public class UnifiedClassDefinition
			: UnifiedExpressionWithBlock<UnifiedClassDefinition> {
		/// <summary>
		///   種類を表します．
		/// </summary>
		public UnifiedClassKind Kind { get; set; }

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
		///   クラスの修飾子の集合を表します
		///   <c>public class A{....}</c>の<c>public</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private IUnifiedExpression _name;

		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		// generics とか
		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetParentOfChild(value, _typeParameters); }
		}

		// 継承とか
		private UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetParentOfChild(value, _constrains); }
		}

		private UnifiedClassDefinition() {}

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

		public static UnifiedClassDefinition CreateClass(string name) {
			return Create(UnifiedClassKind.Class, UnifiedModifierCollection.Create(), UnifiedIdentifier.CreateType(name), null, null, UnifiedBlock.Create());
		}

		public static UnifiedClassDefinition CreateClass(
				string name,
				UnifiedBlock body) {
			return Create(UnifiedClassKind.Class, UnifiedModifierCollection.Create(), UnifiedIdentifier.CreateType(name), null, null, body);
		}

		public static UnifiedClassDefinition CreateClass(
				string name,
				UnifiedTypeConstrainCollection contrains,
				UnifiedBlock body) {
			return Create(UnifiedClassKind.Class, UnifiedModifierCollection.Create(), UnifiedIdentifier.CreateType(name), null, contrains, body);
		}

		public static UnifiedClassDefinition Create(
				UnifiedClassKind kind, UnifiedModifierCollection modifiers,
				IUnifiedExpression name, UnifiedTypeParameterCollection typeParameters,
				UnifiedTypeConstrainCollection constrains, UnifiedBlock body) {
			return Create(kind, null, modifiers, name, typeParameters, constrains, body);
		}

		public static UnifiedClassDefinition Create(
				UnifiedClassKind kind, UnifiedAnnotationCollection annotations, UnifiedModifierCollection modifiers,
				IUnifiedExpression name, UnifiedTypeParameterCollection typeParameters,
				UnifiedTypeConstrainCollection constrains, UnifiedBlock body) {
			return new UnifiedClassDefinition {
					Annotations = annotations,
					Modifiers = modifiers,
					Kind = kind,
					Name = name,
					TypeParameters = typeParameters,
					Constrains = constrains,
					Body = body,
			};
		}

		public static UnifiedClassDefinition CreateNamespace(IUnifiedExpression name) {
			return Create(UnifiedClassKind.Namespace, null, name, null, null, UnifiedBlock.Create());
		}

		public static UnifiedClassDefinition CreateAnnotation(IUnifiedExpression name) {
			return Create(UnifiedClassKind.Namespace, null, name, null, null, UnifiedBlock.Create());
		}

		public static UnifiedClassDefinition CreateAnnotation(UnifiedAnnotationCollection annotations, UnifiedModifierCollection modifiers, UnifiedIdentifier name, UnifiedBlock body) {
			return Create(UnifiedClassKind.Annotation, annotations, modifiers, name, null, null, body);
		}

		public static UnifiedClassDefinition CreateClass(UnifiedModifierCollection modifiers, string name, UnifiedTypeParameterCollection typeParameters, UnifiedTypeConstrainCollection constrains, UnifiedBlock body) {
			return Create(UnifiedClassKind.Class, modifiers, UnifiedIdentifier.CreateType(name), typeParameters, constrains, body);
		}

		public static UnifiedClassDefinition CreateClass(UnifiedAnnotationCollection annotations, UnifiedModifierCollection modifiers, string name, UnifiedTypeParameterCollection typeParameters, UnifiedTypeConstrainCollection constrains, UnifiedBlock body) {
			return Create(UnifiedClassKind.Class, modifiers, UnifiedIdentifier.CreateType(name), typeParameters, constrains, body);
		}
			}
}