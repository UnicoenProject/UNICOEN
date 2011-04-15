class Point {
        int x, y;

        Point(int x, int y) { this.x = x; this.y = y; }

        public String toString() { return "("+x+","+y+")"; }
}

interface Colorable { void setColor(int color); }

class ColoredPoint extends Point implements Colorable
{
        int color;


        ColoredPoint(int x, int y, int color) {
                super(x, y); setColor(color);
        }

        public void setColor(int color) { this.color = color; }

        public String toString() {
                return super.toString() + "@" + color;
        }

}

class CastConversionTest {
        public static void main(String[] args) {
                Point[] pa = new ColoredPoint[4];
                pa[0] = new ColoredPoint(2, 2, 12);
                pa[1] = new ColoredPoint(4, 5, 24);
                ColoredPoint[] cpa = (ColoredPoint[])pa;
                System.out.print("cpa: {");
                for (int i = 0; i < cpa.length; i++)
                        System.out.print((i == 0 ? " " : ", ") + cpa[i]);
                System.out.println(" }");
        }

}