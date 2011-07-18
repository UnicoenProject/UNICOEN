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
using Unicoen.Model;
using System.Collections.Generic;

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
			switch (mod) {
			case ParameterModifier.Out:
				return UnifiedModifier.Create("out");
			case ParameterModifier.Params:
				return UnifiedModifier.Create("params");
			case ParameterModifier.Ref:
				return UnifiedModifier.Create("ref");
			case ParameterModifier.This:
				return UnifiedModifier.Create("this");
			}
			return null;
		}

		private static UnifiedModifier LookupModifier(FieldDirection dir) {
			switch (dir) {
			case FieldDirection.Out:
				return UnifiedModifier.Create("out");
			case FieldDirection.Ref:
				return UnifiedModifier.Create("ref");
			}
			return null;
		}

		internal static UnifiedType LookupType(AstType type) {
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

			case BinaryOperatorType.NullCoalescing:
				return UnifiedBinaryOperator.Create("??", UnifiedBinaryOperatorKind.Coalesce);
			}
			throw new ArgumentException("Unknown operator: " + op);
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
			throw new ArgumentException("Unknown operator: " + op);
		}

		private static UnifiedAnnotationTarget LookupAttributeTarget(string target) {
			if (target == null)
				return UnifiedAnnotationTarget.None;
			switch(target) {
			case "assembly":
				return UnifiedAnnotationTarget.Assembly;
			case "module":
				return UnifiedAnnotationTarget.Module;
			case "type":
				return UnifiedAnnotationTarget.Type;
			case "field":
				return UnifiedAnnotationTarget.Field;
			case "method":
				return UnifiedAnnotationTarget.Method;
			case "event":
				return UnifiedAnnotationTarget.Event;
			case "property":
				return UnifiedAnnotationTarget.Property;
			case "param":
				return UnifiedAnnotationTarget.Param;
			case "return":
				return UnifiedAnnotationTarget.Return;
			}
			throw new ArgumentException("未対応の対象です: " + target);
		}

		#endregion

		private static IDictionary<string, IList<UnifiedTypeConstraint>> CreateDictionary(IEnumerable<Constraint> constraints) {
			var dic = new Dictionary<string, IList<UnifiedTypeConstraint>>();
			foreach(var c in constraints) {
				var list = null as IList<UnifiedTypeConstraint>;
				if (dic.TryGetValue(c.TypeParameter, out list) == false) {
					dic[c.TypeParameter] = list =  new List<UnifiedTypeConstraint>();
				}
				var types = c.BaseTypes.Select(LookupType);
				foreach(var type in types) {
					list.Add(UnifiedExtendConstraint.Create(type));
				}
			}
			return dic;
		}

		private static string GetTypeName(UnifiedType type) {
			Contract.Requires(type != null);
			var ident = type.BasicTypeName as UnifiedIdentifier;
			if (ident == null) return null;
			return ident.Name;
		}
	}

	#region AcceptVisitorExntension

	internal static class VisitorExtension {

		internal static IUnifiedExpression TryAcceptForExpression(this AstNode node, IAstVisitor<IUnifiedElement, object> visitor) {
			if (node == null) return null;
			return node.AcceptVisitor(visitor, null) as IUnifiedExpression;
		}

		internal static UnifiedAnnotationCollection AcceptVisitorAsAttrs<T, TResult>(
				this IEnumerable<AttributeSection> attrs, IAstVisitor<T, TResult> visitor, T data) {
			return attrs
					.Select(a => a.AcceptVisitor(visitor, data))
					.OfType<UnifiedAnnotationCollection>()
					.Merge();
		}

		internal static UnifiedParameterCollection AcceptVisitorAsParams<T, TResult>(
				this IEnumerable<ParameterDeclaration> parameters, IAstVisitor<T, TResult> visitor, T data) {
			return parameters
					.Select(p => p.AcceptVisitor(visitor, data))
					.OfType<UnifiedParameter>()
					.ToCollection();
		}

		internal static UnifiedGenericParameterCollection AcceptVisitorAsTypeParams<T, TResult>(
				this IEnumerable<TypeParameterDeclaration> types, IAstVisitor<T, TResult> visitor, T data) {
			return types
					.Select(p => p.AcceptVisitor(visitor, data))
					.OfType<UnifiedGenericParameter>()
					.ToCollection();
		}

		internal static UnifiedTypeConstrainCollection AcceptVisitorAsTypeParams<T, TResult>(
				this IEnumerable<Constraint> constraints, IAstVisitor<T, TResult> visitor, T data) {
			return constraints
					.Select(p => p.AcceptVisitor(visitor, data))
					.OfType<UnifiedTypeConstraint>()
					.ToCollection();
		}

		internal static UnifiedGenericArgumentCollection AcceptVisitorAsTypeArgs<T, TResult>(
				this IEnumerable<AstType> types, IAstVisitor<T, TResult> visitor, T data) {
			return types
					.Select(NRefactoryModelVisitor.LookupType)
					.Select(t => UnifiedGenericArgument.Create(t))
					.ToCollection();
		}

		internal static UnifiedTypeConstrainCollection AcceptVisitorAsConstrains<T, TResult>(
				this IEnumerable<AstType> types, IAstVisitor<T, TResult> visitor, T data) {
			return types
					.Select(NRefactoryModelVisitor.LookupType)
					.Select(UnifiedExtendConstraint.Create)
					.ToCollection();
		}

		internal static UnifiedArgumentCollection AcceptVisitorAsArgs<T, TResult>(
				this IEnumerable<Expression> args, IAstVisitor<T, TResult> visitor, T data) {
			var uArgs = UnifiedArgumentCollection.Create();
			foreach (var arg in args) {
				var value = arg.AcceptVisitor(visitor, data);
				var uArg = value as UnifiedArgument;
				if (uArg != null) {
					uArgs.Add(uArg);
				}
				else {
					var uExpr = value as IUnifiedExpression;
					if (uExpr != null)
						uArgs.Add(UnifiedArgument.Create(uExpr, /*label*/null, /*mod*/null));
				}
			}
			return uArgs;
		}
	}

	#endregion
}
