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
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
using Paraiba.Xml.Linq;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ProgramGenerators {
	public static partial class CProgramGeneratorHelper {
		public static Dictionary<string, UnifiedBinaryOperator>
				Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static CProgramGeneratorHelper() {
			Sign2BinaryOperator =
					UnifiedProgramGeneratorHelper.CreateBinaryOperatorDictionary
							();
			Sign2PrefixUnaryOperator =
					UnifiedProgramGeneratorHelper.
							CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static UnifiedProgram CreateTranslationUnit(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "translation_unit");
			/*
			 * translation_unit: external_declaration+ ;
			 */
			var program = UnifiedProgram.Create(UnifiedBlock.Create());
			var expressions = program.Body;
			foreach (var e in node.Elements("external_declaration")) {
				expressions.Add(CreateExternalDeclaration(e));
			}

			return program;
		}

		public static UnifiedExpression CreateExternalDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "external_declaration");
			/*
			 * external_declaration 
			 * options {k=1;}
			 * : ( declaration_specifiers? declarator declaration* '{' )=> function_definition
			 * | declaration
			 * ;
			 */
			// 前者が関数宣言のこと、後者がtypedefのこと

			var first = node.FirstElement();
			if (first.Name() == "function_definition") {
				return CreateFunctionDefinition(first);
			}
			if (first.Name() == "declaration") {
				return CreateDeclaration(first);
			}
			throw new InvalidOperationException();
		}

		public static UnifiedFunctionDefinition CreateFunctionDefinition(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "function_definition");
			/* function_definition
			 * :	declaration_specifiers? declarator
			 * (	declaration+ compound_statement	// K&R style
			 *   |	compound_statement				// ANSI style
			 * )
			 */

			UnifiedSet<UnifiedModifier> modifiers = null;
			UnifiedType type = null;
			UnifiedSet<UnifiedGenericParameter> genericParameters = null;
			UnifiedIdentifier name = null;
			UnifiedSet<UnifiedParameter> parameters = null;
			UnifiedBlock body = null;

			var first = node.FirstElement();
			if (first.Name() == "declaration_specifiers") {
				var modifiersAndType = CreateDeclarationSpecifiers(first);
				modifiers = modifiersAndType.Item1;
				type = (UnifiedType)modifiersAndType.Item2;
			}

			var declarator = CreateDeclarator(node.Element("declarator"));
			name = declarator.Item1;
			parameters = declarator.Item2;

			if (node.Elements("declaration").Count() != 0) {
				// TODO declaration+ compound_statement　に該当するケースが未検出
				throw new NotImplementedException();
			}

			body = CreateCompoundStatement(node.Element("compound_statement"));

			return UnifiedFunctionDefinition.Create(
					null, modifiers, type, genericParameters, name, parameters,
					null, body);
		}

		public static UnifiedExpression CreateDeclaration(XElement node) {
			// TODO なぜかここのcontractにひっかかる
			//			Contract.Requires(node != null);
			//			Contract.Requires(node.Name() == "declaration");
			/*
			declaration
			:	'typedef' declaration_specifiers? {$declaration::isTypedef=true;}
				init_declarator_list ';' // special case, looking for typedef	
			| declaration_specifiers init_declarator_list? ';'
			 */

			var firstNode = node.FirstElement();
			switch (firstNode.Name()) {
			case "TOKEN":
				// TODO このケースになるプログラムが未検証
				// typedef int S8; はいいけれど、これに初期化子も付けられるのが謎
				throw new NotImplementedException();
				break;

				// TODO プロトタイプ宣言はどう扱うか決める
			case "declaration_specifiers":
				// const int a = 0;
				// struct data { int x; }; => ここもこれになるのだけど、扱いはどうすれば
				var modifiersAndType = CreateDeclarationSpecifiers(firstNode);
				var modifiers = modifiersAndType.Item1;
				var type = modifiersAndType.Item2; // TODO 返り値をtypeじゃなくす

				var initDeclaratorList = node.Element("init_declarator_list");
				if (initDeclaratorList == null) {
					return type.DeepCopy();
				} else {
					UnifiedVariableDefinitionList variables = null;
					variables = UnifiedVariableDefinitionList.Create(
							CreateInitDeclaratorList(initDeclaratorList).
									Select(
											e =>
											UnifiedVariableDefinition.Create(
													null,
													modifiers.DeepCopy(),
													(UnifiedType)type.DeepCopy(),
													e.Item1, e.Item2)));
					return variables;
				}

			default:
				throw new InvalidOperationException();
			}
		}

		public static Tuple<UnifiedSet<UnifiedModifier>, UnifiedExpression>
				CreateDeclarationSpecifiers(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declaration_specifiers");
			/*	declaration_specifiers
			 * :   ( storage_class_specifier
			 *       |   type_specifier
			 *       |   type_qualifier      )+
			 */
			var modifiers = UnifiedSet<UnifiedModifier>.Create();
			IList<UnifiedType> types = new List<UnifiedType>();
			UnifiedExpression declaration = null;

			foreach (var e in node.Elements()) {
				switch (e.Name()) {
				case "storage_class_specifier":
					modifiers.Add(CreateStorageClassSpecifier(e));
					break;
				case "type_specifier":
					var typeSpecifier = CreateTypeSpecifier(e);
					if (typeSpecifier.GetType().Equals(typeof(UnifiedType))) {
						types.Add((UnifiedType)CreateTypeSpecifier(e));
					} else {
						declaration = typeSpecifier;
					}
					break;
				case "type_qualifier":
					//TODO: const または volatileのことであるが、安直にリストに追加していいか要確認
					modifiers.Add(CreateTypeQualifier(e));
					break;
				default:
					throw new InvalidOperationException();
				}
			}
			// 修飾子が空の場合はnullにする
			if (modifiers.IsEmpty()) {
				modifiers = null;
			}

			if (declaration != null) {
				return Tuple.Create(modifiers, declaration);
			}

			UnifiedExpression type;
			if (types.Count == 1) {
				type = types[0];
			} else {
				var s = "";
				var prefix = "";
				// TODO unsigned int, long long int などは そのまま１つの型で表されるのか？
				foreach (var t in types) {
					s += prefix
						 + ((UnifiedVariableIdentifier)t.BasicTypeName).Name;
					prefix = " ";
				}
				type = UnifiedType.Create(UnifiedVariableIdentifier.Create(s));
			}
			return Tuple.Create(modifiers, type);
		}

		public static IEnumerable<Tuple<UnifiedIdentifier, UnifiedExpression>>
				CreateInitDeclaratorList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "init_declarator_list");
			/*
			init_declarator_list
			: init_declarator (',' init_declarator)*
			*/
			return node.Elements("init_declarator").Select(CreateInitDeclarator);
		}

		public static Tuple<UnifiedIdentifier, UnifiedExpression>
				CreateInitDeclarator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "init_declarator");
			/* init_declarator : declarator ('=' initializer)? ; */

			var declarator = CreateDeclarator(node.Element("declarator"));
			var initializer = node.Element("initializer") != null
									  ? CreateInitializer(
											  node.Element("initializer"))
									  : null;

			return Tuple.Create(declarator.Item1, initializer);
		}

		public static UnifiedModifier CreateStorageClassSpecifier(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "storage_class_specifier");
			/*
			 * storage_class_specifier
			 * : 'extern'
			 * | 'static'
			 * | 'auto'
			 * | 'register'
			 */
			return UnifiedModifier.Create(node.FirstElement().Value);
		}

		public static UnifiedExpression CreateTypeSpecifier(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_specifier");
			/*	type_specifier
			 * : 'void'
			 * | 'char'
			 * | 'short'
			 * | 'int'
			 * | 'long'
			 * | 'float'
			 * | 'double'
			 * | 'signed'
			 * | 'unsigned'
			 * | struct_or_union_specifier
			 * | enum_specifier
			 * | type_id
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "struct_or_union_specifier":
				return CreateStructOrUnionSpecifier(first);
			case "enum_specifier":
				return CreateEnumSpecifier(first);
			case "type_id":
				return CreateTypeId(first);
			default:
				return
						UnifiedType.Create(
								UnifiedVariableIdentifier.Create(first.Value));
			}
		}

		public static UnifiedType CreateTypeId(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_id");
			/*
			type_id
			: {isTypeName(input.LT(1).getText())}? IDENTIFIER
			*/
			// typedefされた型名が使用される場合
			return UnifiedType.Create(node.Elements().First().Value);
		}

		public static UnifiedType CreateStructOrUnionSpecifier(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_or_union_specifier");
			/*	struct_or_union_specifier
			 * : struct_or_union IDENTIFIER? '{' struct_declaration_list '}'
			 * | struct_or_union IDENTIFIER
			 */
			// 構造体の定義と宣言の両方をこのメソッドで作成
			// 常に UnifiedType を返すが、
			// 構造体定義をしている場合だけ関数の呼び出し元で UnifiedType の中身をとりだす

			// typedef "struct {}" data; -> クラス？
			// "struct data {}"; -> クラス
			// "struct data" a; -> 型

			var isStruct = CreateStructOrUnion(node.FirstElement()) == "struct";
			var identifier = node.Element("IDENTIFIER");
			var typeName = identifier == null
								   ? null
								   : UnifiedVariableIdentifier.Create(
										   identifier.Value);

			// 型の場合
			if (node.Elements().Count() == 2) {
				var baseType = UnifiedType.Create(typeName);
				return isStruct ? baseType.WrapStruct() : baseType.WrapUnion();
			}

			// struct or union の定義がある場合
			var body =
					CreateStructDeclarationList(
							node.Element("struct_declaration_list"));
			var structOrUnion = isStruct
										? (UnifiedClassLikeDefinition)
										  UnifiedStructDefinition.
												  Create(
														  name: typeName,
														  body: body)
										: UnifiedUnionDefinition.Create(
												name: typeName, body: body);

			// TODO struct or unionはあくまでもTypeとして返すののか？
			return UnifiedType.Create(structOrUnion);
		}

		public static string CreateStructOrUnion(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_or_union");
			/* struct_or_union
			 * : 'struct'
			 * | 'union'
			 */
			return node.Value;
		}

		public static UnifiedBlock CreateStructDeclarationList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declaration_list");
			/* struct_declaration_list
			 * : struct_declaration+
			 */
			return
					UnifiedBlock.Create(
							node.Elements("struct_declaration").Select(
									CreateStructDeclaration));
		}

		public static UnifiedVariableDefinitionList CreateStructDeclaration(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declaration");
			/*
			 * struct_declaration
			 * : specifier_qualifier_list struct_declarator_list ';'
			 */

			var modifiersAndType = CreateSpecifierQualifierList(
					node.Element("specifier_qualifier_list"));
			var modifiers = modifiersAndType.Item1;
			var type = modifiersAndType.Item2;

			var structDeclaratorList = node.Element("struct_declarator_list");
			UnifiedVariableDefinitionList variables = null;
			if (structDeclaratorList != null) {
				variables = UnifiedVariableDefinitionList.Create(
						CreateStructDeclaratorList(structDeclaratorList).
								Select(
										e =>
										UnifiedVariableDefinition.Create(
												null, modifiers, type, e.Item1,
												e.Item2)));
			}
			return variables;
		}

		public static Tuple<UnifiedSet<UnifiedModifier>, UnifiedType>
				CreateSpecifierQualifierList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "specifier_qualifier_list");
			/*
			 * specifier_qualifier_list
			 * : ( type_qualifier | type_specifier )+
			 */
			var modifiers = UnifiedSet<UnifiedModifier>.Create();
			var types = new List<UnifiedType>();
			foreach (var e in node.Elements()) {
				switch (e.Name()) {
				case "type_qualifier":
					modifiers.Add(CreateTypeQualifier(e));
					break;
				case "type_specifier":
					types.Add((UnifiedType)CreateTypeSpecifier(e));
					break;
				}
			}
			// 修飾子が空の場合はnullにする
			if (modifiers.IsEmpty()) {
				modifiers = null;
			}

			var s = "";
			var prefix = "";
			foreach (var t in types) {
				s += prefix + t.BasicTypeName;
				prefix = " ";
			}
			var type = s.Equals("")
							   ? null
							   : UnifiedType.Create(
									   UnifiedVariableIdentifier.Create(s));
			return Tuple.Create(modifiers, type);
		}

		public static IEnumerable<Tuple<UnifiedIdentifier, UnifiedExpression>>
				CreateStructDeclaratorList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declarator_list");
			/*
			 * struct_declarator_list
			 * : struct_declarator (',' struct_declarator)*
			 * */

			return
					node.Elements("struct_declarator").Select(
							CreateStructDeclarator);
		}

		public static Tuple<UnifiedIdentifier, UnifiedExpression>
				CreateStructDeclarator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declarator");
			/*
			 * struct_declarator
			 * : declarator (':' constant_expression)?
			 * | ':' constant_expression
			 * */

			var declarator = CreateDeclarator(node.Element("declarator"));
			if (declarator == null) {
				throw new NotImplementedException(); // TODO まだ、コロンを使うプログラムが未検証
			}

			var initializer = node.Element("constant_expression") != null
									  ? CreateConstantExpression(
											  node.Element(
													  "constant_expression"))
									  : null;

			return Tuple.Create(declarator.Item1, initializer);
		}

		public static UnifiedExpression CreateEnumSpecifier(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enum_specifier");
			/*
			enum_specifier
			: 'enum' '{' enumerator_list '}'
			| 'enum' IDENTIFIER '{' enumerator_list '}'
			| 'enum' IDENTIFIER
			*/

			// enum { RED, BLUE, YELLOW } -> 宣言
			// enum COLOR { RED, BLUE, YELLOW } -> 宣言
			// enum COLOR -> 型

			if (node.Elements("enumerator_list").Count() == 0) {
				// TODO 型名はどうなるのか？
				return
						UnifiedType.Create(
								"enum " + node.FirstElement("IDENTIFIER").Value);
			}

			var identifier = node.Element("IDENTIFIER");
			UnifiedIdentifier name = identifier != null
											 ? UnifiedIdentifier.CreateVariable(
													 identifier.Value) : null;
			var body = CreateEnumeratorList(node.Element("enumerator_list"));
			return UnifiedEnumDefinition.Create(
					null, null, name, null, null, body);
		}

		public static UnifiedBlock CreateEnumeratorList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumerator_list");
			/*
			enumerator_list
			: enumerator (',' enumerator)*
			*/

			var enumerators =
					node.Elements("enumerator").Select(CreateEnumerator);
			return
					UnifiedBlock.Create(
							UnifiedVariableDefinitionList.Create(enumerators));
		}

		public static UnifiedVariableDefinition CreateEnumerator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumerator");
			/*
			enumerator
			: IDENTIFIER ('=' constant_expression)?
			*/

			var identifier =
					UnifiedIdentifier.CreateVariable(node.NthElement(0).Value);
			UnifiedExpression value = null;
			var expression = node.Element("constant_expression");
			if (expression != null) {
				value = CreateConstantExpression(expression);
			}
			return UnifiedVariableDefinition.Create(
					null, null, null, identifier, value);
		}

		public static UnifiedModifier CreateTypeQualifier(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_qualifier");
			/* type_qualifier
			 * : 'const'
			 * | 'volatile'
			 */

			return UnifiedModifier.Create(node.FirstElement().Name());
		}

		public static Tuple<UnifiedIdentifier, UnifiedSet<UnifiedParameter>>
				CreateDeclarator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declarator");
			/*	declarator
			 * : pointer? direct_declarator
			 * | pointer
			 */

			if (node.Element("direct_declarator") != null) {
				if (node.Element("pointer") != null) {
					// TODO ポインタ型はタイプにくっつくが、ＡＳＴ上では型とは分離されているがどうするか
					CreatePointer(node.Element("pointer"));
					throw new NotImplementedException();
				}

				//現状では、int func(){ }のような一般的な関数名の場合のみ
				return CreateDirectDeclarator(node.Element("direct_declarator"));
			} else {
				// TODO pointerだけの場合にどんなケースがあるのか未検出
				throw new NotImplementedException();
			}
		}

		public static Tuple<UnifiedIdentifier, UnifiedSet<UnifiedParameter>>
				CreateDirectDeclarator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "direct_declarator");
			/* direct_declarator
			 * :   (	IDENTIFIER  | '(' declarator ')' ) declarator_suffix*
			 */

			var identifier = node.Element("IDENTIFIER");
			UnifiedIdentifier name;
			if (identifier != null) {
				name = UnifiedVariableIdentifier.Create(identifier.Value);
			} else if (node.Element("declarator") != null) {
				// TODO (test())(){ }が許されるとして、その場合はどうするのか
				return CreateDeclarator(node.Element("declarator"));
			} else {
				throw new InvalidOperationException();
			}

			UnifiedSet<UnifiedParameter> parameters = null;
			if (node.Elements("declarator_suffix").Count() > 1) {
				// TODO test()()となるケースが未検出
				throw new NotImplementedException();
			} else if (node.Elements("declarator_suffix").Count() == 1) {
				parameters =
						CreateDeclaratorSuffix(
								node.Element("declarator_suffix"));
			}

			return Tuple.Create(name, parameters);
		}

		public static UnifiedSet<UnifiedParameter> CreateDeclaratorSuffix(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declarator_suffix");
			/* declarator_suffix
			 * :   '[' constant_expression ']'
			 * |   '[' ']'
			 * |   '(' parameter_type_list ')'
			 * |   '(' identifier_list ')'
			 * |   '(' ')'
			 * ;
			*/

			// 空のパラメータリストを生成する
			var parameters = UnifiedSet<UnifiedParameter>.Create();
			// ()の場合
			if (node.FirstElement().Value.Equals("(")
				&& node.LastElement().Value.Equals(")")) {
				if (node.Element("parameter_type_list") != null) {
					parameters =
							CreateParameterTypeList(
									node.Element("parameter_type_list"));
				} else if (node.Element("identifier_list") != null) {
					// TODO どう考えてもargumentCollectionだが、対応するプログラムをまずは検証する
					throw new NotImplementedException();
				}
				// []の場合
			} else if (node.FirstElement().Value.Equals("[")
					   && node.LastElement().Value.Equals("]")) {
				// TODO []がくるケースがまだ未検証
				throw new NotImplementedException();
			} else {
				throw new InvalidOperationException();
			}
			return parameters;
		}

		public static UnifiedElement CreatePointer(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "pointer");
			/*	pointer
			 * : '*' type_qualifier+ pointer?
			 * | '*' pointer
			 * | '*'
			 */

			// TODO ポインタ型がtypeに付くのかidentifierに付くのか決定する必要がある
			throw new NotImplementedException();
		}

		public static UnifiedSet<UnifiedParameter> CreateParameterTypeList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_type_list");
			/*
			parameter_type_list
			: parameter_list (',' '...')?
			*/
			var parameters = CreateParameterList(node.Element("parameter_list"));
			// TODO 可変長引数はmodifierなのか確認
			if (node.LastElement().Value == "...") {
				parameters.Add(
						UnifiedParameter.Create(
								modifiers:
										UnifiedSet<UnifiedModifier>.Create(
												UnifiedModifier.Create("..."))));
			}
			return parameters;
		}

		public static UnifiedSet<UnifiedParameter> CreateParameterList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_list");
			/*
			parameter_list
			: parameter_declaration (',' parameter_declaration)*
			*/

			var parameters = UnifiedSet<UnifiedParameter>.Create();
			foreach (var parameterNode in node.Elements("parameter_declaration")
					) {
				parameters.Add(CreateParameterDeclaration(parameterNode));
			}
			return parameters;
		}

		public static UnifiedParameter CreateParameterDeclaration(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_declaration");
			/*
			parameter_declaration
			: declaration_specifiers (declarator|abstract_declarator)*
			 */

			UnifiedIdentifier name;
			UnifiedSet<UnifiedParameter> parameters;

			var modifiersAndType =
					CreateDeclarationSpecifiers(
							node.Element("declaration_specifiers"));
			var modifiers = modifiersAndType.Item1;
			var type = (UnifiedType)modifiersAndType.Item2;

			var declarators = node.Elements("declarator");
			if (declarators.Count() == 0) {
				return UnifiedParameter.Create(null, modifiers, type);
			}
			var declarator = CreateDeclarator(node.FirstElement("declarator"));

			// abstract_declaratorはおそらく[]など=> よって、最初に現れることはないはず( // TODO 未検証)

			if (node.Element("abstract_declarator") != null) {
				// TODO (int y[])の場合は、[]はどこに付くのか？
				throw new NotImplementedException();
			} 
					// TODO 実際のところ、そこまで理解しきれていない
			else if (declarators.Count() == 1) {
				// 多分declarator自体は１つしか現れないはず( // TODO 未検証)
				return UnifiedParameter.Create(
						null, modifiers, type, declarator.Item1.ToSet());
			} else if (node.Element("declarator") != null) {
				parameters = declarator.Item2;
				name = declarator.Item1;
				if (parameters != null && parameters.Count > 0) {
					// この場合はパラメータが関数ポインタ
					var returnType = type;
					type = UnifiedType.Create(
							UnifiedFunctionDefinition.Create(
									null, modifiers, returnType, null, null,
									parameters));
					modifiers = null;
				}
				return UnifiedParameter.Create(
						null, modifiers, type, name.ToSet(), null);
			}
			throw new InvalidOperationException();
		}

		public static IEnumerable<UnifiedExpression> CreateIdentifierList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "identifier_list");
			/*
			identifier_list
			: IDENTIFIER (',' IDENTIFIER)*
			*/

			// TODO 使いどころがわからない
			return
					node.Elements("IDENTIFIER").Select(
							e => UnifiedIdentifier.CreateVariable(e.Value));
		}

		public static UnifiedType CreateTypeName(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_name");
			/*
			type_name
			: specifier_qualifier_list abstract_declarator?
			*/

			var modifiersAndType =
					CreateSpecifierQualifierList(
							node.Element("specifier_qualifier_list"));
			CreateAbstractDeclarator(node.Element("abstract_declarator"));

			// TODO modifiersはどう扱うのか？ abstract_declaratorがどう出現するのか未検証
			return modifiersAndType.Item2;
		}

		public static UnifiedElement CreateAbstractDeclarator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "abstract_declarator");
			/*
			abstract_declarator
			: pointer direct_abstract_declarator?
			| direct_abstract_declarator
			 */

			if (node.Element("pointer") != null) {
				// TODO declaratorと同じでポイント型の扱い方次第
				throw new NotImplementedException();
			} else if (node.Element("direct_abstract_declarator") != null) {
				// TODO 実際に出現する例を調べる
				throw new NotImplementedException();
			} else {
				throw new InvalidOperationException();
			}
		}

		public static UnifiedElement CreateDirectAbstractDeclarator(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "direct_abstract_declarator");
			/*
			direct_abstract_declarator
			:	( '(' abstract_declarator ')' | abstract_declarator_suffix ) abstract_declarator_suffix*
			 */

			// TODO 実際に出現する例を調べる
			throw new NotImplementedException();
		}

		public static UnifiedElement CreateAbstractDeclaratorSuffix(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "abstract_declarator_suffix");
			/*
			abstract_declarator_suffix
			:	'[' ']'
			|	'[' constant_expression ']'
			|	'(' ')'
			|	'(' parameter_type_list ')'
			*/

			// TODO どこにくっ付いているsuffixなのか確認する
			throw new NotImplementedException();
		}

		public static UnifiedExpression CreateInitializer(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initializer");
			/*
			initializer
			: assignment_expression
			| '{' initializer_list ','? '}'
			 */
			if (node.Element("assignment_expression") != null) {
				return
						CreateAssignmentExpression(
								node.Element("assignment_expression"));
			} else if (node.Element("initializer_list") != null) {
				// TODO おそらく構造体の初期化子=> どの要素に当てはまるのか確認する
				throw new NotImplementedException();
			}
			throw new InvalidOperationException();
		}

		public static IEnumerable<UnifiedExpression> CreateInitializerList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initializer_list");
			/*
			initializer_list
			: initializer (',' initializer)*
			 */
			return node.Elements("initializer").Select(CreateInitializer);
		}
	}
}