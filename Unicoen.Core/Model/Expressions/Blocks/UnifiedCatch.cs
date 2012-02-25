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
    ///   catch/rescue節を表します。
    ///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>の部分
    /// </summary>
    public class UnifiedCatch : UnifiedElement, IUnifiedExpression {
        private UnifiedAnnotationCollection _annotations;
        private UnifiedModifierCollection _modifiers;
        private UnifiedTypeCollection _types;
        private IUnifiedExpression _assign;
        private UnifiedBlock _body;

        /// <summary>
        ///   アノテーションの集合を取得または設定します．
        /// </summary>
        public UnifiedAnnotationCollection Annotations {
            get { return _annotations; }
            set { _annotations = SetChild(value, _annotations); }
        }

        /// <summary>
        ///   修飾子の集合を取得または設定します．
        ///   e.g. Javaにおける<c>public static int a</c>の<c>public static</c>
        /// </summary>
        public UnifiedModifierCollection Modifiers {
            get { return _modifiers; }
            set { _modifiers = SetChild(value, _modifiers); }
        }

        /// <summary>
        ///   受け取る例外の型の集合を取得もしくは設定します．
        ///   e.g. JavaとC#における<c>catch (Exception e) { ... }</c>の<c>Exception</c>
        ///   e.g. C#における<c>catch (Exception) { ... }</c>の<c>Exception</c>
        /// </summary>
        public UnifiedTypeCollection Types {
            get { return _types; }
            set { _types = SetChild(value, _types); }
        }

        /// <summary>
        ///   例外オブジェクトを受け取る左辺式（≠変数宣言）を取得もしくは設定します．
        ///   e.g. JavaとC#における<c>catch (Exception e) { ... }</c>の<c>e</c>
        ///   e.g. Rubyにおける<c>rescue ArgumentError, TypeError => e</c>の<c>e</c>
        /// </summary>
        public IUnifiedExpression Assign {
            get { return _assign; }
            set { _assign = SetChild(value, _assign); }
        }

        /// <summary>
        ///   ブロックを取得します．
        /// </summary>
        public UnifiedBlock Body {
            get { return _body; }
            set { _body = SetChild(value, _body); }
        }

        protected UnifiedCatch() {}

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

        public static UnifiedCatch Create(
                UnifiedTypeCollection types,
                IUnifiedExpression assign,
                UnifiedBlock body = null,
                UnifiedAnnotationCollection annotations = null,
                UnifiedModifierCollection modifiers = null) {
            return new UnifiedCatch {
                    Annotations = annotations,
                    Modifiers = modifiers,
                    Types = types,
                    Assign = assign,
                    Body = body,
            };
        }
    }
}