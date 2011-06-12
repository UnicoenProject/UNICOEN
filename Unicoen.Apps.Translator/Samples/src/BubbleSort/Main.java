package BubbleSort;

import java.util.Random;

public class Main {
	public static void main(String[] args){
		final int N = 10;
		int[] ary = new int[N];
		
		Random random = new Random();
		
		for(int i = 0; i < N; i++){
			ary[i] = random.nextInt(1000);
		}
		
		dump(ary);
		ary = sort(ary);
		System.out.println("----------");
		dump(ary);
	}
	
	public static int[] sort(int[] ary){
		for(int i = ary.length - 1; i >= 0; i--){
			for(int j = 0; j < i; j++){
				if(ary[j] > ary[j + 1]){
					int tmp = ary[j];
					ary[j] = ary[j + 1];
					ary[j + 1] = tmp;
				}
			}
		}
		
		return ary;
	}
	
	public static void dump(int[] ary){
		for(int i = 0; i < ary.length; i++){
			System.out.println(ary[i]);
		}
	}
}
