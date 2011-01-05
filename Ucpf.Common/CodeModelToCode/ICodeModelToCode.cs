using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Expressions;
using Ucpf.Common.CodeModel.Operators;
using Ucpf.Common.CodeModel.Statements;

namespace Ucpf.Common.CodeModelToCode
{
	public interface ICodeModelToCode {
		// Function
		void Generate(IFunction func);
		
		// Expression
		void Generate(IExpression exp);
		void Generate(IBinaryExpression exp);
		void Generate(IUnaryExpression exp);
		void Generate(ICallExpression exp);
		void Generate(ITernaryExpression exp);
		void Generate(IAssignmentExpression exp);

		// Operator
		void Generate(IBinaryOperator op);
		void Generate(IUnaryOperator op);
		void Generate(IAssignmentOperator op);
		
		// Statement
		void Generate(IStatement stmt);
		void Generate(IIfStatement stmt);
		void Generate(IReturnStatement stmt);
		void Generate(IExpressionStatement stmt);
		void Generate(IEmptyStatement stmt);

		// Block
		void Generate(IBlock block);

		// Type
		void Generate(IType type);

		// Variable
		void Generate(IVariable variable);



		
	}
}
