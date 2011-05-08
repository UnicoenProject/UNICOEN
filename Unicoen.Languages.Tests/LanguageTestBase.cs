using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Unicoen.Languages.Tests
{
	public abstract class LanguageTestBase
	{
		protected abstract Fixture Fixture { get; }

		public IEnumerable<TestCaseData> TestCodes {
			get { return Fixture.TestCodes; }
		}

		public IEnumerable<TestCaseData> TestFilePathes {
			get { return Fixture.TestFilePathes; }
		}

		public IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return Fixture.TestDirectoryPathes; }
		}
	}
}
