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

using System;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.Python2.CodeGenerators {
    public partial class Python2CodeFactoryVisitor {
        private static Tuple<string, string> GetRequiredParen(
                UnifiedElement element) {
            var parent = element.Parent;
            if (parent is UnifiedUnaryExpression ||
                parent is UnifiedBinaryExpression ||
                parent is UnifiedTernaryExpression) {
                return Tuple.Create("(", ")");
            }
            return Tuple.Create("", "");
        }

        // e.g. (Int)a  or (int)(a + b)
        public override bool Visit(UnifiedCast element, VisitorArgument arg) {
            Writer.Write("(");
            element.Type.TryAccept(this, arg);
            Writer.Write(")");
            element.Expression.TryAccept(this, arg.Set(Paren));
            return false;
        }

        public override bool Visit(
                UnifiedTernaryExpression element, VisitorArgument arg) {
            var paren = GetRequiredParen(element);
            Writer.Write(paren.Item1);
            element.Condition.TryAccept(this, arg.Set(Paren));
            Writer.Write(" ? ");
            element.TrueExpression.TryAccept(this, arg.Set(Paren));
            Writer.Write(" : ");
            element.FalseExpression.TryAccept(this, arg.Set(Paren));
            Writer.Write(paren.Item2);
            return false;
        }

        public override bool Visit(UnifiedImport element, VisitorArgument arg) {
            Writer.Write("import ");
            element.Modifiers.TryAccept(this, arg);
            element.Name.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedBinaryExpression element, VisitorArgument arg) {
            var paren = GetRequiredParen(element);
            Writer.Write(paren.Item1);
            element.LeftHandSide.TryAccept(this, arg.Set(Paren));
            Writer.Write(" ");
            element.Operator.TryAccept(this, arg);
            Writer.Write(" ");
            element.RightHandSide.TryAccept(this, arg.Set(Paren));
            Writer.Write(paren.Item2);
            return false;
        }

        public override bool Visit(UnifiedCall element, VisitorArgument arg) {
            var prop = element.Function as UnifiedProperty;
            if (prop != null) {
                prop.Owner.TryAccept(this, arg);
                Writer.Write(prop.Delimiter);
                element.GenericArguments.TryAccept(this, arg);
                prop.Name.TryAccept(this, arg);
            } else {
                // Javaでifが実行されるケースは存在しないが、言語変換のため
                if (element.GenericArguments != null) {
                    Writer.Write("this.");
                }
                element.GenericArguments.TryAccept(this, arg);
                element.Function.TryAccept(this, arg);
            }
            element.Arguments.TryAccept(this, arg.Set(Paren));
            return false;
        }

        public override bool Visit(UnifiedNew element, VisitorArgument arg) {
            Writer.Write("new ");
            element.GenericArguments.TryAccept(this, arg);
            element.Target.TryAccept(this, arg);
            element.Arguments.TryAccept(this, arg.Set(Paren));
            element.InitialValue.TryAccept(this, arg.Set(Brace));
            element.Body.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedUnaryExpression element, VisitorArgument arg) {
            if (element.Operator.Kind
                == UnifiedUnaryOperatorKind.PostIncrementAssign ||
                element.Operator.Kind
                == UnifiedUnaryOperatorKind.PostDecrementAssign) {
                element.Operand.TryAccept(this, arg.Set(Paren));
                element.Operator.TryAccept(this, arg);
            } else {
                element.Operator.TryAccept(this, arg);
                element.Operand.TryAccept(this, arg.Set(Paren));
            }
            return false;
        }

        public override bool Visit(UnifiedProperty element, VisitorArgument arg) {
            element.Owner.TryAccept(this, arg);
            Writer.Write(element.Delimiter);
            element.Name.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(UnifiedBreak element, VisitorArgument arg) {
            Writer.Write("break ");
            return true;
        }

        public override bool Visit(UnifiedContinue element, VisitorArgument arg) {
            Writer.Write("continue ");
            return true;
        }

        public override bool Visit(UnifiedReturn element, VisitorArgument arg) {
            Writer.Write("return ");
            element.Value.TryAccept(this, arg);
            return true;
        }

        public override bool Visit(UnifiedGoto element, VisitorArgument arg) {
            Writer.Write("goto ");
            element.Target.TryAccept(this, arg);
            return true;
        }

        public override bool Visit(
                UnifiedYieldReturn element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(UnifiedDelete element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(UnifiedThrow element, VisitorArgument arg) {
            Writer.Write("raise ");
            element.Value.TryAccept(this, arg);
            return true;
        }

        public override bool Visit(UnifiedAssert element, VisitorArgument arg) {
            Writer.Write("assert ");
            element.Value.TryAccept(this, arg);
            element.Message.TryAccept(this, arg.Set(CommaMostLeft));
            return true;
        }

        public override bool Visit(UnifiedExec element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(
                UnifiedStringConversion element, VisitorArgument data) {
            throw new NotImplementedException();
        }
    }
}