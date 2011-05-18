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
	public abstract class ModelFeatureTest : LanguageTestBase {
		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyDeepCopyUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
			var copiedModel = model.DeepCopy();
			Assert.That(
					copiedModel, Is.EqualTo(model).Using(StructuralEqualityComparer.Instance));

			var pairs = copiedModel.Descendants().Zip(model.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent));
			}
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyDeepCopyUsingFile(string path) {
			VerifyDeepCopyUsingCode(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyDeepCopyUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyDeepCopyUsingCode(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyGetElementsUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
			foreach (var element in model.Descendants()) {
				var elements = element.GetElements();
				var references = element.GetElementReferences();
				var referenecesOfPrivateFields =
						element.GetElementReferencesOfFields();
				var propValues = GetProperties(element).ToList();
				var refElements = references.Select(t => t.Element).ToList();
				var privateRefElements =
						referenecesOfPrivateFields.Select(t => t.Element).ToList();
				Assert.That(elements, Is.EqualTo(propValues));
				Assert.That(refElements, Is.EqualTo(propValues));
				Assert.That(privateRefElements, Is.EqualTo(propValues));
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyGetElementsUsingFile(string path) {
			VerifyGetElementsUsingCode(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyGetElementsUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementsUsingCode(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyGetElementReferencesUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
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
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyGetElementReferencesUsingFile(string path) {
			VerifyGetElementReferencesUsingCode(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyGetElementReferencesUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementReferencesUsingCode(File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyGetElementReferenecesOfFieldsUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
			var elements = model.Descendants().ToList();
			foreach (var element in elements) {
				var references = element.GetElementReferencesOfFields();
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
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyGetElementReferenecesOfFieldsUsingFile(string path) {
			VerifyGetElementReferenecesOfFieldsUsingCode(
					File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyGetElementReferenecesOfFieldsUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyGetElementReferenecesOfFieldsUsingCode(
						File.ReadAllText(path, XEncoding.SJIS));
			}
		}

		private static IEnumerable<IUnifiedElement> GetProperties(
				IUnifiedElement element) {
			var elements = element as IEnumerable<IUnifiedElement>;
			if (elements != null) {
				foreach (var e in elements) {
					yield return e;
				}
			}
			var props = element.GetType().GetProperties()
					.Where(prop => prop.Name != "Parent")
					.Where(prop => prop.GetIndexParameters().Length == 0)
					.Where(prop => typeof(IUnifiedElement).IsAssignableFrom(prop.PropertyType));
			foreach (var prop in props) {
				yield return (IUnifiedElement)prop.GetValue(element, null);
			}
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyParentPropertyUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
			VerifyParentPropertyRecusively(model);
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyParentPropertyUsingFile(string path) {
			VerifyParentPropertyUsingCode(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   親要素が不適切な要素がないかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyParentPropertyUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyParentPropertyUsingCode(File.ReadAllText(path, XEncoding.SJIS));
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
		/// <param name = "code">テスト対象のソースコード</param>
		public virtual void VerifyToStringUsingCode(string code) {
			var model = Fixture.ModelFactory.Generate(code);
			foreach (var element in model.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null);
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "path">テスト対象のソースコードのパス</param>
		public virtual void VerifyToStringUsingFile(string path) {
			VerifyToStringUsingCode(File.ReadAllText(path, XEncoding.SJIS));
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードのパスを指定してテストします。
		/// </summary>
		/// <param name = "dirPath">テスト対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "command">使用しません</param>
		/// <param name = "arguments">使用しません</param>
		public virtual void VerifyToStringUsingProject(
				string dirPath, string command, string arguments) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				VerifyToStringUsingCode(File.ReadAllText(path, XEncoding.SJIS));
			}
		}
	}
}