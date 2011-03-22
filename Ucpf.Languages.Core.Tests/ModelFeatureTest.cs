using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;

namespace Ucpf.Languages.Core.Tests {
	public static class ModelFeatureTest {
		public static void VerifyParentProperty(UnifiedElement parent) {
			foreach (var element in parent.GetElements()) {
				if (element != null) {
					element.Parent.IsSameReferenceAs(parent);
					VerifyParentProperty(element);
				}
			}
		}
	}
}
