namespace Ucpf.Languages.C.CodeModel
{
	public class CNumericArgument : CArgument
	{
		private int _num;
		public override string Name
		{
			get
			{
				return _num.ToString();
			}
			set	{}
		}

		// constructors
		public CNumericArgument(int num)
		{
			_num = num;
		}

		public CNumericArgument(string snum)
		{
			_num = int.Parse(snum);
		}
	}
}
