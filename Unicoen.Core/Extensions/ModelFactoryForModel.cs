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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Model {
	public static class ProgramGeneratorForModel {
		public static UnifiedArgument ToArgument(
				this UnifiedExpression expression) {
			return UnifiedArgument.Create(expression);
		}

		public static UnifiedParameter ToParameter(
				this UnifiedIdentifier expression) {
			return UnifiedParameter.Create(
					null, null, null, expression.ToSet());
		}

		public static UnifiedParameter ToParameter(
				this UnifiedIdentifier expression, UnifiedType type) {
			return UnifiedParameter.Create(
					null, null, type, expression.ToSet());
		}

		public static UnifiedExpression ToProperty(
				this IEnumerable<UnifiedExpression> expressions,
				string delimiter) {
			return expressions.ToList().ToProperty(delimiter);
		}

		public static UnifiedExpression ToProperty(
				this IList<UnifiedExpression> expressions, string delimiter) {
			Contract.Requires<ArgumentNullException>(expressions != null);
			Contract.Requires<ArgumentException>(expressions.Count >= 1);
			if (expressions.Count == 1) {
				return expressions[0];
			}
			return expressions.Skip(1).Aggregate(
					expressions[0],
					(l, r) => UnifiedProperty.Create(delimiter, l, r));
		}
	}
}