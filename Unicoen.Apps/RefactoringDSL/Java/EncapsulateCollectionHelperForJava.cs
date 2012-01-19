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

using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.Java {
    public class EncapsulateCollectionHelperForJava {
        // Java におけるリスト要素の追加を作成する例
        public static UnifiedBlock GenerateAddingProcedureForList(
                UnifiedVariableDefinition list) {
            var name = list.Name;
            var property = UnifiedProperty.Create(
                    ".",
                    name.DeepCopy(),
                    UnifiedIdentifier.CreateLabel("add"));
            var call = UnifiedCall.Create();
            call.Function = property;

            var argument =
                    UnifiedArgument.Create(
                            UnifiedIdentifier.CreateLabel("object"));
            var arguments = UnifiedArgumentCollection.Create(argument);
            call.Arguments = arguments;

            var block = UnifiedBlock.Create();
            block.Add(call);

            return block;
        }

        // Javaにおけるリスト要素の削除を作成する例
        public static UnifiedBlock GenerateRemovingProcedureForList(
                UnifiedVariableDefinition list) {
            var name = list.Name;

            var property = UnifiedProperty.Create(
                    ".",
                    name.DeepCopy(),
                    UnifiedIdentifier.CreateLabel("remove"));
            var call = UnifiedCall.Create();
            call.Function = property;

            var argument =
                    UnifiedArgument.Create(UnifiedIdentifier.CreateLabel("i"));
            var arguments = UnifiedArgumentCollection.Create(argument);
            call.Arguments = arguments;

            var block = UnifiedBlock.Create();
            block.Add(call);

            return block;
        }
    }
}