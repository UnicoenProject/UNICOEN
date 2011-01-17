﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
{
	public class CStatement : IStatement
	{
		/*
		// properties
		public List<IExpression> Expressions { get; private set; }

		// constructor for parsing AST
		public CStatement(XElement node)
		{
			Expressions = node.Descendants("expression")
				.Select(e => CExpression.Create(e))
				.Cast<IExpression>()
				.ToList();
		}
		*/


		// constructor for deligating to subclasses
		public CStatement() { }

		public static CStatement Create(XElement stmtNode)
		{
			// -- which is better ?
			// var judge = node.Descendants("TOKEN").First().Value;
			var judge = stmtNode.Descendants().First().Name.LocalName;
			switch (judge)
			{
				case ("selection_statement"):
					return CSelectionStatement.Create(stmtNode);
				case ("jump_statement"):
					return new CReturnStatement(stmtNode);
				case ("iteration_statement") :
					// return CIterationStatement.CreateStatement(node);
					throw new NotImplementedException();
				case ("expression_statement") :
					return CExpressionStatement.Create(stmtNode);
				default:
					throw new InvalidOperationException();
			}
		}

		// acceptor
		public virtual void Accept(IModelToCode conv) {
			conv.Generate(this);
		}
	}
}

/*
 * postfix_expression
	:   primary_expression
        (   '[' expression ']'
        |   '(' ')'
        |   '(' argument_expression_list ')'
        |   '.' IDENTIFIER
        |   '->' IDENTIFIER
        |   '++'
        |   '--'
        )*
*/