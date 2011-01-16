using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.JavaScript.Model;
using Ucpf.Languages.Ruby18.Model;
using Ucpf.Languages.C.CodeTranslation;

namespace Ucpf.Languages.C.CodeTranslation.Test
{
	[TestFixture]
	public class CCodeModelToCodeTestForFibonacci
	{
		private CModelToCode _cmtc;
		private JSModelToCode _rmtc;
		private StringWriter _rwriter;
		private CFunction _func;

		private static readonly string InputPath =
			Path.Combine(Settings.GetInputDirPath("C"), "fibonacci.c");

		[SetUp]
		public void SetUp()
		{
			_rwriter = new StringWriter();
			_rmtc = new	JSModelToCode(_rwriter, 0);
			_func = new CFunction(
						CAstGenerator.Instance.GenerateFromFile(InputPath)
						.Descendants("function_definition")
						.First());
		}

		// GOAL
		[Test]
		public void CからRubyにシンタクスレベルの変換ができる()
		{
			_rmtc.Generate(_func);
			var actual = _rwriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		[Test]
		public void CからRubyにセマンティクスレベルの変換ができる() {
		}

	}
}
