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
using System.Collections;
using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   識別子を表します。
	/// </summary>
	public class UnifiedIdentifier
			: UnifiedElement, IUnifiedExpression, IUnifiedIdentifierOrCollection {
		/// <summary>
		/// </summary>
		public string Value { get; set; }

		public UnifiedIdentifierKind Kind { get; set; }

		private UnifiedIdentifier() {}

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
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield break;
		}

		public IEnumerable<UnifiedIdentifier> GetIdentifiers() {
			yield return this;
		}

		private static UnifiedIdentifier Create(
				string name, UnifiedIdentifierKind kind) {
			return new UnifiedIdentifier {
					Value = name,
					Kind = kind
			};
		}

		public static UnifiedIdentifier CreateThis(string name) {
			return Create(name, UnifiedIdentifierKind.This);
		}

		public static UnifiedIdentifier CreateSuper(string name) {
			return Create(name, UnifiedIdentifierKind.Super);
		}

		public static UnifiedIdentifier CreateClassObject(string name) {
			return Create(name, UnifiedIdentifierKind.ClassObject);
		}

		public static UnifiedIdentifier CreateUnknown(string name) {
			return Create(name, UnifiedIdentifierKind.Unknown);
		}

		public static UnifiedIdentifier CreateVariable(string name) {
			return Create(name, UnifiedIdentifierKind.Variable);
		}

		public static UnifiedIdentifier CreateType(string name) {
			return Create(name, UnifiedIdentifierKind.Type);
		}

		public static UnifiedIdentifier CreateFunction(string name) {
			return Create(name, UnifiedIdentifierKind.Function);
		}
			}
}