using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   配列型やポインタ型などを表すために型に付加される修飾子を表します。
	///   例えば、"int* p;"の"*"部分が該当します。
	///   例えば、"int[10] a;"の"[10]"部分が該当します。
	///   例えば、"int[10, 10] a;"の"[10, 10]"部分が該当します。
	/// </summary>
	public class UnifiedTypeSupplement : UnifiedElement
	{
		private UnifiedExpressionCollection _values;

		public UnifiedExpressionCollection Values
		{
			get { return _values; }
			set { _values = SetParentOfChild(value, _values); }
		}

		public UnifiedTypeSupplementKind Kind { get; set; }

		private UnifiedTypeSupplement() {}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data)
		{
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Values;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Values, v => Values = (UnifiedExpressionCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_values, v => _values = (UnifiedExpressionCollection)v);
		}

		public static UnifiedTypeSupplement Create(UnifiedExpressionCollection values,
		                                           UnifiedTypeSupplementKind kind)
		{
			// values.Countが2以上の場合はC#の長方形配列を指定してください。
			Contract.Requires(kind == UnifiedTypeSupplementKind.Array && values.Count != 1);
			return new UnifiedTypeSupplement {
				Values = values,
				Kind = kind,
			};
		}

		/// <summary>
		/// 実引数を取らない１次元配列を作成します。
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplement CreateArray()
		{
			return Create(null, UnifiedTypeSupplementKind.Array);
		}

		/// <summary>
		/// 実引数を取る１次元配列を作成します。
		/// </summary>
		/// <returns></returns>
		public static UnifiedTypeSupplement CreateArray(IUnifiedExpression value)
		{
			return Create(value.ToCollection(), UnifiedTypeSupplementKind.Array);
		}
	}
}