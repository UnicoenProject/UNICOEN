﻿#region License

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
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.CSharp.Tests {
	[Ignore, TestFixture]
	public class CSharpRegenerateTest : RegenerateTest {
		private readonly Fixture _fixture = new CSharpFixture();

		protected override Fixture Fixture {
			get { return _fixture; }
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareCompiledCodeOfSameCode(string orgPath) {
			base.CompareCompiledCodeOfSameCode(orgPath);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareModelOfSameCode(string orgPath) {
			base.CompareModelOfSameCode(orgPath);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void CompareCompiledCodeUsingCode(string code) {
			base.CompareCompiledCodeUsingCode(code);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void CompareModelUsingCode(string code) {
			base.CompareModelUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareCompiledCodeUsingFile(string orgPath) {
			base.CompareCompiledCodeUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void CompareModelUsingFile(string orgPath) {
			base.CompareModelUsingFile(orgPath);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareCompiledCodeUsingDirectory(string orgPath, string command, string arguments) {
			base.CompareCompiledCodeUsingDirectory(orgPath, command, arguments);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void CompareModelUsingDirectory(string orgPath, string command, string arguments) {
			base.CompareModelUsingDirectory(orgPath, command, arguments);
		}
	}
}