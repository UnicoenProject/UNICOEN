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
using System.Linq;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   仮引数(パラメータ)を表します。
	///   e.g. Javaにおける<code>public void method(int a)</code>の<code>int a</code>
	/// </summary>
	public class UnifiedParameter : UnifiedElement {
		private UnifiedModifierCollection _modifiers;

		/// <summary>
		///   仮引数の修飾子を表します
		/// </summary>
		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   仮引数の型を表します。
		///   e.g. Javaにおける<code>public void method(int a)</code>の<code>int</code>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private IUnifiedIdentifierOrCollection _name;

		/// <summary>
		///   仮引数の引数名を表します。
		///   e.g. Javaにおける<code>method(int a)</code>の<code>a</code>
		/// </summary>
		public IUnifiedIdentifierOrCollection Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private IUnifiedExpression _defaultValue;

		/// <summary>
		///   仮引数のデフォルト値を表します。
		///   e.g. C#における<code>method(int a = 0)</code>の<code>0</code>
		/// </summary>
		public IUnifiedExpression DefaultValue {
			get { return _defaultValue; }
			set { _defaultValue = SetParentOfChild(value, _defaultValue); }
		}

		private UnifiedParameter() {
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
			yield return Name;
			yield return DefaultValue;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Type, v => Type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (IUnifiedIdentifierOrCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(DefaultValue, v => DefaultValue = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (IUnifiedIdentifierOrCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_defaultValue, v => _defaultValue = (IUnifiedExpression)v);
		}

		public static UnifiedParameter Create(
				UnifiedModifierCollection modifiers, UnifiedType type,
				IUnifiedIdentifierOrCollection name, IUnifiedExpression defaultValue) {
			return new UnifiedParameter {
					Modifiers = modifiers,
					Type = type,
					Name = name,
					DefaultValue = defaultValue,
			};
		}

		public static UnifiedParameter Create(
				UnifiedModifierCollection modifiers, UnifiedType type,
				IEnumerable<string> names, IUnifiedExpression defaultValue) {
			return Create(
					modifiers, type,
					names.Select(UnifiedIdentifier.CreateVariable).ToCollection(), defaultValue);
		}

		public static UnifiedParameter Create(
				UnifiedModifierCollection modifiers, UnifiedType type, string name,
				IUnifiedExpression defaultValue) {
			return Create(
					modifiers, type, UnifiedIdentifier.CreateVariable(name), defaultValue);
		}

		public static UnifiedParameter Create(string name) {
			return Create(null, null, name, null);
		}

		public static UnifiedParameter Create(string name, UnifiedType type) {
			return Create(null, type, name, null);
		}

		public static UnifiedParameter Create(
				UnifiedModifierCollection modifiers, UnifiedType type, string name) {
			return Create(modifiers, type, name, null);
		}
	}
}