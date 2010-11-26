using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Paraiba.Linq;
using Ucpf.AstGenerators;
using Ucpf.CodeGenerators;

namespace Ucpf.Plugins {
	public class PluginManager {
		private static PluginManager _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<AstGenerator> _astGenerators;
#pragma warning restore 649

#pragma warning disable 649
		[ImportMany] private IEnumerable<CodeGenerator> _codeGenerators;
#pragma warning restore 649

		private PluginManager() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			//catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		private static PluginManager Instance {
			get { return _instance ?? (_instance = new PluginManager()); }
		}

		public static IEnumerable<AstGenerator> AstGenerators {
			get {
				return Instance._astGenerators
					.OrderBy(a => a.ParserName);
			}
		}

		public static IEnumerable<CodeGenerator> CodeGenerators {
			get {
				return Instance._codeGenerators
					.OrderBy(c => c.ParserName);
			}
		}

		public static AstGenerator GetAstGeneratorByName(string name) {
			var lowerName = name.ToLower();
			return AstGenerators
				.Where(ast => ast.ParserName.ToLower().Contains(lowerName))
				.MinElementOrDefault(ast => Math.Abs(ast.ParserName.Length - name.Length));
		}

		public static AstGenerator GetAstGeneratorByExtension(string ext) {
			var lowerExt = ext.ToLower();
			return AstGenerators
				.FirstOrDefault(ast => ast.TargetExtensions
				                       	.Select(e => e.ToLower())
				                       	.Contains(lowerExt));
		}

		public static CodeGenerator GetCodeGeneratorByName(string name) {
			var lowerName = name.ToLower();
			return CodeGenerators
				.Where(code => code.ParserName.ToLower().Contains(lowerName))
				.MinElementOrDefault(code => Math.Abs(code.ParserName.Length - name.Length));
		}

		public static CodeGenerator GetCodeGeneratorByExtension(string ext) {
			var lowerExt = ext.ToLower();
			return CodeGenerators
				.FirstOrDefault(ast => ast.DefaultExtension.ToLower() == lowerExt);
		}
	}
}