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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	public static class ModelExtensionsForVisitor {
		public static void TryAccept<TElement>(
				this TElement element, IUnifiedVisitor visitor)
				where TElement : class, IUnifiedElement {
			if (element != null)
				element.Accept(visitor);
		}

		public static TResult TryAccept<TElement, TResult, TArg>(
				this TElement element, IUnifiedVisitor<TResult, TArg> visitor, TArg arg)
				where TElement : class, IUnifiedElement {
			if (element != null)
				return element.Accept(visitor, arg);
			return default(TResult);
		}
	}
}