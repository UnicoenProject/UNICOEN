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
	///   boolean型であるリテラルを表します。
	///   e.g. Javaにおける<c>Boolean flag = true;</c>の<c>true</c>の部分
	/// </summary>
	public class UnifiedBooleanLiteral : UnifiedTypedLiteral<bool> {
		private UnifiedBooleanLiteral() {}

		public static UnifiedBooleanLiteral Create(bool value) {
			return new UnifiedBooleanLiteral { Value = value };
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
			yield break;
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield break;
		}
	}
}