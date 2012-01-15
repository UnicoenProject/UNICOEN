package src;

public class NULL_SAMPLE {
	public static void main(String[] args){
		String st = null;
		Integer in = null;
		Boolean bool = null;
		Boolean np = true;
		int abc = 0;
		double def;

		System.out.println(st + in + bool);
		
		abc = 2;
		st = "STRING";
		in = 100;
		bool = false;
		np = null;
		abc = in;
		in = 200;

		System.out.println(st + in + bool);
	}
}