interface Colorable5 {
	void setColor(int color);
	int getColor();
}
enum Finish {MATTE, GLOSSY}
interface Paintable extends Colorable5 {
	void setFinish(Finish finish);
	Finish getFinish();
}
class Point5 { int x, y; }
class ColoredPoint5 extends Point5 implements Colorable5 {
	int color;
	public void setColor(int color) { this.color = color; }
	public int getColor() { return color; }
}
class PaintedPoint extends ColoredPoint5 implements Paintable
{
	Finish finish;
	public void setFinish(Finish finish) {
		this.finish = finish;
	}
	public Finish getFinish() { return finish; }
}