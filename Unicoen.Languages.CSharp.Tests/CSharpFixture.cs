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

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	public static class CSharpFixture {
		public static IEnumerable<TestCaseData> TestStatements {
			get {
				return new[] {
						"{ M1(); }",
				}.Select(s => new TestCaseData(CreateCode(s)));
			}
		}

		public static IEnumerable<TestCaseData> TestCodes {
			get {
				return new[] {
						"class A { }",
				}.Select(s => new TestCaseData(s));
			}
		}

		public static IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						//"Block1.cs",
						//"Block2.cs",
						//"Block3.cs",
						"Fibonacci.cs",
						//"Student.cs",
				}
						.Select(s => new TestCaseData(Fixture.GetInputPath("CSharp", s)));
				//return Directory.EnumerateFiles(GetInputPath("CSharp"))
				//        .Select(path => new TestCaseData(path));
			}
		}

		private static string CreateCode(string statement) {
			return "class A { public void M1() {" + statement + "} }";
		}
	}
}