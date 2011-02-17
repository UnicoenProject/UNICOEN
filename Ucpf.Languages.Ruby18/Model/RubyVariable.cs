﻿using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyVariable : IVariable {
		public RubyVariable(XElement symbol) {
			Contract.Requires(symbol.Name.LocalName == "Symbol");
			Name = symbol.Value;
		}

		#region IVariable Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public string Name { get; set; }

		public IType Type {
			get { return null; }
			set { new NotSupportedException(); }
		}

		#endregion
	}
}