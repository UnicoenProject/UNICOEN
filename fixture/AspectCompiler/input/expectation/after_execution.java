public class Sample {

    private int x;

    public Sample(int x) {
        this.x = x;
        {System.out.println("executed");}
    }

    public int getX() {
        return x;
    }

    public static void main(String[] args) {
        Sample instance = new Sample(3);
        getX();
    }

}