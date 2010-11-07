using System.Linq;
using NUnit.Framework;
using Ucpf.Languages.Python3;

namespace Ucpf.Languages.Tests.Python3
{
	[TestFixture]
	public class AstGeneratorTest
	{
		[Test]
		public void GenerateFromText()
		{
			var code = "CoverageWriter.WriteStatement(" + 1 + "," + 1 + "," + 1 + ")";
			var node = Python3AstGenerator.Instance.GenerateFromText(code)
				.Descendants("small_stmt")
				.FirstOrDefault();
			Assert.That(node, Is.Not.Null);
		}
	}
}
