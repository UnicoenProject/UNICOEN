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

namespace Unicoen.Model {
    /// <summary>
    ///   集合としての操作を備えている共通表現オブジェクトを表します．
    /// </summary>
    /// <typeparam name="TElement"> </typeparam>
    public interface IUnifiedElementCollection<TElement>
            : IUnifiedElement, IList<TElement>
            where TElement : class, IUnifiedElement {
        /// <summary>
        ///   共通表現の要素列を追加します．
        /// </summary>
        /// <param name="elements"> </param>
        void AddRange(IEnumerable<TElement> elements);
            }
}