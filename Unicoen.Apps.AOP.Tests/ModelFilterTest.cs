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

using System.IO;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   アスペクト指向プログラミング処理系の作成に辺り，
	///   共通コードモデル上の特定の要素だけを取得できるかテストする．
	/// </summary>
	[TestFixture]
	public class ModelFilterTest {
		private const string filePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Block1.java";

		private string _ext;
		private string _code;
		private UnifiedProgram _model;

		[SetUp]
		public void Setup() {
			_ext = Path.GetExtension(filePath);
			_code = File.ReadAllText(filePath, XEncoding.SJIS);
			_model = Program.CreateModel(_ext, _code);
		}

		[Test]
		[TestCase("method1")]
		public void GetFunctionDefinitionByName(string name) {
			var e = CodeProcessor.GetFunctionDefinitionByName(_model, name);
			Assert.That(e.Name.Value, Is.EqualTo(name));
		}
	}
}