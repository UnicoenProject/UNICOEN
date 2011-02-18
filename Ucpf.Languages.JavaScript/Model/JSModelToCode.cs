using System;
using System.IO;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Operators;
using Ucpf.Common.OldModel.Statements;

using Ucpf.Common.Visitors;
using Ucpf.Languages.JavaScript.Model.Expressions;

namespace Ucpf.Languages.JavaScript.Model {
	public class JSModelToCode : IModelToCode {
		private readonly TextWriter _writer;
		private int _depth;

		//constructor
		public JSModelToCode(TextWriter writer, int depth) {
			_writer = writer;
			_depth = depth;
		}

		//utility functions

		//generate functions
		//FunctionBody
		/*
		public void Generate(IBlock jsFunctionBody)
		{
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("{");
			WriteLine();
			_depth++;

			var line = "";

			//TODO how deal with the actual order of functionDeclarations and statements
			//write functionDeclarations
//			foreach (var declaration in jsFunctionBody.FunctionDeclarations) {
//				_writer.Write(line);
//				declaration.Accept(this);
//				line = "\n";
//			}

			//write statements
			foreach (var statement in jsFunctionBody.Statements) {
				_writer.Write(line);
				statement.Accept(this);
				line = "\n";
			}

			_depth--;
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("}\n");
		}
*/
		//Statement

		#region IModelToCode Members

		public void Generate(IAssignmentOperator op) {
			throw new NotImplementedException();
		}

		public void Generate(IStatement jsStatement) {
			jsStatement.Accept(this);
		}

		//IfStatement
		public void Generate(IIfStatement jsIfStatement) {
			_writer.Write(Tabs(_depth));
			_writer.Write("if(");
			jsIfStatement.Condition.Accept(this);
			_writer.Write(")");

			//TrueBlock
			jsIfStatement.TrueBlock.Accept(this);

			//FalseBlock
			_writer.Write(Tabs(_depth));
			_writer.Write("else");
			jsIfStatement.FalseBlock.Accept(this);

			//TODO need to adjust for IIfStatement
			//ElseBlock
			//			foreach (var statement in jsIfStatement.ElseBlock) {
			//				_writer.Write(Tabs(_depth));
			//				_writer.Write("else");
			//				statement.Accept(this);
			//			}
		}

		//ReturnStatement
		public void Generate(IReturnStatement jsReturnStatement) {
			_writer.Write(Tabs(_depth));
			_writer.Write("return");
			WriteSpace();

			jsReturnStatement.Expression.Accept(this);
			_writer.Write(";");
		}

		public void Generate(IExpressionStatement stmt) {
			throw new NotImplementedException();
		}

		public void Generate(IEmptyStatement stmt) {
			throw new NotImplementedException();
		}

		//Block
		public void Generate(IBlock jsBlock) {
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("{");
			WriteLine();
			_depth++;

			var line = "";

			//write statements
			foreach (var statement in jsBlock.Statements) {
				_writer.Write(line);
				statement.Accept(this);
				line = "\n";
			}

			_depth--;
			WriteLine();
			_writer.Write(Tabs(_depth));
			_writer.Write("}\n");
		}

		public void Generate(IType type) {
			throw new NotImplementedException();
		}

		//Function
		// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody
		public void Generate(IFunction jsFunctionDeclaration) {
			_writer.Write("function");
			WriteSpace();

			_writer.Write(jsFunctionDeclaration.Name);
			WriteSpace();

			var comma = "";
			_writer.Write("(");
			foreach (IVariable param in jsFunctionDeclaration.Parameters) {
				_writer.Write(comma);
				param.Accept(this);
				comma = ",";
			}
			_writer.Write(")");

			jsFunctionDeclaration.Body.Accept(this);
		}

		//Variable
		public void Generate(IVariable jsVariable) {
			_writer.Write(jsVariable.Name);
		}

		//Expression
		public void Generate(IExpression jsExpression) {
			jsExpression.Accept(this);
		}

		//PrimaryExpression

		//BinaryExpression
		public void Generate(IBinaryExpression jsBinaryExpression) {
			jsBinaryExpression.LeftHandSide.Accept(this);
			WriteSpace();
			jsBinaryExpression.Operator.Accept(this);
			WriteSpace();
			jsBinaryExpression.RightHandSide.Accept(this);
		}

		//CallExpression
		public void Generate(ICallExpression jsCallExpression) {
			_writer.Write(jsCallExpression.FunctionName);
			_writer.Write("(");

			var comma = "";
			foreach (var argument in jsCallExpression.Arguments) {
				_writer.Write(comma);
				argument.Accept(this);
				comma = ",";
			}

			_writer.Write(")");
		}

		public void Generate(IPrimaryExpression exp) {
			_writer.Write(exp.Name);
		}

		public void Generate(ITernaryExpression exp) {
			throw new NotImplementedException();
		}

		public void Generate(IAssignmentExpression exp) {
			throw new NotImplementedException();
		}

		//UnaryExpression
		public void Generate(IUnaryExpression jsUnaryExpression) {
			var opType = jsUnaryExpression.Operator.Type;

			if (opType == UnaryOperatorType.PostfixDecrement ||
			    opType == UnaryOperatorType.PostfixIncrement) {
				jsUnaryExpression.Term.Accept(this);
				jsUnaryExpression.Operator.Accept(this);
			} else {
				jsUnaryExpression.Operator.Accept(this);
				jsUnaryExpression.Term.Accept(this);
			}
		}

		//UnaryOperator
		public void Generate(IUnaryOperator jsUnaryOperator) {
			_writer.Write(jsUnaryOperator.Sign);
		}

		//BinaryOperator
		public void Generate(IBinaryOperator jsBinaryOperator) {
			_writer.Write(jsBinaryOperator.Sign);
		}

		#endregion

		public string Tabs(int depth) {
			var tabs = "";
			for (int i = 0; i < depth; i++) {
				tabs += "\t";
			}
			return tabs;
		}

		public void WriteSpace() {
			_writer.Write(" ");
		}

		public void WriteLine() {
			_writer.Write("\n");
		}

		public void Generate(JSPrimaryExpression jsPrimaryExpression) {
			_writer.Write(jsPrimaryExpression.Identifier);
		}

		//Program
		public void Generate(JSProgram jsProgram) {
			throw new NotImplementedException();
		}
	}
}