using System;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Common.Antlr {
	public abstract class AntlrAstGenerator<TParser> : AstGenerator {
		protected abstract Func<TParser, XParserRuleReturnScope> DefaultParseFunc { get; }

		protected virtual void ArrangeAst(XElement root) {}

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		private XElement Generate(ICharStream stream,
		                          Func<TParser, XParserRuleReturnScope> parseFunc,
		                          bool ignoreArrange) {
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

		private XElement Generate(ICharStream stream, string nodeName,
		                          bool ignoreArrange) {
			return Generate(stream,
				p =>
				(XParserRuleReturnScope)
				p.GetType().GetMethod(nodeName).Invoke(p, null),
				ignoreArrange);
		}

		public XElement Generate(string text, string nodeName) {
			return Generate(text, nodeName, true);
		}

		public XElement Generate(string text, string nodeName, bool ignoreArrange) {
			return Generate(new ANTLRStringStream(text), nodeName, ignoreArrange);
		}

		public XElement Generate(string text,
		                         Func<TParser, XParserRuleReturnScope> parseAction) {
			return Generate(text, parseAction, true);
		}

		public XElement Generate(string text,
		                         Func<TParser, XParserRuleReturnScope> parseAction,
		                         bool ignoreArrange) {
			return Generate(new ANTLRStringStream(text), parseAction, ignoreArrange);
		}

		private XElement Generate(ICharStream stream, bool ignoreArrange) {
			return Generate(stream, DefaultParseFunc, ignoreArrange);
		}

		public override XElement Generate(TextReader reader, bool ignoreArrange) {
			return Generate(new ANTLRReaderStream(reader), ignoreArrange);
		}

		public override XElement Generate(string text, bool ignoreArrange) {
			return Generate(new ANTLRStringStream(text), ignoreArrange);
		}
	}
}