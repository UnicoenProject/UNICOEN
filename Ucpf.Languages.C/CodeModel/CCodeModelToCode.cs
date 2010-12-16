using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

// TODO :: extract "pre_procedure" as a method
namespace Ucpf.Languages.C.CodeModel {
	public class CCodeModelToCode{ // : ICodeModelToCode {
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
			// WriteLine();
			_depth++;

			var line = "";
			
			foreach (var stmt in block.Statements)
			{
				_writer.Write(line);
				stmt.Accept(this);
				line = "\n";
			}
			 _depth--;
			 // WriteLine();
			// end_paren
			_writer.Write(Tabs(_depth));
			_writer.Write("}");
			// WriteLine();
		}

		// Statement
		public void Generate(CStatement stmt)
		{
			WriteLine();
			
			if (stmt is CIfStatement)
			{
				
				Generate((CIfStatement)stmt);
			}
			else if (stmt is CReturnStatement)
			{
				_writer.Write(Tabs(_depth));
				Generate((CReturnStatement)stmt);
			}
			WriteLine();
		}

		// IfStatement
		public void Generate(CIfStatement stmt)
		{
			// _writer.WriteLine("IFSTMNT");
			// ConditionalExpression
			_writer.Write(Tabs(_depth));
			_writer.Write("if (");
			stmt.ConditionalExpression.Accept(this);
			_writer.Write(")");
			WriteLine();
			_writer.Flush();
			// TrueBlock
			// _writer.WriteLine("TRUE");
			stmt.TrueBlock.Accept(this);

			// ElseBlock
			// _writer.WriteLine("ELSE");
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.WriteLine("else");
			stmt.ElseBlock.Accept(this);
		}

		// ReturnStatement
		public void Generate(CReturnStatement stmt)
		{
			// _writer.WriteLine("RETURNSTMT");
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
		public void Generate(CBinaryExpression exp)
		{
			exp.LeftExpression.Accept(this);
			WriteSpace();
			exp.Operator.Accept(this);
			WriteSpace();
			exp.RightExpression.Accept(this);
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
			var opeType = ope.Type;

			// TODO :: MODIFY FOLLOWING 2 VARIABLE AND SWITCHING!!!
			UnaryOperatorType[] postfixOperators = { UnaryOperatorType.PostfixIncrement, UnaryOperatorType.PostfixDecrement };
			UnaryOperatorType[] unaryOperators = (UnaryOperatorType[])Enum.GetValues(typeof(UnaryOperatorType));

			if (postfixOperators.Contains(opeType))			// e.g. x++
			{
				exp.Accept(this);
				ope.Accept(this);
			}
			else if (unaryOperators.Contains(opeType))	// e.g. y++
			{
				ope.Accept(this);
				exp.Accept(this);
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

		// UnaryOperator
		public void Generate(CUnaryOperator op)
		{
			var sw = op.Type;
			switch (sw)
			{
				case UnaryOperatorType.PrefixIncrement:
				case UnaryOperatorType.PostfixIncrement:
					_writer.Write("++");
					break;
				case UnaryOperatorType.PrefixDecrement:
				case UnaryOperatorType.PostfixDecrement:
					_writer.Write("--");
					break;
				case UnaryOperatorType.Plus:
					_writer.Write("+");
					break;
				case UnaryOperatorType.Minus:
					_writer.Write("-");
					break;
				case UnaryOperatorType.Not:
					_writer.Write("!");
					break;
				case UnaryOperatorType.BitReverse:
					_writer.Write("~");
					break;
				case UnaryOperatorType.Address:
					_writer.Write("&");
					break;
				case UnaryOperatorType.Indirect:
					_writer.Write("*");
					break;
				default:
					throw new InvalidOperationException();
			}
		}

		// BinaryOperator
		public void Generate(CBinaryOperator op) {
			switch (op.Type) {
				// Arithmetic
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
				// Shift
				case BinaryOperatorType.LeftShift:
					_writer.Write("<<");
					break;
				case BinaryOperatorType.RightShift:
					_writer.Write(">>");
					break;
				case BinaryOperatorType.LeftRotate:
					_writer.Write("<<<");
					break;
				case BinaryOperatorType.RightRotate:
					_writer.Write(">>>");
					break;
				// Comparison
				case BinaryOperatorType.Greater:
					_writer.Write(">");
					break;
				case BinaryOperatorType.GreaterEqual:
					_writer.Write(">=");
					break;
				case BinaryOperatorType.Lesser:
					_writer.Write("<");
					break;
				case BinaryOperatorType.LesserEqual:
					_writer.Write("<=");
					break;
				case BinaryOperatorType.Equal:
					_writer.Write("==");
					break;
				case BinaryOperatorType.NotEqual:
					_writer.Write("!=");
					break;
				// Logical
				case BinaryOperatorType.LogicalAnd:
					_writer.Write("&&");
					break;
				case BinaryOperatorType.LogicalOr:
					_writer.Write("||");
					break;
				// Bit
				case BinaryOperatorType.BitAnd:
					_writer.Write("&");
					break;
				case BinaryOperatorType.BitOr:
					_writer.Write("|");
					break;
				case BinaryOperatorType.BitXor:
					_writer.Write("^");
					break;
				// Assignment
				case BinaryOperatorType.Assignment:
					_writer.Write("=");
					break;
				// TODO :: Implement other 'compound' assignment operator
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}