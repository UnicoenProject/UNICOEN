using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Text;

namespace Ucpf.Common.AstGenerators {
	[ContractClass(typeof(AstGeneratorContract))]
	public abstract class AstGenerator {
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public XElement GenerateFromFile(string path) {
			Contract.Requires(path != null);
			// TODO: fix encoding
			using (var reader = new StreamReader(path, XEncoding.SJIS)) {
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
	internal abstract class AstGeneratorContract : AstGenerator {
		public override string ParserName {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new NotImplementedException();
			}
		}

		public override IEnumerable<string> TargetExtensions {
			get {
				Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);
				Contract.Ensures(Contract.Result<IEnumerable<string>>().Count() > 0);
				throw new NotImplementedException();
			}
		}

		public override XElement Generate(TextReader reader) {
			Contract.Requires(reader != null);
			throw new NotImplementedException();
		}
	}
}