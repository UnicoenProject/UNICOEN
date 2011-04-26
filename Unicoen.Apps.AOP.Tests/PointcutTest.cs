using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.AOP.Tests {
	/// <summary>
	/// アスペクトが正しく織り込まれているかテストする。
	/// </summary>
	[TestFixture]
	class PointcutTest {
		private const string FilePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Fibonacci.java";
		private const string PathOfStudent =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Student.java";

		
		public UnifiedProgram CreateModel(string path) {
			var ext = Path.GetExtension(path);
			var code = File.ReadAllText(path, XEncoding.SJIS);
			return Program.CreateModel(ext, code);
		}

		[Test]
		public void WeavingAtFunctionBeforeCorrectly() {
			var model = CreateModel(FilePath);
			var actual = JavaModelFactory.Instance.Generate("public class Fibonacci { public static int fibonacci(int n) { { Console.Write(); } if (n < 2) { return n; } else { return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			
			CodeProcessor.InsertBeforeAllFunction(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtFunctionAfterCorrectly() {
			var model = CreateModel(FilePath);
			var actual = JavaModelFactory.Instance.Generate("public class Fibonacci { public static int fibonacci(int n) { if (n < 2) { { Console.Write(); } return n; } else { { Console.Write(); } return fibonacci(n - 1) + fibonacci(n - 2); } } }");
			
			CodeProcessor.InsertAfterAllFunction(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtCallBeforeCorrectly() {
			var model = CreateModel(PathOfStudent);
			var actual = JavaModelFactory.Instance.Generate("public class Student { private String _name; public Student(String name) { _name = name; } public String getName() { return _name; } public static void write(String name) { } public static void main(String[] args) { Student[] students = new Student[2]; students[0] = new Student(\"Tom\"); students[1] = new Student(\"Anna\"); for (int i = 0; i < 2; i++) {  {Console.Write();} write(students[i].getName()); } for (Student student : students) { {Console.Write();} write(student.getName()); } } }");

			CodeProcessor.InsertBeforeAllCall(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		[Test]
		public void WeavingAtCallAfterCorrectly() {
			var model = CreateModel(PathOfStudent);
			var actual = JavaModelFactory.Instance.Generate("public class Student { private String _name; public Student(String name) { _name = name; } public String getName() { return _name; } public static void write(String name) { } public static void main(String[] args) { Student[] students = new Student[2]; students[0] = new Student(\"Tom\"); students[1] = new Student(\"Anna\"); for (int i = 0; i < 2; i++) { write(students[i].getName()); {Console.Write();} } for (Student student : students) { write(student.getName()); {Console.Write();} } } }");

			CodeProcessor.InsertAfterAllCall(model, "{Console.Write();}");

			//TODO ToString()しないと比較できないか
			Assert.That(model.ToString(), Is.EqualTo(actual.ToString()));
		}

		//TODO 多項式中や関数の引数として現れるUnifiedCallに対しては、処理が行われないことを確認するテストを書く
	}
}
