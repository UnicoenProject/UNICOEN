using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Paraiba.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Core.Tests {
	public abstract class ModelFeatureTest {
		protected abstract UnifiedProgram CreateModel(string code);

		/// <summary>
		///   深いコピーが正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyDeepCopy(string code) {
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
		///   子要素の列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyGetElements(string code) {
			var model = CreateModel(code);
			foreach (var element in model.Descendants()) {
				var elements = element.GetElements();
				var elementAndSetters = element.GetElementAndSetters();
				var elementAndDirectSetters = element.GetElementAndDirectSetters();
				var propValues = GetProperties(element);
				Assert.That(elements, Is.EqualTo(propValues));
				Assert.That(elementAndSetters.Select(t => t.Item1), Is.EqualTo(propValues));
				Assert.That(elementAndDirectSetters.Select(t => t.Item1),
						Is.EqualTo(propValues));
			}
		}

		/// <summary>
		///   子要素とセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyGetElementAndSetters(string code) {
			var model = CreateModel(code);
			var elements = model.Descendants().ToList();
			foreach (var element in elements) {
				var elementAndSetters = element.GetElementAndSetters();
				foreach (var elementAndSetter in elementAndSetters) {
					elementAndSetter.Item2(null);
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.GetElements()) {
					Assert.That(child, Is.Null);
				}
			}
		}

		/// <summary>
		///   子要素とプロパティを介さないセッターの列挙機能が正常に動作するかソースーコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyGetElementAndDirectSetters(string code) {
			var model = CreateModel(code);
			var elements = model.Descendants().ToList();
			foreach (var element in elements) {
				var elementAndSetters = element.GetElementAndDirectSetters();
				foreach (var elementAndSetter in elementAndSetters) {
					elementAndSetter.Item2(null);
				}
			}
			foreach (var element in elements) {
				foreach (var child in element.GetElements()) {
					Assert.That(child, Is.Null);
				}
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
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyParentProperty(string code) {
			var model = CreateModel(code);
			VerifyParentProperty(model);
		}

		private static void VerifyParentProperty(IUnifiedElement parent) {
			foreach (var element in parent.GetElements()) {
				if (element != null) {
					Assert.That(element.Parent, Is.SameAs(parent));
					VerifyParentProperty(element);
				}
			}
		}

		/// <summary>
		///   全要素の文字列情報を取得できるかソースコードを指定してテストします。
		/// </summary>
		/// <param name = "code">テスト対象のソースコード</param>
		protected void VerifyToString(string code) {
			var model = CreateModel(code);
			foreach (var element in model.DescendantsAndSelf()) {
				Assert.That(element.ToString(), Is.Not.Null);
			}
		}
	}
}