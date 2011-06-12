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
using ICSharpCode.NRefactory.TypeSystem;
using Unicoen.Core.Model;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;

namespace Unicoen.Languages.CSharp.ModelFactories {

	internal partial class NRefactoryModelVisitor : IAstVisitor<object, IUnifiedElement> {

		public IUnifiedElement VisitCompilationUnit(CompilationUnit unit, object data) {
			Contract.Requires<ArgumentNullException>(unit != null);

			var prog = UnifiedProgram.Create();
			foreach (var child in unit.Children) {
				var elem = child.AcceptForExpression(this);
				if (elem != null)
					prog.Add(elem);
			}
			return prog;
		}

		public IUnifiedElement VisitAnonymousMethodExpression(AnonymousMethodExpression expr, object data) {
			throw new NotImplementedException("AnonymousMethodExpression");
		}

		public IUnifiedElement VisitUndocumentedExpression(UndocumentedExpression expr, object data) {
			throw new NotImplementedException("UndocumentedExpression");
		}

		public IUnifiedElement VisitArrayCreateExpression(ArrayCreateExpression array, object data) {
			Contract.Requires<ArgumentNullException>(array != null);

			var type = LookupType(array.Type);
			var uArgs = array.Arguments
					.Select(nExpr => nExpr.AcceptVisitor(this, data))
					.OfType<IUnifiedExpression>()
					.Select(uExpr => UnifiedArgument.Create(value: uExpr))
					.ToCollection();
			return type.WrapRectangleArray(uArgs);
		}

		public IUnifiedElement VisitArrayInitializerExpression(ArrayInitializerExpression arrayInit, object data) {
			throw new NotImplementedException("ArrayInitializerExpression");
		}

		public IUnifiedElement VisitAsExpression(AsExpression asExpr, object data) {
			throw new NotImplementedException("AsExpression");
		}

		public IUnifiedElement VisitAssignmentExpression(AssignmentExpression assign, object data) {
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

			var op = LookupBinaryOperator(expr.Operator);
			var left = expr.Left.AcceptForExpression(this);
			var right = expr.Right.AcceptForExpression(this);
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

			return UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, ident.Identifier);
		}

		public IUnifiedElement VisitIndexerExpression(IndexerExpression indexer, object data) {
			Contract.Requires<ArgumentNullException>(indexer != null);

			var target = indexer.Target.AcceptForExpression(this);
			var args =
					from arg in indexer.Arguments
					let uExpr = arg.AcceptForExpression(this)
					where uExpr != null
					select UnifiedArgument.Create(value: uExpr);
			return args.ToCollection();
		}

		public IUnifiedElement VisitInvocationExpression(
				InvocationExpression invoc, object data) {
			Contract.Requires<ArgumentNullException>(invoc != null);

			var target = invoc.Target.AcceptForExpression(this);
			var uArgs = UnifiedArgumentCollection.Create();
			foreach (var arg in invoc.Arguments) {
				var value = arg.AcceptForExpression(this);
				uArgs.Add(UnifiedArgument.Create(value: value));
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

		public IUnifiedElement VisitMemberReferenceExpression(MemberReferenceExpression propExpr, object data) {
			Contract.Requires<ArgumentNullException>(propExpr != null);

			var target = propExpr.Target.AcceptForExpression(this);
			var name = propExpr.MemberName.ToUnknownIdentifier();

			return UnifiedProperty.Create(target, name, ".");
		}

		public IUnifiedElement VisitNamedArgumentExpression(
				NamedArgumentExpression namedArgumentExpression, object data) {
			throw new NotImplementedException("NamedArgumentExpression");
		}

		public IUnifiedElement VisitNullReferenceExpression(
				NullReferenceExpression nullReferenceExpression, object data) {
			throw new NotImplementedException("NullReferenceExpression");
		}

		public IUnifiedElement VisitObjectCreateExpression(ObjectCreateExpression create, object data) {
			Contract.Requires<ArgumentNullException>(create != null);

			var uType = LookupType(create.Type);
			var args =
					from arg in create.Arguments
					let value = arg.AcceptForExpression(this)
					select UnifiedArgument.Create(value: value);

			return UnifiedNew.Create(uType, args.ToCollection());
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

		public IUnifiedElement VisitPrimitiveExpression(PrimitiveExpression prim, object data) {
			Contract.Requires<ArgumentNullException>(prim != null);

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

		public IUnifiedElement VisitUnaryOperatorExpression(UnaryOperatorExpression unary, object data) {
			Contract.Requires<ArgumentNullException>(unary != null);

			var op = LookupUnaryOperator(unary.Operator);
			var operand = unary.Expression.AcceptForExpression(this);
			return UnifiedUnaryExpression.Create(operand, op);
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

			var mods = LookupModifier(dec.Modifiers);
			var name = UnifiedIdentifier.Create(UnifiedIdentifierKind.Type, dec.Name);
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Members) {
				var uExpr = node.AcceptForExpression(this);
				if (uExpr != null)
					body.Add(uExpr);
			}
			switch (dec.ClassType) {
			case ClassType.Class:
				return UnifiedClass.Create(modifiers: mods, name: name, body: body);
			case ClassType.Struct:
				return UnifiedStruct.Create(modifiers: mods, name: name, body: body);
			default:
				var msg = "LookupClassKind : " + dec.ClassType + "には対応していません。";
				throw new IndexOutOfRangeException(msg);
			}
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

			var uBlock = UnifiedBlock.Create();
			foreach (var stmt in block.Statements) {
				var uStmt = stmt.AcceptForExpression(this);
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

		public IUnifiedElement VisitExpressionStatement(ExpressionStatement exprStmt, object data) {
			Contract.Requires<ArgumentNullException>(exprStmt != null);

			return exprStmt.Expression.AcceptForExpression(this);
		}

		public IUnifiedElement VisitFixedStatement(
				FixedStatement fixedStatement, object data) {
			throw new NotImplementedException("FixedStatement");
		}

		public IUnifiedElement VisitForeachStatement(ForeachStatement stmt, object data) {
			Contract.Requires<ArgumentNullException>(stmt != null);

			var type = LookupType(stmt.VariableType);
			var name = stmt.VariableName.ToVariableIdentifier();
			var set = stmt.InExpression.AcceptForExpression(this);
			var body = stmt.EmbeddedStatement.AcceptVisitor(this, data) as UnifiedBlock;

			var varDec = UnifiedVariableDefinition.Create(type: type, name: name);
			return UnifiedForeach.Create(varDec, set, body);
		}

		public IUnifiedElement VisitForStatement(ForStatement forStmt, object data) {
			Contract.Requires<ArgumentNullException>(forStmt != null);

			var initStmt = forStmt.Initializers
				.Select(s => s.AcceptForExpression(this))
				.ToBlock();
			var condExpr = forStmt.Condition.AcceptForExpression(this);
			var stepStmt = forStmt.Iterators
				.Select(s => s.AcceptForExpression(this))
				.ToBlock();
			var body = forStmt.EmbeddedStatement.AcceptVisitor(this, data) as UnifiedBlock;

			return UnifiedFor.Create(initStmt, condExpr, stepStmt, body);
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

			var cond = stmt.Condition.AcceptForExpression(this);
			var trueBlock = stmt.TrueStatement.AcceptVisitor(this, data) as UnifiedBlock;

			var nElseStmt = stmt.FalseStatement;
			if (nElseStmt == null) {
				return UnifiedIf.Create(cond, trueBlock);
			}
			else {
				var falseBlock = stmt.FalseStatement.AcceptVisitor(this, data) as UnifiedBlock;
				return UnifiedIf.Create(cond, trueBlock, falseBlock);
			}
		}

		public IUnifiedElement VisitLabelStatement(
				LabelStatement labelStatement, object data) {
			throw new NotImplementedException("LabelStatement");
		}

		public IUnifiedElement VisitLockStatement(
				LockStatement lockStatement, object data) {
			throw new NotImplementedException("LockStatement");
		}

		public IUnifiedElement VisitReturnStatement(ReturnStatement retStmt, object data) {
			Contract.Requires<ArgumentNullException>(retStmt != null);
			var nExpr = retStmt.Expression;

			if (nExpr == null)
				return UnifiedReturn.Create();
			var uExpr = nExpr.AcceptForExpression(this);
			return UnifiedReturn.Create(uExpr);
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

		public IUnifiedElement VisitVariableDeclarationStatement(VariableDeclarationStatement dec, object data) {
			Contract.Requires<ArgumentNullException>(dec != null);

			var uType = LookupType(dec.Type);
			var uMods = LookupModifier(dec.Modifiers);

			var variables =
				from nVar in dec.Variables
				let name = nVar.Name
				let nInitValue = nVar.Initializer
				let uInitValue = nInitValue == null
						? null
						: nInitValue.AcceptForExpression(this)
				select UnifiedVariableDefinition.Create(
						type: uType.DeepCopy(),
						modifiers: uMods.DeepCopy(),
						name: name.ToVariableIdentifier(),
						initialValue: uInitValue);

			return variables.ToVariableDefinitionList();
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

		public IUnifiedElement VisitConstructorDeclaration(ConstructorDeclaration ctorDec, object data) {
			var uMods = LookupModifier(ctorDec.Modifiers);
			var uBody = ctorDec.Body.AcceptVisitor(this, data) as UnifiedBlock;

			var uParms = UnifiedParameterCollection.Create();
			foreach (var param in ctorDec.Parameters) {
				var type = LookupType(param.Type);
				var names = UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, param.Name).ToCollection();
				uParms.Add(UnifiedParameter.Create(type: type, names: names));
			}

			return UnifiedConstructorDefinition.Create(
				UnifiedConstructorDefinitionKind.Constructor, body: uBody, modifiers: uMods, parameters: uParms);
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

			var definitions =
				from nVar in dec.Variables
				let name = nVar.Name
				let nInitValue = nVar.Initializer
				let uInitValue = nInitValue == null
						? null
						: nInitValue.AcceptForExpression(this)
				select UnifiedVariableDefinition.Create(
						type: uType.DeepCopy(),
						modifiers: uMods.DeepCopy(),
						name: name.ToVariableIdentifier(),
						initialValue: uInitValue);

			return definitions.ToVariableDefinitionList();
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
			var name = UnifiedIdentifier.Create(UnifiedIdentifierKind.Function, dec.Name);
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Body) {
				var uExpr = node.AcceptForExpression(this);
				if (uExpr != null)
					body.Add(uExpr);
			}

			var kind = UnifiedFunctionDefinitionKind.Function;
			return UnifiedFunctionDefinition.Create(kind, modifiers: mods, type: type, name: name, body: body);
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