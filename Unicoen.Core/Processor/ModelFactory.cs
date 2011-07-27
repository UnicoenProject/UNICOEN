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
using System.IO;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Processor {
	public abstract class ModelFactory {
		public abstract IEnumerable<string> Extensions { get; }

		public abstract UnifiedProgram GenerateWithouNormalizing(string code);

		public virtual UnifiedProgram GenerateFromFile(string filePath) {
			var code = File.ReadAllText(filePath, Encoding.Default);
			return Generate(code);
		}

		public UnifiedProgram Generate(string code) {
			if (string.IsNullOrWhiteSpace(code))
				return UnifiedProgram.Create(UnifiedBlock.Create());
			var model = GenerateWithouNormalizing(code);
			model.Normalize();
			return model;
		}
	}
}