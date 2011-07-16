using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.Ruby18.Model {
	public class RubyModelFactoryHelper {
		Dictionary<> 

		public static IUnifiedExpression CreateBlock(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
		}
	}
}
