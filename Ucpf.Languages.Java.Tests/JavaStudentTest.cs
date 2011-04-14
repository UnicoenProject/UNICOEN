using System.IO;
using NUnit.Framework;
using Ucpf.Core.Tests;
using Ucpf.Languages.CSharp.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests
{
	[Ignore, TestFixture]
	public class JavaStudentTest
	{
		private readonly string _source;

		public JavaStudentTest()
		{
			var path = Fixture.GetInputPath("Java", "Student.java");
			_source = File.ReadAllText(path);
		}

		[Test]
		public void CreateClassDefinition()
		{
			var expected = CSharpStudentTest.CreateModel();

			var actual = JavaModelFactory.CreateModel(_source);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}