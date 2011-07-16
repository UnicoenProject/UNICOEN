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
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using UniUni.Xml.Linq;
using Unicoen.Model;

namespace Unicoen.Languages.Ruby18.Model {
	public partial class RubyModelFactoryHelper {
		private static readonly Dictionary<string, Func<XElement, IUnifiedExpression>>
				ExpressionFuncs;

		static RubyModelFactoryHelper() {
			ExpressionFuncs =
					new Dictionary<string, Func<XElement, IUnifiedExpression>>();
			ExpressionFuncs["nil"] = CreateNil;
			ExpressionFuncs["block"] = CreateBlock;
			ExpressionFuncs["lasgn"] = CreateLasgn;
			ExpressionFuncs["if"] = CreateFloat;
			ExpressionFuncs["call"] = CreateFloat;
			ExpressionFuncs["lvar"] = CreateLvar;
			ExpressionFuncs["case"] = CreateCase;
			ExpressionFuncs["array"] = CreateArray;
			ExpressionFuncs["until"] = CreateUntil;
			ExpressionFuncs["for"] = CreateUntil;
			ExpressionFuncs["iter"] = CreateUntil;
			ExpressionFuncs["defn"] = CreateUntil;
			ExpressionFuncs["scope"] = CreateUntil;
			ExpressionFuncs["args"] = CreateUntil;
			ExpressionFuncs["masgn"] = CreateUntil;

			ExpressionFuncs["Symbol"] = CreateSymbol;
			ExpressionFuncs["Fixnum"] = CreateFixnum;
			ExpressionFuncs["Bignum"] = CreateBignum;
			ExpressionFuncs["Float"] = CreateFloat;
			ExpressionFuncs["String"] = CreateString;
		}

		private static IUnifiedExpression CreateUntil(XElement node) {
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

		private static UnifiedArrayLiteral CreateArray(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "array");
			return node.Elements().Select(CreateExpresion).ToArrayLiteral();
		}

		private static IEnumerable<UnifiedCase> CreateWhen(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "when");
			var block = CreateExpresion(node.LastElement()).ToBlock();
			return node.FirstElement()
					.Elements()
					.Select(CreateExpresion)
					.Select(e => UnifiedCase.Create(e, block));
		}

		private static IUnifiedExpression CreateCase(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "case");
			return UnifiedSwitch.Create(
					CreateExpresion(node.NthElement(0)),
					node.Elements().Skip(1)
							.SelectMany(CreateWhen)
							.ToCollection()
					);
		}

		private static IUnifiedExpression CreateLvar(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lvar");
			return UnifiedVariableIdentifier.Create(node.Value);
		}

		private static IUnifiedExpression CreateExpresion(XElement node) {
			return ExpressionFuncs[node.Name()](node);
		}

		private static IUnifiedExpression CreateNil(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nil");
			return null;
		}

		private static UnifiedArgumentCollection CreateArglist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arglist");
			return node.Elements()
					.Select(e => CreateExpresion(e).ToArgument())
					.ToCollection();
		}

		public static UnifiedCall CreateCall(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "call");
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

		public static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			return node.Elements()
					.Select(CreateExpresion)
					.ToBlock();
		}
	}
}