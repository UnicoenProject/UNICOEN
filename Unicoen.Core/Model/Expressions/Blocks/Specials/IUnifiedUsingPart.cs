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

namespace Unicoen.Model {
    /// <summary>
    ///   リソース管理に用いられるローンパターンを提供する構文の構成要素を表します。 e.g. C#における <c>using(var r = new StreamReader(path)){...}</c> の <c>var r = new StreamReader(path)</c> e.g. Pythonにおける <c>with file(p1) as f1, file(p2) as f2:</c> の <c>file(p1) as f1</c>
    /// </summary>
    public interface IUnifiedUsingPart : IUnifiedElement {
        /// <summary>
        ///   管理対象のリソースの値を受け取る左辺式や変数宣言を取得もしくは設定します． e.g. C#における <c>using(var r = new StreamReader(path)){...}</c> の <c>var r</c> e.g. Pythonにおける <c>with file(p1) as f1:</c> の <c>f1</c>
        /// </summary>
        UnifiedVariableDefinition VariableDefinition { get; set; }

        /// <summary>
        ///   管理対象のリソースの値を受け取る左辺式や変数宣言を取得もしくは設定します． e.g. C#における <c>using(var r = new StreamReader(path)){...}</c> の <c>var r</c> e.g. Pythonにおける <c>with file(p1) as f1:</c> の <c>f1</c>
        /// </summary>
        IUnifiedExpression Assign { get; set; }

        /// <summary>
        ///   管理対象のリソースが得られる式を取得もしくは設定します． e.g. C#における <c>using(var r = new StreamReader(path)){...}</c> の <c>new StreamReader(path)</c> e.g. Pythonにおける <c>with file(p1) as f1:</c> の <c>file(p1)</c>
        /// </summary>
        IUnifiedExpression Target { get; set; }
    }
}