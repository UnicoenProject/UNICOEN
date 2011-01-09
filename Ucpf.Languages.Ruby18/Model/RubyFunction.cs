using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyFunction : IFunction {
		public RubyFunction(XElement defn) {
			Name = defn.Elements().ElementAt(0).Value;
			Parameters = defn.Elements().ElementAt(1).Elements()
				.Select(e => (IVariable)new RubyVariable(e))
				.ToList();
		}

		#region IFunction Members

		public void Accept(IModelToCode conv) {
			throw new NotImplementedException();
		}

		public IType ReturnType { get; set; }

		public string Name { get; set; }

		public IList<IVariable> Parameters { get; set; }

		public IBlock Body {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}