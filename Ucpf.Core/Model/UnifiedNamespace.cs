using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedNamespace : UnifiedElement {
		public string Name { get; set; }

		private UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						throw new InvalidOperationException("既に親要素が設定されている要素を設定できません。");
					}
					value.Parent = this;
				} else if (Parent != null) {
					Remove();
				}
				_body = value;
			}
		}

		private UnifiedNamespace() { }

		public UnifiedNamespace AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedNamespace Create(string name) {
			return new UnifiedNamespace {
				Name = name,
			};
		}

		public static UnifiedNamespace Create(string name, UnifiedBlock body) {
			return new UnifiedNamespace {
					Name = name,
					Body = body,
			};
		}
	}
}