using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.Tests;
using Ucpf.Languages.C;
using Ucpf.Languages.C.AstGenerators;
using Ucpf.Languages.C.Model;
using Ucpf.Languages.JavaScript;
using Ucpf.Languages.JavaScript.AstGenerators;
using Ucpf.Languages.JavaScript.Model;
using Ucpf.Languages.Ruby18.Model;
using Ucpf.Languages.C.CodeTranslation;

namespace Ucpf.Languages.C.CodeTranslation.Test
{
	[TestFixture]
	public class CCodeModelToCodeTestForFibonacci
	{
		private CModelToCode _cm2c;
		private JSModelToCode _jsm2c;
		private RubyModelToCode _rm2c;

		private StringWriter _rwriter, _jswriter, _cwriter;
		private CFunction _cfunc;
		private JSFunction _jsfunc; 

		private static readonly string CInputPath =
			Fixture.GetInputPath("C", "fibonacci.c");

		private static readonly string JSInputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		[SetUp]
		public void SetUp()
		{
			_jswriter = new StringWriter();
			_rwriter = new StringWriter();
			_cwriter = new StringWriter();

			_jsm2c = new JSModelToCode(_jswriter, 0);
			_cm2c = new CModelToCode(_cwriter, 0);
			_rm2c = new RubyModelToCode(_rwriter, 0);
			

			_cfunc = new CFunction(
						CAstGenerator.Instance.GenerateFromFile(CInputPath)
						.Descendants("function_definition")
						.First());

			_jsfunc = new JSFunction(
				JavaScriptAstGenerator.Instance.GenerateFromFile(JSInputPath)
						.Descendants("functionDeclaration")
						.First());
		}

		// GOAL
		[Test]
		public void CからRubyにシンタクスレベルの変換ができる()
		{
			_rm2c.Generate(_cfunc);
			var actual = _rwriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		[Test]
		public void CからJSにシンタクスレベルの変換ができる() {
			_jsm2c.Generate(_cfunc);
			var actual = _jswriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		[Test]
		public void JSからCにシンタクスレベルの変換ができる() {
			_cm2c.Generate(_jsfunc);
			var actual = _cwriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		[Test]
		public void JSからCに型補完を伴ってセマンティクスレベルの変換できる() {
			var variable = new Dictionary<string, string>();
			var function = new Dictionary<string, string>();
			var type = new Dictionary<string, string>();

			// variable["n"] = "int";
			function["fibonacci"] = "int";

			var rules = new Dictionary<string, Dictionary<string, string>>();
			rules["variable"] = variable;
			rules["function"] = function;

			var typeTransRule = new CTypeTransRule(rules);

			
			var _cm2cwr = new CModelToCode(_cwriter, 0, typeTransRule);
			_cm2cwr.Generate(_jsfunc);
			
			var actual = _cwriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);
		}

		[Test]
		public void CからCにセマンティクスレベルを考慮した出力ができる() {
			
			var testMethodIntoC = new Dictionary<string, string>();

			testMethodIntoC["CU_ASSERT_NOT_EQUAL"] = "CU_ASSERT_NOT_EQUAL";
			testMethodIntoC["assertEquals"] = "CU_ASSERT_NOT_EQUAL";
			testMethodIntoC["assert_equal"] = "CU_ASSERT_NOT_EQUAL";
			testMethodIntoC["fibonacci"] = "CU_ASSERT_NOT_EQUAL";


			var rules = new List<Dictionary<string, string>>();
			rules.Add(testMethodIntoC);

			var methodTransRule = new CMethodTransRule(rules);

			// model to code with rules
			var _cm2cwr = new CModelToCode(_cwriter, 0, methodTransRule);
			_cm2cwr.Generate(_cfunc);

			var actual = _cwriter.ToString();

			// DebugPrint
			System.Diagnostics.Debug.WriteLine(actual);

		}
	}
}
