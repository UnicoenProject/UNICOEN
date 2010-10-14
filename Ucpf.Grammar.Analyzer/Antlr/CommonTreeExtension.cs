using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Tree;

namespace Ucpf.Grammar.Analyzer.Antlr
{
	public static class CommonTreeExtension
	{
		public static IEnumerable<CommonTree> GetChildren(this CommonTree tree)
		{
			return tree.Children.Cast<CommonTree>();
		}
	}
}