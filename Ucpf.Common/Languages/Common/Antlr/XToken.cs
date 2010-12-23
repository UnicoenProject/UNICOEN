using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace Ucpf.Languages.Common.Antlr
{
	public class XToken : IToken {
		private readonly IToken _token;

		public XToken(IToken token, string name) {
			_token = token;
			Name = name;
		}

		public string Name { private set; get; }

		public int Type {
			get { return _token.Type; }
			set { _token.Type = value; }
		}

		public int Line {
			get { return _token.Line; }
			set { _token.Line = value; }
		}

		public int CharPositionInLine {
			get { return _token.CharPositionInLine; }
			set { _token.CharPositionInLine = value; }
		}

		public int Channel {
			get { return _token.Channel; }
			set { _token.Channel = value; }
		}

		public int TokenIndex {
			get { return _token.TokenIndex; }
			set { _token.TokenIndex = value; }
		}

		public string Text {
			get { return _token.Text; }
			set { _token.Text = value; }
		}
	}
}
