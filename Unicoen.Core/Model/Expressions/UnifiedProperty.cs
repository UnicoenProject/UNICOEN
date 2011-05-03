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
using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   フィールド、メンバー、プロパティなどへのアクセス式を表します。
	///   Javaにおける<c>int a = b.c</c>の<c>b.c</c>
	/// </summary>
	public class UnifiedProperty : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _owner;

		public IUnifiedExpression Owner {
			get { return _owner; }
			set { _owner = SetParentOfChild(value, _owner); }
		}

		private IUnifiedExpression _name;

		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		public string Delimiter { get; set; }

		private UnifiedProperty() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Owner;
			yield return Name;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Owner, v => Owner = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Name, v => Name = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_owner, v => _owner = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_name, v => _name = (IUnifiedExpression)v);
		}

		public static UnifiedProperty Create(
				IUnifiedExpression owner,
				UnifiedIdentifier name, string delimite) {
			return new UnifiedProperty {
					Owner = owner,
					Name = name,
					Delimiter = delimite,
			};
		}

		public static UnifiedProperty Create(
				IUnifiedExpression owner, string name,
				string delimite) {
			return new UnifiedProperty {
					Owner = owner,
					Name = UnifiedIdentifier.CreateUnknown(name),
					Delimiter = delimite,
			};
		}

		public static UnifiedProperty Create(
				IUnifiedExpression owner,
				IUnifiedExpression name, string delimite) {
			return new UnifiedProperty {
					Owner = owner,
					Name = name,
					Delimiter = delimite,
			};
		}
	}
}