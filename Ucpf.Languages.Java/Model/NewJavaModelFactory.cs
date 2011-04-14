using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
using Paraiba.Xml.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

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
				// TODO: use annotations
				var annotations = CreateAnnotations(node.FirstElement());
				var packageDeclaration = CreatePackageDeclaration(node.NthElement(1));
				expressions = packageDeclaration.Body;
			}
			foreach (var e in node.Elements("importDeclaration")) {
				var importDeclaration = CreateImportDeclaration(e);
				expressions.PrivateAdd(importDeclaration);
			}
			foreach (var e in node.Elements("typeDeclaration")) {
				var typeDeclaration = CreateTypeDeclaration(e);
				expressions.PrivateAddRange(typeDeclaration);
			}
			return program;
		}

		public static UnifiedClassDefinition CreatePackageDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "packageDeclaration");
			// TODO: imeplement this
			return null;
		}

		public static IUnifiedExpression CreateImportDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "importDeclaration");
			// TODO: imeplement this
			return null;
		}

		public static IUnifiedElement CreateQualifiedImportName(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedImportName");
			// TODO: imeplement this
			return null;
		}

		public static IEnumerable<UnifiedClassDefinition> CreateTypeDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeDeclaration");
			/*
			 * typeDeclaration 
			 * :   classOrInterfaceDeclaration
			 * |   ';' 
			 */
			if (node.FirstElement().Name() == "classOrInterfaceDeclaration") {
				yield return CreateClassOrInterfaceDeclaration(node.FirstElement());
			}
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
			foreach (var e in node.Elements()) {
				if (e.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.Add(UnifiedAnnotation.Create());
				} else {
					modifiers.Add(UnifiedModifier.Create(e.Value));
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
			foreach (var e in node.Elements()) {
				if (e.Name() == "annotation") {
					//TODO まだUnifiedAnnotationは未実装
					//modifiers.Add(UnifiedAnnotation.Create());
				} else {
					modifiers.Add(UnifiedModifier.Create(e.Value));
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
				return CreateEnumDeclaration(first);
			}
			throw new InvalidOperationException();
		}

		public static UnifiedClassDefinition CreateNormalClassDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalClassDeclaration");
			/*
			 * normalClassDeclaration 
			 * :   modifiers 'class' IDENTIFIER (typeParameters)? ('extends' type)? ('implements' typeList)? classBody 
			 */
			var modifiers = CreateModifiers(node.Element("modifiers"));
			var name = UnifiedIdentifier.CreateType(node.Element("IDENTIFIER").Value);
			var typeParameters = node.HasElement("typeParameters")
			                     	? CreateTypeParameters(node.Element("typeParameters"))
			                     	: null;
			var constrains = UnifiedTypeConstrainCollection.Create();
			if (node.HasElement("type")) {
				constrains.Add(UnifiedTypeConstrain.CreateExtends(
					CreateType(node.Element("type"))));
			}
			if (node.HasElement("typeList")) {
				foreach (var type in CreateTypeList(node.Element("typeList")))  {
					constrains.Add(UnifiedTypeConstrain.CreateImplements(type));
				}
			}
			var body = CreateClassBody(node.Element("classBody"));
			return UnifiedClassDefinition.Create(modifiers, UnifiedClassKind.Class, name, typeParameters,
				constrains, body);
		}

		public static UnifiedTypeParameterCollection CreateTypeParameters(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeParameters");
			/*
			 * typeParameters 
			 * :   '<' typeParameter (',' typeParameter )* '>' 
			 */
			return node.Elements("typeParameter")
				.Select(CreateTypeParameter)
				.ToCollection();
		}

		public static UnifiedTypeParameter CreateTypeParameter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeParameter");
			/*
			 * typeParameter 
			 * :   IDENTIFIER ('extends' typeBound)? 
			 */
			if (node.Elements().Count() == 1) {
				return UnifiedTypeParameter.Create(
					UnifiedType.CreateUsingString(node.FirstElement().Value));
			}
			return UnifiedTypeParameter.Create(
				UnifiedType.CreateUsingString(node.FirstElement().Value),
				UnifiedTypeConstrainCollection.Create(
					CreateTypeBound(node.LastElement())
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

		public static UnifiedClassDefinition CreateEnumDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumDeclaration");
			/*
			 * enumDeclaration 
			 * :   modifiers ('enum') IDENTIFIER ('implements' typeList)? enumBody 
			 */
			var modifiers = CreateModifiers(node);
			var name = node.NthElement(2).Value;
			var typeListNode = node.Element("typeList");
			var constrains = typeListNode != null
			               	? CreateTypeList(typeListNode)
			               	  	.Select(UnifiedTypeConstrain.CreateImplements)
			               	  	.ToCollection()
			               	: null;
			var enumBody = CreateEnumBody(node.Element("enumBody"));
			return UnifiedClassDefinition.Create(modifiers,
				UnifiedClassKind.Enum,
				UnifiedIdentifier.CreateType(name),
				null,
				constrains,
				enumBody);
		}

		public static UnifiedBlock CreateEnumBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBody");
			/*
			 * enumBody 
			 * :   '{' (enumConstants)? ','? (enumBodyDeclarations)? '}' 
			 */
			var block = UnifiedBlock.Create();
			var enumConstantsNode = node.Element("enumConstants");
			if (enumConstantsNode != null)
				block.AddRange(CreateEnumConstants(enumConstantsNode));
			var enumBodyDeclarationsNode = node.Element("enumBodyDeclarations");
			if (enumBodyDeclarationsNode  != null)
				block.AddRange(CreateEnumBodyDeclarations(enumBodyDeclarationsNode));
			return block;
		}

		public static IEnumerable<IUnifiedExpression> CreateEnumConstants(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstants");
			/*
			 * enumConstants 
			 * :   enumConstant (',' enumConstant)* 
			 */
			return node.Elements("enumConstant")
				.Select(CreateEnumConstant);
		}

		public static IUnifiedExpression CreateEnumConstant(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstant");
			/*
			 * enumConstant 
			 * :   (annotations)? IDENTIFIER (arguments)? (classBody)?
			 */
			var annotationsNode = node.Element("annotations");
			var argumentsNode = node.Element("arguments");
			var classBodyNode = node.Element("classBody");
			// TODO: use annotations
			var annotations = annotationsNode != null
			                  	? CreateAnnotations(annotationsNode)
			                  	: null;
			var name = node.ElementByContent().Value;
			var arguments = argumentsNode != null
			                  	? CreateArguments(argumentsNode)
			                  	: null;
			var classBody = classBodyNode != null
			                  	? CreateClassBody(classBodyNode)
			                  	: null;
			return UnifiedVariableDefinition.CreateSingle(
				null,
				null,
				UnifiedIdentifier.Create(name, UnifiedIdentifierKind.Variable),
				null,
				arguments,
				classBody);
		}

		public static IEnumerable<IUnifiedExpression> CreateEnumBodyDeclarations(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBodyDeclarations");
			/*
			 * enumBodyDeclarations 
			 * :   ';' (classBodyDeclaration)* 
			 */
			return node.Elements("classBodyDeclaration")
				.SelectMany(CreateClassBodyDeclaration);
		}

		public static UnifiedClassDefinition CreateInterfaceDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceDeclaration");
			/*
			 * interfaceDeclaration 
			 * :   normalInterfaceDeclaration | annotationTypeDeclaration 
			 */
			var first = node.FirstElement();
			if (first.Name() == "normalInterfaceDeclaration") {
				return CreateNormalInterfaceDeclaration(first);
			}
			if (first.Name() == "annotationTypeDeclaration") {
				return CreateAnnotationTypeDeclaration(first);
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
			var name = UnifiedIdentifier.CreateType(node.Element("IDENTIFIER").Value);
			var typeParameters = node.Element("typeParameters") != null
			                     	? CreateTypeParameters(node.Element("typeParameters"))
			                     	: null;
			var constrains = node.Element("typeList") != null
			                 	? UnifiedTypeConstrainCollection.Create(
			                 		CreateTypeList(node.Element("typeList")).Select(
			                 			UnifiedTypeConstrain.CreateExtends))
			                 	: null;
			var body = CreateInterfaceBody(node.Element("interfaceBody"));

			//TODO UnifiedClassDefinitionのCreateの整理
			return UnifiedClassDefinition.Create(modifiers, UnifiedClassKind.Interface,
				name, typeParameters, constrains, body);
		}

		public static UnifiedTypeCollection CreateTypeList(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeList");
			/*
			 * typeList 
			 * :   type (',' type)* 
			 */
			return node.Elements("type")
				.Select(CreateType).ToCollection();
		}

		public static UnifiedBlock CreateClassBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classBody");
			/*
			 * classBody 
			 * :   '{' (classBodyDeclaration)* '}' 
			 */
			return node.Elements("classBodyDeclaration")
				.SelectMany(CreateClassBodyDeclaration)
				.ToBlock();
		}

		public static UnifiedBlock CreateInterfaceBody(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceBody");
			/*
			 * interfaceBody 
			 * :   '{' (interfaceBodyDeclaration)* '}' 
			 */
			return node.Elements("interfaceBodyDeclaration")
				.SelectMany(CreateInterfaceBodyDeclaration)
				.ToBlock();
		}

		public static IEnumerable<IUnifiedExpression> CreateClassBodyDeclaration(XElement node)
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
				//case static initializer
				var modifier = node.HasContent("static")
				               	? UnifiedModifier.Create("static")
								: null;
				yield return UnifiedConstructorDefinition.Create(
					CreateBlock(node.Element("block")),
					modifier,
					null,
					UnifiedFunctionDefinitionKind.StaticInitializer);
			}
			if (node.HasElement("memberDecl")) {
				yield return CreateMemberDecl(node.Element("memberDecl"));
			}
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

			/* コード例
			 * public int[] getName(String name) [] throws Error {
			 *	   int[][] a = null;
			 *     return a;
			 * } 
			 */

			// TODO 未実装
			var name = UnifiedIdentifier.Create(
				node.Element("IDENTIFIER").Value,
				UnifiedIdentifierKind.Function
				);
			var typeParameters = node.HasElement("typeParameters")
			                     	? CreateTypeParameters(node.Element("typeParameters"))
			                    	: null;
			var type = CreateType(node.Element("type")); //コンストラクタの場合はnullになるがどうせ使わない
			var dimension = node.ElementsByContent("[").Count();
				for(var i = 0; i < dimension; i++)
					type.AddSupplement(UnifiedTypeSupplement.Create(null,UnifiedTypeSupplementKind.Array));
			var modifiers = CreateModifiers(node.Element("modifiers"));
			var parameters = CreateFormalParameters(node.Element("formalParameters"));
			var throws = node.HasElement("qualifiedNameList")
			             	? UnifiedTypeCollection.Create(
			             		CreateQualifiedNameList(node.Element("qualifiedNameList"))
			             	  	.Select(e => UnifiedType.Create(e, null, null)))
			             	: null;
			var body = CreateBlock(node.Element("block"));

			if (!node.HasElement("type") && !node.HasElementByContent("void")) {
				//case constructor
				//TODO 考慮していない要素の実装
				return UnifiedConstructorDefinition.Create(
						node.Elements("blockStatement")
							.SelectMany(CreateBlockStatement)
							.ToBlock(),
					modifiers,
					parameters,UnifiedFunctionDefinitionKind.Constructor);
			}
			//TODO UnifiedFunctionDefinition.Createの整備
			return UnifiedFunctionDefinition.CreateFunction(
				name,
				type,
				modifiers,
				parameters,
				body
				);
		}

		public static UnifiedVariableDefinition CreateFieldDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fieldDeclaration");
			/*
			 * fieldDeclaration 
			 * :   modifiers type variableDeclarator (',' variableDeclarator)* ';' 
			 */
			var bodys = node.Elements("variableDeclarator")
				.Select(CreateVariableDeclarator)
				.ToCollection();
			return UnifiedVariableDefinition.Create(
				CreateModifiers(node.Element("modifiers")),
				CreateType(node.Element("type")),
				bodys);
		}

		public static UnifiedVariableDefinitionBody CreateVariableDeclarator(
			XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarator");
			/*
			 * variableDeclarator 
			 * :   IDENTIFIER ('[' ']')* ('=' variableInitializer)? 
			 */
			return UnifiedVariableDefinitionBody.Create(
				node.Element("IDENTIFIER").Value,
					UnifiedTypeSupplementCollection.CreateArray(node.ElementsByContent("[").Count()),
				CreateVariableInitializer(node.Element("variableInitializer")));
		}

		public static IEnumerable<IUnifiedExpression> CreateInterfaceBodyDeclaration(XElement node)
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
				yield return CreateInterfaceFieldDeclaration(first);
				break;
			case "interfaceMethodDeclaration":
				yield return CreateInterfaceMethodDeclaration(first);
				break;
			case "interfaceDeclaration":
				yield return CreateInterfaceDeclaration(first);
				break;
			case "classDeclaration":
				yield return CreateClassDeclaration(first);
				break;
			default:
				yield break;
			}
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
			// TODO: 未使用
			var typeParameters = node.HasElement("typeParameters")
			                     	? CreateTypeParameters(node.Element("typeParameters"))
			                     	: null;
			var type = CreateType(node.Element("type"));
			var dimension = node.ElementsByContent("[").Count();
				for(var i = 0; i < dimension; i++)
					type.AddSupplement(UnifiedTypeSupplement.Create(null,UnifiedTypeSupplementKind.Array));
			var name = UnifiedIdentifier.Create(node.Element("IDENTIFIER").Value,
				UnifiedIdentifierKind.Function);
			var parameters = CreateFormalParameters(node.Element("formalParameters"));

			var throws = node.HasElement("qualifiedNameList")
			             	? UnifiedTypeCollection.Create(
			             		CreateQualifiedNameList(node.Element("qualifiedNameList"))
			             	  	.Select(e => UnifiedType.Create(e, null, null)))
			             	: null;

			//TODO UnifiedFunctionDefinitionのCreateの整理
			//TODO 引数が8個のCreateを実装
			return UnifiedFunctionDefinition.CreateFunction(name, type, modifiers,
				parameters, throws, null);
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
			var bodys = node.Elements("variableDeclarator")
				.Select(CreateVariableDeclarator)
				.ToCollection();
			return UnifiedVariableDefinition.Create(
				CreateModifiers(node.Element("modifiers")),
				CreateType(node.Element("type")),
				bodys);
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
				return UnifiedType.CreateUsingString("void");

			var first = node.FirstElement();
			UnifiedType type;
			
			switch (first.Name()) {
			case "classOrInterfaceType":
				type = CreateClassOrInterfaceType(first);
				break;
			case "primitiveType":
				type = CreatePrimitiveType(first);
				break;
			default:
				throw new InvalidOperationException();
			}
			var dimension = node.ElementsByContent("[").Count();
			type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);
			return type;
		}

		public static UnifiedType CreateClassOrInterfaceType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			/*
			 * classOrInterfaceType 
			 * :   IDENTIFIER (typeArguments)? ('.' IDENTIFIER (typeArguments)? )* 
			 */
			// TODO 坂本担当予定：具体的なケースの洗い出し
			var name = node.Element("IDENTIFIER").Value;
			if (node.HasElement("typeArguments")) {
				return UnifiedType.CreateUsingString(
					name, CreateTypeArguments(node.Element("typeArguments")));
			}
			return UnifiedType.CreateUsingString(name);
			//TODO typeArgumentsを複数持っている場合が未実装
		}

		public static UnifiedType CreatePrimitiveType(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primitiveType");
			/* 
			 * primitiveType  
			 * :   'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' 
			 */
			return UnifiedType.CreateUsingString(node.Value);
		}

		public static UnifiedTypeArgumentCollection CreateTypeArguments(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeArguments");
			/* 
			 * typeArguments 
			 * :   '<' typeArgument (',' typeArgument)* '>' 
			 */
			return node.Elements("typeArgument")
					.Select(CreateTypeArgument)
					.ToCollection();
		}

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
				return UnifiedTypeArgument.Create(CreateType(node.FirstElement()), null);
			}

			var type = UnifiedType.CreateUsingString(node.NthElement(0).Value);
			UnifiedTypeConstrain constrains = null;
			
			if (node.HasElement("type")) {
				if(node.NthElement(1).Value == "extends") {
					constrains = UnifiedTypeConstrain.Create(CreateType(node.Element("type")),
						UnifiedTypeConstrainKind.Extends);
				}
				else {
					constrains = UnifiedTypeConstrain.Create(CreateType(node.Element("type")),
						UnifiedTypeConstrainKind.Super);
				}
			}
			return UnifiedTypeArgument.Create(type, null, constrains.ToCollection());
		}

		public static IEnumerable<IUnifiedExpression> CreateQualifiedNameList(
			XElement node)
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
				// ()が付いているので空集合を返す
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
			return node.Elements()
				.OddIndexElements()
				.Select(e => e.Name() == "normalParameterDecl"
				             	? CreateNormalParameterDecl(e)
				             	: CreateEllipsisParameterDecl(e))
				.ToCollection();
		}

		public static UnifiedParameter CreateNormalParameterDecl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalParameterDecl");
			/*
			 * normalParameterDecl 
			 * :   variableModifiers type IDENTIFIER ('[' ']')*
			 */
			var type = CreateType(node.Element("type"));
			var dimension = node.ElementsByContent("[").Count();
			type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);

			return UnifiedParameter.Create(
				node.Element("IDENTIFIER").Value,
				type,
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
			var ids = node.Elements()
				.OddIndexElements()
				.Select(e => UnifiedIdentifier.CreateUnknown(e.Value));
			return ids.Skip(1)
				.Aggregate((IUnifiedExpression)ids.First(),
					(l, r) => UnifiedProperty.Create(l, r, "."));
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

		public static UnifiedClassDefinition CreateAnnotationTypeDeclaration(
			XElement node)
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

		public static IEnumerable<IUnifiedExpression> CreateAnnotationTypeElementDeclaration(
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
				yield return CreateAnnotationMethodDeclaration(first);
				break;
			case "interfaceFieldDeclaration":
				yield return CreateInterfaceFieldDeclaration(first);
				break;
			case "normalClassDeclaration":
				yield return CreateNormalClassDeclaration(first);
				break;
			case "normalInterfaceDeclaration":
				yield return CreateNormalInterfaceDeclaration(first);
				break;
			case "enumDeclaration":
				yield return CreateEnumDeclaration(first);
				break;
			case "annotationTypeDeclaration":
				yield return CreateAnnotationTypeDeclaration(first);
				break;
			default:
				yield break;
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
			return node.Elements("blockStatement")
				.SelectMany(CreateBlockStatement)
				.ToBlock();
		}

		public static IEnumerable<IUnifiedExpression> CreateBlockStatement(XElement node)
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
				yield return CreateLocalVariableDeclarationStatement(first);
				break;
			case "classOrInterfaceDeclaration":
				yield return CreateClassOrInterfaceDeclaration(first);
				break;
			case "statement":
				foreach (var stmt in CreateStatement(first)) {
					yield return stmt;
				}
				break;
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
			var bodys = node.Elements("variableDeclarator")
				.Select(CreateVariableDeclarator)
				.ToCollection();
			return UnifiedVariableDefinition.Create(
				CreateVariableModifiers(node.Element("variableModifiers")),
				CreateType(node.Element("type")),
				bodys);
		}

		public static IEnumerable<IUnifiedExpression> CreateStatement(XElement node)
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
				yield return CreateBlock(first);
				yield break;
			case "forstatement":
				yield return CreateForstatement(first);
				yield break;
			case "trystatement":
				yield return CreateTrystatement(first);
				yield break;
			case "expression":
				yield return CreateExpression(first);
				yield break;
			case "IDENTIFIER":
				// TODO implement
				throw new NotImplementedException();
			}
			switch (first.Value) {
			case "assert":
				// TODO assert
				throw new NotImplementedException();
			case "if":
				yield return CreateIf(node);
				break;
			case "while":
				yield return CreateWhile(node);
				break;
			case "do":
				yield return CreateDoWhile(node);
				break;
			case "switch":
				yield return CreateSwitch(node);
				break;
			case "synchronized":
				yield return CreateSynchronized(node);
				break;
			case "return":
				yield return CreateReturn(node);
				break;
			case "throw":
				yield return CreateThrow(node);
				break;
			case "break":
				yield return CreateBreak(node);
				break;
			case "continue":
				yield return CreateContinue(node);
				break;
			case ";":
				break;
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
			return node.Elements("switchBlockStatementGroup")
					.Select(CreateSwitchBlockStatementGroup)
					.ToCollection();
		}

		public static UnifiedCase CreateSwitchBlockStatementGroup(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroup");
			/*
			 * switchBlockStatementGroup 
			 * :   switchLabel (blockStatement)* 
			 */
			var body = node.Elements("blockStatement")
					.SelectMany(CreateBlockStatement)
					.ToBlock();
			return UnifiedCase.Create(CreateSwitchLabel(node.Element("switchLabel")), body);
		}

		public static IUnifiedExpression CreateSwitchLabel(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchLabel");
			/*
			 * switchLabel 
			 * :   'case' expression ':'
			 * |   'default' ':' 
			 */
			if (node.HasElement("expression")) {
				return CreateExpression(node.Element("expression"));
			}
			return null;
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
			var catches = node.HasElement("catches")
				? CreateCatches(node.Element("catches")) 
				: null;
			var finallyBlock = node.HasElement("FINALLY")
			                   	? CreateBlock(node.Elements("block").ElementAt(1)) 
								: null;
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
			return node.Elements("catchClause")
				.Select(CreateCatchClause)
				.ToCollection();
		}

		public static UnifiedCatch CreateCatchClause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause 
			 * :   'catch' '(' formalParameter ')' block  
			 */
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

			var type = CreateType(node.NthElement(1));
			var dimension = node.ElementsByContent("[").Count();
			type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);

			return UnifiedParameterCollection.Create(
				UnifiedParameter.Create(
					node.NthElement(2).Value,
					type,
					CreateVariableModifiers(node.FirstElement())
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
			if (node.NthElement(2).Name() == "variableModifiers") {
				return UnifiedForeach.Create(
					UnifiedVariableDefinition.CreateSingle(
						CreateType(node.Element("type")),
						CreateVariableModifiers(node.Element("variableModifiers")),
						null,
						node.Element("IDENTIFIER").Value
						),
					CreateExpression(node.Element("expression")),
					CreateStatement(node.Element("statement"))
					.ToBlock()
					);
			} else {
				var forInit = node.HasElement("forInit")
				              	? CreateForInit(node.Element("forInit"))
								: null;
				var condition = node.HasElement("expression")
				                	? CreateExpression(node.Element("expression"))
									: null;
				var step = node.HasElement("expressionList")
							? CreateExpressionList(node.Element("expressionList"))
								.ToExpressionList()
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
				return CreateExpressionList(first).ToExpressionList();
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
					CreateConditionalExpression(node.FirstElement()),
					CreateAssignmentOperator(node.NthElement(1)),
					CreateExpression(node.NthElement(2))
					);
			return CreateConditionalExpression(node.FirstElement());
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
				throw new IndexOutOfRangeException();
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
				return UnifiedTernaryExpression.Create(
					CreateConditionalExpression(node.NthElement(0)),
					UnifiedTernaryOperator.Create(
						node.NthElement(1).Value, 
						node.NthElement(3).Value,
						UnifiedTernaryOperatorKind.Conditional
						),
					CreateExpression(node.NthElement(2)),
					CreateConditionalExpression(node.NthElement(4))
					);
			}
			return CreateConditionalOrExpression(node.FirstElement());
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
				throw new IndexOutOfRangeException();
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

			if (node.FirstElement().Name() == "primitiveType") {
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
				return UnifiedProperty.Create(UnifiedType.CreateUsingString(type), "class", ".");
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
			// TODO implement
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
			// TODO implement
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

			//TODO classCreatorRest内のargumentsが必要となるケースを調査
			if (node.Elements().Count() == 4)
				return UnifiedNew.Create(
					CreateClassOrInterfaceType(node.NthElement(2)),
					CreateNonWildcardTypeArguments(node.NthElement(1)),
					null,
					CreateClassCreatorRest(node.NthElement(3)).Item2
					);

			return UnifiedNew.Create(
				CreateClassOrInterfaceType(node.NthElement(1)),
				CreateClassCreatorRest(node.NthElement(2)).Item2
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

			//TODO UnifiedNew.CreateArray()を使う必要があるのか？typeにsupplementをaddするのではダメか？
			var type = CreateCreatedName(node.NthElement(1));
			int dimension;

			if (node.HasContent("arrayInitializer")) { 
				var initVal = CreateArrayInitializer(node.Element("arrayInitializer"));
				dimension = node.ElementsByContent("[").Count();
				type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);
				type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);
				return UnifiedNew.Create(type, null, initVal, null);
			}

			var supplements = UnifiedTypeSupplementCollection.Create();
			foreach (var exps in node.Elements("expression")) {
				var supplement =
					UnifiedTypeSupplement.Create(CreateExpression(exps).ToCollection(),
						UnifiedTypeSupplementKind.Array);
				supplements.Add(supplement);
			}
			type.Supplements = supplements;
			dimension = node.ElementsByContent("[").Where(e => e.NextElement().Name == "]").Count();
			for(var i=0; i<dimension; i++)
				type.AddSupplement(UnifiedTypeSupplement.Create(null, UnifiedTypeSupplementKind.Array));

			return UnifiedNew.Create(type);
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
				throw new IndexOutOfRangeException();
			}
		}

		public static UnifiedExpressionList CreateArrayInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayInitializer");
			/*
			 * arrayInitializer 
			 * :   '{' (variableInitializer (',' variableInitializer)* )? (',')? '}'
			 */
			return node.Elements("variableInitializer")
				.Select(CreateVariableInitializer)
				.ToExpressionList();
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
				throw new IndexOutOfRangeException();
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

		public static Tuple<UnifiedArgumentCollection, UnifiedBlock> CreateClassCreatorRest(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classCreatorRest");
			/*
			 * classCreatorRest 
			 * :   arguments (classBody)? 
			 */

			var body = node.HasElement("classBody")
			           	? CreateClassBody(node.Element("classBody")) : null;
			return
				new Tuple<UnifiedArgumentCollection, UnifiedBlock>(
					CreateArguments(node.Element("arguments")), body);
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

			var typeList = CreateTypeList(node.NthElement(1));
			var typeArguments = UnifiedArgumentCollection.Create();

			foreach (var type in typeList) {
				var argument = UnifiedArgument.Create(type);
				typeArguments.Add(argument);
			}
			return typeArguments;
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
				// ()がついているので空集合を返す
				return UnifiedArgumentCollection.Create();

			return CreateExpressionList(expressionListNode)
				.Select(UnifiedArgument.Create)
				.ToCollection();
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

		private static UnifiedBinaryOperator CreateBinaryOperator(string name)
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

		private static UnifiedUnaryOperator CreatePrefixUnaryOperator(string name)
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

		private static UnifiedIf CreateIf(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.FirstElement().Name() == "IF");
			/*  
			 * 'if' parExpression statement ('else' statement)? 
			 */
			var trueBody = CreateStatement(node.Element("statement"))
				.ToBlock();

			UnifiedBlock falseBody = null;
			if (node.Elements("statement").Count() == 2) {
				var falseNode = node.Elements("statement").ElementAt(1);
				falseBody = CreateStatement(falseNode).ToBlock();
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
			Contract.Requires(node.FirstElement().Name() == "WHILE");
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
			Contract.Requires(node.FirstElement().Name() == "DO");
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
			return UnifiedSwitch.Create(
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
				return UnifiedSpecialExpression.CreateBreak(
					UnifiedIdentifier.CreateUnknown(node.Element("IDENTIFIER").Value));
			return UnifiedSpecialExpression.CreateBreak();
		}

		private static UnifiedSpecialExpression CreateContinue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("continue"));
			/* 'continue' (IDENTIFIER)? ';' */
			if (node.Elements().Count() > 2)
				return UnifiedSpecialExpression.CreateContinue(
					UnifiedIdentifier.CreateUnknown(node.Element("IDENTIFIER").Value));
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
			return UnifiedSpecialExpression.CreateThrow(
					CreateExpression(node.Element("expression")));
		}
	}
}