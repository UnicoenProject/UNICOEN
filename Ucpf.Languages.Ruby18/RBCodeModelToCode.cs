using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;



namespace Ucpf.Languages.Ruby18
{
	public class RBCodeModelToCode : ICodeModelToCode
	{
		private readonly TextWriter _writer;
		private int _depth;

		// constructor
		public RBCodeModelToCode(TextWriter writer, int depth)
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
			throw new NotImplementedException();
		}

		public void Generate(ICallExpression exp)
		{
			var comma = "";
			_writer.Write(exp.FunctionName);
			
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

		public void Generate(ITernaryExpression exp)
		{
			_writer.Write(exp.Body);
		}


		public void Generate(IBinaryOperator op)
		{
			_writer.Write(op.Sign);
		}

		public void Generate(IUnaryOperator op)
		{
			// _writer.Write(op.);
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
			_writer.Write("end if");
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

		public void Generate(IEmptyStatement stmt) {
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

		public void Generate(IType type) {
			// print nothing
			return;
		}


		public void Generate(IVariable variable)
		{
			_writer.Write(variable.Name);
		}
	}
}
