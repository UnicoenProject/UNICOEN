class Names {
        public static void main(String[] args) {
                Class c = System.out.getClass();
                System.out.println(c.toString().length() +
                                args[0].length() + args.length);
        }
}