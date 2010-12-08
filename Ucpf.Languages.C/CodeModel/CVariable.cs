namespace Ucpf.Languages.C.CodeModel
{
	public class CVariable
	{
		public string Name;
		public CType Type;

		// constructor
		public CVariable(CType type, string name)
		{
			Name = name;
			Type = type;
		}
	}
}
