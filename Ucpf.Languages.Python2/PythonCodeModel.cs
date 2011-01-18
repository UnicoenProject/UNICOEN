using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.Python2 {
	public class FuncDef {
		private readonly XElement _node;

		public FuncDef(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "funcdef");
			_node = elem;
		}

		// ----- ----- ----- ----- ----- property ----- ----- ----- ----- -----
		public string Name {
			get { return _node.Elements("NAME").ElementAt(1).Value; }
		}

		public IEnumerable<string> Parameters {
			get {
				return _node.Element("parameters").Element("vararglist").Elements("ipdef")
					.Select(e => e.Element("TOKEN").Value);
			}
		}

		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
	}

	public class Block {
		private readonly XElement _node;

		// ----- ----- ----- ----- ----- property ----- ----- ----- ----- -----

		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
		public Block(XElement elem) {
			Contract.Requires<NullReferenceException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "suite");
			_node = elem;
		}

		public IEnumerable<Statement> Statements {
			get { return _node.Elements("stmt").Select(e => StatementFactory.Create(e)); }
		}
	}

	#region Statement

	public abstract class Statement {}

	public static class StatementFactory {
		public static Statement Create(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "stmt");

			var childNode = elem.Elements().First();
			var name = childNode.Name.LocalName;
			switch (name) {
			case "simple_stmt":
				break;
			case "compound_stmt":
				return CreateCompoundStatement(childNode);
			}
			throw new ArgumentException("child node is " + name);
		}

		private static Statement CreateCompoundStatement(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "compound_stmt");

			var childNode = elem.Elements().First();
			var name = childNode.Name.LocalName;
			switch (name) {
			case "if_stmt":
				return new IfStatement(childNode);
			}
			throw new NotImplementedException();
		}
	}

	public class IfStatement : Statement {
		private readonly XElement _node;

		// ----- ----- ----- ----- ----- property ----- ----- ----- ----- -----

		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
		public IfStatement(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "if_stmt");
			_node = elem;
		}

		public Expression Test {
			get { return ExpressionFactory.Create(_node.Element("test")); }
		}
	}

	#endregion

	#region Expression

	public static class ExpressionFactory {
		public static Expression Create(XElement elem) {
			throw new NotImplementedException();
		}
	}

	public abstract class Expression {}

	#endregion
}