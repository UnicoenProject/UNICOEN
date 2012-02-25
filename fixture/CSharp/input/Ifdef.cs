#define DEBUG
using System;

class A :
#if DEBUG
	Object
#else
	ArrayList
#endif
{
	public bool Equals(
#if DEBUG
		int
#else
		string
#endif
		value)
	{
		return true;
	}

}

