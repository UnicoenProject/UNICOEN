using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Ucpf.Languages.Java.Tests
{
	public class JavaAstGeneratorTest
	{
		[Test]
		public void ユニコード文字の入ったコードをパースできる() {
			JavaAstGenerator.Instance.GenerateFromFile("../fixture/Unicode.java");
		}
	}
}
