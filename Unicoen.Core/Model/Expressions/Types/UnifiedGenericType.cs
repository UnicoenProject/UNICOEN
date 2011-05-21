using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model{
	public class UnifiedGenericType : UnifiedType {
		private UnifiedType _type;

		/// <summary>
		///   修飾しているベースとなる型を取得します．
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}
		private UnifiedTypeArgumentCollection _arguments;

		/// <summary>
		///   ジェネリックタイプにおける実引数の集合を表します
		///   e.g. Javaにおける<c>HashMap&ltInteger, String&gt</c>の<c>Integer, String</c>
		/// </summary>
		public UnifiedTypeArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		internal UnifiedGenericType() { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TState>(
				IUnifiedModelVisitor<TState> visitor, TState state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TState, TResult>(
				IUnifiedModelVisitor<TState, TResult> visitor, TState state) {
			return visitor.Visit(this, state);
		}
	}
}
