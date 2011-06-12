using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.Aop.Visitor;

namespace Aries.Tests
{
	[TestFixture]
	class IntertypeTest
	{
		private AstVisitor _visitor;

		[SetUp]
		public void SetUp()
		{
			var input = new Antlr.Runtime.ANTLRFileStream("../../fixture/AspectCompiler/input/simple_intertype_sample.txt");

			var lex = new AriesLexer(input);
			var tokens = new Antlr.Runtime.CommonTokenStream(lex);
			var parser = new AriesParser(tokens);

			var result = parser.aspect();
			var ast = (CommonTree) result.Tree;

			_visitor = new AstVisitor();
			_visitor.Visit(ast, 0, null);
		}

		[Test]
		public void インタータイプ宣言の対象言語を取得する()
		{
			Assert.That(
				_visitor.Intertypes.ElementAt(0).GetLanguageType(), 
				Is.EqualTo("Java"));
		}

		[Test]
		public void インタータイプ宣言の対象クラス名を取得する()
		{
			Assert.That(
				_visitor.Intertypes.ElementAt(0).GetTarget(), 
				Is.EqualTo("Foo"));
		}

		[Test]
		public void インタータイプ宣言のブロック内のコードを取得する()
		{
			var contents = _visitor.Intertypes.ElementAt(0).GetContents();
			var code = "";
			foreach (var e in contents)
			{
				code += e;
			}
			var actual = 
				"private int x = 10 ; public int getX ( ) { return x ; } ";

			//TODO 最終的にはコード同士をモデル変換した結果を比較したい
			Assert.That(code, Is.EqualTo(actual));
		}
	}
}
