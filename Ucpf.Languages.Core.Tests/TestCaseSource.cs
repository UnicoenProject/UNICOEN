using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.Core.Tests {
	public static class TestCaseSource {
		public static IEnumerable<TestCaseData> CSharpTestCases {
			get {
				return Directory.EnumerateFiles(Fixture.GetInputPath("CSharp"))
					.Select(path => new TestCaseData(path));
			}
		}

		public static IEnumerable<TestCaseData> JavaTestCases {
			get {
				return Directory.EnumerateFiles(Fixture.GetInputPath("Java"))
					.Select(path => new TestCaseData(path));
			}
		}
	}
}
