using System.Linq;
using NUnit.Framework;
using Paraiba.Linq;
using Ucpf.AstGenerators;
using Ucpf.CodeGenerators;
using Ucpf.Languages.Java;

namespace Ucpf.Languages.Tests.Temp
{
	[TestFixture]
	public class JavaPointcutsTest
	{
		private static AstGenerator _xmlGen;
		private static CodeGenerator _codeGen;
		private static JavaPointcut _pointcut;
		private const string BaseDirectory = "../fixture/";
		private const string ExtensionName = ".java";

		[SetUp]
		public void MySetUp()
		{
			_xmlGen = JavaAstGenerator.Instance;
			_codeGen = JavaCodeGenerator.Instance;
			_pointcut = new JavaPointcut();
		}

		[Test]
		public void Statementに対してElementFactoryが動作する()
		{
			var r1 = _xmlGen.GenerateFromFile(BaseDirectory + "Block1" + ExtensionName);
			var statements = r1.Descendants("statement");
			foreach (var statement in statements) {
				var stmtElement = SemanticAnalyzer.Statement(statement);
				var index = 0;
				Assert.IsTrue(stmtElement is JavaExpressionStatement == (
					statement.Elements().ElementAt(index++).Name == "expression" &&
					statement.Elements().ElementAt(index++).Value == ";"
					));
				index = 0;
				Assert.IsTrue(stmtElement is JavaIfStatement == (
					statement.Elements().ElementAt(index++).Value == "if" &&
					statement.Elements().ElementAt(index++).Name == "parExpression" &&
					statement.Elements().ElementAt(index++).Name == "statement"
					));
			}
		}

		[Test]
		public void 全てのStatementを取得できる()
		{
			var r1 = _xmlGen.GenerateFromFile(BaseDirectory + "Block1" + ExtensionName);
			var statements = _pointcut.Statements(r1);
			var expressionStatements = statements
				.Where(stmt => stmt is JavaExpressionStatement);
			foreach (var expressionStatement in expressionStatements) {
				Assert.IsTrue(expressionStatement.Code.StartsWith("System.out.println"));
			}
		}

		[Test]
		public void Statementを生成できる()
		{
			var code = "System.out.println(\"weave\");";
			var statement = SemanticFactory.Statement(code);
			Assert.IsTrue(statement is JavaExpressionStatement);
			Assert.IsTrue(statement.Code == code);
		}

		[Test]
		public void 全てのIfStatementを取得できる()
		{
			var ast = _xmlGen.GenerateFromFile(BaseDirectory + "Block1" + ExtensionName);
			var expectNodes = ast.Descendants("statement")
				.Where(e => e.Value.StartsWith("if"))
				.Take(5);

			var elements = _pointcut.IfStatements(ast);
			Assert.AreEqual(expectNodes.Count(), elements.Count());
			foreach (var tuple in elements.Zip(expectNodes)) {
				Assert.AreEqual(tuple.Item1.Node, tuple.Item2);
			}
		}

		[Test]
		public void IfStatementからTrueの処理が取得できる()
		{
			var ast = _xmlGen.GenerateFromFile(BaseDirectory + "Block1" + ExtensionName);
			var elements = _pointcut.IfStatements(ast).ToList();
			var i = 0;
			Assert.That(elements[i++].IfProcess.Code, Is.EqualTo("{System.out.println(\"0\");}"));
			Assert.That(elements[i++].IfProcess.Code, Is.EqualTo("{System.out.println(\"0\");}"));
			Assert.That(elements[i++].IfProcess.Code, Is.EqualTo("{System.out.println(\"0\");}"));
			Assert.That(elements[i++].IfProcess.Code, Is.EqualTo("{System.out.println(\"1\");}"));
			Assert.That(elements[i++].IfProcess.Code, Is.EqualTo("{System.out.println(\"2\");}"));
			Assert.That(elements.Count(), Is.EqualTo(i));
		}

		[Test]
		public void IfStatementからElseの処理が取得できる()
		{
			var ast = _xmlGen.GenerateFromFile(BaseDirectory + "Block1" + ExtensionName);
			var elements = _pointcut.IfStatements(ast).ToList();

			var i = 0;
			Assert.That(elements[i++].ElseProcess, Is.Null);
			Assert.That(elements[i++].ElseProcess.Code, Is.EqualTo("{System.out.println(\"else\");}"));
			Assert.That(elements[i++].ElseProcess.Code, Is.StringStarting("{if(i==1)"));
			Assert.That(elements[i++].ElseProcess.Code, Is.StringStarting("{if(i==2)"));
			Assert.That(elements[i++].ElseProcess.Code, Is.EqualTo("{System.out.println(\"else\");}"));
			Assert.That(elements.Count(), Is.EqualTo(i));
		}
	}
}
