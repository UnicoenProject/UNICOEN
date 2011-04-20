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
using Unicoen.Core.Tests;
using Unicoen.Languages.CSharp.Tests;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests {
	[Ignore, TestFixture]
	public class JavaStudentTest {
		private readonly string _source;

		public JavaStudentTest() {
			var path = Fixture.GetInputPath("Java", "Student.java");
			_source = File.ReadAllText(path, XEncoding.SJIS);
		}

		[Test]
		public void CreateClassDefinition() {
			var expected = CSharpStudentTest.CreateModel();

			var actual = JavaModelFactoryHelper.CreateModel(_source);
			Assert.That(
					actual,
					Is.EqualTo(expected).Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}