﻿#region License

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
	///   Cにおける<c>int** a;</c>の<c>**</c>部分、
	/// </summary>
	public class UnifiedSupplementType : UnifiedWrapType {
		public UnifiedSupplementTypeKind Kind { get; set; }
		internal UnifiedSupplementType() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TState>(
				IUnifiedModelVisitor<TState> visitor, TState state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TState, TResult>(
				IUnifiedModelVisitor<TState, TResult> visitor, TState state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Type;
		}

		public override IEnumerable<ElementReference> GetElementReferences() {
			yield return ElementReference.Create(() => Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<ElementReference> GetElementReferencesOfFields() {
			yield return
					ElementReference.Create(() => _type, v => _type = (UnifiedType)v);
		}
	}
}