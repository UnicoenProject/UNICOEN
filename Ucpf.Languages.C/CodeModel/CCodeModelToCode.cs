using System;
using System.Diagnostics.Contracts;
using System.IO;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

// TODO :: extract "pre_procedure" as a method
namespace Ucpf.Languages.C.CodeModel {
	public class CCodeModelToCode : ICodeModelToCode {
		private readonly TextWriter _writer;
		private int _depth;

		// constructor
		public CCodeModelToCode(TextWriter writer, int depth)
		{
			_writer = writer;
			_depth = depth;
		}

		#region UtilityFunctions

		// print tabs 'depth' times.
		public static string Tabs(int depth)
		{
			// proper way to set exception
			Contract.Requires<InvalidOperationException>(depth >= 0);

			var tabs = "";
			for (int i = 0; i < depth; i++)
			{
				tabs += "\t";
			}
			return tabs;
		}

		public void WriteSpace()
		{
			_writer.Write(" ");
		}
		public void WriteLine()
		{
			_writer.Write("\n");
		}
		#endregion

		// Block
		public void Generate(CBlock block)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write("{");
			WriteLine();
			_depth++;

			var line = "";
			
			foreach (var stmt in block.Statements)
			{
				_writer.Write(line);
				_writer.Write(Tabs(_depth));
				stmt.Accept(this);
				line = "\n";
			}
			 _depth--;

			// end_paren
			_writer.Write(Tabs(_depth));
			_writer.Write("}");
			WriteLine();
		}

		// Statement
		public void Generate(CStatement stmt)
		{
			if (stmt is CIfStatement)
			{
				Generate((CIfStatement)stmt);
			}
			else if (stmt is CReturnStatement)
			{
				Generate((CReturnStatement)stmt);
			}
		}

		// IfStatement
		public void Generate(CIfStatement stmt)
		{
			// ConditionalExpression
			_writer.Write("if (");
			stmt.ConditionalExpression.Accept(this);
			_writer.Write(")");
			WriteLine();
			
			// TrueBlock
			stmt.TrueBlock.Accept(this);

			// ElseBlock
			_writer.Write("else");
			WriteLine();
			stmt.ElseBlock.Accept(this);
		}

		// ReturnStatement
		public void Generate(CReturnStatement stmt)
		{
			_writer.Write("return");
			WriteSpace();

			foreach (CExpression exp in stmt.Expressions)
			{
				exp.Accept(this);
			}
			_writer.Write(";");
		}

		// Function
		// [ReturnType] [FuncName] '(' ([Type] [Name])* ')'
		public void Generate(CFunction func)
		{
			var comma = "";

			// Signature
			func.ReturnType.Accept(this);
			WriteSpace();
			_writer.Write(func.Name);
			_writer.Write("(");
			foreach(CVariable prm in func.Parameters){
				_writer.Write(comma);
				prm.Accept(this);
				comma = ", ";
			}
			_writer.Write(")");
			WriteLine();

			// Body
			func.Body.Accept(this);
		}

		// Type
		public void Generate(CType type)
		{
			_writer.Write(type.Name);
		}

		// Variable
		public void Generate(CVariable variable)
		{
			variable.Type.Accept(this);
			WriteSpace();
			_writer.Write(variable.Name);
		}


		#region Expression
		// Expression
		public void Generate(CExpression exp)
		{
			if (exp is CPrimaryExpression)
			{
				Generate((CPrimaryExpression)exp);
			}
			else if (exp is CBinaryExpression)
			{
				Generate((CBinaryExpression)exp);
			}
			else if (exp is CUnaryExpression)
			{
				Generate((CUnaryExpression)exp);
			}
			else if (exp is CInvocationExpression)
			{
				Generate((CInvocationExpression)exp);
			}
			else if (exp is CAssignmentExpression)
			{
				Generate((CAssignmentExpression)exp);
			}
			else
			{
				throw new InvalidOperationException();
			}

			// adding ";" is deligated to submethods

		}
		
		// PrimaryExpression
		public void Generate(CPrimaryExpression pExp)
		{
			_writer.Write(pExp.Body);
		}

		// BinaryExpression
		public void Generate(IBinaryExpression exp)
		{
			exp.LeftHandSide.Accept(this);
			WriteSpace();
			exp.Operator.Accept(this);
			WriteSpace();
			exp.RightHandSide.Accept(this);
		}

		// InvocationExpression
		public void Generate(CInvocationExpression exp)
		{
			// [FuncName] '(' [Argument]* ');'
			var comma = "";
			_writer.Write(exp.FunctionName);
			_writer.Write("(");
			foreach (CExpression e in exp.Arguments)
			{
				_writer.Write(comma);
				e.Accept(this);
				comma = ", ";
			}
			_writer.Write(")");

		}

		// UnaryExpression
		public void Generate(CUnaryExpression exp)
		{
			var ope = exp.Operator;
			
			if (ope is CPrefixOperator)			// e.g. ++x
			{
				ope.Accept(this);
				exp.Accept(this);
			}
			else if (ope is CPostfixOperator)	// e.g. y++
			{
				exp.Accept(this);
				ope.Accept(this);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		// AssignmentExpression
		public void Generate(CAssignmentExpression exp)
		{
			throw new NotImplementedException();
		}

		#endregion

		// Operator
		public void Generate(COperator ope)
		{
			_writer.Write(ope.Name);
		}

		public void Generate(IBinaryOperator op) {
			switch (op.Type) {
			case BinaryOperatorType.Addition:
				_writer.Write("+");
				break;
			case BinaryOperatorType.Subtraction:
				_writer.Write("-");
				break;
			case BinaryOperatorType.Multiplication:
				_writer.Write("*");
				break;
			case BinaryOperatorType.Division:
				_writer.Write("/");
				break;
			case BinaryOperatorType.Modulo:
				_writer.Write("%");
				break;
			case BinaryOperatorType.Assignment:
				_writer.Write("=");
				break;
			case BinaryOperatorType.LeftShift:
				_writer.Write("+");
				break;
			case BinaryOperatorType.RightShift:
				_writer.Write("+");
				break;
			case BinaryOperatorType.LeftRotate:
				_writer.Write("+");
				break;
			case BinaryOperatorType.RightRotate:
				_writer.Write("+");
				break;
			case BinaryOperatorType.Greater:
				_writer.Write("+");
				break;
			case BinaryOperatorType.GreaterEqual:
				_writer.Write("+");
				break;
			case BinaryOperatorType.Lesser:
				_writer.Write("+");
				break;
			case BinaryOperatorType.LesserEqual:
				_writer.Write("+");
				break;
			case BinaryOperatorType.Equal:
				_writer.Write("+");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}