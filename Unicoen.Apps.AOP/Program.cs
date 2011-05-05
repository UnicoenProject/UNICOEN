using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java;

namespace Unicoen.Apps.Aop {
	public class Program {

		public static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpFactory.GenerateModel(code);
			case ".java":
				return JavaFactory.GenerateModel(code);
			}
			return null;
		}

		private static void Main(string[] args) {
			/* parameters
			 *  :  args[0] -> filePath
			 */
			//var filePath = args[0];
			const string filePath =
					@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Student.java";

			var ext = Path.GetExtension(filePath);
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var model = CreateModel(ext, code);

			CodeProcessor.InsertAtAfterCallAll(model, "{Console.Write();}");
			Console.Write(JavaFactory.GenerateCode(model));
		}
	}
}
