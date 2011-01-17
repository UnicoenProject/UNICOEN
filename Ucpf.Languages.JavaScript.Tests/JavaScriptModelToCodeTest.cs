using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.JavaScript.Model;

namespace Ucpf.Languages.JavaScript.Tests
{
	[TestFixture]
	public class JavaScriptModelToCodeTest
	{
		private JSModelToCode _generator;
		private StringWriter _writer;
		private JSFunction _func;
		private static readonly string InputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		//for C
		private static readonly string CInputPath =
			Fixture.GetInputPath("C", "fibonacci.c");
		private CFunction _function;

		[SetUp]
		public void SetUp() 
		{
			_writer = new StringWriter();
			_generator = new JSModelToCode(_writer, 0);

			var ast = JavaScriptAstGenerator.Instance.GenerateFromFile(InputPath);
            var root = ast.Descendants("functionDeclaration").First();
            _func = new JSFunction(root);
		}

		[Test,Ignore]
		public void 関数が正しくコードに変換できる() 
		{
			_generator.Generate(_func);
			Console.Write(_writer.ToString());
			//Assert.That(_writer.ToString(), Is.EqualTo("hoge"));
		}
		
		[Test]
		public void CコードをJSコードに変換できる()
		{
			_function = new CFunction(
						CAstGenerator.Instance.GenerateFromFile(CInputPath)
						.Descendants("function_definition")
						.First());
			_generator.Generate(_function);
			Console.Write(_writer.ToString());
		}
	}
}
