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
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedArgumentCollection element, VisitorState state) {
			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedParameterCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedModifierCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedExpressionCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeArgumentCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCaseCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCatchCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeParameterCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeConstrainCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeSupplementCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBodyCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIdentifierCollection element, VisitorState state) {
			throw new NotImplementedException();

		}
	}
}
