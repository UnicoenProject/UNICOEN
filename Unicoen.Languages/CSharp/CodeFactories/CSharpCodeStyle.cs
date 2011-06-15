using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Languages.CSharp.CodeFactories {

	public class CSharpCodeStyle {

		public string Indent { get; set; }

		private readonly SpaceStyle _space = new SpaceStyle();
		public SpaceStyle Space { get { return _space; } }

		public CSharpCodeStyle() {
			Indent = "\t";
		}

		public class SpaceStyle {
			
		}

	}
}
