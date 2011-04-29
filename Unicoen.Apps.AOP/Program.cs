#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Aop {
	public class Program {
		public static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpModelFactory.CreateModel(code);
			case ".java":
				return JavaModelFactory.Instance.Generate(code);
			}
			return null;
		}

		private static void Main(string[] args) {
			/* parameters
			 *  :  args[0] -> filePath
			 */
			//var filePath = args[0];
			const string filePath =
					@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Fibonacci.java";

			var ext = Path.GetExtension(filePath);
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var model = CreateModel(ext, code);

			CodeProcessor.InsertAfterAllFunction(model, "{Console.Write();}");
			Console.Write(JavaCodeFactory.Instance.Generate(model));
		}
	}
}