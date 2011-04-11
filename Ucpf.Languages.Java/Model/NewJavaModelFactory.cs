using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Xml.Linq;
using Ucpf.Core.Model;

namespace Ucpf.Languages.Java.Model
{
	public class NewJavaModelFactory
	{
		public static UnifiedProgram CreateCompilationUnit(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compilationUnit");
			/*
			 * compilationUnit 
			 * :   ( (annotations)? packageDeclaration )? (importDeclaration)* (typeDeclaration)*
			 */

			var program = UnifiedProgram.Create();
			IUnifiedElementCollection<IUnifiedExpression> expressions = program;

			if (node.FirstElement().Name() == "annotations") {
				var annotations = CreateAnnotations(node.NthElement(0));
				var packageDeclaration = CreatePackageDeclaration(node.NthElement(1));
				expressions = packageDeclaration.Body;
			}
			foreach (var e in node.Elements("importDeclaration")) {
				var importDeclaration = CreateImportDeclaration(e);
				expressions.PrivateAdd(importDeclaration);
			}
			foreach (var e in node.Elements("typeDeclaration")) {
				var typeDeclaration = CreateTypeDeclaration(e);
				expressions.PrivateAdd(typeDeclaration);
			}
			return program;
		}

		public static UnifiedClassDefinition CreatePackageDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "packageDeclaration");
			return null;
		}

		public static IUnifiedExpression CreateImportDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "importDeclaration");
			return null;
		}

		public static IUnifiedElement CreateQualifiedImportName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedImportName");
			return null;
		}

		public static IUnifiedExpression CreateTypeDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeDeclaration");
			/*
			 * typeDeclaration 
			 * :   classOrInterfaceDeclaration
			 * |   ';' 
			 */

			if(node.FirstElement().Name() == "classOrInterfaceDeclaration") {
				return CreateClassOrInterfaceDeclaration(node.NthElement(0));
			}
			//TODO ';'をどう扱うかを考える
			//TODO returnTypeを考える
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateClassOrInterfaceDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceDeclaration");
			/*
			 * classOrInterfaceDeclaration 
			 * :    classDeclaration
			 * |   interfaceDeclaration 
			 */

			if(node.FirstElement().Name() == "classDeclaration") {
				return CreateClassDeclaration(node.NthElement(0));
			}
			if(node.FirstElement().Name() == "interfaceDeclaration") {
				return CreateInterfaceDeclaration(node.NthElement(0));
			}
			throw new InvalidOperationException();
		}

		public static UnifiedModifierCollection CreateModifiers(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "modifiers");
			/*
			 * modifiers  
			 * :
			 * (    annotation
			 * |   'public'
			 * |   'protected'
			 * |   'private'
			 * |   'static'
			 * |   'abstract'
			 * |   'final'
			 * |   'native'
			 * |   'synchronized'
			 * |   'transient'
			 * |   'volatile'
			 * |   'strictfp'
			 * )* 
			 */

			var modifiers = UnifiedModifierCollection.Create();
			foreach (var modifier in node.Elements()) {
				if(modifier.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.PrivateAdd(UnifiedAnnotation.Create());
				}
				else {
					modifiers.PrivateAdd(UnifiedModifier.Create(modifier.Value));
				}
			}
			return modifiers;
		}

		public static UnifiedModifierCollection CreateVariableModifiers(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableModifiers");
			/*
			 * variableModifiers 
			 * :   ( 'final' | annotation )* 
			 */

			var modifiers = UnifiedModifierCollection.Create();
			foreach (var modifier in node.Elements()) {
				if(modifier.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.PrivateAdd(UnifiedAnnotation.Create());
				}
				else {
					modifiers.PrivateAdd(UnifiedModifier.Create(modifier.Value));
				}
			}
			return modifiers;
		}

		public static UnifiedClassDefinition CreateClassDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classDeclaration");
			/*
			 * classDeclaration 
			 * :   normalClassDeclaration | enumDeclaration 
			 */

			if(node.FirstElement().Name() == "normalClassDeclaration") {
				return CreateNormalClassDeclaration(node.NthElement(0));
			}
			if(node.FirstElement().Name() == "enumDeclaration") {
				throw new NotImplementedException();
			}
			throw new InvalidOperationException();
		}

		public static UnifiedClassDefinition CreateNormalClassDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalClassDeclaration");
			/*
			 * normalClassDeclaration 
			 * :   modifiers  'class' IDENTIFIER (typeParameters)? ('extends' type)? ('implements' typeList)? classBody 
			 */

			return UnifiedClassDefinition.Create(
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value, UnifiedIdentifierType.Function),
				CreateClassBody(node.Element("classBody")),
				CreateModifiers(node.Element("modifiers")),
				UnifiedClassType.Class);
			//TODO パラメータおよび親クラスについて未実装
		}

		public static UnifiedTypeParameterCollection CreateTypeParameters(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeParameters");
			/*
			 * typeParameters 
			 * :   '<' typeParameter (',' typeParameter )* '>' 
			 */

			var typeParameters = UnifiedTypeParameterCollection.Create();
			foreach (var typeParameter in node.Elements("typeParameter")) {
				var e = CreateTypeParameter(typeParameter);
				typeParameters.PrivateAdd(e);
			}
			return typeParameters;
		}

		public static UnifiedTypeParameter CreateTypeParameter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeParameter");
			/*
			 * typeParameter 
			 * :   IDENTIFIER ('extends' typeBound)? 
			 */

			//TODO extends以降が未実装
			return UnifiedTypeParameter.Create(UnifiedType.Create(node.NthElement(0).Value));
		}

		public static UnifiedTypeCollection CreateTypeBound(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeBound");
			/*
			 * typeBound 
			 * :   type ('&' type)* 
			 */

			var types = UnifiedTypeCollection.Create();
			foreach (var type in node.Elements("type")) {
				var e = CreateType(type);
				types.PrivateAdd(e);
			}
			return types;
		}

		public static IUnifiedElement CreateEnumDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumDeclaration");
			/*
			 * enumDeclaration 
			 * :   modifiers ('enum') IDENTIFIER ('implements' typeList)? enumBody 
			 */

			//TODO UnifiedEnumが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedElement CreateEnumBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBody");
			/*
			 * enumBody 
			 * :   '{' (enumConstants)? ','? (enumBodyDeclarations)? '}' 
			 */

			//TODO UnifiedEnumConstantCollection, UnifiedEnumBodyが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedElement CreateEnumConstants(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstants");
			/*
			 * enumConstants 
			 * :   enumConstant (',' enumConstant)* 
			 */

			//TODO UnifiedEnumConstantが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedElement CreateEnumConstant(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstant");
			/*
			 * enumConstant 
			 * :   (annotations)? IDENTIFIER (arguments)? (classBody)?
			 */

			//TODO UnifiedEnumConstantが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedElement CreateEnumBodyDeclarations(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBodyDeclarations");
			/*
			 * enumBodyDeclarations 
			 * :   ';' (classBodyDeclaration)* 
			 */

			var declarations = UnifiedExpressionCollection.Create();
			foreach (var declaration in node.Elements("classBodyDeclaration")) {
				var e = CreateClassBodyDeclaration(declaration);
				declarations.PrivateAdd(e);
			}
			return declarations;
		}

		public static IUnifiedExpression CreateInterfaceDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceDeclaration");
			/*
			 * interfaceDeclaration 
			 * :   normalInterfaceDeclaration | annotationTypeDeclaration 
			 */

			if(node.FirstElement().Name() == "normalInterfaceDeclaration") {
				return CreateNormalInterfaceDeclaration(node.NthElement(0));
			}
			if(node.FirstElement().Name() == "annotationTypeDeclaration") {
				return CreateAnnotationTypeDeclaration(node.NthElement(0));
			}
			//TODO returnTypeを考える
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateNormalInterfaceDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalInterfaceDeclaration");
			/*
			 * normalInterfaceDeclaration 
			 * :   modifiers 'interface' IDENTIFIER (typeParameters)? ('extends' typeList)? interfaceBody 
			 */

			//TODO UnifiedInterfaceDeclarationが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedElement CreateTypeList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeList");
			/*
			 * typeList 
			 * :   type (',' type)* 
			 */

			var types = UnifiedTypeCollection.Create();
			foreach (var type in node.Elements("type")) {
				var e = CreateType(type);
				types.PrivateAdd(e);
			}
			return types;
		}

		public static UnifiedBlock CreateClassBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBody");
			/*
			 * classBody 
			 * :   '{' (classBodyDeclaration)* '}' 
			 */

			return UnifiedBlock.Create(
					node
					.Elements("classBodyDeclaration")
					.Select(CreateClassBodyDeclaration)
					.ToList()
				);
		}

		public static UnifiedBlock CreateInterfaceBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceBody");
			/*
			 * interfaceBody 
			 * :   '{' (interfaceBodyDeclaration)* '}' 
			 */

			return UnifiedBlock.Create(
					node
					.Elements("interfaceBodyDeclaration")
					.Select(CreateInterfaceBodyDeclaration)
					.ToList()
				);
		}

		public static IUnifiedExpression CreateClassBodyDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBodyDeclaration");
			/*
			 * classBodyDeclaration 
			 * :   ';'
			 * |   ('static')? block
			 * |   memberDecl 
			 */

			if(node.HasElement("block")) {
				//TODO staticをどう扱うか
				return CreateBlock(node.Element("block"));
			}
			if(node.HasElement("memberDecl")) {
				return CreateMemberDecl(node.Element("memberDecl"));
			}
			//TODO ';'の場合をどう扱うか
			throw new NotImplementedException();
			return null;
		}

		public static IUnifiedExpression CreateMemberDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "memberDecl");
			/*
			 * memberDecl 
			 * :    fieldDeclaration
			 * |    methodDeclaration
			 * |    classDeclaration
			 * |    interfaceDeclaration 
			 */

			var first = node.FirstElement();
			switch(first.Name()) {
				case "fieldDeclaration":
					return CreateFieldDeclaration(first);
				case "methodDeclaration":
					return CreateMethodDeclaration(first);
				case "classDeclaration":
					return CreateClassDeclaration(first);
				case "interfaceDeclaration":
					return CreateInterfaceDeclaration(first);
				default:
					throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateMethodDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "methodDeclaration");
			/*
			 * methodDeclaration 
			 * :   //constructor
			 *     modifiers (typeParameters)? IDENTIFIER formalParameters ('throws' qualifiedNameList)? 
			       '{' (explicitConstructorInvocation)? (blockStatement)* '}'
			 * |   modifiers (typeParameters)? (type | 'void') IDENTIFIER formalParameters
			 *     ('[' ']')* ('throws' qualifiedNameList)? (block | ';' ) 
			 */

			if(!node.HasElement("type") && !node.HasElement("VOID")) {
				//case constructor
				return UnifiedConstructorDefinition.Create(
					UnifiedBlock.Create(
						node
						.Elements("blockStatement")
						.Select(CreateBlockStatement)
						.ToList()
						),
					CreateModifiers(node.Element("modifiers")),
					CreateFormalParameters(node.Element("formalParameters")));
			}
			return UnifiedFunctionDefinition.Create(
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value, UnifiedIdentifierType.Function),
				CreateType(node.Element("type")),
				CreateModifiers(node.Element("modifiers")),
				CreateFormalParameters(node.Element("formalParameters")),
				CreateBlock(node.Element("block"))
				);
			//TODO typeParametersなどについて未実装
		}

		public static UnifiedVariableDefinition CreateFieldDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fieldDeclaration");
			/*
			 * fieldDeclaration 
			 * :   modifiers type variableDeclarator (',' variableDeclarator)* ';' 
			 */

			var declarator =
				CreateVariableDeclarator(node.Elements("variableDeclarator").First());
			return UnifiedVariableDefinition.Create(
				CreateType(node.Element("type")),
				CreateModifiers(node.Element("modifiers")),
				declarator.RightHandSide,
				declarator.LeftHandSide.ToString() //TODO Expressionの文字列表現は取得できるのか
				);
			//TODO variableDeclaratorが複数ある場合が未実装
		}

		public static UnifiedBinaryExpression CreateVariableDeclarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarator");
			/*
			 * variableDeclarator 
			 * :   IDENTIFIER ('[' ']')* ('=' variableInitializer)? 
			 */

			return UnifiedBinaryExpression.Create(
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value, UnifiedIdentifierType.Variable),
				UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorType.Assign),
				CreateVariableInitializer(node.Element("variableInitializer"))
				);
			//TODO 配列である場合や、初期値がない場合が未実装
		}

		public static IUnifiedExpression CreateInterfaceBodyDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceBodyDeclaration");
			/*
			 * interfaceBodyDeclaration 
			 * :   interfaceFieldDeclaration
			 * |   interfaceMethodDeclaration
			 * |   interfaceDeclaration
			 * |   classDeclaration
			 * |   ';' 
			 */

			var first = node.FirstElement();
			switch(first.Name()) {
				case "interfaceFieldDeclaration":
					return CreateInterfaceFieldDeclaration(first);
				case "interfaceMethodDeclaration":
					return CreateInterfaceMethodDeclaration(first);
				case "interfaceDeclaration":
					return CreateInterfaceDeclaration(first);
				case "classDeclaration":
					return CreateClassDeclaration(first);
				default:
					throw new InvalidOperationException();
			}
			//TODO ';'の場合が未実装
		}

		public static IUnifiedExpression CreateInterfaceMethodDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceMethodDeclaration");
			return null;
		}

		public static IUnifiedExpression CreateInterfaceFieldDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceFieldDeclaration");
			return null;
		}

		public static UnifiedType CreateType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type");
			return null;
		}

		public static IUnifiedElement CreateClassOrInterfaceType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			return null;
		}

		public static IUnifiedElement CreatePrimitiveType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primitiveType");
			return null;
		}

		public static IUnifiedElement CreateTypeArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArguments");
			return null;
		}

		public static IUnifiedElement CreateTypeArgument(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArgument");
			return null;
		}

		public static IUnifiedElement CreateQualifiedNameList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedNameList");
			return null;
		}

		public static UnifiedParameterCollection CreateFormalParameters(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameters");
			return null;
		}

		public static IUnifiedElement CreateFormalParameterDecls(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameterDecls");
			return null;
		}

		public static IUnifiedElement CreateNormalParameterDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalParameterDecl");
			return null;
		}

		public static IUnifiedElement CreateEllipsisParameterDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ellipsisParameterDecl");
			return null;
		}

		public static IUnifiedElement CreateExplicitConstructorInvocation(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "explicitConstructorInvocation");
			return null;
		}

		public static IUnifiedElement CreateQualifiedName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedName");
			return null;
		}

		public static IUnifiedElement CreateAnnotations(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotations");
			return null;
		}

		public static IUnifiedElement CreateAnnotation(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotation");
			return null;
		}

		public static IUnifiedElement CreateElementValuePairs(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePairs");
			return null;
		}

		public static IUnifiedElement CreateElementValuePair(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePair");
			return null;
		}

		public static IUnifiedElement CreateElementValue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValue");
			return null;
		}

		public static IUnifiedElement CreateElementValueArrayInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValueArrayInitializer");
			return null;
		}

		public static IUnifiedExpression CreateAnnotationTypeDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeDeclaration");
			return null;
		}

		public static IUnifiedElement CreateAnnotationTypeBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeBody");
			return null;
		}

		public static IUnifiedElement CreateAnnotationTypeElementDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeElementDeclaration");
			return null;
		}

		public static IUnifiedElement CreateAnnotationMethodDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationMethodDeclaration");
			return null;
		}

		public static UnifiedBlock CreateBlock(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			return null;
		}

		public static IUnifiedExpression CreateBlockStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "blockStatement");
			return null;
		}

		public static IUnifiedElement CreateLocalVariableDeclarationStatement(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclarationStatement");
			return null;
		}

		public static IUnifiedElement CreateLocalVariableDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclaration");
			return null;
		}

		public static IUnifiedElement CreateStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			return null;
		}

		public static IUnifiedElement CreateSwitchBlockStatementGroups(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroups");
			return null;
		}

		public static IUnifiedElement CreateSwitchBlockStatementGroup(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroup");
			return null;
		}

		public static IUnifiedElement CreateSwitchLabel(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchLabel");
			return null;
		}

		public static IUnifiedElement CreateTrystatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "trystatement");
			return null;
		}

		public static IUnifiedElement CreateCatches(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catches");
			return null;
		}

		public static IUnifiedElement CreateCatchClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			return null;
		}

		public static IUnifiedElement CreateFormalParameter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameter");
			return null;
		}

		public static IUnifiedElement CreateForstatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forstatement");
			return null;
		}

		public static IUnifiedElement CreateForInit(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInit");
			return null;
		}

		public static IUnifiedElement CreateParExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parExpression");
			return null;
		}

		public static IUnifiedElement CreateExpressionList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionList");
			return null;
		}

		public static IUnifiedElement CreateExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			return null;
		}

		public static IUnifiedElement CreateAssignmentOperator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentOperator");
			return null;
		}

		public static IUnifiedElement CreateConditionalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			return null;
		}

		public static IUnifiedElement CreateConditionalOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalOrExpression");
			return null;
		}

		public static IUnifiedElement CreateConditionalAndExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalAndExpression");
			return null;
		}

		public static IUnifiedElement CreateInclusiveOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusiveOrExpression");
			return null;
		}

		public static IUnifiedElement CreateExclusiveOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusiveOrExpression");
			return null;
		}

		public static IUnifiedElement CreateAndExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "andExpression");
			return null;
		}

		public static IUnifiedElement CreateEqualityExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			return null;
		}

		public static IUnifiedElement CreateInstanceOfExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "instanceOfExpression");
			return null;
		}

		public static IUnifiedElement CreateRelationalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			return null;
		}

		public static IUnifiedElement CreateRelationalOp(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalOp");
			return null;
		}

		public static IUnifiedElement CreateShiftExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			return null;
		}

		public static IUnifiedElement CreateShiftOp(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftOp");
			return null;
		}

		public static IUnifiedElement CreateAdditiveExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			return null;
		}

		public static IUnifiedElement CreateMultiplicativeExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			return null;
		}

		public static IUnifiedElement CreateUnaryExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpression");
			return null;
		}

		public static IUnifiedElement CreateUnaryExpressionNotPlusMinus(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpressionNotPlusMinus");
			return null;
		}

		public static IUnifiedElement CreateCastExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "castExpression");
			return null;
		}

		public static IUnifiedElement CreatePrimary(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary");
			return null;
		}

		public static IUnifiedElement CreateSuperSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "superSuffix");
			return null;
		}

		public static IUnifiedElement CreateIdentifierSuffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "identifierSuffix");
			return null;
		}

		public static IUnifiedElement CreateSelector(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selector");
			return null;
		}

		public static IUnifiedElement CreateCreator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "creator");
			return null;
		}

		public static IUnifiedElement CreateArrayCreator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayCreator");
			return null;
		}

		public static IUnifiedExpression CreateVariableInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableInitializer");
			return null;
		}

		public static IUnifiedElement CreateArrayInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayInitializer");
			return null;
		}

		public static IUnifiedElement CreateCreatedName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "createdName");
			return null;
		}

		public static IUnifiedElement CreateInnerCreator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "innerCreator");
			return null;
		}

		public static IUnifiedElement CreateClassCreatorRest(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classCreatorRest");
			return null;
		}

		public static IUnifiedElement CreateNonWildcardTypeArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nonWildcardTypeArguments");
			return null;
		}

		public static IUnifiedElement CreateArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arguments");
			return null;
		}

		public static IUnifiedElement CreateLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			return null;
		}

		public static IUnifiedElement CreateClassHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classHeader");
			return null;
		}

		public static IUnifiedElement CreateEnumHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumHeader");
			return null;
		}

		public static IUnifiedElement CreateInterfaceHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceHeader");
			return null;
		}

		public static IUnifiedElement CreateAnnotationHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationHeader");
			return null;
		}

		public static IUnifiedElement CreateTypeHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeHeader");
			return null;
		}

		public static IUnifiedElement CreateMethodHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "methodHeader");
			return null;
		}

		public static IUnifiedElement CreateFieldHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fieldHeader");
			return null;
		}

		public static IUnifiedElement CreateLocalVariableHeader(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableHeader");
			return null;
		}
	}
}