using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Core.Tests {
	public abstract class ModelFeatureTest {
		protected abstract UnifiedProgram CreateModel(string code);

		/// <summary>
		/// 深いコピーが正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test]
		[TestCaseSource("TestCases")]
		public virtual void VerifyDeepCopy(string path) {
			var code = File.ReadAllText(path);
			var model = CreateModel(code);
			var copiedModel = model.DeepCopy();
			Assert.That(copiedModel, Is.EqualTo(model)
					.Using(StructuralEqualityComparer.Instance));

			var pairs = copiedModel.Descendants().Zip(model.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent));
			}
		}

		/// <summary>
		/// 子要素の列挙機能が正常に動作するかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test]
		[TestCaseSource("TestCases")]
		public virtual void VerifyGetElements(string path) {
			var code = File.ReadAllText(path);
			var model = CreateModel(code);
			foreach (var element in model.Descendants()) {
				var elements = element.GetElements();
				var elementAndSetters = element.GetElementAndSetters().ToList();
				var elementAndDirectSetters = element.GetElementAndDirectSetters().ToList();
				var propValues = GetProperties(element);
				Assert.That(elements, Is.EqualTo(propValues));
				Assert.That(elementAndSetters.Count, Is.EqualTo(propValues.Count()));
				Assert.That(elementAndDirectSetters.Count, Is.EqualTo(propValues.Count()));
			}
		}

		private static IEnumerable<UnifiedElement> GetProperties(UnifiedElement element) {
			var elements = element as IEnumerable<UnifiedElement>;
			if (elements != null) {
				return elements;
			}
			return element.GetType().GetProperties()
					.Where(prop => prop.Name != "Parent")
					.Where(prop => typeof(UnifiedElement).IsAssignableFrom(prop.PropertyType))
					.Select(prop => (UnifiedElement)prop.GetValue(element, null));
		}

		/// <summary>
		/// 親要素が不適切な要素がないかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		[Test]
		[TestCaseSource("TestCases")]
		public virtual void VerifyParentProperty(string path) {
			var code = File.ReadAllText(path);
			var model = CreateModel(code);
			VerifyParentProperty(model);
		}

		private static void VerifyParentProperty(UnifiedElement parent) {
			foreach (var element in parent.GetElements()) {
				if (element != null) {
					Assert.That(element.Parent, Is.SameAs(parent));
					VerifyParentProperty(element);
				}
			}
		}

		/// <summary>
		/// 全要素の文字列情報を取得できるかテストします。
		/// </summary>
		/// <param name="path">テスト対象のソースコードのパス</param>
		public virtual void VerifyToString(string path) {
			var code = File.ReadAllText(path);
			var model = CreateModel(code);
			foreach (var element in model.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null);
			}
		}
	}
}
