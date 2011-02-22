using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Common.Model.Visitors {
	public class UnifiedModelToXml : IUnifiedModelVisitor {
		private readonly Stack<XElement> _targets;
		private XElement _root;

		public static XElement ToXml(UnifiedElement element) {
			var toXml = new UnifiedModelToXml();
			element.Accept(toXml);
			return toXml.Result;
		}

		public XElement Result {
			get { return _root.Elements().First(); }
		}

		public UnifiedModelToXml() {
			_targets = new Stack<XElement>();
			RestartVisit();
		}

		public void RestartVisit() {
			RestartVisit(new XElement("Root"));
		}

		public void RestartVisit(XElement root) {
			_targets.Clear();
			_targets.Push(root);
			_root = root;
		}

		public void Visit<T>(UnifiedTypedLiteral<T> element) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("TypedValue", element.TypedValue);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedLiteral element) {
			Contract.Requires(element.GetType().Name == "UnifiedLiteral");
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Value", element.Value);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBinaryOperator element) {
			Contract.Requires(element.GetType().Name == "UnifiedBinaryOperator");
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedUnaryOperator element) {
			Contract.Requires(element.GetType().Name == "UnifiedUnaryOperator");
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedArgument element) {
			Contract.Requires(element.GetType().Name == "UnifiedArgument");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedArgumentCollection element) {
			Contract.Requires(element.GetType().Name == "UnifiedArgumentCollection");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBinaryExpression element) {
			Contract.Requires(element.GetType().Name == "UnifiedBinaryExpression");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.LeftHandSide.Accept(this);
			element.Operator.Accept(this);
			element.RightHandSide.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBlock element) {
			Contract.Requires(element.GetType().Name == "UnifiedBlock");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedCall element) {
			Contract.Requires(element.GetType().Name == "UnifiedCall");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Function.Accept(this);
			element.Arguments.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedFunctionDefinition element) {
			Contract.Requires(element.GetType().Name == "UnifiedFunctionDefinition");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			element.Parameters.Accept(this);
			element.Block.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedExpressionStatement element) {
			Contract.Requires(element.GetType().Name == "UnifiedExpressionStatement");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Expression.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedIf element) {
			Contract.Requires(element.GetType().Name == "UnifiedIf");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Condition.Accept(this);
			element.TrueBlock.Accept(this);
			element.FalseBlock.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedParameter element) {
			Contract.Requires(element.GetType().Name == "UnifiedParameter");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedParameterCollection element) {
			Contract.Requires(element.GetType().Name == "UnifiedParameterCollection");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedReturn element) {
			Contract.Requires(element.GetType().Name == "UnifiedReturn");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedVariable element) {
			Contract.Requires(element.GetType().Name == "UnifiedVariable");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}
	}
}