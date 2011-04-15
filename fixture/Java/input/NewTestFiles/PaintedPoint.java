interface Colorable {
	void setColor(int color);
	int getColor();
}
enum Finish {MATTE, GLOSSY}
interface Paintable extends Colorable {
	void setFinish(Finish finish);
	Finish getFinish();
}
class Point { int x, y; }
class ColoredPoint extends Point implements Colorable {
	int color;
	public void setColor(int color) { this.color = color; }
	public int getColor() { return color; }
}
class PaintedPoint extends ColoredPoint implements Paintable
{
	Finish finish;
	public void setFinish(Finish finish) {
		this.finish = finish;
	}
	public Finish getFinish() { return finish; }
}