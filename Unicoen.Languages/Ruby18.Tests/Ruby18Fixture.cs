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
using System.Collections.Generic;
using NUnit.Framework;
using Unicoen.Core.Processor;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.Ruby18.Tests {
	public class Ruby18Fixture : Fixture {
		public override string Extension {
			get { return ".rb"; }
		}

		public override string CompiledExtension {
			get { throw new NotImplementedException(); }
		}

		public override ModelFactory ModelFactory {
			get { throw new NotImplementedException(); }
		}

		public override ICodeFactory CodeFactory {
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<TestCaseData> TestCodes {
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<TestCaseData> TestFilePathes {
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<TestCaseData> TestProjectInfos {
			get { throw new NotImplementedException(); }
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { throw new NotImplementedException(); }
		}

		public override void Compile(string workPath, string srcPath) {
			throw new NotImplementedException();
		}

		public override void CompileWithArguments(
				string workPath, string command, string arguments) {
			throw new NotImplementedException();
		}
	}
}