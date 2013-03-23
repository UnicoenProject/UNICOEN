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
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Unicoen.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ProgramGenerators {
	public static partial class CProgramGeneratorHelper {
		// Operator
		public static UnifiedElement CreateUnaryOperator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unary_operator");
			/*
			unary_operator
			: '&'
			| '*'
			| '+'
			| '-'
			| '~'
			| '!'
			 */
			UnifiedUnaryOperatorKind kind;
			switch (node.Value) {
			case "&":
				kind = UnifiedUnaryOperatorKind.Address;
				break;
			case "*":
				kind = UnifiedUnaryOperatorKind.Indirect;
				break;
			case "+":
				kind = UnifiedUnaryOperatorKind.UnaryPlus;
				break;
			case "-":
				kind = UnifiedUnaryOperatorKind.Negate;
				break;
			case "~":
				kind = UnifiedUnaryOperatorKind.OnesComplement;
				break;
			case "!":
				kind = UnifiedUnaryOperatorKind.Not;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedUnaryOperator.Create(node.Value, kind);
		}

		public static UnifiedBinaryOperator CreateAssignmentOperator(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_operator");
			/*
			assignment_operator
			: '='
			| '*='
			| '/='
			| '%='
			| '+='
			| '-='
			| '<<='
			| '>>='
			| '&='
			| '^='
			| '|='
			 */

			UnifiedBinaryOperatorKind kind;
			switch (node.Value) {
			case "=":
				kind = UnifiedBinaryOperatorKind.Assign;
				break;
			case "*=":
				kind = UnifiedBinaryOperatorKind.MultiplyAssign;
				break;
			case "/=":
				kind = UnifiedBinaryOperatorKind.DivideAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			case "+=":
				kind = UnifiedBinaryOperatorKind.AddAssign;
				break;
			case "-=":
				kind = UnifiedBinaryOperatorKind.SubtractAssign;
				break;
			case "<<=":
				kind = UnifiedBinaryOperatorKind.LogicalLeftShiftAssign;
				break;
			case ">>=":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign;
				break;
			case "&=":
				kind = UnifiedBinaryOperatorKind.AndAssign;
				break;
			case "^=":
				kind = UnifiedBinaryOperatorKind.ExclusiveOrAssign;
				break;
			case "|=":
				kind = UnifiedBinaryOperatorKind.OrAssign;
				break;
			default:
				throw new InvalidOperationException();
			}

			return UnifiedBinaryOperator.Create(node.Value, kind);
		}
	}
}