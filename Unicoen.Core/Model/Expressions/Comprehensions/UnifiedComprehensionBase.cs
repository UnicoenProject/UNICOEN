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
    public abstract class UnifiedComprehensionBase
            : UnifiedElement, IUnifiedExpression {
        protected IUnifiedExpression _element;

        protected UnifiedExpressionCollection _generator;

        /// <summary>
        ///   リスト内包表記によって生成される要素部分の式を表します．
        /// </summary>
        public IUnifiedExpression Element {
            get { return _element; }
            set { _element = SetChild(value, _element); }
        }

        /// <summary>
        ///   リスト内包表記の集合部分の式を表します．
        /// </summary>
        public UnifiedExpressionCollection Generator {
            get { return _generator; }
            set { _generator = SetChild(value, _generator); }
        }
            }
}