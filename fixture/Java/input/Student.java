public class Student {
	private String _name;
	
	public Student(String name) {
		_name = name;
	}
	
	public String getName() {
		return _name;
	}
	
	public static void main(String[] args) {
		Student[] students = new Student[2];
		students[0] = new Student("Tom");
		students[1] = new Student("Anna");
		
		for (int i = 0; i < 2; i++) {
			System.out.println(students[i].getName());
		}
		for (Student student : students) {
			System.out.println(student.getName());
		}
	}
}
