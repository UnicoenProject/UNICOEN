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
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Unicoen.Core.Model;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;

namespace Unicoen.Languages.CSharp.ModelFactories {
	internal partial class NRefactoryModelVisitor
			: IAstVisitor<object, IUnifiedElement> {
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

		public IUnifiedElement VisitAnonymousMethodExpression(
				AnonymousMethodExpression anonymousMethodExpression, object data) {
			throw new NotImplementedException("AnonymousMethodExpression");
		}

		public IUnifiedElement VisitUndocumentedExpression(
				UndocumentedExpression undocumentedExpression, object data) {
			throw new NotImplementedException("UndocumentedExpression");
		}

		public IUnifiedElement VisitArrayCreateExpression(
				ArrayCreateExpression array, object data) {
			//var type = LookupType(array.Type);
			//foreach (var spec in array.AdditionalArraySpecifiers) {
			//    type.AddSupplement(UnifiedTypeSupplement.CreateRectangleArray(spec.Dimensions));
			//}
			//return UnifiedNew.Create()

			throw new NotImplementedException("ArrayCreateExpression");
		}

		public IUnifiedElement VisitArrayInitializerExpression(
				ArrayInitializerExpression arrayInitializerExpression, object data) {
			throw new NotImplementedException("ArrayInitializerExpression");
		}

		public IUnifiedElement VisitAsExpression(
				AsExpression asExpression, object data) {
			throw new NotImplementedException("AsExpression");
		}

		public IUnifiedElement VisitAssignmentExpression(
				AssignmentExpression assign, object data) {
			Contract.Requires<ArgumentNullException>(assign != null);

			var op = UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign);
			var left = assign.Left.AcceptVisitor(this, data) as IUnifiedExpression;
			var right = assign.Right.AcceptVisitor(this, data) as IUnifiedExpression;

			return UnifiedBinaryExpression.Create(left, op, right);
		}

		public IUnifiedElement VisitBaseReferenceExpression(
				BaseReferenceExpression baseReferenceExpression, object data) {
			throw new NotImplementedException("BaseReferenceExpression");
		}

		public IUnifiedElement VisitBinaryOperatorExpression(
				BinaryOperatorExpression expr, object data) {
			Contract.Requires<ArgumentNullException>(expr != null);
			Contract.Ensures(
					Contract.Result<IUnifiedElement>() is UnifiedBinaryExpression);

			var op = LookupBinaryOperator(expr.Operator);
			var left = expr.Left.AcceptVisitor(this, data) as IUnifiedExpression;
			var right = expr.Right.AcceptVisitor(this, data) as IUnifiedExpression;
			return UnifiedBinaryExpression.Create(left, op, right);
		}

		public IUnifiedElement VisitCastExpression(
				CastExpression castExpression, object data) {
			throw new NotImplementedException("CastExpression");
		}

		public IUnifiedElement VisitCheckedExpression(
				CheckedExpression checkedExpression, object data) {
			throw new NotImplementedException("CheckedExpression");
		}

		public IUnifiedElement VisitConditionalExpression(
				ConditionalExpression conditionalExpression, object data) {
			throw new NotImplementedException("ConditionalExpression");
		}

		public IUnifiedElement VisitDefaultValueExpression(
				DefaultValueExpression defaultValueExpression, object data) {
			throw new NotImplementedException("DefaultValueExpression");
		}

		public IUnifiedElement VisitDirectionExpression(
				DirectionExpression directionExpression, object data) {
			throw new NotImplementedException("DirectionExpression");
		}

		public IUnifiedElement VisitIdentifierExpression(
				IdentifierExpression ident, object data) {
			Contract.Requires<ArgumentNullException>(ident != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedIdentifier);

			return UnifiedIdentifier.Create(ident.Identifier, UnifiedIdentifierKind.Variable);
		}

		public IUnifiedElement VisitIndexerExpression(
				IndexerExpression indexerExpression, object data) {
			throw new NotImplementedException("IndexerExpression");
		}

		public IUnifiedElement VisitInvocationExpression(
				InvocationExpression invoc, object data) {
			Contract.Requires<ArgumentNullException>(invoc != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedCall);

			var target = invoc.Target.AcceptVisitor(this, data) as IUnifiedExpression;
			var uArgs = UnifiedArgumentCollection.Create();
			foreach (var arg in invoc.Arguments) {
				var value = arg.AcceptVisitor(this, data) as IUnifiedExpression;
				uArgs.Add(UnifiedArgument.Create(null, null, value));
			}
			return UnifiedCall.Create(target, uArgs);
		}

		public IUnifiedElement VisitIsExpression(
				IsExpression isExpression, object data) {
			throw new NotImplementedException("IsExpression");
		}

		public IUnifiedElement VisitLambdaExpression(
				LambdaExpression lambdaExpression, object data) {
			throw new NotImplementedException("LambdaExpression");
		}

		public IUnifiedElement VisitMemberReferenceExpression(
				MemberReferenceExpression memberReferenceExpression, object data) {
			throw new NotImplementedException("MemberReferenceExpression");
		}

		public IUnifiedElement VisitNamedArgumentExpression(
				NamedArgumentExpression namedArgumentExpression, object data) {
			throw new NotImplementedException("NamedArgumentExpression");
		}

		public IUnifiedElement VisitNullReferenceExpression(
				NullReferenceExpression nullReferenceExpression, object data) {
			throw new NotImplementedException("NullReferenceExpression");
		}

		public IUnifiedElement VisitObjectCreateExpression(
				ObjectCreateExpression objectCreateExpression, object data) {
			throw new NotImplementedException("ObjectCreateExpression");
		}

		public IUnifiedElement VisitAnonymousTypeCreateExpression(
				AnonymousTypeCreateExpression anonymousTypeCreateExpression, object data) {
			throw new NotImplementedException("AnonymousTypeCreateExpression");
		}

		public IUnifiedElement VisitParenthesizedExpression(
				ParenthesizedExpression parenthesizedExpression, object data) {
			throw new NotImplementedException("ParenthesizedExpression");
		}

		public IUnifiedElement VisitPointerReferenceExpression(
				PointerReferenceExpression pointerReferenceExpression, object data) {
			throw new NotImplementedException("PointerReferenceExpression");
		}

		public IUnifiedElement VisitPrimitiveExpression(
				PrimitiveExpression prim, object data) {
			Contract.Requires<ArgumentNullException>(prim != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedLiteral);

			return ParseValue(prim.Value);
		}

		public IUnifiedElement VisitSizeOfExpression(
				SizeOfExpression sizeOfExpression, object data) {
			throw new NotImplementedException("SizeOfExpression");
		}

		public IUnifiedElement VisitStackAllocExpression(
				StackAllocExpression stackAllocExpression, object data) {
			throw new NotImplementedException("StackAllocExpression");
		}

		public IUnifiedElement VisitThisReferenceExpression(
				ThisReferenceExpression thisReferenceExpression, object data) {
			throw new NotImplementedException("ThisReferenceExpression");
		}

		public IUnifiedElement VisitTypeOfExpression(
				TypeOfExpression typeOfExpression, object data) {
			throw new NotImplementedException("TypeOfExpression");
		}

		public IUnifiedElement VisitTypeReferenceExpression(
				TypeReferenceExpression typeReferenceExpression, object data) {
			throw new NotImplementedException("TypeReferenceExpression");
		}

		public IUnifiedElement VisitUnaryOperatorExpression(
				UnaryOperatorExpression unaryOperatorExpression, object data) {
			throw new NotImplementedException("UnaryOperatorExpression");
		}

		public IUnifiedElement VisitUncheckedExpression(
				UncheckedExpression uncheckedExpression, object data) {
			throw new NotImplementedException("UncheckedExpression");
		}

		public IUnifiedElement VisitEmptyExpression(
				EmptyExpression emptyExpression, object data) {
			throw new NotImplementedException("EmptyExpression");
		}

		public IUnifiedElement VisitQueryExpression(
				QueryExpression queryExpression, object data) {
			throw new NotImplementedException("QueryExpression");
		}

		public IUnifiedElement VisitQueryContinuationClause(
				QueryContinuationClause queryContinuationClause, object data) {
			throw new NotImplementedException("QueryContinuationClause");
		}

		public IUnifiedElement VisitQueryFromClause(
				QueryFromClause queryFromClause, object data) {
			throw new NotImplementedException("QueryFromClause");
		}

		public IUnifiedElement VisitQueryLetClause(
				QueryLetClause queryLetClause, object data) {
			throw new NotImplementedException("QueryLetClause");
		}

		public IUnifiedElement VisitQueryWhereClause(
				QueryWhereClause queryWhereClause, object data) {
			throw new NotImplementedException("QueryWhereClause");
		}

		public IUnifiedElement VisitQueryJoinClause(
				QueryJoinClause queryJoinClause, object data) {
			throw new NotImplementedException("QueryJoinClause");
		}

		public IUnifiedElement VisitQueryOrderClause(
				QueryOrderClause queryOrderClause, object data) {
			throw new NotImplementedException("QueryOrderClause");
		}

		public IUnifiedElement VisitQueryOrdering(
				QueryOrdering queryOrdering, object data) {
			throw new NotImplementedException("QueryOrdering");
		}

		public IUnifiedElement VisitQuerySelectClause(
				QuerySelectClause querySelectClause, object data) {
			throw new NotImplementedException("QuerySelectClause");
		}

		public IUnifiedElement VisitQueryGroupClause(
				QueryGroupClause queryGroupClause, object data) {
			throw new NotImplementedException("QueryGroupClause");
		}

		public IUnifiedElement VisitAttribute(Attribute attribute, object data) {
			throw new NotImplementedException("Attribute");
		}

		public IUnifiedElement VisitAttributeSection(
				AttributeSection attributeSection, object data) {
			throw new NotImplementedException("AttributeSection");
		}

		public IUnifiedElement VisitDelegateDeclaration(
				DelegateDeclaration delegateDeclaration, object data) {
			throw new NotImplementedException("DelegateDeclaration");
		}

		public IUnifiedElement VisitNamespaceDeclaration(
				NamespaceDeclaration namespaceDeclaration, object data) {
			throw new NotImplementedException("NamespaceDeclaration");
		}

		public IUnifiedElement VisitTypeDeclaration(TypeDeclaration dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);
			Contract.Ensures(
					Contract.Result<IUnifiedElement>() is UnifiedClassDefinition);

			var kind = LookupClassKind(dec.ClassType);
			var mods = LookupModifier(dec.Modifiers);
			var name = UnifiedIdentifier.Create(dec.Name, UnifiedIdentifierKind.Type);
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Members) {
				var uExpr = node.AcceptVisitor(this, data) as IUnifiedExpression;
				if (uExpr != null)
					body.Add(uExpr);
			}
			return UnifiedClassDefinition.Create(kind, null, mods, name, null, null, body);
		}

		public IUnifiedElement VisitUsingAliasDeclaration(
				UsingAliasDeclaration usingAliasDeclaration, object data) {
			throw new NotImplementedException("UsingAliasDeclaration");
		}

		public IUnifiedElement VisitUsingDeclaration(
				UsingDeclaration usingDeclaration, object data) {
			throw new NotImplementedException("UsingDeclaration");
		}

		public IUnifiedElement VisitExternAliasDeclaration(
				ExternAliasDeclaration externAliasDeclaration, object data) {
			throw new NotImplementedException("ExternAliasDeclaration");
		}

		public IUnifiedElement VisitBlockStatement(BlockStatement block, object data) {
			Contract.Requires<ArgumentNullException>(block != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedBlock);

			var uBlock = UnifiedBlock.Create();
			foreach (var stmt in block.Statements) {
				var uStmt = stmt.AcceptVisitor(this, data) as IUnifiedExpression;
				if (uStmt != null)
					uBlock.Add(uStmt);
			}
			return uBlock;
		}

		public IUnifiedElement VisitBreakStatement(
				BreakStatement breakStatement, object data) {
			throw new NotImplementedException("BreakStatement");
		}

		public IUnifiedElement VisitCheckedStatement(
				CheckedStatement checkedStatement, object data) {
			throw new NotImplementedException("CheckedStatement");
		}

		public IUnifiedElement VisitContinueStatement(
				ContinueStatement continueStatement, object data) {
			throw new NotImplementedException("ContinueStatement");
		}

		public IUnifiedElement VisitDoWhileStatement(
				DoWhileStatement doWhileStatement, object data) {
			throw new NotImplementedException("DoWhileStatement");
		}

		public IUnifiedElement VisitEmptyStatement(
				EmptyStatement emptyStatement, object data) {
			throw new NotImplementedException("EmptyStatement");
		}

		public IUnifiedElement VisitExpressionStatement(
				ExpressionStatement exprStmt, object data) {
			Contract.Requires<ArgumentNullException>(exprStmt != null);

			return exprStmt.Expression.AcceptVisitor(this, data) as IUnifiedExpression;
		}

		public IUnifiedElement VisitFixedStatement(
				FixedStatement fixedStatement, object data) {
			throw new NotImplementedException("FixedStatement");
		}

		public IUnifiedElement VisitForeachStatement(
				ForeachStatement foreachStatement, object data) {
			throw new NotImplementedException("ForeachStatement");
		}

		public IUnifiedElement VisitForStatement(
				ForStatement forStatement, object data) {
			throw new NotImplementedException("ForStatement");
		}

		public IUnifiedElement VisitGotoCaseStatement(
				GotoCaseStatement gotoCaseStatement, object data) {
			throw new NotImplementedException("GotoCaseStatement");
		}

		public IUnifiedElement VisitGotoDefaultStatement(
				GotoDefaultStatement gotoDefaultStatement, object data) {
			throw new NotImplementedException("GotoDefaultStatement");
		}

		public IUnifiedElement VisitGotoStatement(
				GotoStatement gotoStatement, object data) {
			throw new NotImplementedException("GotoStatement");
		}

		public IUnifiedElement VisitIfElseStatement(IfElseStatement stmt, object data) {
			Contract.Requires<ArgumentNullException>(stmt != null);
			Contract.Ensures(Contract.Result<IUnifiedElement>() is UnifiedIf);

			var cond = stmt.Condition.AcceptVisitor(this, data) as IUnifiedExpression;
			var trueBlock = stmt.TrueStatement.AcceptVisitor(this, data) as UnifiedBlock;

			var nElseStmt = stmt.FalseStatement;
			var falseBlock = null as UnifiedBlock;
			if (nElseStmt != null)
				falseBlock = stmt.FalseStatement.AcceptVisitor(this, data) as UnifiedBlock;

			return UnifiedIf.Create(cond, trueBlock, falseBlock);
		}

		public IUnifiedElement VisitLabelStatement(
				LabelStatement labelStatement, object data) {
			throw new NotImplementedException("LabelStatement");
		}

		public IUnifiedElement VisitLockStatement(
				LockStatement lockStatement, object data) {
			throw new NotImplementedException("LockStatement");
		}

		public IUnifiedElement VisitReturnStatement(
				ReturnStatement retStmt, object data) {
			Contract.Requires<ArgumentNullException>(retStmt != null);
			Contract.Ensures(
					Contract.Result<IUnifiedElement>() is UnifiedSpecialExpression);

			var nExpr = retStmt.Expression;
			var uExpr = nExpr == null
			            		? null
			            		: retStmt.Expression.AcceptVisitor(this, data) as
			            		  IUnifiedExpression;
			return UnifiedSpecialExpression.Create(UnifiedSpecialExpressionKind.Return, uExpr);
		}

		public IUnifiedElement VisitSwitchStatement(
				SwitchStatement switchStatement, object data) {
			throw new NotImplementedException("SwitchStatement");
		}

		public IUnifiedElement VisitSwitchSection(
				SwitchSection switchSection, object data) {
			throw new NotImplementedException("SwitchSection");
		}

		public IUnifiedElement VisitCaseLabel(CaseLabel caseLabel, object data) {
			throw new NotImplementedException("CaseLabel");
		}

		public IUnifiedElement VisitThrowStatement(
				ThrowStatement throwStatement, object data) {
			throw new NotImplementedException("ThrowStatement");
		}

		public IUnifiedElement VisitTryCatchStatement(
				TryCatchStatement tryCatchStatement, object data) {
			throw new NotImplementedException("TryCatchStatement");
		}

		public IUnifiedElement VisitCatchClause(CatchClause catchClause, object data) {
			throw new NotImplementedException("CatchClause");
		}

		public IUnifiedElement VisitUncheckedStatement(
				UncheckedStatement uncheckedStatement, object data) {
			throw new NotImplementedException("UncheckedStatement");
		}

		public IUnifiedElement VisitUnsafeStatement(
				UnsafeStatement unsafeStatement, object data) {
			throw new NotImplementedException("UnsafeStatement");
		}

		public IUnifiedElement VisitUsingStatement(
				UsingStatement usingStatement, object data) {
			throw new NotImplementedException("UsingStatement");
		}

		public IUnifiedElement VisitVariableDeclarationStatement(
				VariableDeclarationStatement dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);

			var uType = LookupType(dec.Type);
			var uMods = LookupModifier(dec.Modifiers);

			return dec.Variables.Select(
					nVar => {
						var name = nVar.Name;
						var nInitValue = nVar.Initializer;
						var uInitValue = nInitValue == null
						                 		? null
						                 		: nInitValue.AcceptVisitor(this, data) as
						                 		  IUnifiedExpression;
						return UnifiedVariableDefinition.Create(
								type: uType.DeepCopy(),
								modifiers: uMods.DeepCopy(),
								name: name.ToVariableIdentifier(),
								initialValue: uInitValue);
					}).ToVariableDefinitionList();
			throw new NotImplementedException("VariableDeclarationStatement");
		}

		public IUnifiedElement VisitWhileStatement(
				WhileStatement whileStatement, object data) {
			throw new NotImplementedException("WhileStatement");
		}

		public IUnifiedElement VisitYieldBreakStatement(
				YieldBreakStatement yieldBreakStatement, object data) {
			throw new NotImplementedException("YieldBreakStatement");
		}

		public IUnifiedElement VisitYieldStatement(
				YieldStatement yieldStatement, object data) {
			throw new NotImplementedException("YieldStatement");
		}

		public IUnifiedElement VisitAccessor(Accessor accessor, object data) {
			throw new NotImplementedException("Accessor");
		}

		public IUnifiedElement VisitConstructorDeclaration(
				ConstructorDeclaration ctorDec, object data) {
			var uMods = LookupModifier(ctorDec.Modifiers);
			var uBody = ctorDec.Body.AcceptVisitor(this, data) as UnifiedBlock;

			var uParms = UnifiedParameterCollection.Create();
			foreach (var param in ctorDec.Parameters) {
				var type = LookupType(param.Type);
				var name = param.Name;
				var uParam = UnifiedParameter.Create(
						null,
						null,
						type,
						UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable).ToCollection(),
						null);
				uParms.Add(uParam);
			}

			return UnifiedConstructorDefinition.Create(
					UnifiedConstructorDefinitionKind.Constructor, uBody, null, uMods, uParms, null, null);

			throw new NotImplementedException("ConstructorDeclaration");
		}

		public IUnifiedElement VisitConstructorInitializer(
				ConstructorInitializer constructorInitializer, object data) {
			throw new NotImplementedException("ConstructorInitializer");
		}

		public IUnifiedElement VisitDestructorDeclaration(
				DestructorDeclaration destructorDeclaration, object data) {
			throw new NotImplementedException("DestructorDeclaration");
		}

		public IUnifiedElement VisitEnumMemberDeclaration(
				EnumMemberDeclaration enumMemberDeclaration, object data) {
			throw new NotImplementedException("EnumMemberDeclaration");
		}

		public IUnifiedElement VisitEventDeclaration(
				EventDeclaration eventDeclaration, object data) {
			throw new NotImplementedException("EventDeclaration");
		}

		public IUnifiedElement VisitCustomEventDeclaration(
				CustomEventDeclaration customEventDeclaration, object data) {
			throw new NotImplementedException("CustomEventDeclaration");
		}

		public IUnifiedElement VisitFieldDeclaration(
				FieldDeclaration dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);

			var uType = LookupType(dec.ReturnType);
			var uMods = LookupModifier(dec.Modifiers);
			return dec.Variables.Select(
					nVar => {
						var name = nVar.Name;
						var nInitValue = nVar.Initializer;
						var uInitValue = nInitValue == null
						                 		? null
						                 		: nInitValue.AcceptVisitor(this, data) as
						                 		  IUnifiedExpression;
						return UnifiedVariableDefinition.Create(
								type: uType.DeepCopy(),
								modifiers: uMods.DeepCopy(),
								name: name.ToVariableIdentifier(),
								initialValue: uInitValue);
					}).ToVariableDefinitionList();
		}

		public IUnifiedElement VisitIndexerDeclaration(
				IndexerDeclaration indexerDeclaration, object data) {
			throw new NotImplementedException("IndexerDeclaration");
		}

		public IUnifiedElement VisitMethodDeclaration(
				MethodDeclaration dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);
			Contract.Ensures(
					Contract.Result<IUnifiedElement>() is UnifiedFunctionDefinition);

			var mods = LookupModifier(dec.Modifiers);
			var type = LookupType(dec.ReturnType);
			var name = dec.Name;
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Body) {
				var uExpr = node.AcceptVisitor(this, data) as IUnifiedExpression;
				if (uExpr != null)
					body.Add(uExpr);
			}

			return UnifiedFunctionDefinition.Create(
					UnifiedFunctionDefinitionKind.Function,
					null, mods, type, null, UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Function), null, null, body);
		}

		public IUnifiedElement VisitOperatorDeclaration(
				OperatorDeclaration operatorDeclaration, object data) {
			throw new NotImplementedException("OperatorDeclaration");
		}

		public IUnifiedElement VisitParameterDeclaration(
				ParameterDeclaration parameterDeclaration, object data) {
			throw new NotImplementedException("ParameterDeclaration");
		}

		public IUnifiedElement VisitPropertyDeclaration(
				PropertyDeclaration propertyDeclaration, object data) {
			throw new NotImplementedException("PropertyDeclaration");
		}

		public IUnifiedElement VisitVariableInitializer(
				VariableInitializer variableInitializer, object data) {
			throw new NotImplementedException("VariableInitializer");
		}

		public IUnifiedElement VisitFixedFieldDeclaration(
				FixedFieldDeclaration fixedFieldDeclaration, object data) {
			throw new NotImplementedException("FixedFieldDeclaration");
		}

		public IUnifiedElement VisitFixedVariableInitializer(
				FixedVariableInitializer fixedVariableInitializer, object data) {
			throw new NotImplementedException("FixedVariableInitializer");
		}

		public IUnifiedElement VisitSimpleType(SimpleType simpleType, object data) {
			throw new NotImplementedException("SimpleType");
		}

		public IUnifiedElement VisitMemberType(MemberType memberType, object data) {
			throw new NotImplementedException("MemberType");
		}

		public IUnifiedElement VisitComposedType(
				ComposedType composedType, object data) {
			throw new NotImplementedException("ComposedType");
		}

		public IUnifiedElement VisitArraySpecifier(
				ArraySpecifier arraySpecifier, object data) {
			throw new NotImplementedException("ArraySpecifier");
		}

		public IUnifiedElement VisitPrimitiveType(
				PrimitiveType primitiveType, object data) {
			throw new NotImplementedException("PrimitiveType");
		}

		public IUnifiedElement VisitComment(Comment comment, object data) {
			throw new NotImplementedException("Comment");
		}

		public IUnifiedElement VisitTypeParameterDeclaration(
				TypeParameterDeclaration typeParameterDeclaration, object data) {
			throw new NotImplementedException("TypeParameterDeclaration");
		}

		public IUnifiedElement VisitConstraint(Constraint constraint, object data) {
			throw new NotImplementedException("Constraint");
		}

		public IUnifiedElement VisitCSharpTokenNode(
				CSharpTokenNode tokenNode, object data) {
			// TODO よく分からないから調べる
			return null;
			//throw new NotImplementedException("CSharpTokenNode");
		}

		public IUnifiedElement VisitIdentifier(Identifier identifier, object data) {
			throw new NotImplementedException("Identifier");
		}

		public IUnifiedElement VisitPatternPlaceholder(
				AstNode placeholder, Pattern pattern, object data) {
			throw new NotImplementedException("AstNode");
		}
			}
}