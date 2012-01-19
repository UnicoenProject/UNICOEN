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
    ///   Cast式を表します。 e.g. Javaにおける <c>(int)a</c>
    /// </summary>
    public class UnifiedCast : UnifiedElement, IUnifiedExpression {
        private IUnifiedExpression _expression;
        private UnifiedType _type;
        private UnifiedCast() {}

        /// <summary>
        ///   キャスト先の型を表します e.g. Javaにおける <c>(int)a</c> の <c>int</c>
        /// </summary>
        public UnifiedType Type {
            get { return _type; }
            set { _type = SetChild(value, _type); }
        }

        /// <summary>
        ///   キャスト対象の式を表します e.g. Javaにおける <c>(int)a</c> の <c>a</c>
        /// </summary>
        public IUnifiedExpression Expression {
            get { return _expression; }
            set { _expression = SetChild(value, _expression); }
        }

        #region IUnifiedExpression Members

        [DebuggerStepThrough]
        public override void Accept(IUnifiedVisitor visitor) {
            visitor.Visit(this);
        }

        [DebuggerStepThrough]
        public override void Accept<TArg>(
                IUnifiedVisitor<TArg> visitor,
                TArg arg) {
            visitor.Visit(this, arg);
        }

        [DebuggerStepThrough]
        public override TResult Accept<TArg, TResult>(
                IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        #endregion

        public static UnifiedCast Create(
                UnifiedType type,
                IUnifiedExpression createExpression) {
            return new UnifiedCast {
                    Type = type,
                    Expression = createExpression
            };
        }
    }
}