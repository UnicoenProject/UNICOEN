class Array {
        public static void main(String[] args) {
                int[] ia = new int[3];
                int[] ib = new int[6];
                System.out.println(ia.getClass() == ib.getClass());
                System.out.println("ia has length=" + ia.length);
        }
}