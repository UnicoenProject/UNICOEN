public class Human {
	String myName;
	int myAge;

	public void SetName(String name) {
		myName = name;
	}

	public String GetName() {
		return myName;
	}

	public void SetAge(int age) {
		myAge = age;
	}

	public int GetAge() {
		return myAge;
	}
}

class HumanTest {
	public static void main(String[] args) {
		Human tanaka = new Human(); // �c������I�u�W�F�N�g�����
		tanaka.SetName("Tanaka"); // �c������̖��O��ݒ肷��
		tanaka.SetAge(26); // �c������̔N���ݒ肷��

		Human suzuki = new Human(); // ��؂���I�u�W�F�N�g�����
		suzuki.SetName("Suzuki"); // ��؂���̖��O��ݒ肷��
		suzuki.SetAge(32); // ��؂���̔N���ݒ肷��

		System.out.println(tanaka.GetName());
		System.out.println(tanaka.GetAge());
		System.out.println(suzuki.GetName());
		System.out.println(suzuki.GetAge());
	}
}

class Human2 {
	String myName;
	int myAge;

	Human2(String name) {
		myName = name;
	}

	public void SetName(String name) {
		myName = name;
	}

	public String GetName() {
		return myName;
	}

	public void SetAge(int age) {
		myAge = age;
	}

	public int GetAge() {
		return myAge;
	}
}

class Member extends Human {
	int myNumber;

	public void SetNumber(int number) {
		myNumber = number;
	}

	public int GetNumber() {
		return myNumber;
	}
}

class Member2 extends Human2 {
	Member2() {
		super("tanaka"); // �e�N���X�̃R���X�g���N�^���Ăяo��
		super.SetAge(26); // �e�N���X�̃��\�b�h���Ăяo��
		String s = super.myName; // �e�N���X�̑������Q�Ƃ���
	}
}