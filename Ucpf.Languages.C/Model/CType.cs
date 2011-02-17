using System;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel;

namespace Ucpf.Languages.C.Model {
	public class CType : IType {
		// constructor
		public CType(string name) {
			Name = name;
		}

		public string Name { get; set; }

		// acceptor

		#region IType Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		string IType.Name {
			get { return Name; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}