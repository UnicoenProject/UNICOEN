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
	///   3項演算子を表します
	///   e.g. Javaにおける<c>a ? b : c</c>
	/// </summary>
	public class UnifiedTernaryOperator : UnifiedElement {
		/// <summary>
		///   最初の識別子を表します
		///   e.g. Javaにおける<c>a ? b : c</c>の<c>?</c>
		/// </summary>
		public string FirstSign { get; private set; }

		/// <summary>
		///   2番目の識別子を表します
		///   e.g. Javaにおける<c>a ? b : c</c>の<c>:</c>
		/// </summary>
		public string SecondSign { get; private set; }

		/// <summary>
		///   三項演算子の種類を表します
		/// </summary>
		public UnifiedTernaryOperatorKind Kind { get; private set; }

		private UnifiedTernaryOperator() {}

		public static UnifiedTernaryOperator Create(
				string first, string second,
				UnifiedTernaryOperatorKind kind) {
			return new UnifiedTernaryOperator {
					FirstSign = first,
					SecondSign = second,
					Kind = kind,
			};
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
				GetElementReferences() {
			yield break;
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield break;
		}
	}
}