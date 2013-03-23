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
using Paraiba.Xml.Linq;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
    public partial class Ruby18ProgramGeneratorHelper {
        private static readonly
                Dictionary<string, Func<XElement, UnifiedExpression>>
                ExpressionFuncs;

        public static Dictionary<string, UnifiedBinaryOperator>
                Sign2BinaryOperator;

        public static Dictionary<string, UnifiedUnaryOperator>
                Sign2PrefixUnaryOperator;

        static Ruby18ProgramGeneratorHelper() {
            Sign2BinaryOperator =
                    UnifiedProgramGeneratorHelper.CreateBinaryOperatorDictionary
                            ();
            Sign2PrefixUnaryOperator =
                    UnifiedProgramGeneratorHelper.
                            CreatePrefixUnaryOperatorDictionaryForJava();

            ExpressionFuncs =
                    new Dictionary<string, Func<XElement, UnifiedExpression>>();
            InitializeExpressions();
            InitializeLiterals();
            InitializeDefinitions();
            InitializeControlFlows();
        }

        public static UnifiedProgram CreateProgram(XElement node) {
            Contract.Requires(node != null);
            return UnifiedProgram.Create(CreateSmartBlock(node));
        }

        public static UnifiedSet<UnifiedParameter> CreateArgs(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "args");
            Contract.Requires(
                    node.Elements().All(
                            e => e.Name() == "Symbol" || e.Name() == "block"));
            var args = node.Elements("Symbol")
                    .Select(e => e.Value.ToVariableIdentifier().ToParameter())
                    .ToSet();
            if (args.Count > 0 && node.LastElement().Name() == "block") {
                // デフォルト引数付き
                var asgnNodes = node.LastElement().Elements();
                foreach (var asgnNode in asgnNodes) {
                    var name = asgnNode.FirstElement().Value;
                    args.First(arg => arg.Names[0].Name == name)
                            .DefaultValue =
                            CreateExpresion(asgnNode.NthElement(1));
                }
            }
            return args;
        }

        public static IEnumerable<UnifiedVariableIdentifier>
                CreateLasgnOrMasgnOrNil(
                XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(
                    node.Name() == "lasgn" || node.Name() == "masgn"
                    || node.Name() == "nil");
            Contract.Requires(
                    node.Name() == "nil" || node.Elements().Count() == 1);
            Contract.Requires(
                    node.Name() == "nil" || node.Name() != "masgn"
                    || node.FirstElement().Name() == "array");
            return node.Descendants("Symbol")
                    .Select(CreateSymbol);
        }

        public static UnifiedSet<UnifiedArgument> CreateArglist(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "arglist");
            return node.Elements()
                    .Select(e => CreateExpresion(e).ToArgument())
                    .ToSet();
        }

        private static UnifiedBlock CreateSmartBlock(XElement node) {
            if (node == null || node.Name() == "nil") {
                return UnifiedBlock.Create();
            }
            if (node.Name() == "block") {
                return CreateBlock(node);
            }
            return CreateExpresion(node).ToBlock();
        }

        private static IEnumerable<UnifiedCase> CreateWhenAndDefault(
                XElement node) {
            Contract.Requires(node != null);
            if (node.Name() == "nil") {
                yield break;
            }

            if (node.Name() != "when") {
                yield return UnifiedCase.CreateDefault(CreateSmartBlock(node));
            } else {
                var first = node.FirstElement();
                var caseConds = first.Elements()
                        .Select(CreateExpresion)
                        .ToList();
                int i;
                for (i = 0; i < caseConds.Count - 1; i++) {
                    yield return UnifiedCase.Create(caseConds[i]);
                }
                yield return
                        UnifiedCase.Create(
                                caseConds[i],
                                CreateSmartBlock(node.LastElement()));
            }
        }

        public static UnifiedVariableIdentifier CreateConst(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "const");
            return UnifiedIdentifier.CreateVariable(node.Value);
        }
    }
}