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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Paraiba.Linq;
using Unicoen.CodeGenerators;
using Unicoen.Model;
using Unicoen.ProgramGeneratos;

namespace Unicoen {
	public class UniGenerators {
		private static UniGenerators _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<UnifiedProgramGenerator> _programGenerators;
		[ImportMany] private IEnumerable<UnifiedCodeGenerator> _codeGenerators;
#pragma warning restore 649

		private UniGenerators() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			//catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		private static UniGenerators Instance {
			get { return _instance ?? (_instance = new UniGenerators()); }
		}

		public static IEnumerable<UnifiedProgramGenerator> ProgramGenerators {
			get { return Instance._programGenerators; }
		}

		public static IEnumerable<UnifiedCodeGenerator> CodeGenerators {
			get { return Instance._codeGenerators; }
		}

		public static UnifiedProgram GenerateProgramFromFile(string filePath) {
			var extension = Path.GetExtension(filePath);
			var progGen = GetProgramGeneratorByExtension(extension);
			return progGen.GenerateFromFile(filePath);
		}

		public static UnifiedProgram GenerateProgramFromFileOrDefault(string filePath) {
			var extension = Path.GetExtension(filePath);
			var progGen = GetProgramGeneratorByExtension(extension);
			try {
				return progGen.GenerateFromFile(filePath);
			} catch {
				return null;
			}
		}

		public static UnifiedProgramGenerator GetProgramGeneratorByName(string name) {
			var lowerName = name.ToLower();
			return ProgramGenerators
					.Where(gen => gen.GetType().Name.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							gen => Math.Abs(gen.GetType().Name.Length - name.Length));
		}

		public static UnifiedProgramGenerator GetProgramGeneratorByExtension(string ext) {
			var lowerExt = NormalizeExtension(ext);
			return ProgramGenerators
					.FirstOrDefault(
							gen => gen.Extensions
							       		.Select(e => e.ToLower())
							       		.Contains(lowerExt));
		}

		public static UnifiedCodeGenerator GetCodeGeneratorByName(string name) {
			var lowerName = name.ToLower();
			return CodeGenerators
					.Where(gen => gen.GetType().Name.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							gen => Math.Abs(gen.GetType().Name.Length - name.Length));
		}

		public static UnifiedCodeGenerator GetCodeGeneratorByExtension(string ext) {
			var lowerExt = NormalizeExtension(ext);
			return CodeGenerators
					.FirstOrDefault(gen => gen.Extension.ToLower() == lowerExt);
		}

		private static string NormalizeExtension(string ext) {
			var lowerExt = ext.ToLower();
			if (!lowerExt.StartsWith(".")) {
				lowerExt = "." + lowerExt;
			}
			return lowerExt;
		}
	}
}