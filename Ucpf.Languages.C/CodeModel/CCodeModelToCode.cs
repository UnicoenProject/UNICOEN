using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

// TODO :: extract "pre_procedure" as a method
namespace Ucpf.Languages.C.CodeModel
{
	public class CCodeModelToCode : ICodeModelToCode
	{
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
		public void Generate(IBlock block)
		{
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("{");
			WriteLine();
			_depth++;

			var line = "";

			foreach (var stmt in block.Statements)
			{
				_writer.Write(line);
				stmt.Accept(this);
				line = "\n";
			}
			_depth--;
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("}\n");
		}

		// Statement
		public void Generate(IStatement stmt)
		{
			WriteLine();
			/*
			if (stmt is IIfStatement)
			{
				Generate((IIfStatement)stmt);
			}
			else if (stmt is IReturnStatement)
			{
				Generate((IReturnStatement)stmt);
			}
			else
			{
				foreach (IExpression exp in stmt.Expressions)
				{
					_writer.Write(Tabs(_depth));
					exp.Accept(this);
				}
				_writer.Write(";");
			}
			*/
			stmt.Accept(this);

			WriteLine();
		}


		// IfStatement
		public void Generate(IIfStatement stmt)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write("if (");
			stmt.Condition.Accept(this);
			_writer.Write(")");
			// _writer.Flush();

			// TrueBlock
			stmt.TrueBlock.Accept(this);

			// ElseIfBlock
			if (stmt.FalseBlock != null)
			{
				WriteLine();
				// TODO :: how treat the ElseIfBlock????
				foreach (var elm in stmt.ElseIfBlocks)
				{
					_writer.Write(Tabs(_depth));
					_writer.Write("else if (");
					elm.ConditionalExpression.Accept(this);
					_writer.Write(")");
					elm.Accept(this);
				}
				WriteLine();
			}

			// ElseBlock
			if (stmt.FalseBlock != null)
			{
				_writer.Write(Tabs(_depth));
				_writer.Write("else");
				stmt.FalseBlock.Accept(this);
			}


		}

		// ReturnStatement
		public void Generate(IReturnStatement stmt)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write("return");
			WriteSpace();

			stmt.Expression.Accept(this);
			_writer.Write(";");
		}

		// Expression Statement
		public void Generate(IExpressionStatement stmt)
		{
			if (stmt is IEmptyStatement)
			{
				Generate((IEmptyStatement) stmt);
			}
			else
			{
				_writer.Write(Tabs(_depth));
				stmt.Expression.Accept(this);
				_writer.Write(";");
			}
		}
		public void Generate(IEmptyStatement stmt)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write(";");
		}

		// Function
		// [ReturnType] [FuncName] '(' ([Type] [Name])* ')'
		public void Generate(IFunction func)
		{
			var comma = "";

			// Signature
			func.ReturnType.Accept(this);
			WriteSpace();
			_writer.Write(func.Name);
			_writer.Write("(");
			foreach (CVariable prm in func.Parameters)
			{
				_writer.Write(comma);
				prm.Accept(this);
				comma = ", ";
			}
			_writer.Write(")");

			// Body
			func.Body.Accept(this);
		}

		// Type
		public void Generate(IType type)
		{
			_writer.Write(type.Name);
		}

		// Variable
		public void Generate(IVariable variable)
		{
			variable.Type.Accept(this);
			WriteSpace();
			_writer.Write(variable.Name);
		}


		#region Expression
		// Expression
		public void Generate(IExpression exp)
		{
			exp.Accept(this);
		}

		// PrimaryExpression
		public void Generate(ITernaryExpression pExp)
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
		public void Generate(ICallExpression exp)
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
		public void Generate(IUnaryExpression exp)
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
		public void Generate(IAssignmentExpression exp)
		{
			throw new NotImplementedException();
		}

		#endregion


		// UnaryOperator
		public void Generate(IUnaryOperator op)
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
		public void Generate(IBinaryOperator op)
		{
			switch (op.Type)
			{
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