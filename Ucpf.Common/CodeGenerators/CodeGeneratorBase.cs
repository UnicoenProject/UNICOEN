﻿using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;

namespace Ucpf.Common.CodeGenerators {
	[ContractClass(typeof(CodeGeneratorBaseContract))]
	public abstract class CodeGeneratorBase : CodeGenerator {
		private readonly StringBuilder _builder;
		private int _depth;
		private bool _indented;

		protected CodeGeneratorBase() {
			_builder = new StringBuilder();
		}

		protected int Depth {
			get { return _depth; }
			set { _depth = value; }
		}

		protected virtual void Initialize() {
			_builder.Length = 0;
			_depth = 0;
			_indented = false;
		}

		protected void WriteWord(string str) {
			Contract.Requires(str != null);
			if (_indented) {
				_builder.Append(' ');
			} else {
				WriteIndent();
			}
			_builder.Append(str);
		}

		protected void WriteWordWithoutWhiteSpace(string str) {
			Contract.Requires(str != null);
			if (!_indented) {
				WriteIndent();
			}
			_builder.Append(str);
		}

		protected void WriteIndent() {
			for (int i = 0; i < _depth; i++) {
				_builder.Append('\t');
			}
			_indented = true;
		}

		protected void WriteLine() {
			_builder.AppendLine();
			_indented = false;
		}

		protected void WriteLine(string str) {
			Contract.Requires(str != null);
			WriteWord(str);
			_builder.AppendLine();
			_indented = false;
		}

		protected void WalkElement(XContainer element) {
			Contract.Requires(element != null);
			foreach (var e in element.Elements()) {
				if (e.HasElements) {
					WalkElement(e);
				} else if (!TreatTerminalSymbol(e) && e.Value != string.Empty) {
					WriteWord(e.Value);
				}
			}
		}

		protected abstract bool TreatTerminalSymbol(XElement element);

		public override string Generate(XElement root) {
			Contract.Requires(root != null);
			Contract.Ensures(Contract.Result<string>() != null);
			Initialize();
			WalkElement(root);
			return _builder.ToString();
		}
	}

	[ContractClassFor(typeof(CodeGeneratorBase))]
	internal abstract class CodeGeneratorBaseContract : CodeGeneratorBase {
		protected override bool TreatTerminalSymbol(XElement element) {
			Contract.Requires(element != null);
			throw new NotImplementedException();
		}
	}
}