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
	///   
	/// </summary>
	public class UnifiedIdentifierCollection
			: UnifiedElementCollection
			  		<UnifiedIdentifier, UnifiedIdentifierCollection>,
			  IUnifiedIdentifierOrCollection {
		private UnifiedIdentifierCollection() {}

		private UnifiedIdentifierCollection(
				IEnumerable<UnifiedIdentifier> elements)
				: base(elements) {}

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

		public static UnifiedIdentifierCollection Create() {
			return new UnifiedIdentifierCollection();
		}

		public static UnifiedIdentifierCollection Create(
				params UnifiedIdentifier[] elements) {
			return new UnifiedIdentifierCollection(elements);
		}

		public static UnifiedIdentifierCollection Create(
				IEnumerable<UnifiedIdentifier> elements) {
			return new UnifiedIdentifierCollection(elements);
		}
			  }
}