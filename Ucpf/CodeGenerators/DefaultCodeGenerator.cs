using System;
using System.Xml.Linq;

namespace Ucpf.CodeGenerators
{
	public class DefaultCodeGenerator : CodeGenerator
	{
		private static DefaultCodeGenerator _instance;

		public static DefaultCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new DefaultCodeGenerator()); }
		}

		public override string ParserName
		{
			get { throw new NotImplementedException(); }
		}

		public override string DefaultExtension
		{
			get { throw new NotImplementedException(); }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
			return false;
		}
	}
}