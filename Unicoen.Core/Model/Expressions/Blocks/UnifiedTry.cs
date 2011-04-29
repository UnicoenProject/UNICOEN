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
	///   try文を表します。
	///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>
	/// </summary>
	public class UnifiedTry : UnifiedExpressionWithBlock<UnifiedTry> {
		private UnifiedCatchCollection _catches;

		/// <summary>
		/// 付随するcatch節の集合を表します
		/// e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>
		/// </summary>
		public UnifiedCatchCollection Catches {
			get { return _catches; }
			set { _catches = SetParentOfChild(value, _catches); }
		}

		private UnifiedBlock _finallyBody;

		/// <summary>
		/// 付随するfinally節を表します
		/// e.g. Javaにおける<c>try{...}catch(Exception e){...}finally{...}</c>の<c>finally{...}</c>
		/// </summary>
		public UnifiedBlock FinallyBody {
			get { return _finallyBody; }
			set { _finallyBody = SetParentOfChild(value, _finallyBody); }
		}

		private UnifiedTry() {
			Body = UnifiedBlock.Create();
			Catches = UnifiedCatchCollection.Create();
			FinallyBody = UnifiedBlock.Create();
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
			yield return Catches;
			yield return FinallyBody;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Catches, v => Catches = (UnifiedCatchCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(FinallyBody, v => FinallyBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Catches, v => _catches = (UnifiedCatchCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(FinallyBody, v => _finallyBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedTry Create(
				UnifiedBlock body,
				UnifiedCatchCollection catches,
				UnifiedBlock finallyBody) {
			return new UnifiedTry {
					Body = body,
					Catches = catches,
					FinallyBody = finallyBody,
			};
		}
	}
}