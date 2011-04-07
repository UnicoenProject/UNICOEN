using System.Linq;
using System.Xml.Linq;
using Code2Xml.Languages.JavaScript.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.JavaScript.Model;

namespace Ucpf.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptModelTest {
		private static readonly string InputPath =
			Fixture.GetInputPath("JavaScript", "fibonacci.js");

		[SetUp]
		public void SetUp() {
			_ast = JavaScriptXmlGenerator.Instance.GenerateFromFile(InputPath);
			_root = _ast.Descendants("functionDeclaration").First();
			_func = JSModelFactory.CreateFunction(_root);
		}

		private XElement _ast;
		private XElement _root;
		private UnifiedFunctionDefinition _func;

		[Test]
		public void If文の条件式を取得する() {
			//actual
			var block   = _func.Body;
			var expStmt = block.First();
			var ifStmt  = (UnifiedIf)expStmt;
			var cond    = ifStmt.Condition;

			//expectation
			var expectation = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorType.LessThan), UnifiedIntegerLiteral.Create(2));

			Assert.That(cond, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数のパラメータを取得する() {
			//actual
			var firstParam = _func.Parameters.First();

			//expectation
			var expectation = UnifiedParameter.Create("n");

			Assert.That(firstParam, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 一番最初に宣言されている関数名を取得する() {
			Assert.That(_func.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 一番最初のreturn文を取得する() {
			//actual
			var block      = _func.Body;
			var expStmt    = block.First();
			var ifStmt     = (UnifiedIf)expStmt;
			var tBlock     = ifStmt.Body;
			var returnStmt = tBlock.First();

			//expectation
			var expectation = UnifiedJump.CreateReturn(UnifiedVariable.Create("n"));

			Assert.That(returnStmt, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 二項演算子を取得する() {
			//actual
			var block       = _func.Body;
			var expStmt     = block.First();
			var ifStmt      = (UnifiedIf)expStmt;
			var fBlock      = ifStmt.FalseBody;
			var returnStmt  = (UnifiedJump)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;

			Assert.That(binaryExp.Operator.Sign, Is.EqualTo("+"));
		}

		[Test]
		public void 呼び出す関数の名前を取得する() {
			//actual
			var block       = _func.Body;
			var expStmt     = block.First();
			var ifStmt      = (UnifiedIf)expStmt;
			var fBlock      = ifStmt.FalseBody;
			var returnStmt  = (UnifiedJump)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp     = (UnifiedCall)binaryExp.LeftHandSide;
			var identifier  = (UnifiedVariable)callExp.Function;

			Assert.That(identifier.Name, Is.EqualTo("fibonacci"));
		}

		[Test]
		public void 呼び出す関数の引数を取得する() {
			var block       = _func.Body;
			var expStmt     = block.First();
			var ifStmt      = (UnifiedIf)expStmt;
			var fBlock      = ifStmt.FalseBody;
			var returnStmt  = (UnifiedJump)fBlock.First();
			var binaryExp   = (UnifiedBinaryExpression)returnStmt.Value;
			var callExp     = (UnifiedCall)binaryExp.LeftHandSide;
			var firstArg    = callExp.Arguments.First().Value;

			//expectation
			var expectation = UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"), UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract), UnifiedIntegerLiteral.Create(1));

			Assert.That(firstArg, Is.EqualTo(expectation)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 返却される式を取得する() {
			//actual
			var block = _func.Body;
			var expStmt = block.First();
			var ifStmt = (UnifiedIf)expStmt;
			var fBlock = ifStmt.FalseBody;
			var returnStmt = (UnifiedJump)fBlock.First();
			var binaryExp = (UnifiedBinaryExpression)returnStmt.Value;

			//expectation
			var expectation = UnifiedBinaryExpression.Create(UnifiedCall.Create(
					UnifiedVariable.Create("fibonacci"),
					UnifiedArgumentCollection.Create(
							UnifiedArgument.Create(UnifiedBinaryExpression.Create(
											UnifiedVariable.Create("n"),
											UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorType.Subtract),
											UnifiedIntegerLiteral.Create(1)
											))
							)
					),
					UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorType.Add),
					UnifiedCall.Create(
							UnifiedVariable.Create("fibonacci"),
							UnifiedArgumentCollection.Create(
									UnifiedArgument.Create(UnifiedBinaryExpression.Create(UnifiedVariable.Create("n"),
															UnifiedBinaryOperator.Create("-",
																	UnifiedBinaryOperatorType.Subtract),
															UnifiedIntegerLiteral.Create(2)
															))
									)
							)
					);

			Assert.That(binaryExp, Is.EqualTo(expectation)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void 関数内のステートメントを取得する() {
			//actual
			var block     = _func.Body;
			var firstStmt = block.First();

			Assert.That(firstStmt, Is.InstanceOf<IUnifiedExpression>());
		}
	}
}