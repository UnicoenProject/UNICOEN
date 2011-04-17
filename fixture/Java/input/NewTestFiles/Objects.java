class Point4 {
        int x, y;
        Point4() { System.out.println("default"); }
        Point4(int x, int y) { this.x = x; this.y = y; }
        // A Point instance is explicitly created at class initialization time:
        static Point4 origin = new Point4(0,0);
        // A String can be implicitly created by a + operator:
        public String toString() {
                return "(" + x + "," + y + ")";
        }
}
class Objects {
        public static void main(String[] args) {
                // A Point is explicitly created using newInstance:
                Point4 p = null;
                try {
                        p = (Point4)Class.forName("Point").newInstance();
                } catch (Exception e) {
                        System.out.println(e);
                }
                // An array is implicitly created by an array constructor:
                Point4 a[] = { new Point4(0,0), new Point4(1,1) };
                // Strings are implicitly created by + operators:
                System.out.println("p: " + p);
                System.out.println("a: { " + a[0] + ", "
                                                                                   + a[1] + " }");
                // An array is explicitly created by an array creation expression:
                String sa[] = new String[2];
                sa[0] = "he"; sa[1] = "llo";
                System.out.println(sa[0] + sa[1]);
        }
}