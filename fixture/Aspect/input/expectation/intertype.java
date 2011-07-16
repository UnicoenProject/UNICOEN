public class Sample {

    private int y = 10;
    public int getY() {
        return y;
    }

    private int x;

    public Sample(int x) {
        this.x = x;
    }

    public int getX() {
        return x;
    }

    public static void main(String[] args) {
    	int a = 10;
    	int b = a;
        getX();
    }

}