public class ControlFlow {
	public static void main(String[] args) {
		int a = 3;
		if (a == 3) {
			System.out.println("a is 3.");
		}
		if (a == 3) {
			System.out.println("a is 3.");
		} else {
			System.out.println("a is not 3.");
		}
		if (a == 3) {
			System.out.println("a is 3.");
		} else if (a == 4) {
			System.out.println("a is 4.");
		} else {
			System.out.println("a is unknown.");
		}
		int i;
		for (i = 0; i < 10; i++) {
			System.out.println(i);
		}
		while (i < 10) {
			System.out.println(i);
			i++;
		}
		do {
			System.out.println(i);
			i++;
		} while (i < 10);
		int n = 3;
		switch (n) {
		case 1:
			System.out.println("n is one.");
			break;
		case 2:
			System.out.println("n is two.");
			break;
		case 3:
			System.out.println("n is tree.");
			break;
		default:
			System.out.println("unknwon");
			break;
		}
		for (i = 0; i < 10; i++) {
			if (i == 5) {
				break;
			}
			System.out.println(i);
		}
		System.out.println("finish!!");
		loop1: for (i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				if ((i == 1) && (j == 5)) {
					break loop1;
				}
			}
		}
		for (i = 0; i < 10; i++) {
			if (i == 5) {
				continue;
			}
			System.out.println(i);
		}
	}
}
