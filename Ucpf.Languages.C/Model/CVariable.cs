using System;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel;

using Ucpf.Common.Visitors;

namespace Ucpf.Languages.C.Model {
	public class CVariable : IVariable {
		public CVariable(CType type, string name) {
			Name = name;
			Type = type;
		}

		public string Name { get; private set; }
		public CType Type { get; private set; }

		// constructor

		// acceptor

		#region IVariable Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		string IVariable.Name {
			get { return Name; }
			set { throw new NotImplementedException(); }
		}

		IType IVariable.Type {
			get { return Type; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}