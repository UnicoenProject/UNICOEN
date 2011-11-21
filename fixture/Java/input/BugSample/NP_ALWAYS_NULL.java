package src;

import java.util.LinkedList;

public class NP_ALWAYS_NULL {
	public static void main(String[] args){

		Boolean bool = null;
		method(bool);	//NP_ALWAYS_NULL	優先度 高

		LinkedList<Integer> link = new LinkedList<Integer>();
		LinkedList<String> link2 = null;

		link.add(0);
		link2.add("aasdf");	//NP_ALWAYS_NULL

		System.out.println(link.pop() + link2.pop());

	}
	static Boolean method(boolean n){
		if(n){
			return true;
		}
		return false;
	}
}
