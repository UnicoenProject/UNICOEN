using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Common.Antlr {
	public abstract class AntlrAstGeneratorOld<TParser> : AstGenerator
		where TParser : IXParser {
		protected virtual string TokenElementName {
			get { return "TOKEN"; }
		}

		protected virtual string LeaveElementName {
			get { return "LEAVE"; }
		}

		protected abstract Action<TParser> DefaultParseAction { get; }

		protected virtual void ArrangeAst(XElement ast) {}

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		private XElement Generate(ICharStream stream, Action<TParser> parseAction,
		                          bool ignoreArrange) {
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);
			parser.LeaveElementName = LeaveElementName;
			parser.TreeAdaptor = new XmlTreeAdaptor(parser.ElementList, TokenElementName);
			parseAction(parser); // launch parsing

			var ast = CreateXDocument(parser.ElementList, TokenElementName,
				LeaveElementName);
			if (!ignoreArrange) {
				ArrangeAst(ast);
			}
			return ast;
		}

		private XElement Generate(ICharStream stream, string nodeName,
		                          bool ignoreArrange) {
			return Generate(stream, p => p.GetType().GetMethod(nodeName).Invoke(p, null),
				ignoreArrange);
		}

		public XElement Generate(string text, string nodeName) {
			return Generate(text, nodeName, true);
		}

		public XElement Generate(string text, string nodeName, bool ignoreArrange) {
			return Generate(new ANTLRStringStream(text), nodeName, ignoreArrange);
		}

		public XElement Generate(string text, Action<TParser> parseAction) {
			return Generate(text, parseAction, true);
		}

		public XElement Generate(string text, Action<TParser> parseAction,
		                         bool ignoreArrange = false) {
			return Generate(new ANTLRStringStream(text), parseAction, ignoreArrange);
		}

		private XElement Generate(ICharStream stream, bool ignoreArrange) {
			return Generate(stream, DefaultParseAction, ignoreArrange);
		}

		public override XElement Generate(TextReader reader, bool ignoreArrange) {
			return Generate(new ANTLRReaderStream(reader), ignoreArrange);
		}

		public override XElement Generate(string text, bool ignoreArrange) {
			return Generate(new ANTLRStringStream(text), ignoreArrange);
		}

		private static XElement CreateXDocument(IEnumerable<XElement> elements,
		                                        string tokenElementName,
		                                        string leaveElementName) {
			var xdoc = new XDocument();
			var parent = (XContainer)xdoc;
			foreach (var element in elements.Where(e => e != null)) {
				if (element.Name.LocalName == tokenElementName) {
					parent.Add(element);
					continue;
				}
				if (element.Name.LocalName == leaveElementName) {
					parent = parent.Parent;
					continue;
				}
				parent.Add(element);
				parent = element;
			}
			return xdoc.Root;
		}
		}
}