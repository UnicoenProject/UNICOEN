using System.Collections.Generic;

namespace Ucpf.Common.Model {
	// OOPと非OOPの差異の吸収方法
	public interface ICallExpression : IExpression {
		string FunctionName { get; set; }
		IList<IExpression> Arguments { get; }
	}
}