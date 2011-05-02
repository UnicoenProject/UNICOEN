using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   if文を表します。
	///   e.g. Javaにおける<c>if(cond){...}else{...}</c>
	/// </summary>
	public class UnifiedIfExpression : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;

		/// <summary>
		/// 条件式を表します
		/// <c>if(cond){...}else{...}</c>の<c>con</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private IUnifiedExpression _expression;

		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetParentOfChild(value, _expression); }
		}

		private IUnifiedExpression _elseExpression;

		public IUnifiedExpression ElseExpression {
			get { return _elseExpression; }
			set { _elseExpression = SetParentOfChild(value, _elseExpression); }
		}

		private UnifiedIfExpression() {}

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
			yield return Condition;
			yield return ElseExpression;
			yield return Expression;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(ElseExpression, v => ElseExpression = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Expression, v => Expression = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_elseExpression, v => _elseExpression = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_expression, v => _expression = (UnifiedBlock)v);
		}

		public static UnifiedIfExpression Create(
				IUnifiedExpression condition, IUnifiedExpression expression) {
			return new UnifiedIfExpression {
					Expression = expression,
					Condition = condition,
			};
		}

		public static UnifiedIfExpression Create(
				IUnifiedExpression condition, IUnifiedExpression expression,
				IUnifiedExpression elseExpression) {
			return new UnifiedIfExpression {
					Condition = condition,
					Expression = expression,
					ElseExpression = elseExpression,
			};
		}
	}
}
