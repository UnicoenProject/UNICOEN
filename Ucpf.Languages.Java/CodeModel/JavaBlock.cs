using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.Java.CodeModel.Statements;

namespace Ucpf.Languages.Java.CodeModel {
	public class Block {
		private readonly XElement _node;
		/* blockStatement* */

		public Block(XElement xElement) {
			_node = xElement;
		}

		private IEnumerable<JavaStatement> Statements {
			get {
				throw new NotImplementedException();
				return _node.Elements("blockStatement").Select(e => createStatement(e));
			}
		}

		private JavaStatement createStatement(XElement xElement) {
			var element = xElement.Element("Statement").Elements().First();
			if (element.Name.LocalName == "TOKEN" && element.Value == "if")
				return new IfStatement();
			throw new NotImplementedException();
		}
	}
}