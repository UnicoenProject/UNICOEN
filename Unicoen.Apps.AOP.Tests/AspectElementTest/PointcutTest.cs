using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.Aop.Visitor;

namespace Aries.Tests
{
	class PointcutTest
	{
		private AstVisitor _visitor;

		[SetUp]
		public void SetUp()
		{
			var input = new Antlr.Runtime.ANTLRFileStream("../../fixture/AspectCompiler/input/simple_pointcut_sample.txt");

			var lex = new AriesLexer(input);
			var tokens = new Antlr.Runtime.CommonTokenStream(lex);
			var parser = new AriesParser(tokens);
			parser.TraceDestination = Console.Error;

			var result = parser.aspect();
			var ast = (CommonTree) result.Tree;

			_visitor = new AstVisitor();
			_visitor.Visit(ast, 0, null);
		}

		[Test]
		public void ポイントカットの種類を取得できる()
		{
			var pointcutType = 
				_visitor.Pointcuts.ElementAt(0).GetPointcutType();
			Assert.That(pointcutType, Is.EqualTo("execution"));
		}

		[Test]
		public void ポイントカット名を取得できる()
		{
			var name =
				_visitor.Pointcuts.ElementAt(0).GetName();
			Assert.That(name, Is.EqualTo("move"));
		}
		
		[Test, Ignore]
		public void ポイントカットのパラメータを取得できる()
		{
			//TODO implement
		}

		[Test]
		public void ポイントカット条件の型を取得できる()
		{
			var targetType =
				_visitor.Pointcuts.ElementAt(0).GetTargetType();
			Assert.That(targetType, Is.EqualTo("double"));
		}

		[Test]
		public void ポイントカット条件の識別子を取得できる()
		{
			var targetName =
				_visitor.Pointcuts.ElementAt(0).GetTargetName();
			var className = targetName.ElementAt(0);
			var methodName = targetName.ElementAt(1);
			
			Assert.That(className, Is.EqualTo("Rectangle"));
			Assert.That(methodName, Is.EqualTo("shift"));
		}
	}
}
