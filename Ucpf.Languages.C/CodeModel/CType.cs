using Ucpf.CodeModel;

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
	}
}
