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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
    /// <summary>
    ///   LINQのクエリ式を構成するorderby句で指定するキーを表します。 e.g. C#における <c>orderby p.X descending</c> の <c>p.X descending</c>
    /// </summary>
    public class UnifiedOrderByKey : UnifiedElement {
        private IUnifiedExpression _expression;
        protected UnifiedOrderByKey() {}

        /// <summary>
        ///   ソートを行うキーを取得もしくは設定します． e.g. C#における <c>orderby p.X descending</c> の <c>p.X</c>
        /// </summary>
        public IUnifiedExpression Expression {
            get { return _expression; }
            set { _expression = SetChild(value, _expression); }
        }

        /// <summary>
        ///   昇順でソートするかどうかを取得もしくは設定します． e.g. C#における <c>orderby p.X descending</c> の <c>descending</c>
        /// </summary>
        public bool Ascending { get; set; }

        [DebuggerStepThrough]
        public override void Accept(IUnifiedVisitor visitor) {
            visitor.Visit(this);
        }

        [DebuggerStepThrough]
        public override void Accept<TArg>(
                IUnifiedVisitor<TArg> visitor, TArg arg) {
            visitor.Visit(this, arg);
        }

        [DebuggerStepThrough]
        public override TResult Accept<TArg, TResult>(
                IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        public static UnifiedOrderByKey Create(
                IUnifiedExpression expression, bool ascending) {
            return new UnifiedOrderByKey {
                    Expression = expression,
                    Ascending = ascending,
            };
        }
    }
}