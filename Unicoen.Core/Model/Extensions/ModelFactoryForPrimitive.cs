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

namespace Unicoen.Core.Model {
	public static class ModelFactoryForPrimitive {
		public static UnifiedIdentifier ToThisIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.This);
		}

		public static UnifiedIdentifier ToSuperIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Super);
		}

		public static UnifiedIdentifier ToClassObjectIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.ClassObject);
		}

		public static UnifiedIdentifier ToUnknownIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Unknown);
		}

		public static UnifiedIdentifier ToVariableIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable);
		}

		public static UnifiedIdentifier ToTypeIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Type);
		}

		public static UnifiedIdentifier ToFunctionIdentifier(this string name) {
			return UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Function);
		}

		public static DeprecatedUnifiedVariableDefinition ToVariableDefinition(
				this string name) {
			return DeprecatedUnifiedVariableDefinition.CreateSingle(name);
		}

		public static DeprecatedUnifiedVariableDefinition ToVariableDefinition(
				this string name,
				UnifiedType type) {
			return DeprecatedUnifiedVariableDefinition.CreateSingle(type, name);
		}

		public static DeprecatedUnifiedVariableDefinition ToVariableDefinition(
				this string name,
				IUnifiedExpression
						initialValue) {
			return DeprecatedUnifiedVariableDefinition.CreateSingle(name, initialValue);
		}

		public static DeprecatedUnifiedVariableDefinition ToVariableDefinition(
				this string name,
				UnifiedType type,
				IUnifiedExpression
						initialValue) {
			return DeprecatedUnifiedVariableDefinition.CreateSingle(
					type, name, initialValue);
		}

		public static UnifiedType ToType(this string name) {
			return UnifiedType.Create(name);
		}

		public static UnifiedClassDefinition ToClassDefinition(this string name) {
			return UnifiedClassDefinition.CreateClass(name);
		}

		public static UnifiedBooleanLiteral ToLiteral(this bool literal) {
			return UnifiedBooleanLiteral.Create(literal);
		}

		public static UnifiedIntegerLiteral ToLiteral(this int value) {
			return UnifiedIntegerLiteral.Create(value);
		}

		public static UnifiedFractionLiteral ToLiteral(this double value) {
			return UnifiedFractionLiteral.CreateDouble(value);
		}
	}
}