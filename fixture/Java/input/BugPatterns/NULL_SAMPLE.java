package src;

public class NULL_SAMPLE {
	public static void main(String[] args){
		String st = null;
		Integer in = null;
		Boolean bool = null;
		Boolean np = true;

		System.out.println(st + in + bool);

		st = "STRING";
		in = 100;
		bool = false;
		np = null;

		System.out.println(st + in + bool);
	}
}