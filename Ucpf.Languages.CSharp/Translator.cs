using System;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Parser;
using Ucpf.Common.Model;

namespace Ucpf.Languages.CSharp {

	partial class Translator : IAstVisitor {

		public object VisitAddHandlerStatement(AddHandlerStatement addHandlerStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitAddressOfExpression(AddressOfExpression addressOfExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitAttribute(ICSharpCode.NRefactory.Ast.Attribute attribute, object data) {
			throw new NotImplementedException();
		}

		public object VisitAttributeSection(AttributeSection attributeSection, object data) {
			throw new NotImplementedException();
		}

		public object VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitBinaryOperatorExpression(BinaryOperatorExpression expr, object data) {
			var op = ConvertOperator(expr.Op);
			var left = expr.Left.AcceptVisitor(this, data) as UnifiedExpression;
			var right = expr.Right.AcceptVisitor(this, data) as UnifiedExpression;
			return new UnifiedBinaryExpression {
				Operator = op,
				LeftHandSide = left,
				RightHandSide = right,
			};
		}

		public object VisitBlockStatement(BlockStatement block, object data) {
			var stmts = block.Children
				.Select(node => node.AcceptVisitor(this, data));
			return ToBlock(stmts);
		}

		public object VisitBreakStatement(BreakStatement breakStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitCaseLabel(CaseLabel caseLabel, object data) {
			throw new NotImplementedException();
		}

		public object VisitCastExpression(CastExpression castExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitCatchClause(CatchClause catchClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitCheckedExpression(CheckedExpression checkedExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitCheckedStatement(CheckedStatement checkedStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitClassReferenceExpression(ClassReferenceExpression classReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitCollectionInitializerExpression(CollectionInitializerExpression collectionInitializerExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitCollectionRangeVariable(CollectionRangeVariable collectionRangeVariable, object data) {
			throw new NotImplementedException();
		}

		public object VisitCompilationUnit(CompilationUnit compilationUnit, object data) {
			if (compilationUnit.Children.Count == 1) {
				return compilationUnit.Children[0].AcceptVisitor(this, data);
			}
			var stmts = compilationUnit.Children
				.Select(node => node.AcceptVisitor(this, data));
			return ToBlock(stmts);
		}

		public object VisitConditionalExpression(ConditionalExpression conditionalExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitConstructorInitializer(ConstructorInitializer constructorInitializer, object data) {
			throw new NotImplementedException();
		}

		public object VisitContinueStatement(ContinueStatement continueStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitDeclareDeclaration(DeclareDeclaration declareDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitDirectionExpression(DirectionExpression directionExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitElseIfSection(ElseIfSection elseIfSection, object data) {
			throw new NotImplementedException();
		}

		public object VisitEmptyStatement(EmptyStatement emptyStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitEndStatement(EndStatement endStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitEraseStatement(EraseStatement eraseStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitErrorStatement(ErrorStatement errorStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitEventAddRegion(EventAddRegion eventAddRegion, object data) {
			throw new NotImplementedException();
		}

		public object VisitEventDeclaration(EventDeclaration eventDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitEventRaiseRegion(EventRaiseRegion eventRaiseRegion, object data) {
			throw new NotImplementedException();
		}

		public object VisitEventRemoveRegion(EventRemoveRegion eventRemoveRegion, object data) {
			throw new NotImplementedException();
		}

		public object VisitExitStatement(ExitStatement exitStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitExpressionRangeVariable(ExpressionRangeVariable expressionRangeVariable, object data) {
			throw new NotImplementedException();
		}

		public object VisitExpressionStatement(ExpressionStatement expressionStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitExternAliasDirective(ExternAliasDirective externAliasDirective, object data) {
			throw new NotImplementedException();
		}

		public object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitFixedStatement(FixedStatement fixedStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitForNextStatement(ForNextStatement forNextStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitForStatement(ForStatement forStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitForeachStatement(ForeachStatement foreachStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitGotoStatement(GotoStatement gotoStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitIdentifierExpression(IdentifierExpression ident, object data) {
			return UnifiedVariable.Create(ident.Identifier);
		}

		public object VisitIfElseStatement(IfElseStatement stmt, object data) {
			var cond = stmt.Condition.AcceptVisitor(this, data) as UnifiedExpression;
			var trueStmt = stmt.TrueStatement
				.Select(s => s.AcceptVisitor(this, data));
			var falseStmt = stmt.FalseStatement
				.Select(s => s.AcceptVisitor(this, data));
			return new UnifiedIf {
				Condition = cond,
				TrueBlock = ToBlock(trueStmt),
				FalseBlock = ToBlock(falseStmt),
			};
		}

		public object VisitIndexerExpression(IndexerExpression indexerExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitInnerClassTypeReference(InnerClassTypeReference innerClassTypeReference, object data) {
			throw new NotImplementedException();
		}

		public object VisitInterfaceImplementation(InterfaceImplementation interfaceImplementation, object data) {
			throw new NotImplementedException();
		}

		public object VisitInvocationExpression(InvocationExpression invoke, object data) {
			var target =
				invoke.TargetObject.AcceptVisitor(this, data) as UnifiedExpression;
			var args = invoke.Arguments
				.Select(exp => exp.AcceptVisitor(this, data))
				.OfType<UnifiedExpression>()
				.Select(exp => new UnifiedArgument { Value = exp });
			return new UnifiedCall {
				Function = target,
				Arguments = new UnifiedArgumentCollection(args)
			};
		}

		public object VisitLabelStatement(LabelStatement labelStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitLambdaExpression(LambdaExpression lambdaExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitLockStatement(LockStatement lockStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitMemberInitializerExpression(MemberInitializerExpression memberInitializerExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitMethodDeclaration(MethodDeclaration method, object data) {
			var parameters = new UnifiedParameterCollection(
				method.Parameters
					.Select(p => VisitParameterDeclarationExpression(p, data))
					.OfType<UnifiedParameter>());
			var modifiers = new UnifiedModifierCollection();
			return new UnifiedFunctionDefinition {
				Name = method.Name,
				Modifiers = ConvertModifiler(method.Modifier),
				Parameters = parameters,
				Type = GetTypeName(method.TypeReference),
				Block = VisitBlockStatement(method.Body, data) as UnifiedBlock
			};
		}

		public object VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitOnErrorStatement(OnErrorStatement onErrorStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitOptionDeclaration(OptionDeclaration optionDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitParameterDeclarationExpression(ParameterDeclarationExpression parameter, object data) {
			return new UnifiedParameter {
				Name = parameter.ParameterName,
				Type = GetTypeName(parameter.TypeReference),
			};
		}

		public object VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitPrimitiveExpression(PrimitiveExpression primitive, object data) {
			switch (primitive.LiteralFormat) {
				case LiteralFormat.DecimalNumber:
					if (primitive.Value is int) {
						return new UnifiedIntegerLiteral((int)primitive.Value);
					}
					break;
			}
			return null;
		}

		public object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitPropertyGetRegion(PropertyGetRegion propertyGetRegion, object data) {
			throw new NotImplementedException();
		}

		public object VisitPropertySetRegion(PropertySetRegion propertySetRegion, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpression(QueryExpression queryExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionAggregateClause(QueryExpressionAggregateClause queryExpressionAggregateClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionDistinctClause(QueryExpressionDistinctClause queryExpressionDistinctClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionFromClause(QueryExpressionFromClause queryExpressionFromClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionGroupClause(QueryExpressionGroupClause queryExpressionGroupClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionGroupJoinVBClause(QueryExpressionGroupJoinVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionGroupVBClause(QueryExpressionGroupVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionJoinClause(QueryExpressionJoinClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionJoinConditionVB(QueryExpressionJoinConditionVB expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionJoinVBClause(QueryExpressionJoinVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionLetClause(QueryExpressionLetClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionLetVBClause(QueryExpressionLetVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionOrderClause(QueryExpressionOrderClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionOrdering(QueryExpressionOrdering expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionPartitionVBClause(QueryExpressionPartitionVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionSelectClause(QueryExpressionSelectClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionSelectVBClause(QueryExpressionSelectVBClause expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionVB(QueryExpressionVB expr, object data) {
			throw new NotImplementedException();
		}

		public object VisitQueryExpressionWhereClause(QueryExpressionWhereClause queryExpressionWhereClause, object data) {
			throw new NotImplementedException();
		}

		public object VisitRaiseEventStatement(RaiseEventStatement raiseEventStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitReDimStatement(ReDimStatement reDimStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitRemoveHandlerStatement(RemoveHandlerStatement removeHandlerStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitResumeStatement(ResumeStatement resumeStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitReturnStatement(ReturnStatement stmt, object data) {
			var value = stmt.Expression.AcceptVisitor(this, data) as UnifiedExpression;
			return new UnifiedReturn { Value = value };
		}

		public object VisitSizeOfExpression(SizeOfExpression sizeOfExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitStackAllocExpression(StackAllocExpression stackAllocExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitStopStatement(StopStatement stopStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitSwitchSection(SwitchSection switchSection, object data) {
			throw new NotImplementedException();
		}

		public object VisitSwitchStatement(SwitchStatement switchStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitTemplateDefinition(TemplateDefinition templateDefinition, object data) {
			throw new NotImplementedException();
		}

		public object VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitThrowStatement(ThrowStatement throwStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data) {
			var stmts = typeDeclaration.Children
				.Select(node => node.AcceptVisitor(this, data));
			return new UnifiedClassDefinition {
				Name = typeDeclaration.Name,
				Body = ToBlock(stmts)
			};
		}

		public object VisitTypeOfExpression(TypeOfExpression typeOfExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitTypeOfIsExpression(TypeOfIsExpression typeOfIsExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitTypeReference(TypeReference typeReference, object data) {
			throw new NotImplementedException();
		}

		public object VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitUncheckedExpression(UncheckedExpression uncheckedExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitUncheckedStatement(UncheckedStatement uncheckedStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitUnsafeStatement(UnsafeStatement unsafeStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitUsing(Using @using, object data) {
			throw new NotImplementedException();
		}

		public object VisitUsingDeclaration(UsingDeclaration usingDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitUsingStatement(UsingStatement usingStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data) {
			throw new NotImplementedException();
		}

		public object VisitWithStatement(WithStatement withStatement, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlAttributeExpression(XmlAttributeExpression xmlAttributeExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlContentExpression(XmlContentExpression xmlContentExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlDocumentExpression(XmlDocumentExpression xmlDocumentExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlElementExpression(XmlElementExpression xmlElementExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlEmbeddedExpression(XmlEmbeddedExpression xmlEmbeddedExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitXmlMemberAccessExpression(XmlMemberAccessExpression xmlMemberAccessExpression, object data) {
			throw new NotImplementedException();
		}

		public object VisitYieldStatement(YieldStatement yieldStatement, object data) {
			throw new NotImplementedException();
		}
	}
}
