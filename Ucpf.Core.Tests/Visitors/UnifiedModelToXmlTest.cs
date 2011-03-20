using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Core.Model;



using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Tests.Visitors {
	[TestFixture]
	public class UnifiedModelToXmlTest {
		private UnifiedModelToXml _toXml;

		private static UnifiedCall CreateCall(int? decrement) {
			return new UnifiedCall {
				Function = UnifiedVariable.Create("fibonacci"),
				Arguments = {
					decrement == null
						? UnifiedArgument.Create(UnifiedVariable.Create("n"))
						: UnifiedArgument.Create(new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("-", UnifiedBinaryOperatorType.Subtract),
							RightHandSide = UnifiedIntegerLiteral.Create((int)decrement),
						})
				},
			};
		}

		[SetUp]
		public void SetUp() {
			_toXml = new UnifiedModelToXml();
		}

		[Test]
		public void GenerateDefineFunction() {
			var a = new UnifiedImport() as UnifiedElement;
			var b = a.Normalize();

			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter { Name = "n" }
				},
				Body = new UnifiedBlock(),
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock/>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateReturn() {
			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter { Name = "n" }
				},
				Body = {
					new UnifiedReturn {
						Value = UnifiedVariable.Create("n")
					}
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedReturn>
			<UnifiedVariable Name = ""n"" />
		</UnifiedReturn>
	</UnifiedBlock>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFunctionCall() {
			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter { Name = "n" }
				},
				Body = {
					new UnifiedReturn {
						Value = CreateCall(null)
					}
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedReturn>
			<UnifiedCall>
				<UnifiedVariable Name = ""fibonacci"" />
				<UnifiedArgumentCollection>
					<UnifiedArgument>
						<UnifiedVariable Name = ""n"" />
					</UnifiedArgument>
				</UnifiedArgumentCollection>
			</UnifiedCall>
		</UnifiedReturn>
	</UnifiedBlock>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFunctionCall2() {
			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter { Name = "n" }
				},
				Body = {
					new UnifiedReturn {
						Value = new UnifiedBinaryExpression {
							LeftHandSide = CreateCall(1),
							Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
							RightHandSide = CreateCall(2),
						}
					}
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedReturn>
			<UnifiedBinaryExpression>
				<UnifiedCall>
					<UnifiedVariable Name=""fibonacci"" />
					<UnifiedArgumentCollection>
						<UnifiedArgument>
							<UnifiedBinaryExpression>
								<UnifiedVariable Name=""n"" />
								<UnifiedBinaryOperator Sign=""-"" Type=""Subtract"" />
								<UnifiedIntegerLiteral Value=""1"" />
							</UnifiedBinaryExpression>
						</UnifiedArgument>
					</UnifiedArgumentCollection>
				</UnifiedCall>
				<UnifiedBinaryOperator Sign = ""+"" Type = ""Add"" />
				<UnifiedCall>
					<UnifiedVariable Name=""fibonacci"" />
					<UnifiedArgumentCollection>
						<UnifiedArgument>
							<UnifiedBinaryExpression>
								<UnifiedVariable Name=""n"" />
								<UnifiedBinaryOperator Sign=""-"" Type=""Subtract"" />
								<UnifiedIntegerLiteral Value=""2"" />
							</UnifiedBinaryExpression>
						</UnifiedArgument>
					</UnifiedArgumentCollection>
				</UnifiedCall>
			</UnifiedBinaryExpression>
		</UnifiedReturn>
	</UnifiedBlock>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateIf() {
			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.LessThan),
							RightHandSide = UnifiedIntegerLiteral.Create(2),
						},
						TrueBlock = {
							new UnifiedReturn{ Value = UnifiedVariable.Create("n") }
						},
						FalseBlock = {
							new UnifiedReturn{ Value = UnifiedIntegerLiteral.Create(0) }
						},
					},
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedIf>
			<UnifiedBinaryExpression>
				<UnifiedVariable Name = ""n"" />
				<UnifiedBinaryOperator Sign = ""&lt;"" Type = ""LessThan"" />
				<UnifiedIntegerLiteral Value = ""2"" />
			</UnifiedBinaryExpression>
			<UnifiedBlock>
				<UnifiedReturn>
					<UnifiedVariable Name = ""n"" />
				</UnifiedReturn>
			</UnifiedBlock>
			<UnifiedBlock>
				<UnifiedReturn>
					<UnifiedIntegerLiteral Value = ""0"" />
				</UnifiedReturn>
			</UnifiedBlock>
		</UnifiedIf>
	</UnifiedBlock>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFibonacci() {
			var model = new UnifiedFunctionDefinition {
				Name = "fibonacci",
				Parameters = {
					new UnifiedParameter{ Name = "n" }
				},
				Body = {
					new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = UnifiedVariable.Create("n"),
							Operator = new UnifiedBinaryOperator("<", UnifiedBinaryOperatorType.LessThan),
							RightHandSide = UnifiedIntegerLiteral.Create(2),
						},
						TrueBlock = {
							new UnifiedReturn { Value = UnifiedVariable.Create("n") }
						},
						FalseBlock = {
							new UnifiedReturn {
								Value = new UnifiedBinaryExpression {
									LeftHandSide = CreateCall(1),
									Operator = new UnifiedBinaryOperator("+", UnifiedBinaryOperatorType.Add),
									RightHandSide = CreateCall(2),
								}
							}
						},
					},
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedFunctionDefinition Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedIf>
			<UnifiedBinaryExpression>
				<UnifiedVariable Name = ""n"" />
				<UnifiedBinaryOperator Sign = ""&lt;"" Type = ""LessThan"" />
				<UnifiedIntegerLiteral Value = ""2"" />
			</UnifiedBinaryExpression>
			<UnifiedBlock>
				<UnifiedReturn>
					<UnifiedVariable Name = ""n"" />
				</UnifiedReturn>
			</UnifiedBlock>
			<UnifiedBlock>
				<UnifiedReturn>
					<UnifiedBinaryExpression>
						<UnifiedCall>
							<UnifiedVariable Name=""fibonacci"" />
							<UnifiedArgumentCollection>
								<UnifiedArgument>
									<UnifiedBinaryExpression>
										<UnifiedVariable Name=""n"" />
										<UnifiedBinaryOperator Sign=""-"" Type=""Subtract"" />
										<UnifiedIntegerLiteral Value=""1"" />
									</UnifiedBinaryExpression>
								</UnifiedArgument>
							</UnifiedArgumentCollection>
						</UnifiedCall>
						<UnifiedBinaryOperator Sign = ""+"" Type = ""Add"" />
						<UnifiedCall>
							<UnifiedVariable Name=""fibonacci"" />
							<UnifiedArgumentCollection>
								<UnifiedArgument>
									<UnifiedBinaryExpression>
										<UnifiedVariable Name=""n"" />
										<UnifiedBinaryOperator Sign=""-"" Type=""Subtract"" />
										<UnifiedIntegerLiteral Value=""2"" />
									</UnifiedBinaryExpression>
								</UnifiedArgument>
							</UnifiedArgumentCollection>
						</UnifiedCall>
					</UnifiedBinaryExpression>
				</UnifiedReturn>
			</UnifiedBlock>
		</UnifiedIf>
	</UnifiedBlock>
</UnifiedFunctionDefinition>
");
			_toXml.Visit(model, null);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}
	}
}