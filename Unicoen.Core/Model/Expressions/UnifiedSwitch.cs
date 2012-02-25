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
    ///   switch文を表します。
    ///   e.g. Javaにおける<c>switch(v){...}</c>
    /// </summary>
    public class UnifiedSwitch : UnifiedElement, IUnifiedExpression {
        private IUnifiedExpression _value;

        /// <summary>
        ///   caseの分岐に使用される式を表します
        ///   e.g. Javaにおける<c>switch(v){...}</c>の<c>v</c>
        /// </summary>
        public IUnifiedExpression Value {
            get { return _value; }
            set { _value = SetChild(value, _value); }
        }

        private UnifiedCaseCollection _cases;

        /// <summary>
        ///   switch文に付随するcase節の集合を表します
        /// </summary>
        public UnifiedCaseCollection Cases {
            get { return _cases; }
            set { _cases = SetChild(value, _cases); }
        }

        private UnifiedSwitch() {}

        public UnifiedSwitch AddToCases(UnifiedCase kase) {
            Cases.Add(kase);
            return this;
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

        public static UnifiedSwitch Create(
                IUnifiedExpression value = null,
                UnifiedCaseCollection cases = null) {
            return new UnifiedSwitch {
                    Value = value,
                    Cases = cases,
            };
        }
    }
}