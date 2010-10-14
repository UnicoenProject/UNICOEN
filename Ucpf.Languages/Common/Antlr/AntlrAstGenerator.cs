using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;

namespace OpenCodeProcessorFramework.Languages.Common.Antlr
{
	public abstract class AntlrAstGenerator<TParser> : IAstGenerator
	{
		protected abstract Func<TParser, XParserRuleReturnScope> DefaultParseFunc { get; }
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		protected virtual void ArrangeAst(XElement root) { }

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		public XElement Generate(ICharStream stream, Func<TParser, XParserRuleReturnScope> parseFunc, bool ignoreArrange = false)
		{
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);

			// launch parsing
			var ast = parseFunc(parser).Element;
			if (!ignoreArrange) {
				ArrangeAst(ast);
			}
			return ast;
		}

		public XElement Generate(ICharStream stream, string nodeName, bool ignoreArrange = false)
		{
			return Generate(stream, p => (XParserRuleReturnScope)p.GetType().GetMethod(nodeName).Invoke(p, null), ignoreArrange);
		}

		public XElement Generate(TextReader reader, string nodeName, bool ignoreArrange = false)
		{
			return Generate(new ANTLRReaderStream(reader), nodeName, ignoreArrange);
		}

		public XElement Generate(Stream stream, string nodeName, bool ignoreArrange = false)
		{
			return Generate(new ANTLRInputStream(stream), nodeName, ignoreArrange);
		}

		public XElement Generate(string text, string nodeName, bool ignoreArrange = false)
		{
			return Generate(new ANTLRStringStream(text), nodeName, ignoreArrange);
		}

		public XElement Generate(TextReader reader, Func<TParser, XParserRuleReturnScope> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRReaderStream(reader), parseAction, ignoreArrange);
		}

		public XElement Generate(Stream stream, Func<TParser, XParserRuleReturnScope> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRInputStream(stream), parseAction, ignoreArrange);
		}

		public XElement Generate(string text, Func<TParser, XParserRuleReturnScope> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRStringStream(text), parseAction, ignoreArrange);
		}

		public XElement GenerateFromFile(string fileName, Func<TParser, XParserRuleReturnScope> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRFileStream(fileName), parseAction, ignoreArrange);
		}

		public XElement Generate(ICharStream stream, bool ignoreArrange = false)
		{
			return Generate(stream, DefaultParseFunc, ignoreArrange);
		}

		public XElement Generate(TextReader reader, bool ignoreArrange = false)
		{
			return Generate(new ANTLRReaderStream(reader), ignoreArrange);
		}

		public XElement Generate(Stream stream, bool ignoreArrange = false)
		{
			return Generate(new ANTLRInputStream(stream), ignoreArrange);
		}

		public XElement GenerateFromText(string text, bool ignoreArrange = false)
		{
			return Generate(new ANTLRStringStream(text), ignoreArrange);
		}

		public XElement GenerateFromFile(string fileName, bool ignoreArrange = false)
		{
			return Generate(new ANTLRFileStream(fileName), ignoreArrange);
		}
	}
}
