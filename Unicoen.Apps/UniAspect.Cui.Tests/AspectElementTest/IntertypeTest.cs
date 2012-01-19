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

using System.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Visitor;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui.AspectElementTest {
    [TestFixture]
    internal class IntertypeTest {
        #region Setup/Teardown

        [SetUp]
        public void SetUp() {
            //アスペクトファイルのパスを取得
            var input =
                    new ANTLRFileStream(
                            FixtureUtil.GetAspectPath(
                                    "simple_intertype_sample.apt"));

            //アスペクトファイルをパースして抽象構文木を生成する
            var lex = new AriesLexer(input);
            var tokens = new CommonTokenStream(lex);
            var parser = new AriesParser(tokens);

            var result = parser.aspect();
            var ast = (CommonTree)result.Tree;

            //抽象構文木を走査して、ポイントカット・アドバイス情報を格納する
            _visitor = new AstVisitor();
            _visitor.Visit(ast, 0, null);
        }

        #endregion

        private AstVisitor _visitor;

        [Test]
        public void インタータイプ宣言のブロック内のコードを取得する() {
            var contents = _visitor.Intertypes.ElementAt(0).GetContents();
            var code = "";
            foreach (var e in contents) {
                code += e;
            }
            const string actual =
                    "private int x = 10 ; public int getX ( ) { return x ; } ";

            //文字列による比較
            Assert.That(code, Is.EqualTo(actual));

            //文字列をモデル変換した結果を比較
            Assert.That(
                    UcoGenerator.CreateIntertype("Java", code),
                    Is.EqualTo(UcoGenerator.CreateIntertype("Java", actual)).
                            Using(StructuralEqualityComparer.Instance));
        }

        [Test]
        public void インタータイプ宣言の対象クラス名を取得する() {
            Assert.That(
                    _visitor.Intertypes.ElementAt(0).GetTarget(),
                    Is.EqualTo("Foo"));
        }

        [Test]
        public void インタータイプ宣言の対象言語を取得する() {
            Assert.That(
                    _visitor.Intertypes.ElementAt(0).GetLanguageType(),
                    Is.EqualTo("Java"));
        }
    }
}