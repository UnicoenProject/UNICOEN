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
	/// コード→モデル→コードと変換することで再生成します。
	/// コードは、コンパイルしたバイナリファイル同士、もしくは、
	/// コードから得られるモデルで比較しています。
	/// </summary>
	[TestFixture]
	public class JavaRegenerateTest {
		private const string JavacPath = "javac";

		private static IEnumerable<byte[]> GetByteCode(string workPath,
		                                               string fileName) {
			var args = new[] {
				"\"" + Path.Combine(workPath, fileName) + "\""
			};
			var argg = args.JoinString(" ");
			var info = new ProcessStartInfo {
				FileName = JavacPath,
				Arguments = argg,
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
		/// CompareThroughByteCodeが正常に動作するかテストします。
		/// 全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughByteCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetByteCode(workPath, fileName);
			var actual = GetByteCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		/// CompareThroughModelが正常に動作するかテストします。
		/// 全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = JavaModelFactory.CreateModel(orgCode);
			var actual = JavaModelFactory.CreateModel(orgCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparer.Instance));
		}

		/// <summary>
		/// コンパイル結果を通して再生成したコードが変化しないかテストします。
		/// コードはコンパイルしたバイナリファイルで比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		//[Ignore, Test, TestCaseSource("TestCases")]
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughByteCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			var expected = GetByteCode(workPath, fileName);
			var orgCode = File.ReadAllText(orgPath);
			var model = JavaModelFactory.CreateModel(orgCode);
			var code = JavaCodeGenerator.Generate(model);
			File.WriteAllText(srcPath, code);
			var actual = GetByteCode(workPath, fileName);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		/// モデルを通した再生成したコードが変化しないかテストします。
		/// コードから生成したモデルで比較します。
		/// </summary>
		/// <param name="orgPath">再生成するソースコードのパス</param>
		//[Test, TestCaseSource(@"..\..\fixture\Java\input\Fibonacci.java")]
		[Ignore, Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void CompareThroughModel(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = JavaModelFactory.CreateModel(orgCode);
			var newCode = JavaCodeGenerator.Generate(expected);
			var actual = JavaModelFactory.CreateModel(newCode);
			Assert.That(actual, Is.EqualTo(expected)
				.Using(StructuralEqualityComparer.Instance));
		}
	}
}