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

namespace Unicoen.Languages.Java.Tests {
	[TestFixture]
	public class JavaModelFeatureTest : ModelFeatureTest {
		private readonly Fixture _fixture = new JavaFixture();

		protected override Fixture Fixture {
			get { return _fixture; }
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyDeepCopyUsingCode(string code) {
			base.VerifyDeepCopyUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyDeepCopyUsingFile(string path) {
			base.VerifyDeepCopyUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyDeepCopyUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyDeepCopyUsingDirectory(dirPath, command, arguments);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementsUsingCode(string code) {
			base.VerifyGetElementsUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementsUsingFile(string path) {
			base.VerifyGetElementsUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementsUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyGetElementsUsingDirectory(dirPath, command, arguments);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndSettersUsingCode(string code) {
			base.VerifyGetElementAndSettersUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndSettersUsingFile(string path) {
			base.VerifyGetElementAndSettersUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndSettersUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyGetElementAndSettersUsingDirectory(dirPath, command, arguments);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyGetElementAndDirectSettersUsingCode(string code) {
			base.VerifyGetElementAndDirectSettersUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyGetElementAndDirectSettersUsingFile(string path) {
			base.VerifyGetElementAndDirectSettersUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyGetElementAndDirectSettersUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyGetElementAndDirectSettersUsingDirectory(dirPath, command, arguments);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyParentPropertyUsingCode(string code) {
			base.VerifyParentPropertyUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyParentPropertyUsingFile(string path) {
			base.VerifyParentPropertyUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyParentPropertyUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyParentPropertyUsingDirectory(dirPath, command, arguments);
		}

		[Test, TestCaseSource("TestCodes")]
		public override void VerifyToStringUsingCode(string code) {
			base.VerifyToStringUsingCode(code);
		}

		[Test, TestCaseSource("TestFilePathes")]
		public override void VerifyToStringUsingFile(string path) {
			base.VerifyToStringUsingFile(path);
		}

		[Test, TestCaseSource("TestDirectoryPathes")]
		public override void VerifyToStringUsingDirectory(string dirPath, string command, string arguments) {
			base.VerifyToStringUsingDirectory(dirPath, command, arguments);
		}
	}
}