using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Paraiba.IO;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.CodeGeneraotr;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	/// <summary>
	///   Java向けに再生成したソースコードが変化していないかテストします。
	///   元コード1→モデル1→コード2→... のように再生成します。
	///   コードは、コンパイルしたclassファイル同士、
	///   もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[TestFixture]
	public class JavaRegenerateTest {
		private const string JavacPath = "javac";

		private static void Compile(string workPath, string fileName) {
			var args = new[] {
					"\"" + Path.Combine(workPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(workPath, JavacPath, arguments);
		}

		private static IEnumerable<Tuple<string, byte[]>> GetAllByteCode(
				string workPath) {
			return Directory.EnumerateFiles(workPath, "*.class",
					SearchOption.AllDirectories)
					.Select(path => Tuple.Create(path, File.ReadAllBytes(path)));
		}

		private static void CompileWithArguments(string workPath, string command,
		                                         string arguments) {
			var info = new ProcessStartInfo {
					FileName = command,
					Arguments = arguments,
					CreateNoWindow = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
			};
			try {
				using (var p = Process.Start(info)) {
					p.WaitForExit();
					if (p.ExitCode != 0) {
						throw new InvalidOperationException("Failed to compile the code.");
					}
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException("Failed to launch compiler.", e);
			}
		}

		public static IEnumerable<TestCaseData> TestStatements {
			get { return JavaFixture.TestStatements; }
		}

		public static IEnumerable<TestCaseData> TestCodes {
			get { return JavaFixture.TestCodes; }
		}

		public static IEnumerable<TestCaseData> TestFilePathes {
			get { return JavaFixture.TestFilePathes; }
		}

		public static IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return JavaFixture.TestDirectoryPathes; }
		}

		/// <summary>
		///   再生成を行わずCompareThroughByteCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void TestCompareThroughByteCodeForSameCode(string orgPath) {
			var workPath = Fixture.CleanTemporalPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.Copy(orgPath, srcPath);
			Compile(workPath, fileName);
			var expected = GetAllByteCode(workPath);
			Compile(workPath, fileName);
			var actual = GetAllByteCode(workPath);
			Assert.That(actual, Is.EqualTo(expected));
		}

		/// <summary>
		///   再生成を行わずCompareThroughModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public void TestCompareThroughModelForSameCode(string orgPath) {
			var orgCode = File.ReadAllText(orgPath);
			var expected = JavaModelFactory.CreateModel(orgCode);
			var actual = JavaModelFactory.CreateModel(orgCode);
			Assert.That(actual, Is.EqualTo(expected)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "orgCode1">再生成するソースコード</param>
		/// <param name = "fileName">再生成するソースコードのファイル名</param>
		public void VerifyCompareThroughByteCode(string orgCode1, string fileName) {
			var workPath = Fixture.CleanTemporalPath();
			var srcPath = Fixture.GetTemporalPath(fileName);
			File.WriteAllText(srcPath, orgCode1);
			Compile(workPath, fileName);
			var orgByteCode1 = GetAllByteCode(workPath);
			var model1 = JavaModelFactory.CreateModel(orgCode1);
			var code2 = JavaCodeGenerator.Generate(model1);
			File.WriteAllText(srcPath, code2);
			Compile(workPath, fileName);
			var byteCode2 = GetAllByteCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   指定したディレクトリ内のコンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		/// <param name = "command">コンパイルに用いるコマンド名</param>
		/// <param name = "arguments">コンパイルに用いる引数リスト</param>
		public void VerifyCompareThroughByteCodeUsingDirectory(string dirPath,
		                                                       string command,
		                                                       string arguments) {
			var workPath = Fixture.CleanTemporalPath();
			FileUtility.CopyRecursively(dirPath, workPath);
			CompileWithArguments(workPath, command, arguments);
			var orgByteCode1 = GetAllByteCode(workPath);
			var codePaths = JavaFixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = File.ReadAllText(codePath);
				var model1 = JavaModelFactory.CreateModel(orgCode1);
				var code2 = JavaCodeGenerator.Generate(model1);
				File.WriteAllText(workPath, code2);
			}
			CompileWithArguments(workPath, command, arguments);
			var byteCode2 = GetAllByteCode(workPath);
			Assert.That(byteCode2, Is.EqualTo(orgByteCode1));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgCode">再生成するソースコード</param>
		public void VerifyCompareThroughModel(string orgCode) {
			var model1 = JavaModelFactory.CreateModel(orgCode);
			var code2 = JavaCodeGenerator.Generate(model1);
			var model2 = JavaModelFactory.CreateModel(code2);
			var code3 = JavaCodeGenerator.Generate(model2);
			var model3 = JavaModelFactory.CreateModel(code3);
			Assert.That(model3, Is.EqualTo(model1)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "dirPath">再生成するソースコードが格納されているディレクトリパス</param>
		public void VerifyCompareThroughModelUsingDirectory(string dirPath) {
			var codePaths = JavaFixture.GetAllSourceFilePaths(dirPath);
			foreach (var codePath in codePaths) {
				var orgCode = File.ReadAllText(codePath);
				var model1 = JavaModelFactory.CreateModel(orgCode);
				var code2 = JavaCodeGenerator.Generate(model1);
				var model2 = JavaModelFactory.CreateModel(code2);
				var code3 = JavaCodeGenerator.Generate(model2);
				var model3 = JavaModelFactory.CreateModel(code3);
				Assert.That(model3, Is.EqualTo(model1)
						.Using(StructuralEqualityComparerForDebug.Instance));
			}
		}

		[Test, TestCaseSource("TestStatements")]
		public void CompareThroughByteCodeUsingStatement(string statement) {
			VerifyCompareThroughByteCode(statement, "A.java");
		}

		[Test, TestCaseSource("TestStatements")]
		public void CompareThroughModelUsingStatement(string statement) {
			VerifyCompareThroughModel(statement);
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareThroughByteCodeUsingCode(string code) {
			VerifyCompareThroughByteCode(code, "A.java");
		}

		[Test, TestCaseSource("TestCodes")]
		public void CompareThroughModelUsingCode(string code) {
			VerifyCompareThroughModel(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareThroughByteCodeUsingFile(string orgPath) {
			var fileName = Path.GetFileName(orgPath);
			VerifyCompareThroughByteCode(File.ReadAllText(orgPath), fileName);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public void CompareThroughModelUsingFile(string orgPath) {
			VerifyCompareThroughModel(File.ReadAllText(orgPath));
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public void CompareThroughByteCodeUsingDirectory(string orgPath,
		                                                 string command,
		                                                 string arguments) {
			VerifyCompareThroughByteCodeUsingDirectory(orgPath, command, arguments);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public void CompareThroughModelUsingDirectory(string orgPath,
														 string command,
														 string arguments) {
			VerifyCompareThroughModelUsingDirectory(orgPath);
		}
	}
}