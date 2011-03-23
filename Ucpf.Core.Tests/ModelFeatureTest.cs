using System.Linq;
using NUnit.Framework;
using Paraiba.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Core.Tests {
	public static class ModelFeatureTest {
		public static void VerifyParentProperty(UnifiedElement parent) {
			foreach (var element in parent.GetElements()) {
				if (element != null) {
					element.Parent.IsSameReferenceAs(parent);
					VerifyParentProperty(element);
				}
			}
		}
	
		public static void VerifyDeepCopy(UnifiedElement model) {
			var copiedModel = model.DeepCopy();
			Assert.That(copiedModel, Is.EqualTo(model)
				.Using(StructuralEqualityComparer.Instance));

			var pairs = copiedModel.Descendants().Zip(model.Descendants());
			foreach (var pair in pairs) {
				Assert.That(pair.Item1.Parent, Is.Not.EqualTo(pair.Item2.Parent));
			}
		}
	}
}
