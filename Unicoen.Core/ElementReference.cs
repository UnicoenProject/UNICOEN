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

using System;
using Unicoen.Model;

namespace Unicoen {
	public class ElementReference : ElementReference<IUnifiedElement> {
		public ElementReference(
				Func<IUnifiedElement> getter, Action<IUnifiedElement> setter)
				: base(getter, setter) {}

		public new static ElementReference Create(
				Func<IUnifiedElement> getter, Action<IUnifiedElement> setter) {
			return new ElementReference(getter, setter);
		}
	}

	public class ElementReference<T> {
		private readonly Func<T> _getter;
		private readonly Action<T> _setter;

		public ElementReference(Func<T> getter, Action<T> setter) {
			_getter = getter;
			_setter = setter;
		}

		public T Element {
			get { return _getter(); }
			set { _setter(value); }
		}

		public static ElementReference<T> Create(Func<T> getter, Action<T> setter) {
			return new ElementReference<T>(getter, setter);
		}
	}
}