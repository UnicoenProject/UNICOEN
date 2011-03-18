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

		#region program, namespace, class, method, filed ...

		public void Visit(UnifiedProgram program) {
			foreach (var elem in program)
			{
				elem.Accept(this);
			}
			
		}

		public void Visit(UnifiedClassDefinition classDefinition) {
			WriteIndent();
			classDefinition.Modifiers.Accept(this);
			_writer.Write("class ");
			_writer.WriteLine(classDefinition.Name);
			classDefinition.Body.Accept(this);
		}

		public void Visit(UnifiedFunctionDefinition functionDefinition) {
			WriteIndent();
			functionDefinition.Modifiers.Accept(this);
			functionDefinition.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(functionDefinition.Name);
			functionDefinition.Parameters.Accept(this);
			functionDefinition.Body.Accept(this);
		}


		public void Visit(UnifiedParameterCollection parameters) {
			_writer.Write("(");
			var splitter = "";
			foreach (var p in parameters)
			{
				_writer.Write(splitter);
				p.Accept(this);
				splitter = ", ";
			}
			_writer.Write(")");
		}

		public void Visit(UnifiedParameter parameter) {
			parameter.Modifiers.Accept(this);
			parameter.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(parameter.Name);
		}

		public void Visit(UnifiedModifierCollection modifiers) {
			foreach (var mod in modifiers) {
				mod.Accept(this);
				_writer.Write(" ");
			}
		}

		public void Visit(UnifiedModifier mod) {
			_writer.Write(mod.Name);
		}

		public void Visit(UnifiedType type)
		{
			_writer.Write(type.Name);
		}

		#endregion

		#region statement

		public void Visit(UnifiedBlock block) {
			WriteIndent();
			_writer.WriteLine("{");
			_indent++;
			foreach (var stmt in block)
			{
				WriteIndent();
				stmt.Accept(this);
				_writer.WriteLine(";");
			}
			_indent--;
			WriteIndent();
			_writer.WriteLine("}");
		}

		public void Visit(UnifiedIf ifStatement)		{
			_writer.Write("if (");
			ifStatement.Condition.Accept(this);
			_writer.WriteLine(")");
			ifStatement.TrueBlock.Accept(this);
			if (ifStatement.FalseBlock != null)
			{
				WriteIndent();
				_writer.WriteLine("else");
				ifStatement.FalseBlock.Accept(this);
			}
		}

		public void Visit(UnifiedReturn returnStatement) {
			_writer.Write("return ");
			returnStatement.Value.Accept(this);
		}

		#endregion

		#region expression

		public void Visit(UnifiedBinaryExpression expr) {
			_writer.Write("(");
			expr.LeftHandSide.Accept(this);
			expr.Operator.Accept(this);
			expr.RightHandSide.Accept(this);
			_writer.Write(")");
		}

		public void Visit(UnifiedBinaryOperator op) {
			_writer.Write(op.Sign);
		}

		public void Visit(UnifiedCall call) {
			call.Function.Accept(this);
			call.Arguments.Accept(this);
		}

		public void Visit(UnifiedArgumentCollection args) {
			_writer.Write("(");
			var splitter = "";
			foreach (var arg in args)
			{
				_writer.Write(splitter);
				arg.Accept(this);
				splitter = ", ";
			}
			_writer.Write(")");
		}

		public void Visit(UnifiedArgument arg) {
			arg.Value.Accept(this);
		}

		#endregion

		#region value
		public void Visit(UnifiedVariable variable)
		{
			_writer.Write(variable.Name);
		}

		public void Visit(UnifiedLiteral lit)
		{
			_writer.Write(lit.ToString());
		}

		public void Visit<T>(UnifiedTypedLiteral<T> lit)
		{
			_writer.Write(lit.Value);
		}
		#endregion


		#region notImplemented

		public void Visit(UnifiedUnaryOperator element) {
			throw new NotImplementedException();
		}


		public void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructorDefinition element) {
			throw new NotImplementedException();
		}


		public void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNew element) {
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

		#endregion

	}
}
