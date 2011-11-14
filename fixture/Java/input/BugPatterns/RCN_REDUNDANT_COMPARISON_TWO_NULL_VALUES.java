package src;

public class RCN_REDUNDANT_COMPARISON_TWO_NULL_VALUES {
	public void method(){
		Boolean n = null;
		Boolean m = null;

		if(n == m){	//RCN_REDUNDANT_COMPARISON_TWO_NULL_VALUES	優先度 低
			System.out.println("STRING");
		}
	}

	public static void main(String[] args){
		RCN_REDUNDANT_COMPARISON_TWO_NULL_VALUES meth = new RCN_REDUNDANT_COMPARISON_TWO_NULL_VALUES();
		meth.method();
	}
}
