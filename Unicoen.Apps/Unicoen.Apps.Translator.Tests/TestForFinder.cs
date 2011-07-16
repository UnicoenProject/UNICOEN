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
using System.Text;
using NUnit.Framework;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Languages.Java;

namespace Unicoen.Apps.Translator.Tests {
	public class TestForFinder {
		private UnifiedProgram _program;

		[SetUp]
		public void SetUp() {
			var filePath = FixtureUtil.GetInputPath("Java", "default", "Student.java");
			var code = File.ReadAllText(filePath, Encoding.Default);
			_program = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void 関数をすべて取得できる() {
			var functions =
					Finder.GetAllElements<UnifiedFunctionDefinition>(_program);
			Assert.That(functions.Count, Is.EqualTo(3));
		}
	}
}