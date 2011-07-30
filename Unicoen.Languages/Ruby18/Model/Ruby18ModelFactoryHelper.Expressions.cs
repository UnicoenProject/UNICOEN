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
using System.Xml.Linq;
using UniUni.Xml.Linq;
using Unicoen.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
	public partial class Ruby18ModelFactoryHelper {
		private static void InitializeExpressions() {
			ExpressionFuncs["scope"] = CreateScope;

			ExpressionFuncs["block"] = CreateBlock;
			ExpressionFuncs["call"] = CreateCall;
			ExpressionFuncs["lvar"] = CreateVar;
			ExpressionFuncs["ivar"] = CreateVar;
			ExpressionFuncs["cvar"] = CreateVar;
			ExpressionFuncs["gvar"] = CreateVar;

			ExpressionFuncs["lasgn"] = CreateAsgn;
			ExpressionFuncs["masgn"] = CreateAsgn;
			ExpressionFuncs["iasgn"] = CreateAsgn;
			ExpressionFuncs["cvasgn"] = CreateAsgn;
			ExpressionFuncs["gasgn"] = CreateAsgn;
			ExpressionFuncs["cdecl"] = CreateAsgn;

			ExpressionFuncs["attrasgn"] = CreateAttrasgn;
			ExpressionFuncs["const"] = CreateConst;
			ExpressionFuncs["Symbol"] = CreateSymbol;
			ExpressionFuncs["self"] = CreateSelf;

			ExpressionFuncs["to_ary"] = CreateToAry;

			ExpressionFuncs["alias"] = CreateAlias;
			ExpressionFuncs["colon2"] = CreateColon2;
			ExpressionFuncs["and"] = CreateAnd;
			ExpressionFuncs["or"] = CreateOr;
			ExpressionFuncs["not"] = CreateNot;
			ExpressionFuncs["match3"] = CreateMatch3;

			ExpressionFuncs["op_asgn1"] = CreateOpAsgn1;
			ExpressionFuncs["op_asgn2"] = CreateOpAsgn2;
		}

		private static IUnifiedExpression CreateOpAsgn2(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "op_asgn2");
			var propName = node.NthElement(1).Value;
			var expression = UnifiedProperty.Create(
					".", CreateExpresion(node.FirstElement()),
					UnifiedVariableIdentifier.Create(
							propName.Substring(0, propName.Length - 1)));
			return UnifiedBinaryExpression.Create(
					expression,
					Sign2BinaryOperator[node.NthElement(2).Value + "="].DeepCopy(),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateOpAsgn1(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "op_asgn1");
			var expression = UnifiedIndexer.Create(
					CreateExpresion(node.FirstElement()),
					CreateArglist(node.NthElement(1)));
			return UnifiedBinaryExpression.Create(
					expression,
					Sign2BinaryOperator[node.NthElement(2).Value + "="].DeepCopy(),
					CreateExpresion(node.LastElement()));
		}

		public static IUnifiedExpression CreateExpresion(XElement node) {
			return ExpressionFuncs[node.Name()](node);
		}

		private static IUnifiedExpression CreateToAry(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "to_ary");
			return CreateExpresion(node.FirstElement());
		}

		private static IUnifiedExpression CreateAttrasgn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "attrasgn");
			var left = CreateExpresion(node.FirstElement());
			var name = node.NthElement(1);
			var args = CreateArglist(node.LastElement());
			var right = args[args.Count - 1].Value;
			args.RemoveAt(args.Count - 1);
			right.RemoveSelf();
			IUnifiedExpression expression;
			if (name.Value == "[]=") {
				expression = UnifiedIndexer.Create(left, args);
			} else {
				var propName = name.Value;
				propName = propName.Substring(0, propName.Length - 1);
				expression = UnifiedProperty.Create(
						".", left, UnifiedVariableIdentifier.Create(propName));
			}
			return UnifiedBinaryExpression.Create(
					expression,
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					right);
		}

		public static IUnifiedExpression CreateSmartExpresion(XElement node) {
			if (node == null || node.Name() == "nil")
				return null;
			return ExpressionFuncs[node.Name()](node);
		}

		private static UnifiedThisIdentifier CreateSelf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "self");
			return UnifiedIdentifier.CreateThis("self");
		}

		public static UnifiedBlock CreateScope(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "scope");
			return CreateSmartBlock(node.FirstElementOrDefault());
		}

		public static IUnifiedExpression CreateVar(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(
					node.Name() == "lvar" || node.Name() == "ivar" || node.Name() == "cvar"
					|| node.Name() == "gvar");
			return UnifiedVariableIdentifier.Create(node.Value);
		}

		public static UnifiedCall CreateCall(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "call");
			// TODO: 演算子への変換
			var receiver = CreateExpresion(node.NthElement(0));
			var secondNode = node.NthElement(1);
			return UnifiedCall.Create(
					receiver != null
							? UnifiedProperty.Create(".", receiver, CreateExpresion(secondNode))
							: CreateExpresion(secondNode),
					CreateArglist(node.NthElement(2)));
		}

		public static UnifiedVariableIdentifier CreateSymbol(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Symbol");
			return UnifiedVariableIdentifier.Create(node.Value);
		}

		public static UnifiedBinaryExpression CreateAsgn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(
					node.Name() == "lasgn" || node.Name() == "masgn" || node.Name() == "iasgn"
					|| node.Name() == "cvasgn" || node.Name() == "gasgn"
					|| node.Name() == "cdecl");
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					CreateExpresion(node.LastElement()));
		}

		public static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			return node.Elements()
					.Select(CreateExpresion)
					.ToBlock();
		}

		public static IUnifiedExpression CreateAlias(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "alias");
			// TODO: UnifiedCall?
			return UnifiedCall.Create(
					UnifiedVariableIdentifier.Create("alias"),
					new[] {
							CreateExpresion(node.FirstElement()).ToArgument(),
							CreateExpresion(node.LastElement()).ToArgument()
					}.ToCollection());
		}

		private static IUnifiedExpression CreateColon2(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "colon2");
			return UnifiedProperty.Create(
					"::",
					CreateExpresion(node.FirstElement()),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateAnd(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and");
			// TODO: && と and
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("and", UnifiedBinaryOperatorKind.AndAlso),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateOr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "or");
			// TODO: || と or
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("or", UnifiedBinaryOperatorKind.OrElse),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateNot(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "not");
			// TODO: || と or
			return UnifiedUnaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedUnaryOperator.Create("!", UnifiedUnaryOperatorKind.Not));
		}

		private static IUnifiedExpression CreateMatch3(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "match3");
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("=~", UnifiedBinaryOperatorKind.RegexEqual),
					CreateExpresion(node.LastElement()));
		}
	}
}