using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	/// <summary>
	/// Java向けに再生成したソースコードが変化していないかテストします。
	/// 元コード1→モデル1→コード2→... のように再生成します。
	/// コードは、コンパイルしたclassファイル同士、
	/// もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[TestFixture]
	public class JavaRegenerateTest {
		private const string JavacPath = "javac";

		private static IEnumerable<byte[]> GetByteCode(string workPath,
		                                               string fileName) {
			var args = new[] {
				"\"" + Path.Combine(workPath, fileName) + "\""
			};
			var info = new ProcessStartInfo {
				FileName = JavacPath,
				Arguments = args.JoinString(" "),
				CreateNoWindow = true,
				UseShellExecute = false,
				WorkingDirectory = workPath,
			};
			try {
				using (var p = Process.Start(info)) {
					p.WaitForExit();
				}
			} catch(Win32Exception e) {
				throw new InvalidOperationException("Failed to launch 'javac'.", e);
			}

			return Directory.EnumerateFiles(workPath, "*.class",
				SearchOption.AllDirectories)
				.Select(File.ReadAllBytes);
		}

		private static IEnumerable<TestCaseData> TestCases {
			get {
				return Directory.EnumerateFiles(Fixture.GetInputPath("Java"))
					.Select(path => new TestCaseData(path));
			}
		}

		/// <summary>
		/// 再生成を行わずCompareThroughByteCodeが正常に動作するかテストします。
		/// 全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void TestCompareThroughByteCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetByteCode(workPath, fileName);
			var actual = GetByteCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		/// 再生成を行わずCompareThroughModelが正常に動作するかテストします。
		/// 全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void TestCompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = JavaModelFactory.CreateModel(orgCode);
			var actual = JavaModelFactory.CreateModel(orgCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparer.Instance));
		}

		/// <summary>
		/// コンパイル結果を通して再生成したコードが変化しないかテストします。
		/// 元コード1→モデル1→コード2と再生成します。
		/// コンパイルしたclassファイルを通して、
		/// 元コード1とコード2を比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		//[Ignore, Test, TestCaseSource("TestCases")]
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughByteCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var orgByteCode1 = GetByteCode(workPath, fileName);
			var orgCode1 = File.ReadAllText(orgPath);
			var model1 = JavaModelFactory.CreateModel(orgCode1);
			var code2 = JavaCodeGenerator.Generate(model1);
			File.WriteAllText(srcPath, code2);
			var byteCode2 = GetByteCode(workPath, fileName);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		/// モデルを通した再生成したコードが変化しないかテストします。
		/// 元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		/// モデル2とモデル3を比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		//[Ignore, Test, TestCaseSource("TestCases")]
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughModel(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var model1 = JavaModelFactory.CreateModel(orgCode);
			var code2 = JavaCodeGenerator.Generate(model1);
			var model2 = JavaModelFactory.CreateModel(code2);
			var code3 = JavaCodeGenerator.Generate(model2);
			var model3 = JavaModelFactory.CreateModel(code3);
			Assert.That(model3, Is.EqualTo(model1)
				.Using(StructuralEqualityComparer.Instance));
		}
	}
}