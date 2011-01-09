using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model
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
		public void Accept(IModelToCode conv) {
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
	}
}
