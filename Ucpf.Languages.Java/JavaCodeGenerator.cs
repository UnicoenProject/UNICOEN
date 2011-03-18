using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Languages.Java {
	public class JavaCodeGenerator : IUnifiedModelVisitor {


		public static string Generate(UnifiedProgram program) {
			var buff = new StringWriter();
			var visitor = new JavaCodeGenerator(buff);
			visitor.Visit(program);
			return buff.ToString();
			throw new NotImplementedException();
		}

		private readonly TextWriter _writer;
		private int _indent;

		public string IndentSpace { get; set; }

		private JavaCodeGenerator(TextWriter writer) {
			_writer = writer;
			_indent = 0;
			IndentSpace = "\t";
		}

		private void WriteIndent() {
			for (int i = 0; i < _indent; i++)
				_writer.Write(IndentSpace);
		}

		public void Visit<T>(UnifiedTypedLiteral<T> element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBinaryOperator element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnaryOperator element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArgument element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArgumentCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBinaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBlock element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCall element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFunctionDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIf element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedParameter element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedParameterCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedReturn element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariable element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifierCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructorDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProgram element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedClassDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArrayNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFor element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedForeach element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProperty element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExpressionCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedWhile element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDoWhile element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBreak element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedContinue element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNamespace element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIndexer element) {
			throw new NotImplementedException();
		}
	}
}
