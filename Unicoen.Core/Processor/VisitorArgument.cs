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

using System.Diagnostics;

namespace Unicoen.Core.Processor {
	public class VisitorArgument {
		public int IndentDepth { get; private set; }
		public Decoration Decoration { get; private set; }

		[DebuggerStepThrough]
		public VisitorArgument() {
			Decoration = new Decoration();
		}

		[DebuggerStepThrough]
		public VisitorArgument Set(Decoration decoration) {
			return new VisitorArgument {
					Decoration = decoration,
					IndentDepth = IndentDepth,
			};
		}

		[DebuggerStepThrough]
		public VisitorArgument IncrementDepth() {
			return new VisitorArgument {
					Decoration = Decoration,
					IndentDepth = IndentDepth + 1,
			};
		}

		[DebuggerStepThrough]
		public VisitorArgument DecrementDepth() {
			return new VisitorArgument {
					Decoration = Decoration,
					IndentDepth = IndentDepth - 1,
			};
		}
	}
}