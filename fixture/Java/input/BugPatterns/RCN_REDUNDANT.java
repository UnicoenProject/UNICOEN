package src;

public class RCN_REDUNDANT {
	public void method(){
		Boolean n = null;
		Boolean m = null;
		Boolean bool = true;

		if(n == null){	//RCN_REDUNDANT_NULLCHECK_OF_NULL_VALUE	優先度 低
			System.out.println("STRING");
		}

		if(bool != null){
			System.out.println(bool);
			if(bool != null){	//RCN_REDUNDANT_NULLCHECK_OF_NONNULL_VALUE	優先度 低
				System.out.println("BOOLEAN");
				if(bool != m){	//RCN_REDUNDANT_COMPARISON_OF_NULL_AND_NONNULL_VALUE 優先度 低
					System.out.println("NOT NULL");
				}
			}
		}

		if(n == m){	//RCN_REDUNDANT_COMPARISON_TWO_NULL_VALUES	優先度 低
			System.out.println("STRING");
		}
	}

	public static void main(String[] args){
		RCN_REDUNDANT meth = new RCN_REDUNDANT();
		meth.method();
	}
}
