﻿#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
	///   ラムダ式の定義部分を表します。
	/// </summary>
	public class UnifiedLambda : UnifiedExpression {
		#region fields

		private UnifiedIdentifier _name;
		private UnifiedSet<UnifiedParameter> _parameters;
		private UnifiedBlock _body;

		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		public UnifiedSet<UnifiedParameter> Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		/// <summary>
		///   ブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		#endregion

		private UnifiedLambda() {}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedLambda Create(
				UnifiedIdentifier name = null,
				UnifiedSet<UnifiedParameter> parameters = null,
				UnifiedBlock body = null) {
			return new UnifiedLambda {
					Name = name,
					Parameters = parameters,
					Body = body,
			};
		}
	}
}