interface Colorable {
        void setColor(byte r, byte g, byte b);
}
class Point { int x, y; }
class ColoredPoint extends Point implements Colorable {
        byte r, g, b;
        public void setColor(byte rv, byte gv, byte bv) {
                r = rv; g = gv; b = bv;
        }
}
class InterfaceTest {
        public static void main(String[] args) {
                Point p = new Point();
                ColoredPoint cp = new ColoredPoint();
                p = cp;
                Colorable c = cp;
        }
}