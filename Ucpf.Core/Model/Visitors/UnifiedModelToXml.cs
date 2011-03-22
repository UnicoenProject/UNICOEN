using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Core.Model.Visitors {
	public class UnifiedModelToXml : IUnifiedModelVisitor<object, object> {
		private readonly Stack<XElement> _targets;
		private XElement _root;

		public static XElement ToXml(UnifiedElement element) {
			var toXml = new UnifiedModelToXml();
			element.Accept(toXml, null);
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

		public object Visit<T>(UnifiedTypedLiteral<T> element, object data) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Value", element.Value);
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedBinaryOperator element, object data) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedUnaryOperator element, object data) {
			var xe = new XElement(element.GetType().Name);
			xe.SetAttributeValue("Sign", element.Sign);
			xe.SetAttributeValue("Type", element.Type);
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedArgument element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedArgumentCollection element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this, data);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedBinaryExpression element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.LeftHandSide.Accept(this, data);
			element.Operator.Accept(this, data);
			element.RightHandSide.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedBlock element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this, data);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedCall element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Function.Accept(this, data);
			element.Arguments.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedFunctionDefinition element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			element.Parameters.Accept(this, data);
			element.Body.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedIf element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Condition.Accept(this, data);
			element.TrueBody.Accept(this, data);
			element.FalseBody.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedParameter element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Type", element.Type);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedParameterCollection element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this, data);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedReturn element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			element.Value.Accept(this, data);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedVariable element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedModifier element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			_targets.Pop();
			_targets.Peek().Add(xe);
			return null;
		}

		public object Visit(UnifiedModifierCollection element, object data) {
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				e.Accept(this, data);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
			throw new NotImplementedException();
		}

		public object Visit(UnifiedImport element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedConstructorDefinition element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedProgram element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedClassDefinition element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedVariableDefinition element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedNew element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedLiteral element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedArrayNew element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedFor element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedForeach element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedUnaryExpression element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedProperty element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedType element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedExpressionCollection element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedWhile element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedDoWhile element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedBreak element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedContinue element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedNamespace element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedIndexer element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedTypeParameter element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedTypeParameterCollection element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedSwitch element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedCaseCollection element, object data) {
			throw new NotImplementedException();
		}

		public object Visit(UnifiedCase element, object data) {
			throw new NotImplementedException();
		}
	}
}