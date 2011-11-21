package src;

public class NP_NULL_ON_SOME_PATH_EXCEPTION{
	public void func(boolean a, boolean b) {
		String str = null;
		try{
			if(b){
				throw new Exception();
			}
			str = "STRING";
		}catch(Exception e){
			if(a){
				str = "SSTTRRIINNGG";
			}
		}
		if(str.length() > 0){	//NP_NULL_ON_SOME_PATH_EXCEPTION 優先度 低
			System.out.println(str);
		}
	}

	public static void main(String[] args){
		NP_NULL_ON_SOME_PATH_EXCEPTION sl = new NP_NULL_ON_SOME_PATH_EXCEPTION();
		sl.func(false, true);
	}
}
