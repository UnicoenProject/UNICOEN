using Ucpf.Languages.C.CodeModel.Expressions;

namespace Ucpf.Languages.C.CodeModel
{
	public class CConstant : CExpression
	{
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}


		// constructor
		public CConstant(string name) : base(null, "const")
		{
			Name = name;
		}
	}
}