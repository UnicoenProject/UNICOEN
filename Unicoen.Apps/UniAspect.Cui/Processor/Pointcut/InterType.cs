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
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
    public class InterType {
        /// <summary>
        ///   指定されたクラスまたはプログラムに指定されたフィールドやメソッドを追加します。
        /// </summary>
        /// <param name="program"> メンバーを追加するモデルのルートノード </param>
        /// <param name="name"> 対象となるクラスやプログラムを指定する名前 </param>
        /// <param name="members"> 挿入するメンバーのリスト </param>
        public static void AddIntertypeDeclaration(
                UnifiedProgram program, string name,
                List<UnifiedExpression> members) {
            //クラスのリストを取得(Java, C#向け)
            var classes = program.Descendants<UnifiedClassDefinition>();
            if (classes.Count() > 0) {
                foreach (var c in classes) {
                    //クラス名を取得
                    var className = c.Name as UnifiedVariableIdentifier;
                    if (className == null) {
                        continue;
                    }

                    //受け取った名前を正規表現に変換し、クラス名が一致する場合は合成する
                    var regex = new Regex(name == "*" ? ".*" : name);
                    var m = regex.Match(className.Name);
                    if (m.Success) {
                        foreach (var e in members) {
                            c.Body.Insert(0, e.DeepCopy());
                        }
                    }
                }
                return;
            }
            //TODO interfaceのようにUnifiedClassDefinitionがない場合はここまでくるのでどう対処するか
            //とりあえず応急処置
            var interfaces = program.Descendants<UnifiedInterfaceDefinition>();
            if (interfaces.Count() > 0) {
                return;
            }
            var enums = program.Descendants<UnifiedEnumDefinition>();
            if (enums.Count() > 0) {
                return;
            }

            //プログラムに対してメンバーを追加(JavaScript向け))
            if (program != null) {
                foreach (var e in members) {
                    program.Body.Insert(0, e.DeepCopy());
                }
            }
        }
    }
}