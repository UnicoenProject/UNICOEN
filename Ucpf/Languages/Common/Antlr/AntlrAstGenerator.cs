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

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		private XElement Generate(ICharStream stream,
		                          Func<TParser, XParserRuleReturnScope> parseFunc) {
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);

			// launch parsing
			return parseFunc(parser).Element;
		}

		private XElement Generate(ICharStream stream, string nodeName) {
			return Generate(stream,
				p =>
				(XParserRuleReturnScope)
				p.GetType().GetMethod(nodeName).Invoke(p, null));
		}

		public XElement Generate(string code, string nodeName) {
			Contract.Requires(code != null);
			Contract.Requires(nodeName != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), nodeName);
		}

		public XElement Generate(string code,
		                         Func<TParser, XParserRuleReturnScope> parseAction) {
			Contract.Requires(code != null);
			Contract.Requires(parseAction != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(new ANTLRStringStream(code), parseAction);
		}

		private XElement Generate(ICharStream stream) {
			Contract.Requires(stream != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(stream, DefaultParseFunc);
		}

		public override XElement Generate(TextReader reader) {
			return Generate(new ANTLRReaderStream(reader));
		}

		public override XElement Generate(string code) {
			return Generate(new ANTLRStringStream(code));
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