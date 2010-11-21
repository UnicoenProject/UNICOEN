using System.Collections.Generic;
using System.Xml.Linq;
using Antlr.Runtime;

namespace Ucpf.Languages.Common.Antlr
{
	public abstract class XParser : Parser
	{
		public readonly IList<XElement> Elements = new List<XElement>();

		public string LeaveElementName
		{
			get;
			set;
		}

		protected XParser(ITokenStream input)
			: base(input)
		{
		}

		protected XParser(ITokenStream input, RecognizerSharedState state)
			: base(input, state)
		{
		}
	}
}


