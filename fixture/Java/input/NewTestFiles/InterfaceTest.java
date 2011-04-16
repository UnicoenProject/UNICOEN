interface Colorable3 {
        void setColor(byte r, byte g, byte b);
}
class Point3 { int x, y; }
class ColoredPoint3 extends Point3 implements Colorable3 {
        byte r, g, b;
        public void setColor(byte rv, byte gv, byte bv) {
                r = rv; g = gv; b = bv;
        }
}
class InterfaceTest {
        public static void main(String[] args) {
                Point3 p = new Point3();
                ColoredPoint3 cp = new ColoredPoint3();
                p = cp;
                Colorable3 c = cp;
        }
}