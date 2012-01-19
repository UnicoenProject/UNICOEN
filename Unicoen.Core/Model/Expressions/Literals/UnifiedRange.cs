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
    ///   範囲リテラルを表します． e.g. Rubyにおける <c>1..2</c> や <c>1...3</c>
    /// </summary>
    public class UnifiedRange : UnifiedElement, IUnifiedExpression {
        private IUnifiedExpression _max;
        private IUnifiedExpression _min;
        private UnifiedRange() {}

        public IUnifiedExpression Min {
            get { return _min; }
            set { _min = SetChild(value, _min); }
        }

        public IUnifiedExpression Max {
            get { return _max; }
            set { _max = SetChild(value, _max); }
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

        public static UnifiedRange Create(
                IUnifiedExpression min = null,
                IUnifiedExpression max = null) {
            return new UnifiedRange {
                    Min = min,
                    Max = max,
            };
        }

        public static UnifiedRange CreateNotContainingMax(
                IUnifiedExpression min = null,
                IUnifiedExpression max = null) {
            return new UnifiedRange {
                    Min = min,
                    Max = UnifiedBinaryExpression.Create(
                            max,
                            UnifiedBinaryOperator.Create(
                                    "-", UnifiedBinaryOperatorKind.Subtract),
                            UnifiedIntegerLiteral.CreateInt32(-1)),
            };
        }
    }
}