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
	///   変数宣言部分を表します。
	///   e.g. Javaにおける<c>int[] a[][], b[], c;</c>
	/// </summary>
	public class UnifiedVariableDefinition : UnifiedElement, IUnifiedExpression {
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		/// 変数に付随する修飾子の集合を表します
		/// e.g. Javaにおける<c>public static int a</c>の<c>public static</c>
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		/// 変数の型を表します
		/// e.g. Javaにおける<c>public static int a</c>の<c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedVariableDefinitionBodyCollection _bodys;

		public UnifiedVariableDefinitionBodyCollection Bodys {
			get { return _bodys; }
			set { _bodys = SetParentOfChild(value, _bodys); }
		}

		private UnifiedVariableDefinition() {
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
			yield return Type;
			yield return Bodys;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Bodys, v => Bodys = (UnifiedVariableDefinitionBodyCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_bodys, v => _bodys = (UnifiedVariableDefinitionBodyCollection)v);
		}

		public static UnifiedVariableDefinition CreateSingle(string name) {
			return CreateSingle(
					null,
					null,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					null,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				UnifiedType type,
				string name) {
			return CreateSingle(
					null,
					type,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					null,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				string name,
				IUnifiedExpression
						initialValue) {
			return CreateSingle(
					null,
					null,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					initialValue,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				UnifiedType type,
				string name,
				IUnifiedExpression
						initialValue) {
			return CreateSingle(
					null,
					type,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					initialValue,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				UnifiedType type,
				UnifiedModifierCollection
						modifiers,
				IUnifiedExpression
						initialValue,
				string name) {
			return CreateSingle(
					modifiers,
					type,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					initialValue,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				UnifiedType type,
				string name,
				UnifiedModifierCollection
						modifiers) {
			return CreateSingle(
					modifiers,
					type,
					UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
					null,
					null,
					null);
		}

		public static UnifiedVariableDefinition CreateSingle(
				UnifiedModifierCollection modifiers,
				UnifiedType type,
				UnifiedIdentifier name,
				IUnifiedExpression initialValues,
				UnifiedArgumentCollection arguments,
				UnifiedBlock block) {
			return Create(
					modifiers,
					type,
					UnifiedVariableDefinitionBody.Create(
							name,
							null,
							initialValues,
							arguments,
							block).ToCollection()
					);
		}

		public static UnifiedVariableDefinition Create(
				UnifiedModifierCollection modifiers,
				UnifiedType type,
				UnifiedVariableDefinitionBodyCollection bodys) {
			return new UnifiedVariableDefinition {
					Modifiers = modifiers,
					Type = type,
					Bodys = bodys,
			};
		}
	}
}