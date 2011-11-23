/**File : point_modified.java @author Reisha Humaira (13505047)**/

import java.io.*;
import java.util.Scanner;

class point_modified {
	private int x;
	private int y;
	
	// CONSTRUCTOR
	public point_modified () {
		x = 0; 
		y = 0;
	}
	public point_modified (int Vx, int Vy) {
		x = Vx; 
		y = Vy;
	}
	
	// SELECTOR
	
	//Set x value
	public void setX (int px) {
		x = px;
	}
	//Set y value
	public void setY (int py) {
		y = py;
	}
	//Get x value
	public int getX () { 
		return x;
	}
	//Get y value
	public int getY () { 
		return y;
	}
	
	// READ & WRITE
	
	//Read point inputted by user
	public void read () {
		Scanner sc = new Scanner(System.in);
		System.out.print("Enter Abscissa   : ");
		x = sc.nextInt();
		System.out.print("Enter Ordinate : ");
		y = sc.nextInt();
	}
	
	public void translation (int dx, int dy) {
		x += dx;
		y += dy;
	}
	
	//Print point
	public void print () {
		System.out.println("(" + x + "," + y + ")" );
	}
	
	//Return true if P is origin
	public boolean isOrigin () {
		return ((x==0) && (y==0));
	}
	//Return true if P is at X-axis
	public boolean isOnSbX () {
		return (y==0);
	}
	//Return true if P is at Y-axis
	public boolean isOnSbY () {
		return (x==0);
	}
}
