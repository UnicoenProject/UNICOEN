using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 識別子の種類を表します。
	/// </summary>
	public enum UnifiedIdentifierType {
		Variable,
		Type,
		NameSpace,
		Function,
		Class,
		Super,
		Unknown
	}
}
