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
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using Unicoen.Model;
using Attribute = ICSharpCode.NRefactory.CSharp.Attribute;

namespace Unicoen.Languages.CSharp.ProgramGenerators {

	internal partial class NRefactoryAstVisitor : IAstVisitor<object, IUnifiedElement> {

		public IUnifiedElement VisitCompilationUnit(CompilationUnit unit, object data) {
			var prog = UnifiedProgram.Create(UnifiedBlock.Create());
			foreach (var child in unit.Children) {
				var elem = child.TryAcceptForExpression(this);
				if (elem != null)
					prog.Body.Add(elem);
			}
			return prog;
		}

		#region expression

		public IUnifiedElement VisitAnonymousMethodExpression(AnonymousMethodExpression expr, object data) {
			var parameters = expr.Parameters.AcceptVisitorAsParams(this, data);
			var body = expr.Body.TryAcceptForExpression(this).ToBlock();
			return UnifiedLambda.Create(parameters: parameters, body: body);
		}

		public IUnifiedElement VisitUndocumentedExpression(UndocumentedExpression expr, object data) {
			throw new NotImplementedException("UndocumentedExpression");
		}

		public IUnifiedElement VisitArrayCreateExpression(ArrayCreateExpression array, object data) {
			var type = LookupType(array.Type);
			var uArgs = array.Arguments.AcceptVisitorAsArgs(this, data);
			var initValues = null as UnifiedArrayLiteral;
			if (array.Initializer != null) {
				initValues = array.Initializer.AcceptVisitor(this, data) as UnifiedArrayLiteral;
			}
			return UnifiedNew.Create(type.WrapRectangleArray(uArgs), initialValues: initValues);
		}

		public IUnifiedElement VisitArrayInitializerExpression(ArrayInitializerExpression arrayInit, object data) {
			return arrayInit.Elements
					.Select(e => e.TryAcceptForExpression(this))
					.ToArrayLiteral();
		}

		public IUnifiedElement VisitAsExpression(AsExpression asExpr, object data) {
			var op = UnifiedBinaryOperator.Create("as", UnifiedBinaryOperatorKind.As);
			var value = asExpr.Expression.TryAcceptForExpression(this);
			var type = LookupType(asExpr.Type);
			return UnifiedBinaryExpression.Create(value, op, type);
		}

		public IUnifiedElement VisitAssignmentExpression(AssignmentExpression assign, object data) {
			var op = UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign);
			var left = assign.Left.TryAcceptForExpression(this);
			var right = assign.Right.TryAcceptForExpression(this);
			return UnifiedBinaryExpression.Create(left, op, right);
		}

		public IUnifiedElement VisitBaseReferenceExpression(BaseReferenceExpression expr, object data) {
			return UnifiedSuperIdentifier.Create("base");
		}

		public IUnifiedElement VisitBinaryOperatorExpression(BinaryOperatorExpression expr, object data) {
			var op = LookupBinaryOperator(expr.Operator);
			var left = expr.Left.TryAcceptForExpression(this);
			var right = expr.Right.TryAcceptForExpression(this);
			return UnifiedBinaryExpression.Create(left, op, right);
		}

		public IUnifiedElement VisitCastExpression(CastExpression expr, object data) {
			var type = LookupType(expr.Type);
			var elem = expr.Expression.TryAcceptForExpression(this);
			return UnifiedCast.Create(type, elem);
		}

		public IUnifiedElement VisitCheckedExpression(
				CheckedExpression checkedExpression, object data) {
			throw new NotImplementedException("CheckedExpression");
		}

		public IUnifiedElement VisitConditionalExpression(ConditionalExpression expr, object data) {
			var cond = expr.Condition.TryAcceptForExpression(this);
			var former = expr.TrueExpression.TryAcceptForExpression(this);
			var latter = expr.FalseExpression.TryAcceptForExpression(this);
			return UnifiedTernaryExpression.Create(cond, former, latter);
		}

		public IUnifiedElement VisitDefaultValueExpression(DefaultValueExpression expr, object data) {
			var type = LookupType(expr.Type);
			return UnifiedDefault.Create(type);
		}

		public IUnifiedElement VisitDirectionExpression(DirectionExpression expr, object data) {
			var mods = LookupModifier(expr.FieldDirection).ToCollection();
			var value = expr.Expression.TryAcceptForExpression(this);
			return UnifiedArgument.Create(value, null, mods);
		}

		public IUnifiedElement VisitIdentifierExpression(IdentifierExpression ident, object data) {
			return UnifiedVariableIdentifier.Create(ident.Identifier);
		}

		public IUnifiedElement VisitIndexerExpression(IndexerExpression indexer, object data) {
			var target = indexer.Target.TryAcceptForExpression(this);
			var args = indexer.Arguments.AcceptVisitorAsArgs(this, data);
			return UnifiedIndexer.Create(target, args);
		}

		public IUnifiedElement VisitInvocationExpression(InvocationExpression invoc, object data) {
			var target = invoc.Target.TryAcceptForExpression(this);
			var uArgs = invoc.Arguments.AcceptVisitorAsArgs(this, data);
			return UnifiedCall.Create(target, uArgs);
		}

		public IUnifiedElement VisitIsExpression(IsExpression expr, object data) {
			var op = UnifiedBinaryOperator.Create("is", UnifiedBinaryOperatorKind.InstanceOf);
			var value = expr.Expression.TryAcceptForExpression(this);
			var type = LookupType(expr.Type);
			return UnifiedBinaryExpression.Create(value, op, type);
		}

		public IUnifiedElement VisitLambdaExpression(LambdaExpression lambda, object data) {
			var parameters = lambda.Parameters.AcceptVisitorAsParams(this, data);
			var body = lambda.Body.TryAcceptForExpression(this).ToBlock();
			return UnifiedLambda.Create(parameters: parameters, body: body);
		}

		public IUnifiedElement VisitMemberReferenceExpression(MemberReferenceExpression propExpr, object data) {
			var target = propExpr.Target.TryAcceptForExpression(this);
			var name = propExpr.MemberName.ToVariableIdentifier();
			return UnifiedProperty.Create(".", target, name);
		}

		public IUnifiedElement VisitNamedArgumentExpression(NamedArgumentExpression expr, object data) {
			var name = UnifiedVariableIdentifier.Create(expr.Identifier);
			var value = expr.Expression.TryAcceptForExpression(this);
			return UnifiedArgument.Create(value: value, target: name);
		}

		public IUnifiedElement VisitNullReferenceExpression(NullReferenceExpression expr, object data) {
			return UnifiedNullLiteral.Create();
		}

		public IUnifiedElement VisitObjectCreateExpression(ObjectCreateExpression create, object data) {
			var uType = LookupType(create.Type);
			var args = create.Arguments.AcceptVisitorAsArgs(this, data);
			return UnifiedNew.Create(uType, args);
		}

		public IUnifiedElement VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression expr, object data) {
			var block = UnifiedBlock.Create();
			foreach(var nExpr in expr.Initializer) {
				var uExpr = nExpr.TryAcceptForExpression(this);
				if (uExpr != null)
					block.Add(uExpr);
			}
			return UnifiedNew.Create(body: block);
		}

		public IUnifiedElement VisitParenthesizedExpression(ParenthesizedExpression expr, object data) {
			return expr.Expression.AcceptVisitor(this, data);
		}

		public IUnifiedElement VisitPointerReferenceExpression(
				PointerReferenceExpression pointerReferenceExpression, object data) {
			throw new NotImplementedException("PointerReferenceExpression");
		}

		public IUnifiedElement VisitPrimitiveExpression(PrimitiveExpression prim, object data) {
			if (prim.Value == null) {
				return UnifiedNullLiteral.Create();
			}
			if (prim.Value is bool) {
				return UnifiedBooleanLiteral.Create((bool)prim.Value);
			}
			if (prim.Value is int) {
				return UnifiedIntegerLiteral.CreateInt32((int)prim.Value);
			}
			if (prim.Value is UInt64) {
				return UnifiedIntegerLiteral.CreateUInt64((UInt64)prim.Value);
			}
			if (prim.Value is double) {
				return UnifiedFractionLiteral.Create((double)prim.Value, UnifiedFractionLiteralKind.Double);
			}
			if (prim.Value is char) {
				return UnifiedCharLiteral.Create(((char)prim.Value).ToString());
			}
			if (prim.Value is string) {
				return UnifiedStringLiteral.Create(prim.LiteralValue);
			}
			throw new NotImplementedException("value type is " + prim.Value.GetType());
		}

		public IUnifiedElement VisitSizeOfExpression(
				SizeOfExpression sizeOfExpression, object data) {
			throw new NotImplementedException("SizeOfExpression");
		}

		public IUnifiedElement VisitStackAllocExpression(
				StackAllocExpression stackAllocExpression, object data) {
			throw new NotImplementedException("StackAllocExpression");
		}

		public IUnifiedElement VisitThisReferenceExpression(ThisReferenceExpression expr, object data) {
			return UnifiedThisIdentifier.Create("this");
		}

		public IUnifiedElement VisitTypeOfExpression(TypeOfExpression expr, object data) {
			var type = LookupType(expr.Type);
			return UnifiedTypeof.Create(type);
		}

		public IUnifiedElement VisitTypeReferenceExpression(TypeReferenceExpression expr, object data) {
			return LookupType(expr.Type);
		}

		public IUnifiedElement VisitUnaryOperatorExpression(UnaryOperatorExpression unary, object data) {
			var op = LookupUnaryOperator(unary.Operator);
			var operand = unary.Expression.TryAcceptForExpression(this);
			return UnifiedUnaryExpression.Create(operand, op);
		}

		public IUnifiedElement VisitUncheckedExpression(
				UncheckedExpression uncheckedExpression, object data) {
			throw new NotImplementedException("UncheckedExpression");
		}

		public IUnifiedElement VisitEmptyExpression(EmptyExpression empty, object data) {
			return null;
		}

		#region query

		public IUnifiedElement VisitQueryExpression(QueryExpression expr, object data) {
			return expr.Clauses
					.Select(c => c.AcceptVisitor(this, data))
					.OfType<UnifiedLinqQuery>()
					.ToLinqExpression();
		}

		public IUnifiedElement VisitQueryContinuationClause(QueryContinuationClause query, object data) {
			var expr = query.PrecedingQuery.AcceptVisitor(this, data);

			throw new NotImplementedException("QueryContinuationClause");
		}

		public IUnifiedElement VisitQueryFromClause(QueryFromClause from, object data) {
			var ident = UnifiedIdentifier.CreateVariable(from.Identifier);
			var expr = from.Expression.TryAcceptForExpression(this);
			if (from.Type == null)
				return UnifiedFromQuery.Create(ident, expr);
			var type = LookupType(from.Type);
			return UnifiedFromQuery.Create(ident, expr, type);
		}

		public IUnifiedElement VisitQueryLetClause(QueryLetClause let, object data) {
			var ident = UnifiedIdentifier.CreateVariable(let.Identifier);
			var expr = let.Expression.TryAcceptForExpression(this);
			return UnifiedLetQuery.Create(ident, expr);
		}

		public IUnifiedElement VisitQueryWhereClause(QueryWhereClause where, object data) {
			var cond = where.Condition.TryAcceptForExpression(this);
			return UnifiedWhereQuery.Create(cond);
		}

		public IUnifiedElement VisitQueryJoinClause(
				QueryJoinClause queryJoinClause, object data) {
			throw new NotImplementedException("QueryJoinClause");
		}

		public IUnifiedElement VisitQueryOrderClause(
				QueryOrderClause queryOrderClause, object data) {
			throw new NotImplementedException("QueryOrderClause");
		}

		public IUnifiedElement VisitQueryOrdering(QueryOrdering order, object data) {
			throw new NotImplementedException("QueryOrdering");
		}

		public IUnifiedElement VisitQuerySelectClause(QuerySelectClause select, object data) {
			var expr = select.Expression.TryAcceptForExpression(this);
			return UnifiedSelectQuery.Create(expr);
		}

		public IUnifiedElement VisitQueryGroupClause(
				QueryGroupClause queryGroupClause, object data) {
			throw new NotImplementedException("QueryGroupClause");
		}

		#endregion

		#endregion

		#region attribute

		public IUnifiedElement VisitAttribute(Attribute attribute, object data) {
			var type = LookupType(attribute.Type);
			if (attribute.HasArgumentList == false)
				return UnifiedAnnotation.Create(type);
			var uArgs = attribute.Arguments.AcceptVisitorAsArgs(this, data);
			return UnifiedAnnotation.Create(type, uArgs);
		}

		public IUnifiedElement VisitAttributeSection(AttributeSection attrSec, object data) {
			var target = LookupAttributeTarget(attrSec.AttributeTarget);
			Func<UnifiedAnnotation, UnifiedAnnotation> setAttr = a => {
				a.Target = target;
				return a;
			};
			return attrSec.Attributes
					.Select(a => a.AcceptVisitor(this, data))
					.OfType<UnifiedAnnotation>()
					.Select(setAttr)
					.ToCollection();
		}

		#endregion

		#region top-level declaration

		public IUnifiedElement VisitDelegateDeclaration(
				DelegateDeclaration delegateDeclaration, object data) {
			throw new NotImplementedException("DelegateDeclaration");
		}

		public IUnifiedElement VisitNamespaceDeclaration(NamespaceDeclaration dec, object data) {
			var ns = dec.Identifiers
					.Select(ident => ident.Name.ToVariableIdentifier() as IUnifiedExpression)
					.Aggregate((left, right) => UnifiedProperty.Create(".", left, right));
			var body = dec.Members
					.Select(mem => mem.TryAcceptForExpression(this))
					.ToBlock();
			return UnifiedNamespaceDefinition.Create(name: ns, body: body);
		}

		public IUnifiedElement VisitTypeDeclaration(TypeDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(dec.Modifiers);
			var name = UnifiedVariableIdentifier.Create(dec.Name);
			var typeParams = dec.TypeParameters.AcceptVisitorAsTypeParams(this, data);
			if (typeParams.Count == 0) typeParams = null;
			var extends = dec.BaseTypes.AcceptVisitorAsConstrains(this, data);
			var body = UnifiedBlock.Create();
			foreach (var node in dec.Members) {
				var uExpr = node.TryAcceptForExpression(this);
				if (uExpr != null)
					body.Add(uExpr);
			}
			// set constraint
			var dic = CreateDictionary(dec.Constraints);
			if (typeParams != null) {
				foreach (var generic in typeParams.Descendants<UnifiedGenericParameter>()) {
					var tName = GetTypeName(generic.Type);
					if (dic.ContainsKey(tName)) {
						foreach (var c in dic[tName]) {
							if (generic.Constrains == null)
								generic.Constrains = UnifiedTypeConstrainCollection.Create();
							generic.Constrains.Add(c.DeepCopy());
						}
					}
				}
			}
			foreach(var generic in extends.Descendants<UnifiedGenericParameter>()) {
				var tName = GetTypeName(generic.Type);
				if (dic.ContainsKey(tName)) {
					foreach (var c in dic[tName]) {
						if (generic.Constrains == null)
							generic.Constrains = UnifiedTypeConstrainCollection.Create();
						generic.Constrains.Add(c.DeepCopy());
					}
				}
			}

			switch (dec.ClassType) {
			case ClassType.Class:
				return UnifiedClassDefinition.Create(attrs, mods, name, typeParams, extends, body);
			case ClassType.Struct:
				return UnifiedStructDefinition.Create(attrs, mods, name, typeParams, extends, body);
			case ClassType.Interface:
				return UnifiedInterfaceDefinition.Create(attrs, mods, name, typeParams, extends, body);
			case ClassType.Enum:
				return UnifiedEnumDefinition.Create(attrs, mods, name, typeParams, extends, body);
			}
			var msg = "LookupClassKind : " + dec.ClassType + "には対応していません。";
			throw new InvalidOperationException(msg);
		}

		public IUnifiedElement VisitUsingAliasDeclaration(UsingAliasDeclaration dec, object data) {
			var name = dec.Alias;
			var import = dec.Import.TryAcceptForExpression(this);
			return UnifiedImport.Create(import, name);
		}

		public IUnifiedElement VisitUsingDeclaration(UsingDeclaration dec, object data) {
			var target = LookupType(dec.Import);
			return UnifiedImport.Create(target);
		}

		public IUnifiedElement VisitExternAliasDeclaration(
				ExternAliasDeclaration externAliasDeclaration, object data) {
			throw new NotImplementedException("ExternAliasDeclaration");
		}

		#endregion

		#region statement

		public IUnifiedElement VisitBlockStatement(BlockStatement block, object data) {
			return block.Statements
					.Select(stmt => stmt.TryAcceptForExpression(this))
					.Where(stmt => stmt != null)
					.ToBlock();
		}

		public IUnifiedElement VisitBreakStatement(BreakStatement stmt, object data) {
			return UnifiedBreak.Create();
		}

		public IUnifiedElement VisitCheckedStatement(
				CheckedStatement checkedStatement, object data) {
			throw new NotImplementedException("CheckedStatement");
		}

		public IUnifiedElement VisitContinueStatement(ContinueStatement stmt, object data) {
			return UnifiedContinue.Create();
		}

		public IUnifiedElement VisitDoWhileStatement(DoWhileStatement stmt, object data) {
			var body = stmt.EmbeddedStatement.TryAcceptForExpression(this).ToBlock();
			var cond = stmt.Condition.TryAcceptForExpression(this);
			return UnifiedDoWhile.Create(cond, body);
		}

		public IUnifiedElement VisitEmptyStatement(EmptyStatement stmt, object data) {
			return UnifiedBlock.Create();
		}

		public IUnifiedElement VisitExpressionStatement(ExpressionStatement exprStmt, object data) {
			return exprStmt.Expression.TryAcceptForExpression(this);
		}

		public IUnifiedElement VisitFixedStatement(
				FixedStatement fixedStatement, object data) {
			throw new NotImplementedException("FixedStatement");
		}

		public IUnifiedElement VisitForeachStatement(ForeachStatement stmt, object data) {
			var type = LookupType(stmt.VariableType);
			var name = stmt.VariableName.ToVariableIdentifier();
			var set = stmt.InExpression.TryAcceptForExpression(this);
			var body = stmt.EmbeddedStatement.TryAcceptForExpression(this).ToBlock();

			var varDec = UnifiedVariableDefinition.Create(type: type, name: name);
			return UnifiedForeach.Create(varDec.ToVariableDefinitionList(), set, body);
		}

		public IUnifiedElement VisitForStatement(ForStatement forStmt, object data) {
			// C#はstatementは一つのStatementあるいはBlockなためFirstOrDefaultで問題ない。
			// 複数あるのはVBを表す場合のため。
			var initStmt = forStmt.Initializers
					.Select(s => s.TryAcceptForExpression(this))
					.FirstOrDefault();
			var condExpr = forStmt.Condition.TryAcceptForExpression(this);
			var stepStmt = forStmt.Iterators
					.Select(s => s.TryAcceptForExpression(this))
					.FirstOrDefault();
			var body = forStmt.EmbeddedStatement.TryAcceptForExpression(this).ToBlock();
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
			return UnifiedGoto.Create(gotoStatement.Label);
		}

		public IUnifiedElement VisitIfElseStatement(IfElseStatement stmt, object data) {
			var cond = stmt.Condition.TryAcceptForExpression(this);
			var trueBlock = stmt.TrueStatement.TryAcceptForExpression(this).ToBlock();

			var nElseStmt = stmt.FalseStatement;
			if (nElseStmt == null) {
				return UnifiedIf.Create(cond, trueBlock);
			}
			var falseBlock = nElseStmt.TryAcceptForExpression(this).ToBlock();
			return UnifiedIf.Create(cond, trueBlock, falseBlock);
		}

		public IUnifiedElement VisitLabelStatement(LabelStatement label, object data) {
			return UnifiedLabelIdentifier.Create(label.Label);
		}

		public IUnifiedElement VisitLockStatement(
				LockStatement lockStatement, object data) {
			throw new NotImplementedException("LockStatement");
		}

		public IUnifiedElement VisitReturnStatement(ReturnStatement retStmt, object data) {
			var nExpr = retStmt.Expression;
			if (nExpr == null)
				return UnifiedReturn.Create();
			var uExpr = nExpr.TryAcceptForExpression(this);
			return UnifiedReturn.Create(uExpr);
		}

		public IUnifiedElement VisitSwitchStatement(SwitchStatement stmt, object data) {
			var uExpr = stmt.Expression.TryAcceptForExpression(this);
			var caseCollection = UnifiedCaseCollection.Create();
			foreach (var sec in stmt.SwitchSections) {
				var body = sec.Statements
						.Select(s => s.TryAcceptForExpression(this))
						.ToBlock();
				var lastIx = sec.CaseLabels.Count - 1;
				Func<IUnifiedExpression, int, UnifiedCase> func = (expr, ix) => {
					return (ix == lastIx)
						? UnifiedCase.Create(expr, body)
						: UnifiedCase.Create(expr);
				};
				var cases = sec.CaseLabels
						.Select(lbl => lbl.Expression.TryAcceptForExpression(this))
						.Select(func);
				foreach (var c in cases)
					caseCollection.Add(c);
			}
			return UnifiedSwitch.Create(uExpr, caseCollection);
		}

		public IUnifiedElement VisitSwitchSection(
				SwitchSection switchSection, object data) {
			throw new NotImplementedException("SwitchSection");
		}

		public IUnifiedElement VisitCaseLabel(CaseLabel caseLabel, object data) {
			throw new NotImplementedException("CaseLabel");
		}

		public IUnifiedElement VisitThrowStatement(ThrowStatement stmt, object data) {
			var uExpr = stmt.Expression.TryAcceptForExpression(this);
			return UnifiedThrow.Create(uExpr);
		}

		public IUnifiedElement VisitTryCatchStatement(
				TryCatchStatement tryCatchStatement, object data) {

			var uTry = tryCatchStatement.TryBlock.TryAcceptForExpression(this).ToBlock();
			var uCatchs = tryCatchStatement
					.CatchClauses
					.Select(c => c.AcceptVisitor(this, data))
					.Cast<UnifiedCatch>()
					.ToCollection();
			var nFinally = tryCatchStatement.FinallyBlock;
			var uFinally = nFinally == null
								? null
								: nFinally.TryAcceptForExpression(this).ToBlock();
			return UnifiedTry.Create(uTry, uCatchs, /* else */null, uFinally);
		}

		public IUnifiedElement VisitCatchClause(CatchClause catchClause, object data) {
			var type = LookupType(catchClause.Type);
			var name = UnifiedVariableIdentifier.Create(catchClause.VariableName);
			var body = catchClause.Body.TryAcceptForExpression(this).ToBlock();
			return UnifiedCatch.Create(type.ToCollection(), name, body);
		}

		public IUnifiedElement VisitUncheckedStatement(
				UncheckedStatement uncheckedStatement, object data) {
			throw new NotImplementedException("UncheckedStatement");
		}

		public IUnifiedElement VisitUnsafeStatement(
				UnsafeStatement unsafeStatement, object data) {
			throw new NotImplementedException("UnsafeStatement");
		}

		public IUnifiedElement VisitUsingStatement(UsingStatement stmt, object data) {
			var target = stmt.ResourceAcquisition.TryAcceptForExpression(this);
			var body = stmt.EmbeddedStatement.TryAcceptForExpression(this).ToBlock();
			return UnifiedUsing.Create(target.ToCollection(), body);
		}

		public IUnifiedElement VisitVariableDeclarationStatement(VariableDeclarationStatement dec, object data) {
			var uMods = LookupModifiers(dec.Modifiers);
			var uType = LookupType(dec.Type);
			var variables =
					from nVar in dec.Variables
					let name = nVar.Name
					let nInitValue = nVar.Initializer
					let uInitValue = nInitValue.TryAcceptForExpression(this)
					select UnifiedVariableDefinition.Create(
							/* no attribute */null,
							uMods.DeepCopy(),
							uType.DeepCopy(),
							name.ToVariableIdentifier(),
							uInitValue);
			return variables.ToVariableDefinitionList();
		}

		public IUnifiedElement VisitWhileStatement(WhileStatement stmt, object data) {
			var cond = stmt.Condition.TryAcceptForExpression(this);
			var body = stmt.EmbeddedStatement.TryAcceptForExpression(this).ToBlock();
			return UnifiedWhile.Create(cond, body);
		}

		public IUnifiedElement VisitYieldBreakStatement(YieldBreakStatement stmt, object data) {
			return UnifiedYieldBreak.Create();
		}

		public IUnifiedElement VisitYieldStatement(YieldStatement stmt, object data) {
			var value = stmt.Expression.TryAcceptForExpression(this);
			return UnifiedYieldReturn.Create(value);
		}

		#endregion

		#region declaration

		public IUnifiedElement VisitAccessor(Accessor accessor, object data) {
			var attrs = accessor.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(accessor.Modifiers);
			var block = accessor.Body.TryAcceptForExpression(this).ToBlock();
			return UnifiedPropertyDefinitionPart.Create(attrs, mods, block);
		}

		public IUnifiedElement VisitConstructorDeclaration(ConstructorDeclaration ctorDec, object data) {
			var mods = LookupModifiers(ctorDec.Modifiers);
			var attrs = ctorDec.Attributes.AcceptVisitorAsAttrs(this, data);
			var body = ctorDec.Body.AcceptVisitor(this, data) as UnifiedBlock;
			var parameters = ctorDec.Parameters.AcceptVisitorAsParams(this, data);
			return UnifiedConstructor.Create(body, attrs, mods, parameters, /*no-generic*/null, /*thorws*/null);
		}

		public IUnifiedElement VisitConstructorInitializer(
				ConstructorInitializer constructorInitializer, object data) {
			throw new NotImplementedException("ConstructorInitializer");
		}

		public IUnifiedElement VisitDestructorDeclaration(
				DestructorDeclaration destructorDeclaration, object data) {
			throw new NotImplementedException("DestructorDeclaration");
		}

		public IUnifiedElement VisitEnumMemberDeclaration(EnumMemberDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(dec.Modifiers);
			var name = UnifiedIdentifier.CreateVariable(dec.Name);
			var value = dec.Initializer.TryAcceptForExpression(this);
			return UnifiedVariableDefinition.Create(attrs, mods, /*no type*/null, name, value,
				/*no args*/null, /*no bit field*/null, /*no body*/null);
		}

		public IUnifiedElement VisitEventDeclaration(
				EventDeclaration eventDeclaration, object data) {
			throw new NotImplementedException("EventDeclaration");
		}

		public IUnifiedElement VisitCustomEventDeclaration(
				CustomEventDeclaration customEventDeclaration, object data) {
			throw new NotImplementedException("CustomEventDeclaration");
		}

		public IUnifiedElement VisitFieldDeclaration(FieldDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var type = LookupType(dec.ReturnType);
			var mods = LookupModifiers(dec.Modifiers);
			var definitions =
					from nVar in dec.Variables
					let name = nVar.Name
					let nInitValue = nVar.Initializer
					let uInitValue = nInitValue.TryAcceptForExpression(this)
					select UnifiedVariableDefinition.Create(
							attrs.DeepCopy(),
							mods.DeepCopy(),
							type.DeepCopy(),
							name.ToVariableIdentifier(),
							uInitValue);
			return definitions.ToVariableDefinitionList();
		}

		public IUnifiedElement VisitIndexerDeclaration(IndexerDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(dec.Modifiers);
			var type = LookupType(dec.ReturnType);
			var name = UnifiedIdentifier.CreateVariable(dec.Name);
			var param = dec.Parameters.AcceptVisitorAsParams(this, data);
			var get = dec.Getter.AcceptVisitor(this, data) as UnifiedPropertyDefinitionPart;
			var set = dec.Setter.AcceptVisitor(this, data) as UnifiedPropertyDefinitionPart;
			return UnifiedPropertyDefinition.Create(attrs, mods, type, name, param, get, set);
		}

		public IUnifiedElement VisitMethodDeclaration(MethodDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(dec.Modifiers);
			var type = LookupType(dec.ReturnType);
			var name = UnifiedVariableIdentifier.Create(dec.Name);
			var generics = dec.TypeParameters.AcceptVisitorAsTypeParams(this, data);
			if (generics.IsEmptyOrNull()) {
				generics = null;
			}
			var parameters = dec.Parameters.AcceptVisitorAsParams(this, data);
			var body = dec.Body.TryAcceptForExpression(this).ToBlock();
			// TODO constraint
			return UnifiedFunctionDefinition.Create(
					attrs, mods, type, generics, name, parameters, /* no throws */ null, body);
		}

		public IUnifiedElement VisitOperatorDeclaration(
				OperatorDeclaration operatorDeclaration, object data) {
			throw new NotImplementedException("OperatorDeclaration");
		}

		public IUnifiedElement VisitParameterDeclaration(ParameterDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifier(dec.ParameterModifier).ToCollection();
			var type = LookupType(dec.Type);
			var names = dec.Name.ToVariableIdentifier().ToCollection();
			var defaultValue = dec.DefaultExpression.TryAcceptForExpression(this);
			return UnifiedParameter.Create(attrs, mods, type, names, defaultValue);
		}

		public IUnifiedElement VisitPropertyDeclaration(PropertyDeclaration dec, object data) {
			var attrs = dec.Attributes.AcceptVisitorAsAttrs(this, data);
			var mods = LookupModifiers(dec.Modifiers);
			var type = LookupType(dec.ReturnType);
			var name = UnifiedIdentifier.CreateVariable(dec.Name);
			var get = dec.Getter.AcceptVisitor(this, data) as UnifiedPropertyDefinitionPart;
			var set = dec.Setter.AcceptVisitor(this, data) as UnifiedPropertyDefinitionPart;
			return UnifiedPropertyDefinition.Create(attrs, mods, type, name, null /*no parameter*/, get, set);
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

		#endregion

		public IUnifiedElement VisitSimpleType(SimpleType simpleType, object data) {
			var type = UnifiedType.Create(simpleType.Identifier);
			// TODO: Send a Patch to NRefactory
			if (ReferenceEquals(simpleType.TypeArguments, null))
				return type;
			var uTypeArgs = simpleType.TypeArguments.AcceptVisitorAsTypeArgs(this, data);
			return type.WrapGeneric(uTypeArgs);
		}

		public IUnifiedElement VisitMemberType(MemberType memberType, object data) {
			var ident = UnifiedTypeIdentifier.Create(memberType.MemberName);
			var target = memberType.Target.TryAcceptForExpression(this);
			var uProp = UnifiedType.Create(UnifiedProperty.Create(".", target, ident));
			// TODO: Send a Patch to NRefactory
			if (ReferenceEquals(memberType.TypeArguments, null))
				return uProp;
			var uTypeArgs = memberType.TypeArguments.AcceptVisitorAsTypeArgs(this, data);
			return uProp.WrapGeneric(uTypeArgs);
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
			return null;
		}

		public IUnifiedElement VisitTypeParameterDeclaration(TypeParameterDeclaration dec, object data) {
			var type = UnifiedType.Create(dec.Name);
			var modifiers = null as UnifiedModifierCollection;
			switch(dec.Variance) {
			case VarianceModifier.Contravariant:
			    modifiers = UnifiedModifier.Create("in").ToCollection();
			    break;
			case VarianceModifier.Covariant:
			    modifiers = UnifiedModifier.Create("out").ToCollection();
			    break;
			}
			return UnifiedGenericParameter.Create(type, /*constraint*/null, modifiers);
		}

		public IUnifiedElement VisitConstraint(Constraint constraint, object data) {
			throw new InvalidOperationException("VisitConstraint は呼ばれない");
		}

		public IUnifiedElement VisitCSharpTokenNode(
				CSharpTokenNode tokenNode, object data) {
			throw new NotImplementedException("CSharpTokenNode");
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