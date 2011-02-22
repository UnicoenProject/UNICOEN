
public class Student {
	
	private String _name;
	
	public Student(String name) {
		_name = name;
	}
	
	public String getName() {
		return _name;
	}
	
	public static void main(String[] args) {
		Student[] list = new Student[4];
		list[0] = new Student("Tom");
		list[1] = new Student("Anna");
		
		for(int i = 0; i < 2; i++) {
			System.out.println(list[i].getName());
		}
	}
}
