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

using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Core.Model {
	public abstract class UnifiedType : UnifiedElement, IUnifiedExpression {
		public abstract IUnifiedExpression NameExpression { get; set; }

		public static UnifiedSimpleType Create(string name) {
			// new[] の場合，NameExpressionがnullなUnifiedSimpleTypeを生成する．
			return new UnifiedSimpleType {
					NameExpression = name != null
					                 		? UnifiedIdentifier.Create(UnifiedIdentifierKind.Type, name)
					                 		: null,
			};
		}

		public static UnifiedSimpleType Create(
				IUnifiedExpression nameExpression = null) {
			return new UnifiedSimpleType {
					NameExpression = nameExpression,
			};
		}

		public UnifiedType WrapArrayRepeatedly(int count) {
			Contract.Requires(count >= 0);
			var type = this;
			for (int i = 0; i < count; i++) {
				type = type.WrapArray();
			}
			return type;
		}

		public UnifiedArrayType WrapArray(UnifiedArgument argument = null) {
			return new UnifiedArrayType {
					Type = this,
					Arguments = argument.ToCollection(),
			};
		}

		public UnifiedArrayType WrapRectangleArray(int dimension) {
			Contract.Requires(dimension >= 1);
			return new UnifiedArrayType {
					Type = this,
					Arguments =
							Enumerable.Repeat<UnifiedArgument>(null, dimension).ToCollection(),
			};
		}

		public UnifiedArrayType WrapRectangleArray(
				UnifiedArgumentCollection arguments = null) {
			return new UnifiedArrayType {
					Type = this,
					Arguments = arguments,
			};
		}

		public UnifiedGenericType WrapGeneric(
				UnifiedTypeArgumentCollection arguments = null) {
			return new UnifiedGenericType {
					Type = this,
					Arguments = arguments,
			};
		}

		public UnifiedSupplementType WrapPointer() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Pointer,
			};
		}

		public UnifiedSupplementType WrapReference() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Reference,
			};
		}

		public UnifiedSupplementType WrapConst() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Const,
			};
		}

		public UnifiedSupplementType WrapVolatile() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Volatile,
			};
		}

		public UnifiedSupplementType WrapUnion() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Union,
			};
		}

		public UnifiedSupplementType WrapStruct() {
			return new UnifiedSupplementType {
					Type = this,
					Kind = UnifiedSupplementTypeKind.Struct,
			};
		}
	}
}