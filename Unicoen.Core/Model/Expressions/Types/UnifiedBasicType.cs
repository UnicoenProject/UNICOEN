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
    ///   型を表します。 Javaにおける <c>int, double, char</c>
    /// </summary>
    public class UnifiedBasicType : UnifiedType {
        // パッケージ名が付いているときに
        // UnifiedProperty が name に入る時があるので
        // isntace.Class
        private IUnifiedExpression _basicTypeName;

        internal UnifiedBasicType() {}

        /// <summary>
        ///   型の基礎部分の名前を表します． e.g. Javaにおける <c>Package.ClassA instance = null;</c> の <c>Package.ClassA</c> (UnifiedPropertyで表現される) e.g. Javaにおける <c>ArrayList&lt;Integer&gt;</c> の <c>ArrayList</c>
        /// </summary>
        public override IUnifiedExpression BasicTypeName {
            get { return _basicTypeName; }
            set { _basicTypeName = SetChild(value, _basicTypeName); }
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
    }
}