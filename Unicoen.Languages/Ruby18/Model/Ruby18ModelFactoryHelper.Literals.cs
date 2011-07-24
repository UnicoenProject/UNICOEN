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
using Unicoen.Processor;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
	public partial class Ruby18ModelFactoryHelper {
		private static void InitializeLiterals() {
			ExpressionFuncs["nil"] = CreateNil;
			ExpressionFuncs["array"] = CreateArray;
			ExpressionFuncs["lit"] = CreateLit;
			ExpressionFuncs["Fixnum"] = CreateFixnum;
			ExpressionFuncs["Bignum"] = CreateBignum;
			ExpressionFuncs["Float"] = CreateFloat;
			ExpressionFuncs["true"] = CreateTrue;
			ExpressionFuncs["false"] = CreateFalse;
			ExpressionFuncs["str"] = CreateStr;
		}

		public static UnifiedArrayLiteral CreateArray(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "array");
			return node.Elements().Select(CreateExpresion).ToArrayLiteral();
		}

		public static IUnifiedExpression CreateNil(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nil");
			return null;
		}

		public static IUnifiedExpression CreateLit(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lit");
			return CreateExpresion(node.FirstElement());
		}

		public static IUnifiedExpression CreateFloat(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Float");
			return UnifiedFractionLiteral.Create(
					double.Parse(node.Value),
					UnifiedFractionLiteralKind.Double);
		}

		public static IUnifiedExpression CreateBignum(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Bignum");
			return
					UnifiedInt32Literal.Create(LiteralFuzzyParser.ParseBigInteger(node.Value));
		}

		public static IUnifiedExpression CreateFixnum(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Fixnum");
			return UnifiedInt32Literal.Create(LiteralFuzzyParser.ParseInt32(node.Value));
		}

		public static UnifiedBooleanLiteral CreateTrue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "true");
			return UnifiedBooleanLiteral.Create(true);
		}

		public static UnifiedBooleanLiteral CreateFalse(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "false");
			return UnifiedBooleanLiteral.Create(false);
		}

		public static UnifiedStringLiteral CreateStr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "str");
			return UnifiedStringLiteral.Create(node.Value);
		}
	}
}