class Point {
	int x, y, useCount;
	Point(int x, int y) { this.x = x; this.y = y; }
	final static Point origin = new Point(0, 0);
}
class StaticField {
	public static void main(String[] args) {
		Point p = new Point(1,1);
		Point q = new Point(2,2);
		p.x = 3; p.y = 3; p.useCount++; p.origin.useCount++;
		System.out.println("(" + q.x + "," + q.y + ")");
		System.out.println(q.useCount);
		System.out.println(q.origin == Point.origin);
		System.out.println(q.origin.useCount);
	}
}