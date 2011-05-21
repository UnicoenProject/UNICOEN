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

using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   Cにおける<c>int** a;</c>の<c>**</c>部分、
	/// </summary>
	public class UnifiedSupplementType : UnifiedTypeBase {
		public UnifiedSupplementTypeKind Kind { get; set; }

		private UnifiedTypeBase _type;

		/// <summary>
		///   修飾しているベースとなる型を取得します．
		/// </summary>
		public UnifiedTypeBase Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

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

		public static UnifiedSupplementType CreateConst(UnifiedTypeBase type) {
			return new UnifiedSupplementType {
					Kind = UnifiedSupplementTypeKind.Const,
					Type = type,
			};
		}

		public static UnifiedSupplementType CreatePointer(UnifiedTypeBase type) {
			return new UnifiedSupplementType {
					Kind = UnifiedSupplementTypeKind.Pointer,
					Type = type,
			};
		}

		public static UnifiedSupplementType CreateReference(UnifiedTypeBase type) {
			return new UnifiedSupplementType {
					Kind = UnifiedSupplementTypeKind.Reference,
					Type = type,
			};
		}

		public static UnifiedSupplementType CreateVolatile(UnifiedTypeBase type) {
			return new UnifiedSupplementType {
					Kind = UnifiedSupplementTypeKind.Volatile,
					Type = type,
			};
		}
	}
}