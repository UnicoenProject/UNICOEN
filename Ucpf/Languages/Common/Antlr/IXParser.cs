using System.Collections.Generic;
using System.Xml.Linq;
using Antlr.Runtime.Tree;

namespace Ucpf.Languages.Common.Antlr {
	public interface IXParser {
		IList<XElement> ElementList { get; }
		string LeaveElementName { get; set; }
		ITreeAdaptor TreeAdaptor { get; set; }
	}
}