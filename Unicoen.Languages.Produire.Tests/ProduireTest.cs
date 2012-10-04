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
		public void TestIf() {
			new ProduireProgramGenerator().Generate(@"
得点は、70
合格点は、60
もし得点が合格点以上なら
　　「合格」を表示
もし終わり");
		}

		[Test]
		public void TestArray() {
			new ProduireProgramGenerator().Generate(@"
Aを10とする
A=120
果物（A）は、「りんご」
果物（１）は、「りんご」
果物（４）を表示する");
		}
	}
}
