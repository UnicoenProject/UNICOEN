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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.IO;
using Paraiba.Linq;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Tests;

namespace Unicoen.Languages.Tests {
	public class LanguageTest {
		public Fixture Fixture { get; set; }

		/// <summary>
		///   テスト対象のソースコードの集合を取得します．
		/// </summary>
		public IEnumerable<TestCaseData> TestCodes {
			get { return Fixture.TestCodes; }
		}

		/// <summary>
		///   テスト対象のソースコードのパスの集合を取得します．
		/// </summary>
		public IEnumerable<TestCaseData> TestFilePathes {
			get { return Fixture.TestFilePathes; }
		}

		/// <summary>
		///   テスト対象のプロジェクトのパスとコンパイルのコマンドと引数の集合を取得します．
		/// </summary>
		public IEnumerable<TestCaseData> TestProjectInfos {
			get { return Fixture.TestProjectInfos; }
		}

		public LanguageTest(Fixture fixture) {
			Fixture = fixture;
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "code">検査対象のソースコード</param>
		public void VerifyCodeObjectFeatureUsingCode(string code) {
			VerifyCodeObjectFeature(code, "A" + Fixture.Extension);
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "path">検査対象のソースコードのパス</param>
		public void VerifyCodeObjectFeatureUsingFile(string path) {
			VerifyCodeObjectFeature(File.ReadAllText(path, XEncoding.SJIS), Path.GetFileName(path));
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "code">検査対象のソースコード</param>
		/// <param name = "fileName"></param>
		private void VerifyCodeObjectFeature(string code, string fileName) {
			var codeObject = Fixture.ModelFactory.Generate(code);
			AssertModelFeature(codeObject);
			AssertCompareModel(code, codeObject);
			AssertCompareCompiledCode(code, fileName, codeObject);
		}

		/// <summary>
		///   指定したディレクトリ内のソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "dirPath">検査対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "compileAction">使用しません</param>
		public void VerifyCodeObjectFeatureUsingProject(string dirPath, Action<string> compileAction) {
			// コンパイル用の作業ディレクトリの取得
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			// 作業ディレクトリ内にソースコードを配置
			FileUtility.CopyRecursively(dirPath, workPath);
			// 作業ディレクトリ内でコンパイル
			compileAction(workPath);
			// コンパイル結果の取得
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			var codePaths = Fixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = File.ReadAllText(codePath, XEncoding.SJIS);

				// モデルを生成して，合わせて各種検査を実施する
				var codeObject = Fixture.ModelFactory.Generate(orgCode1);
				AssertModelFeature(codeObject);
				AssertCompareModel(orgCode1, codeObject);

				var code2 = Fixture.CodeFactory.Generate(codeObject);
				File.WriteAllText(codePath, code2, XEncoding.SJIS);
			}
			// 再生成したソースコードのコンパイル結果の取得
			compileAction(workPath);
			var byteCode2 = Fixture.GetAllCompiledCode(workPath);
			Assert.That(FuzzyCompare(orgByteCode1, byteCode2), Is.True);
		}

		/// <summary>
		///   指定した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "codeObject">検査対象の統一コードオブジェクト</param>
		private static void AssertModelFeature(UnifiedProgram codeObject) {
			AssertDeepCopy(codeObject);
			AssertGetElements(codeObject);
			AssertGetElementReferences(codeObject);
			AssertGetElementReferenecesOfFields(codeObject);
			AssertParentProperty(codeObject);
			AssertToString(codeObject);
		}

		/// <summary>
		///   深いコピーが正常に動作するか検査します．
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertDeepCopy(UnifiedProgram codeObject) {
			var copiedModel = codeObject.DeepCopy();
			Assert.That(
					copiedModel,
					Is.EqualTo(codeObject).Using(StructuralEqualityComparerForDebug.Instance));

			var pairs = copiedModel.Descendants().Zip(codeObject.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.Null);
				Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent));
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertGetElements(UnifiedProgram codeObject) {
			foreach (var element in codeObject.Descendants()) {
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

		private static IEnumerable<IUnifiedElement> GetProperties(IUnifiedElement element) {
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
			if (element is UnifiedWrapType) {
				props = props.Where(prop => prop.Name != "NameExpression");
			}
			foreach (var prop in props) {
				yield return (IUnifiedElement)prop.GetValue(element, null);
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertGetElementReferences(UnifiedProgram codeObject) {
			codeObject = codeObject.DeepCopy();
			var elements = codeObject.Descendants().ToList();
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
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertGetElementReferenecesOfFields(UnifiedProgram codeObject) {
			codeObject = codeObject.DeepCopy();
			var elements = codeObject.Descendants().ToList();
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
		///   親要素に不適切な要素がないかソースコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertParentProperty(IUnifiedElement codeObject) {
			foreach (var element in codeObject.GetElements()) {
				if (element != null) {
					Assert.That(element.Parent, Is.SameAs(codeObject));
					AssertParentProperty(element);
				}
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		private static void AssertToString(UnifiedProgram codeObject) {
			foreach (var element in codeObject.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null);
			}
		}

		/// <summary>
		///   モデルを通した再生成したコードが変化しないか検査します。
		///   元コード1→モデル1→コード2→モデル2→コード3→モデル3と再生成します。
		///   モデル2とモデル3を比較します。
		/// </summary>
		/// <param name = "orgCode">検査対象のソースコード</param>
		/// <param name = "codeObject">検査対象のモデル</param>
		private void AssertCompareModel(string orgCode, UnifiedProgram codeObject) {
			var code2 = Fixture.CodeFactory.Generate(codeObject);
			var obj2 = Fixture.ModelFactory.Generate(code2);
			var code3 = Fixture.CodeFactory.Generate(obj2);
			var obj3 = Fixture.ModelFactory.Generate(code3);
			try {
				Assert.That(
						obj3,
						Is.EqualTo(obj2).Using(StructuralEqualityComparerForDebug.Instance));
			} catch (Exception) {
				var outPath = FixtureUtil.GetOutputPath();
				File.WriteAllText(orgCode, Path.Combine(outPath, "orgignal.txt"));
				File.WriteAllText(code2, Path.Combine(outPath, "generate.txt"));
				File.WriteAllText(code3, Path.Combine(outPath, "regenerate.txt"));
				throw;
			}
		}

		/// <summary>
		///   コンパイル結果を通して再生成したコードが変化しないかテストします。
		///   元コード1→モデル1→コード2と再生成します。
		///   コンパイルしたアセンブリファイルの逆コンパイル結果を通して、
		///   元コード1とコード2を比較します。
		/// </summary>
		/// <param name = "orgCode">検査対象のソースコード</param>
		/// <param name = "fileName">再生成するソースコードのファイル名</param>
		/// <param name = "codeObject">検査対象のモデル</param>
		private void AssertCompareCompiledCode(string orgCode, string fileName, UnifiedProgram codeObject) {
			// コンパイル用の作業ディレクトリの取得
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			// 作業ディレクトリ内にソースコードを配置
			var srcPath = FixtureUtil.GetOutputPath(fileName);
			File.WriteAllText(srcPath, orgCode, XEncoding.SJIS);
			// 作業ディレクトリ内でコンパイル
			Fixture.Compile(workPath, fileName);
			// コンパイル結果の取得
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			// 再生成したソースコードを配置
			var code2 = Fixture.CodeFactory.Generate(codeObject);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			// 再生成したソースコードのコンパイル結果の取得
			Fixture.Compile(workPath, fileName);
			var byteCode2 = Fixture.GetAllCompiledCode(workPath);
			Assert.That(FuzzyCompare(orgByteCode1, byteCode2), Is.True);
		}

		/// <summary>
		///   閾値（許容する不一致文字の数）を設けてバイトコード同士を比較します．
		/// </summary>
		/// <param name = "actual"></param>
		/// <param name = "expected"></param>
		/// <returns></returns>
		private bool FuzzyCompare(
				IEnumerable<Tuple<string, byte[]>> actual,
				IEnumerable<Tuple<string, byte[]>> expected) {
			var actuals = actual.ToList();
			var expecteds = expected.ToList();
			if (actuals.Count != expecteds.Count)
				return false;
			for (int i = 0; i < actuals.Count; i++) {
				if (actuals[i].Item1 != expecteds[i].Item1)
					return false;
				if (!FuzzyCompare(actuals[i].Item2, expecteds[i].Item2))
					return false;
			}
			return true;
		}

		/// <summary>
		///   閾値（許容する不一致文字の数）を設けてバイトコード同士を比較します．
		/// </summary>
		/// <param name = "actual"></param>
		/// <param name = "expected"></param>
		/// <returns></returns>
		private bool FuzzyCompare(byte[] actual, byte[] expected) {
			if (actual.Length != expected.Length)
				return false;
			var count = Fixture.AllowedMismatchCount;
			for (int i = 0; i < actual.Length; i++) {
				if (actual[i] != expected[i] && --count < 0)
					return false;
			}
			return true;
		}
	}
}