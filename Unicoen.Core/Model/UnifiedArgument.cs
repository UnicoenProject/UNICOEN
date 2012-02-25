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
    ///   実引数を表します。
    ///   e.g. Javaにおける<c>method(a, b, c)</c>の<c>a</c>
    /// </summary>
    public class UnifiedArgument : UnifiedElement {
        private UnifiedModifierCollection _modifiers;

        /// <summary>
        ///   実引数の修飾子を表します．
        ///   e.g. C#における<code>method(out v);</code>の<code>out</code>
        /// </summary>
        public UnifiedModifierCollection Modifiers {
            get { return _modifiers; }
            set { _modifiers = SetChild(value, _modifiers); }
        }

        private IUnifiedExpression _value;

        /// <summary>
        ///   実引数の値を表します．
        /// </summary>
        public IUnifiedExpression Value {
            get { return _value; }
            set { _value = SetChild(value, _value); }
        }

        private UnifiedIdentifier _target;

        /// <summary>
        ///   実引数の代入先の変数名を表します．
        /// </summary>
        // TODO: 名前が分かりづらいのでは？
        public UnifiedIdentifier Target {
            get { return _target; }
            set { _target = SetChild(value, _target); }
        }

        private UnifiedArgument() {}

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

        public static UnifiedArgument Create(
                IUnifiedExpression value, UnifiedIdentifier target = null,
                UnifiedModifierCollection modifiers = null) {
            return new UnifiedArgument {
                    Modifiers = modifiers,
                    Value = value,
                    Target = target,
            };
        }
    }
}