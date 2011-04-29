using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Languages.C.CodeFactories
{
	public class Decoration
	{
		/// <summary>
		///   左端の文字
		/// </summary>
		public string MostLeft;

		/// <summary>
		///   右端の文字
		/// </summary>
		public string MostRight;

		/// <summary>
		///   各要素の直前
		/// </summary>
		public string EachLeft;

		/// <summary>
		///   各要素の直後
		/// </summary>
		public string EachRight;

		/// <summary>
		///   区切り文字
		/// </summary>
		public string Delimiter;

		public Decoration() {
			MostLeft = "";
			MostRight = "";
			EachLeft = "";
			EachRight = "";
			Delimiter = "";
		}
	}
}
