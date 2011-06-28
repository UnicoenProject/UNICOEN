public class Sample {
    private static int x;
    public Sample(int x) {
        this.x = x;
    }
    public static int getX() {
        return x;
    }
    public static void main(String[] args) {
        getX();
    }
}