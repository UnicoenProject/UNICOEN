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
using System.Linq;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   if文を表します。
	///   e.g. Javaにおける<c>if(cond){...}else{...}</c>
	/// </summary>
	public class UnifiedIf : UnifiedExpressionWithBlock<UnifiedIf> {
		private IUnifiedExpression _condition;

		/// <summary>
		/// 条件式を表します
		/// <c>if(cond){...}else{...}</c>の<c>con</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private UnifiedBlock _falseBody;

		public UnifiedBlock FalseBody {
			get { return _falseBody; }
			set { _falseBody = SetParentOfChild(value, _falseBody); }
		}

		private UnifiedIf() {}

		public UnifiedIf AddToFalseBody(IUnifiedExpression expression) {
			FalseBody.Add(expression);
			return this;
		}

		public UnifiedIf RemoveFalseBody() {
			FalseBody = null;
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			// TODO: Fix to proper order
			yield return Condition;
			yield return FalseBody;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(FalseBody, v => FalseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_falseBody, v => _falseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedIf Create(UnifiedBlock body) {
			return new UnifiedIf {
					Body = body,
			};
		}

		public static UnifiedIf Create(
				IUnifiedExpression condition, UnifiedBlock body) {
			return new UnifiedIf {
					Body = body,
					Condition = condition,
			};
		}

		public static UnifiedIf Create(
				IEnumerable<Tuple<IUnifiedExpression, UnifiedBlock>> conditionAndBodies,
				UnifiedBlock lastFalseBody) {
			var ifs = conditionAndBodies
					.Select(t => Create(t.Item1, t.Item2))
					.ToList();
			for (int i = 1; i < ifs.Count; i++) {
				ifs[i - 1].FalseBody = ifs[i].ToBlock();
			}
			if (lastFalseBody != null) {
				ifs[ifs.Count - 1].FalseBody = lastFalseBody;
			}
			return ifs[0];
		}

		public static UnifiedIf Create(IUnifiedExpression condition) {
			return new UnifiedIf {
					Condition = condition,
			};
		}

		public static UnifiedIf Create(
				IUnifiedExpression condition, UnifiedBlock body,
				UnifiedBlock falseBody) {
			return new UnifiedIf {
					Body = body,
					Condition = condition,
					FalseBody = falseBody,
			};
		}
	}
}