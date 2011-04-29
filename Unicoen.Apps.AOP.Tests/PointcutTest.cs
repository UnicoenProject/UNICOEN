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
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   アスペクトが正しく織り込まれているかテストする。
	/// </summary>
	[TestFixture]
	internal class PointcutTest {
		private const string filePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Fibonacci.java";

		private string _ext;
		private string _code;
		private UnifiedProgram _model;

		[SetUp]
		public void Setup() {
			_ext = Path.GetExtension(filePath);
			_code = File.ReadAllText(filePath, XEncoding.SJIS);
			_model = Program.CreateModel(_ext, _code);
		}

		[Test]
		public void WeavingAtFunctionBeforeCorrectly() {
			var actual =
					JavaModelFactory.Instance.Generate(
							"public class Fibonacci { public static int fibonacci(int n) { { Console.Write(); } if (n < 2) { return n; } else { return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			CodeProcessor.InsertBeforeAllFunction(_model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(_model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtFunctionAfterCorrectly() {
			var actual =
					JavaModelFactory.Instance.Generate(
							"public class Fibonacci { public static int fibonacci(int n) { if (n < 2) { { Console.Write(); } return n; } else { { Console.Write(); } return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			CodeProcessor.InsertAfterAllFunction(_model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(_model.ToString(), Is.EqualTo(actual.ToString()));
		}
	}
}