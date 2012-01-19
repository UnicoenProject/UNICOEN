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
        #region program, namespace, class, method, filed ...

        public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
            element.Comments.TryAccept(this, arg);
            Writer.WriteLine();
            element.Body.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedNamespaceDefinition element, VisitorArgument arg) {
            // パッケージはディレクトリ構造で表現
            Writer.Write("# ");
            element.Modifiers.TryAccept(this, arg);
            Writer.Write("package");
            Writer.Write(" ");
            element.Name.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedClassDefinition element, VisitorArgument arg) {
            element.Annotations.TryAccept(this, arg);
            element.Modifiers.TryAccept(this, arg);
            Writer.Write("class");
            Writer.Write(" ");
            element.Name.TryAccept(this, arg);
            Writer.Write(":");
            Writer.Write(" # ");
            element.GenericParameters.TryAccept(this, arg);
            element.Constrains.TryAccept(this, arg);
            Writer.WriteLine();

            element.Body.TryAccept(this, arg.IncrementDepth());
            return false;
        }

        public override bool Visit(
                UnifiedFunctionDefinition element, VisitorArgument arg) {
            element.Annotations.TryAccept(this, arg);
            element.Modifiers.TryAccept(this, arg);
            Writer.Write("def ");
            element.Name.TryAccept(this, arg);
            element.Parameters.TryAccept(this, arg);
            Writer.WriteLine(":");

            element.Body.TryAccept(this, arg.IncrementDepth());
            return false;
        }

        public override bool Visit(
                UnifiedParameter element, VisitorArgument arg) {
            element.Annotations.TryAccept(this, arg);
            element.Modifiers.TryAccept(this, arg);
            element.Names.TryAccept(this, arg.Set(CommaDelimiter));
            if (element.DefaultValue != null) {
                Writer.Write(" = ");
                element.DefaultValue.TryAccept(this, arg);
            }
            return false;
        }

        public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        #endregion

        #region statement

        public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
            foreach (var stmt in element) {
                WriteIndent(arg.IndentDepth);
                stmt.TryAccept(this, arg);
                Writer.WriteLine();
            }
            return false;
        }

        public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
            Writer.Write("if ");
            ifStatement.Condition.TryAccept(this, arg);
            Writer.WriteLine(":");
            ifStatement.Body.TryAccept(this, arg.IncrementDepth());
            if (ifStatement.ElseBody != null) {
                WriteIndent(arg.IndentDepth);
                Writer.WriteLine("else:");
                ifStatement.ElseBody.TryAccept(this, arg.IncrementDepth());
            }
            return false;
        }

        // e.g. try{...}catch(E e){...}finally{...}
        public override bool Visit(UnifiedTry element, VisitorArgument arg) {
            // try block
            Writer.Write("try");
            element.Body.TryAccept(this, arg);

            // catch blocks
            element.Catches.TryAccept(this, arg);

            // finally block
            var finallyBlock = element.FinallyBody;
            // how judge whether finalluBlock exists or not???
            if (finallyBlock != null) {
                Writer.Write("finally");
                finallyBlock.TryAccept(this, arg);
            }
            return false;
        }

        public override bool Visit(
                UnifiedGenericParameter element, VisitorArgument arg) {
            element.Type.TryAccept(this, arg);
            element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
            return false;
        }

        public override bool Visit(UnifiedLabel element, VisitorArgument arg) {
            element.Name.TryAccept(this, arg);
            Writer.Write(":");
            return false;
        }

        public override bool Visit(
                UnifiedBooleanLiteral element, VisitorArgument arg) {
            if (element.Value) {
                Writer.Write("true");
            } else {
                Writer.Write("false");
            }
            return false;
        }

        public override bool Visit(
                UnifiedFractionLiteral element, VisitorArgument arg) {
            Writer.Write(element.Value);
            switch (element.Kind) {
            case UnifiedFractionLiteralKind.Single:
                Writer.Write("f");
                break;
            case UnifiedFractionLiteralKind.Double:
                Writer.Write("d");
                break;
            default:
                throw new ArgumentOutOfRangeException();
            }
            return false;
        }

        public override bool Visit(
                UnifiedStringLiteral element, VisitorArgument arg) {
            Writer.Write(element.Value);
            return false;
        }

        public override bool Visit(
                UnifiedCharLiteral element, VisitorArgument arg) {
            Writer.Write(element.Value);
            return false;
        }

        public override bool Visit(
                UnifiedNullLiteral element, VisitorArgument arg) {
            Writer.Write("null");
            return false;
        }

        #endregion

        #region expression

        public override bool Visit(
                UnifiedBinaryOperator element, VisitorArgument arg) {
            Writer.Write(element.Sign);
            return false;
        }

        public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
            Writer.Write("/*");
            element.Modifiers.TryAccept(this, arg);
            Writer.Write("*/");
            element.Value.TryAccept(this, arg);
            return false;
        }

        #endregion

        #region value

        public override bool Visit(
                UnifiedVariableIdentifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        public override bool Visit(
                UnifiedLabelIdentifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        public override bool Visit(
                UnifiedSuperIdentifier element, VisitorArgument arg) {
            Writer.Write("");
            return false;
        }

        public override bool Visit(
                UnifiedThisIdentifier element, VisitorArgument arg) {
            Writer.Write("");
            return false;
        }

        #endregion

        public override bool Visit(
                UnifiedUnaryOperator element, VisitorArgument arg) {
            var kind = element.Kind;
            switch (kind) {
            case (UnifiedUnaryOperatorKind.Negate):
                Writer.Write("-");
                break;
            case (UnifiedUnaryOperatorKind.Not):
                Writer.Write("!");
                break;
            case (UnifiedUnaryOperatorKind.PostDecrementAssign):
            case (UnifiedUnaryOperatorKind.PreDecrementAssign):
                Writer.Write("--");
                break;
            case (UnifiedUnaryOperatorKind.PostIncrementAssign):
            case (UnifiedUnaryOperatorKind.PreIncrementAssign):
                Writer.Write("++");
                break;
            case (UnifiedUnaryOperatorKind.UnaryPlus):
                Writer.Write("+");
                break;
            case (UnifiedUnaryOperatorKind.OnesComplement):
                Writer.Write("~");
                break;
            case (UnifiedUnaryOperatorKind.Unknown):
                Writer.Write(element.Sign);
                break;
            default:
                throw new InvalidOperationException();
            }
            return false;
        }

        public override bool Visit(UnifiedFor element, VisitorArgument arg) {
            element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
            Writer.Write("while ");
            element.Condition.TryAccept(this, arg);
            Writer.WriteLine(":");
            arg = arg.IncrementDepth();
            element.Body.TryAccept(this, arg);
            WriteIndent(arg.IndentDepth);
            element.Step.TryAccept(this, arg.Set(SemiColonDelimiter));
            return false;
        }

        public override bool Visit(UnifiedForeach element, VisitorArgument arg) {
            Writer.Write("for ");
            element.Element.TryAccept(this, arg);
            Writer.Write(" in ");
            element.Set.TryAccept(this, arg);
            Writer.WriteLine(":");

            element.Body.TryAccept(this, arg.IncrementDepth());
            if (!element.ElseBody.IsEmptyOrNull()) {
                Writer.WriteLine("else:");
                element.ElseBody.TryAccept(this, arg.IncrementDepth());
            }
            return false;
        }

        public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
            Writer.Write("while ");
            element.Condition.TryAccept(this, arg);
            Writer.WriteLine(":");

            element.Body.TryAccept(this, arg.IncrementDepth());
            if (!element.ElseBody.IsEmptyOrNull()) {
                Writer.WriteLine("else:");
                element.ElseBody.TryAccept(this, arg.IncrementDepth());
            }
            return false;
        }

        public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
            element.Body.TryAccept(this, arg);
            Writer.Write("while ");
            element.Condition.TryAccept(this, arg);
            Writer.WriteLine(":");

            element.Body.TryAccept(this, arg.IncrementDepth());
            return false;
        }

        public override bool Visit(UnifiedIndexer element, VisitorArgument arg) {
            element.Target.TryAccept(this, arg);
            element.Arguments.TryAccept(this, arg.Set(Bracket));
            return false;
        }

        public override bool Visit(
                UnifiedGenericArgument element, VisitorArgument arg) {
            element.Modifiers.TryAccept(this, arg);
            element.Value.TryAccept(this, arg);
            element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
            return false;
        }

        public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
            if (!element.Cases.IsEmptyOrNull()) {
                foreach (var c in element.Cases) {
                    Writer.Write("if ");
                    element.Value.TryAccept(this, arg);
                    Writer.Write(" == ");
                    c.Condition.TryAccept(this, arg);
                    Writer.WriteLine(":");
                    c.Body.TryAccept(this, arg.IncrementDepth());
                }
            }
            return false;
        }

        public override bool Visit(UnifiedCase element, VisitorArgument arg) {
            throw new InvalidOperationException("このメソッドは呼び出せません。");
            return false;
        }

        public override bool Visit(UnifiedUsing element, VisitorArgument arg) {
            Writer.Write("/* using ");
            element.Expressions.TryAccept(this, arg);
            Writer.WriteLine(" { */");
            element.Expressions.TryAccept(this, arg);
            Writer.WriteLine("//extracted from above");
            Writer.WriteLine("/* } */");
            return false;
        }

        public override bool Visit(UnifiedKeyValue element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(
                UnifiedMapComprehension element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(
                UnifiedMapLiteral element, VisitorArgument arg) {
            return false;
            //TODO Mseコンバーターのために一時的に例外を吐かないようにします
            throw new NotImplementedException();
        }

        public override bool Visit(
                UnifiedListComprehension element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(UnifiedSlice element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(UnifiedComment element, VisitorArgument arg) {
            throw new NotImplementedException();
        }

        public override bool Visit(
                UnifiedVariableDefinition element, VisitorArgument arg) {
            element.Annotations.TryAccept(this, arg);
            element.Modifiers.TryAccept(this, arg);
            Writer.Write(" ");
            element.Type.TryAccept(this, arg);
            Writer.Write(" ");
            element.Name.TryAccept(this, arg);
            if (element.InitialValue != null) {
                Writer.Write(" = ");
                element.InitialValue.TryAccept(this, arg.Set(Brace));
            }
            element.Arguments.TryAccept(this, arg.Set(Paren));
            element.Body.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedGenericType element, VisitorArgument arg) {
            element.Type.TryAccept(this, arg);
            element.Arguments.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedArrayType element, VisitorArgument arg) {
            element.Type.TryAccept(this, arg);
            Writer.Write("[");
            element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
            Writer.Write("]");
            return false;
        }

        public override bool Visit(UnifiedPass element, VisitorArgument arg) {
            Writer.Write("pass");
            return false;
        }

        public override bool Visit(UnifiedPrint element, VisitorArgument arg) {
            Writer.Write("print ");
            element.Value.TryAccept(this, arg);
            return false;
        }

        public override bool Visit(
                UnifiedPrintChevron element, VisitorArgument arg) {
            Writer.Write("print >> ");
            element.Value.TryAccept(this, arg);
            return false;
        }
    }
}