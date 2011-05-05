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

namespace Unicoen.Core.Model {
	public static class ModelGenerator {
		/// <summary>
		///   �[���R�s�[���擾���܂��D
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "self"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T self)
				where T : IUnifiedElement {
			return (T)self.PrivateDeepCopy();
		}
	}
}