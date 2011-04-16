class Point7 {
	int x, y, useCount;
	Point7(int x, int y) { this.x = x; this.y = y; }
	final static Point7 origin = new Point7(0, 0);
}
class StaticField {
	public static void main(String[] args) {
		Point7 p = new Point7(1,1);
		Point7 q = new Point7(2,2);
		p.x = 3; p.y = 3; p.useCount++; p.origin.useCount++;
		System.out.println("(" + q.x + "," + q.y + ")");
		System.out.println(q.useCount);
		System.out.println(q.origin == Point7.origin);
		System.out.println(q.origin.useCount);
	}
}