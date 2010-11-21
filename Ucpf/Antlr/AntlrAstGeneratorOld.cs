using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Common.Antlr
{
	public abstract class AntlrAstGeneratorOld<TParser> : IAstGenerator
		where TParser : IXParser
	{
		protected virtual string TokenElementName
		{
			get { return "TOKEN"; }
		}

		protected virtual string LeaveElementName
		{
			get { return "LEAVE"; }
		}

		protected abstract Action<TParser> DefaultParseAction { get; }
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		protected virtual void ArrangeAst(XElement ast) { }

		protected abstract ITokenSource CreateTokenSource(ICharStream stream);

		protected abstract TParser CreateParser(ITokenStream tokenStream);

		public XElement Generate(ICharStream stream, Action<TParser> parseAction, bool ignoreArrange = false)
		{
			var lex = CreateTokenSource(stream);
			var tokens = new CommonTokenStream(lex);
			var parser = CreateParser(tokens);
			parser.LeaveElementName = LeaveElementName;
			parser.TreeAdaptor = new XmlTreeAdaptor(parser.ElementList, TokenElementName);
			parseAction(parser); // launch parsing

			var ast = CreateXDocument(parser.ElementList, TokenElementName, LeaveElementName);
			if (!ignoreArrange) {
				ArrangeAst(ast);
			}
			return ast;
		}

		public XElement Generate(ICharStream stream, string nodeName, bool ignoreArrange = false)
		{
			return Generate(stream, p => p.GetType().GetMethod(nodeName).Invoke(p, null), ignoreArrange);
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

		public XElement Generate(TextReader reader, Action<TParser> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRReaderStream(reader), parseAction, ignoreArrange);
		}

		public XElement Generate(Stream stream, Action<TParser> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRInputStream(stream), parseAction, ignoreArrange);
		}

		public XElement Generate(string text, Action<TParser> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRStringStream(text), parseAction, ignoreArrange);
		}

		public XElement GenerateFromFile(string fileName, Action<TParser> parseAction, bool ignoreArrange = false)
		{
			return Generate(new ANTLRFileStream(fileName), parseAction, ignoreArrange);
		}

		public XElement Generate(ICharStream stream, bool ignoreArrange = false)
		{
			return Generate(stream, DefaultParseAction, ignoreArrange);
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

		private static XElement CreateXDocument(IEnumerable<XElement> elements, string tokenElementName, string leaveElementName)
		{
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