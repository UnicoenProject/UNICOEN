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

using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.JavaScript.CodeGenerators {
    public partial class JavaScriptCodeFactoryVisitor {
        //関数呼び出し
        public override bool Visit(UnifiedCall element, VisitorArgument arg) {
            //JavaScriptではTypeArgumentsが存在しない
            var prop = element.Function as UnifiedProperty;
            //呼び出し式がプロパティの場合
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

        //配列orオブジェクトのインスタンス化式
        public override bool Visit(UnifiedNew element, VisitorArgument arg) {
            //配列 : e.g. var a = [1, 2, 3] の [1, 2, 3];
            if (element.InitialValue != null) {
                element.InitialValue.TryAccept(this, arg.Set(Brace));
                return true;
            }
            //オブジェクト : e.g. var a = new X();
            Writer.Write("new ");
            element.Target.TryAccept(this, arg);
            element.Arguments.TryAccept(this, arg.Set(Paren));
            return true;
        }

        //キャスト式
        public override bool Visit(UnifiedCast element, VisitorArgument arg) {
            Writer.Write("(");
            element.Type.TryAccept(this, arg);
            Writer.Write(")");
            //TODO ここのarg.Set(Paren)が不要な気がするので、後ではずしてテストしてみる
            element.Expression.TryAccept(this, arg.Set(Paren));
            return true;
        }

        //return文
        public override bool Visit(UnifiedReturn element, VisitorArgument arg) {
            Writer.Write("return ");
            element.Value.TryAccept(this, arg.Set(CommaDelimiter));
            return true;
        }

        //goto文
        public override bool Visit(UnifiedGoto element, VisitorArgument arg) {
            //JavaScriptではgoto文はサポートされていない
            Writer.Write("/* goto ");
            element.Target.TryAccept(this, arg);
            Writer.Write("*/");
            return true;
        }

        //delete式
        public override bool Visit(UnifiedDelete element, VisitorArgument arg) {
            Writer.Write("delete (");
            element.Value.TryAccept(this, arg);
            Writer.Write(")");
            return true;
        }

        //typeof式
        public override bool Visit(UnifiedTypeof element, VisitorArgument arg) {
            Writer.Write("typeof (");
            element.Value.TryAccept(this, arg);
            Writer.Write(")");
            return true;
        }

        //void式
        public override bool Visit(UnifiedPass element, VisitorArgument arg) {
            Writer.Write("void (");
            element.Value.TryAccept(this, arg);
            Writer.Write(")");
            return true;
        }

        //例外スロー文
        public override bool Visit(UnifiedThrow element, VisitorArgument arg) {
            Writer.Write("throw ");
            element.Value.TryAccept(this, arg.Set(CommaDelimiter));
            return true;
        }

        //assert文
        public override bool Visit(UnifiedAssert element, VisitorArgument arg) {
            //TODO JavaScriptではassert文はサポートされていない？
            Writer.Write("/* assert(");
            element.Value.TryAccept(this, arg);
            Writer.Write(") */");
            return true;
        }
    }
}