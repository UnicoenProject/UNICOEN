using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.Model
{
	public class CWhileStatement : CIterationStatement
	{
		public CWhileStatement(XElement node) : base(node) { }
	}
}
