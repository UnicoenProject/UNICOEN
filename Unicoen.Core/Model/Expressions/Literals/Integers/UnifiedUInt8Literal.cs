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
using System.Numerics;
using Paraiba.Numerics;
using Unicoen.Processor;

namespace Unicoen.Model {
    /// <summary>
    ///   整数のリテラルを表します。 e.g. Javaにおける <c>int i = 10;</c> の <c>10</c> の部分
    /// </summary>
    public class UnifiedUInt8Literal : UnifiedIntegerLiteral {
        private UnifiedUInt8Literal() {}

        public override BigInteger Value {
            get { return _value; }
            set { _value = value.ToForceUInt8(); }
        }

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

        public static UnifiedUInt8Literal Create(BigInteger value) {
            return new UnifiedUInt8Literal {
                    Value = value,
            };
        }
    }
}