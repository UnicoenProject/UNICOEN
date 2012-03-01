#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

namespace Unicoen.Model {
	public abstract class UnifiedType : UnifiedExpression {
		/// <summary>
		///   型の基礎部分の名前を表します． e.g. Javaにおける <c>Package.ClassA instance = null;</c> の <c>Package.ClassA</c> (UnifiedPropertyで表現される) e.g. Javaにおける <c>ArrayList&lt;Integer&gt;</c> の <c>ArrayList</c>
		/// </summary>
		public abstract UnifiedExpression BasicTypeName { get; set; }

		public static UnifiedType Create(string name) {
			// new[] の場合，NameExpressionがnullなUnifiedSimpleTypeを生成する．
			return new UnifiedBasicType {
					BasicTypeName = name != null
					                		? UnifiedVariableIdentifier.Create(
					                				name)
					                		: null,
			};
		}

		public static UnifiedType Create(
				UnifiedExpression basicExpression = null) {
			return new UnifiedBasicType {
					BasicTypeName = basicExpression,
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

		public UnifiedType WrapArray(UnifiedArgument argument = null) {
			return new UnifiedArrayType {
					Type = this,
					// argumentがnullの場合でもコレクションの要素にしたいため
					Arguments = Enumerable.Repeat(argument, 1).ToCollection(),
			};
		}

		public UnifiedType WrapRectangleArray(int dimension) {
			Contract.Requires(dimension >= 1);
			return new UnifiedArrayType {
					Type = this,
					Arguments =
							Enumerable.Repeat<UnifiedArgument>(null, dimension).
									ToCollection(),
			};
		}

		public UnifiedType WrapRectangleArray(
				UnifiedArgumentCollection arguments = null) {
			return new UnifiedArrayType {
					Type = this,
					Arguments = arguments,
			};
		}

		public UnifiedType WrapGeneric(
				UnifiedGenericArgumentCollection arguments = null) {
			return new UnifiedGenericType {
					Type = this,
					Arguments = arguments,
			};
		}

		public UnifiedType WrapPointer() {
			return new UnifiedPointerType {
					Type = this,
			};
		}

		public UnifiedType WrapReference() {
			return new UnifiedReferenceType {
					Type = this,
			};
		}

		public UnifiedType WrapConst() {
			return new UnifiedConstType {
					Type = this,
			};
		}

		public UnifiedType WrapVolatile() {
			return new UnifiedVolatileType {
					Type = this,
			};
		}

		public UnifiedType WrapUnion() {
			return new UnifiedUnionType {
					Type = this,
			};
		}

		public UnifiedType WrapStruct() {
			return new UnifiedStructType {
					Type = this,
			};
		}
	}
}