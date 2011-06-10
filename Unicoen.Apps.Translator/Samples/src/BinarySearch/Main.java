package BinarySearch;

import java.util.Arrays;
import java.util.Random;

public class Main {
	public static void main(String[] args){
		Random r = new Random();
		int[] array = new int[5];
		
		for(int i = 0; i < array.length; i++){
			array[i] = r.nextInt(10);
		}
		
		Arrays.sort(array);
		
		int key = 3;
		dumpArray(array);
		int result = binarySearch(key, array);
		
		if(result == -1){
			System.out.println("not found");
		}
		else{
			System.out.println("found @" + result);
		}
	}
	
	public static int binarySearch(int key, int[] array){
		int left = 0;
		int right = array.length - 1;
		
		while(left <= right){
			int middle = (left + right) / 2;
			if(array[middle] == key){
				return middle;
			}
			
			if(key <= array[middle]){
				right = middle - 1;
			}
			else if(key > array[middle]){
				left = middle + 1;
			}
		}
		
		return -1;
	}
	
	public static void dumpArray(int[] array){
		for(int v : array){
			System.out.println(v);
		}
	}
}
