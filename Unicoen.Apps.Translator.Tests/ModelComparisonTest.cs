using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Languages.C;
using Unicoen.Languages.Java;
using Paraiba.Text;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator.Tests
{
	public class ModelComparisonTest
	{
		[Test]
		public void ComparisonTest()
		{
			const string javaFilePath =
				@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\Java\input\default\Fibonacci.java";
			const string cFilePath =
				@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\C\input\fibonacci.c";
			const string jsFilePath =
				@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\JavaScript\input\fibonacci.js";
			var javaCode = File.ReadAllText(javaFilePath, XEncoding.SJIS);
			var cCode = File.ReadAllText(cFilePath, XEncoding.SJIS);
			var jsCode = File.ReadAllText(jsFilePath, XEncoding.SJIS);

			var javaModel = JavaFactory.GenerateModel(javaCode);
			// var cModel = CFactory.GenerateModel(cCode);
			var jsModel = JavaScriptFactory.GenerateModel(jsCode);

			//			Console.WriteLine(javaModel.ToString());
			//			Console.WriteLine("");

			//			Console.Write("*/***");

			Console.WriteLine(jsModel.ToString());

		}
	}
}