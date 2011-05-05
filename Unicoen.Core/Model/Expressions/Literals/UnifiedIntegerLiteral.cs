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
using System.Numerics;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   整数のリテラルを表します。
	///   e.g. Javaにおける<c>int i = 10;</c>の<c>10</c>の部分
	/// </summary>
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		private UnifiedIntegerLiteral() {}

		public UnifiedIntegerLiteralKind Kind { get; set; }

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

		public static UnifiedIntegerLiteral Create(
				BigInteger value, UnifiedIntegerLiteralKind kind) {
			return new UnifiedIntegerLiteral {
					Value = value,
					Kind = kind,
			};
		}

		public static UnifiedIntegerLiteral Create(int value) {
			return Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedIntegerLiteral CreateInt32(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedIntegerLiteral Create(long value) {
			return Create(value, UnifiedIntegerLiteralKind.Int64);
		}

		public static UnifiedIntegerLiteral CreateInt64(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.Int64);
		}

		public static UnifiedIntegerLiteral Create(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.BigInteger);
		}

		public static UnifiedIntegerLiteral CreateBigInteger(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.BigInteger);
		}
	}
}