using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Languages.CSharp.CodeFactories {

	public class CSharpCodeStyle {

		public string Indent = "\t";

		public readonly SpaceStyle Space = new SpaceStyle();

		public readonly LineBreakStyle LineBreak = new LineBreakStyle();

		#region StyleGroup

		public class SpaceStyle {
			public bool BeforeBinaryOperation = true;
			public bool AfterBinaryOperation = true;
		}

		public class LineBreakStyle {
			public bool AfterClass = false;
		}

		#endregion

	}
}
