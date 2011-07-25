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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   LINQのクエリ式を構成するorderby句を表します。
	///   e.g. C#における<c>orderby p.X, p.Y descending, p.Z ascending</c>
	/// </summary>
	public class UnifiedOrderByQuery : UnifiedLinqQuery {
		private UnifiedOrderByKeyCollection _keys;

		/// <summary>
		///   ソートを行うキーの集合を取得もしくは設定します．
		///   e.g. C#における<c>orderby p.X, p.Y descending, p.Z ascending</c>の<c>p.X, p.Y descending, p.Z ascending</c>
		/// </summary>
		public UnifiedOrderByKeyCollection Keys {
			get { return _keys; }
			set { _keys = SetChild(value, _keys); }
		}

		protected UnifiedOrderByQuery() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedOrderByQuery Create(UnifiedOrderByKeyCollection keys) {
			return new UnifiedOrderByQuery {
					Keys = keys,
			};
		}
	}
}