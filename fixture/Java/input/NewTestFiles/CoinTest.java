public class CoinTest {
    public static void main(String[] args) {
        for (Coin c : Coin.values())
            System.out.println(c + ": "+ c.value() +"C" + color(c));
    }
    private enum CoinColor { COPPER, NICKEL, SILVER }
    private static CoinColor color(Coin c) {
        switch(c) {
          case PENNY:
            return CoinColor.COPPER;
          case NICKEL:
            return CoinColor.NICKEL;
          case DIME: case QUARTER:
            return CoinColor.SILVER;
          default:
            throw new AssertionError("Unknown coin: " + c);
        }
    }
}
enum Coin {
    PENNY(1), NICKEL(5), DIME(10), QUARTER(25);

    Coin(int value) { this.value = value; }

    private final int value;

    public int value() { return value; }
}