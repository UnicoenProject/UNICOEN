using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;

namespace Unicoen.Languages.C.CodeFactories
{
	public partial class CCodeFactory
	{
		public void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, VisitorState state)
			where T : class, IUnifiedElement
			where TSelf : UnifiedElementCollection<T, TSelf>
		{
			var decoration = state.Decoration;
			state.Writer.Write(decoration.MostLeft);
			var splitter = "";
			foreach (var e in elements)
			{
				state.Writer.Write(splitter);
				state.Writer.Write(decoration.EachLeft);
				e.TryAccept(this, state);
				state.Writer.Write(decoration.EachRight);
				splitter = decoration.Delimiter;
			}
			state.Writer.Write(decoration.MostRight);
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedArgumentCollection element, VisitorState state) {
			VisitCollection(element, state);
			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedParameterCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Paren));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedModifierCollection element, VisitorState state) {
			VisitCollection(element, state.Set(SpaceDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedExpressionCollection element, VisitorState state) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeArgumentCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCaseCollection element, VisitorState state) {
			state = state.IncrementIndentDepth();
			foreach(var caseElement in element) {
				state.WriteIndent();
				caseElement.TryAccept(this, state);
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCatchCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeParameterCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeConstrainCollection element, VisitorState state) {
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeSupplementCollection element, VisitorState state) {
			VisitCollection(element, state.Set(Empty));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBodyCollection element, VisitorState state) {
			VisitCollection(element, state.Set(CommaDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIdentifierCollection element, VisitorState state) {
			throw new InvalidOperationException();

		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedExpressionList element, VisitorState state)
		{
			VisitCollection(element, state);

			return false;
		}
	}
}
