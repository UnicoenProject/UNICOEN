using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[TestFixture]
	public class CSharpStudentTest {
		private readonly string _source;

		public CSharpStudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path);
		}

		[Test]
		public void CreateExpectedClassDefinition() {
			Assert.That(CreateModel(), Is.Not.Null);
		}

		[Test]
		public void CreateClassDefinition() {
			var expected = CreateModel();

			var actual = CSharpModelFactory.CreateModel(_source);
			Assert.That(actual,
				Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}

		public static UnifiedProgram CreateModel() {
			return UnifiedProgram.Create(
					UnifiedClassDefinition.CreateClass(
							"Student",
							UnifiedBlock.Create(new IUnifiedExpression[] {
									UnifiedVariableDefinition.Create(
											UnifiedType.Create("String"),
											"_name",
											UnifiedModifierCollection.Create(UnifiedModifier.Create("private"))
											),
									UnifiedConstructorDefinition.Create(
											UnifiedBlock.Create(
													CSharpModelFactoryHelper.CreateAssignExpression(
															UnifiedVariable.Create("_name"), UnifiedVariable.Create("name"))
													),
											UnifiedModifier.Create("public"),
											UnifiedParameterCollection.Create(
													UnifiedParameter.Create(
															"name", UnifiedType.Create("String"))
													)
											),
									UnifiedFunctionDefinition.Create(
											"getName",
											UnifiedType.Create("String"),
											UnifiedModifierCollection.Create(
													UnifiedModifier.Create("public")
													),
											UnifiedBlock.Create(
													UnifiedJump.CreateReturn(UnifiedVariable.Create("_name"))
													)
											),
									UnifiedFunctionDefinition.Create(
											"main",
											UnifiedType.Create("void"),
											UnifiedModifierCollection.Create(
													UnifiedModifier.Create("public"),
													UnifiedModifier.Create("static")
													),
											UnifiedParameterCollection.Create(
													UnifiedParameter.Create("args", UnifiedType.Create("String[]"))
													),
											UnifiedBlock.Create(
													UnifiedVariableDefinition.Create(UnifiedType.Create("Student[]"),
															"students",
															UnifiedArrayNew.Create(UnifiedType.Create("Student"), 
																UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedIntegerLiteral.Create(2))), 
																null)
															),
													CSharpModelFactoryHelper.CreateAssignExpression(
															UnifiedIndexer.Create(UnifiedVariable.Create("students"), 
															UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedIntegerLiteral.Create(0)))),
																UnifiedNew.Create(UnifiedType.Create("Student"), 
																	UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedStringLiteral.Create("Tom")))) 
															),
													CSharpModelFactoryHelper.CreateAssignExpression(
															UnifiedIndexer.Create(UnifiedVariable.Create("students"), 
																UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedIntegerLiteral.Create(1)))),
																	UnifiedNew.Create(UnifiedType.Create("Student"), UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedStringLiteral.Create("Anna"))))
															),
													UnifiedFor.Create(
															UnifiedVariableDefinition.Create(UnifiedType.Create("int"), "i",
																	UnifiedIntegerLiteral.Create(0)),
															CSharpModelFactoryHelper.CreateLesserExpression(
																	UnifiedVariable.Create("i"), UnifiedIntegerLiteral.Create(2)),
															CSharpModelFactoryHelper.CreateExpression(
																	UnifiedVariable.Create("i"),
																	UnifiedUnaryOperatorType.PostIncrementAssign),
															UnifiedBlock.Create(new[] {
																	UnifiedCall.Create(UnifiedVariable.Create("write"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(
																							UnifiedCall.Create(
																									UnifiedProperty.Create("getName", 
																										UnifiedIndexer.Create(UnifiedVariable.Create("students"), 
																											UnifiedArgumentCollection.Create(UnifiedArgument.Create(UnifiedVariable.Create("i"))))),
																										UnifiedArgumentCollection.Create()
																									)
																							)
																					)
																			)
															}
																	)
															),
													UnifiedForeach.Create(
															UnifiedVariableDefinition.Create(UnifiedType.Create("Student"),
																	"student"),
															UnifiedVariable.Create("students"),
															UnifiedBlock.Create(
																	UnifiedCall.Create(UnifiedVariable.Create("write"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(
																							UnifiedCall.Create(
																									UnifiedProperty.Create("getName", UnifiedVariable.Create("student")),
																										UnifiedArgumentCollection.Create())
																							)
																					)
																			)
																	)
															)
													)
											)
							}
									)
							)
					);
		}
	}
}
