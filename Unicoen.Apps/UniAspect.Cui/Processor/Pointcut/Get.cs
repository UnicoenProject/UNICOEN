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
    public class Get : CodeProcessor {
        public override string PointcutName {
            get { return "get"; }
        }

        /// <summary>
        ///   指定された変数参照の直前に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="regex"> 対象変数を指定する正規表現 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtBeforeGet(
                IUnifiedElement root, Regex regex, UnifiedBlock advice) {
            //a = b;
            //TODO とりえあずAssignのみ +=,-=などについてはおいおい
            var assignmentExpressions =
                    root.Descendants<UnifiedBinaryExpression>().Where(
                            e =>
                            e.Operator.Kind == UnifiedBinaryOperatorKind.Assign)
                            .ToList();

            foreach (var exp in assignmentExpressions) {
                var parent = exp.Parent as UnifiedBlock;
                var rhs = exp.RightHandSide as UnifiedVariableIdentifier;

                //親がブロック　かつ　右辺がUnifiedVariableIdentifier　でない場合は次の要素へ
                if (parent == null || rhs == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(rhs.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                parent.Insert(parent.IndexOf(exp, 0), advice.DeepCopy());
            }

            //int a = b;
            var variableDefinitions =
                    root.Descendants<UnifiedVariableDefinition>().ToList();

            foreach (var definition in variableDefinitions) {
                //初期化子を変数として取得
                var identifier =
                        definition.InitialValue as UnifiedVariableIdentifier;
                var block = definition.Parent.Parent as UnifiedBlock;

                //初期化子が変数でない場合は次の要素へ
                if (block == null || identifier == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(identifier.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                var parent = definition.Parent as UnifiedVariableDefinitionList;
                block.Insert(block.IndexOf(parent, 0), advice.DeepCopy());
            }
        }

        /// <summary>
        ///   指定された変数参照の直後に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="regex"> 対象変数を指定する正規表現 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtAfterGet(
                IUnifiedElement root, Regex regex, UnifiedBlock advice) {
            //a = b;のb
            //TODO とりえあずAssignのみ +=,-=などについてはおいおい
            var assignmentExpressions =
                    root.Descendants<UnifiedBinaryExpression>().Where(
                            e =>
                            e.Operator.Kind == UnifiedBinaryOperatorKind.Assign)
                            .ToList();

            foreach (var exp in assignmentExpressions) {
                var parent = exp.Parent as UnifiedBlock;
                var rhs = exp.RightHandSide as UnifiedVariableIdentifier;

                //親がブロック　かつ　右辺がUnifiedVariableIdentifier　でない場合は次の要素へ
                if (parent == null || rhs == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(rhs.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                parent.Insert(parent.IndexOf(exp, 0) + 1, advice.DeepCopy());
            }

            //int a = b;のb
            var variableDefinitions =
                    root.Descendants<UnifiedVariableDefinition>().ToList();

            foreach (var definition in variableDefinitions) {
                //初期化子を変数として取得
                var identifier =
                        definition.InitialValue as UnifiedVariableIdentifier;
                var block = definition.Parent.Parent as UnifiedBlock;

                //初期化子が変数でない場合は次の要素へ
                if (block == null || identifier == null) {
                    continue;
                }

                //変数名が与えられた正規表現にマッチするか確認する
                var m = regex.Match(identifier.Name);
                if (!m.Success) {
                    continue;
                }

                //アドバイスの合成
                var parent = definition.Parent as UnifiedVariableDefinitionList;
                block.Insert(block.IndexOf(parent, 0) + 1, advice.DeepCopy());
            }
        }

        public static void InsertAtBeforeGetByName(
                IUnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtBeforeGet(root, new Regex(name), advice);
        }

        public static void InsertAtAfterGetByName(
                IUnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtAfterGet(root, new Regex(name), advice);
        }

        public override void Before(
                IUnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtBeforeGetByName(model, targetName, advice);
        }

        public override void After(
                IUnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtAfterGetByName(model, targetName, advice);
        }

        public override void Around(IUnifiedElement model) {
            throw new NotImplementedException();
        }
    }
}