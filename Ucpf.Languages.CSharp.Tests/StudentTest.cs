using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class StudentTest {
		private string _source;

		public StudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path);
		}

		[Ignore, Test]
		public void CreateClassDefinition() {
			var actual = CSharpModelFactory.CreateModel(_source);
			var expected = new UnifiedClassDefinition {
				Name = "Student",
				Body = new UnifiedBlock {
				}
			};
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}
