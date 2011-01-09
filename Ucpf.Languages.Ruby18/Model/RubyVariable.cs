using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyVariable : IVariable {
		public RubyVariable(XElement symbol) {
			Contract.Requires(symbol.Name.LocalName == "Symbol");
			Name = symbol.Value;
		}

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public string Name { get; set; }

		public IType Type {
			get { return null; }
			set { new NotSupportedException(); }
		}
	}
}
