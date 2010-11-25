using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics.Contracts;

namespace Ucpf.Languages.Python2 {

	public class FuncDef {
		private readonly XElement _node;

		// ----- ----- ----- ----- ----- property ----- ----- ----- ----- -----
		public string Name {
			get {
				return _node.Elements("NAME").ElementAt(1).Value;
			}
		}

		public IEnumerable<string> Parameters {
			get {
				return _node.Element("parameters").Element("vararglist").Elements("ipdef")
					.Select(e => e.Element("TOKEN").Value);
			}
		}

		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
		public FuncDef(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "funcdef");
			_node = elem;
		}
	}

	public class Block {
		private readonly XElement _node;

		// ----- ----- ----- ----- ----- property ----- ----- ----- ----- -----
		public IEnumerable<Statement> Statements {
			get {
				return _node.Elements("stmt").Select(e => StatementFactory.Create(e));
			}
		}

		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
		public Block(XElement elem) {
			Contract.Requires<NullReferenceException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "suite");
			_node = elem;
		}
	}

	#region Statement

	public abstract class Statement {
	}

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
		public Expression Test {
			get {
				return ExpressionFactory.Create(_node.Element("test"));
			}
		}


		// ----- ----- ----- ----- ----- ctor ----- ----- ----- ----- -----
		public IfStatement(XElement elem) {
			Contract.Requires<ArgumentNullException>(elem != null);
			Contract.Requires<ArgumentException>(elem.Name == "if_stmt");
			_node = elem;
		}
	}

	#endregion

	#region Expression

	public static class ExpressionFactory {
		public static Expression Create(XElement elem) {
			throw new NotImplementedException();
		}
	}

	public abstract class Expression {

	}

	#endregion
}
