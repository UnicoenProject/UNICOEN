using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Apps.Aop.Tests
{
	/// <summary>
	/// AspectAdaptorを用いたコードの合成が正しく行われるかテストします
	/// </summary>
	[TestFixture]
	public class AspectAdaptorTest {

		private const string JavaCodePath =
				"../fixture/AspectCompiler/input/JavaSample.java";
		private const string JavaScriptCodePath =
				"../fixture/AspectCompiler/input/JavaScriptSample.js";

		private UnifiedProgram _javaModel;
		private UnifiedProgram _javaScriptModel;

		/// <summary>
		/// 基準となるソースコードをモデルに変換します
		/// </summary>
		[SetUp]
		public void Setup() {
			//Java言語のモデルを作成
			var javaCode = File.ReadAllText(JavaCodePath, XEncoding.SJIS);
			_javaModel = CodeProcessor.CreateModel("Java", javaCode);

			//JavaScript言語のモデルを作成
			var javaScriptCode = File.ReadAllText(JavaScriptCodePath, XEncoding.SJIS);
			_javaScriptModel = CodeProcessor.CreateModel("Java", javaScriptCode);
		}

		public AstVisitor CreateAspectElement(string path) {
			//アスペクトファイルの生成
			var aspect = new Antlr.Runtime.ANTLRFileStream(path);
			var lexer = new AriesLexer(aspect);
			var tokens = new Antlr.Runtime.CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree) result.Tree;

			var visitor = new AstVisitor();
			visitor.Visit(ast, 0, null);

			return visitor;
		}

		[Test]
		public void Java言語の関数実行前にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath = ""; //TODO before_executionのアスペクトを用意
			var visitor = CreateAspectElement(aspectPath);
			
			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);
			
			//期待されるモデルの作成
			const string filePath = "../fixture/AspectCompiler/input/expectation/before_execution.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel("Java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数実行後にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath = ""; //TODO after_executionのアスペクトを用意
			var visitor = CreateAspectElement(aspectPath);
			
			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);
			
			//期待されるモデルの作成
			const string filePath = "../fixture/AspectCompiler/input/expectation/after_execution.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel("Java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数呼び出し前にコードが正しく合成される() {
			//TODO implement
		}

		[Test]
		public void Java言語の関数呼び出し後にコードが正しく合成される() {
			//TODO implement
		}

		[Test]
		public void JavaScript言語の関数実行前にコードが正しく合成される() {
			//TODO implement
		}
		[Test]
		public void JavaScript言語の関数実行後にコードが正しく合成される() {
			//TODO implement
		}

		[Test]
		public void JavaScript言語の関数呼び出し前にコードが正しく合成される() {
			//TODO implement
		}

		[Test]
		public void JavaScript言語の関数呼び出し後にコードが正しく合成される() {
			//TODO implement
		}

		//TODO インタータイプ宣言に関するテストの追加
	}
}
