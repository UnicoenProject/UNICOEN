class NarrowingPrimitiveConversionsTest {
        public static void main(String[] args) {
                float fmin = Float.NEGATIVE_INFINITY;
                float fmax = Float.POSITIVE_INFINITY;
                System.out.println("long: " + (long)fmin +
                                        ".." + (long)fmax);
                System.out.println("int: " + (int)fmin +
                                        ".." + (int)fmax);
                System.out.println("short: " + (short)fmin +
                                        ".." + (short)fmax);
                System.out.println("char: " + (int)(char)fmin +
                                        ".." + (int)(char)fmax);
                System.out.println("byte: " + (byte)fmin +
                                        ".." + (byte)fmax);
        }
}