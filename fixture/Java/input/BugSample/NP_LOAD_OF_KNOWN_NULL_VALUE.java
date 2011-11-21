package src;

public class NP_LOAD_OF_KNOWN_NULL_VALUE {
	public static void main(String[] args){
		String st1 = "STRING";
		String st2 = null;

		if(st1.equals(st2)){	//NP_LOAD_OF_KNOWN_NULL_VALUE	優先度 低
			System.out.println("HELLO");
		}else{
			System.out.println("NOOOO");
		}
	}
}
