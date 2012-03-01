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
using System.Linq;
using Unicoen.Model;

namespace Unicoen.Apps.Findbug {
    public class DefUseAnalyzer {
        public static IEnumerable<UnifiedElement> FindDefines(
                UnifiedBlock codeObj) {
            /*
			 * Binary Expressionを探索
			 * "="だけ
			 * 左辺の変数名を調べる
			 * 左辺のやつを表示するものを作る
			 * 
			 */
            var binaryExpressions =
                    codeObj.Descendants<UnifiedBinaryExpression>();

            foreach (var be in binaryExpressions) {
                if (be.Operator.Kind == UnifiedBinaryOperatorKind.Assign) {
                    var leftName = "";
                    var left = be.LeftHandSide as UnifiedVariableIdentifier;
                    if (left != null) {
                        Console.WriteLine("left is \n{0}", left);
                        leftName = left.Name;
                    }
                    var right = be.RightHandSide as UnifiedNullLiteral;
                    if (right != null) {
                        Console.WriteLine("{0} is NULL", leftName);
                    }
                    yield return left;
                }
            }
        }

        public static IEnumerable<UnifiedElement> FindUses(
                UnifiedBlock codeObj) {
            var binaryExpressions =
                    codeObj.Descendants<UnifiedBinaryExpression>();
            foreach (var be in binaryExpressions) {
                if (be.Operator.Kind == UnifiedBinaryOperatorKind.Assign) {
                    var right = be.RightHandSide as UnifiedVariableIdentifier;
                    if (right != null) {
                        var rightName = right.Name;
                        Console.WriteLine("{0} is used", rightName);
                        yield return right;
                    }
                }
            }
        }

        //new
        public static IEnumerable<string> FindNullDefines(UnifiedBlock codeObj) {
            var binaryExpressions =
                    codeObj.Descendants<UnifiedBinaryExpression>();
            var definition = codeObj.Descendants<UnifiedVariableDefinition>();
            var nameList = new LinkedList<string>();
            foreach (var def in definition) {
                var nullDefinition = def.InitialValue as UnifiedNullLiteral;
                if (nullDefinition != null) {
                    Console.WriteLine("{0} defines null", def.Name.Name);
                    nameList.AddFirst(def.Name.Name);
                }
            }

            foreach (var be in binaryExpressions) {
                if (be.Operator.Kind == UnifiedBinaryOperatorKind.Assign) {
                    var right = be.RightHandSide as UnifiedNullLiteral;
                    var nullId = be.LeftHandSide as UnifiedVariableIdentifier;
                    if (right != null && nullId != null) {
                        Console.WriteLine("{0} will be null", nullId.Name);
                        nameList.AddFirst(nullId.Name);
                    }
                }
            }
            return nameList;
        }

        //new
        public static void FindUsesDefine(UnifiedBlock codeObj) {
            var defineNames = FindUses(codeObj);
            foreach (var defName in defineNames) {
                var name = defName;
                var elements =
                        codeObj.Descendants<UnifiedBinaryExpression>().Where(
                                e => name != e);
                var variableName = (UnifiedVariableIdentifier)defName;
                foreach (var element in elements) {
                    var left = element.LeftHandSide as UnifiedVariableIdentifier;
                    var right = element.RightHandSide as UnifiedNullLiteral;
                    if (left != null && left.Name.Equals(variableName.Name)) {
                        Console.WriteLine(
                                "{0} is {1}", left.Name, element.RightHandSide);
                    }
                }
            }
        }
    }
}