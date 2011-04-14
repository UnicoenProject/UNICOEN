using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	/// 変数宣言における修飾子と型を省略した部分を表します。
	/// なお、変数宣言(UnifiedVariableDefinition)は修飾子と型と本クラスの集合クラス(UnifiedVariableDefinitionBodyCollection)によって表現されます。
	/// </summary>
	public class UnifiedVariableDefinitionBody : UnifiedElement
	{
		private UnifiedIdentifier _name;

		/// <summary>
		/// 変数名を表します。
		/// </summary>
		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
		}

		private UnifiedTypeSupplementCollection _supplements;

		/// <summary>
		///   変数名に付随する型情報を表します。
		///   e.g. Javaにおける<c>int[][] a[] = new int[1][1][1];</c>の<c>[]</c>部分
		/// </summary>
		public UnifiedTypeSupplementCollection Supplements
		{
			get { return _supplements; }
			set { _supplements = SetParentOfChild(value, _supplements); }
		}

		private IUnifiedExpression _initialValue;

		/// <summary>
		///   変数の初期化部分を表します。
		///   e.g. Javaにおける<c>int a[] = { 1 };</c>の<c>{ 1 }</c>部分
		///   e.g. C#, Javaにおける<c>int[] a = { 1 };</c>の<c>{ 1 }</c>部分
		///   e.g. C, C++, C#, Javaにおける<c>int i = 1;</c>の<c>{ 1 }</c>部分
		/// </summary>
		public IUnifiedExpression InitialValue
		{
			get { return _initialValue; }
			set { _initialValue = SetParentOfChild(value, _initialValue); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   変数の初期化のコンストラクタ呼び出しを表します。
		///   e.g. C++における<c>Class c(1);</c>
		/// </summary>
		public UnifiedArgumentCollection Arguments
		{
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedBlock _block;

		///<summary>
		///  変数に付随するブロックを表します。
		///  e.g. Javaにおけるenumの定数に付随するブロック
		///  <code>
		///    enum E {
		///      E1 {
		///        @override public String toString() { return ""; }
		///      },
		///      E2
		///    }
		///  </code>
		///</summary>
		public UnifiedBlock Block
		{
			get { return _block; }
			set { _block = SetParentOfChild(value, _block); }
		}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Name;
			yield return InitialValue;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Name, v => Name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(InitialValue, v => InitialValue = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Block, v => Block = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndDirectSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_initialValue, v => _initialValue = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_block, v => _block = (UnifiedBlock)v);
		}

		public static UnifiedVariableDefinitionBody Create(string name, UnifiedTypeSupplementCollection supplements, IUnifiedExpression initialValues)
		{
			return Create(
				UnifiedIdentifier.CreateVariable(name),
				supplements,
				initialValues,
				null,
				null);
		}

		public static UnifiedVariableDefinitionBody Create(UnifiedIdentifier name, UnifiedTypeSupplementCollection supplements, IUnifiedExpression initialValues, UnifiedArgumentCollection arguments, UnifiedBlock block)
		{
			return new UnifiedVariableDefinitionBody {
				Name = name,
				Supplements = supplements,
				InitialValue = initialValues,
				Arguments = arguments,
				Block = block,
			};
		}
	}
}
