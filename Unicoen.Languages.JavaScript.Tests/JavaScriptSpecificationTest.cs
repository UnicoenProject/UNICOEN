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

using NUnit.Framework;
using Unicoen.Core.Comparers;
using Unicoen.Core.Tests;
using Unicoen.Languages.JavaScript.Model;

namespace Unicoen.Languages.JavaScript.Tests {
	[TestFixture]
	public class JavaScriptSpecificationTest {
		[Ignore, Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var actual = JSModelFactory.CreateModel(fragment);

			Assert.That(
					actual,
					Is.EqualTo(CSharpAndJavaSpecificationTest.WhileModel)
							.Using(StructuralEqualityComparer.Instance));
		}
	}
}