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
using System.Xml.Linq;
using Unicoen.Model;
using UniUni.Xml.Linq;

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

			ExpressionFuncs["lasgn"] = CreateAsgn; // 代入
			ExpressionFuncs["masgn"] = CreateAsgn; // 複数代入
			ExpressionFuncs["iasgn"] = CreateAsgn; // インスタンス変数に代入
			ExpressionFuncs["cvdecl"] = CreateAsgn; // クラス変数に代入
			ExpressionFuncs["gasgn"] = CreateAsgn; // グローバル変数に代入
			ExpressionFuncs["cdecl"] = CreateAsgn; // 定数の定義

			ExpressionFuncs["attrasgn"] = CreateAttrasgn;
			ExpressionFuncs["const"] = CreateConst;
			ExpressionFuncs["Symbol"] = CreateSymbol;
			ExpressionFuncs["self"] = CreateSelf;
			ExpressionFuncs["super"] = CreateSuper;
			ExpressionFuncs["zsuper"] = CreateZsuper;

			ExpressionFuncs["to_ary"] = CreateToAry;

			ExpressionFuncs["alias"] = CreateAlias;
			ExpressionFuncs["undef"] = CreateUndef;
			ExpressionFuncs["defined"] = CreateDefined;

			ExpressionFuncs["colon2"] = CreateColon2;
			ExpressionFuncs["colon3"] = CreateColon3;
			ExpressionFuncs["and"] = CreateAnd;
			ExpressionFuncs["or"] = CreateOr;
			ExpressionFuncs["not"] = CreateNot;
			ExpressionFuncs["match3"] = CreateMatch3;

			ExpressionFuncs["op_asgn1"] = CreateOpAsgn1;
			ExpressionFuncs["op_asgn2"] = CreateOpAsgn2;
			ExpressionFuncs["op_asgn_and"] = CreateOpAsgnAnd;
			ExpressionFuncs["op_asgn_or"] = CreateOpAsgnOr;

			ExpressionFuncs["splat"] = CreateSplat;
			ExpressionFuncs["block_pass"] = CreateBlockPass;
			ExpressionFuncs["nth_ref"] = CreateNthRef;
		}

		public static IUnifiedExpression CreateExpresion(XElement node) {
			//if (!ExpressionFuncs.ContainsKey(node.Name()))
			//    return null;
			return ExpressionFuncs[node.Name()](node);
		}

		private static IUnifiedExpression CreateNthRef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nth_ref");
			// TODO: 正規表現オブジェクトのパターンにマッチした文字列の処理
			return UnifiedIdentifier.CreateVariable("$" + node.Value);
		}

		private static IUnifiedExpression CreateBlockPass(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block_pass");
			return UnifiedUnaryExpression.Create(
					CreateExpresion(node.FirstElement()), 
					UnifiedUnaryOperator.Create("&", UnifiedUnaryOperatorKind.BlockPass));
		}

		private static IUnifiedExpression CreateSplat(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "splat");
			return UnifiedUnaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedUnaryOperator.Create("*", UnifiedUnaryOperatorKind.Expand));
		}

		private static IUnifiedExpression CreateSuper(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "super");
			// 引数を省略するとコンストラクタと同じ引数を渡す
			return UnifiedCall.Create(
					UnifiedSuperIdentifier.Create("super"),
					node.Elements()
							.Select(CreateExpresion)
							.Select(e => UnifiedArgument.Create(e))
							.ToCollection()
					);
		}

		private static IUnifiedExpression CreateZsuper(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "zsuper");
			// 引数を省略するとコンストラクタと同じ引数を渡す
			return UnifiedCall.Create(
					UnifiedSuperIdentifier.Create("super"));
		}

		private static IUnifiedExpression CreateColon3(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "colon3");
			return UnifiedProperty.Create(
					"::", null, CreateExpresion(node.FirstElement()));
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

		public static UnifiedBinaryExpression CreateAsgn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(
					node.Name() == "lasgn" || node.Name() == "masgn" || node.Name() == "iasgn"
					|| node.Name() == "gasgn" || node.Name() == "cvdecl"
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
			return UnifiedAlias.Create(
					CreateExpresion(node.FirstElement()),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateDefined(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "defined");
			return UnifiedDefined.Create(
					CreateExpresion(node.FirstElement()));
		}

		private static IUnifiedExpression CreateUndef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "undef");
			return UnifiedDelete.Create(
					CreateExpresion(node.FirstElement()));
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
			// 優先順位の違いはASTの深さ（&& / and）
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("&&", UnifiedBinaryOperatorKind.AndAlso),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateOr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "or");
			// 優先順位の違いはASTの深さ（|| / or）
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("||", UnifiedBinaryOperatorKind.OrElse),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateNot(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "not");
			return UnifiedUnaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedUnaryOperator.Create("!", UnifiedUnaryOperatorKind.Not));
		}

		private static IUnifiedExpression CreateOpAsgnAnd(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "op_asgn_and");
			// 優先順位の違いはASTの深さ（&& / and）
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("&&=", UnifiedBinaryOperatorKind.AndAlsoAssign),
					CreateExpresion(node.LastElement()));
		}

		private static IUnifiedExpression CreateOpAsgnOr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "op_asgn_or");
			// 優先順位の違いはASTの深さ（|| / or）
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("||=", UnifiedBinaryOperatorKind.OrElseAssign),
					CreateExpresion(node.LastElement()));
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