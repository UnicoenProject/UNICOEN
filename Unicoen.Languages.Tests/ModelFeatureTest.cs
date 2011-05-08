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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Linq;
using Paraiba.Text;
using Unicoen.Core.Comparers;
using Unicoen.Core.Model;

namespace Unicoen.Languages.Tests {
	[TestFixture]
	public class ModelFeatureTest {
		protected IEnumerable<TestCaseData> TestCodes {
			get { return LanguageFixtureLoader.AllTestCodes; }
		}

		protected IEnumerable<TestCaseData> TestFilePathes {
			get { return LanguageFixtureLoader.AllTestFilePathes; }
		}

		protected IEnumerable<TestCaseData> TestDirectoryPathes {
			get { return LanguageFixtureLoader.AllTestDirectoryPathes; }
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyDeepCopyUsingCode(LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			var copiedModel = model.DeepCopy();
			Assert.That(
					copiedModel, Is.EqualTo(model)
					             		.Using(StructuralEqualityComparer.Instance));

			var pairs = copiedModel.Descendants().Zip(model.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent));
			}
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyDeepCopyUsingFile(
				LanguageFixture fixture, string path) {
			VerifyDeepCopyUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyDeepCopyUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyDeepCopyUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyGetElementsUsingCode(
				LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			foreach (var element in model.Descendants()) {
				var elements = element.GetElements();
				var references = element.GetElementReferences();
				var referenecesOfPrivateFields =
						element.GetElementReferenecesOfPrivateFields();
				var propValues = GetProperties(element);
				Assert.That(elements, Is.EqualTo(propValues));
				Assert.That(references.Select(t => t.Element), Is.EqualTo(propValues));
				Assert.That(
						referenecesOfPrivateFields.Select(t => t.Element),
						Is.EqualTo(propValues));
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingFile(
				LanguageFixture fixture, string path) {
			VerifyGetElementsUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementsUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementsUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyGetElementAndSettersUsingCode(
				LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			var elements = model.Descendants().ToList();
			foreach (var element in elements) {
				var references = element.GetElementReferences();
				foreach (var reference in references) {
					reference.Element = null;
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.GetElements()) {
					Assert.That(child, Is.Null);
				}
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndSettersUsingFile(
				LanguageFixture fixture, string path) {
			VerifyGetElementAndSettersUsingCode(
					fixture, File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyGetElementAndSettersUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementAndSettersUsingCode(
						fixture, File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyGetElementAndDirectSettersUsingCode(
				LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			var elements = model.Descendants().ToList();
			foreach (var element in elements) {
				var references = element.GetElementReferenecesOfPrivateFields();
				foreach (var reference in references) {
					reference.Element = null;
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.GetElements()) {
					Assert.That(child, Is.Null);
				}
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyGetElementAndDirectSettersUsingFile(
				LanguageFixture fixture, string path) {
			VerifyGetElementAndDirectSettersUsingCode(
					fixture,
					File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyGetElementAndDirectSettersUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementAndDirectSettersUsingCode(
						fixture,
						File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		private static IEnumerable<IUnifiedElement> GetProperties(
				IUnifiedElement element) {
			var elements = element as IEnumerable<IUnifiedElement>;
			if (elements != null) {
				return elements;
			}
			return element.GetType().GetProperties()
					.Where(prop => prop.Name != "Parent")
					.Where(prop => typeof(IUnifiedElement).IsAssignableFrom(prop.PropertyType))
					.Select(prop => (IUnifiedElement)prop.GetValue(element, null));
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyParentPropertyUsingCode(
				LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			VerifyParentPropertyRecusively(model);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyParentPropertyUsingFile(
				LanguageFixture fixture, string path) {
			VerifyParentPropertyUsingCode(
					fixture, File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyParentPropertyUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyParentPropertyUsingCode(
						fixture, File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		private static void VerifyParentPropertyRecusively(IUnifiedElement parent) {
			foreach (var element in parent.GetElements()) {
				if (element != null) {
					Assert.That(element.Parent, Is.SameAs(parent));
					VerifyParentPropertyRecusively(element);
				}
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "code">テスト対象のソースコード</param>
		[Test, TestCaseSource("TestCodes")]
		public void VerifyToStringUsingCode(
				LanguageFixture fixture, string code) {
			var model = fixture.ModelFactory.Generate(code);
			foreach (var element in model.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null);
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		[Test, TestCaseSource("TestFilePathes")]
		public void VerifyToStringUsingFile(
				LanguageFixture fixture, string path) {
			VerifyToStringUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "fixture"></param>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリパス</param>
		/// <param name = "command"></param>
		/// <param name = "arguments"></param>
		[Test, TestCaseSource("TestDirectoryPathes")]
		public void VerifyToStringUsingDirectory(
				LanguageFixture fixture, string dirPath, string command, string arguments) {
			var paths = fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyToStringUsingCode(fixture, File.ReadAllText(path, XEncoding.SJIS));
			}
		}
	}
}