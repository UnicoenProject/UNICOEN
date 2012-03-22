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

namespace Unicoen.Apps.RefactoringDSL {
    /// <summary>
    ///   EncapsulateField リファクタリングを行うためのクラス
    /// </summary>
    public class EncapsulateField {
        // コンストラクタ
        public EncapsulateField(UnifiedProgram program) {
            Program = program;
        }

        private UnifiedProgram Program { get; set; }

        public UnifiedProgram Refactor(String className) {
            // 一応コピー
            var model = Program.DeepCopy();
            var targetClass =
                    EncapsulateFieldHelper.FindByClassName(model, "Foo").First();
            var publicVariables =
                    EncapsulateFieldHelper.FindPublicFields(targetClass);

            var getters = new List<UnifiedFunctionDefinition>();
            var setters = new List<UnifiedFunctionDefinition>();
            // ゲッタとセッタを生成
            foreach (var v in publicVariables) {
                getters.Add(EncapsulateFieldHelper.GenerateGetter(v));
                setters.Add(EncapsulateFieldHelper.GenerateSetter(v));
            }

            // フィールドを private に変更
            foreach (var pv in publicVariables) {
                EncapsulateFieldHelper.ChangeModifier(pv, "private");
            }

            var list = targetClass.Body.DeepCopy();
            // 元の要素群とアクセッサを結合
            // var list = new List<UnifiedExpression>();
            foreach (var getter in getters) {
                list.Add(getter);
            }
            foreach (var setter in setters) {
                list.Add(setter);
            }

            // var newBody = UnifiedBlock.Create(list);
            // var newBody = list;

            targetClass.Body = list;

            return model;
        }
    }
}