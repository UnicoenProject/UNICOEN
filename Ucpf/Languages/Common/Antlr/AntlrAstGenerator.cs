using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Common.Antlr {
	[ContractClass(typeof(AntlrAstGeneratorContract<>))]
	public abstract class AntlrAstGenerator<TParser> : AstGenerator {
		protected abstract Func<TParser, XParserRuleReturnScope> DefaultParseFunc { get; }

		protected virtual void ArrangeAst(XElement root) {
			Contract.Requires(root != null);
		}

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

		public XElement Generate(string code, string nodeName) {
			Contract.Requires(code != null);
			Contract.Requires(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(code, nodeName, true);
		}

		public XElement Generate(string code, string nodeName, bool ignoreArrange) {
			Contract.Requires(code != null);
			Contract.Requires(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), nodeName, ignoreArrange);
		}

		public XElement Generate(string code,
		                         Func<TParser, XParserRuleReturnScope> parseAction) {
			Contract.Requires(code != null);
			Contract.Requires(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(code, parseAction, true);
		}

		public XElement Generate(string code,
		                         Func<TParser, XParserRuleReturnScope> parseAction,
		                         bool ignoreArrange) {
			Contract.Requires(code != null);
			Contract.Requires(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), parseAction, ignoreArrange);
		}

		private XElement Generate(ICharStream stream, bool ignoreArrange) {
			Contract.Requires(stream != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(stream, DefaultParseFunc, ignoreArrange);
		}

		public override XElement Generate(TextReader reader, bool ignoreArrange) {
			return Generate(new ANTLRReaderStream(reader), ignoreArrange);
		}

		public override XElement Generate(string code, bool ignoreArrange) {
			return Generate(new ANTLRStringStream(code), ignoreArrange);
		}
	}

	[ContractClassFor(typeof(AntlrAstGenerator<>))]
	abstract class AntlrAstGeneratorContract<TParser> : AntlrAstGenerator<TParser> {
		protected override Func<TParser, XParserRuleReturnScope> DefaultParseFunc {
			get {
				Contract.Ensures(Contract.Result<Func<TParser, XParserRuleReturnScope>>() != null);
				throw new NotImplementedException();
			}
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream) {
			Contract.Requires(stream != null);
			Contract.Ensures(Contract.Result<ITokenSource>() != null);
			throw new NotImplementedException();
		}

		protected override TParser CreateParser(ITokenStream tokenStream) {
			Contract.Requires(tokenStream != null);
			Contract.Ensures(Contract.Result<TParser>() != null);
			throw new NotImplementedException();
		}
	}
}