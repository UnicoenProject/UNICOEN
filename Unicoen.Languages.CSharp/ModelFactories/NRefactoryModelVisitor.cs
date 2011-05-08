#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Diagnostics.Contracts;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Unicoen.Core.Model;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;

namespace Unicoen.Languages.CSharp.ModelFactories {
	internal partial class NRefactoryModelVisitor : IAstVisitor<object, IUnifiedElement> {
		public IUnifiedElement VisitCompilationUnit(CompilationUnit unit, object data) {
			Contract.Requires<ArgumentNullException>(unit != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedProgram);

			var prog = UnifiedProgram.Create();
			foreach (var child in unit.Children) {
				var elem = child.AcceptVisitor(this, data) as IUnifiedExpression;
				if (elem != null)
					prog.Add(elem);
			}
			return prog;
		}

		public IUnifiedElement VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data) {
			throw new NotImplementedException("AnonymousMethodExpression");
		}

		public IUnifiedElement VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression, object data) {
			throw new NotImplementedException("UndocumentedExpression");
		}

		public IUnifiedElement VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, object data) {
			throw new NotImplementedException("ArrayCreateExpression");
		}

		public IUnifiedElement VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression, object data) {
			throw new NotImplementedException("ArrayInitializerExpression");
		}

		public IUnifiedElement VisitAsExpression(AsExpression asExpression, object data) {
			throw new NotImplementedException("AsExpression");
		}

		public IUnifiedElement VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data) {
			throw new NotImplementedException("AssignmentExpression");
		}

		public IUnifiedElement VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, object data) {
			throw new NotImplementedException("BaseReferenceExpression");
		}

		public IUnifiedElement VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data) {
			throw new NotImplementedException("BinaryOperatorExpression");
		}

		public IUnifiedElement VisitCastExpression(CastExpression castExpression, object data) {
			throw new NotImplementedException("CastExpression");
		}

		public IUnifiedElement VisitCheckedExpression(CheckedExpression checkedExpression, object data) {
			throw new NotImplementedException("CheckedExpression");
		}

		public IUnifiedElement VisitConditionalExpression(ConditionalExpression conditionalExpression, object data) {
			throw new NotImplementedException("ConditionalExpression");
		}

		public IUnifiedElement VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, object data) {
			throw new NotImplementedException("DefaultValueExpression");
		}

		public IUnifiedElement VisitDirectionExpression(DirectionExpression directionExpression, object data) {
			throw new NotImplementedException("DirectionExpression");
		}

		public IUnifiedElement VisitIdentifierExpression(IdentifierExpression identifierExpression, object data) {
			throw new NotImplementedException("IdentifierExpression");
		}

		public IUnifiedElement VisitIndexerExpression(IndexerExpression indexerExpression, object data) {
			throw new NotImplementedException("IndexerExpression");
		}

		public IUnifiedElement VisitInvocationExpression(InvocationExpression invocationExpression, object data) {
			throw new NotImplementedException("InvocationExpression");
		}

		public IUnifiedElement VisitIsExpression(IsExpression isExpression, object data) {
			throw new NotImplementedException("IsExpression");
		}

		public IUnifiedElement VisitLambdaExpression(LambdaExpression lambdaExpression, object data) {
			throw new NotImplementedException("LambdaExpression");
		}

		public IUnifiedElement VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data) {
			throw new NotImplementedException("MemberReferenceExpression");
		}

		public IUnifiedElement VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, object data) {
			throw new NotImplementedException("NamedArgumentExpression");
		}

		public IUnifiedElement VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression, object data) {
			throw new NotImplementedException("NullReferenceExpression");
		}

		public IUnifiedElement VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data) {
			throw new NotImplementedException("ObjectCreateExpression");
		}

		public IUnifiedElement VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression, object data) {
			throw new NotImplementedException("AnonymousTypeCreateExpression");
		}

		public IUnifiedElement VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, object data) {
			throw new NotImplementedException("ParenthesizedExpression");
		}

		public IUnifiedElement VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data) {
			throw new NotImplementedException("PointerReferenceExpression");
		}

		public IUnifiedElement VisitPrimitiveExpression(PrimitiveExpression primitiveExpression, object data) {
			throw new NotImplementedException("PrimitiveExpression");
		}

		public IUnifiedElement VisitSizeOfExpression(SizeOfExpression sizeOfExpression, object data) {
			throw new NotImplementedException("SizeOfExpression");
		}

		public IUnifiedElement VisitStackAllocExpression(StackAllocExpression stackAllocExpression, object data) {
			throw new NotImplementedException("StackAllocExpression");
		}

		public IUnifiedElement VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, object data) {
			throw new NotImplementedException("ThisReferenceExpression");
		}

		public IUnifiedElement VisitTypeOfExpression(TypeOfExpression typeOfExpression, object data) {
			throw new NotImplementedException("TypeOfExpression");
		}

		public IUnifiedElement VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, object data) {
			throw new NotImplementedException("TypeReferenceExpression");
		}

		public IUnifiedElement VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data) {
			throw new NotImplementedException("UnaryOperatorExpression");
		}

		public IUnifiedElement VisitUncheckedExpression(UncheckedExpression uncheckedExpression, object data) {
			throw new NotImplementedException("UncheckedExpression");
		}

		public IUnifiedElement VisitEmptyExpression(EmptyExpression emptyExpression, object data) {
			throw new NotImplementedException("EmptyExpression");
		}

		public IUnifiedElement VisitQueryExpression(QueryExpression queryExpression, object data) {
			throw new NotImplementedException("QueryExpression");
		}

		public IUnifiedElement VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause, object data) {
			throw new NotImplementedException("QueryContinuationClause");
		}

		public IUnifiedElement VisitQueryFromClause(QueryFromClause queryFromClause, object data) {
			throw new NotImplementedException("QueryFromClause");
		}

		public IUnifiedElement VisitQueryLetClause(QueryLetClause queryLetClause, object data) {
			throw new NotImplementedException("QueryLetClause");
		}

		public IUnifiedElement VisitQueryWhereClause(QueryWhereClause queryWhereClause, object data) {
			throw new NotImplementedException("QueryWhereClause");
		}

		public IUnifiedElement VisitQueryJoinClause(QueryJoinClause queryJoinClause, object data) {
			throw new NotImplementedException("QueryJoinClause");
		}

		public IUnifiedElement VisitQueryOrderClause(QueryOrderClause queryOrderClause, object data) {
			throw new NotImplementedException("QueryOrderClause");
		}

		public IUnifiedElement VisitQueryOrdering(QueryOrdering queryOrdering, object data) {
			throw new NotImplementedException("QueryOrdering");
		}

		public IUnifiedElement VisitQuerySelectClause(QuerySelectClause querySelectClause, object data) {
			throw new NotImplementedException("QuerySelectClause");
		}

		public IUnifiedElement VisitQueryGroupClause(QueryGroupClause queryGroupClause, object data) {
			throw new NotImplementedException("QueryGroupClause");
		}

		public IUnifiedElement VisitAttribute(Attribute attribute, object data) {
			throw new NotImplementedException("Attribute");
		}

		public IUnifiedElement VisitAttributeSection(AttributeSection attributeSection, object data) {
			throw new NotImplementedException("AttributeSection");
		}

		public IUnifiedElement VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, object data) {
			throw new NotImplementedException("DelegateDeclaration");
		}

		public IUnifiedElement VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data) {
			throw new NotImplementedException("NamespaceDeclaration");
		}

		public IUnifiedElement VisitTypeDeclaration(TypeDeclaration dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedClassDefinition);

			var kind = LookupClassKind(dec.ClassType);
			var mods = LookupModifier(dec.Modifiers);
			var name = UnifiedIdentifier.CreateType(dec.Name);
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Members) {
				var uExpr = node.AcceptVisitor(this, data) as IUnifiedExpression;
				if (uExpr != null)
					body.Add(uExpr);
			}
			return UnifiedClassDefinition.Create(kind, mods, name, /*TODO*/null, /*TODO*/null, body);
		}

		public IUnifiedElement VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration, object data) {
			throw new NotImplementedException("UsingAliasDeclaration");
		}

		public IUnifiedElement VisitUsingDeclaration(UsingDeclaration usingDeclaration, object data) {
			throw new NotImplementedException("UsingDeclaration");
		}

		public IUnifiedElement VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration, object data) {
			throw new NotImplementedException("ExternAliasDeclaration");
		}

		public IUnifiedElement VisitBlockStatement(BlockStatement blockStatement, object data) {
			throw new NotImplementedException("BlockStatement");
		}

		public IUnifiedElement VisitBreakStatement(BreakStatement breakStatement, object data) {
			throw new NotImplementedException("BreakStatement");
		}

		public IUnifiedElement VisitCheckedStatement(CheckedStatement checkedStatement, object data) {
			throw new NotImplementedException("CheckedStatement");
		}

		public IUnifiedElement VisitContinueStatement(ContinueStatement continueStatement, object data) {
			throw new NotImplementedException("ContinueStatement");
		}

		public IUnifiedElement VisitDoWhileStatement(DoWhileStatement doWhileStatement, object data) {
			throw new NotImplementedException("DoWhileStatement");
		}

		public IUnifiedElement VisitEmptyStatement(EmptyStatement emptyStatement, object data) {
			throw new NotImplementedException("EmptyStatement");
		}

		public IUnifiedElement VisitExpressionStatement(ExpressionStatement expressionStatement, object data) {
			throw new NotImplementedException("ExpressionStatement");
		}

		public IUnifiedElement VisitFixedStatement(FixedStatement fixedStatement, object data) {
			throw new NotImplementedException("FixedStatement");
		}

		public IUnifiedElement VisitForeachStatement(ForeachStatement foreachStatement, object data) {
			throw new NotImplementedException("ForeachStatement");
		}

		public IUnifiedElement VisitForStatement(ForStatement forStatement, object data) {
			throw new NotImplementedException("ForStatement");
		}

		public IUnifiedElement VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, object data) {
			throw new NotImplementedException("GotoCaseStatement");
		}

		public IUnifiedElement VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement, object data) {
			throw new NotImplementedException("GotoDefaultStatement");
		}

		public IUnifiedElement VisitGotoStatement(GotoStatement gotoStatement, object data) {
			throw new NotImplementedException("GotoStatement");
		}

		public IUnifiedElement VisitIfElseStatement(IfElseStatement stmt, object data) {
			Contract.Requires<ArgumentNullException>(stmt != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedIf);
			var cond = stmt.Condition;
			var trueBlock = stmt.TrueStatement;
			var falseBlock = stmt.FalseStatement;

			throw new NotImplementedException("IfElseStatement");
		}

		public IUnifiedElement VisitLabelStatement(LabelStatement labelStatement, object data) {
			throw new NotImplementedException("LabelStatement");
		}

		public IUnifiedElement VisitLockStatement(LockStatement lockStatement, object data) {
			throw new NotImplementedException("LockStatement");
		}

		public IUnifiedElement VisitReturnStatement(ReturnStatement returnStatement, object data) {
			throw new NotImplementedException("ReturnStatement");
		}

		public IUnifiedElement VisitSwitchStatement(SwitchStatement switchStatement, object data) {
			throw new NotImplementedException("SwitchStatement");
		}

		public IUnifiedElement VisitSwitchSection(SwitchSection switchSection, object data) {
			throw new NotImplementedException("SwitchSection");
		}

		public IUnifiedElement VisitCaseLabel(CaseLabel caseLabel, object data) {
			throw new NotImplementedException("CaseLabel");
		}

		public IUnifiedElement VisitThrowStatement(ThrowStatement throwStatement, object data) {
			throw new NotImplementedException("ThrowStatement");
		}

		public IUnifiedElement VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data) {
			throw new NotImplementedException("TryCatchStatement");
		}

		public IUnifiedElement VisitCatchClause(CatchClause catchClause, object data) {
			throw new NotImplementedException("CatchClause");
		}

		public IUnifiedElement VisitUncheckedStatement(UncheckedStatement uncheckedStatement, object data) {
			throw new NotImplementedException("UncheckedStatement");
		}

		public IUnifiedElement VisitUnsafeStatement(UnsafeStatement unsafeStatement, object data) {
			throw new NotImplementedException("UnsafeStatement");
		}

		public IUnifiedElement VisitUsingStatement(UsingStatement usingStatement, object data) {
			throw new NotImplementedException("UsingStatement");
		}

		public IUnifiedElement VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data) {
			throw new NotImplementedException("VariableDeclarationStatement");
		}

		public IUnifiedElement VisitWhileStatement(WhileStatement whileStatement, object data) {
			throw new NotImplementedException("WhileStatement");
		}

		public IUnifiedElement VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement, object data) {
			throw new NotImplementedException("YieldBreakStatement");
		}

		public IUnifiedElement VisitYieldStatement(YieldStatement yieldStatement, object data) {
			throw new NotImplementedException("YieldStatement");
		}

		public IUnifiedElement VisitAccessor(Accessor accessor, object data) {
			throw new NotImplementedException("Accessor");
		}

		public IUnifiedElement VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data) {
			throw new NotImplementedException("ConstructorDeclaration");
		}

		public IUnifiedElement VisitConstructorInitializer(ConstructorInitializer constructorInitializer, object data) {
			throw new NotImplementedException("ConstructorInitializer");
		}

		public IUnifiedElement VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data) {
			throw new NotImplementedException("DestructorDeclaration");
		}

		public IUnifiedElement VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration, object data) {
			throw new NotImplementedException("EnumMemberDeclaration");
		}

		public IUnifiedElement VisitEventDeclaration(EventDeclaration eventDeclaration, object data) {
			throw new NotImplementedException("EventDeclaration");
		}

		public IUnifiedElement VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration, object data) {
			throw new NotImplementedException("CustomEventDeclaration");
		}

		public IUnifiedElement VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data) {
			throw new NotImplementedException("FieldDeclaration");
		}

		public IUnifiedElement VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration, object data) {
			throw new NotImplementedException("IndexerDeclaration");
		}

		public IUnifiedElement VisitMethodDeclaration(MethodDeclaration dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedFunctionDefinition);

			var mods = LookupModifier(dec.Modifiers);
			var type = LookupType(dec.ReturnType);
			var name = dec.Name;
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Body) {
				var uExpr = node.AcceptVisitor(this, data) as IUnifiedExpression;
				if (uExpr != null)
					body.Add(uExpr);
			}

			return UnifiedFunctionDefinition.CreateFunction(mods, type, name, null, body);
		}

		public IUnifiedElement VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data) {
			throw new NotImplementedException("OperatorDeclaration");
		}

		public IUnifiedElement VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data) {
			throw new NotImplementedException("ParameterDeclaration");
		}

		public IUnifiedElement VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data) {
			throw new NotImplementedException("PropertyDeclaration");
		}

		public IUnifiedElement VisitVariableInitializer(VariableInitializer variableInitializer, object data) {
			throw new NotImplementedException("VariableInitializer");
		}

		public IUnifiedElement VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration, object data) {
			throw new NotImplementedException("FixedFieldDeclaration");
		}

		public IUnifiedElement VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer, object data) {
			throw new NotImplementedException("FixedVariableInitializer");
		}

		public IUnifiedElement VisitSimpleType(SimpleType simpleType, object data) {
			throw new NotImplementedException("SimpleType");
		}

		public IUnifiedElement VisitMemberType(MemberType memberType, object data) {
			throw new NotImplementedException("MemberType");
		}

		public IUnifiedElement VisitComposedType(ComposedType composedType, object data) {
			throw new NotImplementedException("ComposedType");
		}

		public IUnifiedElement VisitArraySpecifier(ArraySpecifier arraySpecifier, object data) {
			throw new NotImplementedException("ArraySpecifier");
		}

		public IUnifiedElement VisitPrimitiveType(PrimitiveType primitiveType, object data) {
			throw new NotImplementedException("PrimitiveType");
		}

		public IUnifiedElement VisitComment(Comment comment, object data) {
			throw new NotImplementedException("Comment");
		}

		public IUnifiedElement VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration, object data) {
			throw new NotImplementedException("TypeParameterDeclaration");
		}

		public IUnifiedElement VisitConstraint(Constraint constraint, object data) {
			throw new NotImplementedException("Constraint");
		}

		public IUnifiedElement VisitCSharpTokenNode(CSharpTokenNode tokenNode, object data) {
			// TODO よく分からないから調べる
			return null;
			//throw new NotImplementedException("CSharpTokenNode");
		}

		public IUnifiedElement VisitIdentifier(Identifier identifier, object data) {
			throw new NotImplementedException("Identifier");
		}

		public IUnifiedElement VisitPatternPlaceholder(AstNode placeholder, Pattern pattern, object data) {
			throw new NotImplementedException("AstNode");
		}
	}
}