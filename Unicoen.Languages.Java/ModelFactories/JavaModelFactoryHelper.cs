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
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;
using Unicoen.Core.ModelFactories;

namespace Unicoen.Languages.Java.ModelFactories {
	public static class JavaModelFactoryHelper {
		public static Dictionary<string, UnifiedBinaryOperator> Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static JavaModelFactoryHelper() {
			Sign2BinaryOperator =
					ModelFactoryHelper.CreateBinaryOperatorDictionary();
			Sign2PrefixUnaryOperator =
					ModelFactoryHelper.CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static UnifiedProgram CreateCompilationUnit(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compilationUnit");
			/*
			 * compilationUnit 
			 * :   ( (annotations)? packageDeclaration )? (importDeclaration)* (typeDeclaration)*
			 */
			var program = UnifiedProgram.Create();
			IUnifiedElementCollection<IUnifiedExpression> expressions = program;

			if (node.FirstElement().Name() == "annotations") {
				var annotations = CreateAnnotations(node.FirstElement());
				var packageDeclaration = CreatePackageDeclaration(node.NthElement(1));
				packageDeclaration.Annotations = annotations;
				expressions.Add(packageDeclaration);
				expressions = packageDeclaration.Body;
			}
			foreach (var e in node.Elements("importDeclaration")) {
				var importDeclaration = CreateImportDeclaration(e);
				expressions.Add(importDeclaration);
			}
			foreach (var e in node.Elements("typeDeclaration")) {
				var typeDeclaration = CreateTypeDeclaration(e);
				expressions.AddRange(typeDeclaration);
			}
			return program;
		}

		public static UnifiedClassDefinition CreatePackageDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "packageDeclaration");
			/*
			 * packageDeclaration 
			 * :   'package' qualifiedName ';'
			 */
			var name = CreateQualifiedName(node.Element("qualifiedName"));
			return UnifiedClassDefinition.CreateNamespace(name);
		}

		public static UnifiedImport CreateImportDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "importDeclaration");
			/*
			 * importDeclaration  
			 * :   'import' ('static')? IDENTIFIER '.' '*' ';'
			 * |   'import' ('static')? IDENTIFIER ('.' IDENTIFIER)+ ('.' '*')? ';' 
			 */
			var idStrs = node.Elements("IDENTIFIER").Select(e => e.Value);
			if (node.HasElementByContent("*"))
				idStrs = idStrs.Concat("*");

			// TODO CreateUnknownより詳しい情報を
			var name = idStrs.Select(UnifiedIdentifier.CreateUnknown).ToProperty(".");
			var modifiers = node.HasElementByContent("static")
			                		? UnifiedModifier.Create(node.NthElement(1).Value).
			                		  		ToCollection()
			                		: null;

			return UnifiedImport.Create(name, modifiers);
		}

		public static IEnumerable<UnifiedClassDefinition> CreateTypeDeclaration(
				XElement node) {
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
				XElement node) {
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

		public static Tuple<UnifiedAnnotationCollection, UnifiedModifierCollection>
				CreateModifiers(XElement node) {
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
			var annotations = UnifiedAnnotationCollection.Create();
			var modifiers = UnifiedModifierCollection.Create();
			foreach (var e in node.Elements()) {
				if (e.Name() == "annotation") {
					annotations.Add(CreateAnnotation(e));
				} else {
					modifiers.Add(UnifiedModifier.Create(e.Value));
				}
			}
			return Tuple.Create(annotations, modifiers);
		}

		public static Tuple<UnifiedAnnotationCollection, UnifiedModifierCollection>
				CreateVariableModifiers(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableModifiers");
			/*
			 * variableModifiers 
			 * :   ( 'final' | annotation )* 
			 */
			var annotations = UnifiedAnnotationCollection.Create();
			var modifiers = UnifiedModifierCollection.Create();
			foreach (var e in node.Elements()) {
				if (e.Name() == "annotation") {
					annotations.Add(CreateAnnotation(e));
				} else {
					modifiers.Add(UnifiedModifier.Create(e.Value));
				}
			}
			return Tuple.Create(annotations, modifiers);
		}

		public static UnifiedClassDefinition CreateClassDeclaration(XElement node) {
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

		public static UnifiedClassDefinition CreateNormalClassDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalClassDeclaration");
			/*
			 * normalClassDeclaration 
			 * :   modifiers 'class' IDENTIFIER (typeParameters)? ('extends' type)? ('implements' typeList)? classBody 
			 */
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
			var name = node.Element("IDENTIFIER").Value;
			var typeParameters = node.HasElement("typeParameters")
			                     		? CreateTypeParameters(node.Element("typeParameters"))
			                     		: null;
			var constrains = UnifiedTypeConstrainCollection.Create();
			if (node.HasElement("type")) {
				constrains.Add(
						UnifiedTypeConstrain.CreateExtends(
								CreateType(node.Element("type"))));
			}
			if (node.HasElement("typeList")) {
				foreach (var type in CreateTypeList(node.Element("typeList"))) {
					constrains.Add(UnifiedTypeConstrain.CreateImplements(type));
				}
			}
			var body = CreateClassBody(node.Element("classBody"));
			return UnifiedClassDefinition.CreateClass(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					name,
					typeParameters, constrains, body);
		}

		public static UnifiedTypeParameterCollection CreateTypeParameters(
				XElement node) {
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

		public static UnifiedTypeParameter CreateTypeParameter(XElement node) {
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
									.Select(UnifiedTypeConstrain.CreateExtendsOrImplements))
					);
		}

		public static IEnumerable<UnifiedType> CreateTypeBound(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeBound");
			/*
			 * typeBound 
			 * :   type ('&' type)* 
			 */
			return node.Elements("type").Select(CreateType);
		}

		public static UnifiedClassDefinition CreateEnumDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumDeclaration");
			/*
			 * enumDeclaration 
			 * :   modifiers ('enum') IDENTIFIER ('implements' typeList)? enumBody 
			 */
			var annotationsAndModifiers = CreateModifiers(node.FirstElement());
			var name = node.NthElement(2).Value;
			var typeListNode = node.Element("typeList");
			var constrains = typeListNode != null
			                 		? CreateTypeList(typeListNode)
			                 		  		.Select(UnifiedTypeConstrain.CreateImplements)
			                 		  		.ToCollection()
			                 		: null;
			var enumBody = CreateEnumBody(node.Element("enumBody"));
			return UnifiedClassDefinition.Create(
					UnifiedClassKind.Enum,
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					UnifiedIdentifier.CreateType(name),
					null,
					constrains,
					enumBody);
		}

		public static UnifiedBlock CreateEnumBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBody");
			/*
			 * enumBody 
			 * :   '{' (enumConstants)? ','? (enumBodyDeclarations)? '}' 
			 */
			var block = UnifiedBlock.Create();
			var enumConstantsNode = node.Element("enumConstants");
			if (enumConstantsNode != null)
				block.Add(CreateEnumConstants(enumConstantsNode));
			var enumBodyDeclarationsNode = node.Element("enumBodyDeclarations");
			if (enumBodyDeclarationsNode != null)
				block.AddRange(CreateEnumBodyDeclarations(enumBodyDeclarationsNode));
			return block;
		}

		public static UnifiedVariableDefinitionList CreateEnumConstants(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstants");
			/*
			 * enumConstants 
			 * :   enumConstant (',' enumConstant)* 
			 */
			return node.Elements("enumConstant")
					.Select(CreateEnumConstant)
					.Select(
							t =>
							DeprecatedUnifiedVariableDefinition.Create(
									t.Item1, null, null, t.Item2.ToCollection()))
					.ToCollection();
		}

		public static
				Tuple<UnifiedAnnotationCollection, DeprecatedUnifiedVariableDefinitionBody>
				CreateEnumConstant(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumConstant");
			/*
			 * enumConstant 
			 * :   (annotations)? IDENTIFIER (arguments)? (classBody)?
			 */
			var annotationsNode = node.Element("annotations");
			var argumentsNode = node.Element("arguments");
			var classBodyNode = node.Element("classBody");
			var annotations = annotationsNode != null
			                  		? CreateAnnotations(annotationsNode)
			                  		: null;
			var name = node.ElementByContent().Value;
			var arguments = argumentsNode != null
			                		? CreateArguments(argumentsNode)
			                		: null;
			var body = classBodyNode != null
			           		? CreateClassBody(classBodyNode)
			           		: null;
			return Tuple.Create(
					annotations, DeprecatedUnifiedVariableDefinitionBody.Create(
							UnifiedIdentifier.CreateVariable(name),
							null,
							null,
							arguments,
							body));
		}

		public static IEnumerable<IUnifiedExpression> CreateEnumBodyDeclarations(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumBodyDeclarations");
			/*
			 * enumBodyDeclarations 
			 * :   ';' (classBodyDeclaration)* 
			 */
			return node.Elements("classBodyDeclaration")
					.SelectMany(CreateClassBodyDeclaration);
		}

		public static UnifiedClassDefinition CreateInterfaceDeclaration(XElement node) {
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
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalInterfaceDeclaration");
			/*
			 * normalInterfaceDeclaration 
			 * :   modifiers 'interface' IDENTIFIER (typeParameters)? ('extends' typeList)? interfaceBody 
			 */
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
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

			return UnifiedClassDefinition.Create(
					UnifiedClassKind.Interface,
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					name,
					typeParameters,
					constrains,
					body);
		}

		public static IEnumerable<UnifiedType> CreateTypeList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typeList");
			/*
			 * typeList 
			 * :   type (',' type)* 
			 */
			return node.Elements("type")
					.Select(CreateType);
		}

		public static UnifiedBlock CreateClassBody(XElement node) {
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

		public static UnifiedBlock CreateInterfaceBody(XElement node) {
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

		public static IEnumerable<IUnifiedExpression> CreateClassBodyDeclaration(
				XElement node) {
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
						UnifiedConstructorDefinitionKind.StaticInitializer);
			}
			if (node.HasElement("memberDecl")) {
				yield return CreateMemberDecl(node.Element("memberDecl"));
			}
		}

		public static IUnifiedExpression CreateMemberDecl(XElement node) {
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

		public static IUnifiedExpression CreateMethodDeclaration(XElement node) {
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

			var name = UnifiedIdentifier.CreateFunction(
					node.Element("IDENTIFIER").Value);
			var typeParameters = node.HasElement("typeParameters")
			                     		? CreateTypeParameters(node.Element("typeParameters"))
			                     		: null;
			var type = CreateType(node.Element("type")); //コンストラクタの場合はnullになるがどうせ使わない
			var dimension = node.ElementsByContent("[").Count();
			for (var i = 0; i < dimension; i++)
				type.AddSupplement(UnifiedTypeSupplement.CreateArray());
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
			var parameters = CreateFormalParameters(node.Element("formalParameters"));
			var throws = node.HasElement("qualifiedNameList")
			             		? CreateQualifiedNameList(node.Element("qualifiedNameList"))
			             		  		.Select(e => UnifiedType.Create(e, null, null))
			             		  		.ToCollection()
			             		: null;
			var body = node.HasElement("block")
			           		? CreateBlock(node.Element("block")) : null;

			if (!node.HasElement("type") && !node.HasElementByContent("void")) {
				//case constructor
				var invocationNode =
						node.Element("explicitConstructorInvocation");
				var invocations = invocationNode != null
				                  		? Enumerable.Repeat(
				                  				CreateExplicitConstructorInvocation(
				                  						invocationNode), 1)
				                  		: Enumerable.Empty<IUnifiedExpression>();
				var block =
						invocations.Concat(
								node.Elements("blockStatement")
										.SelectMany(CreateBlockStatement)
								)
								.ToBlock();

				return UnifiedConstructorDefinition.Create(
						block,
						annotationsAndModifiers.Item1,
						annotationsAndModifiers.Item2,
						parameters,
						typeParameters,
						throws,
						UnifiedConstructorDefinitionKind.Constructor);
			}
			return UnifiedFunctionDefinition.Create(
					UnifiedFunctionDefinitionKind.Function,
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					type,
					typeParameters,
					name,
					parameters,
					throws,
					body);
		}

		public static DeprecatedUnifiedVariableDefinition CreateFieldDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fieldDeclaration");
			/*
			 * fieldDeclaration 
			 * :   modifiers type variableDeclarator (',' variableDeclarator)* ';' 
			 */
			var bodys = node.Elements("variableDeclarator")
					.Select(CreateVariableDeclarator)
					.ToCollection();
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
			return DeprecatedUnifiedVariableDefinition.Create(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					CreateType(node.Element("type")),
					bodys);
		}

		public static DeprecatedUnifiedVariableDefinitionBody CreateVariableDeclarator
				(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "variableDeclarator");
			/*
			 * variableDeclarator 
			 * :   IDENTIFIER ('[' ']')* ('=' variableInitializer)? 
			 */
			var initializer = node.HasElement("variableInitializer")
			                  		? CreateVariableInitializer(
			                  				node.Element("variableInitializer"))
			                  		: null;
			var dimension = node.ElementsByContent("[").Count();
			var supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);
			return DeprecatedUnifiedVariableDefinitionBody.Create(
					node.Element("IDENTIFIER").Value, supplements, initializer);
		}

		public static IEnumerable<IUnifiedExpression> CreateInterfaceBodyDeclaration(
				XElement node) {
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
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceMethodDeclaration");
			/*
			 * interfaceMethodDeclaration 
			 * :   modifiers (typeParameters)? (type |'void') IDENTIFIER formalParameters
				   ('[' ']')* ('throws' qualifiedNameList)? ';' 
			 */
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
			var typeParameters = node.HasElement("typeParameters")
			                     		? CreateTypeParameters(node.Element("typeParameters"))
			                     		: null;
			var type = CreateType(node.Element("type"));
			var dimension = node.ElementsByContent("[").Count();
			for (var i = 0; i < dimension; i++)
				type.AddSupplement(UnifiedTypeSupplement.CreateArray());
			var name = UnifiedIdentifier.CreateFunction(
					node.Element("IDENTIFIER").Value);
			var parameters = CreateFormalParameters(node.Element("formalParameters"));

			var throws = node.HasElement("qualifiedNameList")
			             		? UnifiedTypeCollection.Create(
			             				CreateQualifiedNameList(node.Element("qualifiedNameList"))
			             						.Select(e => UnifiedType.Create(e, null, null)))
			             		: null;

			return UnifiedFunctionDefinition.Create(
					UnifiedFunctionDefinitionKind.Function,
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					type,
					typeParameters,
					name,
					parameters,
					throws,
					null);
		}

		public static DeprecatedUnifiedVariableDefinition
				CreateInterfaceFieldDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "interfaceFieldDeclaration");
			/* 
			 * interfaceFieldDeclaration 
			 * :   modifiers type variableDeclarator (',' variableDeclarator)* ';' 
			 */
			var bodys = node.Elements("variableDeclarator")
					.Select(CreateVariableDeclarator)
					.ToCollection();
			var annotationsAndModifiers = CreateModifiers(node.Element("modifiers"));
			return DeprecatedUnifiedVariableDefinition.Create(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					CreateType(node.Element("type")),
					bodys);
		}

		public static UnifiedType CreateType(XElement node) {
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
			for (var i = 0; i < dimension; i++)
				type.AddSupplement(UnifiedTypeSupplement.CreateArray());
			return type;
		}

		public static UnifiedType CreateClassOrInterfaceType(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classOrInterfaceType");
			/*
			 * classOrInterfaceType 
			 * :   IDENTIFIER (typeArguments)? ('.' IDENTIFIER (typeArguments)? )* 
			 */

			var innerTypes = node.Elements("IDENTIFIER")
					.Select(
							e => {
								var typeArgumentsNode = e.NextElementOrDefault();
								var typeArguments = typeArgumentsNode != null &&
								                    typeArgumentsNode.Name() == "typeArguments"
								                    		? CreateTypeArguments(typeArgumentsNode)
								                    		: null;
								return UnifiedType.Create(
										UnifiedIdentifier.CreateType(e.Value),
										typeArguments,
										null);
							}).ToList();
			if (innerTypes.Count == 1)
				return innerTypes[0];
			var lastType = innerTypes[innerTypes.Count - 1];
			var lastArguments = lastType.Arguments;
			lastType.Arguments.Remove();
			return UnifiedType.Create(innerTypes.ToProperty("."), lastArguments, null);
		}

		public static UnifiedType CreatePrimitiveType(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primitiveType");
			/* 
			 * primitiveType  
			 * :   'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' 
			 */
			return UnifiedType.CreateUsingString(node.Value);
		}

		public static UnifiedTypeArgumentCollection CreateTypeArguments(XElement node) {
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

		public static UnifiedTypeArgument CreateTypeArgument(XElement node) {
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
				if (node.NthElement(1).Value == "extends") {
					constrains = UnifiedTypeConstrain.Create(
							CreateType(node.Element("type")),
							UnifiedTypeConstrainKind.Extends);
				} else {
					constrains = UnifiedTypeConstrain.Create(
							CreateType(node.Element("type")),
							UnifiedTypeConstrainKind.Super);
				}
			}
			return UnifiedTypeArgument.Create(type, null, constrains.ToCollection());
		}

		public static IEnumerable<IUnifiedExpression> CreateQualifiedNameList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedNameList");
			/* 
			 * qualifiedNameList 
			 * :   qualifiedName (',' qualifiedName)* 
			 */
			return node.Elements("qualifiedName").Select(CreateQualifiedName);
		}

		public static UnifiedParameterCollection CreateFormalParameters(XElement node) {
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
				XElement node) {
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
					.Select(
							e => e.Name() == "normalParameterDecl"
							     		? CreateNormalParameterDecl(e)
							     		: CreateEllipsisParameterDecl(e))
					.ToCollection();
		}

		public static UnifiedParameter CreateNormalParameterDecl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "normalParameterDecl");
			/*
			 * normalParameterDecl 
			 * :   variableModifiers type IDENTIFIER ('[' ']')*
			 */
			var annotationsAndModifiers =
					CreateVariableModifiers(node.Element("variableModifiers"));
			var type = CreateType(node.Element("type"));
			var dimension = node.ElementsByContent("[").Count();
			for (var i = 0; i < dimension; i++)
				type.AddSupplement(UnifiedTypeSupplement.CreateArray());
			return UnifiedParameter.Create(
					annotationsAndModifiers.Item1, annotationsAndModifiers.Item2, type,
					node.Element("IDENTIFIER").Value);
		}

		public static UnifiedParameter CreateEllipsisParameterDecl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "ellipsisParameterDecl");
			/*
			 * ellipsisParameterDecl  
			 * :   variableModifiers type '...' IDENTIFIER 
			 */
			var annotationsAndModifiers =
					CreateVariableModifiers(node.Element("variableModifiers"));
			annotationsAndModifiers.Item2.Add(UnifiedModifier.Create("..."));
			var type = CreateType(node.Element("type"));
			return UnifiedParameter.Create(
					annotationsAndModifiers.Item1, annotationsAndModifiers.Item2, type,
					node.Element("IDENTIFIER").Value);
		}

		public static IUnifiedExpression CreateExplicitConstructorInvocation(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "explicitConstructorInvocation");
			/*
			 * explicitConstructorInvocation 
			 * :   (nonWildcardTypeArguments)? ('this'|'super') arguments ';'
			 * |   primary '.' (nonWildcardTypeArguments)? 'super' arguments ';' 
			 */

			var aruguments = CreateArguments(node.Element("arguments"));
			var typeArguments = node.HasElement("nonWildcardTypeArguments")
			                    		? CreateNonWildcardTypeArguments(
			                    				node.Element("nonWildcardTypeArguments")) : null;

			if (node.FirstElement().Name() == "primary") {
				var prop = UnifiedProperty.Create(
						CreatePrimary(node.Element("primary")),
						UnifiedIdentifier.CreateSuper("super"), ".");
				return UnifiedCall.Create(prop, aruguments, typeArguments);
			}

			var target = node.FirstElement().Value == "this"
			             		? UnifiedIdentifier.CreateThis("this")
			             		: UnifiedIdentifier.CreateSuper("super");
			return UnifiedCall.Create(target, aruguments, typeArguments);
		}

		public static IUnifiedExpression CreateQualifiedName(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "qualifiedName");
			/*
			 * qualifiedName 
			 * :   IDENTIFIER ('.' IDENTIFIER)* 
			 */
			var ids = node.Elements()
					.OddIndexElements()
					.Select(e => UnifiedIdentifier.CreateUnknown(e.Value));
			return ids.ToProperty(".");
		}

		public static UnifiedAnnotationCollection CreateAnnotations(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotations");
			/*
			 * annotations 
			 * :   (annotation)+ 
			 */
			return node.Elements().Select(CreateAnnotation).ToCollection();
		}

		public static UnifiedAnnotation CreateAnnotation(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotation");
			/* 
			 * annotation 
			 * :   '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )? 
			 */
			var elementNode = node.NthElementOrDefault(3);
			return UnifiedAnnotation.Create(
					UnifiedType.Create(CreateQualifiedName(node.NthElement(1))),
					elementNode != null
							? elementNode.Name() == "elementValuePairs"
							  		? CreateElementValuePairs(elementNode)
							  		: CreateElementValue(elementNode).ToArgument().ToCollection()
							: null
					);
		}

		public static UnifiedArgumentCollection CreateElementValuePairs(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePairs");
			/*
			 * elementValuePairs 
			 * :   elementValuePair (',' elementValuePair)* 
			 */
			return
					node.Elements().OddIndexElements().Select(CreateElementValuePair).
							ToCollection();
		}

		public static UnifiedArgument CreateElementValuePair(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValuePair");
			/*
			 * elementValuePair 
			 * :   IDENTIFIER '=' elementValue 
			 */
			return UnifiedArgument.Create(
					null, UnifiedIdentifier.CreateVariable(node.FirstElement().Value),
					CreateElementValue(node.LastElement()));
		}

		public static IUnifiedExpression CreateElementValue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValue");
			/* 
			 * elementValue 
			 * :   conditionalExpression
			 * |   annotation
			 * |   elementValueArrayInitializer 
			 */
			var first = node.FirstElement();
			switch (node.Name()) {
			case "conditionalExpression":
				return CreateConditionalExpression(first);
			case "annotation":
				return CreateAnnotation(first);
			case "elementValueArrayInitializer":
				return CreateElementValueArrayInitializer(first);
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static IUnifiedExpression CreateElementValueArrayInitializer(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "elementValueArrayInitializer");
			/*
			 * elementValueArrayInitializer 
			 * :   '{' (elementValue ( ',' elementValue)* )? (',')? '}' 
			 */
			return UnifiedList.CreateArray(
					node.Elements("elementValue").Select(CreateElementValue).ToCollection());
		}

		public static UnifiedClassDefinition CreateAnnotationTypeDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeDeclaration");
			/*
			 * annotationTypeDeclaration 
			 * :   modifiers '@' 'interface' IDENTIFIER annotationTypeBody 
			 */
			var annotationsAndModifiers = CreateModifiers(node.FirstElement());
			return UnifiedClassDefinition.CreateAnnotation(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					UnifiedIdentifier.CreateType(node.NthElement(3).Value),
					CreateAnnotationTypeBody(node.LastElement())
					);
		}

		public static UnifiedBlock CreateAnnotationTypeBody(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationTypeBody");
			/* 
			 * annotationTypeBody 
			 * :   '{' (annotationTypeElementDeclaration)* '}' 
			 */

			throw new NotImplementedException();
		}

		public static IEnumerable<IUnifiedExpression>
				CreateAnnotationTypeElementDeclaration(
				XElement node) {
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
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "annotationMethodDeclaration");
			/*
			 * annotationMethodDeclaration 
			 * :   modifiers type IDENTIFIER '(' ')' ('default' elementValue)? ';' 
			 */

			throw new NotImplementedException();
		}

		public static UnifiedBlock CreateBlock(XElement node) {
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

		public static IEnumerable<IUnifiedExpression> CreateBlockStatement(
				XElement node) {
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

		public static DeprecatedUnifiedVariableDefinition
				CreateLocalVariableDeclarationStatement(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclarationStatement");
			/*
			 * localVariableDeclarationStatement 
			 * :   localVariableDeclaration ';' 
			 */
			return CreateLocalVariableDeclaration(node.FirstElement());
		}

		public static DeprecatedUnifiedVariableDefinition
				CreateLocalVariableDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "localVariableDeclaration");
			/*
			 * localVariableDeclaration 
			 * :   variableModifiers type variableDeclarator (',' variableDeclarator )* 
			 */
			var bodys = node.Elements("variableDeclarator")
					.Select(CreateVariableDeclarator)
					.ToCollection();
			var annotationsAndModifiers =
					CreateVariableModifiers(node.Element("variableModifiers"));
			return DeprecatedUnifiedVariableDefinition.Create(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					CreateType(node.Element("type")),
					bodys);
		}

		public static IEnumerable<IUnifiedExpression> CreateStatement(XElement node) {
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
				yield return UnifiedLabel.Create(first.Value);
				foreach (var stmt in CreateStatement(node.LastElement())) {
					yield return stmt;
				}
				yield break;
			}
			switch (first.Value) {
			case "assert":
				// TODO assert
				yield return UnifiedSpecialExpression.Create(
						UnifiedSpecialExpressionKind.Assert,
						node.Elements("expression").Select(CreateExpression).ToExpressionList());
				break;
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
				XElement node) {
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

		public static UnifiedCase CreateSwitchBlockStatementGroup(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "switchBlockStatementGroup");
			/*
			 * switchBlockStatementGroup 
			 * :   switchLabel (blockStatement)* 
			 */
			var body = node.Elements("blockStatement")
					.SelectMany(CreateBlockStatement)
					.ToBlock();
			return UnifiedCase.Create(
					CreateSwitchLabel(node.Element("switchLabel")),
					body);
		}

		public static IUnifiedExpression CreateSwitchLabel(XElement node) {
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

		public static UnifiedTry CreateTrystatement(XElement node) {
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

		public static UnifiedCatchCollection CreateCatches(XElement node) {
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

		public static UnifiedCatch CreateCatchClause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "catchClause");
			/*
			 * catchClause 
			 * :   'catch' '(' formalParameter ')' block  
			 */
			return UnifiedCatch.Create(
					CreateFormalParameter(node.Element("formalParameter")).ToCollection(),
					CreateBlock(node.Element("block")));
		}

		public static UnifiedMatcher CreateFormalParameter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "formalParameter");
			/*
			 * formalParameter 
			 * :   variableModifiers type IDENTIFIER ('[' ']')* 
			 */

			var type = CreateType(node.NthElement(1));
			var dimension = node.ElementsByContent("[").Count();
			for (int i = 0; i < dimension; i++) {
				type.AddSupplement(UnifiedTypeSupplement.CreateArray());
			}
			var annotationsAndModifiers = CreateVariableModifiers(node.FirstElement());
			return UnifiedMatcher.Create(
					annotationsAndModifiers.Item1,
					annotationsAndModifiers.Item2,
					type,
					UnifiedIdentifier.CreateVariable(node.NthElement(2).Value));
		}

		public static IUnifiedExpression CreateForstatement(XElement node) {
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
				var annotationsAndModifiers =
						CreateVariableModifiers(node.Element("variableModifiers"));
				return UnifiedForeach.Create(
						DeprecatedUnifiedVariableDefinition.CreateSingle(
								annotationsAndModifiers.Item1,
								annotationsAndModifiers.Item2,
								CreateType(node.Element("type")),
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

		public static IUnifiedExpression CreateForInit(XElement node) {
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

		public static IUnifiedExpression CreateParExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parExpression");
			/*
			 * parExpression 
			 * :   '(' expression ')' 
			 */

			return CreateExpression(node.NthElement(1));
		}

		public static IEnumerable<IUnifiedExpression> CreateExpressionList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expressionList");
			/*
			 * expressionList : expression (',' expression )* ;
			 */

			return node.Elements("expression").Select(CreateExpression);
		}

		public static IUnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression 
			 * :   conditionalExpression (assignmentOperator expression)? 
			 */

			return ModelFactoryHelper.CreateBinaryExpressionForRightAssociation(
					node, CreateConditionalExpression, CreateExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateConditionalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalExpression");
			/*
			 * conditionalExpression 
			 * :   conditionalOrExpression ('?' expression ':' conditionalExpression)?
			 */

			if (node.HasElement("expression")) {
				return UnifiedTernaryExpression.Create(
						CreateConditionalOrExpression(node.NthElement(0)),
						CreateExpression(node.NthElement(2)),
						CreateConditionalExpression(node.NthElement(4))
						);
			}
			return CreateConditionalOrExpression(node.FirstElement());
		}

		public static IUnifiedExpression CreateConditionalOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalOrExpression");
			/*
			 * conditionalOrExpression 
			 * :   conditionalAndExpression ('||' conditionalAndExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateConditionalAndExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateConditionalAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditionalAndExpression");
			/*
			 * conditionalAndExpression 
			 * :   inclusiveOrExpression ('&&' inclusiveOrExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateInclusiveOrExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateInclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusiveOrExpression");
			/* 
			 * inclusiveOrExpression 
			 * :   exclusiveOrExpression ('|' exclusiveOrExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateExclusiveOrExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateExclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusiveOrExpression");
			/*
			 * exclusiveOrExpression 
			 * :   andExpression ('^' andExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateAndExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "andExpression");
			/*
			 * andExpression 
			 * :   equalityExpression ('&' equalityExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateEqualityExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateEqualityExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equalityExpression");
			/*
			 * equalityExpression 
			 * :   instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateInstanceOfExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateInstanceOfExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "instanceOfExpression");
			/*
			 * instanceOfExpression 
			 * :   relationalExpression ('instanceof' type)?
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateRelationalExpression, CreateType, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateRelationalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relationalExpression");
			/*
			 * relationalExpression 
			 * :   shiftExpression (relationalOp shiftExpression)* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateShiftExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateShiftExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shiftExpression");
			/*
			 * shiftExpression 
			 * :   additiveExpression (shiftOp additiveExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateAdditiveExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateAdditiveExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additiveExpression");
			/*
			 * additiveExpression 
			 * :   multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* 
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateMultiplicativeExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateMultiplicativeExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicativeExpression");
			/*
			 * multiplicativeExpression 
			 * :   unaryExpression ( ( '*' | '/' | '%' ) unaryExpression)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateUnaryExpression, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node) {
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
			return ModelFactoryHelper.CreatePrefixUnaryExpression(
					node, CreateUnaryExpression, Sign2PrefixUnaryOperator);
		}

		public static IUnifiedExpression CreateUnaryExpressionNotPlusMinus(
				XElement node) {
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
					result = UnifiedUnaryExpression.Create(
							result,
							UnifiedUnaryOperator.Create(
									ope,
									ope == "++" ? UnifiedUnaryOperatorKind.PostIncrementAssign
											: UnifiedUnaryOperatorKind.PostDecrementAssign));
				}
				return result;
			}
			return ModelFactoryHelper.CreatePrefixUnaryExpression(
					node, CreateUnaryExpression, Sign2PrefixUnaryOperator);
		}

		public static UnifiedCast CreateCastExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "castExpression");
			/*
			 * castExpression 
			 * :   '(' primitiveType ')' unaryExpression
			 * |   '(' type ')' unaryExpressionNotPlusMinus 
			 */
			if (node.LastElement().Name() == "unaryExpression") {
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

		public static IUnifiedExpression CreatePrimary(XElement node) {
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
			if (first.Name() == "parExpression") {
				return CreateParExpression(first);
			}
			if (first.HasContent("this") || first.Name() == "IDENTIFIER") {
				var prefix = node.Elements()
						.OddIndexElements()
						.Select(e => e.Value);
				var identifierSuffixNode = node.Element("identifierSuffix");

				var prefixProp = prefix.Select(UnifiedIdentifier.CreateUnknown)
						.ToProperty(".");

				var id = prefix.Select(UnifiedIdentifier.CreateUnknown).ToProperty(".");
				var type = UnifiedType.Create(id, null, null);
				return identifierSuffixNode == null
				       		? prefixProp
				       		: CreateIdentifierSuffix(prefixProp, type, identifierSuffixNode);
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
				return UnifiedProperty.Create(
						UnifiedType.CreateUsingString(type), "class",
						".");
			}
			if (first.HasContent("void")) {
				return UnifiedProperty.Create(
						UnifiedIdentifier.CreateUnknown(first.Value),
						"class", ".");
			}
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateSuperSuffix(
				IUnifiedExpression prefix,
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "superSuffix");
			/*
			 * superSuffix  
			 * :   arguments
			 * |   '.' (typeArguments)? IDENTIFIER (arguments)?
			 */
			if (node.FirstElement().Name == "arguments") {
				// super(arg1, arg2)
				return UnifiedCall.Create(prefix, CreateArguments(node.FirstElement()));
			}
			var typeArgumentsNode = node.Element("typeArguments");
			var typeArguments = typeArgumentsNode != null
			                    		? CreateTypeArguments(typeArgumentsNode)
			                    		: null;
			var argumentsNode = node.Element("arguments");
			var arguments = argumentsNode != null
			                		? CreateArguments(argumentsNode)
			                		: null;
			var property = UnifiedProperty.Create(
					prefix,
					node.Element("IDENTIFIER").Value, ".");
			if (arguments != null) {
				// super.<Integer>method(arg1)
				return UnifiedCall.Create(property, arguments, typeArguments);
			}
			// super.field1
			return property;
		}

		public static IUnifiedExpression CreateIdentifierSuffix(
				IUnifiedExpression prefixProp, UnifiedType prefixType, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "identifierSuffix");
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

			var second = node.NthElementOrDefault(1);
			// ('[' expression ']' )+	// strs[10]
			if (second != null && second.Name() == "expression") {
				return node.Elements("expression")
						.Select(CreateExpression)
						.Aggregate(
								prefixProp, (current, exp) =>
								            UnifiedIndexer.Create(
								            		current,
								            		UnifiedArgumentCollection.Create(
								            				UnifiedArgument.Create(exp)))
						);
			}
			// arguments				// func(1, 2)
			if (node.FirstElement().Name() == "arguments") {
				return UnifiedCall.Create(prefixProp, CreateArguments(node.FirstElement()));
			}
			// innerCreator				// new Outer().new <Integer> Inner<String>(1);
			if (node.FirstElement().Name() == "innerCreator") {
				return CreateInnerCreator(prefixProp, node.Element("innerCreator"));
			}
			// '.' 'class'				// java.lang.String.class
			if (second.Value == "class") {
				return UnifiedProperty.Create(
						prefixType,
						UnifiedIdentifier.CreateClassObject("class"), ".");
			}
			// ('[' ']')+ '.' 'class'	// java.lang.String[].class
			if (node.LastElement().Value == "class") {
				var d = node.ElementsByContent("[").Count();
				var suplpements = UnifiedTypeSupplementCollection.CreateArray(d);
				prefixType.Supplements = suplpements;
				return UnifiedProperty.Create(
						prefixType,
						UnifiedIdentifier.CreateClassObject("class"), ".");
			}
			// '.' nonWildcardTypeArguments IDENTIFIER arguments
			if (second.Name() == "nonWildcardTypeArguments") {
				var prop = UnifiedProperty.Create(
						prefixProp,
						UnifiedIdentifier.CreateUnknown(
								node.Element("IDENTIFIER").Value), ".");
				return UnifiedCall.Create(
						prop, CreateArguments(node.Element("arguments")),
						CreateNonWildcardTypeArguments(node.Element("nonWildcardTypeArguments")));
			}
			// '.' 'this'				// Outer.this
			if (second.Value == "this") {
				return UnifiedProperty.Create(
						prefixType,
						UnifiedIdentifier.CreateThis("this"), ".");
			}
			// '.' 'super' arguments	// new Outer().super();
			if (second.Value == "super") {
				var prop = UnifiedProperty.Create(
						prefixProp,
						UnifiedIdentifier.CreateSuper("super"), ".");
				return UnifiedCall.Create(prop, CreateArguments(node.Element("arguments")));
			}

			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateSelector(
				IUnifiedExpression prefix,
				XElement node) {
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
			var secondElement = node.NthElementOrDefault(1);
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
			if (secondElement.Value == "this") {
				return UnifiedProperty.Create(prefix, "this", ".");
			}
			if (secondElement.Value == "super") {
				var prop = UnifiedProperty.Create(
						prefix,
						UnifiedIdentifier.CreateSuper("super"), ".");
				return CreateSuperSuffix(prop, node.Element("superSuffix"));
			}
			if (secondElement.Name() == "expression") {
				return UnifiedIndexer.Create(
						prefix,
						UnifiedArgument.Create(CreateExpression(node.Element("expresion"))).
								ToCollection());
			}

			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateCreator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "creator");
			/*
			 * creator 
			 * :   'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
			 * |   'new' classOrInterfaceType classCreatorRest
			 * |   arrayCreator 
			 */

			//コード例
			//Sample<String> Sample = new <Integer> Sample<String> (1,2){ int z = 0; };

			var first = node.FirstElement();

			if (first.Name() == "arrayCreator") {
				return CreateArrayCreator(first);
			}

			var creatorRest = CreateClassCreatorRest(node.Element("classCreatorRest"));
			if (node.Elements().Count() == 4)
				return UnifiedNew.Create(
						CreateClassOrInterfaceType(node.NthElement(2)) /*Type*/,
						creatorRest.Item1 /*Argument*/,
						CreateNonWildcardTypeArguments(node.Element("nonWildcardTypeArguments"))
						/*TypeArguments*/,
						null /*InitialValue*/,
						creatorRest.Item2 /*Body*/
						);

			return UnifiedNew.Create(
					CreateClassOrInterfaceType(node.NthElement(1)) /*Type*/,
					creatorRest.Item1 /*Argument*/,
					null /*TypeParameters*/,
					null /*InitialValue*/,
					creatorRest.Item2 /*Body*/
					);
		}

		public static UnifiedNew CreateArrayCreator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arrayCreator");
			/*
			 * arrayCreator 
			 * :   'new' createdName '[' ']' ('[' ']')* arrayInitializer
			 * |   'new' createdName '[' expression ']' ( '[' expression ']' )* ('[' ']')* 
			 */

			var type = CreateCreatedName(node.NthElement(1));

			if (node.HasElement("arrayInitializer")) {
				var initVal = CreateArrayInitializer(node.Element("arrayInitializer"));
				var dimension = node.ElementsByContent("[").Count();
				type.Supplements = UnifiedTypeSupplementCollection.CreateArray(dimension);
				return UnifiedNew.Create(type, null, null, initVal, null);
			}

			var supplements = UnifiedTypeSupplementCollection.Create();
			foreach (var exp in node.Elements("expression")) {
				var supplement = UnifiedTypeSupplement.CreateArray(
						CreateExpression(exp).ToArgument());
				supplements.Add(supplement);
			}
			{
				var dimension = node.ElementsByContent("[")
						.Where(e => e.NextElement().Value == "]")
						.Count();
				for (var i = 0; i < dimension; i++)
					supplements.Add(UnifiedTypeSupplement.CreateArray());
			}
			type.Supplements = supplements;
			return UnifiedNew.Create(type);
		}

		public static IUnifiedExpression CreateVariableInitializer(XElement node) {
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

		public static UnifiedExpressionList CreateArrayInitializer(XElement node) {
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

		public static UnifiedType CreateCreatedName(XElement node) {
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

		public static IUnifiedExpression CreateInnerCreator(
				IUnifiedExpression prefix,
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "innerCreator");
			/*
			 * innerCreator  
			 * :   '.' 'new' (nonWildcardTypeArguments)? IDENTIFIER (typeArguments)? classCreatorRest 
			 */

			//コード例
			// X . new <T> Sample <E> (1,2){}

			var typeArguments = node.HasElement("typeArguments")
			                    		? CreateTypeArguments(node.Element("typeArguments"))
			                    		: null;
			var type = UnifiedType.CreateUsingString(
					node.Element("IDENTIFIER").Value,
					typeArguments);
			var creatorRest = CreateClassCreatorRest(node.Element("classCreatorRest"));
			var typeParameters = node.HasElement("nonWildcardTypeArguments")
			                     		? CreateNonWildcardTypeArguments(
			                     				node.Element("nonWildcardTypeArguments")) : null;
			var prop = UnifiedNew.Create(
					type,
					creatorRest.Item1,
					typeParameters,
					null,
					creatorRest.Item2
					);

			return UnifiedProperty.Create(prefix, prop, ".");
		}

		public static Tuple<UnifiedArgumentCollection, UnifiedBlock>
				CreateClassCreatorRest(XElement node) {
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

		public static UnifiedTypeArgumentCollection CreateNonWildcardTypeArguments(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "nonWildcardTypeArguments");
			/*
			 * nonWildcardTypeArguments 
			 * :   '<' typeList '>'
			 */

			var typeList = CreateTypeList(node.NthElement(1));
			var typeArguments = UnifiedTypeArgumentCollection.Create();

			foreach (var type in typeList) {
				var argument = UnifiedTypeArgument.Create(type);
				typeArguments.Add(argument);
			}
			return typeArguments;
		}

		public static UnifiedArgumentCollection CreateArguments(XElement node) {
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

		public static UnifiedLiteral CreateLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "literal");
			/*
			 * literal 
			 * :   intLiteral
			 * |   longLiteral
			 * |   floatLiteral
			 * |   doubleLiteral
			 * |   charLiteral
			 * |   stringLiteral
			 * |   trueLiteral
			 * |   falseLiteral
			 * |   nullLiteral
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "intLiteral":
				return CreateIntLiteral(first);
			case "longLiteral":
				return CreateLongLiteral(first);
			case "floatLiteral":
				return CreateFloatLiteral(first);
			case "doubleLiteral":
				return CreateDoubleLiteral(first);
			case "charLiteral":
				return
						UnifiedStringLiteral.CreateChar(
								first.Value.Substring(1, first.Value.Length - 2));
			case "stringLiteral":
				return
						UnifiedStringLiteral.CreateString(
								first.Value.Substring(1, first.Value.Length - 2));
			case "trueLiteral":
				return UnifiedBooleanLiteral.Create(true);
			case "falseLiteral":
				return UnifiedBooleanLiteral.Create(false);
			case "nullLiteral":
				return UnifiedNullLiteral.Create();
			}
			throw new InvalidOperationException();
		}

		public static UnifiedLiteral CreateIntLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "intLiteral");
			/*
			 * intLiteral
			 * : INTLITERAL
			 * 
			 * INTLITERAL
			 * :   IntegerNumber 
			 */
			return UnifiedIntegerLiteral.CreateInt32(ParseInteger(node.Value));
		}

		public static UnifiedLiteral CreateLongLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "longLiteral");
			/*
			 * LONGLITERAL
			 * :   IntegerNumber LongSuffix
			 * 
			 * fragment
			 * LongSuffix
			 * :   'l' | 'L'
			 */
			var str = node.Value;
			return UnifiedIntegerLiteral.CreateInt64(
					ParseInteger(str.Substring(0, str.Length - 1)));
		}

		private static BigInteger ParseInteger(string value) {
			/*
			 * fragment
			 * IntegerNumber
			 * :   '0' 
			 * |   '1'..'9' ('0'..'9')*    
			 * |   '0' ('0'..'7')+         
			 * |   HexPrefix HexDigit+
			 * 
			 * fragment
			 * HexPrefix
			 * :   '0x' | '0X'
			 */
			BigInteger result = 0;
			if (value != "0") {
				if (value[0] != '0') {
					result = BigInteger.Parse(value);
				} else if (value[1] == 'x' || value[1] == 'X') {
					result = BigInteger.Parse(value.Substring(2), NumberStyles.HexNumber);
				} else {
					result = ParseOcatleNumber(value.Substring(1));
				}
			}
			return result;
		}

		private static BigInteger ParseOcatleNumber(IEnumerable<char> str) {
			return str.Aggregate<char, BigInteger>(
					0,
					(current, ch) => current * 8 + (ch - '0'));
		}

		public static UnifiedLiteral CreateFloatLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "floatLiteral");
			/*
			 *  FLOATLITERAL
			 *  :   NonIntegerNumber FloatSuffix
			 *
			 *  fragment
			 *  FloatSuffix
			 *  :   'f' | 'F'
			 */
			var value = node.Value;
			var d = ParseFraction(value.Substring(0, value.Length - 1));
			return UnifiedFractionLiteral.CreateSingle(d);
		}

		public static UnifiedLiteral CreateDoubleLiteral(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "doubleLiteral");
			/*
			 * fragment
			 * DoubleSuffix
			 * :   'd' | 'D'
			 * 
			 * DOUBLELITERAL
			 * :   NonIntegerNumber DoubleSuffix?
			 */
			var value = node.Value;
			if (value[value.Length - 1] == 'd' || value[value.Length - 1] == 'D')
				value = value.Substring(0, value.Length - 1);
			var d = ParseFraction(value);
			return UnifiedFractionLiteral.CreateDouble(d);
		}

		private static double ParseFraction(string value) {
			/*
			 * fragment
			 * NonIntegerNumber
			 * :   ('0' .. '9')+ '.' ('0' .. '9')* Exponent?	// 0.00e+0
			 * |   '.' ( '0' .. '9' )+ Exponent?				// .01E-0
			 * |   ('0' .. '9')+ Exponent						// 01e5
			 * |   ('0' .. '9')+								// 10
			 * |   HexPrefix (HexDigit )*						// 0x1.Ap+1
			 *     (    () 
			 *     |    ('.' (HexDigit )* ) 
			 *     ) 
			 *     ( 'p' | 'P' ) 
			 *     ( '+' | '-' )? 
			 *     ( '0' .. '9' )+
			 *     
			 * fragment 
			 * Exponent    
			 * :   ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ 
			 */
			if (value.Count() > 1 && (value[1] == 'x' || value[1] == 'X')) {
				return ParseHexFraction(value);
			}
			return double.Parse(value);
		}

		private static double ParseHexFraction(string value) {
			value = value.ToLower();
			var numAndExp = value.Split('p');
			var number = numAndExp[0].Split('.');
			var n = number[0].Aggregate(
					0.0,
					(current, ch) => current * 16.0 +
					                 ch > '9' ? ch - 'a' : ch - '0');
			var f = number[1].Reverse().Aggregate(
					0.0,
					(current, ch) => current / 16.0 +
					                 ch > '9' ? ch - 'a' : ch - '0');
			var result = n + f;
			if (numAndExp[1].Length != 0) {
				var expStr = numAndExp[1];
				var power = 10;
				if (expStr[0] == '-') {
					expStr = expStr.Substring(1);
					power = -10;
				} else if (expStr[0] == '+') {
					expStr = expStr.Substring(1);
				}
				var exp = int.Parse(expStr);
				result *= Math.Pow(power, exp);
			}
			return result;
		}

		private static UnifiedIf CreateIf(XElement node) {
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

		private static UnifiedWhile CreateWhile(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.FirstElement().Name() == "WHILE");
			/* 
			 * 'while' parExpression statement
			 */
			return UnifiedWhile.Create(
					CreateParExpression(node.Element("parExpression")),
					UnifiedBlock.Create(CreateStatement(node.Element("statement"))));
		}

		private static UnifiedDoWhile CreateDoWhile(XElement node) {
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

		private static UnifiedSwitch CreateSwitch(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("switch"));
			/* 
			 * 'switch' parExpression '{' switchBlockStatementGroups '}' 
			 */
			return UnifiedSwitch.Create(
					CreateParExpression(node.Element("parExpression")),
					CreateSwitchBlockStatementGroups(
							node.Element("switchBlockStatementGroups"))
					);
		}

		private static UnifiedSpecialExpression CreateReturn(XElement node) {
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

		private static UnifiedSpecialExpression CreateBreak(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("break"));
			/*
			 * 'break' (IDENTIFIER )? ';'
			 */
			if (node.Elements().Count() > 2)
				return UnifiedSpecialExpression.CreateBreak(
						UnifiedIdentifier.CreateUnknown(node.Element("IDENTIFIER").Value));
			return UnifiedSpecialExpression.CreateBreak();
		}

		private static UnifiedSpecialExpression CreateContinue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("continue"));
			/*
			 * 'continue' (IDENTIFIER)? ';' 
			 */
			if (node.Elements().Count() > 2)
				return UnifiedSpecialExpression.CreateContinue(
						UnifiedIdentifier.CreateUnknown(node.Element("IDENTIFIER").Value));
			return UnifiedSpecialExpression.CreateContinue();
		}

		private static UnifiedSpecialBlock CreateSynchronized(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			Contract.Requires(node.HasElementByContent("synchronized"));
			/* 
			 * 'synchronized' parExpression block 
			 */
			return UnifiedSpecialBlock.Create(
					UnifiedSpecialBlockKind.Synchronized,
					CreateParExpression(node.Element("parExpression")),
					CreateBlock(node.Element("block"))
					);
		}

		private static UnifiedSpecialExpression CreateThrow(XElement node) {
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