using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Core.Model;
using Unicoen.Languages.Java;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Translator.Tests {
	public class TestForRewriter {
		private UnifiedProgram _program;
		[SetUp]
		public void SetUp() {
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			_program = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void メソッド名を書き換えられる() {
			Console.WriteLine(JavaFactory.GenerateCode(_program));
			
			var functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			var f = FunctionFinder.Instance.FindByName("getName", functions).ElementAt(0);		// getName()
			Rewriter.Instance.RewiteIdentifierName("getName2", f);

			
			functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			f = functions.ElementAt(0);
			Assert.That(f.Name.Value, Is.EqualTo("getName2"));

			Console.WriteLine(JavaFactory.GenerateCode(_program));
		}

		[Test]
		public void メソッドを削除できる() {
			Console.WriteLine(JavaFactory.GenerateCode(_program));

			var functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			var f = FunctionFinder.Instance.FindByName("getName", functions).ElementAt(0);		// getName()
			Rewriter.Instance.RewiteIdentifierName("getName2", f);


			functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			f = functions.ElementAt(0);
			Rewriter.Instance.DeleteElement(f);	

			Console.WriteLine(JavaFactory.GenerateCode(_program));
		}

		[Test]
		public void 要素を付け替えられる() {
			var newType = UnifiedType.CreateUsingString("Integer");
			
			var functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(_program);
			var f = functions.ElementAt(0);
			var type = f.Type;
			Console.WriteLine(type.Name);
			Console.WriteLine(newType.Name);
			Rewriter.Instance.ExchageElement(type, newType);

			

			Console.WriteLine(JavaFactory.GenerateCode(_program));
		}
	}
}
