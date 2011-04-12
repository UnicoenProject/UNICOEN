using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
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

		public static UnifiedClassDefinition CreateTypeDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeDeclaration");
			/*
			 * typeDeclaration 
			 * :   classOrInterfaceDeclaration
			 * |   ';' 
			 */

			if (node.FirstElement().Name() == "classOrInterfaceDeclaration") {
				return CreateClassOrInterfaceDeclaration(node.NthElement(0));
			}
			//TODO ';'をどう扱うかを考える
			throw new NotImplementedException();
		}

		public static UnifiedClassDefinition CreateClassOrInterfaceDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceDeclaration");
			/*
			 * classOrInterfaceDeclaration 
			 * :    classDeclaration
			 * |   interfaceDeclaration 
			 */

			var first = node.FirstElement();
			if (first.Name() == "classDeclaration") {
				return CreateClassDeclaration(first);
			}
			if (first.Name() == "interfaceDeclaration") {
				return CreateInterfaceDeclaration(first);
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
				if (modifier.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.Add(UnifiedAnnotation.Create());
				} else {
					modifiers.Add(UnifiedModifier.Create(modifier.Value));
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
				if (modifier.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.Add(UnifiedAnnotation.Create());
				} else {
					modifiers.Add(UnifiedModifier.Create(modifier.Value));
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

			var first = node.FirstElement();
			if (first.Name() == "normalClassDeclaration") {
				return CreateNormalClassDeclaration(first);
			}
			if (first.Name() == "enumDeclaration") {
				throw new NotImplementedException();
			}
			throw new InvalidOperationException();
		}

		public static UnifiedClassDefinition CreateNormalClassDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalClassDeclaration");
			/*
			 * normalClassDeclaration 
			 * :   modifiers  'class' IDENTIFIER (typeParameters)? ('extends' type)? ('implements' typeList)? classBody 
			 */

			return UnifiedClassDefinition.Create(
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
					UnifiedIdentifierKind.Class),
				CreateClassBody(node.Element("classBody")),
				CreateModifiers(node.Element("modifiers")),
				UnifiedClassType.Class);
			//TODO パラメータおよび親クラスについて未実装
		}

		public static UnifiedTypeParameterCollection CreateTypeParameters(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeParameters");
			/*
			 * typeParameters 
			 * :   '<' typeParameter (',' typeParameter )* '>' 
			 */
			var typeParameters = UnifiedTypeParameterCollection.Create(
				node.Elements("typeParameter").Select(CreateTypeParameter));
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
			return UnifiedTypeParameter.Create(
				UnifiedType.Create(node.NthElement(0).Value),
				UnifiedTypeConstrainCollection.Create(
					CreateTypeBound(node)
						.Select(UnifiedTypeConstrain.CreateExtends))
				);
		}

		public static IEnumerable<UnifiedType> CreateTypeBound(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeBound");
			/*
			 * typeBound 
			 * :   type ('&' type)* 
			 */
			return node.Elements("type").Select(CreateType);
		}

		public static IUnifiedExpression CreateEnumDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumDeclaration");
			/*
			 * enumDeclaration 
			 * :   modifiers ('enum') IDENTIFIER ('implements' typeList)? enumBody 
			 */

			//TODO UnifiedEnumが未実装 -> UnifiedClassDefinitionです
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
				declarations.Add(e);
			}
			return declarations;
		}

		public static UnifiedClassDefinition CreateInterfaceDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceDeclaration");
			/*
			 * interfaceDeclaration 
			 * :   normalInterfaceDeclaration | annotationTypeDeclaration 
			 */

			if (node.FirstElement().Name() == "normalInterfaceDeclaration") {
				return CreateNormalInterfaceDeclaration(node.NthElement(0));
			}
			if (node.FirstElement().Name() == "annotationTypeDeclaration") {
				return CreateAnnotationTypeDeclaration(node.NthElement(0));
			}
			throw new InvalidOperationException();
		}

		public static UnifiedClassDefinition CreateNormalInterfaceDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalInterfaceDeclaration");
			/*
			 * normalInterfaceDeclaration 
			 * :   modifiers 'interface' IDENTIFIER (typeParameters)? ('extends' typeList)? interfaceBody 
			 */

			var modifiers = CreateModifiers(node.Element("modifiers"));
			var type = UnifiedClassType.Interface;
			var name = UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
				UnifiedIdentifierKind.Class);
			var typeParameters = node.Element("typeParameters") != null ?
				CreateTypeParameters(node.Element("typeParameters")) : null;
			var constrains = node.Element("typeList") != null ?
			                                                  	UnifiedTypeConstrainCollection
			                                                  		.Create(
			                                                  			CreateTypeList(
			                                                  				node.Element("typeList"))
			                                                  		.Select(
			                                                  			UnifiedTypeConstrain.
			                                                  		CreateExtends)
			                                                  		) : null;
			var body = CreateInterfaceBody(node.Element("interfaceBody"));

			//TODO UnifiedClassDefinitionのCreateの整理
			return UnifiedClassDefinition.Create(modifiers, type, name, typeParameters, constrains, body);
		}

		public static UnifiedTypeCollection CreateTypeList(XElement node)
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
				types.Add(e);
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

			if (node.HasElement("block")) {
				//TODO staticをどう扱うか
				return CreateBlock(node.Element("block"));
			}
			if (node.HasElement("memberDecl")) {
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
			switch (first.Name()) {
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

			if (!node.HasElement("type") && !node.HasElement("VOID")) {
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
			return UnifiedFunctionDefinition.CreateFunction(
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
					UnifiedIdentifierKind.Function),
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
				UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
					UnifiedIdentifierKind.Variable),
				UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
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
			switch (first.Name()) {
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

		public static UnifiedFunctionDefinition CreateInterfaceMethodDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceMethodDeclaration");
			/*
			 * interfaceMethodDeclaration 
			 * :   modifiers (typeParameters)? (type |'void') IDENTIFIER formalParameters
			       ('[' ']')* ('throws' qualifiedNameList)? ';' 
			 */

			var modifiers = CreateModifiers(node.Element("modifiers"));
			var typeParameters = node.HasElement("typeParameters") ? 
				CreateTypeParameters(node.Element("typeParameters")) : null;
			var type = CreateType(node.Element("type"));
			var name = UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
				UnifiedIdentifierKind.Function);
			var parameters = CreateFormalParameters(node.Element("formalParameters"));
			
			//TODO CreateQualifiedNameの型を何にするか？
			/*
			 * var throws = UnifiedTypeCollection.Create(
					CreateQualifiedNameList(node.Element("qualifiedNameList"))
					.Select(e => UnifiedType.Create(e.ToString()))
				); 
			 */
			var kind = UnifiedFunctionDefinitionKind.Function;

			//TODO '[]'がどのように付くのか調査
			//TODO UnifiedFunctionDefinitionのCreateの整理
			//TODO 引数が8個のCreateを実装
			return UnifiedFunctionDefinition.CreateFunction(name, type, modifiers, parameters, null, null, kind);
		}

		public static UnifiedVariableDefinition CreateInterfaceFieldDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceFieldDeclaration");
			/* 
			 * interfaceFieldDeclaration 
			 * :   modifiers type variableDeclarator (',' variableDeclarator)* ';' 
			 */

			var declarator =
				CreateVariableDeclarator(node.Elements("variableDeclarator").First());
			return UnifiedVariableDefinition.Create(
				CreateType(node.Element("type")),
				CreateModifiers(node.Element("modifiers")),
				declarator.RightHandSide,
				declarator.LeftHandSide.ToString()); //TODO Expressionの文字列表現は取得できるのか
			//TODO variableDeclaratorが複数の場合が未実装
		}

		public static UnifiedType CreateType(XElement node)
		{
			Contract.Requires(node == null || node.Name() == "type");
			/*
			 * type 
			 * :   classOrInterfaceType ('[' ']')*
			 * |   primitiveType ('[' ']')* 
			 */

			if (node == null)
				return UnifiedType.Create("void");

			var first = node.FirstElement();
			switch (first.Name()) {
			case "classOrInterfaceType":
				return CreateClassOrInterfaceType(first);
			case "primitiveType":
				return CreatePrimitiveType(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedType CreateClassOrInterfaceType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			/*
			 * classOrInterfaceType 
			 * :   IDENTIFIER (typeArguments)? ('.' IDENTIFIER (typeArguments)? )* 
			 */

			var name = node.Element("IDENTIFIER").Value;
			if (node.HasElement("typeArguments")) {
				return UnifiedType.Create(
					name, CreateTypeArguments(node.Element("typeArguments")));
			}
			return UnifiedType.Create(name);
			//TODO typeArgumentsを複数持っている場合が未実装
			//TODO 親ノードが[]を持っている場合を考慮していない
		}

		public static UnifiedType CreatePrimitiveType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primitiveType");
			/* 
			 * primitiveType  
			 * :   'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' 
			 */

			return UnifiedType.Create(node.Value);
		}

		//TODO 型名がUnifiedType"Parameter"Collectionなのか検討
		public static UnifiedTypeArgumentCollection CreateTypeArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArguments");
			/* 
			 * typeArguments 
			 * :   '<' typeArgument (',' typeArgument)* '>' 
			 */

			return UnifiedTypeArgumentCollection.Create(
				node
					.Elements("typeArgument")
					.Select(CreateTypeArgument)
				);
		}

		//TODO 型名がUnifiedType"Parameter"なのか検討
		public static UnifiedTypeArgument CreateTypeArgument(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArgument");
			/*
			 * typeArgument 
			 * :   type
			 * |   '?' (('extends' | 'super') type)? 
			 */

			if (node.FirstElement().Name() == "type") {
				return UnifiedTypeArgument.Create(CreateType(node.NthElement(0)), null);
			}
			//TODO ?型のケースが未実装
			throw new NotImplementedException();
			return null;
		}

		public static IEnumerable<IUnifiedExpression>CreateQualifiedNameList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedNameList");
			/* 
			 * qualifiedNameList 
			 * :   qualifiedName (',' qualifiedName)* 
			 */

			return node.Elements("qualifiedName").Select(CreateQualifiedName);
		}

		public static UnifiedParameterCollection CreateFormalParameters(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameters");
			/*
			 * formalParameters 
			 * :   '(' (formalParameterDecls)? ')' 
			 */

			var element = node.Element("formalParameterDecls");
			if (element == null)
				return UnifiedParameterCollection.Create();
			return CreateFormalParameterDecls(element);
		}

		public static UnifiedParameterCollection CreateFormalParameterDecls(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameterDecls");
			/*
			 * formalParameterDecls 
			 * :   ellipsisParameterDecl
			 * |   normalParameterDecl (',' normalParameterDecl)*
			 * |   (normalParameterDecl ',')+ ellipsisParameterDecl 
			 */

			//TODO oldの処理をそのままコピペ。内容を後で確認
			return UnifiedParameterCollection.Create(node
				.Elements()
				.Select(e => {
					if (e.Name() == "normalParameterDecl")
						return CreateNormalParameterDecl(e);
					if (e.Name() == "ellipsisParameterDecl")
						return CreateEllipsisParameterDecl(e);
					return null;
				})
				.Where(e => e != null));
		}

		public static UnifiedParameter CreateNormalParameterDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalParameterDecl");
			/*
			 * normalParameterDecl 
			 * :   variableModifiers type IDENTIFIER ('[' ']')* 
			 */

			return UnifiedParameter.Create(
				node.Element("IDENTIFIER").Value,
				CreateType(node.Element("type")),
				CreateVariableModifiers(node.Element("variableModifiers"))
				);
		}

		public static UnifiedParameter CreateEllipsisParameterDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ellipsisParameterDecl");
			/*
			 * ellipsisParameterDecl  
			 * :   variableModifiers type '...' IDENTIFIER 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateExplicitConstructorInvocation(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "explicitConstructorInvocation");
			/*
			 * explicitConstructorInvocation 
			 * :   (nonWildcardTypeArguments)? ('this'|'super') arguments ';'
			 * |   primary '.' (nonWildcardTypeArguments)? 'super' arguments ';' 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateQualifiedName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedName");
			/*
			 * qualifiedName 
			 * :   IDENTIFIER ('.' IDENTIFIER)* 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateAnnotations(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotations");
			/*
			 * annotations 
			 * :   (annotation)+ 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateAnnotation(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotation");
			/* 
			 * annotation 
			 * :   '@' qualifiedName( '(' ( elementValuePairs | elementValue )? ')' )? 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateElementValuePairs(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePairs");
			/*
			 * elementValuePairs 
			 * :   elementValuePair (',' elementValuePair)* 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateElementValuePair(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePair");
			/*
			 * elementValuePair 
			 * :   IDENTIFIER '=' elementValue 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateElementValue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValue");
			/* 
			 * elementValue 
			 * :   conditionalExpression
			 * |   annotation
			 * |   elementValueArrayInitializer 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateElementValueArrayInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValueArrayInitializer");
			/*
			 * elementValueArrayInitializer 
			 * :   '{' (elementValue ( ',' elementValue)* )? (',')? '}' 
			 */

			throw new NotImplementedException();
		}

		public static UnifiedClassDefinition CreateAnnotationTypeDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeDeclaration");
			/*
			 * annotationTypeDeclaration 
			 * :   modifiers '@' 'interface' IDENTIFIER annotationTypeBody 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedElement CreateAnnotationTypeBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeBody");
			/* 
			 * annotationTypeBody 
			 * :   '{' (annotationTypeElementDeclaration)* '}' 
			 */

			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateAnnotationTypeElementDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeElementDeclaration");
			/*
			 * annotationTypeElementDeclaration 
			 * :   annotationMethodDeclaration
			 * |   interfaceFieldDeclaration
			 * |   normalClassDeclaration
			 * |   normalInterfaceDeclaration
			 * |   enumDeclaration
			 * |   annotationTypeDeclaration
			 * |   ';' 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "annotationMethodDeclaration":
				return CreateAnnotationMethodDeclaration(first);
			case "interfaceFieldDeclaration":
				return CreateInterfaceFieldDeclaration(first);
			case "normalClassDeclaration":
				return CreateNormalClassDeclaration(first);
			case "normalInterfaceDeclaration":
				return CreateNormalInterfaceDeclaration(first);
			case "enumDeclaration":
				return CreateEnumDeclaration(first);
			case "annotationTypeDeclaration":
				return CreateAnnotationTypeDeclaration(first);
			default:
				throw new NotImplementedException();
				//TODO ';'の場合が未実装
			}
		}

		public static IUnifiedExpression CreateAnnotationMethodDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationMethodDeclaration");
			/*
			 * annotationMethodDeclaration 
			 * :   modifiers type IDENTIFIER '(' ')' ('default' elementValue)? ';' 
			 */

			throw new NotImplementedException();
		}

		public static UnifiedBlock CreateBlock(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			/*
			 * block 
			 * :   '{' (blockStatement)* '}' 
			 */
			var block = UnifiedBlock.Create();
			foreach (var e in node.Elements("blockStatement")) {
				block.Add(CreateBlockStatement(e));
			}
			return block;
		}

		public static IUnifiedExpression CreateBlockStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "blockStatement");
			/*
			 * blockStatement 
			 * :   localVariableDeclarationStatement
			 * |   classOrInterfaceDeclaration
			 * |   statement 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "localVariableDeclarationStatement":
				return CreateLocalVariableDeclarationStatement(first);
			case "classOrInterfaceDeclaration":
				return CreateClassOrInterfaceDeclaration(first);
			case "statement":
				return CreateStatement(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedVariableDefinition
			CreateLocalVariableDeclarationStatement(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclarationStatement");
			/*
			 * localVariableDeclarationStatement 
			 * :   localVariableDeclaration ';' 
			 */

			return CreateLocalVariableDeclaration(node.FirstElement());
		}

		public static UnifiedVariableDefinition CreateLocalVariableDeclaration(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclaration");
			/*
			 * localVariableDeclaration 
			 * :   variableModifiers type variableDeclarator (',' variableDeclarator )* 
			 */

			var declarator =
				CreateVariableDeclarator(node.Elements("variableDeclarator").First());
			return UnifiedVariableDefinition.Create(
				CreateType(node.Element("type")),
				CreateVariableModifiers(node.Element("variableModifiers")),
				declarator.RightHandSide,
				declarator.LeftHandSide.ToString()
				);
			//TODO variableDeclaratorが複数の場合が未実装
		}

		public static IUnifiedExpression CreateStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			 * statement 
			 * :   block
			 * |   ('assert') expression (':' expression)? ';'
			 * |   'assert'  expression (':' expression)? ';'            
			 * |   'if' parExpression statement ('else' statement)?          
			 * |   forstatement
			 * |   'while' parExpression statement
			 * |   'do' statement 'while' parExpression ';'
			 * |   trystatement
			 * |   'switch' parExpression '{' switchBlockStatementGroups '}'
			 * |   'synchronized' parExpression block
			 * |   'return' (expression )? ';'
			 * |   'throw' expression ';'
			 * |   'break' (IDENTIFIER)? ';'
			 * |   'continue' (IDENTIFIER)? ';'
			 * |   expression  ';'     
			 * |   IDENTIFIER ':' statement
			 * |   ';' 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "block":
				return CreateBlock(first);
			case "forstatement":
				return CreateForstatement(first);
			case "trystatement":
				return CreateTrystatement(first);
			case "expression":
				return CreateExpression(first);
			}
			switch (first.Value) {
			case "assert":
				throw new NotImplementedException();
			case "if":
				return CreateIf(node);
			case "while":
				return CreateWhile(node);
			case "do":
				return CreateDoWhile(node);
			case "switch":
				return CreateSwitch(node);
			case "synchronized":
				return CreateSynchronized(node);
			case "return":
				return CreateReturn(node);
			case "throw":
				return CreateThrow(node);
			case "break":
				return CreateBreak(node);
			case "continue":
				return CreateContinue(node);
			case ";":
				throw new NotImplementedException();
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static UnifiedCaseCollection CreateSwitchBlockStatementGroups(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroups");
			/*
			 * switchBlockStatementGroups 
			 * :   (switchBlockStatementGroup )* 
			 */

			return UnifiedCaseCollection.Create(
				node.Elements("switchBlockStatementGroup")
					.Select(CreateSwitchBlockStatementGroup));
		}

		public static UnifiedCase CreateSwitchBlockStatementGroup(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroup");
			/*
			 * switchBlockStatementGroup 
			 * :   switchLabel (blockStatement)* 
			 */

			//TODO 現状だとUnifiedCaseと比較して条件文とブロックが分離している
			//bodyが空のUnifiedCaseを作って後から代入しているがこれは大丈夫か
			var switchLabel = CreateSwitchLabel(node.Element("switchLabel"));
			var body = UnifiedBlock.Create(
				node.Elements("blockStatement").Select(CreateBlockStatement));
			switchLabel.Body = body;
			return switchLabel;
		}

		public static UnifiedCase CreateSwitchLabel(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchLabel");
			/*
			 * switchLabel 
			 * :   'case' expression ':'
			 * |   'default' ':' 
			 */

			if (node.HasElement("expression")) {
				return UnifiedCase.Create(
					CreateExpression(node.Element("expression")), null);
			}
			return UnifiedCase.Create(null, null);
		}

		public static UnifiedTry CreateTrystatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "trystatement");
			/*
			 * trystatement 
			 * :   'try' block (catches 'finally' block | catches | 'finally' block) 
			 */

			var body = CreateBlock(node.NthElement(1));
			var catches =
				node.HasElement("catches") ? CreateCatches(node.Element("catches")) : null;
			var finallyBlock = node.HasElement("FINALLY")
			                   	? CreateBlock(node.Elements("block").ElementAt(1)) : null;

			return UnifiedTry.Create(body, catches, finallyBlock);
		}

		public static UnifiedCatchCollection CreateCatches(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catches");
			/*
			 * catches 
			 * :   catchClause (catchClause)* 
			 */

			var catches = UnifiedCatchCollection.Create();
			foreach (var catche in node.Elements("catchClause")) {
				var e = CreateCatchClause(catche);
				catches.Add(e);
			}
			return catches;
		}

		public static UnifiedCatch CreateCatchClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause 
			 * :   'catch' '(' formalParameter ')' block  
			 */

			//TODO UnifiedCatchがUnifiedParameter"Collection"を持つのは、他の言語でその可能性があるため？
			return UnifiedCatch.Create(
				CreateFormalParameter(node.Element("formalParameter")),
				CreateBlock(node.Element("block")));
		}

		public static UnifiedParameterCollection CreateFormalParameter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameter");
			/*
			 * formalParameter 
			 * :   variableModifiers type IDENTIFIER ('[' ']')* 
			 */

			//TODO 配列の場合はどう扱うか
			return UnifiedParameterCollection.Create(
				UnifiedParameter.Create(
					node.NthElement(2).Value,
					CreateType(node.NthElement(1)),
					CreateVariableModifiers(node.NthElement(0))
					)
				);
		}

		public static IUnifiedExpression CreateForstatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forstatement");
			/*
			 * forstatement 
			 * // enhanced for loop
			 *     'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
			 * // normal for loop
			 * |   'for' '(' (forInit)? ';' (expression)? ';' (expressionList)? ')' statement 
			 */

			//TODO 制御構文はどの段階で共通モデルに落とし込めばいいのか
			if (node.NthElement(2).Name() == "variableModifiers") {
				return UnifiedForeach.Create(
					UnifiedVariableDefinition.Create(
						CreateType(node.Element("type")),
						CreateVariableModifiers(node.Element("variableModifiers")),
						null,
						node.Element("IDENTIFIER").Value
						),
					CreateExpression(node.Element("expression")),
					//TODO CreateStatementを直接呼び出さなくていいのか？(どの場合エラーになるが)
					UnifiedBlock.Create(
						CreateStatement(node.Element("statement"))
						)
					);
			} else {
				var forInit = node.HasElement("forInit")
				              	? CreateForInit(node.Element("forInit")) : null;
				var condition = node.HasElement("expression")
				                	? CreateExpression(node.Element("expression")) : null;
				var step = node.HasElement("expressionList")
				           	? UnifiedExpressionCollection.Create(
				           		CreateExpressionList(node.Element("expressionList")))
				           	: null;
				var body = UnifiedBlock.Create(CreateStatement(node.Element("statement")));

				return UnifiedFor.Create(
					forInit,
					condition,
					step,
					body
					);
			}
		}

		public static IUnifiedExpression CreateForInit(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "forInit");
			/*
			 * forInit 
			 * :   localVariableDeclaration
			 * |   expressionList 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "localVariableDeclaration":
				return CreateLocalVariableDeclaration(first);
			case "expressionList":
				return UnifiedExpressionCollection.Create(CreateExpressionList(first));
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateParExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parExpression");
			/*
			 * parExpression 
			 * :   '(' expression ')' 
			 */

			//TODO 括弧の情報は捨てて大丈夫か？ -> 大丈夫
			return CreateExpression(node.NthElement(1));
		}

		public static IEnumerable<IUnifiedExpression> CreateExpressionList(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionList");
			/*
			 * expressionList : expression (',' expression )* ;
			 */

			return node.Elements("expression").Select(CreateExpression);
		}

		public static IUnifiedExpression CreateExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression 
			 * :   conditionalExpression (assignmentOperator expression)? 
			 */

			if (node.HasElement("expression"))
				return UnifiedBinaryExpression.Create(
					CreateConditionalExpression(node.NthElement(0)),
					CreateAssignmentOperator(node.NthElement(1)),
					CreateExpression(node.NthElement(2))
					);
			return CreateConditionalExpression(node.NthElement(0));
		}

		public static UnifiedBinaryOperator CreateAssignmentOperator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignmentOperator");
			/*
			 * assignmentOperator 
			 * :   '='
			 * |   '+='
			 * |   '-='
			 * |   '*='
			 * |   '/='
			 * |   '&='
			 * |   '|='
			 * |   '^='
			 * |   '%='
			 * |    '<' '<' '='
			 * |    '>' '>' '>' '='
			 * |    '>' '>' '=' 
			 */
			var name = node.Value;
			UnifiedBinaryOperatorKind kind;
			switch (name) {
			case "=":
				kind = UnifiedBinaryOperatorKind.Assign;
				break;
			case "+=":
				kind = UnifiedBinaryOperatorKind.AddAssign;
				break;
			case "-=":
				kind = UnifiedBinaryOperatorKind.SubtractAssign;
				break;
			case "*=":
				kind = UnifiedBinaryOperatorKind.MultiplyAssign;
				break;
			case "/=":
				kind = UnifiedBinaryOperatorKind.DivideAssign;
				break;
			case "&=":
				kind = UnifiedBinaryOperatorKind.AndAssign;
				break;
			case "|=":
				kind = UnifiedBinaryOperatorKind.OrAssign;
				break;
			case "^=":
				kind = UnifiedBinaryOperatorKind.ExclusiveOrAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			case "<<=":
				kind = UnifiedBinaryOperatorKind.LogicalLeftShiftAssign;
				break;
			case ">>>=":
				kind = UnifiedBinaryOperatorKind.LogicalRightShiftAssign;
				break;
			case ">>=":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
		}

		public static IUnifiedExpression CreateConditionalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			/*
			 * conditionalExpression 
			 * :   conditionalOrExpression ('?' expression ':' conditionalExpression)?
			 */

			if (node.HasElement("expression")) {
				//TODO ３項演算子に該当する共通モデルの作成
				throw new NotImplementedException();
			}
			return CreateConditionalOrExpression(node.NthElement(0));
		}

		private static IUnifiedExpression CreateBinaryExpression(XElement node,
		                                                         Func
		                                                         	<XElement,
		                                                         	IUnifiedExpression>
		                                                         	createExpression)
		{
			var nodes = node.Elements().OddIndexElements();
			return nodes.Skip(1).Aggregate(createExpression(nodes.First()),
				(e, n) => UnifiedBinaryExpression.Create(
					e, CreateBinaryOperator(n.PreviousElement().Value),
					CreateConditionalAndExpression(node)));
		}

		public static IUnifiedExpression CreateConditionalOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalOrExpression");
			/*
			 * conditionalOrExpression 
			 * :   conditionalAndExpression ('||' conditionalAndExpression)* 
			 */
			return CreateBinaryExpression(node, CreateConditionalAndExpression);
		}

		public static IUnifiedExpression CreateConditionalAndExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalAndExpression");
			/*
			 * conditionalAndExpression 
			 * :   inclusiveOrExpression ('&&' inclusiveOrExpression)* 
			 */
			return CreateBinaryExpression(node, CreateInclusiveOrExpression);
		}

		public static IUnifiedExpression CreateInclusiveOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusiveOrExpression");
			/* 
			 * inclusiveOrExpression 
			 * :   exclusiveOrExpression ('|' exclusiveOrExpression)* 
			 */
			return CreateBinaryExpression(node, CreateExclusiveOrExpression);
		}

		public static IUnifiedExpression CreateExclusiveOrExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusiveOrExpression");
			/*
			 * exclusiveOrExpression 
			 * :   andExpression ('^' andExpression)* 
			 */
			return CreateBinaryExpression(node, CreateAndExpression);
		}

		public static IUnifiedExpression CreateAndExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "andExpression");
			/*
			 * andExpression 
			 * :   equalityExpression ('&' equalityExpression)* 
			 */
			return CreateBinaryExpression(node, CreateEqualityExpression);
		}

		public static IUnifiedExpression CreateEqualityExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			/*
			 * equalityExpression 
			 * :   instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression)* 
			 */
			return CreateBinaryExpression(node, CreateInstanceOfExpression);
		}

		public static IUnifiedExpression CreateInstanceOfExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "instanceOfExpression");
			/*
			 * instanceOfExpression 
			 * :   relationalExpression ('instanceof' type)?
			 */
			var ret = CreateRelationalExpression(node.FirstElement());
			if (node.Elements().Count() > 1) {
				ret = UnifiedBinaryExpression.Create(ret,
					CreateBinaryOperator(node.NthElement(1).Value),
					CreateType(node.LastElement()));
			}
			return ret;
		}

		public static IUnifiedExpression CreateRelationalExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			/*
			 * relationalExpression 
			 * :   shiftExpression (relationalOp shiftExpression)* 
			 */
			return CreateBinaryExpression(node, CreateShiftExpression);
		}

		public static UnifiedBinaryOperator CreateRelationalOp(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalOp");
			/*
			 * relationalOp 
			 * :   '<' '='
			 * |   '>' '='
			 * |   '<'
			 * |   '>'
			 */

			var name = node.Value;
			UnifiedBinaryOperatorKind kind;

			switch (name) {
			case "<=":
				kind = UnifiedBinaryOperatorKind.LessThanOrEqual;
				break;
			case ">=":
				kind = UnifiedBinaryOperatorKind.GreaterThanOrEqual;
				break;
			case "<":
				kind = UnifiedBinaryOperatorKind.LessThan;
				break;
			case ">":
				kind = UnifiedBinaryOperatorKind.GreaterThan;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
		}

		public static IUnifiedExpression CreateShiftExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			/*
			 * shiftExpression 
			 * :   additiveExpression (shiftOp additiveExpression)*
			 */
			return CreateBinaryExpression(node, CreateAdditiveExpression);
		}

		public static IUnifiedElement CreateShiftOp(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftOp");
			/*
			 * shiftOp 
			 * :    '<' '<'
			 * |    '>' '>' '>'
			 * |    '>' '>' 
			 */

			var name = node.Value;
			UnifiedBinaryOperatorKind kind;

			switch (name) {
			case "<<":
				kind = UnifiedBinaryOperatorKind.LogicalLeftShift;
				break;
			case ">>>":
				kind = UnifiedBinaryOperatorKind.LogicalRightShift;
				break;
			case ">>":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShift;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
		}

		public static IUnifiedExpression CreateAdditiveExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			/*
			 * additiveExpression 
			 * :   multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* 
			 */
			return CreateBinaryExpression(node, CreateMultiplicativeExpression);
		}

		public static IUnifiedExpression CreateMultiplicativeExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			/*
			 * multiplicativeExpression 
			 * :   unaryExpression ( ( '*' | '/' | '%' ) unaryExpression)*
			 */
			return CreateBinaryExpression(node, CreateUnaryExpression);
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpression");
			/*
			 * unaryExpression 
			 *	: '+' unaryExpression
			 *	| '-' unaryExpression
			 *	| '++' unaryExpression
			 *	| '--' unaryExpression
			 *	| unaryExpressionNotPlusMinus
			*/
			var firstElement = node.FirstElement();
			if (firstElement.Name() == "unaryExpressionNotPlusMinus") {
				return CreateUnaryExpressionNotPlusMinus(firstElement);
			}
			return UnifiedUnaryExpression.Create(
				CreateUnaryExpression(node.NthElement(1)),
				CreatePrefixUnaryOperator(firstElement.Value));
		}

		public static IUnifiedExpression CreateUnaryExpressionNotPlusMinus(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unaryExpressionNotPlusMinus");
			/*
			 * unaryExpressionNotPlusMinus 
			 *		: '~' unaryExpression
			 *		| '!' unaryExpression
			 *		| castExpression
			 *		| primary (selector)* ( '++' | '--' )?
			 */
			var firstElement = node.FirstElement();
			switch (firstElement.Name()) {
			case "castExpression":
				return CreateCastExpression(firstElement);
			case "primary":
				var result = CreatePrimary(firstElement);

				result = node.Elements("selector")
					.Aggregate(result, CreateSelector);

				var lastNode = node.LastElement();
				if (!lastNode.HasElement()) {
					var ope = lastNode.Value;
					result = UnifiedUnaryExpression.Create(result,
						UnifiedUnaryOperator.Create(ope,
							ope == "++" ? UnifiedUnaryOperatorKind.PostIncrementAssign
								: UnifiedUnaryOperatorKind.PostDecrementAssign));
				}
				return result;
			}
			return UnifiedUnaryExpression.Create(
				CreateExpression(node.NthElement(1)),
				CreatePrefixUnaryOperator(firstElement.Value));
		}

		public static UnifiedCast CreateCastExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "castExpression");
			/*
			 * castExpression 
			 * :   '(' primitiveType ')' unaryExpression
			 * |   '(' type ')' unaryExpressionNotPlusMinus 
			 */

			if (node.NthElement(0).Name() == "primitiveType") {
				return UnifiedCast.Create(
					CreatePrimitiveType(node.NthElement(1)),
					CreateUnaryExpression(node.NthElement(3))
					);
			}
			return UnifiedCast.Create(
				CreateType(node.NthElement(1)),
				CreateUnaryExpressionNotPlusMinus(node.NthElement(3))
				);
		}

		public static IUnifiedExpression CreatePrimary(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary");
			/*
			 * primary 
			 * :   parExpression            
			 * |   'this' ('.' IDENTIFIER)* (identifierSuffix)?
			 * |   IDENTIFIER ('.' IDENTIFIER)* (identifierSuffix)?
			 * |   'super' superSuffix
			 * |   literal
			 * |   creator
			 * |   primitiveType ('[' ']')* '.' 'class'
			 * |   'void' '.' 'class'
			 */
			var first = node.FirstElement();
			if (first.HasContent("this") || first.Name() == "IDENTIFIER") {
				var variable = UnifiedIdentifier.CreateUnknown(first.Value);
				var prop = first.NextElements("IDENTIFIER")
					.Aggregate((IUnifiedExpression)variable,
						(e, v) => UnifiedProperty.Create(e, v.Value, "."));
				return CreateIdentifierSuffix(prop, node.Element("identifierSuffix"));
			}
			if (first.HasContent("super")) {
				var super = UnifiedIdentifier.CreateUnknown("super");
				return CreateSuperSuffix(super, node.Element("superSuffix"));
			}
			if (first.Name() == "literal") {
				return CreateLiteral(first);
			}
			if (first.Name() == "creator") {
				return CreateCreator(first);
			}
			if (first.Name() == "primitiveType") {
				var type = node.Elements()
					.Take(node.Elements().Count() - 2)
					.Aggregate("", (s, e) => s + e.Value);
				return UnifiedProperty.Create(UnifiedType.Create(type), "class", ".");
			}
			if (first.HasContent("void")) {
				return UnifiedProperty.Create(UnifiedIdentifier.CreateUnknown(first.Value),
					"class", ".");
			}
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateSuperSuffix(UnifiedIdentifier prefix,
		                                                   XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "superSuffix");
			/*
			 * superSuffix  
			 * :   arguments
			 * |   '.' (typeArguments)? IDENTIFIER (arguments)?
			 */
			if (node.FirstElement().Name == "arguments") {
				return UnifiedCall.Create(prefix, CreateArguments(node.FirstElement()));
			}
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateIdentifierSuffix(
			IUnifiedExpression prefix, XElement node)
		{
			Contract.Requires(node == null || node.Name() == "identifierSuffix");
			/*
			 * identifierSuffix
			 * :   ('[' ']')+ '.' 'class'	// java.lang.String[].class
			 * |   ('[' expression ']' )+	// strs[10]
			 * |   arguments				// func(1, 2)
			 * |   '.' 'class'				// java.lang.String.class
			 *			// this.<Integer>m(1), super.<Integer>m(1)
			 * |   '.' nonWildcardTypeArguments IDENTIFIER arguments
			 * |   '.' 'this'				// Outer.this
			 * |   '.' 'super' arguments	// new Outer().super();
			 * |   innerCreator				// new Outer().new <Integer> Inner<String>(1);
			 */

			if (node == null) {
				return prefix;
			}
			var second = node.NthElementOrDefault(1);
			if (second != null && second.Name() == "expression") {
				return node.Elements("expression")
					.Select(CreateExpression)
					.Aggregate(prefix, (current, exp) =>
					                   UnifiedIndexer.Create(current,
					                   	UnifiedArgumentCollection.Create(
					                   		UnifiedArgument.Create(exp)))
					);
			}
			if (node.FirstElement().Name() == "arguments") {
				return UnifiedCall.Create(prefix, CreateArguments(node.FirstElement()));
			}
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateSelector(IUnifiedExpression prefix,
		                                                XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selector");
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selector");
			/*
			 *  selector  
				:   '.' IDENTIFIER (arguments)? //student.getName()
				|   '.' 'this' //OuterClass.this
				|   '.' 'super' superSuffix //Outer.super()
				|   innerCreator
				|   '[' expression ']' 
			 */
			var secondElement = node.NthElement(1);
			if (secondElement == null)
				return CreateInnerCreator(prefix, node.FirstElement());

			if (secondElement.Name() == "IDENTIFIER") {
				prefix = UnifiedProperty.Create(prefix, secondElement.Value, ".");
				var arguments = node.Element("arguments");
				if (arguments != null) {
					prefix = UnifiedCall.Create(prefix, CreateArguments(arguments));
				}
				return prefix;
			}

			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateCreator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "creator");
			/*
			 * creator 
			 * :   'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
			 * |   'new' classOrInterfaceType classCreatorRest
			 * |   arrayCreator 
			 */

			var first = node.FirstElement();

			if (first.Name() == "arrayCreator") {
				return CreateArrayCreator(first);
			}

			if (node.Elements().Count() == 4)
				return UnifiedNew.Create(
					CreateClassOrInterfaceType(node.NthElement(2)),
					CreateNonWildcardTypeArguments(node.NthElement(1)),
					null,
					CreateClassCreatorRest(node.NthElement(3))
					);

			return UnifiedNew.Create(
				CreateClassOrInterfaceType(node.NthElement(1)),
				CreateClassCreatorRest(node.NthElement(2))
				);
		}

		public static UnifiedNew CreateArrayCreator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayCreator");
			/*
			 * arrayCreator 
			 * :   'new' createdName '[' ']' ('[' ']')* arrayInitializer
			 * |   'new' createdName '[' expression ']' ( '[' expression ']' )* ('[' ']')* 
			 */

			//TODO 現状では'[]'を見ていないのであとでUnifiedNew.CreateArray()に切り替える
			UnifiedExpressionCollection initVal = null;
			UnifiedArgumentCollection args = null;

			if (node.HasContent("arrayInitializer")) {
				initVal =
					CreateArrayInitializer(node.Element("arrayInitializer"));
			} else {
				//TODO ここでUnifiedArgumentを生成していいのか？
				args = UnifiedArgumentCollection.Create(
					node.Elements("expression")
						.Select(e => UnifiedArgument.Create(CreateExpression(e)))
					);
			}
			return UnifiedNew.Create(
				CreateCreatedName(node.NthElement(1)), args, initVal);
		}

		public static IUnifiedExpression CreateVariableInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableInitializer");
			/*
			 * variableInitializer 
			 * :   arrayInitializer
			 * |   expression 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "arrayInitializer":
				return CreateArrayInitializer(first);
			case "expression":
				return CreateExpression(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedExpressionCollection CreateArrayInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayInitializer");
			/*
			 * arrayInitializer 
			 * :   '{' (variableInitializer (',' variableInitializer)* )? (',')? '}'
			 */

			var exps = UnifiedExpressionCollection.Create();
			foreach (var exp in node.Elements("variableInitializer")) {
				var e = CreateVariableInitializer(exp);
				exps.Add(e);
			}
			return exps;
		}

		public static UnifiedType CreateCreatedName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "createdName");
			/*
			 * createdName 
			 * :   classOrInterfaceType
			 * |   primitiveType 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "classOrInterfaceType":
				return CreateClassOrInterfaceType(first);
			case "primitiveType":
				return CreatePrimitiveType(first);
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateInnerCreator(IUnifiedExpression prefix,
		                                                    XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "innerCreator");
			/*
			 * innerCreator  
			 * :   '.' 'new' (nonWildcardTypeArguments)? IDENTIFIER (typeArguments)? classCreatorRest 
			 */
			//TODO innerCreatorの実際のコードを調べる
			return null;
		}

		public static UnifiedBlock CreateClassCreatorRest(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classCreatorRest");
			/*
			 * classCreatorRest 
			 * :   arguments (classBody)? 
			 */
			//TODO classCreatorRestの型はどうするのか？
			return null;
		}

		public static UnifiedArgumentCollection CreateNonWildcardTypeArguments(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nonWildcardTypeArguments");
			/*
			 * nonWildcardTypeArguments 
			 * :   '<' typeList '>'
			 */
			//TODO typeListは最終的にTypeCollectionになるが、どう対処するのか
			throw new NotImplementedException();
			//return CreateTypeList(node.FirstElement());
		}

		public static UnifiedArgumentCollection CreateArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arguments");
			/*
			 * arguments : '(' (expressionList)? ')'
			 */

			var expressionListNode = node.Element("expressionList");
			if (expressionListNode == null)
				return UnifiedArgumentCollection.Create();

			var args = CreateExpressionList(expressionListNode)
				.Select(UnifiedArgument.Create);
			return UnifiedArgumentCollection.Create(args);
		}

		public static UnifiedLiteral CreateLiteral(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			/*
			 * literal 
			 * :   INTLITERAL
			 * |   LONGLITERAL
			 * |   FLOATLITERAL
			 * |   DOUBLELITERAL
			 * |   CHARLITERAL
			 * |   STRINGLITERAL
			 * |   TRUE
			 * |   FALSE
			 * |   NULL 
			 */

			var first = node.FirstElement();
			switch (first.Name()) {
			case "INTLITERAL":
			case "LONGLITERAL":
			case "FLOATLITERAL":
			case "DOUBLELITERAL":
			case "CHARLITERAL":
			case "STRINGLITERAL":
			case "TRUE":
			case "FALSE":
			case "NULL":
				//TODO ANTLRですべてTOKEに書き換えられてしまう
				throw new NotImplementedException();
			default:
				throw new InvalidOperationException();
			}
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
			/*
			 * localVariableHeader 
			 * :   variableModifiers type IDENTIFIER ('['']')* ('='|','|';')
			 */

			return null;
		}

		public static UnifiedBinaryOperator CreateBinaryOperator(string name)
		{
			Contract.Requires(name != null);
			UnifiedBinaryOperatorKind kind;
			switch (name) {
				// Arithmetic
			case "+":
				kind = UnifiedBinaryOperatorKind.Add;
				break;
			case "-":
				kind = UnifiedBinaryOperatorKind.Subtract;
				break;
			case "*":
				kind = UnifiedBinaryOperatorKind.Multiply;
				break;
			case "/":
				kind = UnifiedBinaryOperatorKind.Divide;
				break;
			case "%":
				kind = UnifiedBinaryOperatorKind.Modulo;
				break;
				// Shift
			case "<<":
				kind = UnifiedBinaryOperatorKind.ArithmeticLeftShift;
				break;
			case ">>":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShift;
				break;
				// Comparison
			case ">":
				kind = UnifiedBinaryOperatorKind.GreaterThan;
				break;
			case ">=":
				kind = UnifiedBinaryOperatorKind.GreaterThanOrEqual;
				break;
			case "<":
				kind = UnifiedBinaryOperatorKind.LessThan;
				break;
			case "<=":
				kind = UnifiedBinaryOperatorKind.LessThanOrEqual;
				break;
			case "==":
				kind = UnifiedBinaryOperatorKind.Equal;
				break;
			case "!=":
				kind = UnifiedBinaryOperatorKind.NotEqual;
				break;
				// Logocal
			case "&&":
				kind = UnifiedBinaryOperatorKind.AndAlso;
				break;
			case "||":
				kind = UnifiedBinaryOperatorKind.OrElse;
				break;
				// Bit
			case "&":
				kind = UnifiedBinaryOperatorKind.And;
				break;
			case "|":
				kind = UnifiedBinaryOperatorKind.Or;
				break;
			case "^":
				kind = UnifiedBinaryOperatorKind.ExclusiveOr;
				break;
				// Assignment
			case "=":
				kind = UnifiedBinaryOperatorKind.Assign;
				break;
			case "+=":
				kind = UnifiedBinaryOperatorKind.AddAssign;
				break;
			case "-=":
				kind = UnifiedBinaryOperatorKind.SubtractAssign;
				break;
			case "*=":
				kind = UnifiedBinaryOperatorKind.MultiplyAssign;
				break;
			case "/=":
				kind = UnifiedBinaryOperatorKind.DivideAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			case "instanceof":
				kind = UnifiedBinaryOperatorKind.InstanceOf;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(name, kind);
		}

		public static UnifiedUnaryOperator CreatePrefixUnaryOperator(string name)
		{
			Contract.Requires(name != null);
			UnifiedUnaryOperatorKind kind;
			switch (name) {
			case "+":
				kind = UnifiedUnaryOperatorKind.UnaryPlus;
				break;
			case "-":
				kind = UnifiedUnaryOperatorKind.Negate;
				break;
			case "++":
				kind = UnifiedUnaryOperatorKind.PreIncrementAssign;
				break;
			case "--":
				kind = UnifiedUnaryOperatorKind.PreDecrementAssign;
				break;
			case "~":
				kind = UnifiedUnaryOperatorKind.OnesComplement;
				break;
			case "!":
				kind = UnifiedUnaryOperatorKind.Not;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedUnaryOperator.Create(name, kind);
		}

		private static UnifiedIf CreateIf(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "IF");
			/*  
			 * 'if' parExpression statement ('else' statement)? 
			 */

			var trueBody = 
				UnifiedBlock.Create(CreateStatement(node.Element("statement")));

			UnifiedBlock falseBody = null;
			if (node.Elements("statement").Count() == 2) {
				var falseNode = node.Elements("statement").ElementAt(1);
				falseBody = 
					UnifiedBlock.Create(CreateStatement(falseNode));
			}
			return UnifiedIf.Create(
				CreateParExpression(node.Element("parExpression")),
				trueBody, 
				falseBody
				);
		}

		private static UnifiedWhile CreateWhile(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "WHILE");
			/* 
			 * 'while' parExpression statement
			 */

			return UnifiedWhile.Create(
				UnifiedBlock.Create(CreateStatement(node.Element("statement"))),
				CreateParExpression(node.Element("parExpression"))
				);
		}

		private static UnifiedDoWhile CreateDoWhile(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.Elements().First().Name() == "DO");
			/* 
			 * 'do' statement 'while' parExpression ';' 
			 */

			return UnifiedDoWhile.Create(
				UnifiedBlock.Create(CreateStatement(node.Element("statement"))),
				CreateParExpression(node.Element("parExpression"))
				);
		}

		private static UnifiedSwitch CreateSwitch(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("switch"));
			/* 
			 * 'switch' parExpression '{' switchBlockStatementGroups '}' 
			 */

			return
				UnifiedSwitch.Create(
					CreateParExpression(node.Element("parExpression")),
					CreateSwitchBlockStatementGroups(node.Element("switchBlockStatementGroups"))
					);
		}

		private static UnifiedSpecialExpression CreateReturn(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("return"));
			/*
			 * 'return' (expression)? ';'
			 */

			IUnifiedExpression value = null;
			if (node.Elements().Count() == 3) {
				value = CreateExpression(node.Element("expression"));
			}
			return UnifiedSpecialExpression.CreateReturn(value);
		}

		private static UnifiedSpecialExpression CreateBreak(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("break"));
			/* 'break' (IDENTIFIER )? ';' */

			if (node.Elements().Count() > 2)
				//TODO ラベルが指定されている場合が未実装
				throw new NotImplementedException();
			return UnifiedSpecialExpression.CreateBreak();
		}

		private static UnifiedSpecialExpression CreateContinue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("continue"));
			/* 'continue' (IDENTIFIER)? ';' */

			if (node.Elements().Count() > 2)
				//TODO ラベルが指定されている場合が未実装
				throw new NotImplementedException();
			return UnifiedSpecialExpression.CreateContinue();
		}

		private static UnifiedSpecialBlock CreateSynchronized(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("synchronized"));
			/* 
			 * 'synchronized' parExpression block 
			 */

			return UnifiedSpecialBlock.Create(
				UnifiedSpecialBlockKind.Synchrnoized,
				CreateParExpression(node.Element("parExpression")),
				CreateBlock(node.Element("block"))
				);
		}

		private static UnifiedSpecialExpression CreateThrow(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("throw"));
			/*
			 * 'throw' expression ';' 
			 */

			return
				UnifiedSpecialExpression.CreateThrow(
					CreateExpression(node.Element("expression")));
		}
	}
}