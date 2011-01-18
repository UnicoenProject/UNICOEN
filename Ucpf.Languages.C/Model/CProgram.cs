using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Common.Model;

namespace Ucpf.Languages.C.Model {
	public class CProgram {
		// constructor
		public CProgram(XElement progNode) {
			throw new NotImplementedException();
		}

		// properties
		public IList<IFunction> Functions { get; set; }
		// TODO :: add other statements (e.g. global variable decralation ...etc)
	}
}