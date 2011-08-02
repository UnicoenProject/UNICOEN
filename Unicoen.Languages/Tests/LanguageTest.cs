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
using System.Text;
using NUnit.Framework;
using Paraiba.IO;
using Paraiba.Linq;
using Paraiba.Text;
using UniUni.Text;
using Unicoen.Model;
using Unicoen.Tests;

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

		private Tuple<string, UnifiedProgram> GenerateCodeObject(string path) {
			var code = GuessEncoding.ReadAllText(path);
			var obj = Fixture.ModelFactory.Generate(code);
			return Tuple.Create(code, obj);
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "code">検査対象のソースコード</param>
		public void VerifyCodeObjectFeatureUsingCode(string code) {
			var codeObject = Fixture.ModelFactory.Generate(code);
			AssertModelFeature(codeObject, "no file");
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "path">検査対象のソースコードのパス</param>
		public void VerifyCodeObjectFeatureUsingFile(string path) {
			var codeAndObject = GenerateCodeObject(path);
			AssertModelFeature(codeAndObject.Item2, path);
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して，
		///   生成した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "dirPath">検査対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "compileAction">使用しません</param>
		public void VerifyCodeObjectFeatureUsingProject(
				string dirPath, Action<string, string> compileAction) {
			var paths = Fixture.GetAllSourceFilePaths(dirPath);
			foreach (var path in paths) {
				var codeAndObject = GenerateCodeObject(path);
				AssertModelFeature(codeAndObject.Item2, path);
			}
		}

		/// <summary>
		///   再生成を行わずAssertCompareModelが正常に動作するかテストします。
		///   全く同じコードから生成したモデル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public void VerifyAssertCompareModel(string orgPath) {
			var expected = GenerateCodeObject(orgPath);
			var actual = GenerateCodeObject(orgPath);
			Assert.That(
					actual.Item2,
					Is.EqualTo(expected.Item2).Using(
							StructuralEqualityComparerForDebug.Instance));
		}

		/// <summary>
		///   再生成を行わずAssertCompareCompiledCodeが正常に動作するかテストします。
		///   全く同じコードをコンパイルしたバイナリファイル同士で比較します。
		/// </summary>
		/// <param name = "orgPath">再生成するソースコードのパス</param>
		public void VerifyAssertCompareCompiledCode(string orgPath) {
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			var fileName = Path.GetFileName(orgPath);
			var srcPath = FixtureUtil.GetOutputPath(fileName);
			File.Copy(orgPath, srcPath);
			Fixture.Compile(workPath, srcPath);
			var expected = Fixture.GetAllCompiledCode(workPath);
			Fixture.Compile(workPath, srcPath);
			var actual = Fixture.GetAllCompiledCode(workPath);
			Assert.That(FuzzyCompare(actual, expected), Is.True);
		}

		/// <summary>
		///   指定したソースコードから統一コードオブジェクトを生成して，
		///   ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name = "code">検査対象のソースコード</param>
		public void VerifyRegenerateCodeUsingCode(string code) {
			var codeObject = Fixture.ModelFactory.Generate(code);
			AssertCompareModel(code, codeObject);
			AssertCompareCompiledCode(code, "A" + Fixture.Extension, codeObject);
		}

		/// <summary>
		///   指定したパスのソースコードの統一コードオブジェクトを生成して，
		///   ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name = "path">検査対象のソースコードのパス</param>
		public void VerifyRegenerateCodeUsingFile(string path) {
			var codeAndObject = GenerateCodeObject(path);
			var code = codeAndObject.Item1;
			var codeObject = codeAndObject.Item2;
			AssertCompareModel(code, codeObject);
			AssertCompareCompiledCode(code, Path.GetFileName(path), codeObject);
		}

		/// <summary>
		///   指定したディレクトリ内のソースコードから統一コードオブジェクトを生成して，
		///   ソースコードと統一コードオブジェクトを正常に再生成できるか検査します．
		/// </summary>
		/// <param name = "dirPath">検査対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "compileActionByWorkAndDirPath">コンパイル処理</param>
		public void VerifyRegenerateCodeUsingProject(
				string dirPath, Action<string, string> compileActionByWorkAndDirPath) {
			// コンパイル用の作業ディレクトリの取得
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			// 作業ディレクトリ内にソースコードを配置
			FileUtility.CopyRecursively(dirPath, workPath);
			// 作業ディレクトリ内でコンパイル
			compileActionByWorkAndDirPath(workPath, dirPath);
			// コンパイル結果の取得
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			var codePaths = Fixture.GetAllSourceFilePaths(workPath);
			foreach (var codePath in codePaths) {
				var orgCode1 = GuessEncoding.ReadAllText(codePath);

				// モデルを生成して，合わせて各種検査を実施する
				var codeAndObject = GenerateCodeObject(codePath);
				AssertCompareModel(orgCode1, codeAndObject.Item2);

				var code2 = Fixture.CodeFactory.Generate(codeAndObject.Item2);
				File.WriteAllText(codePath, code2, XEncoding.SJIS);
			}
			// 再生成したソースコードのコンパイル結果の取得
			compileActionByWorkAndDirPath(workPath, dirPath);
			var byteCode2 = Fixture.GetAllCompiledCode(workPath);
			Assert.That(FuzzyCompare(orgByteCode1, byteCode2), Is.True);
		}

		/// <summary>
		///   指定した統一コードオブジェクトが適切な性質を備えているか検査します．
		/// </summary>
		/// <param name = "codeObject">検査対象の統一コードオブジェクト</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertModelFeature(
				UnifiedProgram codeObject, string message) {
			AssertDeepCopy(codeObject, message);
			AssertGetElements(codeObject, message);
			AssertGetElementReferences(codeObject, message);
			AssertGetElementReferenecesOfFields(codeObject, message);
			AssertParentProperty(codeObject, message);
			AssertToString(codeObject, message);
		}

		/// <summary>
		///   深いコピーが正常に動作するか検査します．
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertDeepCopy(UnifiedProgram codeObject, string message) {
			var copiedModel = codeObject.DeepCopy();
			Assert.That(
					copiedModel,
					Is.EqualTo(codeObject).Using(StructuralEqualityComparerForDebug.Instance));

			var pairs = copiedModel.Descendants().Zip(codeObject.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.Null, message);
				Assert.That(
						ReferenceEquals(pair.Item1.Parent, pair.Item2.Parent), Is.False, message);
				//Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent), message);
			}
		}

		/// <summary>
		///   子要素の列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertGetElements(
				UnifiedProgram codeObject, string message) {
			foreach (var element in codeObject.Descendants()) {
				var elements = element.Elements();
				var references = element.ElementReferences();
				var referenecesOfPrivateFields =
						element.ElementReferencesOfFields();
				var propValues = GetProperties(element).ToList();
				var refElements = references.Select(t => t.Element).ToList();
				var privateRefElements =
						referenecesOfPrivateFields.Select(t => t.Element).ToList();
				Assert.That(elements, Is.EqualTo(propValues), message);
				Assert.That(refElements, Is.EqualTo(propValues), message);
				Assert.That(privateRefElements, Is.EqualTo(propValues), message);
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
			if (element is UnifiedWrapType) {
				props = props.Where(prop => prop.Name != "BasicTypeName");
			}
			foreach (var prop in props) {
				yield return (IUnifiedElement)prop.GetValue(element, null);
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertGetElementReferences(
				UnifiedProgram codeObject, string message) {
			codeObject = codeObject.DeepCopy();
			var elements = codeObject.Descendants().ToList();
			foreach (var element in elements) {
				var references = element.ElementReferences();
				foreach (var reference in references) {
					reference.Element = null;
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.Elements()) {
					Assert.That(child, Is.Null, message);
				}
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertGetElementReferenecesOfFields(
				UnifiedProgram codeObject, string message) {
			codeObject = codeObject.DeepCopy();
			var elements = codeObject.Descendants().ToList();
			foreach (var element in elements) {
				var references = element.ElementReferencesOfFields();
				foreach (var reference in references) {
					reference.Element = null;
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.Elements()) {
					Assert.That(child, Is.Null, message);
				}
			}
		}

		/// <summary>
		///   親要素に不適切な要素がないかソースコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertParentProperty(
				IUnifiedElement codeObject, string message) {
			foreach (var element in codeObject.Elements()) {
				if (element != null) {
					Assert.That(element.Parent, Is.SameAs(codeObject), message);
					AssertParentProperty(element, message);
				}
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定して検査します。
		/// </summary>
		/// <param name = "codeObject">検査対象のモデル</param>
		/// <param name = "message">アサーションに違反した際のエラーメッセージ</param>
		private static void AssertToString(UnifiedProgram codeObject, string message) {
			foreach (var element in codeObject.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null, message);
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
			string code2 = null, code3 = null;
			try {
				code2 = Fixture.CodeFactory.Generate(codeObject);
				var obj2 = Fixture.ModelFactory.Generate(code2);
				code3 = Fixture.CodeFactory.Generate(obj2);
				var obj3 = Fixture.ModelFactory.Generate(code3);
				Assert.That(
						obj3,
						Is.EqualTo(obj2).Using(StructuralEqualityComparerForDebug.Instance));
			} catch {
				var outPath = FixtureUtil.GetOutputPath();
				File.WriteAllText(Path.Combine(outPath, "orgignal.txt"), orgCode);
				if (code2 != null)
					File.WriteAllText(Path.Combine(outPath, "generate.txt"), code2);
				if (code3 != null)
					File.WriteAllText(Path.Combine(outPath, "regenerate.txt"), code3);
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
		private void AssertCompareCompiledCode(
				string orgCode, string fileName, UnifiedProgram codeObject) {
			// コンパイル用の作業ディレクトリの取得
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			// 作業ディレクトリ内にソースコードを配置
			var srcPath = FixtureUtil.GetOutputPath(fileName);
			File.WriteAllText(srcPath, orgCode, XEncoding.SJIS);
			// 作業ディレクトリ内でコンパイル
			Fixture.Compile(workPath, srcPath);
			// コンパイル結果の取得
			var orgByteCode1 = Fixture.GetAllCompiledCode(workPath);
			// 再生成したソースコードを配置
			var code2 = Fixture.CodeFactory.Generate(codeObject);
			File.WriteAllText(srcPath, code2, XEncoding.SJIS);
			// 再生成したソースコードのコンパイル結果の取得
			Fixture.Compile(workPath, srcPath);
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