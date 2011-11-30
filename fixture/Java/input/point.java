/**File : point.java @author Reisha Humaira (13505047)**/

import java.io.*;
import java.util.Scanner;

class point {
	private int x;
	private int y;
	
	// CONSTRUCTOR
	public point () {
		x = 0; 
		y = 0;
	}
	public point (int Vx, int Vy) {
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
		System.out.print("Abscissa   : ");
		x = sc.nextInt();
		System.out.print("Ordinate : ");
		y = sc.nextInt();
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
	//Return quadrant of P : 1, 2, 3, or 4. P is not at axis
	public int kuadran () {
		if ((x>0) && (y>0)) { 
			return 1;
		} else if ((x<0) && (y>0)) {
			return 2;
		} else if ((x<0) && (y<0)) {
			return 3;
		} else if ((x>0) && (y<0)) {
			return 4;
		} else {
			return -999;
		}
	}
}
