﻿#region License

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

using Unicoen.Processor;

namespace Unicoen.Model {
    public static class ModelExtensions {
        /// <summary>
        ///   指定しオブジェクトのプロパティを再帰的に比較してオブジェクト同士の等価性を判断します．
        /// </summary>
        /// <param name="element"> </param>
        /// <param name="that"> </param>
        /// <returns> </returns>
        public static bool StructuralEquals(
                this IUnifiedElement element, IUnifiedElement that) {
            return StructuralEqualityComparer.StructuralEquals(element, that);
        }
    }
}