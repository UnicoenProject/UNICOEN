using System;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Parser;
using Ucpf.Core.Model;
using System.Collections.Generic;

namespace Ucpf.Languages.CSharp {

	partial class Translator : IAstVisitor {

		#region declare namespace, class, fileds, and so on.

		public object VisitCompilationUnit(CompilationUnit compilationUnit, object data) {
			var program = new UnifiedProgram();
			foreach (var child in compilationUnit.Children) {
				var expr = child.AcceptVisitor(this, data) as UnifiedExpression;
				if (expr != null)
					program.Add(expr);
			}
			return program;
		}

		public object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data) {
			var stmts = typeDeclaration.Children
				.Select(node => node.AcceptVisitor(this, data))
				.ToList();
			return new UnifiedClassDefinition {
				Name = typeDeclaration.Name,
				Body = ToFlattenBlock(stmts)
			};
		}

		public object VisitFieldDeclaration(FieldDeclaration dec, object data) {
			var modifier = ConvertModifiler(dec.Modifier);
			var type = ConvertType(dec.TypeReference);
			var decs =
				from varDec in dec.Fields
				let name = varDec.Name
				let value =
					varDec.Initializer.AcceptVisitor(this, null) as UnifiedExpression
				select new UnifiedVariableDefinition {
					Name = name,
					Type = type,
					Modifiers = modifier,
					InitialValue = value,
				};
			return decs.ToList();
		}

		public object VisitConstructorDeclaration(ConstructorDeclaration ctorDec, object data) {
			var modifier = ConvertModifiler(ctorDec.Modifier);
			var parameters = ConvertParameters(ctorDec.Parameters);
			var block = VisitBlockStatement(ctorDec.Body, null) as UnifiedBlock;
			return new UnifiedConstructorDefinition {
				Modifiers = modifier,
				Parameters = parameters,
				Block = block,
			};
		}

		public object VisitMethodDeclaration(MethodDeclaration method, object data) {
			var parameters = ConvertParameters(method.Parameters);
			return new UnifiedFunctionDefinition {
				Name = method.Name,
				Modifiers = ConvertModifiler(method.Modifier),
				Parameters = parameters,
				Type = ConvertType(method.TypeReference),
				Body = VisitBlockStatement(method.Body, data) as UnifiedBlock
			};
		}

		private static UnifiedParameterCollection ConvertParameters(IEnumerable<ParameterDeclarationExpression> parameters) {
			return new UnifiedParameterCollection(
				parameters.Select(ConvertParameter));
		}

		public object VisitParameterDeclarationExpression(ParameterDeclarationExpression parameter, object data) {
			return ConvertParameter(parameter);
		}

		private static UnifiedParameter ConvertParameter(ParameterDeclarationExpression parameter) {
			return new UnifiedParameter {
				Name = parameter.ParameterName,
				Type = ConvertType(parameter.TypeReference),
			};
		}

		#endregion

		#region block and statements

		private UnifiedExpression ConvertStatement(Statement stmt) {
			var obj = stmt.AcceptVisitor(this, null);
			var expr = obj as UnifiedExpression;
			if (expr != null)
				return expr;
			var exprs = obj as IEnumerable<UnifiedExpression>;
			if (exprs != null) {
				var exprList = exprs.ToList();
				if (exprList.Count == 1)
					return exprList[0];
				return new UnifiedBlock(exprList);
			}
			throw new NotImplementedException();
		}

		private UnifiedBlock ConvertStatementAsBlock(Statement stmt) {
			if (stmt is BlockStatement) {
				return VisitBlockStatement((BlockStatement)stmt, null) as UnifiedBlock;
			}
			return new UnifiedBlock { ConvertStatement(stmt) };
		}

		private UnifiedExpression ConvertStatements(IList<Statement> stmts) {
			if (stmts.Count == 1)
				return ConvertStatement(stmts[0]);
			else
				return ConvertStatementsAsBlock(stmts);
		}

		private UnifiedBlock ConvertStatementsAsBlock(IEnumerable<Statement> stmts) {
			var block = new UnifiedBlock();
			foreach (var stmt in stmts) {
				block.Add(ConvertStatement(stmt));
			}
			return block;
		}

		public object VisitBlockStatement(BlockStatement block, object data) {
			var stmts = block.Children
				.Select(node => node.AcceptVisitor(this, null))
				.ToList();
			return ToFlattenBlock(stmts);
		}

		public object VisitLocalVariableDeclaration(LocalVariableDeclaration dec, object data) {
			var modifier = ConvertModifiler(dec.Modifier);
			var type = ConvertType(dec.TypeReference);
			var decs =
				from varDec in dec.Variables
				let name = varDec.Name
				let value =
					varDec.Initializer.AcceptVisitor(this, null) as UnifiedExpression
				select new UnifiedVariableDefinition {
					Name = name,
					Type = type,
					Modifiers = modifier,
					InitialValue = value,
				};
			return decs.ToList();
		}

		public object VisitIfElseStatement(IfElseStatement stmt, object data) {
			var cond = stmt.Condition.AcceptVisitor(this, data) as UnifiedExpression;
			var trueStmt = stmt.TrueStatement
				.Select(s => s.AcceptVisitor(this, data))
				.ToList();
			var first = stmt.TrueStatement[0] as BlockStatement;
			var falseStmt = stmt.FalseStatement
				.Select(s => s.AcceptVisitor(this, data))
				.ToList();
			return new UnifiedIf {
				Condition = cond,
				TrueBlock = ToFlattenBlock(trueStmt),
				FalseBlock = ToFlattenBlock(falseStmt),
			};
		}

		public object VisitForStatement(ForStatement forStatement, object data) {
			var init = ConvertStatements(forStatement.Initializers);
			var cond = ConvertExpression(forStatement.Condition);
			var step = ConvertStatements(forStatement.Iterator);
			var body = ConvertStatementAsBlock(forStatement.EmbeddedStatement);
			return new UnifiedFor {
				Initializer = init,
				Condition = cond,
				Step = step,
				Body = body
			};
		}

		public object VisitForeachStatement(ForeachStatement stmt, object data) {
			var type = ConvertType(stmt.TypeReference);
			var name = stmt.VariableName;
			var set = ConvertExpression(stmt.Expression);
			var body = ConvertStatementAsBlock(stmt.EmbeddedStatement);

			return new UnifiedForeach {
				Element = new UnifiedVariableDefinition { Type = type, Name = name },
				Set = set,
				Body = body,
			};
		}

		public object VisitReturnStatement(ReturnStatement stmt, object data) {
			var value = stmt.Expression.AcceptVisitor(this, data) as UnifiedExpression;
			return new UnifiedReturn { Value = value };
		}

		public object VisitExpressionStatement(ExpressionStatement stmt, object data) {
			return stmt.Expression.AcceptVisitor(this, data);
		}

		public object VisitEmptyStatement(EmptyStatement emptyStatement, object data) {
			return new UnifiedExpression[0];
		}

		#endregion

		#region expression

		public object VisitParenthesizedExpression(ParenthesizedExpression expr, object data) {
			return expr.Expression.AcceptVisitor(this, data);
		}

		private UnifiedExpression ConvertExpression(Expression expr) {
			return expr.AcceptVisitor(this, null) as UnifiedExpression;
		}

		public object VisitPrimitiveExpression(PrimitiveExpression primitive, object data) {
			switch (primitive.LiteralFormat) {
				case LiteralFormat.DecimalNumber:
					if (primitive.Value is int) {
						return UnifiedIntegerLiteral.Create((int)primitive.Value);
					}
					break;
				case LiteralFormat.StringLiteral:
					if (primitive.Value is string) {
						return UnifiedStringLiteral.Create((string)primitive.Value);
					}
					break;
			}
			throw new NotImplementedException("VisitPrimitiveExpression");
		}

		public object VisitInvocationExpression(InvocationExpression invoke, object data) {
			var target = ConvertExpression(invoke.TargetObject);
			var args = ConvertArguments(invoke.Arguments);
			return new UnifiedCall { Function = target, Arguments = args };
		}

		public object VisitIdentifierExpression(IdentifierExpression ident, object data) {
			return UnifiedVariable.Create(ident.Identifier);
		}

		public object VisitBinaryOperatorExpression(BinaryOperatorExpression expr, object data) {
			var op = ConvertBinaryOperator(expr.Op);
			var left = ConvertExpression(expr.Left);
			var right = ConvertExpression(expr.Right);
			return new UnifiedBinaryExpression {
				Operator = op,
				LeftHandSide = left,
				RightHandSide = right,
			};
		}

		public object VisitAssignmentExpression(AssignmentExpression assign, object data) {
			var op = new UnifiedBinaryOperator("=", UnifiedBinaryOperatorType.Assign);
			var left = ConvertExpression(assign.Left);
			var right = ConvertExpression(assign.Right);
			return new UnifiedBinaryExpression {
				Operator = op,
				LeftHandSide = left,
				RightHandSide = right,
			};
		}

		public object VisitArrayCreateExpression(ArrayCreateExpression expr, object data) {
			var arrayType = ConvertTypeIgnoringIsArray(expr.CreateType);
			var args = ConvertArguments(expr.Arguments);
			return new UnifiedArrayNew { Type = arrayType, Arguments = args };
		}

		public object VisitIndexerExpression(IndexerExpression expr, object data) {
			var target = ConvertExpression(expr.TargetObject);
			var args = ConvertArguments(expr.Indexes);
			return new UnifiedIndexer { Target = target, Arguments = args };
		}

		private UnifiedArgumentCollection ConvertArguments(IEnumerable<Expression> args) {
			return new UnifiedArgumentCollection(
				args.Select(arg => new UnifiedArgument { Value = ConvertExpression(arg) }));
		}

		public object VisitObjectCreateExpression(ObjectCreateExpression expr, object data) {
			var type = ConvertType(expr.CreateType);
			var args = ConvertArguments(expr.Parameters);
			return new UnifiedNew { Type = type, Arguments = args };
		}

		public object VisitMemberReferenceExpression(MemberReferenceExpression expr, object data) {
			var target = ConvertExpression(expr.TargetObject);
			var name = expr.MemberName;
			return new UnifiedProperty { Owner = target, Name = name };
		}

		public object VisitUnaryOperatorExpression(UnaryOperatorExpression expr, object data) {
			var op = ConvertUnaryOperator(expr.Op);
			var target = ConvertExpression(expr.Expression);
			return new UnifiedUnaryExpression { Operator = op, Operand = target };
		}

		#endregion

		#region not implemented

		public object VisitAddHandlerStatement(AddHandlerStatement addHandlerStatement, object data) {
			throw new NotImplementedException("VisitAddHandlerStatement");
		}

		public object VisitAddressOfExpression(AddressOfExpression addressOfExpression, object data) {
			throw new NotImplementedException("VisitAddressOfExpression");
		}

		public object VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data) {
			throw new NotImplementedException("VisitAnonymousMethodExpression");
		}

		public object VisitAttribute(ICSharpCode.NRefactory.Ast.Attribute attribute, object data) {
			throw new NotImplementedException("VisitAttribute");
		}

		public object VisitAttributeSection(AttributeSection attributeSection, object data) {
			throw new NotImplementedException("VisitAttributeSection");
		}

		public object VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression, object data) {
			throw new NotImplementedException("VisitBaseReferenceExpression");
		}

		public object VisitBreakStatement(BreakStatement breakStatement, object data) {
			throw new NotImplementedException("VisitBreakStatement");
		}

		public object VisitCaseLabel(CaseLabel caseLabel, object data) {
			throw new NotImplementedException("VisitCaseLabel");
		}

		public object VisitCastExpression(CastExpression castExpression, object data) {
			throw new NotImplementedException("VisitCastExpression");
		}

		public object VisitCatchClause(CatchClause catchClause, object data) {
			throw new NotImplementedException("VisitCatchClause");
		}

		public object VisitCheckedExpression(CheckedExpression checkedExpression, object data) {
			throw new NotImplementedException("VisitCheckedExpression");
		}

		public object VisitCheckedStatement(CheckedStatement checkedStatement, object data) {
			throw new NotImplementedException("VisitCheckedStatement");
		}

		public object VisitClassReferenceExpression(ClassReferenceExpression classReferenceExpression, object data) {
			throw new NotImplementedException("VisitClassReferenceExpression");
		}

		public object VisitCollectionInitializerExpression(CollectionInitializerExpression collectionInitializerExpression, object data) {
			throw new NotImplementedException("VisitCollectionInitializerExpression");
		}

		public object VisitCollectionRangeVariable(CollectionRangeVariable collectionRangeVariable, object data) {
			throw new NotImplementedException("VisitCollectionRangeVariable");
		}

		public object VisitConditionalExpression(ConditionalExpression conditionalExpression, object data) {
			throw new NotImplementedException("VisitConditionalExpression");
		}

		public object VisitConstructorInitializer(ConstructorInitializer constructorInitializer, object data) {
			throw new NotImplementedException("VisitConstructorInitializer");
		}

		public object VisitContinueStatement(ContinueStatement continueStatement, object data) {
			throw new NotImplementedException("VisitContinueStatement");
		}

		public object VisitDeclareDeclaration(DeclareDeclaration declareDeclaration, object data) {
			throw new NotImplementedException("VisitDeclareDeclaration");
		}

		public object VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression, object data) {
			throw new NotImplementedException("VisitDefaultValueExpression");
		}

		public object VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration, object data) {
			throw new NotImplementedException("VisitDelegateDeclaration");
		}

		public object VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data) {
			throw new NotImplementedException("VisitDestructorDeclaration");
		}

		public object VisitDirectionExpression(DirectionExpression directionExpression, object data) {
			throw new NotImplementedException("VisitDirectionExpression");
		}

		public object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data) {
			throw new NotImplementedException("VisitDoLoopStatement");
		}

		public object VisitElseIfSection(ElseIfSection elseIfSection, object data) {
			throw new NotImplementedException("VisitElseIfSection");
		}

		public object VisitEndStatement(EndStatement endStatement, object data) {
			throw new NotImplementedException("VisitEndStatement");
		}

		public object VisitEraseStatement(EraseStatement eraseStatement, object data) {
			throw new NotImplementedException("VisitEraseStatement");
		}

		public object VisitErrorStatement(ErrorStatement errorStatement, object data) {
			throw new NotImplementedException("VisitErrorStatement");
		}

		public object VisitEventAddRegion(EventAddRegion eventAddRegion, object data) {
			throw new NotImplementedException("VisitEventAddRegion");
		}

		public object VisitEventDeclaration(EventDeclaration eventDeclaration, object data) {
			throw new NotImplementedException("VisitEventDeclaration");
		}

		public object VisitEventRaiseRegion(EventRaiseRegion eventRaiseRegion, object data) {
			throw new NotImplementedException("VisitEventRaiseRegion");
		}

		public object VisitEventRemoveRegion(EventRemoveRegion eventRemoveRegion, object data) {
			throw new NotImplementedException("VisitEventRemoveRegion");
		}

		public object VisitExitStatement(ExitStatement exitStatement, object data) {
			throw new NotImplementedException("VisitExitStatement");
		}

		public object VisitExpressionRangeVariable(ExpressionRangeVariable expressionRangeVariable, object data) {
			throw new NotImplementedException("VisitExpressionRangeVariable");
		}

		public object VisitExternAliasDirective(ExternAliasDirective externAliasDirective, object data) {
			throw new NotImplementedException("VisitExternAliasDirective");
		}

		public object VisitFixedStatement(FixedStatement fixedStatement, object data) {
			throw new NotImplementedException("VisitFixedStatement");
		}

		public object VisitForNextStatement(ForNextStatement forNextStatement, object data) {
			throw new NotImplementedException("VisitForNextStatement");
		}

		public object VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement, object data) {
			throw new NotImplementedException("VisitGotoCaseStatement");
		}

		public object VisitGotoStatement(GotoStatement gotoStatement, object data) {
			throw new NotImplementedException("VisitGotoStatement");
		}

		public object VisitInnerClassTypeReference(InnerClassTypeReference innerClassTypeReference, object data) {
			throw new NotImplementedException("VisitInnerClassTypeReference");
		}

		public object VisitInterfaceImplementation(InterfaceImplementation interfaceImplementation, object data) {
			throw new NotImplementedException("VisitInterfaceImplementation");
		}

		public object VisitLabelStatement(LabelStatement labelStatement, object data) {
			throw new NotImplementedException("VisitLabelStatement");
		}

		public object VisitLambdaExpression(LambdaExpression lambdaExpression, object data) {
			throw new NotImplementedException("VisitLambdaExpression");
		}

		public object VisitLockStatement(LockStatement lockStatement, object data) {
			throw new NotImplementedException("VisitLockStatement");
		}

		public object VisitMemberInitializerExpression(MemberInitializerExpression memberInitializerExpression, object data) {
			throw new NotImplementedException("VisitMemberInitializerExpression");
		}

		public object VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression, object data) {
			throw new NotImplementedException("VisitNamedArgumentExpression");
		}

		public object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data) {
			throw new NotImplementedException("VisitNamespaceDeclaration");
		}

		public object VisitOnErrorStatement(OnErrorStatement onErrorStatement, object data) {
			throw new NotImplementedException("VisitOnErrorStatement");
		}

		public object VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data) {
			throw new NotImplementedException("VisitOperatorDeclaration");
		}

		public object VisitOptionDeclaration(OptionDeclaration optionDeclaration, object data) {
			throw new NotImplementedException("VisitOptionDeclaration");
		}

		public object VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression, object data) {
			throw new NotImplementedException("VisitPointerReferenceExpression");
		}

		public object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data) {
			throw new NotImplementedException("VisitPropertyDeclaration");
		}

		public object VisitPropertyGetRegion(PropertyGetRegion propertyGetRegion, object data) {
			throw new NotImplementedException("VisitPropertyGetRegion");
		}

		public object VisitPropertySetRegion(PropertySetRegion propertySetRegion, object data) {
			throw new NotImplementedException("VisitPropertySetRegion");
		}

		public object VisitQueryExpression(QueryExpression queryExpression, object data) {
			throw new NotImplementedException("VisitQueryExpression");
		}

		public object VisitQueryExpressionAggregateClause(QueryExpressionAggregateClause queryExpressionAggregateClause, object data) {
			throw new NotImplementedException("VisitQueryExpressionAggregateClause");
		}

		public object VisitQueryExpressionDistinctClause(QueryExpressionDistinctClause queryExpressionDistinctClause, object data) {
			throw new NotImplementedException("VisitQueryExpressionDistinctClause");
		}

		public object VisitQueryExpressionFromClause(QueryExpressionFromClause queryExpressionFromClause, object data) {
			throw new NotImplementedException("VisitQueryExpressionFromClause");
		}

		public object VisitQueryExpressionGroupClause(QueryExpressionGroupClause queryExpressionGroupClause, object data) {
			throw new NotImplementedException("VisitQueryExpressionGroupClause");
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

		public object VisitVariableDeclaration(VariableDeclaration dec, object data) {
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

		#endregion

	}
}
