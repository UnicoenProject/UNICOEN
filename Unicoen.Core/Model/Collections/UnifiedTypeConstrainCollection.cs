﻿#region License

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
    ///   型が持つ性質（継承関係など）の集合を表します。
    ///   e.g. Javaにおける<c>public class A extends B</c>の<c>extends B</c>
    ///   e.g. Javaにおける<c>ArrayList&lt;? extends Object&gt;</c>の<c>extends Object</c>
    /// </summary>
    public class UnifiedTypeConstrainCollection
            : UnifiedElementCollection
                      <UnifiedTypeConstrain, UnifiedTypeConstrainCollection> {
        protected UnifiedTypeConstrainCollection() {}

        [DebuggerStepThrough]
        public override void Accept(IUnifiedVisitor visitor) {
            visitor.Visit(this);
        }

        public override UnifiedTypeConstrainCollection CreateSelf() {
            return new UnifiedTypeConstrainCollection();
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
                      }
}