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
using Unicoen.CodeGenerators;
using Unicoen.Processor;
using Unicoen.ProgramGenerators;
using Unicoen.Tests;
using Unicoen.Utils;

namespace Unicoen.Languages.Tests {
	public abstract class Fixture {
		private string _languageName;

		/// <summary>
		///   対応する言語の名前をクラス名から解析して取得します．
		/// </summary>
		public string LanguageName {
			get {
				if (_languageName == null) {
					var name = GetType().Name;
					_languageName = name.Substring(0, name.Length - "Fixture".Length);
				}
				return _languageName;
			}
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public abstract string Extension { get; }

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public abstract string CompiledExtension { get; }

		/// <summary>
		///   バイトコード同士を比較する際に許容する不一致の要素数を取得します．
		/// </summary>
		public virtual int AllowedMismatchCount {
			get { return 0; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public abstract UnifiedProgramGenerator ProgramGenerator { get; }

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public abstract UnifiedCodeGenerator CodeGenerator { get; }

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestCodes { get; }

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestFilePathes { get; }

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestProjectInfos { get; }

		/// <summary>
		///   テスト時に入力する時間のかかるプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
		/// </summary>
		public abstract IEnumerable<TestCaseData> TestHeavyProjectInfos { get; }

		/// <summary>
		///   指定したファイルのソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "workPath">コンパイル時の作業ディレクトリのパス</param>
		/// <param name = "srcPath">コンパイル対象のソースコードのパス</param>
		public abstract void Compile(string workPath, string srcPath);

		/// <summary>
		///   指定したディレクトリ内の全てのソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "workPath">ソースコードが格納されている作業ディレクトリのパス</param>
		public virtual void CompileAll(string workPath) {
			var filePaths = GetAllSourceFilePaths(workPath);
			foreach (var filePath in filePaths) {
				Compile(workPath, filePath);
			}
		}

		/// <summary>
		///   例外を無視して指定したディレクトリ内の全てのソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "workPath">ソースコードが格納されている作業ディレクトリのパス</param>
		public virtual void TryCompileAll(string workPath) {
			var filePaths = GetAllSourceFilePaths(workPath);
			foreach (var filePath in filePaths) {
				try {
					Compile(workPath, filePath);
				} catch {}
			}
		}

		/// <summary>
		///   ソースコードを指定したコマンドと引数でコンパイルします．
		/// </summary>
		/// <param name = "workPath">コマンドを実行する作業ディレクトリのパス</param>
		/// <param name = "command">コンパイルのコマンド</param>
		/// <param name = "arguments">コマンドの引数</param>
		public virtual void CompileWithArguments(
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

		/// <summary>
		///   指定したディレクトリ内の全てのソースコードのパスを取得します．
		/// </summary>
		/// <param name = "dirPath">ソースコードが格納されているディレクトリのパス</param>
		/// <returns></returns>
		public IEnumerable<string> GetAllSourceFilePaths(string dirPath) {
			return Directory.EnumerateFiles(
					dirPath, "*" + Extension,
					SearchOption.AllDirectories);
		}

		/// <summary>
		///   コンパイル済みのコードのバイト列を取得します．
		/// </summary>
		/// <param name = "path">コンパイル済みのコードのパス</param>
		/// <returns>コンパイル済みのコードのバイト列</returns>
		public virtual object GetCompiledByteCode(string path) {
			return File.ReadAllBytes(path);
		}

		/// <summary>
		///   コンパイル済みのコードを全て取得します．
		/// </summary>
		/// <param name = "dirPath">コンパイル済みコードが格納されているディレクトリのパス</param>
		/// <returns></returns>
		public IList<Tuple<string, object>> GetAllCompiledCode(string dirPath) {
			return Directory.EnumerateFiles(
					dirPath, "*" + CompiledExtension,
					SearchOption.AllDirectories)
					.Select(path => Tuple.Create(path, GetCompiledByteCode(path)))
					.ToList();
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Func<string, bool> deploySource) {
			return SetUpTestCaseData(dirName, deploySource, (s1, s2) => { });
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Action<string> deploySource) {
			return SetUpTestCaseData(dirName, deploySource, (s1, s2) => { });
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Action<string> deploySource,
				Action<string> compileActionByWorkPath) {
			return SetUpTestCaseData(
					dirName, path => {
						deploySource(path);
						return true;
					}, (workPath, inPath) => compileActionByWorkPath(workPath));
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Action<string> deploySource,
				Action<string, string> compileActionByWorkAndDirPath) {
			return SetUpTestCaseData(
					dirName, path => {
						deploySource(path);
						return true;
					}, compileActionByWorkAndDirPath);
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Func<string, bool> deploySource,
				Action<string> compileActionByWorkPath) {
			return SetUpTestCaseData(
					dirName, deploySource,
					(workPath, inPath) => compileActionByWorkPath(workPath));
		}

		protected IEnumerable<TestCaseData> SetUpTestCaseData(
				string dirName, Func<string, bool> deploySource,
				Action<string, string> compileActionByWorkAndDirPath) {
			var path = FixtureUtil.GetDownloadPath(LanguageName, dirName);
			var testCase = new TestCaseData(path, compileActionByWorkAndDirPath);
			if (Directory.Exists(path)
			    && Directory.EnumerateFiles(path, "*" + Extension, SearchOption.AllDirectories).Count() >= 1) {
				yield return testCase;
				yield break;
			}
			Directory.CreateDirectory(path);
			if (deploySource(path))
				yield return testCase;
		}

		protected void DownloadAndUnzip(string url, string path) {
			var arcPath = Path.Combine(path, "temp.zip");
			Downloader.Download(url, arcPath);
			Extractor.Unzip(arcPath, path);
		}

		protected void DownloadAndUntgz(string url, string path) {
			using (var stream = Downloader.GetStream(url)) {
				Extractor.Untgz(stream, path);
			}
		}

		protected void DownloadAndUntbz(string url, string path) {
			using (var stream = Downloader.GetStream(url)) {
				Extractor.Untbz(stream, path);
			}
		}
	}
}