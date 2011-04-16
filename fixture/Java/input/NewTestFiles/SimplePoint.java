abstract class Point6 {
	int x = 1, y = 1;
	void move(int dx, int dy) {
		x += dx;
		y += dy;
		alert();
	}
	abstract void alert();
}
abstract class ColoredPoint6 extends Point6 {
	int color;
}

class SimplePoint extends Point6 {
	void alert() { }
}