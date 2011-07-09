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

using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   AspectAdaptorを用いたコードの合成が正しく行われるかテストします
	/// </summary>
	[TestFixture]
	public class AspectAdaptorTest {
		private static readonly string JavaCodePath =
			FixtureUtil.GetInputPath("AspectCompiler", "JavaSample.java");

		private static readonly string JavaScriptCodePath = 
			FixtureUtil.GetInputPath("AspectCompiler", "JavaScriptSample.js");

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
			var javaCode = File.ReadAllText(JavaCodePath, XEncoding.SJIS);
			_javaModel = CodeProcessor.CreateModel(".java", javaCode);
			_amountOfBlockInJava = _javaModel.Descendants<UnifiedBlock>().ToListLiteral().Count;

			//JavaScript言語のモデルを作成
			var javaScriptCode = File.ReadAllText(JavaScriptCodePath, XEncoding.SJIS);
			_javaScriptModel = CodeProcessor.CreateModel(".js", javaScriptCode);
			_amountOfBlockInJavaScript = _javaScriptModel.Descendants<UnifiedBlock>().ToListLiteral().Count;
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

		[Test]
		public void Java言語の関数実行前にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "before_execution.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "before_execution.java");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJava + 1) == _javaModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		//TODO このケースだとbeforeとafterのコード挿入位置が変わらないので、もっといいテストケースを用意する
		[Test]
		public void Java言語の関数実行後にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "after_execution.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "after_execution.java");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJava + 1) == _javaModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数呼び出し前にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "before_call.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "before_call.java");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);
			
			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJava + 1) == _javaModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数呼び出し後にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "after_call.txt");
			var visitor = CreateAspectElement(aspectPath);
			
			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "after_call.java");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJava + 1) == _javaModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			//期待値と合成結果が等しいかどうか
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数実行前にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "before_execution.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "before_execution.js");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJavaScript + 1) == _javaScriptModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数実行後にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "after_execution.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "after_execution.js");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);
			
			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJavaScript + 1) == _javaScriptModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数呼び出し前にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "before_call.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "before_call.js");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJavaScript + 1) == _javaScriptModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数呼び出し後にコードが正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "after_call.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "after_call.js");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);
					
			//モデル内のブロック数が１増えているかどうか
			Assert.That(
					(_amountOfBlockInJavaScript + 1) == _javaScriptModel.Descendants<UnifiedBlock>().ToListLiteral().Count, 
					Is.True);
			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語にインタータイプ宣言が正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "intertype.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "intertype.java");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			var amountOfMethodInExpectation = expectation.Descendants<UnifiedFunctionDefinition>().ToListLiteral().Count;
			var amountOfMethodInJava = _javaModel.Descendants<UnifiedFunctionDefinition>().ToListLiteral().Count;

			//モデル内のメソッド数が１増えているかどうか
			Assert.That(
					amountOfMethodInExpectation == amountOfMethodInJava, 
					Is.True);
			//インタータイプ宣言の合成結果はアスペクトの記述順と逆になるので、構造の一致はテストできない

		}

		[Test]
		public void JavaScript言語にインタータイプ宣言が正しく合成される() {
			//アスペクトモデルの作成
			var aspectPath = FixtureUtil.GetInputPath("AspectCompiler", 
				"partial_aspect", "intertype.txt");
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			var filePath = FixtureUtil.GetInputPath("AspectCompiler", 
				"expectation", "intertype.js");
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			var amountOfMethodInExpectation = expectation.Descendants<UnifiedFunctionDefinition>().ToListLiteral().Count;
			var amountOfMethodInJavaScript = _javaScriptModel.Descendants<UnifiedFunctionDefinition>().ToListLiteral().Count;

			//モデル内のメソッド数が１増えているかどうか
			Assert.That(
					amountOfMethodInExpectation == amountOfMethodInJavaScript, 
					Is.True);
			//インタータイプ宣言の合成結果はアスペクトの記述順と逆になるので、構造の一致はテストできない
		}
	}
}