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
using System.IO;
using System.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.UniAspect.Cui.Processor;
using Unicoen.Apps.UniAspect.Cui.Visitor;
using Unicoen.Languages.Java.CodeGenerators;
using Unicoen.Model;
using Unicoen.Processor;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui {
	/// <summary>
	///   AspectAdaptorを用いたコードの合成が正しく行われるかテストします
	/// </summary>
	[TestFixture]
	public class AspectAdaptorTest {
		private static readonly string JavaCodePath =
				FixtureUtil.GetInputPath("Aspect", "JavaSample.java");

		private static readonly string JavaScriptCodePath =
				FixtureUtil.GetInputPath("Aspect", "JavaScriptSample.js");

		private UnifiedProgram _javaModel;
		private UnifiedProgram _javaScriptModel;

		//アスペクト合成前におけるモデル内のブロック数
		private int _amountOfBlockInJava;
		private int _amountOfBlockInJavaScript;

		/// <summary>
		///   基準となるソースコードをモデルに変換します
		/// </summary>
		[SetUp]
		public void Setup() {
			//Java言語のモデルを作成
			_javaModel = UniGenerators.GenerateProgramFromFile(JavaCodePath);
			_amountOfBlockInJava =
					_javaModel.Descendants<UnifiedBlock>().Count();

			//JavaScript言語のモデルを作成
			_javaScriptModel = UniGenerators.GenerateProgramFromFile(JavaScriptCodePath);
			_amountOfBlockInJavaScript =
					_javaScriptModel.Descendants<UnifiedBlock>().Count();
		}

		public AstVisitor CreateAspectElement(string path) {
			//アスペクトファイルの生成
			var aspect = new ANTLRFileStream(path);
			var lexer = new AriesLexer(aspect);
			var tokens = new CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree)result.Tree;

			var visitor = new AstVisitor();
			visitor.Visit(ast, 0, null);

			return visitor;
		}

		/// <summary>
		/// Java言語向けにアスペクトが正しく合成されるかどうかをテストします
		/// </summary>
		/// <param name="aspectFile">入力アスペクトファイル名</param>
		/// <param name="expectationFile">アスペクト合成後の期待値ファイル名</param>
		public void AssertCorrectWeavingForJava(string aspectFile, string expectationFile) {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetAspectPath(aspectFile);
			Weaver.AnalizeAspect(aspectPath);

			//アスペクトの合成処理
			Weaver.Weave("Java", _javaModel);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetAspectExpectationPath(expectationFile);
			var expectation = UniGenerators.GenerateProgramFromFile(filePath);

			//for debug
			var gen = new JavaCodeGenerator();
			Console.Write(gen.Generate(_javaModel));

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
				_amountOfBlockInJava + 1, 
				Is.EqualTo(_javaModel.Descendants<UnifiedBlock>().Count()));
			//構造が一致しているかどうか
			Assert.That(
					_javaModel,
					Is.EqualTo(expectation).Using(StructuralEqualityComparer.Instance));
		}

		/// <summary>
		/// JavaScript言語向けにアスペクトが正しく合成されるかどうかをテストします
		/// </summary>
		/// <param name="aspectFile">入力アスペクトファイル名</param>
		/// <param name="expectationFile">アスペクト合成後の期待値ファイル名</param>
		public void AssertCorrectWeavingForJavaScript(string aspectFile, string expectationFile) {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetAspectPath(aspectFile);
			Weaver.AnalizeAspect(aspectPath);

			//アスペクトの合成処理
			Weaver.Weave("JavaScript", _javaScriptModel);
			Console.WriteLine(_javaScriptModel);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetAspectExpectationPath(expectationFile);
			var expectation = UniGenerators.GenerateProgramFromFile(filePath);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					_amountOfBlockInJavaScript + 1,
					Is.EqualTo(_javaScriptModel.Descendants<UnifiedBlock>().Count()));
			//構造が一致しているかどうか
			Assert.That(
					_javaScriptModel,
					Is.EqualTo(expectation).Using(StructuralEqualityComparer.Instance));
		}
		
		[Test]
		public void Java言語の関数実行前にコードが正しく合成される() {
			AssertCorrectWeavingForJava("before_execution.apt", "before_execution.java");
		}

		//TODO このケースだとbeforeとafterのコード挿入位置が変わらないので、もっといいテストケースを用意する
		[Test]
		public void Java言語の関数実行後にコードが正しく合成される() {
			AssertCorrectWeavingForJava("after_execution.apt", "after_execution.java");
		}

		[Test]
		public void Java言語の関数呼び出し前にコードが正しく合成される() {
			AssertCorrectWeavingForJava("before_call.apt", "before_call.java");
		}

		[Test]
		public void Java言語の関数呼び出し後にコードが正しく合成される() {
			AssertCorrectWeavingForJava("after_call.apt", "after_call.java");
		}

		[Test]
		public void JavaScript言語の関数実行前にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("before_execution.apt", "before_execution.js");
		}

		[Test]
		public void JavaScript言語の関数実行後にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("after_execution.apt", "after_execution.js");
		}

		[Test]
		public void JavaScript言語の関数呼び出し前にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("before_call.apt", "before_call.js");
		}

		[Test]
		public void JavaScript言語の関数呼び出し後にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("after_call.apt", "after_call.js");
		}

		[Test]
		public void Java言語の変数代入前にコードが正しく合成される() {
			AssertCorrectWeavingForJava("before_set.apt", "before_set.java");
		}

		[Test]
		public void Java言語の変数代入後にコードが正しく合成される() {
			AssertCorrectWeavingForJava("after_set.apt", "after_set.java");
		}

		[Test]
		public void Java言語の変数参照前にコードが正しく合成される() {
			AssertCorrectWeavingForJava("before_get.apt", "before_get.java");
		}

		[Test]
		public void Java言語の変数参照後にコードが正しく合成される() {
			AssertCorrectWeavingForJava("after_get.apt", "after_get.java");
		}

		[Test]
		public void JavaScript言語の変数代入前にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("before_set.apt", "before_set.js");
		}

		[Test]
		public void JavaScript言語の変数代入後にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("after_set.apt", "after_set.js");
		}

		[Test]
		public void JavaScript言語の変数参照前にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("before_get.apt", "before_get.js");
		}

		[Test]
		public void JavaScript言語の変数参照後にコードが正しく合成される() {
			AssertCorrectWeavingForJavaScript("after_get.apt", "after_get.js");
		}

		[Test]
		public void Java言語にインタータイプ宣言が正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetAspectPath("intertype.apt");
			Weaver.AnalizeAspect(aspectPath);

			//アスペクトの合成処理
			Weaver.Weave("Java", _javaModel);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetAspectExpectationPath("intertype.java");
			var expectation = UniGenerators.GenerateProgramFromFile(filePath);

			var amountOfMethodInExpectation =
					expectation.Descendants<UnifiedFunctionDefinition>().Count();
			var amountOfMethodInJava =
					_javaModel.Descendants<UnifiedFunctionDefinition>().Count();

			//モデル内のメソッド数が１増えているかどうか
			Assert.That(
					amountOfMethodInExpectation, 
					Is.EqualTo(amountOfMethodInJava));
			//インタータイプ宣言の合成結果はアスペクトの記述順と逆になるので、構造の一致はテストできない
		}

		[Test]
		public void JavaScript言語にインタータイプ宣言が正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetAspectPath("intertype.apt");
			Weaver.AnalizeAspect(aspectPath);

			//アスペクトの合成処理
			Weaver.Weave("JavaScript", _javaScriptModel);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetAspectExpectationPath("intertype.js");
			var expectation = UniGenerators.GenerateProgramFromFile(filePath);

			var amountOfMethodInExpectation =
					expectation.Descendants<UnifiedFunctionDefinition>().Count();
			var amountOfMethodInJavaScript =
					_javaScriptModel.Descendants<UnifiedFunctionDefinition>().Count();

			//モデル内のメソッド数が１増えているかどうか
			Assert.That(
					amountOfMethodInExpectation, 
					Is.EqualTo(amountOfMethodInJavaScript));
			//インタータイプ宣言の合成結果はアスペクトの記述順と逆になるので、構造の一致はテストできない
		}
	}
}