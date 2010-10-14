﻿using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace OpenCodeProcessorFramework.Languages.Python3
{
	[Export(typeof(ICodeGenerator))]
	public class Python3CodeGenerator : CodeGenerator
	{
		private static Python3CodeGenerator _instance;
		public static Python3CodeGenerator Instance
		{
			get { return _instance ?? (_instance = new Python3CodeGenerator()); }
		}

		private Python3CodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.Python3Language; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.Python3Extensions[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
			switch (element.Name.LocalName) {
			case "NEWLINE":
				WriteLine();
				break;

			case "INDENT":
				Depth++;
				break;

			case "DEDENT":
				Depth--;
				break;

			default:
				return false;
			}

			return true;
		}
	}
}


