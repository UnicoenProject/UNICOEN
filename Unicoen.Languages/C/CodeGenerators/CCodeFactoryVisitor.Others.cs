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
    // CCodeFactoryVisitorのうち、分類されない要素に関する処理を行います
    public partial class CCodeFactoryVisitor {
        #region program, function, ...

        // プログラム全体(UnifiedProgram)
        /* UnifiedProgramはUnifiedBlockとしてプログラム内の全要素を保持しているが、
		 * その際中括弧を必要としないため、DecorationとしてForTopBlockを与える
		 */

        public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
            element.Body.TryAccept(this, arg.Set(ForTopBlock));
            return false;
        }

        // 関数定義(UnifiedFunctionDefinition)
        public override bool Visit(
                UnifiedFunctionDefinition element, VisitorArgument arg) {
            // int main(int param) { ... };
            element.Modifiers.TryAccept(this, arg);
            element.Type.TryAccept(this, arg);
            Writer.Write(" ");
            element.Name.TryAccept(this, arg);
            element.Parameters.TryAccept(this, arg);
            element.Body.TryAccept(this, arg.Set(ForBlock));
            return element.Body == null;
        }

        // enum定義(UnifiedEnumDefinition)
        public override bool Visit(
                UnifiedEnumDefinition element, VisitorArgument arg) {
            // enum COLOR {RED, BLUE, YELLOW};
            element.Modifiers.TryAccept(this, arg);
            Writer.Write("enum ");
            element.Name.TryAccept(this, arg);
            Writer.Write(" ");
            element.Body.TryAccept(this, arg.Set(ForBlock));
            return true;
        }

        # endregion

        # region variable, literal, ...

        // 変数名(UnifiedVariableIdentifier)
        public override bool Visit(
                UnifiedVariableIdentifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        // ラベル名(UnifiedVariableIdentifier)
        public override bool Visit(
                UnifiedLabelIdentifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        // intリテラル(UnifiedInt32Literal)
        public override bool Visit(
                UnifiedInt32Literal element, VisitorArgument arg) {
            Writer.Write(element.Value);
            return false;
        }

        // 文字列リテラル(UnifiedStringLiteral)
        public override bool Visit(
                UnifiedStringLiteral element, VisitorArgument arg) {
            Writer.Write("\"");
            Writer.Write(element.Value);
            Writer.Write("\"");
            return false;
        }

        # endregion

        # region suffix(parameter, argument)

        // 修飾子(UnifiedModifier)
        public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
            Writer.Write(element.Name);
            return false;
        }

        // パラメータ(UnifiedParameter)
        // TODO 可変長引数について調査する
        public override bool Visit(
                UnifiedParameter element, VisitorArgument arg) {
            element.Modifiers.TryAccept(this, arg);
            element.Type.TryAccept(this, arg);
            Writer.Write(" ");
            element.Names.TryAccept(this, arg.Set(CommaDelimiter));
            return false;
        }

        // 実引数(UnifiedArgument)
        public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
            // element.Target.TryAccept(this, arg, "", " = "); // TODO Targetが何か確認
            element.Value.TryAccept(this, arg);
            return false;
        }

        # endregion

        # region operator

        // 2項演算子(UnifiedBinaryOperator)
        public override bool Visit(
                UnifiedBinaryOperator element, VisitorArgument arg) {
            Writer.Write(element.Sign);
            return false;
        }

        // 単項演算子(UnifiedUnaryOperator)
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

        # endregion
    }
}