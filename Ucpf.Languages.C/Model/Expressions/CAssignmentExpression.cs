using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
{
	public class CAssignmentExpression : CExpression, IAssignmentExpression
	{
		/*
		assignment_expression
		: lvalue assignment_operator assignment_expression
		| conditional_expression
		;
		*/
		// 'conditional_expression' stands for '?:-expression' (e.g. a ? b : c

		// constructor
		public CAssignmentExpression(XElement lNode, CAssignmentOperator ope, XElement rNode) {
			LValue = CExpression.Create(lNode);
			Operator = ope;
			RValue = CExpression.Create(rNode);
		}


		// properties
		public CAssignmentOperator Operator { get; set; }
		public CExpression LValue { get; set; }
		public CExpression RValue { get; set; }


		public override string ToString() {
			return LValue.ToString() + Operator + RValue;
		}

		// acceptor
		public override void Accept(IModelToCode conv)
		{
			conv.Generate(this);
		}

		IAssignmentOperator IAssignmentExpression.Operator
		{
			get
			{
				return Operator;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IExpression IAssignmentExpression.LValue
		{
			get
			{
				return LValue;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IExpression IAssignmentExpression.RExpression
		{
			get
			{
				return RValue;
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
