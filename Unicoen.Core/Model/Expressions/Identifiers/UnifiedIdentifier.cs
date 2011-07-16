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

namespace Unicoen.Model {
	/// <summary>
	///   識別子を表します。
	/// </summary>
	public abstract class UnifiedIdentifier : UnifiedElement, IUnifiedExpression {
		/// <summary>
		///   識別子の名前を取得します．
		/// </summary>
		public string Name { get; set; }

		public static UnifiedVariableIdentifier CreateVariable(string name) {
			return UnifiedVariableIdentifier.Create(name);
		}

		public static UnifiedLabelIdentifier CreateLabel(string name) {
			return UnifiedLabelIdentifier.Create(name);
		}

		public static UnifiedSuperIdentifier CreateSuper(string name) {
			return UnifiedSuperIdentifier.Create(name);
		}

		public static UnifiedThisIdentifier CreateThis(string name) {
			return UnifiedThisIdentifier.Create(name);
		}
	}
}