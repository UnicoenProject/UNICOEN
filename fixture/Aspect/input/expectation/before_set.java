public class Sample {

    private int x;

    public Sample(int x) {
        this.x = x;
    }

    public int getX() {
        return x;
    }

    public static void main(String[] args) {
    	{System.out.println("executed");}
    	int a = 10;
    	int b = a;
        getX();
    }

}