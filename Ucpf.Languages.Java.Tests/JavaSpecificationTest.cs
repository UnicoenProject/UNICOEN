using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests
{
	[TestFixture]
	public class JavaSpecificationTest
	{
		public static UnifiedProgram AnonymousClassModel
		{
			get
			{
				return CSharpAndJavaSpecificationTest.
					CreateClassAndMethod(UnifiedBlock.Create(
						UnifiedNew.Create(
							UnifiedType.Create("Interface"),
							UnifiedArgumentCollection.Create(),
							UnifiedBlock.Create()
							)));
			}
		}

		public static UnifiedProgram ThrowsModel
		{
			get
			{
				return UnifiedProgram.Create(
					"A".ToClassDefinition()
						.AddToBody(
							UnifiedFunctionDefinition.Create(
								"M1",
								"void".ToType(),
								UnifiedModifierCollection.Create(),
								UnifiedParameterCollection.Create(),
								UnifiedTypeCollection.Create(
									UnifiedType.Create("Exception")),
								UnifiedBlock.Create()
								)
						)
					);
			}
		}

		[Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.WhileModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("do return; while(true);")]
		[TestCase("do { return; } while(true);")]
		[TestCase("do { { return; } } while(true);")]
		public void CreateDoWhile(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.DoWhileModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("for (int i = 0; i < 1; i++) break;")]
		[TestCase("for (int i = 0; i < 1; i++) { break; }")]
		[TestCase("for (int i = 0; i < 1; i++) { { break; } }")]
		public void CreateFor(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.ForModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("for (int i : new int[] { 1 }) continue;")]
		[TestCase("for (int i : new int[] { 1 }) { continue; }")]
		[TestCase("for (int i : new int[] { 1 }) { { continue; } }")]
		public void CreateForeach(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.ForeachModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("if (true) return -1;")]
		[TestCase("if (true) { return -1; }")]
		[TestCase("if (true) { { return -1; } }")]
		[TestCase("if (true) { { { return -1; } } }")]
		public void CreateIf(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.IfModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("if (false) return -1; else return 0.1;")]
		[TestCase("if (false) { return -1; } else return 0.1;")]
		[TestCase("if (false) return -1; else { return 0.1; }")]
		[TestCase("if (false) { return -1; } else { return 0.1; }")]
		[TestCase("if (false) { { return -1; } } else { return 0.1; }")]
		[TestCase("if (false) { return -1; } else { { return 0.1; } }")]
		[TestCase("if (false) { { return -1; } } else { { return 0.1; } }")]
		[TestCase("if (false) { { { return -1; } } } else { { return 0.1; } }")]
		[TestCase("if (false) { { return -1; } } else { { { return 0.1; } } }")]
		[TestCase("if (false) return -1; else { { { return 0.1; } } }")]
		[TestCase("if (false) { { { return -1; } } } else return 0.1;")]
		[TestCase("if (false) { { { return -1; } } } else { { { return 0.1; } } }")]
		public void CreateIfElse(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.IfElseModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("new List<List<int>>();")]
		public void CreateNewGenericType(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.NewGenericTypeModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("int a = +1;")]
		public void CreatePlusIntegerLiteral(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.PlusIntegerLiteralModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("switch (1) { case 1: break; }")]
		public void CreateSwitchCase(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SwitchCaseModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("switch (1) { case 1: break; default: break; }")]
		public void CreateSwitchCaseWithDefault(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SwitchCaseWithDefaultModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("Integer i = (Integer)1;")]
		public void CreateCast(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.CastModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("synchronized (this) { M1(); }")]
		public void CreateSynchronized(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SynchronizedModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("throw new Exception();")]
		public void CreateThrow(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.ThrowModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("new Interface() { };")]
		public void CreateAnonymousClass(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(AnonymousClassModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("try { int i = 0; } catch(Exception e) { }")]
		public void CreateTryCatchWithVariable(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.TryCatchWithVariableModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("try { int i = 0; } catch(Exception e) { } catch(Exception e) { }")]
		public void CreateTryTwoCatchWithVariable(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.TryCatchWithTwoVariableModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("try { int i = 0; } finally { }")]
		public void CreateTryFinally(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.TryFinallyModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("try { int i = 0; } catch(Exception e) { } finally { }")]
		public void CreateTryCatchFinally(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.TryCatchFinallyModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		public void CreateThrows(string fragment)
		{
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual =
				JavaModelFactory.CreateModel("class A { void M1() throws Exception { } }");
			Assert.That(actual,
				Is.EqualTo(ThrowsModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}