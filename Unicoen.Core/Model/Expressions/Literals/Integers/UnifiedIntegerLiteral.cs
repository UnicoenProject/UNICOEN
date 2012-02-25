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

using System.Numerics;

namespace Unicoen.Model {
    /// <summary>
    ///   整数のリテラルを表します。
    ///   e.g. Javaにおける<c>int i = 10;</c>の<c>10</c>の部分
    /// </summary>
    public abstract class UnifiedIntegerLiteral
            : UnifiedTypedLiteral<BigInteger> {
        protected BigInteger _value;

        public static UnifiedIntegerLiteral CreateInt8(BigInteger value) {
            return UnifiedInt8Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateInt16(BigInteger value) {
            return UnifiedInt16Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateInt31(BigInteger value) {
            return UnifiedInt31Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateInt32(BigInteger value) {
            return UnifiedInt32Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateInt64(BigInteger value) {
            return UnifiedInt64Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateUInt8(BigInteger value) {
            return UnifiedUInt8Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateUInt16(BigInteger value) {
            return UnifiedUInt16Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateUInt31(BigInteger value) {
            return UnifiedUInt31Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateUInt32(BigInteger value) {
            return UnifiedUInt32Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateUInt64(BigInteger value) {
            return UnifiedUInt64Literal.Create(value);
        }

        public static UnifiedIntegerLiteral CreateBigInteger(BigInteger value) {
            return UnifiedBigIntLiteral.Create(value);
        }
            }
}