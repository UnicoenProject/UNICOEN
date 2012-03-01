#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Diagnostics;
using Unicoen.CodeGenerators;
using Unicoen.Processor;

namespace Unicoen.Model {
	public static class ModelExtensionsForVisitor {
		[DebuggerStepThrough]
		public static void TryAcceptAllChildren<TElement>(
				this TElement element, IUnifiedVisitor visitor)
				where TElement : UnifiedElement {
			foreach (var child in element.Elements()) {
				child.TryAccept(visitor);
			}
		}

		[DebuggerStepThrough]
		public static void TryAcceptAllChildren<TElement, TArg>(
				this TElement element, IUnifiedVisitor<TArg> visitor, TArg arg)
				where TElement : UnifiedElement {
			foreach (var child in element.Elements()) {
				child.TryAccept(visitor, arg);
			}
		}

		[DebuggerStepThrough]
		public static void TryAcceptAllChildren<TElement, TArg, TResult>(
				this TElement element, IUnifiedVisitor<TArg, TResult> visitor,
				TArg arg)
				where TElement : UnifiedElement {
			foreach (var child in element.Elements()) {
				child.TryAccept(visitor, arg);
			}
		}

		[DebuggerStepThrough]
		public static void TryAccept<TElement>(
				this TElement element, IUnifiedVisitor visitor)
				where TElement : UnifiedElement {
			if (element != null) {
				element.Accept(visitor);
			}
		}

		[DebuggerStepThrough]
		public static void TryAccept<TElement, TArg>(
				this TElement element, IUnifiedVisitor<TArg> visitor, TArg arg)
				where TElement : UnifiedElement {
			if (element != null) {
				element.Accept(visitor, arg);
			}
		}

		[DebuggerStepThrough]
		public static TResult TryAccept<TElement, TArg, TResult>(
				this TElement element, IUnifiedVisitor<TArg, TResult> visitor,
				TArg arg)
				where TElement : UnifiedElement {
			if (element == null) {
				return default(TResult);
			}
			return element.Accept(visitor, arg);
		}

		[DebuggerStepThrough]
		public static bool TryAccept<TElement>(
				this TElement element, JavaLikeCodeFactoryVisitor visitor,
				VisitorArgument arg, string mostLeft)
				where TElement : UnifiedElement {
			if (element == null) {
				return default(bool);
			}
			visitor.Writer.Write(mostLeft);
			var ret = element.Accept(visitor, arg);
			return ret;
		}

		[DebuggerStepThrough]
		public static bool TryAccept<TElement>(
				this TElement element, JavaLikeCodeFactoryVisitor visitor,
				VisitorArgument arg, string mostLeft, string mostRight)
				where TElement : UnifiedElement {
			if (element == null) {
				return default(bool);
			}
			visitor.Writer.Write(mostLeft);
			var ret = element.Accept(visitor, arg);
			visitor.Writer.Write(mostRight);
			return ret;
		}
	}
}