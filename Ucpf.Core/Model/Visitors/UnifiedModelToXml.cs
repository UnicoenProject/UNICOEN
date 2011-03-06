using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Core.Model.Expressions;
using Ucpf.Core.Model.Expressions.Literals;
using Ucpf.Core.Model.Expressions.Operators;

namespace Ucpf.Core.Model.Visitors {
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
			xe.SetAttributeValue("Value", element.Value);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBinaryOperator element) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedUnaryOperator element) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedArgument element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedArgumentCollection element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBinaryExpression element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.LeftHandSide.Accept(this);
			element.Operator.Accept(this);
			element.RightHandSide.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBlock element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedCall element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Function.Accept(this);
			element.Arguments.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedFunctionDefinition element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			element.Parameters.Accept(this);
			element.Block.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedIf element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Condition.Accept(this);
			element.TrueBlock.Accept(this);
			element.FalseBlock.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedParameter element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Type", element.Type);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedParameterCollection element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedReturn element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedVariable element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedModifier element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedModifierCollection element) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
			throw new NotImplementedException();
		}

		public void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructorDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProgram element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedClassDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArrayNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFor element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedForeach element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProperty element) {
			throw new NotImplementedException();
		}
	}
}