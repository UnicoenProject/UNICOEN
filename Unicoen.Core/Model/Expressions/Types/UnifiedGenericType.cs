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
	public class UnifiedGenericType : UnifiedWrapType {
		private UnifiedTypeArgumentCollection _arguments;

		/// <summary>
		///   ジェネリックタイプにおける実引数の集合を表します
		///   e.g. Javaにおける<c>HashMap&lt;Integer, String&gt;</c>の<c>Integer, String</c>
		/// </summary>
		public UnifiedTypeArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		internal UnifiedGenericType() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Arguments;
			yield return Type;
		}

		public override IEnumerable<ElementReference> GetElementReferences() {
			yield return
					ElementReference.Create(
							() => Arguments, v => Arguments = (UnifiedTypeArgumentCollection)v);
			yield return ElementReference.Create(() => Type, v => Type = (UnifiedType)v);
		}

		public override IEnumerable<ElementReference> GetElementReferencesOfFields() {
			yield return
					ElementReference.Create(
							() => _arguments, v => _arguments = (UnifiedTypeArgumentCollection)v);
			yield return
					ElementReference.Create(() => _type, v => _type = (UnifiedType)v);
		}
	}
}