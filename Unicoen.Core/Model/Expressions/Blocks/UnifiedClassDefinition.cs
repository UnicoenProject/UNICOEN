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
	///   クラスの定義部分を表します。
	///   e.g. Javaにおける<c>public class A{....}</c>
	/// </summary>
	public class UnifiedClassDefinition
			: UnifiedExpressionWithBlock<UnifiedClassDefinition> {
		public UnifiedClassKind Kind { get; set; }

		
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		/// クラスの修飾子の集合を表します
		/// <c>public class A{....}</c>の<c>public</c>
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

		private UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetParentOfChild(value, _typeParameters); }
		}

		private UnifiedTypeConstrainCollection _constrains;

		public UnifiedTypeConstrainCollection Constrains {
			get { return _constrains; }
			set { _constrains = SetParentOfChild(value, _constrains); }
		}

		private UnifiedClassDefinition() {
			Modifiers = UnifiedModifierCollection.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Name;
			yield return TypeParameters;
			yield return Constrains;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(TypeParameters, v => TypeParameters = (UnifiedTypeParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Constrains, v => Constrains = (UnifiedTypeConstrainCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_typeParameters, v => _typeParameters = (UnifiedTypeParameterCollection)v)
					;
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_constrains, v => _constrains = (UnifiedTypeConstrainCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedClassDefinition Create(
				IUnifiedExpression name,
				UnifiedBlock body,
				UnifiedModifierCollection
						modifiers, UnifiedClassKind kind) {
			return new UnifiedClassDefinition {
					Body = body,
					Name = name,
					Modifiers = modifiers,
					Kind = kind,
			};
		}

		public static UnifiedClassDefinition CreateClass(string name) {
			return Create(
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Type),
					UnifiedBlock.Create(), UnifiedModifierCollection.Create(),
					UnifiedClassKind.Class);
		}

		public static UnifiedClassDefinition CreateClass(
				string name,
				UnifiedBlock body) {
			return Create(
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Type),
					body, UnifiedModifierCollection.Create(), UnifiedClassKind.Class);
		}

		public static UnifiedClassDefinition Create(
				UnifiedModifierCollection modifiers, UnifiedClassKind kind,
				IUnifiedExpression name,
				UnifiedTypeParameterCollection typeParameters,
				UnifiedTypeConstrainCollection constrains, UnifiedBlock body) {
			return new UnifiedClassDefinition {
					Modifiers = modifiers,
					Kind = kind,
					Name = name,
					TypeParameters = typeParameters,
					Constrains = constrains,
					Body = body,
			};
		}

		public static UnifiedClassDefinition CreateNamespace(IUnifiedExpression name) {
			return Create(name, UnifiedBlock.Create(), null, UnifiedClassKind.Namespace);
		}
			}
}