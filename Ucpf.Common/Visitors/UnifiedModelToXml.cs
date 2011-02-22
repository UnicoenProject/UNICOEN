using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;

namespace Ucpf.Common.Visitors {
	public class UnifiedModelToXml : IUnifiedModelVisitor {
		private readonly Stack<XElement> _targets;
		private XElement _root;

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
			Visit(element.Value);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedArgumentCollection element) {
			Contract.Requires(element.GetType().Name == "UnifiedArgumentCollection");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				Visit(e);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedBinaryExpression element) {
			Contract.Requires(element.GetType().Name == "UnifiedBinaryExpression");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			Visit(element.LeftHandSide);
			Visit(element.Operator);
			Visit(element.RightHandSide);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedExpression element) {
			if (element is UnifiedBinaryExpression) {
				Visit((UnifiedBinaryExpression)element);
			} else if (element is UnifiedCall) {
				Visit((UnifiedCall)element);
			} else if (element is UnifiedIf) {
				Visit((UnifiedIf)element);
			} else if (element is UnifiedVariable) {
				Visit((UnifiedVariable)element);
			} else if (element is UnifiedStringLiteral) {
				Visit((UnifiedStringLiteral)element);
			} else if (element is UnifiedBooleanLiteral) {
				Visit((UnifiedBooleanLiteral)element);
			} else if (element is UnifiedDecimalLiteral) {
				Visit((UnifiedDecimalLiteral)element);
			} else if (element is UnifiedIntegerLiteral) {
				Visit((UnifiedIntegerLiteral)element);
			} else if (element is UnifiedLiteral) {
				Visit((UnifiedLiteral)element);
			} else {
				throw new NotImplementedException();
			}
		}

		public void Visit(UnifiedBlock element) {
			Contract.Requires(element.GetType().Name == "UnifiedBlock");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			foreach (var e in element) {
				Visit(e);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedStatement element) {
			if (element is UnifiedFunctionDefinition) {
				Visit((UnifiedFunctionDefinition)element);
			} else if (element is UnifiedExpressionStatement) {
				Visit((UnifiedExpressionStatement)element);
			} else if (element is UnifiedReturn) {
				Visit((UnifiedReturn)element);
			} else {
				throw new NotImplementedException();
			}
		}

		public void Visit(UnifiedCall element) {
			Contract.Requires(element.GetType().Name == "UnifiedCall");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			Visit(element.Function);
			Visit(element.Arguments);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedFunctionDefinition element) {
			Contract.Requires(element.GetType().Name == "UnifiedDefineFunction");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			xe.SetAttributeValue("Name", element.Name);
			Visit(element.Parameters);
			Visit(element.Block);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedExpressionStatement element) {
			Contract.Requires(element.GetType().Name == "UnifiedExpressionStatement");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			Visit(element.Expression);
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedIf element) {
			Contract.Requires(element.GetType().Name == "UnifiedIf");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			Visit(element.Condition);
			Visit(element.TrueBlock);
			Visit(element.FalseBlock);
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
				Visit(e);
			}
			_targets.Pop();
			_targets.Peek().Add(xe);
		}

		public void Visit(UnifiedReturn element) {
			Contract.Requires(element.GetType().Name == "UnifiedReturn");
			var xe = new XElement(element.GetType().Name);
			_targets.Push(xe);
			Visit(element.Value);
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