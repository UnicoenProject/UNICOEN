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
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
    [Export(typeof(CodeProcessor))]
    public class Set : CodeProcessor {
        //TODO a = b = cの扱いはどうするか考える
        public override string PointcutName {
            get { return "set"; }
        }

        public static void InsertAtBeforeSet(
                UnifiedElement root, Regex regex, UnifiedBlock advice) {
            //a = b;のa
            //TODO とりえあずAssignのみ +=,-=などについてはおいおい
            var assignmentExpressions =
                    root.Descendants<UnifiedBinaryExpression>().Where(
                            e =>
                            e.Operator.Kind == UnifiedBinaryOperatorKind.Assign)
                            .ToList();

            foreach (var exp in assignmentExpressions) {
                var parent = exp.Parent as UnifiedBlock;
                var lhs = exp.LeftHandSide as UnifiedVariableIdentifier;

                //親がブロック　かつ　左辺がUnifiedVariableIdentifier　でない場合は次の要素へ
                if (parent == null || lhs == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(lhs.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                parent.Insert(parent.IndexOf(exp, 0), advice.DeepCopy());
            }

            //int a = b;のa
            var variableDefinitions =
                    root.Descendants<UnifiedVariableDefinition>().ToList();

            foreach (var definition in variableDefinitions) {
                //初期化子がない場合は値はセットされないので次の要素へ
                if (definition.InitialValue == null) {
                    continue;
                }

                //初期化子を変数として取得
                var variable = definition.Name as UnifiedVariableIdentifier;
                var block = definition.Parent.Parent as UnifiedBlock;

                //初期化子が変数でない場合は次の要素へ
                if (block == null || variable == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(variable.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                var parent = definition.Parent as UnifiedVariableDefinitionList;
                block.Insert(block.IndexOf(parent, 0), advice.DeepCopy());
            }
        }

        public static void InsertAtAfterSet(
                UnifiedElement root, Regex regex, UnifiedBlock advice) {
            //a = b;のa
            //TODO とりえあずAssignのみ +=,-=などについてはおいおい
            var assignmentExpressions =
                    root.Descendants<UnifiedBinaryExpression>().Where(
                            e =>
                            e.Operator.Kind == UnifiedBinaryOperatorKind.Assign)
                            .ToList();

            foreach (var exp in assignmentExpressions) {
                var parent = exp.Parent as UnifiedBlock;
                var lhs = exp.LeftHandSide as UnifiedVariableIdentifier;

                //親がブロック　かつ　左辺がUnifiedVariableIdentifier　でない場合は次の要素へ
                if (parent == null || lhs == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(lhs.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                parent.Insert(parent.IndexOf(exp, 0) + 1, advice.DeepCopy());
            }

            //int a = b;のa
            var variableDefinitions =
                    root.Descendants<UnifiedVariableDefinition>().ToList();

            foreach (var definition in variableDefinitions) {
                //初期化子がない場合は値はセットされないので次の要素へ
                if (definition.InitialValue == null) {
                    continue;
                }

                //初期化子を変数として取得
                var variable = definition.Name as UnifiedVariableIdentifier;
                var block = definition.Parent.Parent as UnifiedBlock;

                //初期化子が変数でない場合は次の要素へ
                if (block == null || variable == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(variable.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                var parent = definition.Parent as UnifiedVariableDefinitionList;
                block.Insert(block.IndexOf(parent, 0) + 1, advice.DeepCopy());
            }
        }

        public static void InsertAtBeforeSetByName(
                UnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtBeforeSet(root, new Regex(name), advice);
        }

        public static void InsertAtAfterSetByName(
                UnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtAfterSet(root, new Regex(name), advice);
        }

        public override void Before(
                UnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtBeforeSetByName(model, targetName, advice);
        }

        public override void After(
                UnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtAfterSetByName(model, targetName, advice);
        }

        public override void Around(UnifiedElement model) {
            throw new NotImplementedException();
        }
    }
}