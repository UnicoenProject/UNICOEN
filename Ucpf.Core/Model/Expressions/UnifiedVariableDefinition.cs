using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model
{
	/// <summary>
	///   変数宣言部分を表します。
	/// </summary>
	public class UnifiedVariableDefinition : UnifiedElement, IUnifiedExpression
	{
		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = SetParentOfChild(value, _modifiers); }
		}

		private UnifiedType _type;

		public UnifiedType Type
		{
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name
		{
			get { return _name; }
			set { _name = SetParentOfChild(value, _name); }
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
		///    E1 {
		///    @override public String toString() { return ""; }
		///    },
		///    E2
		///    }
		///  </code>
		///</summary>
		public UnifiedBlock Block
		{
			get { return _block; }
			set { _block = SetParentOfChild(value, _block); }
		}

		private UnifiedVariableDefinition()
		{
			Modifiers = UnifiedModifierCollection.Create();
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name)
		{
			return new UnifiedVariableDefinition {
				Type = type,
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
			};
		}

		public static UnifiedVariableDefinition Create(string name)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor)
		{
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data)
		{
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements()
		{
			yield return Modifiers;
			yield return Type;
			yield return Name;
			yield return InitialValue;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
			GetElementAndSetters()
		{
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(Type, v => Type = (UnifiedType)v);
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
				(_modifiers, v => _modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_type, v => _type = (UnifiedType)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_name, v => _name = (UnifiedIdentifier)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_initialValue, v => _initialValue = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
				(_block, v => _block = (UnifiedBlock)v);
		}

		public static UnifiedVariableDefinition Create(string name,
		                                               IUnifiedExpression initialValue)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				InitialValue = initialValue,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name,
		                                               IUnifiedExpression initialValue)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				Type = type,
				InitialValue = initialValue,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type,
		                                               UnifiedModifierCollection
		                                               	modifiers,
		                                               IUnifiedExpression initialValue,
		                                               string name)
		{
			return new UnifiedVariableDefinition {
				Type = type,
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				InitialValue = initialValue,
				Modifiers = modifiers,
			};
		}

		public static UnifiedVariableDefinition Create(UnifiedType type, string name,
		                                               UnifiedModifierCollection
		                                               	modifiers)
		{
			return new UnifiedVariableDefinition {
				Name = UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				Modifiers = modifiers,
				Type = type,
			};
		}

		public static UnifiedVariableDefinition Create(
			UnifiedModifierCollection modifiers,
			UnifiedType type,
			UnifiedIdentifier name,
			IUnifiedExpression initialValues,
			UnifiedArgumentCollection arguments,
			UnifiedBlock block)
		{
			return new UnifiedVariableDefinition {
				Modifiers = modifiers,
				Type = type,
				Name = name,
				InitialValue = initialValues,
				Arguments = arguments,
				Block = block,
			};
		}
	}
}