using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.AstGenerators {
	[ContractClass(typeof(AstGeneratorContract))]
	public abstract class AstGenerator {
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public XElement GenerateFromFile(string path) {
			Contract.Requires(path != null);
			using (var reader = new StreamReader(path)) {
				return Generate(reader);
			}
		}

		public abstract XElement Generate(TextReader reader);

		public virtual XElement Generate(string code) {
			Contract.Requires(code != null);
			using (var reader = new StringReader(code)) {
				return Generate(reader);
			}
		}
	}

	[ContractClassFor(typeof(AstGenerator))]
	abstract class AstGeneratorContract : AstGenerator {

		public override string ParserName
		{
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new System.NotImplementedException();
			}
		}

		public override IEnumerable<string> TargetExtensions
		{
			get {
				Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);
				Contract.Ensures(Contract.Result<IEnumerable<string>>().Count() > 0);
				throw new System.NotImplementedException();
			}
		}

		public override XElement Generate(TextReader reader)
		{
			Contract.Requires(reader != null);
			throw new System.NotImplementedException();
		}
	}
}