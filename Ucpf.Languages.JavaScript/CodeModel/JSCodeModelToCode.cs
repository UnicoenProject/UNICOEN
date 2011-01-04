using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ucpf.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel
{
	public class JSCodeModelToCode {
		private readonly TextWriter _writer;
		private int _depth;

		//constructor
		public JSCodeModelToCode(TextWriter writer, int depth) {
			_writer = writer;
			_depth = depth;
		}

		//utility functions

		public void WriteSpace() {
			_writer.Write(" ");
		}

		public void WriteLine() {
			_writer.Write("\n");
		}

		//generate functions
		//FunctionBody
		public void Generate(JSFunctionBody jsFunctionBody)
		{
			WriteLine();
			//tabs
			_writer.Write("{");
			WriteLine();
			_depth++;

			var line = "";

			//TODO how deal with the actual order of functionDeclarations and statements
			//write functionDeclarations
			foreach (var declaration in jsFunctionBody.FunctionDeclarations) {
				_writer.Write(line);
				declaration.Accept(this);
				line = "\n";
			}

			//write statements
			foreach (var statement in jsFunctionBody.Statements) {
				_writer.Write(line);
				statement.Accept(this);
				line = "\n";
			}

			_depth--;
			WriteLine();
			//tabs
			_writer.Write("}\n");
		}

		//Statement
		public void Generate(JSStatement jsStatement)
		{
			jsStatement.Accept(this);
		}

		//IfStatement
		public void Generate(JSIfStatement jsIfStatement)
		{
			WriteLine();
			//tabs
			_writer.Write("if(");
			jsIfStatement.ConditionalExpression.Accept(this);
			_writer.Write(")");

			//TrueBlock
			jsIfStatement.TrueBlock.Accept(this);

			//ElseBlock
			foreach (var statement in jsIfStatement.ElseBlock) {
				//tabs
				_writer.Write("else");
				statement.Accept(this);
			}
		}

		//ReturnStatement
		public void Generate(JSReturnStatement jsReturnStatement) 
		{
			WriteLine();
			//tabs
			_writer.Write("return");
			WriteSpace();

			jsReturnStatement.ReturnExpression.Accept(this);
			_writer.Write(";");
		}

		//Block
		public  void Generate(JSBlock jsBlock)
		{
			WriteLine();
			//tabs
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
			//tabs
			_writer.Write("}\n");
		}

		//Function
		// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody
		public void Generate(JSFunctionDeclaration jsFunctionDeclaration) 
		{
			_writer.Write("function");
			WriteSpace();

			_writer.Write(jsFunctionDeclaration.Identifier);
			WriteSpace();

			var comma = "";
			_writer.Write("(");
			foreach (var param in jsFunctionDeclaration.Parameters) {
				_writer.Write(comma);
				param.Accept(this);
				comma = ",";
			}
			_writer.Write(")");

			jsFunctionDeclaration.FunctionBody.Accept(this);
		}

		//Variable
		public void Generate(JSVariable jsVariable)
		{
			_writer.Write(jsVariable.Name);
		}

		//Expression
		public void Generate(JSExpression jsExpression)
		{
			jsExpression.Accept(this);
		}

		//PrimaryExpression
		public void Generate(JSPrimaryExpression jsPrimaryExpression)
		{
			_writer.Write(jsPrimaryExpression.Identifier);
		}

		//BinaryExpression
		public void Generate(JSBinaryExpression jsBinaryExpression)
		{
			jsBinaryExpression.Lhs.Accept(this);
			WriteSpace();
			jsBinaryExpression.Operator.Accept(this);
			WriteSpace();
			jsBinaryExpression.Rhs.Accept(this);
		}

		//CallExpression
		public void Generate(JSCallExpression jsCallExpression) 
		{
			_writer.Write(jsCallExpression.Identifier);
			_writer.Write("(");

			var comma = "";
			foreach (var argument in jsCallExpression.Arguments) {
				_writer.Write(comma);
				argument.Accept(this);
				comma = ",";
			}

			_writer.Write(")");
		}

		//UnaryExpression
		public void Generate(JSUnaryExpression jsUnaryExpression)
		{
			var opType = jsUnaryExpression.Operator.Type;

			if(opType == UnaryOperatorType.PostfixDecrement || opType == UnaryOperatorType.PostfixIncrement) 
			{
				jsUnaryExpression.Expression.Accept(this);
				jsUnaryExpression.Operator.Accept(this);
			}
			else
			{
				jsUnaryExpression.Operator.Accept(this);
				jsUnaryExpression.Expression.Accept(this);
			}
		}

		//Operator
		public void Generate(JSOperator jsOperator)
		{
			jsOperator.Accept(this);
		}

		//UnaryOperator
		public void Generate(JSUnaryOperator jsUnaryOperator)
		{
			_writer.Write(jsUnaryOperator.Sign);
		}

		//BinaryOperator
		public void Generate(JSBinaryOperator jsBinaryOperator)
		{
			_writer.Write(jsBinaryOperator.Sign);
		}

		//Program
		public void Generate(JSProgram jsProgram)
		{
			throw new NotImplementedException();
		}

	}
}
