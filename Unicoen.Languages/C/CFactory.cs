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

using Unicoen.Model;
using Unicoen.Languages.C.CodeFactories;
using Unicoen.Languages.C.ModelFactories;

namespace Unicoen.Languages.C {
	public static class CFactory {
		public static readonly CCodeFactory CodeFactory;
		public static readonly CModelFactory ModelFactory;

		static CFactory() {
			CodeFactory = new CCodeFactory();
			ModelFactory = new CModelFactory();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ModelFactory.Generate(code);
		}
	}
}