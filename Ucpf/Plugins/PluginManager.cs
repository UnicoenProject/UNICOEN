using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Paraiba.Linq;
using Ucpf.AstGenerators;
using Ucpf.CodeGenerators;

namespace Ucpf.Plugins
{
	public class PluginManager
	{
		private static PluginManager _instance;

		[ImportMany]
		private IEnumerable<IAstGenerator> _astGenerators = null;

		[ImportMany]
		private IEnumerable<ICodeGenerator> _codeGenerators = null;

		private static PluginManager Instance
		{
			get { return _instance ?? (_instance = new PluginManager()); }
		}

		public static IEnumerable<IAstGenerator> AstGenerators
		{
			get {
				return Instance._astGenerators
					.OrderBy(a => a.ParserName);
			}
		}

		public static IEnumerable<ICodeGenerator> CodeGenerators
		{
			get
			{
				return Instance._codeGenerators
					.OrderBy(c => c.ParserName);
			}
		}

		public static IAstGenerator GetAstGeneratorByName(string name)
		{
			var lowerName = name.ToLower();
			return AstGenerators
				.Where(ast => ast.ParserName.ToLower().Contains(lowerName))
				.MinElementOrDefault(ast => Math.Abs(ast.ParserName.Length - name.Length));
		}

		public static IAstGenerator GetAstGeneratorByExtension(string ext)
		{
			var lowerExt = ext.ToLower();
			return AstGenerators
				.FirstOrDefault(ast => ast.TargetExtensions
					.Select(e => e.ToLower())
					.Contains(lowerExt));
		}

		public static ICodeGenerator GetCodeGeneratorByName(string name)
		{
			var lowerName = name.ToLower();
			return CodeGenerators
				.Where(code => code.ParserName.ToLower().Contains(lowerName))
				.MinElementOrDefault(code => Math.Abs(code.ParserName.Length - name.Length));
		}

		public static ICodeGenerator GetCodeGeneratorByExtension(string ext)
		{
			var lowerExt = ext.ToLower();
			return CodeGenerators
				.FirstOrDefault(ast => ast.DefaultExtension.ToLower() == lowerExt);
		}

		private PluginManager()
		{
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			//catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}
	}
}
