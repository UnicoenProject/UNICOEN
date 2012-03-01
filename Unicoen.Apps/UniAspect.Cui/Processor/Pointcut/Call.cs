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
    public class Call : CodeProcessor {
        public override string PointcutName {
            get { return "call"; }
        }

        /// <summary>
        ///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="regex"> 対象関数を指定する正規表現 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtBeforeCall(
                UnifiedElement root, Regex regex, UnifiedBlock advice) {
            //get cass list
            var calls = root.Descendants<UnifiedCall>().ToList();

            //親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
            foreach (var call in calls) {
                //プロパティでない関数呼び出しのみを扱う
                //e.g. write()はOK. Math.max()はNG.
                var functionName = call.Function as UnifiedIdentifier;
                if (functionName == null) {
                    continue;
                }

                // 現状ではToString()とのマッチングを行う。
                var m = regex.Match(functionName.Name);
                if (!m.Success) {
                    continue;
                }

                //(Javaにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
                //(JavaScriptにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
                var block = call.Parent as UnifiedBlock;
                if (block != null) {
                    block.Insert(block.IndexOf(call, 0), advice.DeepCopy());
                }
            }
        }

        /// <summary>
        ///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="regex"> 対象関数を指定する正規表現 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtAfterCall(
                UnifiedElement root, Regex regex, UnifiedBlock advice) {
            //get cass list
            var calls = root.Descendants<UnifiedCall>().ToList();

            //親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
            foreach (var call in calls) {
                //プロパティでない関数呼び出しのみを扱う
                //e.g. write()はOK. Math.max()はNG.
                var functionName = call.Function as UnifiedIdentifier;
                if (functionName == null) {
                    continue;
                }

                var m = regex.Match(functionName.Name);
                if (!m.Success) {
                    continue;
                }

                //(Javaにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
                //(JavaScriptにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
                var block = call.Parent as UnifiedBlock;
                if (block != null) {
                    block.Insert(block.IndexOf(call, 0) + 1, advice.DeepCopy());
                }
            }
        }

        /// <summary>
        ///   すべての関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtBeforeCallAll(
                UnifiedElement root, UnifiedBlock advice) {
            InsertAtBeforeCall(root, new Regex(".*"), advice);
        }

        /// <summary>
        ///   すべての関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルードノード </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtAfterCallAll(
                UnifiedElement root, UnifiedBlock advice) {
            InsertAtAfterCall(root, new Regex(".*"), advice);
        }

        /// <summary>
        ///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルートノード </param>
        /// <param name="name"> 対象関数の名前 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtBeforeCallByName(
                UnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtBeforeCall(root, new Regex("^" + name + "$"), advice);
        }

        /// <summary>
        ///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
        /// </summary>
        /// <param name="root"> コードを追加するモデルのルードノード </param>
        /// <param name="name"> 対象関数の名前 </param>
        /// <param name="advice"> 挿入するコード断片 </param>
        public static void InsertAtAfterCallByName(
                UnifiedElement root, string name, UnifiedBlock advice) {
            InsertAtAfterCall(root, new Regex("^" + name + "$"), advice);
        }

        public override void Before(
                UnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtBeforeCallByName(model, targetName, advice);
        }

        public override void After(
                UnifiedElement model, string targetName, UnifiedBlock advice) {
            InsertAtAfterCallByName(model, targetName, advice);
        }

        public override void Around(UnifiedElement model) {
            throw new NotImplementedException();
        }
    }
}