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
using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   Javaにおける<c>int[10] a;</c>の<c>[10]</c>部分、
	///   <c>int[] a;</c>の<c>[]</c>部分などが該当します。
	/// </summary>
	public class UnifiedArrayType : UnifiedWrapType {
		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   実引数の集合を取得します．
		///   e.g. Cにおける<c>new int[10]</c>の<c>10</c>
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		/// <summary>
		///   長方形配列化どうか取得します．
		/// </summary>
		public bool IsRectangleArray {
			get { return _arguments != null && _arguments.Count >= 2; }
		}

		internal UnifiedArrayType() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TState>(
				IUnifiedModelVisitor<TState> visitor, TState arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TState, TResult>(
				IUnifiedModelVisitor<TState, TResult> visitor, TState arg) {
			return visitor.Visit(this, arg);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Arguments;
			yield return Type;
		}

		public override IEnumerable<ElementReference> GetElementReferences() {
			yield return
					ElementReference.Create(
							() => Arguments, v => Arguments = (UnifiedArgumentCollection)v);
			yield return ElementReference.Create(() => Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<ElementReference> GetElementReferencesOfFields() {
			yield return
					ElementReference.Create(
							() => _arguments, v => _arguments = (UnifiedArgumentCollection)v);
			yield return
					ElementReference.Create(() => _type, v => _type = (UnifiedType)v);
		}
	}
}