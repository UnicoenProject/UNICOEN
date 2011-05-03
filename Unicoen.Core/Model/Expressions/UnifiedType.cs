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
	///   型を表します。
	///   Javaにおける<c>int, double, char</c>
	/// </summary>
	public class UnifiedType : UnifiedElement, IUnifiedExpression {
		// パッケージ名が付いているときに
		// UnifiedProperty が name に入る時があるので
		private IUnifiedExpression _name;

		/// <summary>
		///   型の名前を表します．
		///   e.g. Javaにおける<c>Package.ClassA instance = null;</c>の<c>Package.ClassA</c>(UnifiedPropertyで表現される)
		/// </summary>
		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedTypeArgumentCollection _arguments;

		/// <summary>
		///   ジェネリックタイプにおける実引数の集合を表します
		///   e.g. Javaにおける<c>HashMap&ltInteger, String&gt</c>の<c>Integer, String</c>
		/// </summary>
		public UnifiedTypeArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedTypeSupplementCollection _supplements;

		/// <summary>
		///   Javaにおける<c>int[10] a;</c>の<c>[10]</c>部分、
		///   Cにおける<c>int** a;</c>の<c>**</c>部分、
		///   <c>int[] a;</c>の<c>[]</c>部分などが該当します。
		/// </summary>
		public UnifiedTypeSupplementCollection Supplements {
			get { return _supplements; }
			set { _supplements = SetParentOfChild(value, _supplements); }
		}

		private UnifiedType() {}

		public UnifiedType AddToParameters(IUnifiedExpression expression) {
			Arguments.Add(expression.ToTypeParameter());
			return this;
		}

		public UnifiedType AddToParameters(UnifiedTypeArgument argument) {
			Arguments.Add(argument);
			return this;
		}

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
			yield return Name;
			yield return Arguments;
			yield return Supplements;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Arguments, v => Arguments = (UnifiedTypeArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Supplements, v => Supplements = (UnifiedTypeSupplementCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_arguments, v => _arguments = (UnifiedTypeArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_supplements, v => _supplements = (UnifiedTypeSupplementCollection)v);
		}

		public void AddSupplement(UnifiedTypeSupplement supplement) {
			if (Supplements == null)
				Supplements = UnifiedTypeSupplementCollection.Create();
			Supplements.Add(supplement);
		}

		public void AddSupplementRange(IEnumerable<UnifiedTypeSupplement> supplements) {
			if (Supplements == null)
				Supplements = UnifiedTypeSupplementCollection.Create();
			Supplements.AddRange(supplements);
		}

		public static UnifiedType CreateUsingString(string name) {
			return CreateUsingString(name, null, null);
		}

		public static UnifiedType CreateUsingString(
				string name,
				UnifiedTypeArgumentCollection
						arguments) {
			return CreateUsingString(name, arguments, null);
		}

		public static UnifiedType CreateUsingString(
				string name,
				UnifiedTypeArgumentCollection
						arguments,
				UnifiedTypeSupplementCollection
						supplements) {
			return new UnifiedType {
					Name = name != null
					       		? UnifiedIdentifier.CreateType(name)
					       		: null,
					Arguments = arguments,
					Supplements = supplements,
			};
		}

		public static UnifiedType Create(
			IUnifiedExpression name) {
			return Create(name, null, null);
		}

		public static UnifiedType Create(
				IUnifiedExpression name,
				UnifiedTypeArgumentCollection arguments,
				UnifiedTypeSupplementCollection supplements) {
			return new UnifiedType {
					Name = name,
					Arguments = arguments,
					Supplements = supplements,
			};
		}

		public static UnifiedType CreateArray(string name) {
			return CreateUsingString(
					name, null, UnifiedTypeSupplementCollection.Create(
							UnifiedTypeSupplement.CreateArray()));
		}

		public static UnifiedType CreateArray(string name, UnifiedArgument argument) {
			return new UnifiedType {
					Name = name != null
					       		? UnifiedIdentifier.CreateType(name)
					       		: null,
					Arguments = null,
					Supplements = UnifiedTypeSupplementCollection.Create(
							UnifiedTypeSupplement.CreateArray(argument)),
			};
		}
	}
}