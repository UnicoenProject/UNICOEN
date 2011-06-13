package LinearSearch;

import java.util.Random;

public class Main {
	public static void main(String[] args){
		Random rand = new Random();
		
		final int N = 10;
		int[] ary = new int[N];
		
		for(int i = 0; i < N - 1; i++){
			ary[i] = rand.nextInt(100);
		}
		
		ary[N - 1] = 100;
		
		dump(ary);
		
		if(search(ary, 100)){
			System.out.println("Found!");
			return;
		}
		
		System.out.println("NotFound!");
		return;
		
		
	}
	
	private static boolean search(int[] ary, int key){
		for(int i = 0; i < ary.length; i++){
			if(ary[i] == key){
				return true;
			}
		}
		
		return false;
	}
	
	private static void dump(int[] ary){
		for(int i : ary){
			System.out.print(i + " ");
		}
		
		System.out.println("");
	}
}
