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
	///   ラベル式を表します。
	///   e.g. Javaにおける<c>loop: while(cond){ ... }</c>の<c>loop</c>の部分
	/// </summary>
	public class UnifiedLabel : UnifiedElement, IUnifiedExpression {
		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedLabel() {}

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
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield return ElementReference.Create
					(() => Name, v => Name = (UnifiedIdentifier)v);
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield return ElementReference.Create
					(() => _name, v => _name = (UnifiedIdentifier)v);
		}

		public static IUnifiedExpression Create(string value) {
			return new UnifiedLabel {
					Name = UnifiedIdentifier.CreateUnknown(value),
			};
		}
	}
}