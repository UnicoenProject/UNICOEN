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

namespace Unicoen.Languages.C.CodeGenerators {
    // CCodeFactoryVisitorのうち、ステートメントに関する処理を行います
    public partial class CCodeFactoryVisitor {
        #region Utility Functions for Expression

        // 指定された演算子が左結合かどうかを判定します
        protected virtual bool IsLeftAssociative(UnifiedBinaryOperator op) {
            return !IsRightAssociative(op);
        }

        // 指定された演算子が右結合かどうかを判定します
        // どの演算子が右結合であるかについてはUnifiedBinaryOperator.IsAssignOperatorを参照してください
        protected virtual bool IsRightAssociative(UnifiedBinaryOperator op) {
            return op.IsAssignOperator();
        }

        // 指定された2項式を括弧でくくる必要があるかどうかを判定します
        protected bool GetRequiredParen(UnifiedBinaryExpression exp) {
            var parent = exp.Parent;
            var parentExp = parent as UnifiedBinaryExpression;

            // 2項式がネストしている場合
            if (parentExp != null) {
                if (exp.Operator.Kind == parentExp.Operator.Kind) {
                    // 左結合の演算子である場合、自分が親の左オペランドである場合には括弧は必要でない
                    // e.g. exp -> 1+2, parent -> (1+2)+3, parent.LeftHandSide -> 1+2
                    if (IsLeftAssociative(exp.Operator)) {
                        var left =
                                parentExp.LeftHandSide as
                                UnifiedBinaryExpression;
                        if (exp == left) {
                            return false;
                        }
                    } else if (IsRightAssociative(exp.Operator)) {
                        // 右結合の演算子である場合、自分が親の右オペランドである場合には括弧は必要でない
                        // e.g. exp -> b=c, parent -> a=(b=c), parent.RightHandSide -> b=c
                        var right =
                                parentExp.RightHandSide as
                                UnifiedBinaryExpression;
                        if (exp == right) {
                            return false;
                        }
                    }
                }
                return true;
            }

            // 2項式以外とネストしている場合は親が以下の要素であれば括弧が必要となる
            return parent is UnifiedFunctionDefinition ||
                   parent is UnifiedIndexer ||
                   parent is UnifiedProperty ||
                   parent is UnifiedCast ||
                   parent is UnifiedUnaryExpression ||
                   parent is UnifiedTernaryExpression;
        }

        // 指定された単項式を括弧でくくる必要があるかどうかを判定します
        protected static bool GetRequiredParen(IUnifiedElement element) {
            var parent = element.Parent;
            return parent is UnifiedFunctionDefinition ||
                   parent is UnifiedIndexer ||
                   parent is UnifiedProperty ||
                   parent is UnifiedCast ||
                   parent is UnifiedUnaryExpression ||
                   parent is UnifiedBinaryExpression ||
                   parent is UnifiedTernaryExpression;
        }

        # endregion

        # region Statement(Block, Call, ...)

        // ブロック(UnifiedBlock)
        public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
            // 要素の左端に記述すべきものがある場合はそれを出力する
            // プログラム全体の場合は何も出力しないが、関数の場合には中括弧が必要になるなど
            if (!string.IsNullOrEmpty(arg.Decoration.MostLeft)) {
                Writer.WriteLine(arg.Decoration.MostLeft);
                arg = arg.IncrementDepth();
            }

            // ブロック内の要素を列挙する
            // セミコロンが必要な要素の場合にはセミコロンを出力する
            foreach (var stmt in element) {
                WriteIndent(arg);
                if (stmt.TryAccept(this, arg)) {
                    Writer.Write(";");
                }
                Writer.Write(arg.Decoration.EachRight);
            }

            // 要素の右端に記述すべきものがある場合はインデントを元に戻しそれを出力する
            if (!string.IsNullOrEmpty(arg.Decoration.MostRight)) {
                arg = arg.DecrementDepth();
                WriteIndent(arg);
                Writer.Write(arg.Decoration.MostRight);
            }
            return false;
        }

        // 関数呼び出し(UnifiedCall)
        public override bool Visit(UnifiedCall element, VisitorArgument arg) {
            var prop = element.Function as UnifiedProperty;

            // TODO これに該当するケースがあるか調べる
            if (prop != null) {
                prop.Owner.TryAccept(this, arg);
                Writer.Write(prop.Delimiter);
                prop.Name.TryAccept(this, arg);
            } else {
                element.Function.TryAccept(this, arg);
            }
            element.Arguments.TryAccept(this, arg.Set(Paren));
            return true;
        }

        # endregion

        # region Control Structure (If, For, While, ...)

        // If文(UnifiedIf)
        public override bool Visit(UnifiedIf element, VisitorArgument arg) {
            Writer.Write("if (");
            element.Condition.TryAccept(this, arg);
            Writer.Write(")");
            element.Body.TryAccept(this, arg.Set(ForBlock));
            if (element.ElseBody != null) {
                Writer.WriteLine(); //if(cond){ }の後の改行
                WriteIndent(arg);
                Writer.Write("else");
                element.ElseBody.TryAccept(this, arg.Set(ForBlock));
            }
            return false;
        }

        // For文(UnifiedFor)
        public override bool Visit(UnifiedFor element, VisitorArgument arg) {
            Writer.Write("for(");
            element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
            Writer.Write("; ");
            element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
            Writer.Write("; ");
            element.Step.TryAccept(this, arg.Set(CommaDelimiter));
            Writer.Write(")");

            element.Body.TryAccept(this, arg.Set(ForBlock));
            return false;
        }

        // While文(UnifiedWhile)
        public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
            Writer.Write("while(");
            element.Condition.TryAccept(this, arg);
            Writer.Write(")");

            element.Body.TryAccept(this, arg.Set(ForBlock));
            return false;
        }

        // Do-While文(UnifiedDoWhile)
        public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
            Writer.Write("do");
            element.Body.TryAccept(this, arg.Set(ForBlock));
            Writer.Write("\n");
            WriteIndent(arg);
            Writer.Write("while(");
            element.Condition.TryAccept(this, arg);
            Writer.Write(");");
            return false;
        }

        // Switch文(UnifiedSwitch)
        // TODO インデントについてUNICOENチームの総意を出す
        public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
            Writer.Write("switch(");
            element.Value.TryAccept(this, arg);
            Writer.Write(") {\n");

            element.Cases.TryAccept(this, arg);
            WriteIndent(arg);
            Writer.Write("}");
            return false;
        }

        // Case文(UnifiedCase)
        public override bool Visit(UnifiedCase element, VisitorArgument arg) {
            // default文の条件式はnullとしてオブジェクト化される
            if (element.Condition == null) {
                Writer.Write("default:\n");
            } else {
                Writer.Write("case ");
                element.Condition.TryAccept(this, arg);
                Writer.Write(":\n");
            }
            WriteIndent(arg);
            element.Body.TryAccept(this, arg.Set(ForBlock));
                    // 各Case文のブロックには中括弧を付ける
            return false;
        }

        # endregion

        # region Control Statement (Return, Continue, ...)

        // Rerurn文(UnifiedReturn)
        public override bool Visit(UnifiedReturn element, VisitorArgument arg) {
            Writer.Write("return ");
            element.Value.TryAccept(this, arg);
            return true;
        }

        public override bool Visit(UnifiedBreak element, VisitorArgument arg) {
            Writer.Write("break ");
            element.Value.TryAccept(this, arg);
            return true;
        }

        # endregion

        # region expression

        // ラベル
        public override bool Visit(UnifiedLabel element, VisitorArgument arg) {
            element.Name.TryAccept(this, arg);
            Writer.Write(": ");
            return false;
        }

        // 2項式(UnifiedBinaryExpression)
        public override bool Visit(
                UnifiedBinaryExpression element, VisitorArgument arg) {
            var paren = GetRequiredParen(element)
                                ? Tuple.Create("(", ")") : Tuple.Create("", "");
            Writer.Write(paren.Item1);
            element.LeftHandSide.TryAccept(this, arg.Set(Paren));
            Writer.Write(" ");
            element.Operator.TryAccept(this, arg);
            Writer.Write(" ");
            element.RightHandSide.TryAccept(this, arg.Set(Paren));
            Writer.Write(paren.Item2);
            return true;
        }

        // 単項式(UnifiedUnaryExpression)
        public override bool Visit(
                UnifiedUnaryExpression element, VisitorArgument arg) {
            var paren = GetRequiredParen(element)
                                ? Tuple.Create("(", ")") : Tuple.Create("", "");
            Writer.Write(paren.Item1);

            // TODO 後置演算子が++と--以外にないか確認
            // 前置演算子か後置演算子かで、演算子を先に出力するか決定します
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
            Writer.Write(paren.Item2);
            return true;
        }

        # endregion
    }
}