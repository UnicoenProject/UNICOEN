﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.CodeModel
{
	public interface IReturn : IStatement
	{
		IExpression Return { get; }
	}
}