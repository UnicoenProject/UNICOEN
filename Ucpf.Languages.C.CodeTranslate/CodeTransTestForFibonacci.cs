using System.IO;
using System.Linq;
using NUnit.Framework;
using Ucpf.Common.Tests;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.Ruby18.Model;

namespace Ucpf.Languages.C.CodeTranslation
{
	[TestFixture]
	public class CCodeModelToCodeTestForFibonacci
	{
		private CModelToCode _cmtc;
		private RubyModelToCode _rmtc;
		private StringWriter _rwriter;
		private CFunction _func;

		private static readonly string InputPath =
			Fixture.GetInputPath("C", "fibonacci.c");

		[SetUp]
		public void SetUp()
		{
			_rwriter = new StringWriter();
			_rmtc = new RubyModelToCode(_rwriter, 0);
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
		public void CからRubyにセマンティクスレベルの変換ができる() {}

	}
}
