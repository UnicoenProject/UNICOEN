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
using System.Linq;
using Unicoen.Apps.RefactoringDSL.Java;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL {
    public class EncapsulateCollection {
        // コンストラクタ
        public EncapsulateCollection(UnifiedProgram program) {
            Program = program;
        }

        private UnifiedProgram Program { get; set; }

        public UnifiedProgram Refactor(string className) {
            var model = Program.DeepCopy();
            var targetClass =
                    FindUtil.FindClassByClassName(model, className).First();
            if (targetClass == null) {
                throw new ClassNotFoundException();
            }
            var body = targetClass.Body.DeepCopy();

            // TODO コレクションタイプの任意・複数指定
            var collections = FindUtil.FindGenericsField(body, "List");
            var rfs =
                    EncapsulateCollectionHelper.FindReturningCollectionFunction(
                            body, collections);

            // コレクションをそのまま返却している関数を削除
            var count = rfs.Count();
            for (var i = 0; i < count; i++) {
                rfs.First().RemoveSelf();
            }

            // コレクションを丸ごとセットしているような関数を削除
            var sfs =
                    EncapsulateCollectionHelper.FindSettingCollectionFunction(
                            body, collections);
            count = sfs.Count();
            for (var i = 0; i < count; i++) {
                sfs.First().RemoveSelf();
            }

            // add / remove / colne メソッドを追加
            // TODO コレクションタイプの任意・複数指定
            var genericParameters = FindUtil.FindGenericsField(model, "List");
            foreach (var gp in genericParameters) {
                var addingProcedure =
                        EncapsulateCollectionHelperForJava.
                                GenerateAddingProcedureForList(
                                        (UnifiedVariableDefinition)gp);
                var removingProcedure =
                        EncapsulateCollectionHelperForJava.
                                GenerateRemovingProcedureForList(
                                        (UnifiedVariableDefinition)gp);

                var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(
                        gp, "addItem", addingProcedure);
                var removeMethod =
                        EncapsulateCollectionHelper.GenerateRemoveMethod(
                                gp, "removeItem", removingProcedure);
                var collectionFieldGetter =
                        EncapsulateCollectionHelper.GenerateClonedFieldGetter(
                                (UnifiedVariableDefinition)gp);

                body.Add(addMethod);
                body.Add(removeMethod);
                body.Add(collectionFieldGetter);
            }

            targetClass.Body = body;
            return model;
        }
    }

    public class ClassNotFoundException : Exception {
        public ClassNotFoundException() : base("クラス探したけど見つからなかったorz") {}
    }
}