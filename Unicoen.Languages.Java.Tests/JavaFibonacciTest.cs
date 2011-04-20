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
using Code2Xml.Languages.Java.XmlGenerators;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.CSharp.Tests;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	[Ignore, TestFixture]
	public class JavaFibonacciTest {
		private static readonly string Code =
				File.ReadAllText(
						Fixture.GetInputPath("Java", "Fibonacci.java"), XEncoding.SJIS);

		[Test]
		public void CreateDefineFunction() {
			var ast =
					JavaXmlGenerator.Instance.Generate(
							"public static int fibonacci(int n){}",
							p => p.methodDeclaration());
			var actual = JavaModelFactoryHelper.CreateMethodDeclaration(ast);
			var expectation =
					UnifiedFunctionDefinition.CreateFunction(
							UnifiedModifierCollection.Create(
									UnifiedModifier.Create("public"),
									UnifiedModifier.Create("static")
									),
							UnifiedType.CreateUsingString("int"), "fibonacci",
							UnifiedParameterCollection.Create(
									UnifiedParameter.Create("n", UnifiedType.CreateUsingString("int"))
									));
			Assert.That(
					actual,
					Is.EqualTo(expectation).Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		public void CreateFibonacci() {
			var actual = JavaModelFactoryHelper.CreateModel(Code);
			var expected = CSharpFibonacciTest.Model;
			Assert.That(
					actual,
					Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}