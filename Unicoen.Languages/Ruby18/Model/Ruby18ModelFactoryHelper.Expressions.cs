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
			ExpressionFuncs["if"] = CreateIf;
			ExpressionFuncs["call"] = CreateCall;
			ExpressionFuncs["lvar"] = CreateLvar;
			ExpressionFuncs["case"] = CreateCase;
			ExpressionFuncs["until"] = CreateUntil;

			ExpressionFuncs["for"] = CreateFor;
			ExpressionFuncs["iter"] = CreateIter;

			ExpressionFuncs["lasgn"] = CreateLasgn;
			ExpressionFuncs["masgn"] = CreateMasgn;
			ExpressionFuncs["const"] = CreateConst;
			ExpressionFuncs["Symbol"] = CreateSymbol;
			ExpressionFuncs["self"] = CreateSelf;

			ExpressionFuncs["return"] = CreateReturn;
		}

		public static IUnifiedExpression CreateExpresion(XElement node) {
			return ExpressionFuncs[node.Name()](node);
		}

		public static IUnifiedExpression CreateSmartExpresion(XElement node) {
			if (node == null || node.Name() == "nil")
				return null;
			return ExpressionFuncs[node.Name()](node);
		}

		private static IUnifiedExpression CreateReturn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "return");
			return UnifiedReturn.Create(CreateSmartExpresion(node.FirstElementOrDefault()));
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

		public static UnifiedCall CreateIter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iter");
			var call = CreateCall(node.NthElement(0));
			var parameters = CreateLasgnOrMasgnOrNil(node.NthElement(1))
					.Select(e => e.ToParameter())
					.ToCollection();
			var block = CreateBlock(node.NthElement(2));
			call.Proc = UnifiedProc.Create(parameters, block);
			return call;
		}

		public static IUnifiedExpression CreateFor(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "for");
			Contract.Assert(
					node.NthElement(1).Name() == "lasgn"
					|| node.NthElement(1).Name() == "masgn");
			return UnifiedForeach.Create(
					CreateExpresion(node.NthElement(0)),
					CreateExpresion(node.NthElement(1).FirstElement()),
					CreateBlock(node.NthElement(2)));
		}

		public static IUnifiedExpression CreateUntil(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "until");
			var cond =
					UnifiedUnaryExpression.Create(
							CreateExpresion(node.FirstElement()),
							UnifiedUnaryOperator.Create("!", UnifiedUnaryOperatorKind.Not));
			var secondNode = node.NthElement(1);
			if (node.LastElement().Name() == "TrueClass") {
				return UnifiedWhile.Create(cond, CreateBlock(secondNode));
			}
			return UnifiedDoWhile.Create(cond, CreateBlock(secondNode));
		}

		public static IUnifiedExpression CreateCase(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "case");
			return UnifiedSwitch.Create(
					CreateExpresion(node.NthElement(0)),
					node.Elements().Skip(1)
							.SelectMany(CreateWhenAndDefault)
							.ToCollection()
					);
		}

		public static IUnifiedExpression CreateLvar(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lvar");
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

		public static UnifiedIf CreateIf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "if");
			return UnifiedIf.Create(
					CreateExpresion(node.NthElement(0)),
					CreateBlock(node.NthElement(1)),
					CreateBlock(node.NthElement(2)));
		}

		public static UnifiedVariableIdentifier CreateSymbol(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Symbol");
			return UnifiedVariableIdentifier.Create(node.Value);
		}

		public static UnifiedBinaryExpression CreateLasgn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lasgn");
			return UnifiedBinaryExpression.Create(
					CreateExpresion(node.FirstElement()),
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					CreateExpresion(node.LastElement()));
		}

		public static UnifiedBinaryExpression CreateMasgn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "masgn");
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