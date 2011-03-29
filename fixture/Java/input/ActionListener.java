import java.awt.event.ActionEvent;
import java.util.EventListener;

public interface ActionListener extends EventListener {
	public void actionPerformed(ActionEvent e);
}

interface InterfaceA {
	public abstract void methodA(String msg);

	public abstract void methodB(int x);
}

class InterfaceTest implements InterfaceA {
	public static void main(String[] args) {
		InterfaceTest o = new InterfaceTest();
		o.methodA("ABC");
		o.methodB(123);
	}

	public void methodA(String msg) {
		System.out.println(msg);
	}

	public void methodB(int x) {
		System.out.println(x);
	}
}