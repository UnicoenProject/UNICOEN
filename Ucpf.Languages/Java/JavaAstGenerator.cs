using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;
using Ucpf.Languages.Common.Antlr;
using Ucpf.Weavers;

namespace Ucpf.Languages.Java
{
	[Export(typeof(IAstGenerator))]
	public class JavaAstGenerator : AntlrAstGenerator<JavaParser>
	{
		private static JavaAstGenerator _instance;
		public static JavaAstGenerator Instance
		{
			get { return _instance ?? (_instance = new JavaAstGenerator()); }
		}

		private JavaAstGenerator() { }

		protected override Func<JavaParser, XParserRuleReturnScope> DefaultParseFunc
		{
			get { return parser => parser.compilationUnit(); }
		}

		public override string ParserName
		{
			get { return GlobalInformation.JavaLanguage; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.JavaExtensions; }
		}

		protected override void ArrangeAst(XElement ast)
		{
			var nodes = GetLackingBlockNodes(ast);
			Weaver.SafeWeaveAround(nodes,
				node => AntlrBlockGenerator.Generate(node, this));
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new JavaLexer(stream);
		}

		protected override JavaParser CreateParser(ITokenStream tokenStream)
		{
			var ret = new JavaParser(tokenStream);
			ret.LeaveElementName = "LEAVE";
			return ret;
		}

		private static IEnumerable<XElement> GetLackingBlockNodes(XElement root)
		{
			var ifs = JavaElements.If(root)
				.SelectMany(JavaElements.IfAndElseProcesses);
			var whiles = JavaElements.While(root)
				.Select(JavaElements.WhileProcess);
			var dos = JavaElements.DoWhile(root)
				.Select(JavaElements.DoWhileProcess);
			var fors = JavaElements.For(root)
				.Select(JavaElements.ForProcess);

			return ifs.Concat(whiles)
				.Concat(dos)
				.Concat(fors);
		}
	}
}


