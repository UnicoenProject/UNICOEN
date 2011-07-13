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
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Unicoen.Core.Model;

namespace Unicoen.Languages.CSharp.ModelFactories {
	internal partial class NRefactoryModelVisitor {
		#region Lookups

		private static UnifiedModifierCollection LookupModifiers(Modifiers mods) {
			Contract.Ensures(Contract.Result<UnifiedModifierCollection>() != null);

			var pairs = new[] {
					new { Mod = Modifiers.Public, Name = "public" },
					new { Mod = Modifiers.Protected, Name = "protected" },
					new { Mod = Modifiers.Internal, Name = "internal" },
					new { Mod = Modifiers.Abstract, Name = "abstract" },
					new { Mod = Modifiers.Private, Name = "private" },
					new { Mod = Modifiers.Partial, Name = "partial" },
					new { Mod = Modifiers.Static, Name = "static" },
					new { Mod = Modifiers.Sealed, Name = "sealed" },
					new { Mod = Modifiers.Const, Name = "const" },
					new { Mod = Modifiers.Readonly, Name = "readonly" },
					new { Mod = Modifiers.New, Name = "new" },
					new { Mod = Modifiers.Override, Name = "override" },
					new { Mod = Modifiers.Virtual, Name = "virtual" },
					new { Mod = Modifiers.Extern, Name = "extern" },
					new { Mod = Modifiers.Fixed, Name = "fixed" },
					new { Mod = Modifiers.Unsafe, Name = "unsafe" },
					new { Mod = Modifiers.Volatile, Name = "volatile" },
			};
			var uMods =
					from pair in pairs
					where (mods & pair.Mod) != 0
					select UnifiedModifier.Create(pair.Name);
			return UnifiedModifierCollection.Create(uMods);
		}

		private static UnifiedModifier LookupModifier(ParameterModifier mod) {
			switch(mod) {
			case ParameterModifier.Out:
				return UnifiedModifier.Create("out");
			case ParameterModifier.Params:
				return UnifiedModifier.Create("params");
			case ParameterModifier.Ref:
				return UnifiedModifier.Create("ref");
			case ParameterModifier.This:
				return UnifiedModifier.Create("this");
			default:
				return null;
			}
		}

		private static UnifiedType LookupType(AstType type) {
			Contract.Requires<ArgumentNullException>(type != null);
			Contract.Ensures(Contract.Result<UnifiedType>() != null);

			var prim = type as PrimitiveType;
			if (prim != null) {
				return UnifiedType.Create(prim.Keyword);
			}
			var sim = type as SimpleType;
			if (sim != null) {
				return UnifiedType.Create(sim.Identifier);
			}
			var com = type as ComposedType;
			if (com != null) {
				var uType = LookupType(com.BaseType);
				foreach (var aSpec in com.ArraySpecifiers) {
					uType = uType.WrapRectangleArray(aSpec.Dimensions);
				}
				return uType;
			}
			var mem = type as MemberType;
			if (mem != null) {
				var target = LookupType(mem.Target);
				var name = mem.MemberName.ToVariableIdentifier();
				return UnifiedType.Create(UnifiedProperty.Create(".", target, name));
			}
			if (type == AstType.Null) {
				return UnifiedType.Create();
			}

			throw new NotImplementedException("LookupType");
		}

		private static UnifiedBinaryOperator LookupBinaryOperator(BinaryOperatorType op) {
			switch (op) {
			case BinaryOperatorType.Add:
				return UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add);
			case BinaryOperatorType.Subtract:
				return UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract);
			case BinaryOperatorType.Multiply:
				return UnifiedBinaryOperator.Create("*", UnifiedBinaryOperatorKind.Multiply);
			case BinaryOperatorType.Divide:
				return UnifiedBinaryOperator.Create("/", UnifiedBinaryOperatorKind.Divide);
			case BinaryOperatorType.Modulus:
				return UnifiedBinaryOperator.Create("%", UnifiedBinaryOperatorKind.Modulo);

			case BinaryOperatorType.ShiftLeft:
				return UnifiedBinaryOperator.Create("<<", UnifiedBinaryOperatorKind.ArithmeticLeftShift);
			case BinaryOperatorType.ShiftRight:
				return UnifiedBinaryOperator.Create("<<", UnifiedBinaryOperatorKind.ArithmeticRightShift);

			case BinaryOperatorType.BitwiseAnd:
				return UnifiedBinaryOperator.Create("&", UnifiedBinaryOperatorKind.And);
			case BinaryOperatorType.BitwiseOr:
				return UnifiedBinaryOperator.Create("|", UnifiedBinaryOperatorKind.Or);
			case BinaryOperatorType.ExclusiveOr:
				return UnifiedBinaryOperator.Create("|", UnifiedBinaryOperatorKind.ExclusiveOr);

			case BinaryOperatorType.GreaterThan:
				return UnifiedBinaryOperator.Create(">", UnifiedBinaryOperatorKind.GreaterThan);
			case BinaryOperatorType.GreaterThanOrEqual:
				return UnifiedBinaryOperator.Create(">=", UnifiedBinaryOperatorKind.GreaterThanOrEqual);
			case BinaryOperatorType.LessThanOrEqual:
				return UnifiedBinaryOperator.Create("<=", UnifiedBinaryOperatorKind.LessThanOrEqual);
			case BinaryOperatorType.LessThan:
				return UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan);

			case BinaryOperatorType.Equality:
				return UnifiedBinaryOperator.Create("==", UnifiedBinaryOperatorKind.Equal);
			case BinaryOperatorType.InEquality:
				return UnifiedBinaryOperator.Create("!=", UnifiedBinaryOperatorKind.NotEqual);

			case BinaryOperatorType.ConditionalAnd:
				return UnifiedBinaryOperator.Create("&&", UnifiedBinaryOperatorKind.AndAlso);
			case BinaryOperatorType.ConditionalOr:
				return UnifiedBinaryOperator.Create("||", UnifiedBinaryOperatorKind.OrElse);
			}
			throw new NotImplementedException("LookupBinaryOperator");
		}

		private static UnifiedUnaryOperator LookupUnaryOperator(UnaryOperatorType op) {
			switch (op) {
			case UnaryOperatorType.Not:
				return UnifiedUnaryOperator.Create("!", UnifiedUnaryOperatorKind.Not);
			case UnaryOperatorType.BitNot:
				return UnifiedUnaryOperator.Create("!", UnifiedUnaryOperatorKind.OnesComplement);

			case UnaryOperatorType.Plus:
				return UnifiedUnaryOperator.Create("+", UnifiedUnaryOperatorKind.UnaryPlus);
			case UnaryOperatorType.Minus:
				return UnifiedUnaryOperator.Create("-", UnifiedUnaryOperatorKind.Negate);

			case UnaryOperatorType.Increment:
				return UnifiedUnaryOperator.Create("++", UnifiedUnaryOperatorKind.PreIncrementAssign);
			case UnaryOperatorType.PostIncrement:
				return UnifiedUnaryOperator.Create("++", UnifiedUnaryOperatorKind.PostIncrementAssign);
			case UnaryOperatorType.Decrement:
				return UnifiedUnaryOperator.Create("--", UnifiedUnaryOperatorKind.PreDecrementAssign);
			case UnaryOperatorType.PostDecrement:
				return UnifiedUnaryOperator.Create("--", UnifiedUnaryOperatorKind.PostDecrementAssign);
			}
			throw new NotImplementedException("LookupUnaryOperator");
		}

		#endregion
	}

	internal static class VisitorExtension {
		internal static IUnifiedExpression AcceptForExpression(
				this AstNode node, IAstVisitor<IUnifiedElement, object> visitor) {
			return node.AcceptVisitor(visitor, null) as IUnifiedExpression;
		}
	}
}
