﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CGotoStatement : CJumpStatement
	{
		public CGotoStatement(XElement node) : base(node) { }
	}
}