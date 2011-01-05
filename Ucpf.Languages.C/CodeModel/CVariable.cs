using Ucpf.Common.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public class CVariable : IVariable
	{
		public string Name { get; private set; }
		public CType Type { get; private set; }

		// constructor
		public CVariable(CType type, string name)
		{
			Name = name;
			Type = type;
		}

		// acceptor
		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}


		string IVariable.Name
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

		IType IVariable.Type
		{
			get
			{
				return Type;
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
