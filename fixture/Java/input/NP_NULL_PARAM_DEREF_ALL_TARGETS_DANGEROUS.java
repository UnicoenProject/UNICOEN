package src;

public class NP_NULL_PARAM_DEREF_ALL_TARGETS_DANGEROUS {
	public static void main(String[] args){
		CLASS cl = new CLASS();

		boolean bool = cl.method(null, null);	//NP_NULL_PARAM_DEREF_ALL_TARGETS_DANGEROUS	優先度 中

		if(bool == true){
			System.out.println("HELLO");
		}else{
			System.out.println("NOOOO");
		}
	}
}

class CLASS{
	Boolean method(Integer n, Integer m){
		if(n + m > 10){
			return false;
		}else{
			return true;
		}
	}
}
