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
using Paraiba.Text;
using Unicoen.Core.Comparers;
using Unicoen.Core.Model;

namespace Unicoen.Core.Tests {
	public class StructuralEqualityComparerForDebug : IEqualityComparer<object> {
		public static StructuralEqualityComparerForDebug Instance =
				new StructuralEqualityComparerForDebug();

		bool IEqualityComparer<object>.Equals(object x, object y) {
			var result = StructuralEqualityComparer.StructuralEquals(x, y);
			if (result)
				return true;
			var x2 = x as IUnifiedElement;
			if (x2 != null) {
				File.WriteAllText(
						FixtureUtil.GetTemporalPath("model1.txt"), x2.ToString(), XEncoding.SJIS);
			}
			var y2 = y as IUnifiedElement;
			if (y2 != null) {
				File.WriteAllText(
						FixtureUtil.GetTemporalPath("model2.txt"), y2.ToString(), XEncoding.SJIS);
			}
			return false;
		}

		public int GetHashCode(object obj) {
			return StructuralEqualityComparer.Instance.GetHashCode(obj);
		}
	}
}