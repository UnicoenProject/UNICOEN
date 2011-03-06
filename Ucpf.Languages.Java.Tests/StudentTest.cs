using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class StudentTest {
		private readonly string _source;

		public StudentTest() {
			var path = Fixture.GetInputPath("Java", "student.java");
			_source = File.ReadAllText(path);
		}

		[Test]
		public void CreateClassDefinition() {
			var expected = CSharp.Tests.StudentTest.CreateModel();

			var actual = JavaModelFactory.CreateModel(_source);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparer.Instance));
		}
	}
}
