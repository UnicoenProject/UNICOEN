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
using Paraiba.Xml.Linq;
using Unicoen.Model;
using Unicoen.Processor;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
    public partial class Ruby18ProgramGeneratorHelper {
        private static void InitializeLiterals() {
            ExpressionFuncs["nil"] = CreateNil;
            ExpressionFuncs["array"] = CreateArray;
            ExpressionFuncs["lit"] = CreateLit;
            ExpressionFuncs["Fixnum"] = CreateFixnum;
            ExpressionFuncs["Bignum"] = CreateBignum;
            ExpressionFuncs["Float"] = CreateFloat;
            ExpressionFuncs["true"] = CreateTrue;
            ExpressionFuncs["false"] = CreateFalse;
            ExpressionFuncs["dot2"] = CreateDot2;
            ExpressionFuncs["dot3"] = CreateDot3;
            ExpressionFuncs["str"] = CreateStr;
            ExpressionFuncs["dstr"] = CreateDstr;
            ExpressionFuncs["Symbol"] = CreateSymbol;
            ExpressionFuncs["dsym"] = CreateDsym;
            ExpressionFuncs["hash"] = CreateHash;
            ExpressionFuncs["Regexp"] = CreateRegexp;
            ExpressionFuncs["dregx_once"] = CreateDregxOnce;
            ExpressionFuncs["Range"] = CreateRange;
        }

        private static UnifiedExpression CreateRange(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Range");
            if (node.Value.Contains("...")) {
                var numbers = node.Value.Split(
                        new[] { "..." }, StringSplitOptions.None);
                return UnifiedRange.CreateNotContainingMax(
                        UnifiedIntegerLiteral.CreateInt32(
                                LiteralFuzzyParser.ParseBigInteger(numbers[0])),
                        UnifiedIntegerLiteral.CreateInt32(
                                LiteralFuzzyParser.ParseBigInteger(numbers[1])));
            }
            {
                var numbers = node.Value.Split(
                        new[] { ".." }, StringSplitOptions.None);
                return UnifiedRange.Create(
                        UnifiedIntegerLiteral.CreateInt32(
                                LiteralFuzzyParser.ParseBigInteger(numbers[0])),
                        UnifiedIntegerLiteral.CreateInt32(
                                LiteralFuzzyParser.ParseBigInteger(numbers[1])));
            }
        }

        private static UnifiedExpression CreateHash(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "hash");
            return UnifiedMapLiteral.Create(
                    node.Elements()
                            .Split2()
                            .Select(
                                    t => UnifiedKeyValue.Create(
                                            CreateExpresion(t.Item1),
                                            CreateExpresion(t.Item2))));
        }

        private static UnifiedExpression CreateDot3(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "dot3");
            return UnifiedRange.Create(
                    CreateExpresion(node.FirstElement()),
                    CreateExpresion(node.LastElement()));
        }

        private static UnifiedExpression CreateDot2(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "dot2");
            return UnifiedRange.CreateNotContainingMax(
                    CreateExpresion(node.FirstElement()),
                    CreateExpresion(node.LastElement()));
        }

        public static UnifiedArrayLiteral CreateArray(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "array");
            return node.Elements().Select(CreateExpresion).ToArrayLiteral();
        }

        public static UnifiedExpression CreateNil(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "nil");
            return null;
        }

        public static UnifiedExpression CreateLit(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "lit");
            var child = node.FirstElement();
            switch (child.Name()) {
            case "Symbol":
                return UnifiedSymbolLiteral.Create(child.Value);
            }
            return CreateExpresion(child);
        }

        public static UnifiedExpression CreateFloat(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Float");
            return UnifiedFractionLiteral.Create(
                    double.Parse(node.Value),
                    UnifiedFractionLiteralKind.Double);
        }

        public static UnifiedExpression CreateBignum(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Bignum");
            return
                    UnifiedInt32Literal.Create(
                            LiteralFuzzyParser.ParseBigInteger(node.Value));
        }

        public static UnifiedExpression CreateFixnum(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Fixnum");
            return
                    UnifiedInt32Literal.Create(
                            LiteralFuzzyParser.ParseInt32(node.Value));
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

        private static UnifiedExpression CreateDstr(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "dstr");
            // TODO: Implement
            return UnifiedStringLiteral.Create("");
        }

        public static UnifiedVariableIdentifier CreateSymbol(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Symbol");
            return UnifiedVariableIdentifier.Create(node.Value);
        }

        private static UnifiedExpression CreateDsym(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "dsym");
            // TODO: Implement
            return UnifiedVariableIdentifier.Create(node.Value);
        }

        private static UnifiedExpression CreateDregxOnce(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "dregx_once");
            // TODO: Implement correctly
            var str = node.Value;
            return UnifiedRegularExpressionLiteral.Create(str);
        }

        private static UnifiedExpression CreateRegexp(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "Regexp");
            // TODO: Implement correctly
            var str = node.Value;
            return UnifiedRegularExpressionLiteral.Create(
                    str.Substring(7, str.Length - 8));
        }
    }
}