using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Translator {
	public class FunctionFinder {
		// Singleton!
		public static FunctionFinder Instance = new FunctionFinder();

		public List<UnifiedFunctionDefinition> FindByName(String name, List<UnifiedFunctionDefinition> list) {
			var filteredList = new List<UnifiedFunctionDefinition>();
			
			foreach (var f in list) {
				if(f.Name.Value.Equals(name)) {
					filteredList.Add(f);
				}
			}

			return filteredList;
		}

		public List<UnifiedFunctionDefinition> FindByReturnType(UnifiedType type, List<UnifiedFunctionDefinition> list) {
			var filteredList = new List<UnifiedFunctionDefinition>();

			throw new NotImplementedException();

		}
	}
}
