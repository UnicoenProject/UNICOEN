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

using System;
using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Languages.Java.Tests.CodeGeneraotr {
	[Ignore, TestFixture]
	public class JavaCodeGeneratorTestForTest {
		private string _source;
		private UnifiedProgram _program;
		private string _generated;

		[SetUp]
		public void SetUp() {
			var path = Fixture.GetInputPath("Java", "Student.java");
			_source = File.ReadAllText(path, XEncoding.SJIS);
			_program = JavaModelFactoryHelper.CreateModel(_source);
			_generated = JavaCodeGenerator.Instance.Generate(_program);
		}

		[Test]
		public void TestTest() {
			Console.Write(_generated);
		}
	}
}