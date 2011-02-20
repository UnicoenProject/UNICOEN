using System.Xml.Linq;
using NUnit.Framework;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.Visitors;

namespace Ucpf.Common.Tests.Visitors {
	[TestFixture]
	public class UnifiedModelToXmlTest {
		private UnifiedModelToXml _toXml;

		private static UnifiedCall CreateCall(int? decrement) {
			return new UnifiedCall {
				Function = new UnifiedVariable("fibonacci"),
				Arguments = new UnifiedArgumentCollection {
					decrement == null
						? (UnifiedArgument)new UnifiedVariable("n")
						: (UnifiedArgument)new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("-", BinaryOperatorType.Subtraction),
							RightHandSide = new UnifiedIntegerLiteral((int)decrement),
						}
				},
			};
		}

		[SetUp]
		public void SetUp() {
			_toXml = new UnifiedModelToXml();
		}

		[Test]
		public void GenerateDefineFunction() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock(),
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock/>
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateReturn() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(new UnifiedVariable("n")),
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedReturn>
			<UnifiedVariable Name = ""n"" />
		</UnifiedReturn>
	</UnifiedBlock>
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFunctionCall() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(CreateCall(null)),
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
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
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFunctionCall2() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedReturn(
						new UnifiedBinaryExpression {
							LeftHandSide = CreateCall(1),
							Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
							RightHandSide = CreateCall(2),
						})
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
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
								<UnifiedBinaryOperator Sign=""-"" Type=""Subtraction"" />
								<UnifiedIntegerLiteral TypedValue=""1"" />
							</UnifiedBinaryExpression>
						</UnifiedArgument>
					</UnifiedArgumentCollection>
				</UnifiedCall>
				<UnifiedBinaryOperator Sign = ""+"" Type = ""Addition"" />
				<UnifiedCall>
					<UnifiedVariable Name=""fibonacci"" />
					<UnifiedArgumentCollection>
						<UnifiedArgument>
							<UnifiedBinaryExpression>
								<UnifiedVariable Name=""n"" />
								<UnifiedBinaryOperator Sign=""-"" Type=""Subtraction"" />
								<UnifiedIntegerLiteral TypedValue=""2"" />
							</UnifiedBinaryExpression>
						</UnifiedArgument>
					</UnifiedArgumentCollection>
				</UnifiedCall>
			</UnifiedBinaryExpression>
		</UnifiedReturn>
	</UnifiedBlock>
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateIf() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedExpressionStatement(new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
							RightHandSide = new UnifiedIntegerLiteral(2),
						},
						TrueBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedVariable("n")),
						},
						FalseBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedIntegerLiteral(0)),
						},
					}),
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedExpressionStatement>
			<UnifiedIf>
				<UnifiedBinaryExpression>
					<UnifiedVariable Name = ""n"" />
					<UnifiedBinaryOperator Sign = ""&lt;"" Type = ""Lesser"" />
					<UnifiedIntegerLiteral TypedValue = ""2"" />
				</UnifiedBinaryExpression>
				<UnifiedBlock>
					<UnifiedReturn>
						<UnifiedVariable Name = ""n"" />
					</UnifiedReturn>
				</UnifiedBlock>
				<UnifiedBlock>
					<UnifiedReturn>
						<UnifiedIntegerLiteral TypedValue = ""0"" />
					</UnifiedReturn>
				</UnifiedBlock>
			</UnifiedIf>
		</UnifiedExpressionStatement>
	</UnifiedBlock>
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}

		[Test]
		public void GenerateFibonacci() {
			var model = new UnifiedDefineFunction {
				Name = "fibonacci",
				Parameters = new UnifiedParameterCollection {
					new UnifiedParameter("n"),
				},
				Block = new UnifiedBlock {
					new UnifiedExpressionStatement(new UnifiedIf {
						Condition = new UnifiedBinaryExpression {
							LeftHandSide = new UnifiedVariable("n"),
							Operator = new UnifiedBinaryOperator("<", BinaryOperatorType.Lesser),
							RightHandSide = new UnifiedIntegerLiteral(2),
						},
						TrueBlock = new UnifiedBlock {
							new UnifiedReturn(new UnifiedVariable("n")),
						},
						FalseBlock = new UnifiedBlock {
							new UnifiedReturn(
								new UnifiedBinaryExpression {
									LeftHandSide = CreateCall(1),
									Operator = new UnifiedBinaryOperator("+", BinaryOperatorType.Addition),
									RightHandSide = CreateCall(2),
								})
						},
					}),
				},
			};
			var expectation =
				XDocument.Parse(
					@"
<UnifiedDefineFunction Name = ""fibonacci"">
	<UnifiedParameterCollection>
		<UnifiedParameter Name = ""n"" />
	</UnifiedParameterCollection>
	<UnifiedBlock>
		<UnifiedExpressionStatement>
			<UnifiedIf>
				<UnifiedBinaryExpression>
					<UnifiedVariable Name = ""n"" />
					<UnifiedBinaryOperator Sign = ""&lt;"" Type = ""Lesser"" />
					<UnifiedIntegerLiteral TypedValue = ""2"" />
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
											<UnifiedBinaryOperator Sign=""-"" Type=""Subtraction"" />
											<UnifiedIntegerLiteral TypedValue=""1"" />
										</UnifiedBinaryExpression>
									</UnifiedArgument>
								</UnifiedArgumentCollection>
							</UnifiedCall>
							<UnifiedBinaryOperator Sign = ""+"" Type = ""Addition"" />
							<UnifiedCall>
								<UnifiedVariable Name=""fibonacci"" />
								<UnifiedArgumentCollection>
									<UnifiedArgument>
										<UnifiedBinaryExpression>
											<UnifiedVariable Name=""n"" />
											<UnifiedBinaryOperator Sign=""-"" Type=""Subtraction"" />
											<UnifiedIntegerLiteral TypedValue=""2"" />
										</UnifiedBinaryExpression>
									</UnifiedArgument>
								</UnifiedArgumentCollection>
							</UnifiedCall>
						</UnifiedBinaryExpression>
					</UnifiedReturn>
				</UnifiedBlock>
			</UnifiedIf>
		</UnifiedExpressionStatement>
	</UnifiedBlock>
</UnifiedDefineFunction>
");
			_toXml.Visit(model);
			Assert.That(_toXml.Result.ToString(), Is.EqualTo(expectation.ToString()));
		}
	}
}