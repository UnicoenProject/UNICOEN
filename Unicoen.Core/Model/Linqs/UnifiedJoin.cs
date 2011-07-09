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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	public class UnifiedJoin : UnifiedLinqElement {
		private IUnifiedExpression _expression;

		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetChild(value, _expression); }
		}

		private IUnifiedExpression _inExpression;

		public IUnifiedExpression InExpression {
			get { return _inExpression; }
			set { _inExpression = SetChild(value, _inExpression); }
		}

		private IUnifiedExpression _onExpression;

		public IUnifiedExpression OnExpression {
			get { return _onExpression; }
			set { _onExpression = SetChild(value, _onExpression); }
		}

		private IUnifiedExpression _equalsExpression;

		public IUnifiedExpression EqualsExpression {
			get { return _equalsExpression; }
			set { _equalsExpression = SetChild(value, _equalsExpression); }
		}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}
	}
}