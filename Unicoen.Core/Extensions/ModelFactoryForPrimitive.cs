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

namespace Unicoen.Core.Model {
	public static class ModelFactoryForPrimitive {
		public static UnifiedIdentifier ToVariableIdentifier(this string name) {
			return UnifiedVariableIdentifier.Create(name);
		}

		public static UnifiedBooleanLiteral ToLiteral(this bool literal) {
			return UnifiedBooleanLiteral.Create(literal);
		}

		public static UnifiedIntegerLiteral ToInt64Literal(this long value) {
			return UnifiedIntegerLiteral.Create(value, UnifiedIntegerLiteralKind.Int64);
		}

		public static UnifiedIntegerLiteral ToInt32Literal(this int value) {
			return UnifiedIntegerLiteral.Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedFractionLiteral ToLiteral(this double value) {
			return UnifiedFractionLiteral.Create(
					value, UnifiedFractionLiteralKind.Double);
		}
	}
}