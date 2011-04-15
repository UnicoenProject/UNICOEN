﻿using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Tests;

namespace Ucpf.Languages.CSharp.Tests {
	[Ignore, TestFixture]
	public class CSharpStudentTest {
		private readonly string _source;

		public CSharpStudentTest() {
			var path = Fixture.GetInputPath("CSharp", "student.cs");
			_source = File.ReadAllText(path, XEncoding.SJIS);
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
							UnifiedBlock.Create(
									UnifiedVariableDefinition.CreateSingle(
											UnifiedType.CreateUsingString("String"),
											"_name",
											UnifiedModifierCollection.Create(UnifiedModifier.Create("private"))
											),
									UnifiedConstructorDefinition.Create(
											UnifiedBlock.Create(
													CSharpModelFactoryHelper.CreateAssignExpression(
															UnifiedIdentifier.CreateUnknown("_name"),
															UnifiedIdentifier.CreateUnknown("name"))
													),
											UnifiedModifier.Create("public"),
											UnifiedParameterCollection.Create(
													UnifiedParameter.Create(
															"name", UnifiedType.CreateUsingString("String"))
													)
											),
									UnifiedFunctionDefinition.CreateFunction(UnifiedModifierCollection.Create(
											UnifiedModifier.Create("public")
											),
											UnifiedType.CreateUsingString("String"),
											"getName", UnifiedParameterCollection.Create(), null, UnifiedBlock.Create(
													UnifiedSpecialExpression.CreateReturn(
															UnifiedIdentifier.CreateUnknown("_name"))
													)),
									UnifiedFunctionDefinition.CreateFunction(UnifiedModifierCollection.Create(
											UnifiedModifier.Create("public"),
											UnifiedModifier.Create("static")
											),
											UnifiedType.CreateUsingString("void"),
											"main", UnifiedParameterCollection.Create(
													UnifiedParameter.Create("args", UnifiedType.CreateArray("String"))
													), UnifiedBlock.Create(
															UnifiedVariableDefinition.CreateSingle(
																	UnifiedType.CreateArray("Student"),
																	"students",
																	UnifiedNew.CreateArray("Student",
																			UnifiedIntegerLiteral.Create(2).ToArgument())
																	),
															CSharpModelFactoryHelper.CreateAssignExpression(
																	UnifiedIndexer.Create(
																			UnifiedIdentifier.CreateUnknown("students"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(UnifiedIntegerLiteral.Create(0)))),
																	UnifiedNew.Create(UnifiedType.CreateUsingString("Student"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(UnifiedStringLiteral.Create("Tom"))))
																	),
															CSharpModelFactoryHelper.CreateAssignExpression(
																	UnifiedIndexer.Create(
																			UnifiedIdentifier.CreateUnknown("students"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(UnifiedIntegerLiteral.Create(1)))),
																	UnifiedNew.Create(UnifiedType.CreateUsingString("Student"),
																			UnifiedArgumentCollection.Create(
																					UnifiedArgument.Create(UnifiedStringLiteral.Create("Anna"))))
																	),
															UnifiedFor.Create(
																	UnifiedVariableDefinition.CreateSingle(
																			UnifiedType.CreateUsingString("int"), "i",
																			UnifiedIntegerLiteral.Create(0)),
																	CSharpModelFactoryHelper.CreateLesserExpression(
																			UnifiedIdentifier.CreateUnknown("i"),
																			UnifiedIntegerLiteral.Create(2)),
																	CSharpModelFactoryHelper.CreateExpression(
																			UnifiedIdentifier.CreateUnknown("i"),
																			UnifiedUnaryOperatorKind.PostIncrementAssign),
																	UnifiedBlock.Create(new[] {
																			UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("write"),
																					UnifiedArgumentCollection.Create(
																							UnifiedArgument.Create(
																									UnifiedCall.Create(
																											UnifiedProperty.Create(
																													UnifiedIndexer.Create(
																															UnifiedIdentifier.CreateUnknown("students"),
																															UnifiedArgumentCollection.Create(
																																	UnifiedArgument.Create(
																																			UnifiedIdentifier.CreateUnknown("i")))),
																													"getName", "."),
																											UnifiedArgumentCollection.Create()
																											)
																									)
																							)
																					)
																	}
																			)
																	),
															UnifiedForeach.Create(
																	UnifiedVariableDefinition.CreateSingle(
																			UnifiedType.CreateUsingString("Student"),
																			"student"),
																	UnifiedIdentifier.CreateUnknown("students"),
																	UnifiedBlock.Create(
																			UnifiedCall.Create(UnifiedIdentifier.CreateUnknown("write"),
																					UnifiedArgumentCollection.Create(
																							UnifiedArgument.Create(
																									UnifiedCall.Create(
																											UnifiedProperty.Create(
																													UnifiedIdentifier.CreateUnknown("student"), "getName",
																													"."),
																											UnifiedArgumentCollection.Create())
																									)
																							)
																					)
																			)
																	)
															))
									)
							)
					);
		}
	}
}