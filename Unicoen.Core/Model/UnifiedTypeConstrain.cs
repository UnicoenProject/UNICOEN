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
	///   継承関係やデフォルトコンストラクタの存在などの制約を表します。
	///   なお、継承関係を表す場合、対象の型の個数は１つです。
	///   e.g. Javaにおける継承関係の制約(<c>class C extends P { ... }</c>の<c>extends P</c>部分)
	///   e.g. C#におけるデフォルトコンストラクタの制約(<c>where A : new()</c>の<c>: new()</c>部分)
	/// </summary>
	public class UnifiedTypeConstrain : UnifiedElement {
		/// <summary>
		///   制約の種類を表します
		///   e.g. Javaにおける<c>class C extends P { ... }</c>の<c>extends</c>
		/// </summary>
		public UnifiedTypeConstrainKind Kind { get; set; }

		private UnifiedType _type;

		/// <summary>
		///   制約の対象を表します
		///   e.g. Javaにおける<c>class C extends P { ... }</c>の<c>P</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedTypeConstrain() {}

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
			yield return Type;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _type, v => _type = (UnifiedType)v);
		}

		public static UnifiedTypeConstrain Create(
				UnifiedType type,
				UnifiedTypeConstrainKind kind) {
			return new UnifiedTypeConstrain {
					Type = type,
					Kind = kind,
			};
		}

		public static UnifiedTypeConstrain CreateExtends(UnifiedType type) {
			return Create(type, UnifiedTypeConstrainKind.Extends);
		}

		public static UnifiedTypeConstrain CreateImplements(UnifiedType type) {
			return Create(type, UnifiedTypeConstrainKind.Implements);
		}

		public static UnifiedTypeConstrain CreateExtendsOrImplements(UnifiedType type) {
			return Create(type, UnifiedTypeConstrainKind.ExtendsOrImplements);
		}
	}
}