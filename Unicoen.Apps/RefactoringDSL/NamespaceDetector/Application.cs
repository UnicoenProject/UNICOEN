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

using System.Collections.Generic;
using System.Linq;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
    public class Application {
        /// <summary>
        ///   完全修飾名からコードオブジェクトを検索し，取得します
        /// </summary>
        /// <param name="nsString"> 完全修飾氏名文字列 </param>
        /// <param name="element"> 検索するトップノード </param>
        /// <returns> 検出されたコードオブジェクトの配列（通常，要素数は0または1です） </returns>
        public static IEnumerable<UnifiedElement> FindUnifiedElementByNamespace
                (string nsString, UnifiedElement element) {
            var result = new List<UnifiedElement>();
            foreach (var e in element.Descendants()) {
                var ns = Detector.Dispatcher(e);
                if (ns != null) {
                    if (ns.GetNamespaceString().Equals(nsString)) {
                        result.Add(e);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   関数呼び出しがされている，名前空間を特定する
        /// </summary>
        /// <param name="callNode"> </param>
        /// <returns> </returns>
        public static Namespace GetBelongingNamespace(UnifiedCall callNode) {
            var upperTypes = new[]
            { NamespaceType.Function, NamespaceType.TemporaryScope };
            var unifiedtTypes =
                    upperTypes.Select(
                            e => DetectorHelper.Namespace2UnifiedType(e));
            var firstFound = DetectorHelper.GetFirstFoundNode(
                    callNode, unifiedtTypes);
            if (firstFound == null) {
                return null;
            }

            var belongingSpace = Detector.Dispatcher(firstFound);
            return belongingSpace;
        }

        /// <summary>
        ///   関数呼び出しから，定義を探します
        /// </summary>
        /// <param name="callNode"> 関数呼び出しノード </param>
        /// <param name="topNode"> 検索対象のトップノード </param>
        /// <returns> 呼び出された関数の定義 </returns>
        public static UnifiedFunctionDefinition FindDefinition(
                UnifiedCall callNode, UnifiedElement topNode) {
            var belongingNamespace = GetBelongingNamespace(callNode);
            var callingFuncName =
                    ((UnifiedVariableIdentifier)callNode.Function).Name;

            UnifiedFunctionDefinition parent = null;
            foreach (var ns in belongingNamespace.YieldParents()) {
                var unifiedElement =
                        FindUnifiedElementByNamespace(
                                ns.GetNamespaceString(), topNode);
                var element = unifiedElement.First();
                var found =
                        element.Descendants<UnifiedFunctionDefinition>().Where(
                                e => e.Name.Name == callingFuncName);
                if (found.Count() > 0) {
                    parent = found.First();
                    break;
                }
            }
            // 呼び出しがあるのに，定義がない場合（標準関数など）は null が変える

            return parent;
        }
    }
}