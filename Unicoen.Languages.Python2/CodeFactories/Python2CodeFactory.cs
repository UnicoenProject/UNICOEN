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
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;

namespace Unicoen.Languages.Python2.CodeFactories {
	public class Python2CodeFactory : CodeFactory {
		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			throw new NotImplementedException();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			throw new NotImplementedException();
		}
	}
}