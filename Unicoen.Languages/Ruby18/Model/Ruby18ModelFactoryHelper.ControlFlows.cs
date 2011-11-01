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
using Paraiba.Linq;
using Unicoen.Model;
using Paraiba.Xml.Linq;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
	public partial class Ruby18ProgramGeneratorHelper {
		private static void InitializeControlFlows() {
			ExpressionFuncs["if"] = CreateIf;
			ExpressionFuncs["case"] = CreateCase;
			ExpressionFuncs["until"] = CreateUntil;
			ExpressionFuncs["while"] = CreateWhile;
			ExpressionFuncs["for"] = CreateFor;
			ExpressionFuncs["iter"] = CreateIter;
			ExpressionFuncs["ensure"] = CreateEnsure;
			ExpressionFuncs["rescue"] = CreateRescue;

			ExpressionFuncs["return"] = CreateReturn;
			ExpressionFuncs["break"] = CreateBreak;
			ExpressionFuncs["next"] = CreateNext;
			ExpressionFuncs["redo"] = CreateRedo;
			ExpressionFuncs["retry"] = CreateRetry;
			ExpressionFuncs["yield"] = CreateYield;
		}

		private static IUnifiedExpression CreateYield(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "yield");
			var args = node.Elements()
					.Select(CreateExpresion)
					.ToTupleLiteral();
			return UnifiedYieldReturn.Create(args);
		}

		private static IUnifiedExpression CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "while");
			var cond = CreateExpresion(node.FirstElement());
			var secondNode = node.NthElement(1);
			if (node.LastElement().Name() == "TrueClass") {
				return UnifiedWhile.Create(cond, CreateSmartBlock(secondNode));
			}
			return UnifiedDoWhile.Create(cond, CreateSmartBlock(secondNode));
		}

		private static UnifiedCatch CreateResbody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "resbody");
			Contract.Requires(node.FirstElement().Name() == "array");
			// TODO: UnifiedType.Create(ident) => identをUnifiedTypeIdentifierにべきでは？
			var children = node.FirstElement().Elements().ToList();
			var block = CreateSmartBlock(node.LastElement());
			if (children.Count == 0) {
				return UnifiedCatch.Create(UnifiedTypeCollection.Create(), null, block);
			}
			var assign = CreateExpresion(children.Last().FirstElement());
			var types = children.SkipLast()
					.Select(CreateConst)
					.Select(UnifiedType.Create)
					.ToCollection();
			return UnifiedCatch.Create(types, assign, block);
		}

		private static IUnifiedExpression CreateRescue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "rescue");
			var lastNode = node.LastElement();
			var elseBlock = lastNode.Name() != "resbody"
			                		? CreateSmartBlock(lastNode)
			                		: null;
			return UnifiedTry.Create(
					CreateSmartBlock(node.FirstElement()),
					node.Elements("resbody").Select(CreateResbody).ToCollection(),
					elseBlock);
		}

		private static IUnifiedExpression CreateEnsure(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ensure");
			return UnifiedTry.Create(
					CreateSmartBlock(node.FirstElement()), null, null,
					CreateSmartBlock(node.LastElement()));
		}

		private static IUnifiedExpression CreateRetry(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "retry");
			return UnifiedRedo.Create();
		}

		private static IUnifiedExpression CreateRedo(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "redo");
			return UnifiedRedo.Create();
		}

		private static IUnifiedExpression CreateNext(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "next");
			return
					UnifiedContinue.Create(CreateSmartExpresion(node.FirstElementOrDefault()));
		}

		private static IUnifiedExpression CreateBreak(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "break");
			return UnifiedBreak.Create(
					CreateSmartExpresion(node.FirstElementOrDefault()));
		}

		private static IUnifiedExpression CreateReturn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "return");
			return
					UnifiedReturn.Create(CreateSmartExpresion(node.FirstElementOrDefault()));
		}

		public static UnifiedCall CreateIter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iter");
			var call = CreateCall(node.NthElement(0));
			var paramNode = node.NthElement(1);
			Contract.Assert(paramNode.Name() != "Fixnum" || paramNode.Value == "0");
			var parameters = paramNode.Name() != "Fixnum"
			                 		? CreateLasgnOrMasgnOrNil(node.NthElement(1))
			                 		  		.Select(e => e.ToParameter())
			                 		  		.ToCollection()
			                 		: null;
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
				return UnifiedWhile.Create(cond, CreateSmartBlock(secondNode));
			}
			return UnifiedDoWhile.Create(cond, CreateSmartBlock(secondNode));
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

		public static UnifiedIf CreateIf(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "if");
			return UnifiedIf.Create(
					CreateExpresion(node.NthElement(0)),
					CreateBlock(node.NthElement(1)),
					CreateBlock(node.NthElement(2)));
		}
	}
}