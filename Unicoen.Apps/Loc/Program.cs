using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.Loc {
	class Program {
		static void Main(string[] args) {
			var inputPath = FixtureUtil.GetInputPath("Java", "Fibonacci.java");
			var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
			var blocks = codeObj.Descendants<UnifiedBlock>();
			var sum = 0;
			foreach (var block in blocks) {
				sum += block.Elements().Count();
			}
			Console.WriteLine(sum);
		}
	}
}
