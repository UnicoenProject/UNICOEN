using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.AOP.Tests {
	/// <summary>
	/// アスペクト指向プログラミング処理系の作成に辺り，
	/// 共通コードモデル上の特定の要素だけを取得できるかテストする．
	/// </summary>
	/// 
	[TestFixture]
	public class ModelFilterTest {
		private const string filePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Block1.java";

		private string _ext;
		private string _code;
		private UnifiedProgram _model;

		private static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpModelFactory.CreateModel(code);
			case ".java":
				return JavaModelFactoryHelper.CreateModel(code);
			}
			return null;
		}

		[SetUp]
		public void Setup() {
			_ext = Path.GetExtension(filePath);
			_code = File.ReadAllText(filePath, XEncoding.SJIS);
			_model = CreateModel(_ext, _code);
		}

		[Test]
		public void GetFunctionDefinitionByName(string name) {
			
		}
	}
}
