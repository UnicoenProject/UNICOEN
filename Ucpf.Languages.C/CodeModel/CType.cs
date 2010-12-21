﻿using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public class CType : IType
	{
		public string Name { get; set; }

		// constructor
		public CType(string name)
		{
			Name = name;
		}

		// acceptor
		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		string IType.Name
		{
			get
			{
				return Name;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
