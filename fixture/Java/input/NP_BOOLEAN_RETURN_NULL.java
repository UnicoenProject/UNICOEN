package src;

public class NP_BOOLEAN_RETURN_NULL {
	public static void main(String[] args){
		if(method(10)){
			System.out.println("OK");
		}else{
			System.out.println("NO");
		}
	}
	static Boolean method(int n){
		if(n > 0)
			return true;
		else if(n < 0)
			return false;
		else
			return null;	//NP_BOOLEAN_RETURN_NULL	優先度 中
	}
}
