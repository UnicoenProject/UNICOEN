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
		///   catch節の集合を表します
		///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>
		/// </summary>
		public UnifiedCatchCollection Catches {
			get { return _catches; }
			set { _catches = SetParentOfChild(value, _catches); }
		}

		private UnifiedBlock _elseBody;

		/// <summary>
		///   else節を表します
		///   e.g. Pythonにおける<c>try: ...  else: ... finally: ...</c>の<c>else: ...</c>
		/// </summary>
		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetParentOfChild(value, _elseBody); }
		}

		private UnifiedBlock _finallyBody;

		/// <summary>
		///   finally節を表します
		///   e.g. Javaにおける<c>try{...}catch(Exception e){...}finally{...}</c>の<c>finally{...}</c>
		/// </summary>
		public UnifiedBlock FinallyBody {
			get { return _finallyBody; }
			set { _finallyBody = SetParentOfChild(value, _finallyBody); }
		}

		private UnifiedTry() {}

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
			yield return Catches;
			yield return ElseBody;
			yield return FinallyBody;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Catches, v => Catches = (UnifiedCatchCollection)v);
			yield return ElementReference.Create
					(() => ElseBody, v => ElseBody = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => FinallyBody, v => FinallyBody = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _catches, v => _catches = (UnifiedCatchCollection)v);
			yield return ElementReference.Create
					(() => _elseBody, v => _elseBody = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => _finallyBody, v => _finallyBody = (UnifiedBlock)v);
			yield return ElementReference.Create
					(() => _body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedTry Create(
				UnifiedBlock body,
				UnifiedCatchCollection catches,
				UnifiedBlock finallyBody) {
			return Create(body, catches, null, finallyBody);
		}

		public static UnifiedTry Create(
				UnifiedBlock body, UnifiedCatchCollection catches, UnifiedBlock elseBody,
				UnifiedBlock finallyBody) {
			return new UnifiedTry {
					Body = body,
					Catches = catches,
					ElseBody = elseBody,
					FinallyBody = finallyBody,
			};
		}
	}
}