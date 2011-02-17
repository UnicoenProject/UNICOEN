using System.IO;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.Java.AstGenerators;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaAstGeneratorTest {
		private static readonly string InputPath =
			Path.Combine(Fixture.GetFailedInputPath("Java"), "fibonacci.java");

		[Test, Ignore]
		public void ユニコード文字の入ったコードをパースできる() {
			JavaAstGenerator.Instance.GenerateFromFile(InputPath);
		}
	}
}