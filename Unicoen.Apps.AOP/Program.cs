using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.AOP {
	public class Program {

		private static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpModelFactory.CreateModel(code);
			case ".java":
				return JavaModelFactoryHelper.CreateModel(code);
			}
			return null;
		}

		private static void Main(string[] args) {
			/* parameters
			 *  :  args[0] -> filePath
			 */
			//var filePath = args[0];
			const string filePath =
					@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Block1.java";

			var ext = Path.GetExtension(filePath);
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var model = CreateModel(ext, code);

			foreach (var e in model.Descendants()) {
				if(e is UnifiedBinaryExpression)
					Console.Write(e.ToString());
			}
		}
	}
}
