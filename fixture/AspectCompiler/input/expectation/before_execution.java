public class Sample {

    private int x;

    public Sample(int x) {
        this.x = x;
    }

    public int getX() {
        {System.out.println("executed");}
        return x;
    }

    public static void main(String[] args) {
        getX();
    }

}