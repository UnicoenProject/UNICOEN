using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Code2Xml.Languages.C.CodeToXmls;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.C.ModelFactories {
	public static class CModelFactoryHelper {

		public static UnifiedProgram CreateTranslation_unit(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "translation_unit");
			/*
			 * translation_unit
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExternal_declaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "external_declaration");
			/*
			 * external_declaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFunction_definition(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "function_definition");
			/*
			 * function_definition
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDeclaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declaration");
			/*
			 * declaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDeclaration_specifiers(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declaration_specifiers");
			/*
			 * declaration_specifiers
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInit_declarator_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "init_declarator_list");
			/*
			 * init_declarator_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInit_declarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "init_declarator");
			/*
			 * init_declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStorage_class_specifier(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "storage_class_specifier");
			/*
			 * storage_class_specifier
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateType_specifier(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_specifier");
			/*
			 * type_specifier
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateType_id(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_id");
			/*
			 * type_id
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_or_union_specifier(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_or_union_specifier");
			/*
			 * struct_or_union_specifier
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_or_union(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_or_union");
			/*
			 * struct_or_union
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_declaration_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declaration_list");
			/*
			 * struct_declaration_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_declaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declaration");
			/*
			 * struct_declaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSpecifier_qualifier_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "specifier_qualifier_list");
			/*
			 * specifier_qualifier_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_declarator_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declarator_list");
			/*
			 * struct_declarator_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStruct_declarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "struct_declarator");
			/*
			 * struct_declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEnum_specifier(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enum_specifier");
			/*
			 * enum_specifier
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEnumerator_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumerator_list");
			/*
			 * enumerator_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEnumerator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "enumerator");
			/*
			 * enumerator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateType_qualifier(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_qualifier");
			/*
			 * type_qualifier
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDeclarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declarator");
			/*
			 * declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDirect_declarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "direct_declarator");
			/*
			 * direct_declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDeclarator_suffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "declarator_suffix");
			/*
			 * declarator_suffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePointer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "pointer");
			/*
			 * pointer
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateParameter_type_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_type_list");
			/*
			 * parameter_type_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateParameter_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_list");
			/*
			 * parameter_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateParameter_declaration(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameter_declaration");
			/*
			 * parameter_declaration
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIdentifier_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "identifier_list");
			/*
			 * identifier_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateType_name(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "type_name");
			/*
			 * type_name
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAbstract_declarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "abstract_declarator");
			/*
			 * abstract_declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDirect_abstract_declarator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "direct_abstract_declarator");
			/*
			 * direct_abstract_declarator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAbstract_declarator_suffix(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "abstract_declarator_suffix");
			/*
			 * abstract_declarator_suffix
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInitializer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initializer");
			/*
			 * initializer
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInitializer_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "initializer_list");
			/*
			 * initializer_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArgument_expression_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument_expression_list");
			/*
			 * argument_expression_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAdditive_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additive_expression");
			/*
			 * additive_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMultiplicative_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicative_expression");
			/*
			 * multiplicative_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCast_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "cast_expression");
			/*
			 * cast_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateUnary_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unary_expression");
			/*
			 * unary_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePostfix_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "postfix_expression");
			/*
			 * postfix_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateUnary_operator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unary_operator");
			/*
			 * unary_operator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePrimary_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary_expression");
			/*
			 * primary_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConstant(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant");
			/*
			 * constant
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateHex_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "hex_literal");
			/*
			 * hex_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOctal_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "octal_literal");
			/*
			 * octal_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDecimal_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decimal_literal");
			/*
			 * decimal_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCharacter_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "character_literal");
			/*
			 * character_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateString_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "string_literal");
			/*
			 * string_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFloating_point_literal(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "floating_point_literal");
			/*
			 * floating_point_literal
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/*
			 * expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConstant_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant_expression");
			/*
			 * constant_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignment_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_expression");
			/*
			 * assignment_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLvalue(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lvalue");
			/*
			 * lvalue
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAssignment_operator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_operator");
			/*
			 * assignment_operator
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConditional_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditional_expression");
			/*
			 * conditional_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogical_or_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_or_expression");
			/*
			 * logical_or_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogical_and_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_and_expression");
			/*
			 * logical_and_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInclusive_or_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusive_or_expression");
			/*
			 * inclusive_or_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExclusive_or_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusive_or_expression");
			/*
			 * exclusive_or_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAnd_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expression");
			/*
			 * and_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEquality_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equality_expression");
			/*
			 * equality_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateRelational_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relational_expression");
			/*
			 * relational_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateShift_expression(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expression");
			/*
			 * shift_expression
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			 * statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLabeled_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			 * labeled_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCompound_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compound_statement");
			/*
			 * compound_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateStatement_list(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement_list");
			/*
			 * statement_list
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExpression_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			 * expression_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSelection_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			 * selection_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIteration_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iteration_statement");
			/*
			 * iteration_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateJump_statement(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "jump_statement");
			/*
			 * jump_statement
			 */
			throw new NotImplementedException(); //TODO: implement
		}

	}
}