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
	///   スライス表記を表します．
	///   e.g. Pythonにおける<c>[0 : 10 : 2]</c>
	/// </summary>
	public class UnifiedSlice : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _start;

		/// <summary>
		///   開始インデックスを表します．
		///   e.g. Pythonにおける<c>[0 : 10 : 2]</c>の<c>0</c>
		/// </summary>
		public IUnifiedExpression Start {
			get { return _start; }
			set { _start = SetParentOfChild(value, _start); }
		}

		private IUnifiedExpression _end;

		/// <summary>
		///   終了インデックスを表します．
		///   e.g. Pythonにおける<c>[0 : 10 : 2]</c>の<c>10</c>
		/// </summary>
		public IUnifiedExpression End {
			get { return _end; }
			set { _end = SetParentOfChild(value, _end); }
		}

		private IUnifiedExpression _step;

		/// <summary>
		///   ステップを表します．
		///   e.g. Pythonにおける<c>[0 : 10 : 2]</c>の<c>2</c>
		/// </summary>
		public IUnifiedExpression Step {
			get { return _step; }
			set { _step = SetParentOfChild(value, _step); }
		}

		private UnifiedSlice() {}

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
			yield return Start;
			yield return End;
			yield return Step;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Start, v => Start = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(End, v => End = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Step, v => Step = (IUnifiedExpression)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_start, v => _start = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_end, v => _end = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_step, v => _step = (IUnifiedExpression)v);
		}

		public static UnifiedSlice Create(
				IUnifiedExpression initializer,
				IUnifiedExpression condition,
				IUnifiedExpression step) {
			return new UnifiedSlice {
					Start = initializer,
					End = condition,
					Step = step,
			};
		}
	}
}