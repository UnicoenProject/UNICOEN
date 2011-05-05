#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.ModelFactories;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	/// <summary>
	///   再生成したソースコードが変化していないかテストします。
	///   元コード1→モデル1→コード2→... のように再生成します。
	///   コードは、コンパイルしたclassファイル同士、
	///   もしくは、コードから得られるモデル同士で比較しています。
	/// </summary>
	[TestFixture]
	public class JavaRegenerateTest : RegenerateTest {
		private const string JavacPath = "javac";

		private readonly JavaFixture _fixture = new JavaFixture();

		public override LanguageFixture Fixture {
			get { return _fixture; }
		}

		private readonly JavaCodeFactory _codeFactory = new JavaCodeFactory();

		public override CodeFactory CodeFactory {
			get { return _codeFactory; }
		}

		private readonly JavaModelFactory _modelFactory = new JavaModelFactory();

		public override ModelFactory ModelFactory {
			get { return _modelFactory; }
		}

		protected override void Compile(string workPath, string fileName) {
			var args = new[] {
					"\"" + Path.Combine(workPath, fileName) + "\""
			};
			var arguments = args.JoinString(" ");
			CompileWithArguments(workPath, JavacPath, arguments);
		}

		protected override IEnumerable<object[]> GetAllCompiledCode(string workPath) {
			return Directory.EnumerateFiles(
					workPath, "*.class",
					SearchOption.AllDirectories)
					.Select(path => new object[] { path, File.ReadAllBytes(path) });
		}

		protected override void CompileWithArguments(
				string workPath, string command, string arguments) {
			var info = new ProcessStartInfo {
					FileName = command,
					Arguments = arguments,
					CreateNoWindow = true,
					UseShellExecute = false,
					WorkingDirectory = workPath,
					RedirectStandardError = true,
			};
			try {
				using (var p = Process.Start(info)) {
					var errorMessage = p.StandardError.ReadToEnd();
					p.WaitForExit();
					if (p.ExitCode != 0) {
						throw new InvalidOperationException(
								"Failed to compile the code.\n" + errorMessage);
					}
				}
			} catch (Win32Exception e) {
				throw new InvalidOperationException("Failed to launch compiler.", e);
			}
		}

		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public override void VerifyCompareThroughCompiledCodeForSameCode(
				string orgPath) {
			base.VerifyCompareThroughCompiledCodeForSameCode(orgPath);
		}

		[Test, TestCase(@"..\..\fixture\Java\input\Fibonacci.java")]
		public override void VerifyCompareThroughModelForSameCode(string orgPath) {
			base.VerifyCompareThroughModelForSameCode(orgPath);
		}

		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void CompareThroughByteCodeUsingCode(string code) {
			base.CompareThroughByteCodeUsingCode(code);
		}

		[Test, TestCaseSource("TestCodes"), TestCaseSource("TestStatements")]
		public override void CompareThroughModelUsingCode(string code) {
			base.CompareThroughModelUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareThroughByteCodeUsingFile(string orgPath) {
			base.CompareThroughByteCodeUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareThroughModelUsingFile(string orgPath) {
			base.CompareThroughModelUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareThroughByteCodeUsingDirectory(
				string orgPath, string command, string arguments) {
			base.CompareThroughByteCodeUsingDirectory(orgPath, command, arguments);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareThroughModelUsingDirectory(
				string orgPath, string command, string arguments) {
			base.CompareThroughModelUsingDirectory(orgPath, command, arguments);
		}
	}
}