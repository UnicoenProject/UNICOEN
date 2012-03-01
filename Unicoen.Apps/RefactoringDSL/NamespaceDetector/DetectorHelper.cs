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
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
    ///<summary>
    ///  Detecter 用のヘルパメソッド群
    ///</summary>
    public class DetectorHelper {
        /// <summary>
        ///   node から親をたどって，teypArray に含まれる要素のうち，一番早く見つかったものを返します．最上位ノードまで探索して，見つからなかったら null を返します．
        /// </summary>
        /// <param name="node"> 検索対象のノード </param>
        /// <param name="typeArray"> 検索する型の集合（の集合） </param>
        /// <returns> 1番早く見つかったオブジェクト </returns>
        public static UnifiedElement GetFirstFoundNode(
                UnifiedElement node, IEnumerable<IEnumerable<Type>> typeArray) {
            foreach (var ancestor in node.Ancestors()) {
                foreach (var types in typeArray) {
                    foreach (var t in types) {
                        if (ancestor.GetType().Equals(t)) {
                            return ancestor;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///   自分の親になり得る，かつ，名前空間構成要素になりうる要素タイプを取得します
        /// </summary>
        /// <param name="type"> 名前空間構成要素タイプ </param>
        /// <returns> 親になる名前空間構成要素タイプの集合 </returns>
        public static NamespaceType[] GetParentTypes(NamespaceType type) {
            switch (type) {
            case NamespaceType.Package:
                return new NamespaceType[] { };
            case NamespaceType.Class:
                return new[] { NamespaceType.Class, NamespaceType.Package };
            case NamespaceType.Function:
                return new[] {
                        NamespaceType.Class, NamespaceType.Package,
                        NamespaceType.Function
                };
            case NamespaceType.Variable:
                return new[] {
                        NamespaceType.Class, NamespaceType.Function,
                        NamespaceType.TemporaryScope
                };
            case NamespaceType.TemporaryScope:
                return new[]
                { NamespaceType.Function, NamespaceType.TemporaryScope };
            default:
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///   名前空間要素タイプから対応する Unified 型（型オブジェクト）へ変換します
        /// </summary>
        /// <param name="type"> 名前空間構成要素タイプ </param>
        /// <returns> type に対応する Unified 型（型オブジェクト）の集合 </returns>
        public static IEnumerable<Type> Namespace2UnifiedType(
                NamespaceType type) {
            switch (type) {
            case NamespaceType.Package:
                return new List<Type>
                { UnifiedNamespaceDefinition.Create().GetType() };
            case NamespaceType.Class:
                return new List<Type>
                { UnifiedClassDefinition.Create().GetType() };
            case NamespaceType.Function:
                return new List<Type>
                { UnifiedFunctionDefinition.Create().GetType() };
            case NamespaceType.TemporaryScope:
                return new List<Type> {
                        UnifiedForeach.Create().GetType(),
                        UnifiedFor.Create().GetType(),
                        UnifiedWhile.Create().GetType(),
                        UnifiedDoWhile.Create().GetType(),
                };
            default:
                throw new InvalidOperationException();
            }
        }
    }
}