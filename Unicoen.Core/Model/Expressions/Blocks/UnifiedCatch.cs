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
	///   catch節を表します。
	///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>の部分
	/// </summary>
	public class UnifiedCatch : UnifiedExpressionWithBlock<UnifiedCatch> {
		private UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetParentOfChild(value, _parameters); }
		}

		private UnifiedCatch() {}

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
			yield return Parameters;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Parameters, v => _parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedCatch Create(
				UnifiedParameterCollection definition,
				UnifiedBlock body) {
			return new UnifiedCatch {
					Parameters = definition,
					Body = body,
			};
		}
	}
}