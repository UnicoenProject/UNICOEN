using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Languages.C.Model;

namespace Ucpf.Languages.C.Model
{
	public class CProgram
	{
		// constructor
		public CProgram(XElement progNode) {
			throw new NotImplementedException();
		}

		// properties
		public IList<IFunction> Functions { get; set; }
		// TODO :: add other statements (e.g. global variable decralation ...etc)
		

	}
}
