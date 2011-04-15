using System.Collections.Generic;
using System.IO;
using Ucpf.Core.Model;

namespace Ucpf.Core.Tests {
	public class StructuralEqualityComparerForDebug : IEqualityComparer<object> {
		public static StructuralEqualityComparerForDebug Instance =
				new StructuralEqualityComparerForDebug();

		bool IEqualityComparer<object>.Equals(object x, object y) {
			var result = StructuralEqualityComparer.StructuralEquals(x, y);
			if (result)
				return true;
			var x2 = x as IUnifiedElement;
			if (x2 != null) {
				File.WriteAllText(Fixture.GetTemporalPath("model1.txt"), x2.ToString());
			}
			var y2 = y as IUnifiedElement;
			if (y2 != null) {
				File.WriteAllText(Fixture.GetTemporalPath("model2.txt"), y2.ToString());
			}
			return false;
		}

		public int GetHashCode(object obj) {
			return StructuralEqualityComparer.Instance.GetHashCode(obj);
		}
	}
}