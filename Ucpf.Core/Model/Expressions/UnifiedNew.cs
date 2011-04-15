using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   配列の生成を含むコンストラクタ呼び出しを表します。
	/// </summary>
	public class UnifiedNew : UnifiedExpressionWithBlock<UnifiedNew> {
		private UnifiedType _type;

		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedTypeArgumentCollection _typeArguments;

		public UnifiedTypeArgumentCollection TypeArguments {
			get { return _typeArguments; }
			set { _typeArguments = SetParentOfChild(value, _typeArguments); }
		}

		private UnifiedExpressionList _initialValues;

		/// <summary>
		///   Javaにおける<c>new int[10] { 0, 1 }</c>の<c>{ 0, 1 }</c>部分などが該当します。
		/// </summary>
		public UnifiedExpressionList InitialValues {
			get { return _initialValues; }
			set { _initialValues = SetParentOfChild(value, _initialValues); }
		}

		private UnifiedNew() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Type;
			yield return Arguments;
			yield return TypeArguments;
			yield return InitialValues;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(Type,
							v => Type = (UnifiedType)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(Arguments,
							v => Arguments = (UnifiedArgumentCollection)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(TypeArguments,
							v => TypeArguments = (UnifiedTypeArgumentCollection)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(InitialValues,
							v => InitialValues = (UnifiedExpressionList)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(Body,
							v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(_type,
							v => _type = (UnifiedType)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(_arguments,
							v => _arguments = (UnifiedArgumentCollection)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(_typeArguments,
							v => _typeArguments = (UnifiedTypeArgumentCollection)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(_initialValues,
							v => _initialValues = (UnifiedExpressionList)v);
			yield return
					Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>(_body,
							v => _body = (UnifiedBlock)v);
		}

		public static UnifiedNew Create(UnifiedType type) {
			return Create(type, null, null, null, null);
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedArgumentCollection arguments) {
			return Create(type, arguments, null, null, null);
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedBlock body) {
			return new UnifiedNew {
					Type = type,
					Arguments = null,
					Body = body
			};
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedArgumentCollection arguments,
		                                UnifiedExpressionList initialValues) {
			return Create(type, arguments, null, initialValues, null);
		}

		public static UnifiedNew Create(UnifiedType type,
		                                UnifiedArgumentCollection arguments,
		                                UnifiedTypeArgumentCollection typeArguments,
		                                UnifiedExpressionList initialValues,
		                                UnifiedBlock body) {
			return new UnifiedNew {
					Type = type,
					Arguments = arguments,
					TypeArguments = typeArguments,
					InitialValues = initialValues,
					Body = body,
			};
		}

		public static UnifiedNew CreateArray(string name, UnifiedArgument argument) {
			return Create(
					UnifiedType.CreateUsingString(
							name,
							null,
							UnifiedTypeSupplementCollection.Create(
									UnifiedTypeSupplement.CreateArray(argument))));
		}

		public static UnifiedNew CreateArray(UnifiedExpressionList initialValues) {
			return Create(
					UnifiedType.CreateUsingString(
							null,
							null,
							UnifiedTypeSupplementCollection.Create(
									UnifiedTypeSupplement.CreateArray())),
					null,
					null,
					initialValues,
					null);
		}
	}
}