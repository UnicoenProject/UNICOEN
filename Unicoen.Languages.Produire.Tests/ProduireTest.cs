using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Produire.ProgramGenerators;

namespace Unicoen.Languages.Produire.Tests
{
	[TestFixture]
	public class ProduireTest
	{
		[Test]
		public void Test() {
			new ProduireProgramGenerator().GenerateFromFile(
					@"C:\Users\exKAZUu\Projects\Produire\produire\サンプル\もし.rdr");
		}

		[Test]
		public void Test2() {
			new ProduireProgramGenerator().GenerateFromFile(
					@"C:\Users\exKAZUu\Projects\Produire\ProduireCodeModel\WindowsFormsApplication1\test.rdr");
		}
	}
}
