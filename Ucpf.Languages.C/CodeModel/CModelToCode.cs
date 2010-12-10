using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ucpf.Languages.C.CodeModel
{
	public class CModelToCode
	{
		private TextWriter _writer;
		private int _depth;

		// constructor
		public CModelToCode(TextWriter writer, int depth)
		{
			_writer = writer;
			_depth = depth;
		}

		// utility function 
		// print tabs 'depth' times.
		public static string Tabs(int depth)
		{
			if (depth < 0)
			{
				throw new InvalidOperationException();
			}
			string tabs = "";
			for (int i = 0; i < depth; i++)
			{
				tabs += "\t";
			}
			return tabs;
		}
		
		public void Generate(CFunction func)
		{
			// [ReturnType] [FuncName] '(' [Arguments] ')' '{' [Body] '}'
			Generate(func.ReturnType);
			_writer.Write(func.Name);
			
			// arguments
			_writer.Write("(");
			string comma = "";
			foreach (var param in func.Parameters)
			{
				_writer.Write(comma);
				Generate(param);
				comma = ",";
			}
			_writer.Write(") {");
			
			// body
			_depth++;
			Generate(func.Body);
			_depth--;
			_writer.Write("}");
		}


		public void Generate(CIfStatement ifStmnt)
		{
			// conditional expression
			_writer.Write("if (");
			Generate(ifStmnt.ConditionalExpression);
			_writer.Write(") {");
			
			// true block
			_depth++;
			Generate(ifStmnt.TrueBlock);
			_depth--;
			_writer.Write("}");
			
			// else block
			_writer.Write("else {");
			_depth++;
			Generate(ifStmnt.ElseBlock);
			_depth--;
			_writer.Write("}");
		}

		private void Generate(CExpression cExpression)
		{
			throw new NotImplementedException();
		}
		private void Generate(CBlock cBlock)
		{
			foreach (var stmnt in cBlock.Statements)
			{
				_writer.Write(Tabs(_depth));
				Generate(stmnt);
			}

		}

		private void Generate(CStatement stmnt)
		{
			throw new NotImplementedException();
		}

		private void Generate(CVariable param)
		{
			Generate(param.Type);
			_writer.Write(" ");
			_writer.Write(param.Name);
		}


		public void Generate(CType cType)
		{
			_writer.Write(cType.Name);
		}




		public static string Generate<T>(T val, Func<CModelToCode, Action<T>> generation)
		{
			var writer = new StringWriter();
			var gen = new CModelToCode(writer, 0);
			generation(gen)(val);
			return writer.ToString();
		}

		public static void InTest(CFunction func)
		{
			var writer = new StringWriter();
			var CMTC = new CModelToCode(writer, 0);
			CMTC.Generate(func);
			String code = writer.ToString();
		}
	}



}

