class MyException extends Exception {
	public String errMsg;

	MyException(String msg) {
		errMsg = msg;
	}
}

class ThrowTest {
	public static void main(String[] args) {
		try {
			methodA();
		} catch (MyException e) {
			System.out.println(e.errMsg);
		}
	}

	static void methodA() throws MyException {
		MyException e = new MyException("ÉGÉâÅ[î≠ê∂!!");
		throw e;
	}
}