using System.IO;
using ICSharpCode.NRefactory.CSharp;
using Unicoen.Core.Model;
using Unicoen.Core.ModelFactories;

namespace Unicoen.Languages.CSharp.ModelFactories {

	public class CSharpModelFactory : ModelFactory {

		public override UnifiedProgram GenerateWithouNormalizing(string code) {
			var parser = new CSharpParser();
			var unit = parser.Parse(new StringReader(code));
			var visitor = new NRefactoryModelVisitor();
			var uElem = unit.AcceptVisitor(visitor, null);
			return uElem as UnifiedProgram;
		}
	}
}
