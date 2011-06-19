public class Student {
	private string _name;

	public Student(string name) {
		_name = name;
	}

	public string getName() {
		return _name;
	}
	
	public static void main(string[] args) {
		Student[] students = new Student[2];
		students[0] = new Student("Tom");
		students[1] = new Student("Anna");
		
		for (int i = 0; i < 2; i++) {
			students[i].getName();
		}
		foreach (Student student in students) {
			student.getName();
		}
	}
}
