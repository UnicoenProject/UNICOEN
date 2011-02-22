using System;
using System.IO;
using Ucpf.Common.Model;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.OldModel.Statements;

namespace Ucpf.Languages.Ruby18.Model
{
	public class RubyModelToCode : IModelToCode
	{
		private readonly TextWriter _writer;
		private int _depth;

		// constructor
		public RubyModelToCode(TextWriter writer, int depth)
		{
			_writer = writer;
			_depth = depth;
		}

		#region UtilityFunctions

		// print tabs 'depth' times.
		public static string Tabs(int depth)
		{
			// proper way to set exception
			// Contract.Requires<InvalidOperationException>(depth >= 0);

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

		public void Generate(IFunction func)
		{
			_writer.Write("def ");
			_writer.Write(func.Name);
			_writer.Write(" ");
			var comma = "";
			foreach (var parameter in func.Parameters)
			{
				_writer.Write(comma);
				_writer.Write(parameter.Name);
				comma = ", ";
			}

			func.Body.Accept(this);

			_writer.Write("end");
		}

		public void Generate(IExpression exp)
		{
			// deligate to subclasses
			exp.Accept(this);
		}


		public void Generate(IBinaryExpression exp)
		{
			exp.LeftHandSide.Accept(this);
			WriteSpace();
			exp.Operator.Accept(this);
			WriteSpace();
			exp.RightHandSide.Accept(this);
		}


		public void Generate(IUnaryExpression exp)
		{
			exp.Term.Accept(this);
			exp.Operator.Accept(this);
		}

		public void Generate(ICallExpression exp)
		{
			var comma = "";
			var funcName = exp.FunctionName;

			// ** semantic translate **  :: change method name

			_writer.Write(funcName);

			// paren and comma can be omitted
			_writer.Write("(");
			foreach (var e in exp.Arguments)
			{
				_writer.Write(comma);
				e.Accept(this);
				comma = ", ";
			}
			_writer.Write(")");
		}

		public void Generate(IPrimaryExpression exp)
		{
			_writer.Write(exp.Name);
		}

		public void Generate(ITernaryExpression exp)
		{
			throw new NotImplementedException();
		}

		public void Generate(IAssignmentExpression exp)
		{
			var sw = exp.Operator.Type;
			var lValue = exp.LValue;
			var rValue = exp.RExpression;

			lValue.Accept(this);
			WriteSpace();
			_writer.Write("=");
			WriteSpace();

			// **Ruby does not support multiple assignment(e.g +=)
			// the expression 'a (OP)= b' completely equals to 'a = a (OP) b'
			switch (sw)
			{
				case AssignmentOperatorType.SimpleAssignment:
					rValue.Accept(this);
					break;
				case AssignmentOperatorType.PlusAssignment:
					lValue.Accept(this);

					WriteSpace();
					_writer.Write("+");
					WriteSpace();

					rValue.Accept(this);
					break;
				case AssignmentOperatorType.MinusAssignment:
					lValue.Accept(this);

					WriteSpace();
					_writer.Write("-");
					WriteSpace();

					rValue.Accept(this);
					break;
				case AssignmentOperatorType.MultiAssignment:
					lValue.Accept(this);

					WriteSpace();
					_writer.Write("*");
					WriteSpace();

					rValue.Accept(this);
					break;
				default:
					throw new InvalidOperationException();
			}
		}

		public void Generate(IBinaryOperator op)
		{
			_writer.Write(op.Sign);
		}

		public void Generate(IUnaryOperator op)
		{
			// _writer.Write(op.);
		}

		public void Generate(IAssignmentOperator op)
		{
			throw new NotImplementedException();
		}

		public void Generate(IStatement stmt)
		{
			stmt.Accept(this);
		}

		public void Generate(IIfStatement stmt)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write("if ");
			stmt.Condition.Accept(this);
			// _writer.Write("");
			// _writer.Flush();

			// TrueBlock
			stmt.TrueBlock.Accept(this);

			// ElseIfBlock
			if (stmt.ElseIfBlocks.Count != 0)
			{
				// WriteLine();
				foreach (var elm in stmt.ElseIfBlocks)
				{
					_writer.Write(Tabs(_depth));
					_writer.Write("elsif ");
					elm.ConditionalExpression.Accept(this);
					// _writer.Write(")");
					elm.Accept(this);
				}
				// WriteLine();
			}

			// ElseBlock
			if (stmt.FalseBlock != null)
			{
				_writer.Write(Tabs(_depth));
				_writer.Write("else");
				stmt.FalseBlock.Accept(this);
			}

			_writer.Write(Tabs(_depth));
			_writer.Write("end");
		}

		public void Generate(IReturnStatement stmt)
		{
			_writer.Write(Tabs(_depth));
			_writer.Write("return");			// can be omitted
			WriteSpace();

			stmt.Expression.Accept(this);
		}

		public void Generate(IExpressionStatement stmt)
		{
			if (stmt is IEmptyStatement)
			{
				Generate((IEmptyStatement)stmt);
			}
			else
			{
				_writer.Write(Tabs(_depth));
				stmt.Expression.Accept(this);
			}
		}

		public void Generate(IEmptyStatement stmt)
		{
			return;
		}

		public void Generate(IBlock block)
		{
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
		}

		public void Generate(IType type)
		{
			// print nothing
			return;
		}


		public void Generate(IVariable variable)
		{
			_writer.Write(variable.Name);
		}
	}
}
