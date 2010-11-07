using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Common
{
	public interface INamespace {
		IEnumerable<IClass> Classes { get; }
	}

	public interface IClass {
		IEnumerable<IClassModifier> Modifiers { get; }
		IEnumerable<IMethod> Methods { get; }
	}

	public interface IClassModifier {
	}

	public interface IMethod {
		IEnumerable<IMethodModifier> Modifiers { get; }
		IEnumerable<IArgument> Arguments { get; }
		IEnumerable<IStatement> Statements { get; }
	}

	public interface IStatement {
		
	}

	public interface IType {
		
	}

	public interface IArgument {
		IType Type { get; }
	}

	public interface IMethodModifier {
	}

	public class Fibonacci {
		public int Calculate(int n) {
			if (n == 0)
				return 0;
			if (n == 1)
				return 1;
			return Calculate(n - 2) + Calculate(n - 1);
		}
	}
}
