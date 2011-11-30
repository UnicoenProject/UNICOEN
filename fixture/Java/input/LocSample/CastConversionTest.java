class Point2 {
        int x, y;

        Point2(int x, int y) { this.x = x; this.y = y; }

        public String toString() { return "("+x+","+y+")"; }
}

interface Colorable2 { void setColor(int color); }

class ColoredPoint2 extends Point2 implements Colorable2
{
        int color;


        ColoredPoint2(int x, int y, int color) {
                super(x, y); setColor(color);
        }

        public void setColor(int color) { this.color = color; }

        public String toString() {
                return super.toString() + "@" + color;
        }

}

class CastConversionTest {
        public static void main(String[] args) {
                Point2[] pa = new ColoredPoint2[4];
                pa[0] = new ColoredPoint2(2, 2, 12);
                pa[1] = new ColoredPoint2(4, 5, 24);
                ColoredPoint2[] cpa = (ColoredPoint2[])pa;
                System.out.print("cpa: {");
                for (int i = 0; i < cpa.length; i++)
                        System.out.print((i == 0 ? " " : ", ") + cpa[i]);
                System.out.println(" }");
        }

}