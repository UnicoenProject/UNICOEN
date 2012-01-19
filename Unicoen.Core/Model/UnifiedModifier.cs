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
    ///   修飾子を表します。 e.g. Javaにおける <c>public int method(){...}</c> の <c>public</c> e.g. Javaにおける <c>private String _str</c> の <c>private</c>
    /// </summary>
    public class UnifiedModifier : UnifiedElement {
        private UnifiedModifier() {}

        /// <summary>
        ///   修飾子の名前を表します
        /// </summary>
        public string Name { get; set; }

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

        public static UnifiedModifier Create(string name) {
            return new UnifiedModifier { Name = name };
        }
    }
}