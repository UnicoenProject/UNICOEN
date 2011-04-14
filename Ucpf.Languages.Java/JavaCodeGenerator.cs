using System;
using System.IO;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Languages.Java
{
	public class JavaCodeGenerator : IUnifiedModelVisitor
	{
		public static string Generate(UnifiedProgram program)
		{
			var buff = new StringWriter();
			var visitor = new JavaCodeGenerator(buff);
			visitor.Visit(program);
			return buff.ToString();
		}

		private readonly TextWriter _writer;
		private int _indent;

		public string IndentSpace { get; set; }

		private JavaCodeGenerator(TextWriter writer)
		{
			_writer = writer;
			_indent = 0;
			IndentSpace = "\t";
		}

		private void WriteIndent()
		{
			for (int i = 0; i < _indent; i++)
				_writer.Write(IndentSpace);
		}

		#region program, namespace, class, method, filed ...

		public void Visit(UnifiedProgram program)
		{
			foreach (var elem in program) {
				elem.Accept(this);
			}
		}

		public void Visit(UnifiedClassDefinition classDefinition)
		{
			WriteIndent();
			classDefinition.Modifiers.Accept(this);
			_writer.Write("class ");
			_writer.WriteLine(classDefinition.Name.Value);
			classDefinition.Body.Accept(this);
		}

		public void Visit(UnifiedFunctionDefinition functionDefinition)
		{
			WriteIndent();
			functionDefinition.Modifiers.Accept(this);
			functionDefinition.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(functionDefinition.Name.Value);
			functionDefinition.Parameters.Accept(this);
			functionDefinition.Body.Accept(this);
		}

		public void Visit(UnifiedParameterCollection parameters)
		{
			_writer.Write("(");
			var splitter = "";
			foreach (var p in parameters) {
				_writer.Write(splitter);
				p.Accept(this);
				splitter = ", ";
			}
			_writer.Write(")");
		}

		public void Visit(UnifiedParameter parameter)
		{
			parameter.Modifiers.Accept(this);
			parameter.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(parameter.Name.Value);
		}

		public void Visit(UnifiedModifierCollection modifiers)
		{
			foreach (var mod in modifiers) {
				mod.Accept(this);
				_writer.Write(" ");
			}
		}

		public void Visit(UnifiedModifier mod)
		{
			_writer.Write(mod.Name);
		}

		public void Visit(UnifiedType type)
		{
			type.Name.Accept(this);
		}

		#endregion

		#region statement

		public void Visit(UnifiedBlock block)
		{
			WriteIndent();
			_writer.WriteLine("{");
			_indent++;
			foreach (var stmt in block) {
				WriteIndent();
				stmt.Accept(this);
				if (stmt is UnifiedNew || !(stmt is UnifiedExpressionWithBlock))
					_writer.Write(";");
			}
			_indent--;
			WriteIndent();
			_writer.WriteLine("}");
		}

		public void Visit(UnifiedIf ifStatement)
		{
			_writer.Write("if (");
			ifStatement.Condition.Accept(this);
			_writer.WriteLine(")");
			ifStatement.Body.Accept(this);
			if (ifStatement.FalseBody != null) {
				WriteIndent();
				_writer.WriteLine("else");
				ifStatement.FalseBody.Accept(this);
			}
		}

		public void Visit(UnifiedSpecialExpression element)
		{
			_writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				_writer.Write(" ");
				element.Value.Accept(this);
			}
		}

		public void Visit(UnifiedSpecialBlock element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCatch element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCatchCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTry element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCast element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeParameterCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeConstrain element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeConstrainCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeParameter element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeSupplement element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeSupplementCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTernaryOperator element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTernaryExpression element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinitionBody element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinitionBodyCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIdentifierCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedQualifiedIdentifier element)
		{
			throw new NotImplementedException();
		}

		public string GetKeyword(UnifiedSpecialExpressionKind kind)
		{
			switch (kind) {
			case UnifiedSpecialExpressionKind.Break:
				return "break";
			case UnifiedSpecialExpressionKind.Continue:
				return "continue";
			case UnifiedSpecialExpressionKind.Goto:
				return "goto";
			case UnifiedSpecialExpressionKind.Return:
				return "return";
			case UnifiedSpecialExpressionKind.YieldReturn:
				return "yield return";
			case UnifiedSpecialExpressionKind.Throw:
				return "throw";
			case UnifiedSpecialExpressionKind.Retry:
				throw new NotImplementedException();
			case UnifiedSpecialExpressionKind.Redo:
				throw new NotImplementedException();
			case UnifiedSpecialExpressionKind.Yield:
				throw new NotImplementedException();
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		#endregion

		#region expression

		public void Visit(UnifiedBinaryExpression expr)
		{
			_writer.Write("(");
			expr.LeftHandSide.Accept(this);
			expr.Operator.Accept(this);
			expr.RightHandSide.Accept(this);
			_writer.Write(")");
		}

		public void Visit(UnifiedBinaryOperator op)
		{
			_writer.Write(op.Sign);
		}

		public void Visit(UnifiedCall call)
		{
			call.Function.Accept(this);
			call.Arguments.Accept(this);
		}

		public void Visit(UnifiedArgumentCollection args)
		{
			_writer.Write("(");
			var splitter = "";
			foreach (var arg in args) {
				_writer.Write(splitter);
				arg.Accept(this);
				splitter = ", ";
			}
			_writer.Write(")");
		}

		public void Visit(UnifiedArgument arg)
		{
			arg.Value.Accept(this);
		}

		#endregion

		#region value

		public void Visit(UnifiedIdentifier identifier)
		{
			_writer.Write(identifier.Value);
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

		public void Visit(UnifiedUnaryOperator element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedImport element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructorDefinition element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinition element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNew element)
		{
			_writer.Write("new ");
			element.Type.Accept(this);
			element.Arguments.Accept(this);
			if (element.Body != null)
				element.Body.Accept(this);
		}

		public void Visit(UnifiedFor element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedForeach element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnaryExpression element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProperty element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExpressionCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedWhile element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDoWhile element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIndexer element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeArgument element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeArgumentCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSwitch element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCaseCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCase element)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}