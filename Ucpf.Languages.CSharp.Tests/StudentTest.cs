﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class StudentTest {
		private string _source;

		public StudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.rb");
			_source = File.ReadAllText(path);
		}

		[Ignore, Test]
		public void CreateClassDefinition() {
			
		}
	}
}
