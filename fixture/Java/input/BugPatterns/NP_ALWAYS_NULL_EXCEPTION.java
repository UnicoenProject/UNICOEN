package src;

public class NP_ALWAYS_NULL_EXCEPTION{
	public void func(boolean b){
		String str = null;
		try{
			if(b){
				throw new Exception();
			}
		}catch(Exception e){
			if(str.length() > 0){	//NP_ALWAYS_NULL_EXCEPTION 優先度 中
				str = "STRING";
			}
		}
	}

	public static void main(String[] args){
		NP_ALWAYS_NULL_EXCEPTION sl = new NP_ALWAYS_NULL_EXCEPTION();
		sl.func(false);
	}
}
