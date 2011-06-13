using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Common.Model;
using System.Xml.Linq;

namespace Unicoen.Languages.Python2 {

	public class PythonModelFactory {

		#region static

		public static UnifiedBlock Create(string code) {
			var factory = new PythonModelFactory();
			var xml = Python2AstGenerator.Instance.Generate(code);
			return factory.CreateBlock(xml);
		}

		#endregion

		public PythonModelFactory() { }

		public UnifiedBlock CreateBlock(XElement elem) {
			return new UnifiedBlock(elem.Elements("stmt").Select(CreateStatement).Where(s => s != null));
		}

		public UnifiedStatement CreateStatement(XElement elem) {
			var stmtType = (string)elem.Elements().First().Name;
			switch (stmtType) {
			
			}
		}
	}

}
