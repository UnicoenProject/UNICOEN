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
			ExpressionFuncs["attrasgn"] = CreateAttrasgn;
			ExpressionFuncs["const"] = CreateConst;
			ExpressionFuncs["Symbol"] = CreateSymbol;
			ExpressionFuncs["self"] = CreateSelf;

			ExpressionFuncs["to_ary"] = CreateToAry;
			
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
			Contract.Requires(node.NthElement(1).Value == "[]=");
			return UnifiedIndexer.Create(
					CreateExpresion(node.FirstElement()),
					CreateArglist(node.LastElement()));
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
			Contract.Requires(node.Name() == "lvar" || node.Name() == "ivar" || node.Name() == "cvar" || node.Name() == "gvar");
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
			Contract.Requires(node.Name() == "lasgn" || node.Name() == "masgn" || node.Name() == "iasgn" || node.Name() == "cvasgn" || node.Name() == "gasgn");
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
	}
}