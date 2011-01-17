using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;

namespace Ucpf.Languages.C.Tests
{
	[TestFixture]
	public class CCodeModelTestForTest {
		private CFunction _function;
		private static readonly string InputPath =
			Fixture.GetInputPath("C", "test.c");

		[SetUp]
		public void SetUp() {
			_function = new CFunction(
				CAstGenerator.Instance.GenerateFromFile(InputPath)
				.Descendants("function_definition")
				.First());
		}
		
		[Test]
		public void メソッド返却値タイプが正しい()
		{
		}
		[Test]
		public void メソッド名が正しい()
		{
		}

		// test whether the first parameter equals to (int, "n")
		[Test]
		public void パラメータリストが正しい()
		{
		}

		[Test]
		public void IF文の条件式が正しい()
		{
		}

		[Test]
		public void TrueBlockが正しく生成できる()
		{
		}

		[Test]
		public void ElseBlockが正しく生成できる()
		{
		}

	}
}
