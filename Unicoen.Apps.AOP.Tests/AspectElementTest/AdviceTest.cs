using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.Aop.Visitor;

namespace Aries.Tests
{
	public class AdviceTest
	{
		private AstVisitor _visitor;

		[SetUp]
		public void SetUp()
		{
			var input = new Antlr.Runtime.ANTLRFileStream("../../fixture/AspectCompiler/input/simple_advice_sample.txt");

			var lex = new AriesLexer(input);
			var tokens = new Antlr.Runtime.CommonTokenStream(lex);
			var parser = new AriesParser(tokens);

			var result = parser.aspect();
			var ast = (CommonTree) result.Tree;

			_visitor = new AstVisitor();
			_visitor.Visit(ast, 0, null);
		}

		[Test]
		public void アドバイスの種類を取得できる()
		{
			var adviceType = _visitor.Advices.ElementAt(0).GetAdviceType();
			Assert.That(adviceType, Is.EqualTo("before"));
		}

		[Test]
		public void アドバイスの対象ポイントカット名を取得できる()
		{
			var target = _visitor.Advices.ElementAt(0).GetTarget();
			Assert.That(target, Is.EqualTo("move"));
		}

		[Test, Ignore]
		public void アドバイスのパラメータを取得できる()
		{
			//TODO implement
		}

		[Test]
		public void アドバイスのコード断片を取得できる()
		{
			var advice = _visitor.Advices.ElementAt(1);
			var javaBlock = advice.GetFragments().ElementAt(0).GetLanguageType();
			Assert.That(javaBlock, Is.EqualTo("Java"));
			var jsBlock = advice.GetFragments().ElementAt(1).GetLanguageType();
			Assert.That(jsBlock, Is.EqualTo("JavaScript"));
		}
	}
}
