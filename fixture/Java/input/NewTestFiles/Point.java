class Point {
        static int numPoints;                   // numPoints is a class variable
        int x, y;                               // x and y are instance variables
        int[] w = new int[10];                  // w[0] is an array component
        int setX(int x) {                       // x is a method parameter
                int oldx = this.x;              // oldx is a local variable
                this.x = x;
                return oldx;
        }
}