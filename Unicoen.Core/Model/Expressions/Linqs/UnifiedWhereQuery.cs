#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
    ///   LINQのクエリ式を構成するwhere 句を表します。
    ///   e.g. C#における<c>where p.X > 2</c>
    /// </summary>
    public class UnifiedWhereQuery : UnifiedLinqQuery {
        private IUnifiedExpression _condition;

        /// <summary>
        ///   抽出の条件式を取得もしくは設定します．
        ///   e.g. C#における<c>where p.X > 2</c>
        /// </summary>
        public IUnifiedExpression Condition {
            get { return _condition; }
            set { _condition = SetChild(value, _condition); }
        }

        protected UnifiedWhereQuery() {}

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

        public static UnifiedWhereQuery Create(IUnifiedExpression condition) {
            return new UnifiedWhereQuery {
                    Condition = condition,
            };
        }
    }
}