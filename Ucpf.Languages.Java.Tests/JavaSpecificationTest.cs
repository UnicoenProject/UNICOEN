﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Languages.CSharp.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaSpecificationTest {
		private static string CreateCode(string fragment) {
			return "class A { void M1() {" + fragment + "} }";
		}

		[Ignore, Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.WhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("do return; while(true);")]
		[TestCase("do { return; } while(true);")]
		[TestCase("do { { return; } } while(true);")]
		public void CreateDoWhile(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.DoWhileModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("for (int i = 0; i < 1; i++) break;")]
		[TestCase("for (int i = 0; i < 1; i++) { break; }")]
		[TestCase("for (int i = 0; i < 1; i++) { { break; } }")]
		public void CreateFor(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.ForModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("for (int i : new int[] { 1 }) continue;")]
		[TestCase("for (int i : new int[] { 1 }) { continue; }")]
		[TestCase("for (int i : new int[] { 1 }) { { continue; } }")]
		public void CreateForeach(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.ForeachModel).Using(StructuralEqualityComparer.Instance));
		}

		[Test]
		[TestCase("if (true) return -1;")]
		//[TestCase("if (true) { return -1; }")]
		//[TestCase("if (true) { { return -1; } }")]
		//[TestCase("if (true) { { { return -1; } } }")]
		public void CreateIf(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.IfModel).Using(StructuralEqualityComparer.Instance));
		}

		[Ignore, Test]
		[TestCase("if (true) return -1; else return 0.1;")]
		[TestCase("if (true) { return -1; } else return 0.1;")]
		[TestCase("if (true) return -1; else { return 0.1; }")]
		[TestCase("if (true) { return -1; } else { return 0.1; }")]
		[TestCase("if (true) { { return -1; } } else { return 0.1; }")]
		[TestCase("if (true) { return -1; } else { { return 0.1; } }")]
		[TestCase("if (true) { { return -1; } } else { { return 0.1; } }")]
		[TestCase("if (true) { { { return -1; } } } else { { return 0.1; } }")]
		[TestCase("if (true) { { return -1; } } else { { { return 0.1; } } }")]
		[TestCase("if (true) return -1; else { { { return 0.1; } } }")]
		[TestCase("if (true) { { { return -1; } } } else return 0.1;")]
		[TestCase("if (true) { { { return -1; } } } else { { { return 0.1; } } }")]
		public void CreateIfElse(string fragment) {
			var code = CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpSpecificationTest.IfElseModel).Using(StructuralEqualityComparer.Instance));
		}
	}
}
