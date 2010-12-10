using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Ucpf.Languages.C.CodeModel {
	public class CCodeModelToCode {
		private TextWriter _writer;
		private int _depth;

		// constructor
		public CCodeModelToCode(TextWriter writer, int depth)
		{
			_writer = writer;
			_depth = depth;
		}

		// utility function 
		// print tabs 'depth' times.
		public static string Tabs(int depth)
		{
			Contract.Requires<InvalidOperationException>(depth > 0);

			var tabs = "";
			for (int i = 0; i < depth; i++)
			{
				tabs += "\t";
			}
			return tabs;
		}

		public void Generate(CBlock block)
		{
			foreach (var stmt in block.Statements)
			{
				_writer.Write(Tabs(_depth));
				stmt.Accept(this);
			}
		}

		public void Generate(CStatement stmt) {
		}
	}
}