using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CModelToTest
	{
		[Test]
		public void 型を正しくコードに変換できる(){
			var type = new CType("int");
			var actual = CModelToCode.Generate(type, g => g.Generate);
			Assert.That(actual, Is.EqualTo("int"));
		}
	}
}
