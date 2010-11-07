// $ANTLR 3.2 Sep 23, 2009 12:02:23 Java.g 2010-08-13 02:31:19

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162

using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Ucpf.Languages.Common.Antlr;

/** A Java 1.5 grammar for ANTLR v3 derived from the spec
 *
 *  This is a very close representation of the spec; the changes
 *  are comestic (remove left recursion) and also fixes (the spec
 *  isn't exactly perfect).  I have run this on the 1.4.2 source
 *  and some nasty looking enums from 1.5, but have not really
 *  tested for 1.5 compatibility.
 *
 *  I built this with: java -Xmx100M org.antlr.Tool java.g
 *  and got two errors that are ok (for now):
 *  java.g:691:9: Decision can match input such as
 *    "'0'..'9'{'E', 'e'}{'+', '-'}'0'..'9'{'D', 'F', 'd', 'f'}"
 *    using multiple alternatives: 3, 4
 *  As a result, alternative(s) 4 were disabled for that input
 *  java.g:734:35: Decision can match input such as "{'$', 'A'..'Z',
 *    '_', 'a'..'z', '\u00C0'..'\u00D6', '\u00D8'..'\u00F6',
 *    '\u00F8'..'\u1FFF', '\u3040'..'\u318F', '\u3300'..'\u337F',
 *    '\u3400'..'\u3D2D', '\u4E00'..'\u9FFF', '\uF900'..'\uFAFF'}"
 *    using multiple alternatives: 1, 2
 *  As a result, alternative(s) 2 were disabled for that input
 *
 *  You can turn enum on/off as a keyword :)
 *
 *  Version 1.0 -- initial release July 5, 2006 (requires 3.0b2 or higher)
 *
 *  Primary author: Terence Parr, July 2006
 *
 *  Version 1.0.1 -- corrections by Koen Vanderkimpen & Marko van Dooren,
 *      October 25, 2006;
 *      fixed normalInterfaceDeclaration: now uses typeParameters instead
 *          of typeParameter (according to JLS, 3rd edition)
 *      fixed castExpression: no longer allows expression next to type
 *          (according to semantics in JLS, in contrast with syntax in JLS)
 *
 *  Version 1.0.2 -- Terence Parr, Nov 27, 2006
 *      java spec I built this from had some bizarre for-loop control.
 *          Looked weird and so I looked elsewhere...Yep, it's messed up.
 *          simplified.
 *
 *  Version 1.0.3 -- Chris Hogue, Feb 26, 2007
 *      Factored out an annotationName rule and used it in the annotation rule.
 *          Not sure why, but typeName wasn't recognizing references to inner
 *          annotations (e.g. @InterfaceName.InnerAnnotation())
 *      Factored out the elementValue section of an annotation reference.  Created
 *          elementValuePair and elementValuePairs rules, then used them in the
 *          annotation rule.  Allows it to recognize annotation references with
 *          multiple, comma separated attributes.
 *      Updated elementValueArrayInitializer so that it allows multiple elements.
 *          (It was only allowing 0 or 1 element).
 *      Updated localVariableDeclaration to allow annotations.  Interestingly the JLS
 *          doesn't appear to indicate this is legal, but it does work as of at least
 *          JDK 1.5.0_06.
 *      Moved the Identifier portion of annotationTypeElementRest to annotationMethodRest.
 *          Because annotationConstantRest already references variableDeclarator which
 *          has the Identifier portion in it, the parser would fail on constants in
 *          annotation definitions because it expected two identifiers.
 *      Added optional trailing ';' to the alternatives in annotationTypeElementRest.
 *          Wouldn't handle an inner interface that has a trailing ';'.
 *      Swapped the expression and type rule reference order in castExpression to
 *          make it check for genericized casts first.  It was failing to recognize a
 *          statement like  "Class<Byte> TYPE = (Class<Byte>)...;" because it was seeing
 *          'Class<Byte' in the cast expression as a less than expression, then failing
 *          on the '>'.
 *      Changed createdName to use typeArguments instead of nonWildcardTypeArguments.
 *         
 *      Changed the 'this' alternative in primary to allow 'identifierSuffix' rather than
 *          just 'arguments'.  The case it couldn't handle was a call to an explicit
 *          generic method invocation (e.g. this.<E>doSomething()).  Using identifierSuffix
 *          may be overly aggressive--perhaps should create a more constrained thisSuffix rule?
 *
 *  Version 1.0.4 -- Hiroaki Nakamura, May 3, 2007
 *
 *  Fixed formalParameterDecls, localVariableDeclaration, forInit,
 *  and forVarControl to use variableModifier* not 'final'? (annotation)?
 *
 *  Version 1.0.5 -- Terence, June 21, 2007
 *  --a[i].foo didn't work. Fixed unaryExpression
 *
 *  Version 1.0.6 -- John Ridgway, March 17, 2008
 *      Made "assert" a switchable keyword like "enum".
 *      Fixed compilationUnit to disallow "annotation importDeclaration ...".
 *      Changed "Identifier ('.' Identifier)*" to "qualifiedName" in more
 *          places.
 *      Changed modifier* and/or variableModifier* to classOrInterfaceModifiers,
 *          modifiers or variableModifiers, as appropriate.
 *      Renamed "bound" to "typeBound" to better match language in the JLS.
 *      Added "memberDeclaration" which rewrites to methodDeclaration or
 *      fieldDeclaration and pulled type into memberDeclaration.  So we parse
 *          type and then move on to decide whether we're dealing with a field
 *          or a method.
 *      Modified "constructorDeclaration" to use "constructorBody" instead of
 *          "methodBody".  constructorBody starts with explicitConstructorInvocation,
 *          then goes on to blockStatement*.  Pulling explicitConstructorInvocation
 *          out of expressions allowed me to simplify "primary".
 *      Changed variableDeclarator to simplify it.
 *      Changed type to use classOrInterfaceType, thus simplifying it; of course
 *          I then had to add classOrInterfaceType, but it is used in several
 *          places.
 *      Fixed annotations, old version allowed "@X(y,z)", which is illegal.
 *      Added optional comma to end of "elementValueArrayInitializer"; as per JLS.
 *      Changed annotationTypeElementRest to use normalClassDeclaration and
 *          normalInterfaceDeclaration rather than classDeclaration and
 *          interfaceDeclaration, thus getting rid of a couple of grammar ambiguities.
 *      Split localVariableDeclaration into localVariableDeclarationStatement
 *          (includes the terminating semi-colon) and localVariableDeclaration.
 *          This allowed me to use localVariableDeclaration in "forInit" clauses,
 *           simplifying them.
 *      Changed switchBlockStatementGroup to use multiple labels.  This adds an
 *          ambiguity, but if one uses appropriately greedy parsing it yields the
 *           parse that is closest to the meaning of the switch statement.
 *      Renamed "forVarControl" to "enhancedForControl" -- JLS language.
 *      Added semantic predicates to test for shift operations rather than other
 *          things.  Thus, for instance, the string "< <" will never be treated
 *          as a left-shift operator.
 *      In "creator" we rule out "nonWildcardTypeArguments" on arrayCreation,
 *          which are illegal.
 *      Moved "nonWildcardTypeArguments into innerCreator.
 *      Removed 'super' superSuffix from explicitGenericInvocation, since that
 *          is only used in explicitConstructorInvocation at the beginning of a
 *           constructorBody.  (This is part of the simplification of expressions
 *           mentioned earlier.)
 *      Simplified primary (got rid of those things that are only used in
 *          explicitConstructorInvocation).
 *      Lexer -- removed "Exponent?" from FloatingPointLiteral choice 4, since it
 *          led to an ambiguity.
 *
 *      This grammar successfully parses every .java file in the JDK 1.5 source
 *          tree (excluding those whose file names include '-', which are not
 *          valid Java compilation units).
 *
 *  Known remaining problems:
 *      "Letter" and "JavaIDDigit" are wrong.  The actual specification of
 *      "Letter" should be "a character for which the method
 *      Character.isJavaIdentifierStart(int) returns true."  A "Java
 *      letter-or-digit is a character for which the method
 *      Character.isJavaIdentifierPart(int) returns true."
 */
namespace Ucpf.Languages.Java {
	public partial class JavaParser : Parser, IXParser
	{
		public static readonly string[] tokenNames = new string[] 
		{
			"<invalid>", 
			"<EOR>", 
			"<DOWN>", 
			"<UP>", 
			"IDENTIFIER", 
			"INTLITERAL", 
			"LONGLITERAL", 
			"FLOATLITERAL", 
			"DOUBLELITERAL", 
			"CHARLITERAL", 
			"STRINGLITERAL", 
			"TRUE", 
			"FALSE", 
			"NULL", 
			"IntegerNumber", 
			"LongSuffix", 
			"HexPrefix", 
			"HexDigit", 
			"Exponent", 
			"NonIntegerNumber", 
			"FloatSuffix", 
			"DoubleSuffix", 
			"EscapeSequence", 
			"WS", 
			"COMMENT", 
			"LINE_COMMENT", 
			"ABSTRACT", 
			"ASSERT", 
			"BOOLEAN", 
			"BREAK", 
			"BYTE", 
			"CASE", 
			"CATCH", 
			"CHAR", 
			"CLASS", 
			"CONST", 
			"CONTINUE", 
			"DEFAULT", 
			"DO", 
			"DOUBLE", 
			"ELSE", 
			"ENUM", 
			"EXTENDS", 
			"FINAL", 
			"FINALLY", 
			"FLOAT", 
			"FOR", 
			"GOTO", 
			"IF", 
			"IMPLEMENTS", 
			"IMPORT", 
			"INSTANCEOF", 
			"INT", 
			"INTERFACE", 
			"LONG", 
			"NATIVE", 
			"NEW", 
			"PACKAGE", 
			"PRIVATE", 
			"PROTECTED", 
			"PUBLIC", 
			"RETURN", 
			"SHORT", 
			"STATIC", 
			"STRICTFP", 
			"SUPER", 
			"SWITCH", 
			"SYNCHRONIZED", 
			"THIS", 
			"THROW", 
			"THROWS", 
			"TRANSIENT", 
			"TRY", 
			"VOID", 
			"VOLATILE", 
			"WHILE", 
			"LPAREN", 
			"RPAREN", 
			"LBRACE", 
			"RBRACE", 
			"LBRACKET", 
			"RBRACKET", 
			"SEMI", 
			"COMMA", 
			"DOT", 
			"ELLIPSIS", 
			"EQ", 
			"BANG", 
			"TILDE", 
			"QUES", 
			"COLON", 
			"EQEQ", 
			"AMPAMP", 
			"BARBAR", 
			"PLUSPLUS", 
			"SUBSUB", 
			"PLUS", 
			"SUB", 
			"STAR", 
			"SLASH", 
			"AMP", 
			"BAR", 
			"CARET", 
			"PERCENT", 
			"PLUSEQ", 
			"SUBEQ", 
			"STAREQ", 
			"SLASHEQ", 
			"AMPEQ", 
			"BAREQ", 
			"CARETEQ", 
			"PERCENTEQ", 
			"MONKEYS_AT", 
			"BANGEQ", 
			"GT", 
			"LT", 
			"IdentifierStart", 
			"IdentifierPart", 
			"SurrogateIdentifer"
		};

		public const int PACKAGE = 57;
		public const int LT = 115;
		public const int STAR = 98;
		public const int WHILE = 75;
		public const int CONST = 35;
		public const int CASE = 31;
		public const int CHAR = 33;
		public const int NEW = 56;
		public const int DO = 38;
		public const int EOF = -1;
		public const int BREAK = 29;
		public const int LBRACKET = 80;
		public const int FINAL = 43;
		public const int RPAREN = 77;
		public const int IMPORT = 50;
		public const int SUBSUB = 95;
		public const int STAREQ = 106;
		public const int FloatSuffix = 20;
		public const int NonIntegerNumber = 19;
		public const int CARET = 102;
		public const int RETURN = 61;
		public const int THIS = 68;
		public const int DOUBLE = 39;
		public const int MONKEYS_AT = 112;
		public const int BARBAR = 93;
		public const int VOID = 73;
		public const int SUPER = 65;
		public const int GOTO = 47;
		public const int EQ = 86;
		public const int AMPAMP = 92;
		public const int COMMENT = 24;
		public const int QUES = 89;
		public const int EQEQ = 91;
		public const int HexPrefix = 16;
		public const int RBRACE = 79;
		public const int LINE_COMMENT = 25;
		public const int PRIVATE = 58;
		public const int STATIC = 63;
		public const int SWITCH = 66;
		public const int NULL = 13;
		public const int ELSE = 40;
		public const int STRICTFP = 64;
		public const int DOUBLELITERAL = 8;
		public const int IdentifierStart = 116;
		public const int NATIVE = 55;
		public const int ELLIPSIS = 85;
		public const int THROWS = 70;
		public const int INT = 52;
		public const int SLASHEQ = 107;
		public const int INTLITERAL = 5;
		public const int ASSERT = 27;
		public const int TRY = 72;
		public const int LONGLITERAL = 6;
		public const int LongSuffix = 15;
		public const int WS = 23;
		public const int SurrogateIdentifer = 118;
		public const int CHARLITERAL = 9;
		public const int GT = 114;
		public const int CATCH = 32;
		public const int FALSE = 12;
		public const int EscapeSequence = 22;
		public const int THROW = 69;
		public const int PROTECTED = 59;
		public const int CLASS = 34;
		public const int BAREQ = 109;
		public const int IntegerNumber = 14;
		public const int AMP = 100;
		public const int PLUSPLUS = 94;
		public const int LBRACE = 78;
		public const int SUBEQ = 105;
		public const int Exponent = 18;
		public const int FOR = 46;
		public const int SUB = 97;
		public const int FLOAT = 45;
		public const int ABSTRACT = 26;
		public const int HexDigit = 17;
		public const int PLUSEQ = 104;
		public const int LPAREN = 76;
		public const int IF = 48;
		public const int SLASH = 99;
		public const int BOOLEAN = 28;
		public const int SYNCHRONIZED = 67;
		public const int IMPLEMENTS = 49;
		public const int CONTINUE = 36;
		public const int COMMA = 83;
		public const int AMPEQ = 108;
		public const int IDENTIFIER = 4;
		public const int TRANSIENT = 71;
		public const int TILDE = 88;
		public const int BANGEQ = 113;
		public const int PLUS = 96;
		public const int RBRACKET = 81;
		public const int DOT = 84;
		public const int IdentifierPart = 117;
		public const int BYTE = 30;
		public const int PERCENT = 103;
		public const int VOLATILE = 74;
		public const int DEFAULT = 37;
		public const int SHORT = 62;
		public const int BANG = 87;
		public const int INSTANCEOF = 51;
		public const int TRUE = 11;
		public const int SEMI = 82;
		public const int COLON = 90;
		public const int ENUM = 41;
		public const int PERCENTEQ = 111;
		public const int DoubleSuffix = 21;
		public const int FINALLY = 44;
		public const int STRINGLITERAL = 10;
		public const int CARETEQ = 110;
		public const int INTERFACE = 53;
		public const int LONG = 54;
		public const int EXTENDS = 42;
		public const int FLOATLITERAL = 7;
		public const int PUBLIC = 60;
		public const int BAR = 101;

		// delegates
		// delegators



		public JavaParser(ITokenStream input)
			: this(input, new RecognizerSharedState()) {
		}

		public JavaParser(ITokenStream input, RecognizerSharedState state)
			: base(input, state) {
			InitializeCyclicDFAs();
			this.state.ruleMemo = new Hashtable[381+1];
             
             
		}
        
		protected XmlTreeAdaptor adaptor = new XmlTreeAdaptor(new List<XElement>(), "TOKEN");

		public ITreeAdaptor TreeAdaptor
		{
			get { return this.adaptor; }
			set {
				this.adaptor = (XmlTreeAdaptor)value;
			}
		}

		override public string[] TokenNames {
			get { return JavaParser.tokenNames; }
		}

		override public string GrammarFileName {
			get { return "Java.g"; }
		}


		private readonly IList<XElement> Elements = new List<XElement>();
		public IList<XElement> ElementList { get { return Elements; } }
		public string LeaveElementName { get; set; }


		public class compilationUnit_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "compilationUnit"
		// Java.g:310:1: compilationUnit : ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )* ;
		public JavaParser.compilationUnit_return compilationUnit() // throws RecognitionException [1]
		{   
			JavaParser.compilationUnit_return retval = new JavaParser.compilationUnit_return();
			retval.Start = input.LT(1);
			int compilationUnit_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.annotations_return annotations1 = default(JavaParser.annotations_return);

			JavaParser.packageDeclaration_return packageDeclaration2 = default(JavaParser.packageDeclaration_return);

			JavaParser.importDeclaration_return importDeclaration3 = default(JavaParser.importDeclaration_return);

			JavaParser.typeDeclaration_return typeDeclaration4 = default(JavaParser.typeDeclaration_return);



			const string elementName = "compilationUnit"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
				{
					return retval; 
				}
				// Java.g:317:5: ( ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )* )
				// Java.g:317:9: ( ( annotations )? packageDeclaration )? ( importDeclaration )* ( typeDeclaration )*
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:317:9: ( ( annotations )? packageDeclaration )?
					int alt2 = 2;
					alt2 = dfa2.Predict(input);
					switch (alt2) 
					{
					case 1 :
						// Java.g:317:13: ( annotations )? packageDeclaration
					{
						// Java.g:317:13: ( annotations )?
						int alt1 = 2;
						int LA1_0 = input.LA(1);

						if ( (LA1_0 == MONKEYS_AT) )
						{
							alt1 = 1;
						}
						switch (alt1) 
						{
						case 1 :
							// Java.g:317:14: annotations
						{
							PushFollow(FOLLOW_annotations_in_compilationUnit121);
							annotations1 = annotations();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotations1.Tree, annotations1, retval);

						}
							break;

						}

						PushFollow(FOLLOW_packageDeclaration_in_compilationUnit150);
						packageDeclaration2 = packageDeclaration();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, packageDeclaration2.Tree, packageDeclaration2, retval);

					}
						break;

					}

					// Java.g:321:9: ( importDeclaration )*
					do 
					{
						int alt3 = 2;
						int LA3_0 = input.LA(1);

						if ( (LA3_0 == IMPORT) )
						{
							alt3 = 1;
						}


						switch (alt3) 
						{
						case 1 :
							// Java.g:321:10: importDeclaration
						{
							PushFollow(FOLLOW_importDeclaration_in_compilationUnit172);
							importDeclaration3 = importDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, importDeclaration3.Tree, importDeclaration3, retval);

						}
							break;

						default:
							goto loop3;
						}
					} while (true);

					loop3:
					;	// Stops C# compiler whining that label 'loop3' has no statements

					// Java.g:323:9: ( typeDeclaration )*
					do 
					{
						int alt4 = 2;
						int LA4_0 = input.LA(1);

						if ( (LA4_0 == IDENTIFIER || LA4_0 == ABSTRACT || LA4_0 == BOOLEAN || LA4_0 == BYTE || (LA4_0 >= CHAR && LA4_0 <= CLASS) || LA4_0 == DOUBLE || LA4_0 == ENUM || LA4_0 == FINAL || LA4_0 == FLOAT || (LA4_0 >= INT && LA4_0 <= NATIVE) || (LA4_0 >= PRIVATE && LA4_0 <= PUBLIC) || (LA4_0 >= SHORT && LA4_0 <= STRICTFP) || LA4_0 == SYNCHRONIZED || LA4_0 == TRANSIENT || (LA4_0 >= VOID && LA4_0 <= VOLATILE) || LA4_0 == SEMI || LA4_0 == MONKEYS_AT || LA4_0 == LT) )
						{
							alt4 = 1;
						}


						switch (alt4) 
						{
						case 1 :
							// Java.g:323:10: typeDeclaration
						{
							PushFollow(FOLLOW_typeDeclaration_in_compilationUnit194);
							typeDeclaration4 = typeDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeDeclaration4.Tree, typeDeclaration4, retval);

						}
							break;

						default:
							goto loop4;
						}
					} while (true);

					loop4:
					;	// Stops C# compiler whining that label 'loop4' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 1, compilationUnit_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "compilationUnit"

		public class packageDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "packageDeclaration"
		// Java.g:327:1: packageDeclaration : 'package' qualifiedName ';' ;
		public JavaParser.packageDeclaration_return packageDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.packageDeclaration_return retval = new JavaParser.packageDeclaration_return();
			retval.Start = input.LT(1);
			int packageDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal5 = null;
			IToken char_literal7 = null;
			JavaParser.qualifiedName_return qualifiedName6 = default(JavaParser.qualifiedName_return);


			object string_literal5_tree=null;
			object char_literal7_tree=null;

			const string elementName = "packageDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
				{
					return retval; 
				}
				// Java.g:330:5: ( 'package' qualifiedName ';' )
				// Java.g:330:9: 'package' qualifiedName ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal5=(IToken)Match(input,PACKAGE,FOLLOW_PACKAGE_in_packageDeclaration234); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal5_tree = (object)adaptor.Create(string_literal5, retval);
						adaptor.AddChild(root_0, string_literal5_tree);
					}
					PushFollow(FOLLOW_qualifiedName_in_packageDeclaration236);
					qualifiedName6 = qualifiedName();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedName6.Tree, qualifiedName6, retval);
					char_literal7=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_packageDeclaration246); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal7_tree = (object)adaptor.Create(char_literal7, retval);
						adaptor.AddChild(root_0, char_literal7_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 2, packageDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "packageDeclaration"

		public class importDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "importDeclaration"
		// Java.g:334:1: importDeclaration : ( 'import' ( 'static' )? IDENTIFIER '.' '*' ';' | 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';' );
		public JavaParser.importDeclaration_return importDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.importDeclaration_return retval = new JavaParser.importDeclaration_return();
			retval.Start = input.LT(1);
			int importDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal8 = null;
			IToken string_literal9 = null;
			IToken IDENTIFIER10 = null;
			IToken char_literal11 = null;
			IToken char_literal12 = null;
			IToken char_literal13 = null;
			IToken string_literal14 = null;
			IToken string_literal15 = null;
			IToken IDENTIFIER16 = null;
			IToken char_literal17 = null;
			IToken IDENTIFIER18 = null;
			IToken char_literal19 = null;
			IToken char_literal20 = null;
			IToken char_literal21 = null;

			object string_literal8_tree=null;
			object string_literal9_tree=null;
			object IDENTIFIER10_tree=null;
			object char_literal11_tree=null;
			object char_literal12_tree=null;
			object char_literal13_tree=null;
			object string_literal14_tree=null;
			object string_literal15_tree=null;
			object IDENTIFIER16_tree=null;
			object char_literal17_tree=null;
			object IDENTIFIER18_tree=null;
			object char_literal19_tree=null;
			object char_literal20_tree=null;
			object char_literal21_tree=null;

			const string elementName = "importDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
				{
					return retval; 
				}
				// Java.g:337:5: ( 'import' ( 'static' )? IDENTIFIER '.' '*' ';' | 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';' )
				int alt9 = 2;
				int LA9_0 = input.LA(1);

				if ( (LA9_0 == IMPORT) )
				{
					int LA9_1 = input.LA(2);

					if ( (LA9_1 == STATIC) )
					{
						int LA9_2 = input.LA(3);

						if ( (LA9_2 == IDENTIFIER) )
						{
							int LA9_3 = input.LA(4);

							if ( (LA9_3 == DOT) )
							{
								int LA9_4 = input.LA(5);

								if ( (LA9_4 == STAR) )
								{
									alt9 = 1;
								}
								else if ( (LA9_4 == IDENTIFIER) )
								{
									alt9 = 2;
								}
								else 
								{
									if ( state.backtracking > 0 ) {state.failed = true; return retval;}
									NoViableAltException nvae_d9s4 =
										new NoViableAltException("", 9, 4, input);

									throw nvae_d9s4;
								}
							}
							else 
							{
								if ( state.backtracking > 0 ) {state.failed = true; return retval;}
								NoViableAltException nvae_d9s3 =
									new NoViableAltException("", 9, 3, input);

								throw nvae_d9s3;
							}
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d9s2 =
								new NoViableAltException("", 9, 2, input);

							throw nvae_d9s2;
						}
					}
					else if ( (LA9_1 == IDENTIFIER) )
					{
						int LA9_3 = input.LA(3);

						if ( (LA9_3 == DOT) )
						{
							int LA9_4 = input.LA(4);

							if ( (LA9_4 == STAR) )
							{
								alt9 = 1;
							}
							else if ( (LA9_4 == IDENTIFIER) )
							{
								alt9 = 2;
							}
							else 
							{
								if ( state.backtracking > 0 ) {state.failed = true; return retval;}
								NoViableAltException nvae_d9s4 =
									new NoViableAltException("", 9, 4, input);

								throw nvae_d9s4;
							}
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d9s3 =
								new NoViableAltException("", 9, 3, input);

							throw nvae_d9s3;
						}
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d9s1 =
							new NoViableAltException("", 9, 1, input);

						throw nvae_d9s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d9s0 =
						new NoViableAltException("", 9, 0, input);

					throw nvae_d9s0;
				}
				switch (alt9) 
				{
				case 1 :
					// Java.g:337:9: 'import' ( 'static' )? IDENTIFIER '.' '*' ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal8=(IToken)Match(input,IMPORT,FOLLOW_IMPORT_in_importDeclaration275); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal8_tree = (object)adaptor.Create(string_literal8, retval);
						adaptor.AddChild(root_0, string_literal8_tree);
					}
					// Java.g:338:9: ( 'static' )?
					int alt5 = 2;
					int LA5_0 = input.LA(1);

					if ( (LA5_0 == STATIC) )
					{
						alt5 = 1;
					}
					switch (alt5) 
					{
					case 1 :
						// Java.g:338:10: 'static'
					{
						string_literal9=(IToken)Match(input,STATIC,FOLLOW_STATIC_in_importDeclaration287); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal9_tree = (object)adaptor.Create(string_literal9, retval);
							adaptor.AddChild(root_0, string_literal9_tree);
						}

					}
						break;

					}

					IDENTIFIER10=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_importDeclaration308); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER10_tree = (object)adaptor.Create(IDENTIFIER10, retval);
						adaptor.AddChild(root_0, IDENTIFIER10_tree);
					}
					char_literal11=(IToken)Match(input,DOT,FOLLOW_DOT_in_importDeclaration310); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal11_tree = (object)adaptor.Create(char_literal11, retval);
						adaptor.AddChild(root_0, char_literal11_tree);
					}
					char_literal12=(IToken)Match(input,STAR,FOLLOW_STAR_in_importDeclaration312); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal12_tree = (object)adaptor.Create(char_literal12, retval);
						adaptor.AddChild(root_0, char_literal12_tree);
					}
					char_literal13=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_importDeclaration322); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal13_tree = (object)adaptor.Create(char_literal13, retval);
						adaptor.AddChild(root_0, char_literal13_tree);
					}

				}
					break;
				case 2 :
					// Java.g:342:9: 'import' ( 'static' )? IDENTIFIER ( '.' IDENTIFIER )+ ( '.' '*' )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal14=(IToken)Match(input,IMPORT,FOLLOW_IMPORT_in_importDeclaration339); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal14_tree = (object)adaptor.Create(string_literal14, retval);
						adaptor.AddChild(root_0, string_literal14_tree);
					}
					// Java.g:343:9: ( 'static' )?
					int alt6 = 2;
					int LA6_0 = input.LA(1);

					if ( (LA6_0 == STATIC) )
					{
						alt6 = 1;
					}
					switch (alt6) 
					{
					case 1 :
						// Java.g:343:10: 'static'
					{
						string_literal15=(IToken)Match(input,STATIC,FOLLOW_STATIC_in_importDeclaration351); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal15_tree = (object)adaptor.Create(string_literal15, retval);
							adaptor.AddChild(root_0, string_literal15_tree);
						}

					}
						break;

					}

					IDENTIFIER16=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_importDeclaration372); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER16_tree = (object)adaptor.Create(IDENTIFIER16, retval);
						adaptor.AddChild(root_0, IDENTIFIER16_tree);
					}
					// Java.g:346:9: ( '.' IDENTIFIER )+
					int cnt7 = 0;
					do 
					{
						int alt7 = 2;
						int LA7_0 = input.LA(1);

						if ( (LA7_0 == DOT) )
						{
							int LA7_1 = input.LA(2);

							if ( (LA7_1 == IDENTIFIER) )
							{
								alt7 = 1;
							}


						}


						switch (alt7) 
						{
						case 1 :
							// Java.g:346:10: '.' IDENTIFIER
						{
							char_literal17=(IToken)Match(input,DOT,FOLLOW_DOT_in_importDeclaration383); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal17_tree = (object)adaptor.Create(char_literal17, retval);
								adaptor.AddChild(root_0, char_literal17_tree);
							}
							IDENTIFIER18=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_importDeclaration385); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER18_tree = (object)adaptor.Create(IDENTIFIER18, retval);
								adaptor.AddChild(root_0, IDENTIFIER18_tree);
							}

						}
							break;

						default:
							if ( cnt7 >= 1 ) goto loop7;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee7 =
								new EarlyExitException(7, input);
							throw eee7;
						}
						cnt7++;
					} while (true);

					loop7:
					;	// Stops C# compiler whining that label 'loop7' has no statements

					// Java.g:348:9: ( '.' '*' )?
					int alt8 = 2;
					int LA8_0 = input.LA(1);

					if ( (LA8_0 == DOT) )
					{
						alt8 = 1;
					}
					switch (alt8) 
					{
					case 1 :
						// Java.g:348:10: '.' '*'
					{
						char_literal19=(IToken)Match(input,DOT,FOLLOW_DOT_in_importDeclaration407); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal19_tree = (object)adaptor.Create(char_literal19, retval);
							adaptor.AddChild(root_0, char_literal19_tree);
						}
						char_literal20=(IToken)Match(input,STAR,FOLLOW_STAR_in_importDeclaration409); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal20_tree = (object)adaptor.Create(char_literal20, retval);
							adaptor.AddChild(root_0, char_literal20_tree);
						}

					}
						break;

					}

					char_literal21=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_importDeclaration430); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal21_tree = (object)adaptor.Create(char_literal21, retval);
						adaptor.AddChild(root_0, char_literal21_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 3, importDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "importDeclaration"

		public class qualifiedImportName_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "qualifiedImportName"
		// Java.g:353:1: qualifiedImportName : IDENTIFIER ( '.' IDENTIFIER )* ;
		public JavaParser.qualifiedImportName_return qualifiedImportName() // throws RecognitionException [1]
		{   
			JavaParser.qualifiedImportName_return retval = new JavaParser.qualifiedImportName_return();
			retval.Start = input.LT(1);
			int qualifiedImportName_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER22 = null;
			IToken char_literal23 = null;
			IToken IDENTIFIER24 = null;

			object IDENTIFIER22_tree=null;
			object char_literal23_tree=null;
			object IDENTIFIER24_tree=null;

			const string elementName = "qualifiedImportName"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
				{
					return retval; 
				}
				// Java.g:356:5: ( IDENTIFIER ( '.' IDENTIFIER )* )
				// Java.g:356:9: IDENTIFIER ( '.' IDENTIFIER )*
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER22=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_qualifiedImportName459); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER22_tree = (object)adaptor.Create(IDENTIFIER22, retval);
						adaptor.AddChild(root_0, IDENTIFIER22_tree);
					}
					// Java.g:357:9: ( '.' IDENTIFIER )*
					do 
					{
						int alt10 = 2;
						int LA10_0 = input.LA(1);

						if ( (LA10_0 == DOT) )
						{
							alt10 = 1;
						}


						switch (alt10) 
						{
						case 1 :
							// Java.g:357:10: '.' IDENTIFIER
						{
							char_literal23=(IToken)Match(input,DOT,FOLLOW_DOT_in_qualifiedImportName470); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal23_tree = (object)adaptor.Create(char_literal23, retval);
								adaptor.AddChild(root_0, char_literal23_tree);
							}
							IDENTIFIER24=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_qualifiedImportName472); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER24_tree = (object)adaptor.Create(IDENTIFIER24, retval);
								adaptor.AddChild(root_0, IDENTIFIER24_tree);
							}

						}
							break;

						default:
							goto loop10;
						}
					} while (true);

					loop10:
					;	// Stops C# compiler whining that label 'loop10' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 4, qualifiedImportName_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "qualifiedImportName"

		public class typeDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeDeclaration"
		// Java.g:361:1: typeDeclaration : ( classOrInterfaceDeclaration | ';' );
		public JavaParser.typeDeclaration_return typeDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.typeDeclaration_return retval = new JavaParser.typeDeclaration_return();
			retval.Start = input.LT(1);
			int typeDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal26 = null;
			JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration25 = default(JavaParser.classOrInterfaceDeclaration_return);


			object char_literal26_tree=null;

			const string elementName = "typeDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
				{
					return retval; 
				}
				// Java.g:364:5: ( classOrInterfaceDeclaration | ';' )
				int alt11 = 2;
				int LA11_0 = input.LA(1);

				if ( (LA11_0 == IDENTIFIER || LA11_0 == ABSTRACT || LA11_0 == BOOLEAN || LA11_0 == BYTE || (LA11_0 >= CHAR && LA11_0 <= CLASS) || LA11_0 == DOUBLE || LA11_0 == ENUM || LA11_0 == FINAL || LA11_0 == FLOAT || (LA11_0 >= INT && LA11_0 <= NATIVE) || (LA11_0 >= PRIVATE && LA11_0 <= PUBLIC) || (LA11_0 >= SHORT && LA11_0 <= STRICTFP) || LA11_0 == SYNCHRONIZED || LA11_0 == TRANSIENT || (LA11_0 >= VOID && LA11_0 <= VOLATILE) || LA11_0 == MONKEYS_AT || LA11_0 == LT) )
				{
					alt11 = 1;
				}
				else if ( (LA11_0 == SEMI) )
				{
					alt11 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d11s0 =
						new NoViableAltException("", 11, 0, input);

					throw nvae_d11s0;
				}
				switch (alt11) 
				{
				case 1 :
					// Java.g:364:9: classOrInterfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classOrInterfaceDeclaration_in_typeDeclaration512);
					classOrInterfaceDeclaration25 = classOrInterfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceDeclaration25.Tree, classOrInterfaceDeclaration25, retval);

				}
					break;
				case 2 :
					// Java.g:365:9: ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal26=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_typeDeclaration522); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal26_tree = (object)adaptor.Create(char_literal26, retval);
						adaptor.AddChild(root_0, char_literal26_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 5, typeDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeDeclaration"

		public class classOrInterfaceDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classOrInterfaceDeclaration"
		// Java.g:368:1: classOrInterfaceDeclaration : ( classDeclaration | interfaceDeclaration );
		public JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.classOrInterfaceDeclaration_return retval = new JavaParser.classOrInterfaceDeclaration_return();
			retval.Start = input.LT(1);
			int classOrInterfaceDeclaration_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.classDeclaration_return classDeclaration27 = default(JavaParser.classDeclaration_return);

			JavaParser.interfaceDeclaration_return interfaceDeclaration28 = default(JavaParser.interfaceDeclaration_return);



			const string elementName = "classOrInterfaceDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
				{
					return retval; 
				}
				// Java.g:371:5: ( classDeclaration | interfaceDeclaration )
				int alt12 = 2;
				alt12 = dfa12.Predict(input);
				switch (alt12) 
				{
				case 1 :
					// Java.g:371:10: classDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classDeclaration_in_classOrInterfaceDeclaration552);
					classDeclaration27 = classDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classDeclaration27.Tree, classDeclaration27, retval);

				}
					break;
				case 2 :
					// Java.g:372:9: interfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceDeclaration_in_classOrInterfaceDeclaration562);
					interfaceDeclaration28 = interfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceDeclaration28.Tree, interfaceDeclaration28, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 6, classOrInterfaceDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classOrInterfaceDeclaration"

		public class modifiers_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "modifiers"
		// Java.g:376:1: modifiers : ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )* ;
		public JavaParser.modifiers_return modifiers() // throws RecognitionException [1]
		{   
			JavaParser.modifiers_return retval = new JavaParser.modifiers_return();
			retval.Start = input.LT(1);
			int modifiers_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal30 = null;
			IToken string_literal31 = null;
			IToken string_literal32 = null;
			IToken string_literal33 = null;
			IToken string_literal34 = null;
			IToken string_literal35 = null;
			IToken string_literal36 = null;
			IToken string_literal37 = null;
			IToken string_literal38 = null;
			IToken string_literal39 = null;
			IToken string_literal40 = null;
			JavaParser.annotation_return annotation29 = default(JavaParser.annotation_return);


			object string_literal30_tree=null;
			object string_literal31_tree=null;
			object string_literal32_tree=null;
			object string_literal33_tree=null;
			object string_literal34_tree=null;
			object string_literal35_tree=null;
			object string_literal36_tree=null;
			object string_literal37_tree=null;
			object string_literal38_tree=null;
			object string_literal39_tree=null;
			object string_literal40_tree=null;

			const string elementName = "modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
				{
					return retval; 
				}
				// Java.g:379:5: ( ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )* )
				// Java.g:380:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:380:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*
					do 
					{
						int alt13 = 13;
						alt13 = dfa13.Predict(input);
						switch (alt13) 
						{
						case 1 :
							// Java.g:380:10: annotation
						{
							PushFollow(FOLLOW_annotation_in_modifiers605);
							annotation29 = annotation();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotation29.Tree, annotation29, retval);

						}
							break;
						case 2 :
							// Java.g:381:9: 'public'
						{
							string_literal30=(IToken)Match(input,PUBLIC,FOLLOW_PUBLIC_in_modifiers615); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal30_tree = (object)adaptor.Create(string_literal30, retval);
								adaptor.AddChild(root_0, string_literal30_tree);
							}

						}
							break;
						case 3 :
							// Java.g:382:9: 'protected'
						{
							string_literal31=(IToken)Match(input,PROTECTED,FOLLOW_PROTECTED_in_modifiers625); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal31_tree = (object)adaptor.Create(string_literal31, retval);
								adaptor.AddChild(root_0, string_literal31_tree);
							}

						}
							break;
						case 4 :
							// Java.g:383:9: 'private'
						{
							string_literal32=(IToken)Match(input,PRIVATE,FOLLOW_PRIVATE_in_modifiers635); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal32_tree = (object)adaptor.Create(string_literal32, retval);
								adaptor.AddChild(root_0, string_literal32_tree);
							}

						}
							break;
						case 5 :
							// Java.g:384:9: 'static'
						{
							string_literal33=(IToken)Match(input,STATIC,FOLLOW_STATIC_in_modifiers645); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal33_tree = (object)adaptor.Create(string_literal33, retval);
								adaptor.AddChild(root_0, string_literal33_tree);
							}

						}
							break;
						case 6 :
							// Java.g:385:9: 'abstract'
						{
							string_literal34=(IToken)Match(input,ABSTRACT,FOLLOW_ABSTRACT_in_modifiers655); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal34_tree = (object)adaptor.Create(string_literal34, retval);
								adaptor.AddChild(root_0, string_literal34_tree);
							}

						}
							break;
						case 7 :
							// Java.g:386:9: 'final'
						{
							string_literal35=(IToken)Match(input,FINAL,FOLLOW_FINAL_in_modifiers665); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal35_tree = (object)adaptor.Create(string_literal35, retval);
								adaptor.AddChild(root_0, string_literal35_tree);
							}

						}
							break;
						case 8 :
							// Java.g:387:9: 'native'
						{
							string_literal36=(IToken)Match(input,NATIVE,FOLLOW_NATIVE_in_modifiers675); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal36_tree = (object)adaptor.Create(string_literal36, retval);
								adaptor.AddChild(root_0, string_literal36_tree);
							}

						}
							break;
						case 9 :
							// Java.g:388:9: 'synchronized'
						{
							string_literal37=(IToken)Match(input,SYNCHRONIZED,FOLLOW_SYNCHRONIZED_in_modifiers685); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal37_tree = (object)adaptor.Create(string_literal37, retval);
								adaptor.AddChild(root_0, string_literal37_tree);
							}

						}
							break;
						case 10 :
							// Java.g:389:9: 'transient'
						{
							string_literal38=(IToken)Match(input,TRANSIENT,FOLLOW_TRANSIENT_in_modifiers695); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal38_tree = (object)adaptor.Create(string_literal38, retval);
								adaptor.AddChild(root_0, string_literal38_tree);
							}

						}
							break;
						case 11 :
							// Java.g:390:9: 'volatile'
						{
							string_literal39=(IToken)Match(input,VOLATILE,FOLLOW_VOLATILE_in_modifiers705); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal39_tree = (object)adaptor.Create(string_literal39, retval);
								adaptor.AddChild(root_0, string_literal39_tree);
							}

						}
							break;
						case 12 :
							// Java.g:391:9: 'strictfp'
						{
							string_literal40=(IToken)Match(input,STRICTFP,FOLLOW_STRICTFP_in_modifiers715); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal40_tree = (object)adaptor.Create(string_literal40, retval);
								adaptor.AddChild(root_0, string_literal40_tree);
							}

						}
							break;

						default:
							goto loop13;
						}
					} while (true);

					loop13:
					;	// Stops C# compiler whining that label 'loop13' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 7, modifiers_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "modifiers"

		public class variableModifiers_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "variableModifiers"
		// Java.g:396:1: variableModifiers : ( 'final' | annotation )* ;
		public JavaParser.variableModifiers_return variableModifiers() // throws RecognitionException [1]
		{   
			JavaParser.variableModifiers_return retval = new JavaParser.variableModifiers_return();
			retval.Start = input.LT(1);
			int variableModifiers_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal41 = null;
			JavaParser.annotation_return annotation42 = default(JavaParser.annotation_return);


			object string_literal41_tree=null;

			const string elementName = "variableModifiers"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
				{
					return retval; 
				}
				// Java.g:399:5: ( ( 'final' | annotation )* )
				// Java.g:399:9: ( 'final' | annotation )*
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:399:9: ( 'final' | annotation )*
					do 
					{
						int alt14 = 3;
						int LA14_0 = input.LA(1);

						if ( (LA14_0 == FINAL) )
						{
							alt14 = 1;
						}
						else if ( (LA14_0 == MONKEYS_AT) )
						{
							alt14 = 2;
						}


						switch (alt14) 
						{
						case 1 :
							// Java.g:399:13: 'final'
						{
							string_literal41=(IToken)Match(input,FINAL,FOLLOW_FINAL_in_variableModifiers756); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal41_tree = (object)adaptor.Create(string_literal41, retval);
								adaptor.AddChild(root_0, string_literal41_tree);
							}

						}
							break;
						case 2 :
							// Java.g:400:13: annotation
						{
							PushFollow(FOLLOW_annotation_in_variableModifiers770);
							annotation42 = annotation();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotation42.Tree, annotation42, retval);

						}
							break;

						default:
							goto loop14;
						}
					} while (true);

					loop14:
					;	// Stops C# compiler whining that label 'loop14' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 8, variableModifiers_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "variableModifiers"

		public class classDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classDeclaration"
		// Java.g:405:1: classDeclaration : ( normalClassDeclaration | enumDeclaration );
		public JavaParser.classDeclaration_return classDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.classDeclaration_return retval = new JavaParser.classDeclaration_return();
			retval.Start = input.LT(1);
			int classDeclaration_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.normalClassDeclaration_return normalClassDeclaration43 = default(JavaParser.normalClassDeclaration_return);

			JavaParser.enumDeclaration_return enumDeclaration44 = default(JavaParser.enumDeclaration_return);



			const string elementName = "classDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
				{
					return retval; 
				}
				// Java.g:408:5: ( normalClassDeclaration | enumDeclaration )
				int alt15 = 2;
				alt15 = dfa15.Predict(input);
				switch (alt15) 
				{
				case 1 :
					// Java.g:408:9: normalClassDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_normalClassDeclaration_in_classDeclaration815);
					normalClassDeclaration43 = normalClassDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalClassDeclaration43.Tree, normalClassDeclaration43, retval);

				}
					break;
				case 2 :
					// Java.g:409:9: enumDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_enumDeclaration_in_classDeclaration825);
					enumDeclaration44 = enumDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumDeclaration44.Tree, enumDeclaration44, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 9, classDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classDeclaration"

		public class normalClassDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "normalClassDeclaration"
		// Java.g:412:1: normalClassDeclaration : modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody ;
		public JavaParser.normalClassDeclaration_return normalClassDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.normalClassDeclaration_return retval = new JavaParser.normalClassDeclaration_return();
			retval.Start = input.LT(1);
			int normalClassDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal46 = null;
			IToken IDENTIFIER47 = null;
			IToken string_literal49 = null;
			IToken string_literal51 = null;
			JavaParser.modifiers_return modifiers45 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters48 = default(JavaParser.typeParameters_return);

			JavaParser.type_return type50 = default(JavaParser.type_return);

			JavaParser.typeList_return typeList52 = default(JavaParser.typeList_return);

			JavaParser.classBody_return classBody53 = default(JavaParser.classBody_return);


			object string_literal46_tree=null;
			object IDENTIFIER47_tree=null;
			object string_literal49_tree=null;
			object string_literal51_tree=null;

			const string elementName = "normalClassDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
				{
					return retval; 
				}
				// Java.g:415:5: ( modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody )
				// Java.g:415:9: modifiers 'class' IDENTIFIER ( typeParameters )? ( 'extends' type )? ( 'implements' typeList )? classBody
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_normalClassDeclaration854);
					modifiers45 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers45.Tree, modifiers45, retval);
					string_literal46=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_normalClassDeclaration857); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal46_tree = (object)adaptor.Create(string_literal46, retval);
						adaptor.AddChild(root_0, string_literal46_tree);
					}
					IDENTIFIER47=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_normalClassDeclaration859); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER47_tree = (object)adaptor.Create(IDENTIFIER47, retval);
						adaptor.AddChild(root_0, IDENTIFIER47_tree);
					}
					// Java.g:416:9: ( typeParameters )?
					int alt16 = 2;
					int LA16_0 = input.LA(1);

					if ( (LA16_0 == LT) )
					{
						alt16 = 1;
					}
					switch (alt16) 
					{
					case 1 :
						// Java.g:416:10: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_normalClassDeclaration870);
						typeParameters48 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters48.Tree, typeParameters48, retval);

					}
						break;

					}

					// Java.g:418:9: ( 'extends' type )?
					int alt17 = 2;
					int LA17_0 = input.LA(1);

					if ( (LA17_0 == EXTENDS) )
					{
						alt17 = 1;
					}
					switch (alt17) 
					{
					case 1 :
						// Java.g:418:10: 'extends' type
					{
						string_literal49=(IToken)Match(input,EXTENDS,FOLLOW_EXTENDS_in_normalClassDeclaration892); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal49_tree = (object)adaptor.Create(string_literal49, retval);
							adaptor.AddChild(root_0, string_literal49_tree);
						}
						PushFollow(FOLLOW_type_in_normalClassDeclaration894);
						type50 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type50.Tree, type50, retval);

					}
						break;

					}

					// Java.g:420:9: ( 'implements' typeList )?
					int alt18 = 2;
					int LA18_0 = input.LA(1);

					if ( (LA18_0 == IMPLEMENTS) )
					{
						alt18 = 1;
					}
					switch (alt18) 
					{
					case 1 :
						// Java.g:420:10: 'implements' typeList
					{
						string_literal51=(IToken)Match(input,IMPLEMENTS,FOLLOW_IMPLEMENTS_in_normalClassDeclaration916); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal51_tree = (object)adaptor.Create(string_literal51, retval);
							adaptor.AddChild(root_0, string_literal51_tree);
						}
						PushFollow(FOLLOW_typeList_in_normalClassDeclaration918);
						typeList52 = typeList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeList52.Tree, typeList52, retval);

					}
						break;

					}

					PushFollow(FOLLOW_classBody_in_normalClassDeclaration951);
					classBody53 = classBody();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classBody53.Tree, classBody53, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 10, normalClassDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "normalClassDeclaration"

		public class typeParameters_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeParameters"
		// Java.g:426:1: typeParameters : '<' typeParameter ( ',' typeParameter )* '>' ;
		public JavaParser.typeParameters_return typeParameters() // throws RecognitionException [1]
		{   
			JavaParser.typeParameters_return retval = new JavaParser.typeParameters_return();
			retval.Start = input.LT(1);
			int typeParameters_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal54 = null;
			IToken char_literal56 = null;
			IToken char_literal58 = null;
			JavaParser.typeParameter_return typeParameter55 = default(JavaParser.typeParameter_return);

			JavaParser.typeParameter_return typeParameter57 = default(JavaParser.typeParameter_return);


			object char_literal54_tree=null;
			object char_literal56_tree=null;
			object char_literal58_tree=null;

			const string elementName = "typeParameters"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
				{
					return retval; 
				}
				// Java.g:429:5: ( '<' typeParameter ( ',' typeParameter )* '>' )
				// Java.g:429:9: '<' typeParameter ( ',' typeParameter )* '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal54=(IToken)Match(input,LT,FOLLOW_LT_in_typeParameters981); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal54_tree = (object)adaptor.Create(char_literal54, retval);
						adaptor.AddChild(root_0, char_literal54_tree);
					}
					PushFollow(FOLLOW_typeParameter_in_typeParameters995);
					typeParameter55 = typeParameter();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameter55.Tree, typeParameter55, retval);
					// Java.g:431:13: ( ',' typeParameter )*
					do 
					{
						int alt19 = 2;
						int LA19_0 = input.LA(1);

						if ( (LA19_0 == COMMA) )
						{
							alt19 = 1;
						}


						switch (alt19) 
						{
						case 1 :
							// Java.g:431:14: ',' typeParameter
						{
							char_literal56=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_typeParameters1010); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal56_tree = (object)adaptor.Create(char_literal56, retval);
								adaptor.AddChild(root_0, char_literal56_tree);
							}
							PushFollow(FOLLOW_typeParameter_in_typeParameters1012);
							typeParameter57 = typeParameter();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameter57.Tree, typeParameter57, retval);

						}
							break;

						default:
							goto loop19;
						}
					} while (true);

					loop19:
					;	// Stops C# compiler whining that label 'loop19' has no statements

					char_literal58=(IToken)Match(input,GT,FOLLOW_GT_in_typeParameters1037); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal58_tree = (object)adaptor.Create(char_literal58, retval);
						adaptor.AddChild(root_0, char_literal58_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 11, typeParameters_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeParameters"

		public class typeParameter_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeParameter"
		// Java.g:436:1: typeParameter : IDENTIFIER ( 'extends' typeBound )? ;
		public JavaParser.typeParameter_return typeParameter() // throws RecognitionException [1]
		{   
			JavaParser.typeParameter_return retval = new JavaParser.typeParameter_return();
			retval.Start = input.LT(1);
			int typeParameter_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER59 = null;
			IToken string_literal60 = null;
			JavaParser.typeBound_return typeBound61 = default(JavaParser.typeBound_return);


			object IDENTIFIER59_tree=null;
			object string_literal60_tree=null;

			const string elementName = "typeParameter"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
				{
					return retval; 
				}
				// Java.g:439:5: ( IDENTIFIER ( 'extends' typeBound )? )
				// Java.g:439:9: IDENTIFIER ( 'extends' typeBound )?
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER59=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_typeParameter1066); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER59_tree = (object)adaptor.Create(IDENTIFIER59, retval);
						adaptor.AddChild(root_0, IDENTIFIER59_tree);
					}
					// Java.g:440:9: ( 'extends' typeBound )?
					int alt20 = 2;
					int LA20_0 = input.LA(1);

					if ( (LA20_0 == EXTENDS) )
					{
						alt20 = 1;
					}
					switch (alt20) 
					{
					case 1 :
						// Java.g:440:10: 'extends' typeBound
					{
						string_literal60=(IToken)Match(input,EXTENDS,FOLLOW_EXTENDS_in_typeParameter1077); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal60_tree = (object)adaptor.Create(string_literal60, retval);
							adaptor.AddChild(root_0, string_literal60_tree);
						}
						PushFollow(FOLLOW_typeBound_in_typeParameter1079);
						typeBound61 = typeBound();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeBound61.Tree, typeBound61, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 12, typeParameter_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeParameter"

		public class typeBound_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeBound"
		// Java.g:445:1: typeBound : type ( '&' type )* ;
		public JavaParser.typeBound_return typeBound() // throws RecognitionException [1]
		{   
			JavaParser.typeBound_return retval = new JavaParser.typeBound_return();
			retval.Start = input.LT(1);
			int typeBound_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal63 = null;
			JavaParser.type_return type62 = default(JavaParser.type_return);

			JavaParser.type_return type64 = default(JavaParser.type_return);


			object char_literal63_tree=null;

			const string elementName = "typeBound"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
				{
					return retval; 
				}
				// Java.g:448:5: ( type ( '&' type )* )
				// Java.g:448:9: type ( '&' type )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_type_in_typeBound1120);
					type62 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type62.Tree, type62, retval);
					// Java.g:449:9: ( '&' type )*
					do 
					{
						int alt21 = 2;
						int LA21_0 = input.LA(1);

						if ( (LA21_0 == AMP) )
						{
							alt21 = 1;
						}


						switch (alt21) 
						{
						case 1 :
							// Java.g:449:10: '&' type
						{
							char_literal63=(IToken)Match(input,AMP,FOLLOW_AMP_in_typeBound1131); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal63_tree = (object)adaptor.Create(char_literal63, retval);
								adaptor.AddChild(root_0, char_literal63_tree);
							}
							PushFollow(FOLLOW_type_in_typeBound1133);
							type64 = type();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type64.Tree, type64, retval);

						}
							break;

						default:
							goto loop21;
						}
					} while (true);

					loop21:
					;	// Stops C# compiler whining that label 'loop21' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 13, typeBound_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeBound"

		public class enumDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumDeclaration"
		// Java.g:454:1: enumDeclaration : modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody ;
		public JavaParser.enumDeclaration_return enumDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.enumDeclaration_return retval = new JavaParser.enumDeclaration_return();
			retval.Start = input.LT(1);
			int enumDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal66 = null;
			IToken IDENTIFIER67 = null;
			IToken string_literal68 = null;
			JavaParser.modifiers_return modifiers65 = default(JavaParser.modifiers_return);

			JavaParser.typeList_return typeList69 = default(JavaParser.typeList_return);

			JavaParser.enumBody_return enumBody70 = default(JavaParser.enumBody_return);


			object string_literal66_tree=null;
			object IDENTIFIER67_tree=null;
			object string_literal68_tree=null;

			const string elementName = "enumDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
				{
					return retval; 
				}
				// Java.g:457:5: ( modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody )
				// Java.g:457:9: modifiers ( 'enum' ) IDENTIFIER ( 'implements' typeList )? enumBody
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_enumDeclaration1174);
					modifiers65 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers65.Tree, modifiers65, retval);
					// Java.g:458:9: ( 'enum' )
					// Java.g:458:10: 'enum'
					{
						string_literal66=(IToken)Match(input,ENUM,FOLLOW_ENUM_in_enumDeclaration1186); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal66_tree = (object)adaptor.Create(string_literal66, retval);
							adaptor.AddChild(root_0, string_literal66_tree);
						}

					}

					IDENTIFIER67=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enumDeclaration1207); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER67_tree = (object)adaptor.Create(IDENTIFIER67, retval);
						adaptor.AddChild(root_0, IDENTIFIER67_tree);
					}
					// Java.g:461:9: ( 'implements' typeList )?
					int alt22 = 2;
					int LA22_0 = input.LA(1);

					if ( (LA22_0 == IMPLEMENTS) )
					{
						alt22 = 1;
					}
					switch (alt22) 
					{
					case 1 :
						// Java.g:461:10: 'implements' typeList
					{
						string_literal68=(IToken)Match(input,IMPLEMENTS,FOLLOW_IMPLEMENTS_in_enumDeclaration1218); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal68_tree = (object)adaptor.Create(string_literal68, retval);
							adaptor.AddChild(root_0, string_literal68_tree);
						}
						PushFollow(FOLLOW_typeList_in_enumDeclaration1220);
						typeList69 = typeList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeList69.Tree, typeList69, retval);

					}
						break;

					}

					PushFollow(FOLLOW_enumBody_in_enumDeclaration1241);
					enumBody70 = enumBody();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumBody70.Tree, enumBody70, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 14, enumDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumDeclaration"

		public class enumBody_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumBody"
		// Java.g:467:1: enumBody : '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}' ;
		public JavaParser.enumBody_return enumBody() // throws RecognitionException [1]
		{   
			JavaParser.enumBody_return retval = new JavaParser.enumBody_return();
			retval.Start = input.LT(1);
			int enumBody_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal71 = null;
			IToken char_literal73 = null;
			IToken char_literal75 = null;
			JavaParser.enumConstants_return enumConstants72 = default(JavaParser.enumConstants_return);

			JavaParser.enumBodyDeclarations_return enumBodyDeclarations74 = default(JavaParser.enumBodyDeclarations_return);


			object char_literal71_tree=null;
			object char_literal73_tree=null;
			object char_literal75_tree=null;

			const string elementName = "enumBody"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
				{
					return retval; 
				}
				// Java.g:470:5: ( '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}' )
				// Java.g:470:9: '{' ( enumConstants )? ( ',' )? ( enumBodyDeclarations )? '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal71=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_enumBody1275); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal71_tree = (object)adaptor.Create(char_literal71, retval);
						adaptor.AddChild(root_0, char_literal71_tree);
					}
					// Java.g:471:9: ( enumConstants )?
					int alt23 = 2;
					int LA23_0 = input.LA(1);

					if ( (LA23_0 == IDENTIFIER || LA23_0 == MONKEYS_AT) )
					{
						alt23 = 1;
					}
					switch (alt23) 
					{
					case 1 :
						// Java.g:471:10: enumConstants
					{
						PushFollow(FOLLOW_enumConstants_in_enumBody1286);
						enumConstants72 = enumConstants();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumConstants72.Tree, enumConstants72, retval);

					}
						break;

					}

					// Java.g:473:9: ( ',' )?
					int alt24 = 2;
					int LA24_0 = input.LA(1);

					if ( (LA24_0 == COMMA) )
					{
						alt24 = 1;
					}
					switch (alt24) 
					{
					case 1 :
						// Java.g:0:0: ','
					{
						char_literal73=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_enumBody1308); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal73_tree = (object)adaptor.Create(char_literal73, retval);
							adaptor.AddChild(root_0, char_literal73_tree);
						}

					}
						break;

					}

					// Java.g:474:9: ( enumBodyDeclarations )?
					int alt25 = 2;
					int LA25_0 = input.LA(1);

					if ( (LA25_0 == SEMI) )
					{
						alt25 = 1;
					}
					switch (alt25) 
					{
					case 1 :
						// Java.g:474:10: enumBodyDeclarations
					{
						PushFollow(FOLLOW_enumBodyDeclarations_in_enumBody1321);
						enumBodyDeclarations74 = enumBodyDeclarations();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumBodyDeclarations74.Tree, enumBodyDeclarations74, retval);

					}
						break;

					}

					char_literal75=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_enumBody1343); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal75_tree = (object)adaptor.Create(char_literal75, retval);
						adaptor.AddChild(root_0, char_literal75_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 15, enumBody_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumBody"

		public class enumConstants_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumConstants"
		// Java.g:479:1: enumConstants : enumConstant ( ',' enumConstant )* ;
		public JavaParser.enumConstants_return enumConstants() // throws RecognitionException [1]
		{   
			JavaParser.enumConstants_return retval = new JavaParser.enumConstants_return();
			retval.Start = input.LT(1);
			int enumConstants_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal77 = null;
			JavaParser.enumConstant_return enumConstant76 = default(JavaParser.enumConstant_return);

			JavaParser.enumConstant_return enumConstant78 = default(JavaParser.enumConstant_return);


			object char_literal77_tree=null;

			const string elementName = "enumConstants"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
				{
					return retval; 
				}
				// Java.g:482:5: ( enumConstant ( ',' enumConstant )* )
				// Java.g:482:9: enumConstant ( ',' enumConstant )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_enumConstant_in_enumConstants1372);
					enumConstant76 = enumConstant();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumConstant76.Tree, enumConstant76, retval);
					// Java.g:483:9: ( ',' enumConstant )*
					do 
					{
						int alt26 = 2;
						int LA26_0 = input.LA(1);

						if ( (LA26_0 == COMMA) )
						{
							int LA26_1 = input.LA(2);

							if ( (LA26_1 == IDENTIFIER || LA26_1 == MONKEYS_AT) )
							{
								alt26 = 1;
							}


						}


						switch (alt26) 
						{
						case 1 :
							// Java.g:483:10: ',' enumConstant
						{
							char_literal77=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_enumConstants1383); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal77_tree = (object)adaptor.Create(char_literal77, retval);
								adaptor.AddChild(root_0, char_literal77_tree);
							}
							PushFollow(FOLLOW_enumConstant_in_enumConstants1385);
							enumConstant78 = enumConstant();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumConstant78.Tree, enumConstant78, retval);

						}
							break;

						default:
							goto loop26;
						}
					} while (true);

					loop26:
					;	// Stops C# compiler whining that label 'loop26' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 16, enumConstants_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumConstants"

		public class enumConstant_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumConstant"
		// Java.g:487:1: enumConstant : ( annotations )? IDENTIFIER ( arguments )? ( classBody )? ;
		public JavaParser.enumConstant_return enumConstant() // throws RecognitionException [1]
		{   
			JavaParser.enumConstant_return retval = new JavaParser.enumConstant_return();
			retval.Start = input.LT(1);
			int enumConstant_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER80 = null;
			JavaParser.annotations_return annotations79 = default(JavaParser.annotations_return);

			JavaParser.arguments_return arguments81 = default(JavaParser.arguments_return);

			JavaParser.classBody_return classBody82 = default(JavaParser.classBody_return);


			object IDENTIFIER80_tree=null;

			const string elementName = "enumConstant"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
				{
					return retval; 
				}
				// Java.g:494:5: ( ( annotations )? IDENTIFIER ( arguments )? ( classBody )? )
				// Java.g:494:9: ( annotations )? IDENTIFIER ( arguments )? ( classBody )?
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:494:9: ( annotations )?
					int alt27 = 2;
					int LA27_0 = input.LA(1);

					if ( (LA27_0 == MONKEYS_AT) )
					{
						alt27 = 1;
					}
					switch (alt27) 
					{
					case 1 :
						// Java.g:494:10: annotations
					{
						PushFollow(FOLLOW_annotations_in_enumConstant1428);
						annotations79 = annotations();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotations79.Tree, annotations79, retval);

					}
						break;

					}

					IDENTIFIER80=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enumConstant1449); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER80_tree = (object)adaptor.Create(IDENTIFIER80, retval);
						adaptor.AddChild(root_0, IDENTIFIER80_tree);
					}
					// Java.g:497:9: ( arguments )?
					int alt28 = 2;
					int LA28_0 = input.LA(1);

					if ( (LA28_0 == LPAREN) )
					{
						alt28 = 1;
					}
					switch (alt28) 
					{
					case 1 :
						// Java.g:497:10: arguments
					{
						PushFollow(FOLLOW_arguments_in_enumConstant1460);
						arguments81 = arguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments81.Tree, arguments81, retval);

					}
						break;

					}

					// Java.g:499:9: ( classBody )?
					int alt29 = 2;
					int LA29_0 = input.LA(1);

					if ( (LA29_0 == LBRACE) )
					{
						alt29 = 1;
					}
					switch (alt29) 
					{
					case 1 :
						// Java.g:499:10: classBody
					{
						PushFollow(FOLLOW_classBody_in_enumConstant1482);
						classBody82 = classBody();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classBody82.Tree, classBody82, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 17, enumConstant_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumConstant"

		public class enumBodyDeclarations_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumBodyDeclarations"
		// Java.g:505:1: enumBodyDeclarations : ';' ( classBodyDeclaration )* ;
		public JavaParser.enumBodyDeclarations_return enumBodyDeclarations() // throws RecognitionException [1]
		{   
			JavaParser.enumBodyDeclarations_return retval = new JavaParser.enumBodyDeclarations_return();
			retval.Start = input.LT(1);
			int enumBodyDeclarations_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal83 = null;
			JavaParser.classBodyDeclaration_return classBodyDeclaration84 = default(JavaParser.classBodyDeclaration_return);


			object char_literal83_tree=null;

			const string elementName = "enumBodyDeclarations"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
				{
					return retval; 
				}
				// Java.g:508:5: ( ';' ( classBodyDeclaration )* )
				// Java.g:508:9: ';' ( classBodyDeclaration )*
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal83=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_enumBodyDeclarations1532); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal83_tree = (object)adaptor.Create(char_literal83, retval);
						adaptor.AddChild(root_0, char_literal83_tree);
					}
					// Java.g:509:9: ( classBodyDeclaration )*
					do 
					{
						int alt30 = 2;
						int LA30_0 = input.LA(1);

						if ( (LA30_0 == IDENTIFIER || LA30_0 == ABSTRACT || LA30_0 == BOOLEAN || LA30_0 == BYTE || (LA30_0 >= CHAR && LA30_0 <= CLASS) || LA30_0 == DOUBLE || LA30_0 == ENUM || LA30_0 == FINAL || LA30_0 == FLOAT || (LA30_0 >= INT && LA30_0 <= NATIVE) || (LA30_0 >= PRIVATE && LA30_0 <= PUBLIC) || (LA30_0 >= SHORT && LA30_0 <= STRICTFP) || LA30_0 == SYNCHRONIZED || LA30_0 == TRANSIENT || (LA30_0 >= VOID && LA30_0 <= VOLATILE) || LA30_0 == LBRACE || LA30_0 == SEMI || LA30_0 == MONKEYS_AT || LA30_0 == LT) )
						{
							alt30 = 1;
						}


						switch (alt30) 
						{
						case 1 :
							// Java.g:509:10: classBodyDeclaration
						{
							PushFollow(FOLLOW_classBodyDeclaration_in_enumBodyDeclarations1544);
							classBodyDeclaration84 = classBodyDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classBodyDeclaration84.Tree, classBodyDeclaration84, retval);

						}
							break;

						default:
							goto loop30;
						}
					} while (true);

					loop30:
					;	// Stops C# compiler whining that label 'loop30' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 18, enumBodyDeclarations_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumBodyDeclarations"

		public class interfaceDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceDeclaration"
		// Java.g:513:1: interfaceDeclaration : ( normalInterfaceDeclaration | annotationTypeDeclaration );
		public JavaParser.interfaceDeclaration_return interfaceDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.interfaceDeclaration_return retval = new JavaParser.interfaceDeclaration_return();
			retval.Start = input.LT(1);
			int interfaceDeclaration_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration85 = default(JavaParser.normalInterfaceDeclaration_return);

			JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration86 = default(JavaParser.annotationTypeDeclaration_return);



			const string elementName = "interfaceDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
				{
					return retval; 
				}
				// Java.g:516:5: ( normalInterfaceDeclaration | annotationTypeDeclaration )
				int alt31 = 2;
				alt31 = dfa31.Predict(input);
				switch (alt31) 
				{
				case 1 :
					// Java.g:516:9: normalInterfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_normalInterfaceDeclaration_in_interfaceDeclaration1584);
					normalInterfaceDeclaration85 = normalInterfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalInterfaceDeclaration85.Tree, normalInterfaceDeclaration85, retval);

				}
					break;
				case 2 :
					// Java.g:517:9: annotationTypeDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_annotationTypeDeclaration_in_interfaceDeclaration1594);
					annotationTypeDeclaration86 = annotationTypeDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotationTypeDeclaration86.Tree, annotationTypeDeclaration86, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 19, interfaceDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceDeclaration"

		public class normalInterfaceDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "normalInterfaceDeclaration"
		// Java.g:520:1: normalInterfaceDeclaration : modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody ;
		public JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.normalInterfaceDeclaration_return retval = new JavaParser.normalInterfaceDeclaration_return();
			retval.Start = input.LT(1);
			int normalInterfaceDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal88 = null;
			IToken IDENTIFIER89 = null;
			IToken string_literal91 = null;
			JavaParser.modifiers_return modifiers87 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters90 = default(JavaParser.typeParameters_return);

			JavaParser.typeList_return typeList92 = default(JavaParser.typeList_return);

			JavaParser.interfaceBody_return interfaceBody93 = default(JavaParser.interfaceBody_return);


			object string_literal88_tree=null;
			object IDENTIFIER89_tree=null;
			object string_literal91_tree=null;

			const string elementName = "normalInterfaceDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 20) ) 
				{
					return retval; 
				}
				// Java.g:523:5: ( modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody )
				// Java.g:523:9: modifiers 'interface' IDENTIFIER ( typeParameters )? ( 'extends' typeList )? interfaceBody
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_normalInterfaceDeclaration1627);
					modifiers87 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers87.Tree, modifiers87, retval);
					string_literal88=(IToken)Match(input,INTERFACE,FOLLOW_INTERFACE_in_normalInterfaceDeclaration1629); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal88_tree = (object)adaptor.Create(string_literal88, retval);
						adaptor.AddChild(root_0, string_literal88_tree);
					}
					IDENTIFIER89=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_normalInterfaceDeclaration1631); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER89_tree = (object)adaptor.Create(IDENTIFIER89, retval);
						adaptor.AddChild(root_0, IDENTIFIER89_tree);
					}
					// Java.g:524:9: ( typeParameters )?
					int alt32 = 2;
					int LA32_0 = input.LA(1);

					if ( (LA32_0 == LT) )
					{
						alt32 = 1;
					}
					switch (alt32) 
					{
					case 1 :
						// Java.g:524:10: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_normalInterfaceDeclaration1642);
						typeParameters90 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters90.Tree, typeParameters90, retval);

					}
						break;

					}

					// Java.g:526:9: ( 'extends' typeList )?
					int alt33 = 2;
					int LA33_0 = input.LA(1);

					if ( (LA33_0 == EXTENDS) )
					{
						alt33 = 1;
					}
					switch (alt33) 
					{
					case 1 :
						// Java.g:526:10: 'extends' typeList
					{
						string_literal91=(IToken)Match(input,EXTENDS,FOLLOW_EXTENDS_in_normalInterfaceDeclaration1664); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal91_tree = (object)adaptor.Create(string_literal91, retval);
							adaptor.AddChild(root_0, string_literal91_tree);
						}
						PushFollow(FOLLOW_typeList_in_normalInterfaceDeclaration1666);
						typeList92 = typeList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeList92.Tree, typeList92, retval);

					}
						break;

					}

					PushFollow(FOLLOW_interfaceBody_in_normalInterfaceDeclaration1687);
					interfaceBody93 = interfaceBody();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceBody93.Tree, interfaceBody93, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 20, normalInterfaceDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "normalInterfaceDeclaration"

		public class typeList_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeList"
		// Java.g:531:1: typeList : type ( ',' type )* ;
		public JavaParser.typeList_return typeList() // throws RecognitionException [1]
		{   
			JavaParser.typeList_return retval = new JavaParser.typeList_return();
			retval.Start = input.LT(1);
			int typeList_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal95 = null;
			JavaParser.type_return type94 = default(JavaParser.type_return);

			JavaParser.type_return type96 = default(JavaParser.type_return);


			object char_literal95_tree=null;

			const string elementName = "typeList"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 21) ) 
				{
					return retval; 
				}
				// Java.g:534:5: ( type ( ',' type )* )
				// Java.g:534:9: type ( ',' type )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_type_in_typeList1716);
					type94 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type94.Tree, type94, retval);
					// Java.g:535:9: ( ',' type )*
					do 
					{
						int alt34 = 2;
						int LA34_0 = input.LA(1);

						if ( (LA34_0 == COMMA) )
						{
							alt34 = 1;
						}


						switch (alt34) 
						{
						case 1 :
							// Java.g:535:10: ',' type
						{
							char_literal95=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_typeList1727); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
								adaptor.AddChild(root_0, char_literal95_tree);
							}
							PushFollow(FOLLOW_type_in_typeList1729);
							type96 = type();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type96.Tree, type96, retval);

						}
							break;

						default:
							goto loop34;
						}
					} while (true);

					loop34:
					;	// Stops C# compiler whining that label 'loop34' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 21, typeList_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeList"

		public class classBody_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classBody"
		// Java.g:539:1: classBody : '{' ( classBodyDeclaration )* '}' ;
		public JavaParser.classBody_return classBody() // throws RecognitionException [1]
		{   
			JavaParser.classBody_return retval = new JavaParser.classBody_return();
			retval.Start = input.LT(1);
			int classBody_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal97 = null;
			IToken char_literal99 = null;
			JavaParser.classBodyDeclaration_return classBodyDeclaration98 = default(JavaParser.classBodyDeclaration_return);


			object char_literal97_tree=null;
			object char_literal99_tree=null;

			const string elementName = "classBody"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 22) ) 
				{
					return retval; 
				}
				// Java.g:542:5: ( '{' ( classBodyDeclaration )* '}' )
				// Java.g:542:9: '{' ( classBodyDeclaration )* '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal97=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_classBody1769); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal97_tree = (object)adaptor.Create(char_literal97, retval);
						adaptor.AddChild(root_0, char_literal97_tree);
					}
					// Java.g:543:9: ( classBodyDeclaration )*
					do 
					{
						int alt35 = 2;
						int LA35_0 = input.LA(1);

						if ( (LA35_0 == IDENTIFIER || LA35_0 == ABSTRACT || LA35_0 == BOOLEAN || LA35_0 == BYTE || (LA35_0 >= CHAR && LA35_0 <= CLASS) || LA35_0 == DOUBLE || LA35_0 == ENUM || LA35_0 == FINAL || LA35_0 == FLOAT || (LA35_0 >= INT && LA35_0 <= NATIVE) || (LA35_0 >= PRIVATE && LA35_0 <= PUBLIC) || (LA35_0 >= SHORT && LA35_0 <= STRICTFP) || LA35_0 == SYNCHRONIZED || LA35_0 == TRANSIENT || (LA35_0 >= VOID && LA35_0 <= VOLATILE) || LA35_0 == LBRACE || LA35_0 == SEMI || LA35_0 == MONKEYS_AT || LA35_0 == LT) )
						{
							alt35 = 1;
						}


						switch (alt35) 
						{
						case 1 :
							// Java.g:543:10: classBodyDeclaration
						{
							PushFollow(FOLLOW_classBodyDeclaration_in_classBody1781);
							classBodyDeclaration98 = classBodyDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classBodyDeclaration98.Tree, classBodyDeclaration98, retval);

						}
							break;

						default:
							goto loop35;
						}
					} while (true);

					loop35:
					;	// Stops C# compiler whining that label 'loop35' has no statements

					char_literal99=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_classBody1803); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal99_tree = (object)adaptor.Create(char_literal99, retval);
						adaptor.AddChild(root_0, char_literal99_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 22, classBody_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classBody"

		public class interfaceBody_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceBody"
		// Java.g:548:1: interfaceBody : '{' ( interfaceBodyDeclaration )* '}' ;
		public JavaParser.interfaceBody_return interfaceBody() // throws RecognitionException [1]
		{   
			JavaParser.interfaceBody_return retval = new JavaParser.interfaceBody_return();
			retval.Start = input.LT(1);
			int interfaceBody_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal100 = null;
			IToken char_literal102 = null;
			JavaParser.interfaceBodyDeclaration_return interfaceBodyDeclaration101 = default(JavaParser.interfaceBodyDeclaration_return);


			object char_literal100_tree=null;
			object char_literal102_tree=null;

			const string elementName = "interfaceBody"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 23) ) 
				{
					return retval; 
				}
				// Java.g:551:5: ( '{' ( interfaceBodyDeclaration )* '}' )
				// Java.g:551:9: '{' ( interfaceBodyDeclaration )* '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal100=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_interfaceBody1832); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal100_tree = (object)adaptor.Create(char_literal100, retval);
						adaptor.AddChild(root_0, char_literal100_tree);
					}
					// Java.g:552:9: ( interfaceBodyDeclaration )*
					do 
					{
						int alt36 = 2;
						int LA36_0 = input.LA(1);

						if ( (LA36_0 == IDENTIFIER || LA36_0 == ABSTRACT || LA36_0 == BOOLEAN || LA36_0 == BYTE || (LA36_0 >= CHAR && LA36_0 <= CLASS) || LA36_0 == DOUBLE || LA36_0 == ENUM || LA36_0 == FINAL || LA36_0 == FLOAT || (LA36_0 >= INT && LA36_0 <= NATIVE) || (LA36_0 >= PRIVATE && LA36_0 <= PUBLIC) || (LA36_0 >= SHORT && LA36_0 <= STRICTFP) || LA36_0 == SYNCHRONIZED || LA36_0 == TRANSIENT || (LA36_0 >= VOID && LA36_0 <= VOLATILE) || LA36_0 == SEMI || LA36_0 == MONKEYS_AT || LA36_0 == LT) )
						{
							alt36 = 1;
						}


						switch (alt36) 
						{
						case 1 :
							// Java.g:552:10: interfaceBodyDeclaration
						{
							PushFollow(FOLLOW_interfaceBodyDeclaration_in_interfaceBody1844);
							interfaceBodyDeclaration101 = interfaceBodyDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceBodyDeclaration101.Tree, interfaceBodyDeclaration101, retval);

						}
							break;

						default:
							goto loop36;
						}
					} while (true);

					loop36:
					;	// Stops C# compiler whining that label 'loop36' has no statements

					char_literal102=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_interfaceBody1866); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal102_tree = (object)adaptor.Create(char_literal102, retval);
						adaptor.AddChild(root_0, char_literal102_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 23, interfaceBody_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceBody"

		public class classBodyDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classBodyDeclaration"
		// Java.g:557:1: classBodyDeclaration : ( ';' | ( 'static' )? block | memberDecl );
		public JavaParser.classBodyDeclaration_return classBodyDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.classBodyDeclaration_return retval = new JavaParser.classBodyDeclaration_return();
			retval.Start = input.LT(1);
			int classBodyDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal103 = null;
			IToken string_literal104 = null;
			JavaParser.block_return block105 = default(JavaParser.block_return);

			JavaParser.memberDecl_return memberDecl106 = default(JavaParser.memberDecl_return);


			object char_literal103_tree=null;
			object string_literal104_tree=null;

			const string elementName = "classBodyDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 24) ) 
				{
					return retval; 
				}
				// Java.g:560:5: ( ';' | ( 'static' )? block | memberDecl )
				int alt38 = 3;
				switch ( input.LA(1) ) 
				{
				case SEMI:
				{
					alt38 = 1;
				}
					break;
				case STATIC:
				{
					int LA38_2 = input.LA(2);

					if ( (LA38_2 == IDENTIFIER || LA38_2 == ABSTRACT || LA38_2 == BOOLEAN || LA38_2 == BYTE || (LA38_2 >= CHAR && LA38_2 <= CLASS) || LA38_2 == DOUBLE || LA38_2 == ENUM || LA38_2 == FINAL || LA38_2 == FLOAT || (LA38_2 >= INT && LA38_2 <= NATIVE) || (LA38_2 >= PRIVATE && LA38_2 <= PUBLIC) || (LA38_2 >= SHORT && LA38_2 <= STRICTFP) || LA38_2 == SYNCHRONIZED || LA38_2 == TRANSIENT || (LA38_2 >= VOID && LA38_2 <= VOLATILE) || LA38_2 == MONKEYS_AT || LA38_2 == LT) )
					{
						alt38 = 3;
					}
					else if ( (LA38_2 == LBRACE) )
					{
						alt38 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d38s2 =
							new NoViableAltException("", 38, 2, input);

						throw nvae_d38s2;
					}
				}
					break;
				case LBRACE:
				{
					alt38 = 2;
				}
					break;
				case IDENTIFIER:
				case ABSTRACT:
				case BOOLEAN:
				case BYTE:
				case CHAR:
				case CLASS:
				case DOUBLE:
				case ENUM:
				case FINAL:
				case FLOAT:
				case INT:
				case INTERFACE:
				case LONG:
				case NATIVE:
				case PRIVATE:
				case PROTECTED:
				case PUBLIC:
				case SHORT:
				case STRICTFP:
				case SYNCHRONIZED:
				case TRANSIENT:
				case VOID:
				case VOLATILE:
				case MONKEYS_AT:
				case LT:
				{
					alt38 = 3;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d38s0 =
						new NoViableAltException("", 38, 0, input);

					throw nvae_d38s0;
				}

				switch (alt38) 
				{
				case 1 :
					// Java.g:560:9: ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal103=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_classBodyDeclaration1895); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal103_tree = (object)adaptor.Create(char_literal103, retval);
						adaptor.AddChild(root_0, char_literal103_tree);
					}

				}
					break;
				case 2 :
					// Java.g:561:9: ( 'static' )? block
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:561:9: ( 'static' )?
					int alt37 = 2;
					int LA37_0 = input.LA(1);

					if ( (LA37_0 == STATIC) )
					{
						alt37 = 1;
					}
					switch (alt37) 
					{
					case 1 :
						// Java.g:561:10: 'static'
					{
						string_literal104=(IToken)Match(input,STATIC,FOLLOW_STATIC_in_classBodyDeclaration1906); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal104_tree = (object)adaptor.Create(string_literal104, retval);
							adaptor.AddChild(root_0, string_literal104_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_block_in_classBodyDeclaration1928);
					block105 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block105.Tree, block105, retval);

				}
					break;
				case 3 :
					// Java.g:564:9: memberDecl
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_memberDecl_in_classBodyDeclaration1938);
					memberDecl106 = memberDecl();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberDecl106.Tree, memberDecl106, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 24, classBodyDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classBodyDeclaration"

		public class memberDecl_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "memberDecl"
		// Java.g:567:1: memberDecl : ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration );
		public JavaParser.memberDecl_return memberDecl() // throws RecognitionException [1]
		{   
			JavaParser.memberDecl_return retval = new JavaParser.memberDecl_return();
			retval.Start = input.LT(1);
			int memberDecl_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.fieldDeclaration_return fieldDeclaration107 = default(JavaParser.fieldDeclaration_return);

			JavaParser.methodDeclaration_return methodDeclaration108 = default(JavaParser.methodDeclaration_return);

			JavaParser.classDeclaration_return classDeclaration109 = default(JavaParser.classDeclaration_return);

			JavaParser.interfaceDeclaration_return interfaceDeclaration110 = default(JavaParser.interfaceDeclaration_return);



			const string elementName = "memberDecl"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 25) ) 
				{
					return retval; 
				}
				// Java.g:570:5: ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration )
				int alt39 = 4;
				alt39 = dfa39.Predict(input);
				switch (alt39) 
				{
				case 1 :
					// Java.g:570:10: fieldDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_fieldDeclaration_in_memberDecl1968);
					fieldDeclaration107 = fieldDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, fieldDeclaration107.Tree, fieldDeclaration107, retval);

				}
					break;
				case 2 :
					// Java.g:571:10: methodDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_methodDeclaration_in_memberDecl1979);
					methodDeclaration108 = methodDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, methodDeclaration108.Tree, methodDeclaration108, retval);

				}
					break;
				case 3 :
					// Java.g:572:10: classDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classDeclaration_in_memberDecl1990);
					classDeclaration109 = classDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classDeclaration109.Tree, classDeclaration109, retval);

				}
					break;
				case 4 :
					// Java.g:573:10: interfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceDeclaration_in_memberDecl2001);
					interfaceDeclaration110 = interfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceDeclaration110.Tree, interfaceDeclaration110, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 25, memberDecl_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "memberDecl"

		public class methodDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "methodDeclaration"
		// Java.g:577:1: methodDeclaration : ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) );
		public JavaParser.methodDeclaration_return methodDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.methodDeclaration_return retval = new JavaParser.methodDeclaration_return();
			retval.Start = input.LT(1);
			int methodDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER113 = null;
			IToken string_literal115 = null;
			IToken char_literal117 = null;
			IToken char_literal120 = null;
			IToken string_literal124 = null;
			IToken IDENTIFIER125 = null;
			IToken char_literal127 = null;
			IToken char_literal128 = null;
			IToken string_literal129 = null;
			IToken char_literal132 = null;
			JavaParser.modifiers_return modifiers111 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters112 = default(JavaParser.typeParameters_return);

			JavaParser.formalParameters_return formalParameters114 = default(JavaParser.formalParameters_return);

			JavaParser.qualifiedNameList_return qualifiedNameList116 = default(JavaParser.qualifiedNameList_return);

			JavaParser.explicitConstructorInvocation_return explicitConstructorInvocation118 = default(JavaParser.explicitConstructorInvocation_return);

			JavaParser.blockStatement_return blockStatement119 = default(JavaParser.blockStatement_return);

			JavaParser.modifiers_return modifiers121 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters122 = default(JavaParser.typeParameters_return);

			JavaParser.type_return type123 = default(JavaParser.type_return);

			JavaParser.formalParameters_return formalParameters126 = default(JavaParser.formalParameters_return);

			JavaParser.qualifiedNameList_return qualifiedNameList130 = default(JavaParser.qualifiedNameList_return);

			JavaParser.block_return block131 = default(JavaParser.block_return);


			object IDENTIFIER113_tree=null;
			object string_literal115_tree=null;
			object char_literal117_tree=null;
			object char_literal120_tree=null;
			object string_literal124_tree=null;
			object IDENTIFIER125_tree=null;
			object char_literal127_tree=null;
			object char_literal128_tree=null;
			object string_literal129_tree=null;
			object char_literal132_tree=null;

			const string elementName = "methodDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 26) ) 
				{
					return retval; 
				}
				// Java.g:580:5: ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) )
				int alt49 = 2;
				alt49 = dfa49.Predict(input);
				switch (alt49) 
				{
				case 1 :
					// Java.g:582:10: modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_methodDeclaration2048);
					modifiers111 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers111.Tree, modifiers111, retval);
					// Java.g:583:9: ( typeParameters )?
					int alt40 = 2;
					int LA40_0 = input.LA(1);

					if ( (LA40_0 == LT) )
					{
						alt40 = 1;
					}
					switch (alt40) 
					{
					case 1 :
						// Java.g:583:10: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_methodDeclaration2059);
						typeParameters112 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters112.Tree, typeParameters112, retval);

					}
						break;

					}

					IDENTIFIER113=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_methodDeclaration2080); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER113_tree = (object)adaptor.Create(IDENTIFIER113, retval);
						adaptor.AddChild(root_0, IDENTIFIER113_tree);
					}
					PushFollow(FOLLOW_formalParameters_in_methodDeclaration2090);
					formalParameters114 = formalParameters();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameters114.Tree, formalParameters114, retval);
					// Java.g:587:9: ( 'throws' qualifiedNameList )?
					int alt41 = 2;
					int LA41_0 = input.LA(1);

					if ( (LA41_0 == THROWS) )
					{
						alt41 = 1;
					}
					switch (alt41) 
					{
					case 1 :
						// Java.g:587:10: 'throws' qualifiedNameList
					{
						string_literal115=(IToken)Match(input,THROWS,FOLLOW_THROWS_in_methodDeclaration2101); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal115_tree = (object)adaptor.Create(string_literal115, retval);
							adaptor.AddChild(root_0, string_literal115_tree);
						}
						PushFollow(FOLLOW_qualifiedNameList_in_methodDeclaration2103);
						qualifiedNameList116 = qualifiedNameList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedNameList116.Tree, qualifiedNameList116, retval);

					}
						break;

					}

					char_literal117=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_methodDeclaration2124); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal117_tree = (object)adaptor.Create(char_literal117, retval);
						adaptor.AddChild(root_0, char_literal117_tree);
					}
					// Java.g:590:9: ( explicitConstructorInvocation )?
					int alt42 = 2;
					alt42 = dfa42.Predict(input);
					switch (alt42) 
					{
					case 1 :
						// Java.g:590:10: explicitConstructorInvocation
					{
						PushFollow(FOLLOW_explicitConstructorInvocation_in_methodDeclaration2136);
						explicitConstructorInvocation118 = explicitConstructorInvocation();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, explicitConstructorInvocation118.Tree, explicitConstructorInvocation118, retval);

					}
						break;

					}

					// Java.g:592:9: ( blockStatement )*
					do 
					{
						int alt43 = 2;
						int LA43_0 = input.LA(1);

						if ( ((LA43_0 >= IDENTIFIER && LA43_0 <= NULL) || (LA43_0 >= ABSTRACT && LA43_0 <= BYTE) || (LA43_0 >= CHAR && LA43_0 <= CLASS) || LA43_0 == CONTINUE || (LA43_0 >= DO && LA43_0 <= DOUBLE) || LA43_0 == ENUM || LA43_0 == FINAL || (LA43_0 >= FLOAT && LA43_0 <= FOR) || LA43_0 == IF || (LA43_0 >= INT && LA43_0 <= NEW) || (LA43_0 >= PRIVATE && LA43_0 <= THROW) || (LA43_0 >= TRANSIENT && LA43_0 <= LPAREN) || LA43_0 == LBRACE || LA43_0 == SEMI || (LA43_0 >= BANG && LA43_0 <= TILDE) || (LA43_0 >= PLUSPLUS && LA43_0 <= SUB) || LA43_0 == MONKEYS_AT || LA43_0 == LT) )
						{
							alt43 = 1;
						}


						switch (alt43) 
						{
						case 1 :
							// Java.g:592:10: blockStatement
						{
							PushFollow(FOLLOW_blockStatement_in_methodDeclaration2158);
							blockStatement119 = blockStatement();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, blockStatement119.Tree, blockStatement119, retval);

						}
							break;

						default:
							goto loop43;
						}
					} while (true);

					loop43:
					;	// Stops C# compiler whining that label 'loop43' has no statements

					char_literal120=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_methodDeclaration2179); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal120_tree = (object)adaptor.Create(char_literal120, retval);
						adaptor.AddChild(root_0, char_literal120_tree);
					}

				}
					break;
				case 2 :
					// Java.g:595:9: modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' )
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_methodDeclaration2189);
					modifiers121 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers121.Tree, modifiers121, retval);
					// Java.g:596:9: ( typeParameters )?
					int alt44 = 2;
					int LA44_0 = input.LA(1);

					if ( (LA44_0 == LT) )
					{
						alt44 = 1;
					}
					switch (alt44) 
					{
					case 1 :
						// Java.g:596:10: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_methodDeclaration2200);
						typeParameters122 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters122.Tree, typeParameters122, retval);

					}
						break;

					}

					// Java.g:598:9: ( type | 'void' )
					int alt45 = 2;
					int LA45_0 = input.LA(1);

					if ( (LA45_0 == IDENTIFIER || LA45_0 == BOOLEAN || LA45_0 == BYTE || LA45_0 == CHAR || LA45_0 == DOUBLE || LA45_0 == FLOAT || LA45_0 == INT || LA45_0 == LONG || LA45_0 == SHORT) )
					{
						alt45 = 1;
					}
					else if ( (LA45_0 == VOID) )
					{
						alt45 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d45s0 =
							new NoViableAltException("", 45, 0, input);

						throw nvae_d45s0;
					}
					switch (alt45) 
					{
					case 1 :
						// Java.g:598:10: type
					{
						PushFollow(FOLLOW_type_in_methodDeclaration2222);
						type123 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type123.Tree, type123, retval);

					}
						break;
					case 2 :
						// Java.g:599:13: 'void'
					{
						string_literal124=(IToken)Match(input,VOID,FOLLOW_VOID_in_methodDeclaration2236); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal124_tree = (object)adaptor.Create(string_literal124, retval);
							adaptor.AddChild(root_0, string_literal124_tree);
						}

					}
						break;

					}

					IDENTIFIER125=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_methodDeclaration2256); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER125_tree = (object)adaptor.Create(IDENTIFIER125, retval);
						adaptor.AddChild(root_0, IDENTIFIER125_tree);
					}
					PushFollow(FOLLOW_formalParameters_in_methodDeclaration2266);
					formalParameters126 = formalParameters();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameters126.Tree, formalParameters126, retval);
					// Java.g:603:9: ( '[' ']' )*
					do 
					{
						int alt46 = 2;
						int LA46_0 = input.LA(1);

						if ( (LA46_0 == LBRACKET) )
						{
							alt46 = 1;
						}


						switch (alt46) 
						{
						case 1 :
							// Java.g:603:10: '[' ']'
						{
							char_literal127=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_methodDeclaration2277); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal127_tree = (object)adaptor.Create(char_literal127, retval);
								adaptor.AddChild(root_0, char_literal127_tree);
							}
							char_literal128=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_methodDeclaration2279); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal128_tree = (object)adaptor.Create(char_literal128, retval);
								adaptor.AddChild(root_0, char_literal128_tree);
							}

						}
							break;

						default:
							goto loop46;
						}
					} while (true);

					loop46:
					;	// Stops C# compiler whining that label 'loop46' has no statements

					// Java.g:605:9: ( 'throws' qualifiedNameList )?
					int alt47 = 2;
					int LA47_0 = input.LA(1);

					if ( (LA47_0 == THROWS) )
					{
						alt47 = 1;
					}
					switch (alt47) 
					{
					case 1 :
						// Java.g:605:10: 'throws' qualifiedNameList
					{
						string_literal129=(IToken)Match(input,THROWS,FOLLOW_THROWS_in_methodDeclaration2301); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal129_tree = (object)adaptor.Create(string_literal129, retval);
							adaptor.AddChild(root_0, string_literal129_tree);
						}
						PushFollow(FOLLOW_qualifiedNameList_in_methodDeclaration2303);
						qualifiedNameList130 = qualifiedNameList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedNameList130.Tree, qualifiedNameList130, retval);

					}
						break;

					}

					// Java.g:607:9: ( block | ';' )
					int alt48 = 2;
					int LA48_0 = input.LA(1);

					if ( (LA48_0 == LBRACE) )
					{
						alt48 = 1;
					}
					else if ( (LA48_0 == SEMI) )
					{
						alt48 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d48s0 =
							new NoViableAltException("", 48, 0, input);

						throw nvae_d48s0;
					}
					switch (alt48) 
					{
					case 1 :
						// Java.g:608:13: block
					{
						PushFollow(FOLLOW_block_in_methodDeclaration2358);
						block131 = block();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block131.Tree, block131, retval);

					}
						break;
					case 2 :
						// Java.g:609:13: ';'
					{
						char_literal132=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_methodDeclaration2372); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal132_tree = (object)adaptor.Create(char_literal132, retval);
							adaptor.AddChild(root_0, char_literal132_tree);
						}

					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 26, methodDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "methodDeclaration"

		public class fieldDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "fieldDeclaration"
		// Java.g:614:1: fieldDeclaration : modifiers type variableDeclarator ( ',' variableDeclarator )* ';' ;
		public JavaParser.fieldDeclaration_return fieldDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.fieldDeclaration_return retval = new JavaParser.fieldDeclaration_return();
			retval.Start = input.LT(1);
			int fieldDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal136 = null;
			IToken char_literal138 = null;
			JavaParser.modifiers_return modifiers133 = default(JavaParser.modifiers_return);

			JavaParser.type_return type134 = default(JavaParser.type_return);

			JavaParser.variableDeclarator_return variableDeclarator135 = default(JavaParser.variableDeclarator_return);

			JavaParser.variableDeclarator_return variableDeclarator137 = default(JavaParser.variableDeclarator_return);


			object char_literal136_tree=null;
			object char_literal138_tree=null;

			const string elementName = "fieldDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 27) ) 
				{
					return retval; 
				}
				// Java.g:617:5: ( modifiers type variableDeclarator ( ',' variableDeclarator )* ';' )
				// Java.g:617:9: modifiers type variableDeclarator ( ',' variableDeclarator )* ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_fieldDeclaration2413);
					modifiers133 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers133.Tree, modifiers133, retval);
					PushFollow(FOLLOW_type_in_fieldDeclaration2423);
					type134 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type134.Tree, type134, retval);
					PushFollow(FOLLOW_variableDeclarator_in_fieldDeclaration2433);
					variableDeclarator135 = variableDeclarator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator135.Tree, variableDeclarator135, retval);
					// Java.g:620:9: ( ',' variableDeclarator )*
					do 
					{
						int alt50 = 2;
						int LA50_0 = input.LA(1);

						if ( (LA50_0 == COMMA) )
						{
							alt50 = 1;
						}


						switch (alt50) 
						{
						case 1 :
							// Java.g:620:10: ',' variableDeclarator
						{
							char_literal136=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_fieldDeclaration2444); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal136_tree = (object)adaptor.Create(char_literal136, retval);
								adaptor.AddChild(root_0, char_literal136_tree);
							}
							PushFollow(FOLLOW_variableDeclarator_in_fieldDeclaration2446);
							variableDeclarator137 = variableDeclarator();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator137.Tree, variableDeclarator137, retval);

						}
							break;

						default:
							goto loop50;
						}
					} while (true);

					loop50:
					;	// Stops C# compiler whining that label 'loop50' has no statements

					char_literal138=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_fieldDeclaration2467); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal138_tree = (object)adaptor.Create(char_literal138, retval);
						adaptor.AddChild(root_0, char_literal138_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 27, fieldDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "fieldDeclaration"

		public class variableDeclarator_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "variableDeclarator"
		// Java.g:625:1: variableDeclarator : IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )? ;
		public JavaParser.variableDeclarator_return variableDeclarator() // throws RecognitionException [1]
		{   
			JavaParser.variableDeclarator_return retval = new JavaParser.variableDeclarator_return();
			retval.Start = input.LT(1);
			int variableDeclarator_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER139 = null;
			IToken char_literal140 = null;
			IToken char_literal141 = null;
			IToken char_literal142 = null;
			JavaParser.variableInitializer_return variableInitializer143 = default(JavaParser.variableInitializer_return);


			object IDENTIFIER139_tree=null;
			object char_literal140_tree=null;
			object char_literal141_tree=null;
			object char_literal142_tree=null;

			const string elementName = "variableDeclarator"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 28) ) 
				{
					return retval; 
				}
				// Java.g:628:5: ( IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )? )
				// Java.g:628:9: IDENTIFIER ( '[' ']' )* ( '=' variableInitializer )?
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER139=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_variableDeclarator2496); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER139_tree = (object)adaptor.Create(IDENTIFIER139, retval);
						adaptor.AddChild(root_0, IDENTIFIER139_tree);
					}
					// Java.g:629:9: ( '[' ']' )*
					do 
					{
						int alt51 = 2;
						int LA51_0 = input.LA(1);

						if ( (LA51_0 == LBRACKET) )
						{
							alt51 = 1;
						}


						switch (alt51) 
						{
						case 1 :
							// Java.g:629:10: '[' ']'
						{
							char_literal140=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_variableDeclarator2507); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal140_tree = (object)adaptor.Create(char_literal140, retval);
								adaptor.AddChild(root_0, char_literal140_tree);
							}
							char_literal141=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_variableDeclarator2509); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal141_tree = (object)adaptor.Create(char_literal141, retval);
								adaptor.AddChild(root_0, char_literal141_tree);
							}

						}
							break;

						default:
							goto loop51;
						}
					} while (true);

					loop51:
					;	// Stops C# compiler whining that label 'loop51' has no statements

					// Java.g:631:9: ( '=' variableInitializer )?
					int alt52 = 2;
					int LA52_0 = input.LA(1);

					if ( (LA52_0 == EQ) )
					{
						alt52 = 1;
					}
					switch (alt52) 
					{
					case 1 :
						// Java.g:631:10: '=' variableInitializer
					{
						char_literal142=(IToken)Match(input,EQ,FOLLOW_EQ_in_variableDeclarator2531); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal142_tree = (object)adaptor.Create(char_literal142, retval);
							adaptor.AddChild(root_0, char_literal142_tree);
						}
						PushFollow(FOLLOW_variableInitializer_in_variableDeclarator2533);
						variableInitializer143 = variableInitializer();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableInitializer143.Tree, variableInitializer143, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 28, variableDeclarator_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "variableDeclarator"

		public class interfaceBodyDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceBodyDeclaration"
		// Java.g:635:1: interfaceBodyDeclaration : ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' );
		public JavaParser.interfaceBodyDeclaration_return interfaceBodyDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.interfaceBodyDeclaration_return retval = new JavaParser.interfaceBodyDeclaration_return();
			retval.Start = input.LT(1);
			int interfaceBodyDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal148 = null;
			JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration144 = default(JavaParser.interfaceFieldDeclaration_return);

			JavaParser.interfaceMethodDeclaration_return interfaceMethodDeclaration145 = default(JavaParser.interfaceMethodDeclaration_return);

			JavaParser.interfaceDeclaration_return interfaceDeclaration146 = default(JavaParser.interfaceDeclaration_return);

			JavaParser.classDeclaration_return classDeclaration147 = default(JavaParser.classDeclaration_return);


			object char_literal148_tree=null;

			const string elementName = "interfaceBodyDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 29) ) 
				{
					return retval; 
				}
				// Java.g:641:5: ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' )
				int alt53 = 5;
				alt53 = dfa53.Predict(input);
				switch (alt53) 
				{
				case 1 :
					// Java.g:642:9: interfaceFieldDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceFieldDeclaration_in_interfaceBodyDeclaration2581);
					interfaceFieldDeclaration144 = interfaceFieldDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceFieldDeclaration144.Tree, interfaceFieldDeclaration144, retval);

				}
					break;
				case 2 :
					// Java.g:643:9: interfaceMethodDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceMethodDeclaration_in_interfaceBodyDeclaration2591);
					interfaceMethodDeclaration145 = interfaceMethodDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceMethodDeclaration145.Tree, interfaceMethodDeclaration145, retval);

				}
					break;
				case 3 :
					// Java.g:644:9: interfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceDeclaration_in_interfaceBodyDeclaration2601);
					interfaceDeclaration146 = interfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceDeclaration146.Tree, interfaceDeclaration146, retval);

				}
					break;
				case 4 :
					// Java.g:645:9: classDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classDeclaration_in_interfaceBodyDeclaration2611);
					classDeclaration147 = classDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classDeclaration147.Tree, classDeclaration147, retval);

				}
					break;
				case 5 :
					// Java.g:646:9: ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal148=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_interfaceBodyDeclaration2621); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal148_tree = (object)adaptor.Create(char_literal148, retval);
						adaptor.AddChild(root_0, char_literal148_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 29, interfaceBodyDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceBodyDeclaration"

		public class interfaceMethodDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceMethodDeclaration"
		// Java.g:649:1: interfaceMethodDeclaration : modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';' ;
		public JavaParser.interfaceMethodDeclaration_return interfaceMethodDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.interfaceMethodDeclaration_return retval = new JavaParser.interfaceMethodDeclaration_return();
			retval.Start = input.LT(1);
			int interfaceMethodDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal152 = null;
			IToken IDENTIFIER153 = null;
			IToken char_literal155 = null;
			IToken char_literal156 = null;
			IToken string_literal157 = null;
			IToken char_literal159 = null;
			JavaParser.modifiers_return modifiers149 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters150 = default(JavaParser.typeParameters_return);

			JavaParser.type_return type151 = default(JavaParser.type_return);

			JavaParser.formalParameters_return formalParameters154 = default(JavaParser.formalParameters_return);

			JavaParser.qualifiedNameList_return qualifiedNameList158 = default(JavaParser.qualifiedNameList_return);


			object string_literal152_tree=null;
			object IDENTIFIER153_tree=null;
			object char_literal155_tree=null;
			object char_literal156_tree=null;
			object string_literal157_tree=null;
			object char_literal159_tree=null;

			const string elementName = "interfaceMethodDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 30) ) 
				{
					return retval; 
				}
				// Java.g:652:5: ( modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';' )
				// Java.g:652:9: modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_interfaceMethodDeclaration2650);
					modifiers149 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers149.Tree, modifiers149, retval);
					// Java.g:653:9: ( typeParameters )?
					int alt54 = 2;
					int LA54_0 = input.LA(1);

					if ( (LA54_0 == LT) )
					{
						alt54 = 1;
					}
					switch (alt54) 
					{
					case 1 :
						// Java.g:653:10: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_interfaceMethodDeclaration2661);
						typeParameters150 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters150.Tree, typeParameters150, retval);

					}
						break;

					}

					// Java.g:655:9: ( type | 'void' )
					int alt55 = 2;
					int LA55_0 = input.LA(1);

					if ( (LA55_0 == IDENTIFIER || LA55_0 == BOOLEAN || LA55_0 == BYTE || LA55_0 == CHAR || LA55_0 == DOUBLE || LA55_0 == FLOAT || LA55_0 == INT || LA55_0 == LONG || LA55_0 == SHORT) )
					{
						alt55 = 1;
					}
					else if ( (LA55_0 == VOID) )
					{
						alt55 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d55s0 =
							new NoViableAltException("", 55, 0, input);

						throw nvae_d55s0;
					}
					switch (alt55) 
					{
					case 1 :
						// Java.g:655:10: type
					{
						PushFollow(FOLLOW_type_in_interfaceMethodDeclaration2683);
						type151 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type151.Tree, type151, retval);

					}
						break;
					case 2 :
						// Java.g:656:10: 'void'
					{
						string_literal152=(IToken)Match(input,VOID,FOLLOW_VOID_in_interfaceMethodDeclaration2694); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal152_tree = (object)adaptor.Create(string_literal152, retval);
							adaptor.AddChild(root_0, string_literal152_tree);
						}

					}
						break;

					}

					IDENTIFIER153=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_interfaceMethodDeclaration2714); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER153_tree = (object)adaptor.Create(IDENTIFIER153, retval);
						adaptor.AddChild(root_0, IDENTIFIER153_tree);
					}
					PushFollow(FOLLOW_formalParameters_in_interfaceMethodDeclaration2724);
					formalParameters154 = formalParameters();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameters154.Tree, formalParameters154, retval);
					// Java.g:660:9: ( '[' ']' )*
					do 
					{
						int alt56 = 2;
						int LA56_0 = input.LA(1);

						if ( (LA56_0 == LBRACKET) )
						{
							alt56 = 1;
						}


						switch (alt56) 
						{
						case 1 :
							// Java.g:660:10: '[' ']'
						{
							char_literal155=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_interfaceMethodDeclaration2735); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal155_tree = (object)adaptor.Create(char_literal155, retval);
								adaptor.AddChild(root_0, char_literal155_tree);
							}
							char_literal156=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_interfaceMethodDeclaration2737); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal156_tree = (object)adaptor.Create(char_literal156, retval);
								adaptor.AddChild(root_0, char_literal156_tree);
							}

						}
							break;

						default:
							goto loop56;
						}
					} while (true);

					loop56:
					;	// Stops C# compiler whining that label 'loop56' has no statements

					// Java.g:662:9: ( 'throws' qualifiedNameList )?
					int alt57 = 2;
					int LA57_0 = input.LA(1);

					if ( (LA57_0 == THROWS) )
					{
						alt57 = 1;
					}
					switch (alt57) 
					{
					case 1 :
						// Java.g:662:10: 'throws' qualifiedNameList
					{
						string_literal157=(IToken)Match(input,THROWS,FOLLOW_THROWS_in_interfaceMethodDeclaration2759); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal157_tree = (object)adaptor.Create(string_literal157, retval);
							adaptor.AddChild(root_0, string_literal157_tree);
						}
						PushFollow(FOLLOW_qualifiedNameList_in_interfaceMethodDeclaration2761);
						qualifiedNameList158 = qualifiedNameList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedNameList158.Tree, qualifiedNameList158, retval);

					}
						break;

					}

					char_literal159=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_interfaceMethodDeclaration2774); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal159_tree = (object)adaptor.Create(char_literal159, retval);
						adaptor.AddChild(root_0, char_literal159_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 30, interfaceMethodDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceMethodDeclaration"

		public class interfaceFieldDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceFieldDeclaration"
		// Java.g:666:1: interfaceFieldDeclaration : modifiers type variableDeclarator ( ',' variableDeclarator )* ';' ;
		public JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.interfaceFieldDeclaration_return retval = new JavaParser.interfaceFieldDeclaration_return();
			retval.Start = input.LT(1);
			int interfaceFieldDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal163 = null;
			IToken char_literal165 = null;
			JavaParser.modifiers_return modifiers160 = default(JavaParser.modifiers_return);

			JavaParser.type_return type161 = default(JavaParser.type_return);

			JavaParser.variableDeclarator_return variableDeclarator162 = default(JavaParser.variableDeclarator_return);

			JavaParser.variableDeclarator_return variableDeclarator164 = default(JavaParser.variableDeclarator_return);


			object char_literal163_tree=null;
			object char_literal165_tree=null;

			const string elementName = "interfaceFieldDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 31) ) 
				{
					return retval; 
				}
				// Java.g:674:5: ( modifiers type variableDeclarator ( ',' variableDeclarator )* ';' )
				// Java.g:674:9: modifiers type variableDeclarator ( ',' variableDeclarator )* ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_interfaceFieldDeclaration2805);
					modifiers160 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers160.Tree, modifiers160, retval);
					PushFollow(FOLLOW_type_in_interfaceFieldDeclaration2807);
					type161 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type161.Tree, type161, retval);
					PushFollow(FOLLOW_variableDeclarator_in_interfaceFieldDeclaration2809);
					variableDeclarator162 = variableDeclarator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator162.Tree, variableDeclarator162, retval);
					// Java.g:675:9: ( ',' variableDeclarator )*
					do 
					{
						int alt58 = 2;
						int LA58_0 = input.LA(1);

						if ( (LA58_0 == COMMA) )
						{
							alt58 = 1;
						}


						switch (alt58) 
						{
						case 1 :
							// Java.g:675:10: ',' variableDeclarator
						{
							char_literal163=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_interfaceFieldDeclaration2820); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal163_tree = (object)adaptor.Create(char_literal163, retval);
								adaptor.AddChild(root_0, char_literal163_tree);
							}
							PushFollow(FOLLOW_variableDeclarator_in_interfaceFieldDeclaration2822);
							variableDeclarator164 = variableDeclarator();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator164.Tree, variableDeclarator164, retval);

						}
							break;

						default:
							goto loop58;
						}
					} while (true);

					loop58:
					;	// Stops C# compiler whining that label 'loop58' has no statements

					char_literal165=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_interfaceFieldDeclaration2843); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal165_tree = (object)adaptor.Create(char_literal165, retval);
						adaptor.AddChild(root_0, char_literal165_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 31, interfaceFieldDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceFieldDeclaration"

		public class type_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "type"
		// Java.g:681:1: type : ( classOrInterfaceType ( '[' ']' )* | primitiveType ( '[' ']' )* );
		public JavaParser.type_return type() // throws RecognitionException [1]
		{   
			JavaParser.type_return retval = new JavaParser.type_return();
			retval.Start = input.LT(1);
			int type_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal167 = null;
			IToken char_literal168 = null;
			IToken char_literal170 = null;
			IToken char_literal171 = null;
			JavaParser.classOrInterfaceType_return classOrInterfaceType166 = default(JavaParser.classOrInterfaceType_return);

			JavaParser.primitiveType_return primitiveType169 = default(JavaParser.primitiveType_return);


			object char_literal167_tree=null;
			object char_literal168_tree=null;
			object char_literal170_tree=null;
			object char_literal171_tree=null;

			const string elementName = "type"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 32) ) 
				{
					return retval; 
				}
				// Java.g:684:5: ( classOrInterfaceType ( '[' ']' )* | primitiveType ( '[' ']' )* )
				int alt61 = 2;
				int LA61_0 = input.LA(1);

				if ( (LA61_0 == IDENTIFIER) )
				{
					alt61 = 1;
				}
				else if ( (LA61_0 == BOOLEAN || LA61_0 == BYTE || LA61_0 == CHAR || LA61_0 == DOUBLE || LA61_0 == FLOAT || LA61_0 == INT || LA61_0 == LONG || LA61_0 == SHORT) )
				{
					alt61 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d61s0 =
						new NoViableAltException("", 61, 0, input);

					throw nvae_d61s0;
				}
				switch (alt61) 
				{
				case 1 :
					// Java.g:684:9: classOrInterfaceType ( '[' ']' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classOrInterfaceType_in_type2873);
					classOrInterfaceType166 = classOrInterfaceType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceType166.Tree, classOrInterfaceType166, retval);
					// Java.g:685:9: ( '[' ']' )*
					do 
					{
						int alt59 = 2;
						int LA59_0 = input.LA(1);

						if ( (LA59_0 == LBRACKET) )
						{
							alt59 = 1;
						}


						switch (alt59) 
						{
						case 1 :
							// Java.g:685:10: '[' ']'
						{
							char_literal167=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_type2884); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal167_tree = (object)adaptor.Create(char_literal167, retval);
								adaptor.AddChild(root_0, char_literal167_tree);
							}
							char_literal168=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_type2886); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal168_tree = (object)adaptor.Create(char_literal168, retval);
								adaptor.AddChild(root_0, char_literal168_tree);
							}

						}
							break;

						default:
							goto loop59;
						}
					} while (true);

					loop59:
					;	// Stops C# compiler whining that label 'loop59' has no statements


				}
					break;
				case 2 :
					// Java.g:687:9: primitiveType ( '[' ']' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_primitiveType_in_type2907);
					primitiveType169 = primitiveType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primitiveType169.Tree, primitiveType169, retval);
					// Java.g:688:9: ( '[' ']' )*
					do 
					{
						int alt60 = 2;
						int LA60_0 = input.LA(1);

						if ( (LA60_0 == LBRACKET) )
						{
							alt60 = 1;
						}


						switch (alt60) 
						{
						case 1 :
							// Java.g:688:10: '[' ']'
						{
							char_literal170=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_type2918); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal170_tree = (object)adaptor.Create(char_literal170, retval);
								adaptor.AddChild(root_0, char_literal170_tree);
							}
							char_literal171=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_type2920); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal171_tree = (object)adaptor.Create(char_literal171, retval);
								adaptor.AddChild(root_0, char_literal171_tree);
							}

						}
							break;

						default:
							goto loop60;
						}
					} while (true);

					loop60:
					;	// Stops C# compiler whining that label 'loop60' has no statements


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 32, type_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "type"

		public class classOrInterfaceType_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classOrInterfaceType"
		// Java.g:693:1: classOrInterfaceType : IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )* ;
		public JavaParser.classOrInterfaceType_return classOrInterfaceType() // throws RecognitionException [1]
		{   
			JavaParser.classOrInterfaceType_return retval = new JavaParser.classOrInterfaceType_return();
			retval.Start = input.LT(1);
			int classOrInterfaceType_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER172 = null;
			IToken char_literal174 = null;
			IToken IDENTIFIER175 = null;
			JavaParser.typeArguments_return typeArguments173 = default(JavaParser.typeArguments_return);

			JavaParser.typeArguments_return typeArguments176 = default(JavaParser.typeArguments_return);


			object IDENTIFIER172_tree=null;
			object char_literal174_tree=null;
			object IDENTIFIER175_tree=null;

			const string elementName = "classOrInterfaceType"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 33) ) 
				{
					return retval; 
				}
				// Java.g:696:5: ( IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )* )
				// Java.g:696:9: IDENTIFIER ( typeArguments )? ( '.' IDENTIFIER ( typeArguments )? )*
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER172=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_classOrInterfaceType2961); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER172_tree = (object)adaptor.Create(IDENTIFIER172, retval);
						adaptor.AddChild(root_0, IDENTIFIER172_tree);
					}
					// Java.g:697:9: ( typeArguments )?
					int alt62 = 2;
					int LA62_0 = input.LA(1);

					if ( (LA62_0 == LT) )
					{
						int LA62_1 = input.LA(2);

						if ( (LA62_1 == IDENTIFIER || LA62_1 == BOOLEAN || LA62_1 == BYTE || LA62_1 == CHAR || LA62_1 == DOUBLE || LA62_1 == FLOAT || LA62_1 == INT || LA62_1 == LONG || LA62_1 == SHORT || LA62_1 == QUES) )
						{
							alt62 = 1;
						}
					}
					switch (alt62) 
					{
					case 1 :
						// Java.g:697:10: typeArguments
					{
						PushFollow(FOLLOW_typeArguments_in_classOrInterfaceType2972);
						typeArguments173 = typeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArguments173.Tree, typeArguments173, retval);

					}
						break;

					}

					// Java.g:699:9: ( '.' IDENTIFIER ( typeArguments )? )*
					do 
					{
						int alt64 = 2;
						int LA64_0 = input.LA(1);

						if ( (LA64_0 == DOT) )
						{
							alt64 = 1;
						}


						switch (alt64) 
						{
						case 1 :
							// Java.g:699:10: '.' IDENTIFIER ( typeArguments )?
						{
							char_literal174=(IToken)Match(input,DOT,FOLLOW_DOT_in_classOrInterfaceType2994); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal174_tree = (object)adaptor.Create(char_literal174, retval);
								adaptor.AddChild(root_0, char_literal174_tree);
							}
							IDENTIFIER175=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_classOrInterfaceType2996); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER175_tree = (object)adaptor.Create(IDENTIFIER175, retval);
								adaptor.AddChild(root_0, IDENTIFIER175_tree);
							}
							// Java.g:700:13: ( typeArguments )?
							int alt63 = 2;
							int LA63_0 = input.LA(1);

							if ( (LA63_0 == LT) )
							{
								int LA63_1 = input.LA(2);

								if ( (LA63_1 == IDENTIFIER || LA63_1 == BOOLEAN || LA63_1 == BYTE || LA63_1 == CHAR || LA63_1 == DOUBLE || LA63_1 == FLOAT || LA63_1 == INT || LA63_1 == LONG || LA63_1 == SHORT || LA63_1 == QUES) )
								{
									alt63 = 1;
								}
							}
							switch (alt63) 
							{
							case 1 :
								// Java.g:700:14: typeArguments
							{
								PushFollow(FOLLOW_typeArguments_in_classOrInterfaceType3011);
								typeArguments176 = typeArguments();
								state.followingStackPointer--;
								if (state.failed) return retval;
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArguments176.Tree, typeArguments176, retval);

							}
								break;

							}


						}
							break;

						default:
							goto loop64;
						}
					} while (true);

					loop64:
					;	// Stops C# compiler whining that label 'loop64' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 33, classOrInterfaceType_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classOrInterfaceType"

		public class primitiveType_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "primitiveType"
		// Java.g:705:1: primitiveType : ( 'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' );
		public JavaParser.primitiveType_return primitiveType() // throws RecognitionException [1]
		{   
			JavaParser.primitiveType_return retval = new JavaParser.primitiveType_return();
			retval.Start = input.LT(1);
			int primitiveType_StartIndex = input.Index();
			object root_0 = null;

			IToken set177 = null;

			object set177_tree=null;

			const string elementName = "primitiveType"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 34) ) 
				{
					return retval; 
				}
				// Java.g:708:5: ( 'boolean' | 'char' | 'byte' | 'short' | 'int' | 'long' | 'float' | 'double' )
				// Java.g:
				{
					root_0 = (object)adaptor.GetNilNode();

					set177 = (IToken)input.LT(1);
					if ( input.LA(1) == BOOLEAN || input.LA(1) == BYTE || input.LA(1) == CHAR || input.LA(1) == DOUBLE || input.LA(1) == FLOAT || input.LA(1) == INT || input.LA(1) == LONG || input.LA(1) == SHORT ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set177, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 34, primitiveType_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "primitiveType"

		public class typeArguments_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeArguments"
		// Java.g:718:1: typeArguments : '<' typeArgument ( ',' typeArgument )* '>' ;
		public JavaParser.typeArguments_return typeArguments() // throws RecognitionException [1]
		{   
			JavaParser.typeArguments_return retval = new JavaParser.typeArguments_return();
			retval.Start = input.LT(1);
			int typeArguments_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal178 = null;
			IToken char_literal180 = null;
			IToken char_literal182 = null;
			JavaParser.typeArgument_return typeArgument179 = default(JavaParser.typeArgument_return);

			JavaParser.typeArgument_return typeArgument181 = default(JavaParser.typeArgument_return);


			object char_literal178_tree=null;
			object char_literal180_tree=null;
			object char_literal182_tree=null;

			const string elementName = "typeArguments"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 35) ) 
				{
					return retval; 
				}
				// Java.g:721:5: ( '<' typeArgument ( ',' typeArgument )* '>' )
				// Java.g:721:9: '<' typeArgument ( ',' typeArgument )* '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal178=(IToken)Match(input,LT,FOLLOW_LT_in_typeArguments3165); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal178_tree = (object)adaptor.Create(char_literal178, retval);
						adaptor.AddChild(root_0, char_literal178_tree);
					}
					PushFollow(FOLLOW_typeArgument_in_typeArguments3167);
					typeArgument179 = typeArgument();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArgument179.Tree, typeArgument179, retval);
					// Java.g:722:9: ( ',' typeArgument )*
					do 
					{
						int alt65 = 2;
						int LA65_0 = input.LA(1);

						if ( (LA65_0 == COMMA) )
						{
							alt65 = 1;
						}


						switch (alt65) 
						{
						case 1 :
							// Java.g:722:10: ',' typeArgument
						{
							char_literal180=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_typeArguments3178); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal180_tree = (object)adaptor.Create(char_literal180, retval);
								adaptor.AddChild(root_0, char_literal180_tree);
							}
							PushFollow(FOLLOW_typeArgument_in_typeArguments3180);
							typeArgument181 = typeArgument();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArgument181.Tree, typeArgument181, retval);

						}
							break;

						default:
							goto loop65;
						}
					} while (true);

					loop65:
					;	// Stops C# compiler whining that label 'loop65' has no statements

					char_literal182=(IToken)Match(input,GT,FOLLOW_GT_in_typeArguments3202); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal182_tree = (object)adaptor.Create(char_literal182, retval);
						adaptor.AddChild(root_0, char_literal182_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 35, typeArguments_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeArguments"

		public class typeArgument_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeArgument"
		// Java.g:727:1: typeArgument : ( type | '?' ( ( 'extends' | 'super' ) type )? );
		public JavaParser.typeArgument_return typeArgument() // throws RecognitionException [1]
		{   
			JavaParser.typeArgument_return retval = new JavaParser.typeArgument_return();
			retval.Start = input.LT(1);
			int typeArgument_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal184 = null;
			IToken set185 = null;
			JavaParser.type_return type183 = default(JavaParser.type_return);

			JavaParser.type_return type186 = default(JavaParser.type_return);


			object char_literal184_tree=null;
			object set185_tree=null;

			const string elementName = "typeArgument"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 36) ) 
				{
					return retval; 
				}
				// Java.g:730:5: ( type | '?' ( ( 'extends' | 'super' ) type )? )
				int alt67 = 2;
				int LA67_0 = input.LA(1);

				if ( (LA67_0 == IDENTIFIER || LA67_0 == BOOLEAN || LA67_0 == BYTE || LA67_0 == CHAR || LA67_0 == DOUBLE || LA67_0 == FLOAT || LA67_0 == INT || LA67_0 == LONG || LA67_0 == SHORT) )
				{
					alt67 = 1;
				}
				else if ( (LA67_0 == QUES) )
				{
					alt67 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d67s0 =
						new NoViableAltException("", 67, 0, input);

					throw nvae_d67s0;
				}
				switch (alt67) 
				{
				case 1 :
					// Java.g:730:9: type
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_type_in_typeArgument3231);
					type183 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type183.Tree, type183, retval);

				}
					break;
				case 2 :
					// Java.g:731:9: '?' ( ( 'extends' | 'super' ) type )?
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal184=(IToken)Match(input,QUES,FOLLOW_QUES_in_typeArgument3241); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal184_tree = (object)adaptor.Create(char_literal184, retval);
						adaptor.AddChild(root_0, char_literal184_tree);
					}
					// Java.g:732:9: ( ( 'extends' | 'super' ) type )?
					int alt66 = 2;
					int LA66_0 = input.LA(1);

					if ( (LA66_0 == EXTENDS || LA66_0 == SUPER) )
					{
						alt66 = 1;
					}
					switch (alt66) 
					{
					case 1 :
						// Java.g:733:13: ( 'extends' | 'super' ) type
					{
						set185 = (IToken)input.LT(1);
						if ( input.LA(1) == EXTENDS || input.LA(1) == SUPER ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set185, retval));
							state.errorRecovery = false;state.failed = false;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							MismatchedSetException mse = new MismatchedSetException(null,input);
							throw mse;
						}

						PushFollow(FOLLOW_type_in_typeArgument3309);
						type186 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type186.Tree, type186, retval);

					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 36, typeArgument_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeArgument"

		public class qualifiedNameList_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "qualifiedNameList"
		// Java.g:740:1: qualifiedNameList : qualifiedName ( ',' qualifiedName )* ;
		public JavaParser.qualifiedNameList_return qualifiedNameList() // throws RecognitionException [1]
		{   
			JavaParser.qualifiedNameList_return retval = new JavaParser.qualifiedNameList_return();
			retval.Start = input.LT(1);
			int qualifiedNameList_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal188 = null;
			JavaParser.qualifiedName_return qualifiedName187 = default(JavaParser.qualifiedName_return);

			JavaParser.qualifiedName_return qualifiedName189 = default(JavaParser.qualifiedName_return);


			object char_literal188_tree=null;

			const string elementName = "qualifiedNameList"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 37) ) 
				{
					return retval; 
				}
				// Java.g:743:5: ( qualifiedName ( ',' qualifiedName )* )
				// Java.g:743:9: qualifiedName ( ',' qualifiedName )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_qualifiedName_in_qualifiedNameList3349);
					qualifiedName187 = qualifiedName();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedName187.Tree, qualifiedName187, retval);
					// Java.g:744:9: ( ',' qualifiedName )*
					do 
					{
						int alt68 = 2;
						int LA68_0 = input.LA(1);

						if ( (LA68_0 == COMMA) )
						{
							alt68 = 1;
						}


						switch (alt68) 
						{
						case 1 :
							// Java.g:744:10: ',' qualifiedName
						{
							char_literal188=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_qualifiedNameList3360); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
								adaptor.AddChild(root_0, char_literal188_tree);
							}
							PushFollow(FOLLOW_qualifiedName_in_qualifiedNameList3362);
							qualifiedName189 = qualifiedName();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedName189.Tree, qualifiedName189, retval);

						}
							break;

						default:
							goto loop68;
						}
					} while (true);

					loop68:
					;	// Stops C# compiler whining that label 'loop68' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 37, qualifiedNameList_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "qualifiedNameList"

		public class formalParameters_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "formalParameters"
		// Java.g:748:1: formalParameters : '(' ( formalParameterDecls )? ')' ;
		public JavaParser.formalParameters_return formalParameters() // throws RecognitionException [1]
		{   
			JavaParser.formalParameters_return retval = new JavaParser.formalParameters_return();
			retval.Start = input.LT(1);
			int formalParameters_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal190 = null;
			IToken char_literal192 = null;
			JavaParser.formalParameterDecls_return formalParameterDecls191 = default(JavaParser.formalParameterDecls_return);


			object char_literal190_tree=null;
			object char_literal192_tree=null;

			const string elementName = "formalParameters"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 38) ) 
				{
					return retval; 
				}
				// Java.g:751:5: ( '(' ( formalParameterDecls )? ')' )
				// Java.g:751:9: '(' ( formalParameterDecls )? ')'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal190=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_formalParameters3402); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal190_tree = (object)adaptor.Create(char_literal190, retval);
						adaptor.AddChild(root_0, char_literal190_tree);
					}
					// Java.g:752:9: ( formalParameterDecls )?
					int alt69 = 2;
					int LA69_0 = input.LA(1);

					if ( (LA69_0 == IDENTIFIER || LA69_0 == BOOLEAN || LA69_0 == BYTE || LA69_0 == CHAR || LA69_0 == DOUBLE || LA69_0 == FINAL || LA69_0 == FLOAT || LA69_0 == INT || LA69_0 == LONG || LA69_0 == SHORT || LA69_0 == MONKEYS_AT) )
					{
						alt69 = 1;
					}
					switch (alt69) 
					{
					case 1 :
						// Java.g:752:10: formalParameterDecls
					{
						PushFollow(FOLLOW_formalParameterDecls_in_formalParameters3413);
						formalParameterDecls191 = formalParameterDecls();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterDecls191.Tree, formalParameterDecls191, retval);

					}
						break;

					}

					char_literal192=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_formalParameters3435); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal192_tree = (object)adaptor.Create(char_literal192, retval);
						adaptor.AddChild(root_0, char_literal192_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 38, formalParameters_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "formalParameters"

		public class formalParameterDecls_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "formalParameterDecls"
		// Java.g:757:1: formalParameterDecls : ( ellipsisParameterDecl | normalParameterDecl ( ',' normalParameterDecl )* | ( normalParameterDecl ',' )+ ellipsisParameterDecl );
		public JavaParser.formalParameterDecls_return formalParameterDecls() // throws RecognitionException [1]
		{   
			JavaParser.formalParameterDecls_return retval = new JavaParser.formalParameterDecls_return();
			retval.Start = input.LT(1);
			int formalParameterDecls_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal195 = null;
			IToken char_literal198 = null;
			JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl193 = default(JavaParser.ellipsisParameterDecl_return);

			JavaParser.normalParameterDecl_return normalParameterDecl194 = default(JavaParser.normalParameterDecl_return);

			JavaParser.normalParameterDecl_return normalParameterDecl196 = default(JavaParser.normalParameterDecl_return);

			JavaParser.normalParameterDecl_return normalParameterDecl197 = default(JavaParser.normalParameterDecl_return);

			JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl199 = default(JavaParser.ellipsisParameterDecl_return);


			object char_literal195_tree=null;
			object char_literal198_tree=null;

			const string elementName = "formalParameterDecls"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 39) ) 
				{
					return retval; 
				}
				// Java.g:760:5: ( ellipsisParameterDecl | normalParameterDecl ( ',' normalParameterDecl )* | ( normalParameterDecl ',' )+ ellipsisParameterDecl )
				int alt72 = 3;
				switch ( input.LA(1) ) 
				{
				case FINAL:
				{
					int LA72_1 = input.LA(2);

					if ( (synpred96_Java()) )
					{
						alt72 = 1;
					}
					else if ( (synpred98_Java()) )
					{
						alt72 = 2;
					}
					else if ( (true) )
					{
						alt72 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d72s1 =
							new NoViableAltException("", 72, 1, input);

						throw nvae_d72s1;
					}
				}
					break;
				case MONKEYS_AT:
				{
					int LA72_2 = input.LA(2);

					if ( (synpred96_Java()) )
					{
						alt72 = 1;
					}
					else if ( (synpred98_Java()) )
					{
						alt72 = 2;
					}
					else if ( (true) )
					{
						alt72 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d72s2 =
							new NoViableAltException("", 72, 2, input);

						throw nvae_d72s2;
					}
				}
					break;
				case IDENTIFIER:
				{
					int LA72_3 = input.LA(2);

					if ( (synpred96_Java()) )
					{
						alt72 = 1;
					}
					else if ( (synpred98_Java()) )
					{
						alt72 = 2;
					}
					else if ( (true) )
					{
						alt72 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d72s3 =
							new NoViableAltException("", 72, 3, input);

						throw nvae_d72s3;
					}
				}
					break;
				case BOOLEAN:
				case BYTE:
				case CHAR:
				case DOUBLE:
				case FLOAT:
				case INT:
				case LONG:
				case SHORT:
				{
					int LA72_4 = input.LA(2);

					if ( (synpred96_Java()) )
					{
						alt72 = 1;
					}
					else if ( (synpred98_Java()) )
					{
						alt72 = 2;
					}
					else if ( (true) )
					{
						alt72 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d72s4 =
							new NoViableAltException("", 72, 4, input);

						throw nvae_d72s4;
					}
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d72s0 =
						new NoViableAltException("", 72, 0, input);

					throw nvae_d72s0;
				}

				switch (alt72) 
				{
				case 1 :
					// Java.g:760:9: ellipsisParameterDecl
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_ellipsisParameterDecl_in_formalParameterDecls3464);
					ellipsisParameterDecl193 = ellipsisParameterDecl();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ellipsisParameterDecl193.Tree, ellipsisParameterDecl193, retval);

				}
					break;
				case 2 :
					// Java.g:761:9: normalParameterDecl ( ',' normalParameterDecl )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_normalParameterDecl_in_formalParameterDecls3474);
					normalParameterDecl194 = normalParameterDecl();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalParameterDecl194.Tree, normalParameterDecl194, retval);
					// Java.g:762:9: ( ',' normalParameterDecl )*
					do 
					{
						int alt70 = 2;
						int LA70_0 = input.LA(1);

						if ( (LA70_0 == COMMA) )
						{
							alt70 = 1;
						}


						switch (alt70) 
						{
						case 1 :
							// Java.g:762:10: ',' normalParameterDecl
						{
							char_literal195=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_formalParameterDecls3485); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal195_tree = (object)adaptor.Create(char_literal195, retval);
								adaptor.AddChild(root_0, char_literal195_tree);
							}
							PushFollow(FOLLOW_normalParameterDecl_in_formalParameterDecls3487);
							normalParameterDecl196 = normalParameterDecl();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalParameterDecl196.Tree, normalParameterDecl196, retval);

						}
							break;

						default:
							goto loop70;
						}
					} while (true);

					loop70:
					;	// Stops C# compiler whining that label 'loop70' has no statements


				}
					break;
				case 3 :
					// Java.g:764:9: ( normalParameterDecl ',' )+ ellipsisParameterDecl
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:764:9: ( normalParameterDecl ',' )+
					int cnt71 = 0;
					do 
					{
						int alt71 = 2;
						switch ( input.LA(1) ) 
						{
						case FINAL:
						{
							int LA71_1 = input.LA(2);

							if ( (synpred99_Java()) )
							{
								alt71 = 1;
							}


						}
							break;
						case MONKEYS_AT:
						{
							int LA71_2 = input.LA(2);

							if ( (synpred99_Java()) )
							{
								alt71 = 1;
							}


						}
							break;
						case IDENTIFIER:
						{
							int LA71_3 = input.LA(2);

							if ( (synpred99_Java()) )
							{
								alt71 = 1;
							}


						}
							break;
						case BOOLEAN:
						case BYTE:
						case CHAR:
						case DOUBLE:
						case FLOAT:
						case INT:
						case LONG:
						case SHORT:
						{
							int LA71_4 = input.LA(2);

							if ( (synpred99_Java()) )
							{
								alt71 = 1;
							}


						}
							break;

						}

						switch (alt71) 
						{
						case 1 :
							// Java.g:764:10: normalParameterDecl ','
						{
							PushFollow(FOLLOW_normalParameterDecl_in_formalParameterDecls3509);
							normalParameterDecl197 = normalParameterDecl();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalParameterDecl197.Tree, normalParameterDecl197, retval);
							char_literal198=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_formalParameterDecls3519); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal198_tree = (object)adaptor.Create(char_literal198, retval);
								adaptor.AddChild(root_0, char_literal198_tree);
							}

						}
							break;

						default:
							if ( cnt71 >= 1 ) goto loop71;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee71 =
								new EarlyExitException(71, input);
							throw eee71;
						}
						cnt71++;
					} while (true);

					loop71:
					;	// Stops C# compiler whining that label 'loop71' has no statements

					PushFollow(FOLLOW_ellipsisParameterDecl_in_formalParameterDecls3541);
					ellipsisParameterDecl199 = ellipsisParameterDecl();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ellipsisParameterDecl199.Tree, ellipsisParameterDecl199, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 39, formalParameterDecls_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "formalParameterDecls"

		public class normalParameterDecl_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "normalParameterDecl"
		// Java.g:770:1: normalParameterDecl : variableModifiers type IDENTIFIER ( '[' ']' )* ;
		public JavaParser.normalParameterDecl_return normalParameterDecl() // throws RecognitionException [1]
		{   
			JavaParser.normalParameterDecl_return retval = new JavaParser.normalParameterDecl_return();
			retval.Start = input.LT(1);
			int normalParameterDecl_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER202 = null;
			IToken char_literal203 = null;
			IToken char_literal204 = null;
			JavaParser.variableModifiers_return variableModifiers200 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type201 = default(JavaParser.type_return);


			object IDENTIFIER202_tree=null;
			object char_literal203_tree=null;
			object char_literal204_tree=null;

			const string elementName = "normalParameterDecl"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 40) ) 
				{
					return retval; 
				}
				// Java.g:773:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* )
				// Java.g:773:9: variableModifiers type IDENTIFIER ( '[' ']' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_variableModifiers_in_normalParameterDecl3570);
					variableModifiers200 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers200.Tree, variableModifiers200, retval);
					PushFollow(FOLLOW_type_in_normalParameterDecl3572);
					type201 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type201.Tree, type201, retval);
					IDENTIFIER202=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_normalParameterDecl3574); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER202_tree = (object)adaptor.Create(IDENTIFIER202, retval);
						adaptor.AddChild(root_0, IDENTIFIER202_tree);
					}
					// Java.g:774:9: ( '[' ']' )*
					do 
					{
						int alt73 = 2;
						int LA73_0 = input.LA(1);

						if ( (LA73_0 == LBRACKET) )
						{
							alt73 = 1;
						}


						switch (alt73) 
						{
						case 1 :
							// Java.g:774:10: '[' ']'
						{
							char_literal203=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_normalParameterDecl3585); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal203_tree = (object)adaptor.Create(char_literal203, retval);
								adaptor.AddChild(root_0, char_literal203_tree);
							}
							char_literal204=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_normalParameterDecl3587); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal204_tree = (object)adaptor.Create(char_literal204, retval);
								adaptor.AddChild(root_0, char_literal204_tree);
							}

						}
							break;

						default:
							goto loop73;
						}
					} while (true);

					loop73:
					;	// Stops C# compiler whining that label 'loop73' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 40, normalParameterDecl_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "normalParameterDecl"

		public class ellipsisParameterDecl_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "ellipsisParameterDecl"
		// Java.g:778:1: ellipsisParameterDecl : variableModifiers type '...' IDENTIFIER ;
		public JavaParser.ellipsisParameterDecl_return ellipsisParameterDecl() // throws RecognitionException [1]
		{   
			JavaParser.ellipsisParameterDecl_return retval = new JavaParser.ellipsisParameterDecl_return();
			retval.Start = input.LT(1);
			int ellipsisParameterDecl_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal207 = null;
			IToken IDENTIFIER208 = null;
			JavaParser.variableModifiers_return variableModifiers205 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type206 = default(JavaParser.type_return);


			object string_literal207_tree=null;
			object IDENTIFIER208_tree=null;

			const string elementName = "ellipsisParameterDecl"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 41) ) 
				{
					return retval; 
				}
				// Java.g:781:5: ( variableModifiers type '...' IDENTIFIER )
				// Java.g:781:9: variableModifiers type '...' IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_variableModifiers_in_ellipsisParameterDecl3627);
					variableModifiers205 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers205.Tree, variableModifiers205, retval);
					PushFollow(FOLLOW_type_in_ellipsisParameterDecl3637);
					type206 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type206.Tree, type206, retval);
					string_literal207=(IToken)Match(input,ELLIPSIS,FOLLOW_ELLIPSIS_in_ellipsisParameterDecl3640); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal207_tree = (object)adaptor.Create(string_literal207, retval);
						adaptor.AddChild(root_0, string_literal207_tree);
					}
					IDENTIFIER208=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_ellipsisParameterDecl3650); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER208_tree = (object)adaptor.Create(IDENTIFIER208, retval);
						adaptor.AddChild(root_0, IDENTIFIER208_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 41, ellipsisParameterDecl_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "ellipsisParameterDecl"

		public class explicitConstructorInvocation_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "explicitConstructorInvocation"
		// Java.g:787:1: explicitConstructorInvocation : ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' );
		public JavaParser.explicitConstructorInvocation_return explicitConstructorInvocation() // throws RecognitionException [1]
		{   
			JavaParser.explicitConstructorInvocation_return retval = new JavaParser.explicitConstructorInvocation_return();
			retval.Start = input.LT(1);
			int explicitConstructorInvocation_StartIndex = input.Index();
			object root_0 = null;

			IToken set210 = null;
			IToken char_literal212 = null;
			IToken char_literal214 = null;
			IToken string_literal216 = null;
			IToken char_literal218 = null;
			JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments209 = default(JavaParser.nonWildcardTypeArguments_return);

			JavaParser.arguments_return arguments211 = default(JavaParser.arguments_return);

			JavaParser.primary_return primary213 = default(JavaParser.primary_return);

			JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments215 = default(JavaParser.nonWildcardTypeArguments_return);

			JavaParser.arguments_return arguments217 = default(JavaParser.arguments_return);


			object set210_tree=null;
			object char_literal212_tree=null;
			object char_literal214_tree=null;
			object string_literal216_tree=null;
			object char_literal218_tree=null;

			const string elementName = "explicitConstructorInvocation"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 42) ) 
				{
					return retval; 
				}
				// Java.g:790:5: ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' )
				int alt76 = 2;
				alt76 = dfa76.Predict(input);
				switch (alt76) 
				{
				case 1 :
					// Java.g:790:9: ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:790:9: ( nonWildcardTypeArguments )?
					int alt74 = 2;
					int LA74_0 = input.LA(1);

					if ( (LA74_0 == LT) )
					{
						alt74 = 1;
					}
					switch (alt74) 
					{
					case 1 :
						// Java.g:790:10: nonWildcardTypeArguments
					{
						PushFollow(FOLLOW_nonWildcardTypeArguments_in_explicitConstructorInvocation3681);
						nonWildcardTypeArguments209 = nonWildcardTypeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, nonWildcardTypeArguments209.Tree, nonWildcardTypeArguments209, retval);

					}
						break;

					}

					set210 = (IToken)input.LT(1);
					if ( input.LA(1) == SUPER || input.LA(1) == THIS ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set210, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}

					PushFollow(FOLLOW_arguments_in_explicitConstructorInvocation3739);
					arguments211 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments211.Tree, arguments211, retval);
					char_literal212=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_explicitConstructorInvocation3741); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal212_tree = (object)adaptor.Create(char_literal212, retval);
						adaptor.AddChild(root_0, char_literal212_tree);
					}

				}
					break;
				case 2 :
					// Java.g:797:9: primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_primary_in_explicitConstructorInvocation3752);
					primary213 = primary();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primary213.Tree, primary213, retval);
					char_literal214=(IToken)Match(input,DOT,FOLLOW_DOT_in_explicitConstructorInvocation3762); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal214_tree = (object)adaptor.Create(char_literal214, retval);
						adaptor.AddChild(root_0, char_literal214_tree);
					}
					// Java.g:799:9: ( nonWildcardTypeArguments )?
					int alt75 = 2;
					int LA75_0 = input.LA(1);

					if ( (LA75_0 == LT) )
					{
						alt75 = 1;
					}
					switch (alt75) 
					{
					case 1 :
						// Java.g:799:10: nonWildcardTypeArguments
					{
						PushFollow(FOLLOW_nonWildcardTypeArguments_in_explicitConstructorInvocation3773);
						nonWildcardTypeArguments215 = nonWildcardTypeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, nonWildcardTypeArguments215.Tree, nonWildcardTypeArguments215, retval);

					}
						break;

					}

					string_literal216=(IToken)Match(input,SUPER,FOLLOW_SUPER_in_explicitConstructorInvocation3794); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal216_tree = (object)adaptor.Create(string_literal216, retval);
						adaptor.AddChild(root_0, string_literal216_tree);
					}
					PushFollow(FOLLOW_arguments_in_explicitConstructorInvocation3804);
					arguments217 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments217.Tree, arguments217, retval);
					char_literal218=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_explicitConstructorInvocation3806); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal218_tree = (object)adaptor.Create(char_literal218, retval);
						adaptor.AddChild(root_0, char_literal218_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 42, explicitConstructorInvocation_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "explicitConstructorInvocation"

		public class qualifiedName_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "qualifiedName"
		// Java.g:805:1: qualifiedName : IDENTIFIER ( '.' IDENTIFIER )* ;
		public JavaParser.qualifiedName_return qualifiedName() // throws RecognitionException [1]
		{   
			JavaParser.qualifiedName_return retval = new JavaParser.qualifiedName_return();
			retval.Start = input.LT(1);
			int qualifiedName_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER219 = null;
			IToken char_literal220 = null;
			IToken IDENTIFIER221 = null;

			object IDENTIFIER219_tree=null;
			object char_literal220_tree=null;
			object IDENTIFIER221_tree=null;

			const string elementName = "qualifiedName"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 43) ) 
				{
					return retval; 
				}
				// Java.g:808:5: ( IDENTIFIER ( '.' IDENTIFIER )* )
				// Java.g:808:9: IDENTIFIER ( '.' IDENTIFIER )*
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER219=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_qualifiedName3835); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER219_tree = (object)adaptor.Create(IDENTIFIER219, retval);
						adaptor.AddChild(root_0, IDENTIFIER219_tree);
					}
					// Java.g:809:9: ( '.' IDENTIFIER )*
					do 
					{
						int alt77 = 2;
						int LA77_0 = input.LA(1);

						if ( (LA77_0 == DOT) )
						{
							alt77 = 1;
						}


						switch (alt77) 
						{
						case 1 :
							// Java.g:809:10: '.' IDENTIFIER
						{
							char_literal220=(IToken)Match(input,DOT,FOLLOW_DOT_in_qualifiedName3846); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal220_tree = (object)adaptor.Create(char_literal220, retval);
								adaptor.AddChild(root_0, char_literal220_tree);
							}
							IDENTIFIER221=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_qualifiedName3848); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER221_tree = (object)adaptor.Create(IDENTIFIER221, retval);
								adaptor.AddChild(root_0, IDENTIFIER221_tree);
							}

						}
							break;

						default:
							goto loop77;
						}
					} while (true);

					loop77:
					;	// Stops C# compiler whining that label 'loop77' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 43, qualifiedName_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "qualifiedName"

		public class annotations_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotations"
		// Java.g:813:1: annotations : ( annotation )+ ;
		public JavaParser.annotations_return annotations() // throws RecognitionException [1]
		{   
			JavaParser.annotations_return retval = new JavaParser.annotations_return();
			retval.Start = input.LT(1);
			int annotations_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.annotation_return annotation222 = default(JavaParser.annotation_return);



			const string elementName = "annotations"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 44) ) 
				{
					return retval; 
				}
				// Java.g:816:5: ( ( annotation )+ )
				// Java.g:816:9: ( annotation )+
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:816:9: ( annotation )+
					int cnt78 = 0;
					do 
					{
						int alt78 = 2;
						int LA78_0 = input.LA(1);

						if ( (LA78_0 == MONKEYS_AT) )
						{
							alt78 = 1;
						}


						switch (alt78) 
						{
						case 1 :
							// Java.g:816:10: annotation
						{
							PushFollow(FOLLOW_annotation_in_annotations3889);
							annotation222 = annotation();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotation222.Tree, annotation222, retval);

						}
							break;

						default:
							if ( cnt78 >= 1 ) goto loop78;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee78 =
								new EarlyExitException(78, input);
							throw eee78;
						}
						cnt78++;
					} while (true);

					loop78:
					;	// Stops C# compiler whining that label 'loop78' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 44, annotations_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotations"

		public class annotation_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotation"
		// Java.g:820:1: annotation : '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )? ;
		public JavaParser.annotation_return annotation() // throws RecognitionException [1]
		{   
			JavaParser.annotation_return retval = new JavaParser.annotation_return();
			retval.Start = input.LT(1);
			int annotation_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal223 = null;
			IToken char_literal225 = null;
			IToken char_literal228 = null;
			JavaParser.qualifiedName_return qualifiedName224 = default(JavaParser.qualifiedName_return);

			JavaParser.elementValuePairs_return elementValuePairs226 = default(JavaParser.elementValuePairs_return);

			JavaParser.elementValue_return elementValue227 = default(JavaParser.elementValue_return);


			object char_literal223_tree=null;
			object char_literal225_tree=null;
			object char_literal228_tree=null;

			const string elementName = "annotation"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 45) ) 
				{
					return retval; 
				}
				// Java.g:827:5: ( '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )? )
				// Java.g:827:9: '@' qualifiedName ( '(' ( elementValuePairs | elementValue )? ')' )?
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal223=(IToken)Match(input,MONKEYS_AT,FOLLOW_MONKEYS_AT_in_annotation3931); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal223_tree = (object)adaptor.Create(char_literal223, retval);
						adaptor.AddChild(root_0, char_literal223_tree);
					}
					PushFollow(FOLLOW_qualifiedName_in_annotation3933);
					qualifiedName224 = qualifiedName();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, qualifiedName224.Tree, qualifiedName224, retval);
					// Java.g:828:9: ( '(' ( elementValuePairs | elementValue )? ')' )?
					int alt80 = 2;
					int LA80_0 = input.LA(1);

					if ( (LA80_0 == LPAREN) )
					{
						alt80 = 1;
					}
					switch (alt80) 
					{
					case 1 :
						// Java.g:828:13: '(' ( elementValuePairs | elementValue )? ')'
					{
						char_literal225=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_annotation3947); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal225_tree = (object)adaptor.Create(char_literal225, retval);
							adaptor.AddChild(root_0, char_literal225_tree);
						}
						// Java.g:829:19: ( elementValuePairs | elementValue )?
						int alt79 = 3;
						int LA79_0 = input.LA(1);

						if ( (LA79_0 == IDENTIFIER) )
						{
							int LA79_1 = input.LA(2);

							if ( (LA79_1 == EQ) )
							{
								alt79 = 1;
							}
							else if ( (LA79_1 == INSTANCEOF || (LA79_1 >= LPAREN && LA79_1 <= RPAREN) || LA79_1 == LBRACKET || LA79_1 == DOT || LA79_1 == QUES || (LA79_1 >= EQEQ && LA79_1 <= PERCENT) || (LA79_1 >= BANGEQ && LA79_1 <= LT)) )
							{
								alt79 = 2;
							}
						}
						else if ( ((LA79_0 >= INTLITERAL && LA79_0 <= NULL) || LA79_0 == BOOLEAN || LA79_0 == BYTE || LA79_0 == CHAR || LA79_0 == DOUBLE || LA79_0 == FLOAT || LA79_0 == INT || LA79_0 == LONG || LA79_0 == NEW || LA79_0 == SHORT || LA79_0 == SUPER || LA79_0 == THIS || LA79_0 == VOID || LA79_0 == LPAREN || LA79_0 == LBRACE || (LA79_0 >= BANG && LA79_0 <= TILDE) || (LA79_0 >= PLUSPLUS && LA79_0 <= SUB) || LA79_0 == MONKEYS_AT) )
						{
							alt79 = 2;
						}
						switch (alt79) 
						{
						case 1 :
							// Java.g:829:23: elementValuePairs
						{
							PushFollow(FOLLOW_elementValuePairs_in_annotation3974);
							elementValuePairs226 = elementValuePairs();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValuePairs226.Tree, elementValuePairs226, retval);

						}
							break;
						case 2 :
							// Java.g:830:23: elementValue
						{
							PushFollow(FOLLOW_elementValue_in_annotation3998);
							elementValue227 = elementValue();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValue227.Tree, elementValue227, retval);

						}
							break;

						}

						char_literal228=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_annotation4034); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal228_tree = (object)adaptor.Create(char_literal228, retval);
							adaptor.AddChild(root_0, char_literal228_tree);
						}

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 45, annotation_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotation"

		public class elementValuePairs_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "elementValuePairs"
		// Java.g:836:1: elementValuePairs : elementValuePair ( ',' elementValuePair )* ;
		public JavaParser.elementValuePairs_return elementValuePairs() // throws RecognitionException [1]
		{   
			JavaParser.elementValuePairs_return retval = new JavaParser.elementValuePairs_return();
			retval.Start = input.LT(1);
			int elementValuePairs_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal230 = null;
			JavaParser.elementValuePair_return elementValuePair229 = default(JavaParser.elementValuePair_return);

			JavaParser.elementValuePair_return elementValuePair231 = default(JavaParser.elementValuePair_return);


			object char_literal230_tree=null;

			const string elementName = "elementValuePairs"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 46) ) 
				{
					return retval; 
				}
				// Java.g:839:5: ( elementValuePair ( ',' elementValuePair )* )
				// Java.g:839:9: elementValuePair ( ',' elementValuePair )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_elementValuePair_in_elementValuePairs4075);
					elementValuePair229 = elementValuePair();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValuePair229.Tree, elementValuePair229, retval);
					// Java.g:840:9: ( ',' elementValuePair )*
					do 
					{
						int alt81 = 2;
						int LA81_0 = input.LA(1);

						if ( (LA81_0 == COMMA) )
						{
							alt81 = 1;
						}


						switch (alt81) 
						{
						case 1 :
							// Java.g:840:10: ',' elementValuePair
						{
							char_literal230=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_elementValuePairs4086); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal230_tree = (object)adaptor.Create(char_literal230, retval);
								adaptor.AddChild(root_0, char_literal230_tree);
							}
							PushFollow(FOLLOW_elementValuePair_in_elementValuePairs4088);
							elementValuePair231 = elementValuePair();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValuePair231.Tree, elementValuePair231, retval);

						}
							break;

						default:
							goto loop81;
						}
					} while (true);

					loop81:
					;	// Stops C# compiler whining that label 'loop81' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 46, elementValuePairs_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "elementValuePairs"

		public class elementValuePair_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "elementValuePair"
		// Java.g:844:1: elementValuePair : IDENTIFIER '=' elementValue ;
		public JavaParser.elementValuePair_return elementValuePair() // throws RecognitionException [1]
		{   
			JavaParser.elementValuePair_return retval = new JavaParser.elementValuePair_return();
			retval.Start = input.LT(1);
			int elementValuePair_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER232 = null;
			IToken char_literal233 = null;
			JavaParser.elementValue_return elementValue234 = default(JavaParser.elementValue_return);


			object IDENTIFIER232_tree=null;
			object char_literal233_tree=null;

			const string elementName = "elementValuePair"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 47) ) 
				{
					return retval; 
				}
				// Java.g:847:5: ( IDENTIFIER '=' elementValue )
				// Java.g:847:9: IDENTIFIER '=' elementValue
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER232=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_elementValuePair4128); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER232_tree = (object)adaptor.Create(IDENTIFIER232, retval);
						adaptor.AddChild(root_0, IDENTIFIER232_tree);
					}
					char_literal233=(IToken)Match(input,EQ,FOLLOW_EQ_in_elementValuePair4130); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal233_tree = (object)adaptor.Create(char_literal233, retval);
						adaptor.AddChild(root_0, char_literal233_tree);
					}
					PushFollow(FOLLOW_elementValue_in_elementValuePair4132);
					elementValue234 = elementValue();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValue234.Tree, elementValue234, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 47, elementValuePair_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "elementValuePair"

		public class elementValue_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "elementValue"
		// Java.g:850:1: elementValue : ( conditionalExpression | annotation | elementValueArrayInitializer );
		public JavaParser.elementValue_return elementValue() // throws RecognitionException [1]
		{   
			JavaParser.elementValue_return retval = new JavaParser.elementValue_return();
			retval.Start = input.LT(1);
			int elementValue_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.conditionalExpression_return conditionalExpression235 = default(JavaParser.conditionalExpression_return);

			JavaParser.annotation_return annotation236 = default(JavaParser.annotation_return);

			JavaParser.elementValueArrayInitializer_return elementValueArrayInitializer237 = default(JavaParser.elementValueArrayInitializer_return);



			const string elementName = "elementValue"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 48) ) 
				{
					return retval; 
				}
				// Java.g:853:5: ( conditionalExpression | annotation | elementValueArrayInitializer )
				int alt82 = 3;
				switch ( input.LA(1) ) 
				{
				case IDENTIFIER:
				case INTLITERAL:
				case LONGLITERAL:
				case FLOATLITERAL:
				case DOUBLELITERAL:
				case CHARLITERAL:
				case STRINGLITERAL:
				case TRUE:
				case FALSE:
				case NULL:
				case BOOLEAN:
				case BYTE:
				case CHAR:
				case DOUBLE:
				case FLOAT:
				case INT:
				case LONG:
				case NEW:
				case SHORT:
				case SUPER:
				case THIS:
				case VOID:
				case LPAREN:
				case BANG:
				case TILDE:
				case PLUSPLUS:
				case SUBSUB:
				case PLUS:
				case SUB:
				{
					alt82 = 1;
				}
					break;
				case MONKEYS_AT:
				{
					alt82 = 2;
				}
					break;
				case LBRACE:
				{
					alt82 = 3;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d82s0 =
						new NoViableAltException("", 82, 0, input);

					throw nvae_d82s0;
				}

				switch (alt82) 
				{
				case 1 :
					// Java.g:853:9: conditionalExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_conditionalExpression_in_elementValue4161);
					conditionalExpression235 = conditionalExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression235.Tree, conditionalExpression235, retval);

				}
					break;
				case 2 :
					// Java.g:854:9: annotation
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_annotation_in_elementValue4171);
					annotation236 = annotation();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotation236.Tree, annotation236, retval);

				}
					break;
				case 3 :
					// Java.g:855:9: elementValueArrayInitializer
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_elementValueArrayInitializer_in_elementValue4181);
					elementValueArrayInitializer237 = elementValueArrayInitializer();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValueArrayInitializer237.Tree, elementValueArrayInitializer237, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 48, elementValue_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "elementValue"

		public class elementValueArrayInitializer_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "elementValueArrayInitializer"
		// Java.g:858:1: elementValueArrayInitializer : '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}' ;
		public JavaParser.elementValueArrayInitializer_return elementValueArrayInitializer() // throws RecognitionException [1]
		{   
			JavaParser.elementValueArrayInitializer_return retval = new JavaParser.elementValueArrayInitializer_return();
			retval.Start = input.LT(1);
			int elementValueArrayInitializer_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal238 = null;
			IToken char_literal240 = null;
			IToken char_literal242 = null;
			IToken char_literal243 = null;
			JavaParser.elementValue_return elementValue239 = default(JavaParser.elementValue_return);

			JavaParser.elementValue_return elementValue241 = default(JavaParser.elementValue_return);


			object char_literal238_tree=null;
			object char_literal240_tree=null;
			object char_literal242_tree=null;
			object char_literal243_tree=null;

			const string elementName = "elementValueArrayInitializer"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 49) ) 
				{
					return retval; 
				}
				// Java.g:861:5: ( '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}' )
				// Java.g:861:9: '{' ( elementValue ( ',' elementValue )* )? ( ',' )? '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal238=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_elementValueArrayInitializer4210); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal238_tree = (object)adaptor.Create(char_literal238, retval);
						adaptor.AddChild(root_0, char_literal238_tree);
					}
					// Java.g:862:9: ( elementValue ( ',' elementValue )* )?
					int alt84 = 2;
					int LA84_0 = input.LA(1);

					if ( ((LA84_0 >= IDENTIFIER && LA84_0 <= NULL) || LA84_0 == BOOLEAN || LA84_0 == BYTE || LA84_0 == CHAR || LA84_0 == DOUBLE || LA84_0 == FLOAT || LA84_0 == INT || LA84_0 == LONG || LA84_0 == NEW || LA84_0 == SHORT || LA84_0 == SUPER || LA84_0 == THIS || LA84_0 == VOID || LA84_0 == LPAREN || LA84_0 == LBRACE || (LA84_0 >= BANG && LA84_0 <= TILDE) || (LA84_0 >= PLUSPLUS && LA84_0 <= SUB) || LA84_0 == MONKEYS_AT) )
					{
						alt84 = 1;
					}
					switch (alt84) 
					{
					case 1 :
						// Java.g:862:10: elementValue ( ',' elementValue )*
					{
						PushFollow(FOLLOW_elementValue_in_elementValueArrayInitializer4221);
						elementValue239 = elementValue();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValue239.Tree, elementValue239, retval);
						// Java.g:863:13: ( ',' elementValue )*
						do 
						{
							int alt83 = 2;
							int LA83_0 = input.LA(1);

							if ( (LA83_0 == COMMA) )
							{
								int LA83_1 = input.LA(2);

								if ( ((LA83_1 >= IDENTIFIER && LA83_1 <= NULL) || LA83_1 == BOOLEAN || LA83_1 == BYTE || LA83_1 == CHAR || LA83_1 == DOUBLE || LA83_1 == FLOAT || LA83_1 == INT || LA83_1 == LONG || LA83_1 == NEW || LA83_1 == SHORT || LA83_1 == SUPER || LA83_1 == THIS || LA83_1 == VOID || LA83_1 == LPAREN || LA83_1 == LBRACE || (LA83_1 >= BANG && LA83_1 <= TILDE) || (LA83_1 >= PLUSPLUS && LA83_1 <= SUB) || LA83_1 == MONKEYS_AT) )
								{
									alt83 = 1;
								}


							}


							switch (alt83) 
							{
							case 1 :
								// Java.g:863:14: ',' elementValue
							{
								char_literal240=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_elementValueArrayInitializer4236); if (state.failed) return retval;
								if ( state.backtracking == 0 )
								{char_literal240_tree = (object)adaptor.Create(char_literal240, retval);
									adaptor.AddChild(root_0, char_literal240_tree);
								}
								PushFollow(FOLLOW_elementValue_in_elementValueArrayInitializer4238);
								elementValue241 = elementValue();
								state.followingStackPointer--;
								if (state.failed) return retval;
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValue241.Tree, elementValue241, retval);

							}
								break;

							default:
								goto loop83;
							}
						} while (true);

						loop83:
						;	// Stops C# compiler whining that label 'loop83' has no statements


					}
						break;

					}

					// Java.g:865:12: ( ',' )?
					int alt85 = 2;
					int LA85_0 = input.LA(1);

					if ( (LA85_0 == COMMA) )
					{
						alt85 = 1;
					}
					switch (alt85) 
					{
					case 1 :
						// Java.g:865:13: ','
					{
						char_literal242=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_elementValueArrayInitializer4267); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal242_tree = (object)adaptor.Create(char_literal242, retval);
							adaptor.AddChild(root_0, char_literal242_tree);
						}

					}
						break;

					}

					char_literal243=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_elementValueArrayInitializer4271); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal243_tree = (object)adaptor.Create(char_literal243, retval);
						adaptor.AddChild(root_0, char_literal243_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 49, elementValueArrayInitializer_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "elementValueArrayInitializer"

		public class annotationTypeDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotationTypeDeclaration"
		// Java.g:869:1: annotationTypeDeclaration : modifiers '@' 'interface' IDENTIFIER annotationTypeBody ;
		public JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.annotationTypeDeclaration_return retval = new JavaParser.annotationTypeDeclaration_return();
			retval.Start = input.LT(1);
			int annotationTypeDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal245 = null;
			IToken string_literal246 = null;
			IToken IDENTIFIER247 = null;
			JavaParser.modifiers_return modifiers244 = default(JavaParser.modifiers_return);

			JavaParser.annotationTypeBody_return annotationTypeBody248 = default(JavaParser.annotationTypeBody_return);


			object char_literal245_tree=null;
			object string_literal246_tree=null;
			object IDENTIFIER247_tree=null;

			const string elementName = "annotationTypeDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 50) ) 
				{
					return retval; 
				}
				// Java.g:875:5: ( modifiers '@' 'interface' IDENTIFIER annotationTypeBody )
				// Java.g:875:9: modifiers '@' 'interface' IDENTIFIER annotationTypeBody
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_annotationTypeDeclaration4303);
					modifiers244 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers244.Tree, modifiers244, retval);
					char_literal245=(IToken)Match(input,MONKEYS_AT,FOLLOW_MONKEYS_AT_in_annotationTypeDeclaration4305); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal245_tree = (object)adaptor.Create(char_literal245, retval);
						adaptor.AddChild(root_0, char_literal245_tree);
					}
					string_literal246=(IToken)Match(input,INTERFACE,FOLLOW_INTERFACE_in_annotationTypeDeclaration4315); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal246_tree = (object)adaptor.Create(string_literal246, retval);
						adaptor.AddChild(root_0, string_literal246_tree);
					}
					IDENTIFIER247=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_annotationTypeDeclaration4325); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER247_tree = (object)adaptor.Create(IDENTIFIER247, retval);
						adaptor.AddChild(root_0, IDENTIFIER247_tree);
					}
					PushFollow(FOLLOW_annotationTypeBody_in_annotationTypeDeclaration4335);
					annotationTypeBody248 = annotationTypeBody();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotationTypeBody248.Tree, annotationTypeBody248, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 50, annotationTypeDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotationTypeDeclaration"

		public class annotationTypeBody_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotationTypeBody"
		// Java.g:882:1: annotationTypeBody : '{' ( annotationTypeElementDeclaration )* '}' ;
		public JavaParser.annotationTypeBody_return annotationTypeBody() // throws RecognitionException [1]
		{   
			JavaParser.annotationTypeBody_return retval = new JavaParser.annotationTypeBody_return();
			retval.Start = input.LT(1);
			int annotationTypeBody_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal249 = null;
			IToken char_literal251 = null;
			JavaParser.annotationTypeElementDeclaration_return annotationTypeElementDeclaration250 = default(JavaParser.annotationTypeElementDeclaration_return);


			object char_literal249_tree=null;
			object char_literal251_tree=null;

			const string elementName = "annotationTypeBody"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 51) ) 
				{
					return retval; 
				}
				// Java.g:885:5: ( '{' ( annotationTypeElementDeclaration )* '}' )
				// Java.g:885:9: '{' ( annotationTypeElementDeclaration )* '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal249=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_annotationTypeBody4365); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal249_tree = (object)adaptor.Create(char_literal249, retval);
						adaptor.AddChild(root_0, char_literal249_tree);
					}
					// Java.g:886:9: ( annotationTypeElementDeclaration )*
					do 
					{
						int alt86 = 2;
						int LA86_0 = input.LA(1);

						if ( (LA86_0 == IDENTIFIER || LA86_0 == ABSTRACT || LA86_0 == BOOLEAN || LA86_0 == BYTE || (LA86_0 >= CHAR && LA86_0 <= CLASS) || LA86_0 == DOUBLE || LA86_0 == ENUM || LA86_0 == FINAL || LA86_0 == FLOAT || (LA86_0 >= INT && LA86_0 <= NATIVE) || (LA86_0 >= PRIVATE && LA86_0 <= PUBLIC) || (LA86_0 >= SHORT && LA86_0 <= STRICTFP) || LA86_0 == SYNCHRONIZED || LA86_0 == TRANSIENT || (LA86_0 >= VOID && LA86_0 <= VOLATILE) || LA86_0 == SEMI || LA86_0 == MONKEYS_AT || LA86_0 == LT) )
						{
							alt86 = 1;
						}


						switch (alt86) 
						{
						case 1 :
							// Java.g:886:10: annotationTypeElementDeclaration
						{
							PushFollow(FOLLOW_annotationTypeElementDeclaration_in_annotationTypeBody4377);
							annotationTypeElementDeclaration250 = annotationTypeElementDeclaration();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotationTypeElementDeclaration250.Tree, annotationTypeElementDeclaration250, retval);

						}
							break;

						default:
							goto loop86;
						}
					} while (true);

					loop86:
					;	// Stops C# compiler whining that label 'loop86' has no statements

					char_literal251=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_annotationTypeBody4399); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal251_tree = (object)adaptor.Create(char_literal251, retval);
						adaptor.AddChild(root_0, char_literal251_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 51, annotationTypeBody_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotationTypeBody"

		public class annotationTypeElementDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotationTypeElementDeclaration"
		// Java.g:891:1: annotationTypeElementDeclaration : ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' );
		public JavaParser.annotationTypeElementDeclaration_return annotationTypeElementDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.annotationTypeElementDeclaration_return retval = new JavaParser.annotationTypeElementDeclaration_return();
			retval.Start = input.LT(1);
			int annotationTypeElementDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal258 = null;
			JavaParser.annotationMethodDeclaration_return annotationMethodDeclaration252 = default(JavaParser.annotationMethodDeclaration_return);

			JavaParser.interfaceFieldDeclaration_return interfaceFieldDeclaration253 = default(JavaParser.interfaceFieldDeclaration_return);

			JavaParser.normalClassDeclaration_return normalClassDeclaration254 = default(JavaParser.normalClassDeclaration_return);

			JavaParser.normalInterfaceDeclaration_return normalInterfaceDeclaration255 = default(JavaParser.normalInterfaceDeclaration_return);

			JavaParser.enumDeclaration_return enumDeclaration256 = default(JavaParser.enumDeclaration_return);

			JavaParser.annotationTypeDeclaration_return annotationTypeDeclaration257 = default(JavaParser.annotationTypeDeclaration_return);


			object char_literal258_tree=null;

			const string elementName = "annotationTypeElementDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 52) ) 
				{
					return retval; 
				}
				// Java.g:897:5: ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' )
				int alt87 = 7;
				alt87 = dfa87.Predict(input);
				switch (alt87) 
				{
				case 1 :
					// Java.g:897:9: annotationMethodDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_annotationMethodDeclaration_in_annotationTypeElementDeclaration4430);
					annotationMethodDeclaration252 = annotationMethodDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotationMethodDeclaration252.Tree, annotationMethodDeclaration252, retval);

				}
					break;
				case 2 :
					// Java.g:898:9: interfaceFieldDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_interfaceFieldDeclaration_in_annotationTypeElementDeclaration4440);
					interfaceFieldDeclaration253 = interfaceFieldDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, interfaceFieldDeclaration253.Tree, interfaceFieldDeclaration253, retval);

				}
					break;
				case 3 :
					// Java.g:899:9: normalClassDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_normalClassDeclaration_in_annotationTypeElementDeclaration4450);
					normalClassDeclaration254 = normalClassDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalClassDeclaration254.Tree, normalClassDeclaration254, retval);

				}
					break;
				case 4 :
					// Java.g:900:9: normalInterfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_normalInterfaceDeclaration_in_annotationTypeElementDeclaration4460);
					normalInterfaceDeclaration255 = normalInterfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, normalInterfaceDeclaration255.Tree, normalInterfaceDeclaration255, retval);

				}
					break;
				case 5 :
					// Java.g:901:9: enumDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_enumDeclaration_in_annotationTypeElementDeclaration4470);
					enumDeclaration256 = enumDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumDeclaration256.Tree, enumDeclaration256, retval);

				}
					break;
				case 6 :
					// Java.g:902:9: annotationTypeDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_annotationTypeDeclaration_in_annotationTypeElementDeclaration4480);
					annotationTypeDeclaration257 = annotationTypeDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, annotationTypeDeclaration257.Tree, annotationTypeDeclaration257, retval);

				}
					break;
				case 7 :
					// Java.g:903:9: ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal258=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_annotationTypeElementDeclaration4490); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal258_tree = (object)adaptor.Create(char_literal258, retval);
						adaptor.AddChild(root_0, char_literal258_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 52, annotationTypeElementDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotationTypeElementDeclaration"

		public class annotationMethodDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotationMethodDeclaration"
		// Java.g:906:1: annotationMethodDeclaration : modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';' ;
		public JavaParser.annotationMethodDeclaration_return annotationMethodDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.annotationMethodDeclaration_return retval = new JavaParser.annotationMethodDeclaration_return();
			retval.Start = input.LT(1);
			int annotationMethodDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER261 = null;
			IToken char_literal262 = null;
			IToken char_literal263 = null;
			IToken string_literal264 = null;
			IToken char_literal266 = null;
			JavaParser.modifiers_return modifiers259 = default(JavaParser.modifiers_return);

			JavaParser.type_return type260 = default(JavaParser.type_return);

			JavaParser.elementValue_return elementValue265 = default(JavaParser.elementValue_return);


			object IDENTIFIER261_tree=null;
			object char_literal262_tree=null;
			object char_literal263_tree=null;
			object string_literal264_tree=null;
			object char_literal266_tree=null;

			const string elementName = "annotationMethodDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 53) ) 
				{
					return retval; 
				}
				// Java.g:909:5: ( modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';' )
				// Java.g:909:9: modifiers type IDENTIFIER '(' ')' ( 'default' elementValue )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_annotationMethodDeclaration4519);
					modifiers259 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers259.Tree, modifiers259, retval);
					PushFollow(FOLLOW_type_in_annotationMethodDeclaration4521);
					type260 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type260.Tree, type260, retval);
					IDENTIFIER261=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_annotationMethodDeclaration4523); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER261_tree = (object)adaptor.Create(IDENTIFIER261, retval);
						adaptor.AddChild(root_0, IDENTIFIER261_tree);
					}
					char_literal262=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_annotationMethodDeclaration4533); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal262_tree = (object)adaptor.Create(char_literal262, retval);
						adaptor.AddChild(root_0, char_literal262_tree);
					}
					char_literal263=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_annotationMethodDeclaration4535); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal263_tree = (object)adaptor.Create(char_literal263, retval);
						adaptor.AddChild(root_0, char_literal263_tree);
					}
					// Java.g:910:17: ( 'default' elementValue )?
					int alt88 = 2;
					int LA88_0 = input.LA(1);

					if ( (LA88_0 == DEFAULT) )
					{
						alt88 = 1;
					}
					switch (alt88) 
					{
					case 1 :
						// Java.g:910:18: 'default' elementValue
					{
						string_literal264=(IToken)Match(input,DEFAULT,FOLLOW_DEFAULT_in_annotationMethodDeclaration4538); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal264_tree = (object)adaptor.Create(string_literal264, retval);
							adaptor.AddChild(root_0, string_literal264_tree);
						}
						PushFollow(FOLLOW_elementValue_in_annotationMethodDeclaration4540);
						elementValue265 = elementValue();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementValue265.Tree, elementValue265, retval);

					}
						break;

					}

					char_literal266=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_annotationMethodDeclaration4569); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal266_tree = (object)adaptor.Create(char_literal266, retval);
						adaptor.AddChild(root_0, char_literal266_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 53, annotationMethodDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotationMethodDeclaration"

		public class block_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "block"
		// Java.g:915:1: block : '{' ( blockStatement )* '}' ;
		public JavaParser.block_return block() // throws RecognitionException [1]
		{   
			JavaParser.block_return retval = new JavaParser.block_return();
			retval.Start = input.LT(1);
			int block_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal267 = null;
			IToken char_literal269 = null;
			JavaParser.blockStatement_return blockStatement268 = default(JavaParser.blockStatement_return);


			object char_literal267_tree=null;
			object char_literal269_tree=null;

			const string elementName = "block"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 54) ) 
				{
					return retval; 
				}
				// Java.g:918:5: ( '{' ( blockStatement )* '}' )
				// Java.g:918:9: '{' ( blockStatement )* '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal267=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_block4602); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal267_tree = (object)adaptor.Create(char_literal267, retval);
						adaptor.AddChild(root_0, char_literal267_tree);
					}
					// Java.g:919:9: ( blockStatement )*
					do 
					{
						int alt89 = 2;
						int LA89_0 = input.LA(1);

						if ( ((LA89_0 >= IDENTIFIER && LA89_0 <= NULL) || (LA89_0 >= ABSTRACT && LA89_0 <= BYTE) || (LA89_0 >= CHAR && LA89_0 <= CLASS) || LA89_0 == CONTINUE || (LA89_0 >= DO && LA89_0 <= DOUBLE) || LA89_0 == ENUM || LA89_0 == FINAL || (LA89_0 >= FLOAT && LA89_0 <= FOR) || LA89_0 == IF || (LA89_0 >= INT && LA89_0 <= NEW) || (LA89_0 >= PRIVATE && LA89_0 <= THROW) || (LA89_0 >= TRANSIENT && LA89_0 <= LPAREN) || LA89_0 == LBRACE || LA89_0 == SEMI || (LA89_0 >= BANG && LA89_0 <= TILDE) || (LA89_0 >= PLUSPLUS && LA89_0 <= SUB) || LA89_0 == MONKEYS_AT || LA89_0 == LT) )
						{
							alt89 = 1;
						}


						switch (alt89) 
						{
						case 1 :
							// Java.g:919:10: blockStatement
						{
							PushFollow(FOLLOW_blockStatement_in_block4613);
							blockStatement268 = blockStatement();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, blockStatement268.Tree, blockStatement268, retval);

						}
							break;

						default:
							goto loop89;
						}
					} while (true);

					loop89:
					;	// Stops C# compiler whining that label 'loop89' has no statements

					char_literal269=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_block4634); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal269_tree = (object)adaptor.Create(char_literal269, retval);
						adaptor.AddChild(root_0, char_literal269_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 54, block_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "block"

		public class blockStatement_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "blockStatement"
		// Java.g:948:1: blockStatement : ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement );
		public JavaParser.blockStatement_return blockStatement() // throws RecognitionException [1]
		{   
			JavaParser.blockStatement_return retval = new JavaParser.blockStatement_return();
			retval.Start = input.LT(1);
			int blockStatement_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.localVariableDeclarationStatement_return localVariableDeclarationStatement270 = default(JavaParser.localVariableDeclarationStatement_return);

			JavaParser.classOrInterfaceDeclaration_return classOrInterfaceDeclaration271 = default(JavaParser.classOrInterfaceDeclaration_return);

			JavaParser.statement_return statement272 = default(JavaParser.statement_return);



			const string elementName = "blockStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 55) ) 
				{
					return retval; 
				}
				// Java.g:951:5: ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement )
				int alt90 = 3;
				alt90 = dfa90.Predict(input);
				switch (alt90) 
				{
				case 1 :
					// Java.g:951:9: localVariableDeclarationStatement
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_localVariableDeclarationStatement_in_blockStatement4665);
					localVariableDeclarationStatement270 = localVariableDeclarationStatement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, localVariableDeclarationStatement270.Tree, localVariableDeclarationStatement270, retval);

				}
					break;
				case 2 :
					// Java.g:952:9: classOrInterfaceDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classOrInterfaceDeclaration_in_blockStatement4675);
					classOrInterfaceDeclaration271 = classOrInterfaceDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceDeclaration271.Tree, classOrInterfaceDeclaration271, retval);

				}
					break;
				case 3 :
					// Java.g:953:9: statement
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_statement_in_blockStatement4685);
					statement272 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement272.Tree, statement272, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 55, blockStatement_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "blockStatement"

		public class localVariableDeclarationStatement_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "localVariableDeclarationStatement"
		// Java.g:957:1: localVariableDeclarationStatement : localVariableDeclaration ';' ;
		public JavaParser.localVariableDeclarationStatement_return localVariableDeclarationStatement() // throws RecognitionException [1]
		{   
			JavaParser.localVariableDeclarationStatement_return retval = new JavaParser.localVariableDeclarationStatement_return();
			retval.Start = input.LT(1);
			int localVariableDeclarationStatement_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal274 = null;
			JavaParser.localVariableDeclaration_return localVariableDeclaration273 = default(JavaParser.localVariableDeclaration_return);


			object char_literal274_tree=null;

			const string elementName = "localVariableDeclarationStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 56) ) 
				{
					return retval; 
				}
				// Java.g:960:5: ( localVariableDeclaration ';' )
				// Java.g:960:9: localVariableDeclaration ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_localVariableDeclaration_in_localVariableDeclarationStatement4715);
					localVariableDeclaration273 = localVariableDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, localVariableDeclaration273.Tree, localVariableDeclaration273, retval);
					char_literal274=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_localVariableDeclarationStatement4725); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal274_tree = (object)adaptor.Create(char_literal274, retval);
						adaptor.AddChild(root_0, char_literal274_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 56, localVariableDeclarationStatement_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "localVariableDeclarationStatement"

		public class localVariableDeclaration_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "localVariableDeclaration"
		// Java.g:964:1: localVariableDeclaration : variableModifiers type variableDeclarator ( ',' variableDeclarator )* ;
		public JavaParser.localVariableDeclaration_return localVariableDeclaration() // throws RecognitionException [1]
		{   
			JavaParser.localVariableDeclaration_return retval = new JavaParser.localVariableDeclaration_return();
			retval.Start = input.LT(1);
			int localVariableDeclaration_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal278 = null;
			JavaParser.variableModifiers_return variableModifiers275 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type276 = default(JavaParser.type_return);

			JavaParser.variableDeclarator_return variableDeclarator277 = default(JavaParser.variableDeclarator_return);

			JavaParser.variableDeclarator_return variableDeclarator279 = default(JavaParser.variableDeclarator_return);


			object char_literal278_tree=null;

			const string elementName = "localVariableDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 57) ) 
				{
					return retval; 
				}
				// Java.g:967:5: ( variableModifiers type variableDeclarator ( ',' variableDeclarator )* )
				// Java.g:967:9: variableModifiers type variableDeclarator ( ',' variableDeclarator )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_variableModifiers_in_localVariableDeclaration4754);
					variableModifiers275 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers275.Tree, variableModifiers275, retval);
					PushFollow(FOLLOW_type_in_localVariableDeclaration4756);
					type276 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type276.Tree, type276, retval);
					PushFollow(FOLLOW_variableDeclarator_in_localVariableDeclaration4766);
					variableDeclarator277 = variableDeclarator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator277.Tree, variableDeclarator277, retval);
					// Java.g:969:9: ( ',' variableDeclarator )*
					do 
					{
						int alt91 = 2;
						int LA91_0 = input.LA(1);

						if ( (LA91_0 == COMMA) )
						{
							alt91 = 1;
						}


						switch (alt91) 
						{
						case 1 :
							// Java.g:969:10: ',' variableDeclarator
						{
							char_literal278=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_localVariableDeclaration4777); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal278_tree = (object)adaptor.Create(char_literal278, retval);
								adaptor.AddChild(root_0, char_literal278_tree);
							}
							PushFollow(FOLLOW_variableDeclarator_in_localVariableDeclaration4779);
							variableDeclarator279 = variableDeclarator();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarator279.Tree, variableDeclarator279, retval);

						}
							break;

						default:
							goto loop91;
						}
					} while (true);

					loop91:
					;	// Stops C# compiler whining that label 'loop91' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 57, localVariableDeclaration_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "localVariableDeclaration"

		public class statement_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "statement"
		// Java.g:973:1: statement : ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' );
		public JavaParser.statement_return statement() // throws RecognitionException [1]
		{   
			JavaParser.statement_return retval = new JavaParser.statement_return();
			retval.Start = input.LT(1);
			int statement_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal281 = null;
			IToken char_literal283 = null;
			IToken char_literal285 = null;
			IToken string_literal286 = null;
			IToken char_literal288 = null;
			IToken char_literal290 = null;
			IToken string_literal291 = null;
			IToken string_literal294 = null;
			IToken string_literal297 = null;
			IToken string_literal300 = null;
			IToken string_literal302 = null;
			IToken char_literal304 = null;
			IToken string_literal306 = null;
			IToken char_literal308 = null;
			IToken char_literal310 = null;
			IToken string_literal311 = null;
			IToken string_literal314 = null;
			IToken char_literal316 = null;
			IToken string_literal317 = null;
			IToken char_literal319 = null;
			IToken string_literal320 = null;
			IToken IDENTIFIER321 = null;
			IToken char_literal322 = null;
			IToken string_literal323 = null;
			IToken IDENTIFIER324 = null;
			IToken char_literal325 = null;
			IToken char_literal327 = null;
			IToken IDENTIFIER328 = null;
			IToken char_literal329 = null;
			IToken char_literal331 = null;
			JavaParser.block_return block280 = default(JavaParser.block_return);

			JavaParser.expression_return expression282 = default(JavaParser.expression_return);

			JavaParser.expression_return expression284 = default(JavaParser.expression_return);

			JavaParser.expression_return expression287 = default(JavaParser.expression_return);

			JavaParser.expression_return expression289 = default(JavaParser.expression_return);

			JavaParser.parExpression_return parExpression292 = default(JavaParser.parExpression_return);

			JavaParser.statement_return statement293 = default(JavaParser.statement_return);

			JavaParser.statement_return statement295 = default(JavaParser.statement_return);

			JavaParser.forstatement_return forstatement296 = default(JavaParser.forstatement_return);

			JavaParser.parExpression_return parExpression298 = default(JavaParser.parExpression_return);

			JavaParser.statement_return statement299 = default(JavaParser.statement_return);

			JavaParser.statement_return statement301 = default(JavaParser.statement_return);

			JavaParser.parExpression_return parExpression303 = default(JavaParser.parExpression_return);

			JavaParser.trystatement_return trystatement305 = default(JavaParser.trystatement_return);

			JavaParser.parExpression_return parExpression307 = default(JavaParser.parExpression_return);

			JavaParser.switchBlockStatementGroups_return switchBlockStatementGroups309 = default(JavaParser.switchBlockStatementGroups_return);

			JavaParser.parExpression_return parExpression312 = default(JavaParser.parExpression_return);

			JavaParser.block_return block313 = default(JavaParser.block_return);

			JavaParser.expression_return expression315 = default(JavaParser.expression_return);

			JavaParser.expression_return expression318 = default(JavaParser.expression_return);

			JavaParser.expression_return expression326 = default(JavaParser.expression_return);

			JavaParser.statement_return statement330 = default(JavaParser.statement_return);


			object string_literal281_tree=null;
			object char_literal283_tree=null;
			object char_literal285_tree=null;
			object string_literal286_tree=null;
			object char_literal288_tree=null;
			object char_literal290_tree=null;
			object string_literal291_tree=null;
			object string_literal294_tree=null;
			object string_literal297_tree=null;
			object string_literal300_tree=null;
			object string_literal302_tree=null;
			object char_literal304_tree=null;
			object string_literal306_tree=null;
			object char_literal308_tree=null;
			object char_literal310_tree=null;
			object string_literal311_tree=null;
			object string_literal314_tree=null;
			object char_literal316_tree=null;
			object string_literal317_tree=null;
			object char_literal319_tree=null;
			object string_literal320_tree=null;
			object IDENTIFIER321_tree=null;
			object char_literal322_tree=null;
			object string_literal323_tree=null;
			object IDENTIFIER324_tree=null;
			object char_literal325_tree=null;
			object char_literal327_tree=null;
			object IDENTIFIER328_tree=null;
			object char_literal329_tree=null;
			object char_literal331_tree=null;

			const string elementName = "statement"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 58) ) 
				{
					return retval; 
				}
				// Java.g:976:5: ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' )
				int alt98 = 17;
				alt98 = dfa98.Predict(input);
				switch (alt98) 
				{
				case 1 :
					// Java.g:976:9: block
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_block_in_statement4819);
					block280 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block280.Tree, block280, retval);

				}
					break;
				case 2 :
					// Java.g:978:9: ( 'assert' ) expression ( ':' expression )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:978:9: ( 'assert' )
					// Java.g:978:10: 'assert'
					{
						string_literal281=(IToken)Match(input,ASSERT,FOLLOW_ASSERT_in_statement4843); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal281_tree = (object)adaptor.Create(string_literal281, retval);
							adaptor.AddChild(root_0, string_literal281_tree);
						}

					}

					PushFollow(FOLLOW_expression_in_statement4863);
					expression282 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression282.Tree, expression282, retval);
					// Java.g:980:20: ( ':' expression )?
					int alt92 = 2;
					int LA92_0 = input.LA(1);

					if ( (LA92_0 == COLON) )
					{
						alt92 = 1;
					}
					switch (alt92) 
					{
					case 1 :
						// Java.g:980:21: ':' expression
					{
						char_literal283=(IToken)Match(input,COLON,FOLLOW_COLON_in_statement4866); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal283_tree = (object)adaptor.Create(char_literal283, retval);
							adaptor.AddChild(root_0, char_literal283_tree);
						}
						PushFollow(FOLLOW_expression_in_statement4868);
						expression284 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression284.Tree, expression284, retval);

					}
						break;

					}

					char_literal285=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement4872); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal285_tree = (object)adaptor.Create(char_literal285, retval);
						adaptor.AddChild(root_0, char_literal285_tree);
					}

				}
					break;
				case 3 :
					// Java.g:981:9: 'assert' expression ( ':' expression )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal286=(IToken)Match(input,ASSERT,FOLLOW_ASSERT_in_statement4882); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal286_tree = (object)adaptor.Create(string_literal286, retval);
						adaptor.AddChild(root_0, string_literal286_tree);
					}
					PushFollow(FOLLOW_expression_in_statement4885);
					expression287 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression287.Tree, expression287, retval);
					// Java.g:981:30: ( ':' expression )?
					int alt93 = 2;
					int LA93_0 = input.LA(1);

					if ( (LA93_0 == COLON) )
					{
						alt93 = 1;
					}
					switch (alt93) 
					{
					case 1 :
						// Java.g:981:31: ':' expression
					{
						char_literal288=(IToken)Match(input,COLON,FOLLOW_COLON_in_statement4888); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal288_tree = (object)adaptor.Create(char_literal288, retval);
							adaptor.AddChild(root_0, char_literal288_tree);
						}
						PushFollow(FOLLOW_expression_in_statement4890);
						expression289 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression289.Tree, expression289, retval);

					}
						break;

					}

					char_literal290=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement4894); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal290_tree = (object)adaptor.Create(char_literal290, retval);
						adaptor.AddChild(root_0, char_literal290_tree);
					}

				}
					break;
				case 4 :
					// Java.g:982:9: 'if' parExpression statement ( 'else' statement )?
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal291=(IToken)Match(input,IF,FOLLOW_IF_in_statement4916); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal291_tree = (object)adaptor.Create(string_literal291, retval);
						adaptor.AddChild(root_0, string_literal291_tree);
					}
					PushFollow(FOLLOW_parExpression_in_statement4918);
					parExpression292 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression292.Tree, parExpression292, retval);
					PushFollow(FOLLOW_statement_in_statement4920);
					statement293 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement293.Tree, statement293, retval);
					// Java.g:982:38: ( 'else' statement )?
					int alt94 = 2;
					int LA94_0 = input.LA(1);

					if ( (LA94_0 == ELSE) )
					{
						int LA94_1 = input.LA(2);

						if ( (synpred133_Java()) )
						{
							alt94 = 1;
						}
					}
					switch (alt94) 
					{
					case 1 :
						// Java.g:982:39: 'else' statement
					{
						string_literal294=(IToken)Match(input,ELSE,FOLLOW_ELSE_in_statement4923); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal294_tree = (object)adaptor.Create(string_literal294, retval);
							adaptor.AddChild(root_0, string_literal294_tree);
						}
						PushFollow(FOLLOW_statement_in_statement4925);
						statement295 = statement();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement295.Tree, statement295, retval);

					}
						break;

					}


				}
					break;
				case 5 :
					// Java.g:983:9: forstatement
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_forstatement_in_statement4947);
					forstatement296 = forstatement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forstatement296.Tree, forstatement296, retval);

				}
					break;
				case 6 :
					// Java.g:984:9: 'while' parExpression statement
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal297=(IToken)Match(input,WHILE,FOLLOW_WHILE_in_statement4957); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal297_tree = (object)adaptor.Create(string_literal297, retval);
						adaptor.AddChild(root_0, string_literal297_tree);
					}
					PushFollow(FOLLOW_parExpression_in_statement4959);
					parExpression298 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression298.Tree, parExpression298, retval);
					PushFollow(FOLLOW_statement_in_statement4961);
					statement299 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement299.Tree, statement299, retval);

				}
					break;
				case 7 :
					// Java.g:985:9: 'do' statement 'while' parExpression ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal300=(IToken)Match(input,DO,FOLLOW_DO_in_statement4971); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal300_tree = (object)adaptor.Create(string_literal300, retval);
						adaptor.AddChild(root_0, string_literal300_tree);
					}
					PushFollow(FOLLOW_statement_in_statement4973);
					statement301 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement301.Tree, statement301, retval);
					string_literal302=(IToken)Match(input,WHILE,FOLLOW_WHILE_in_statement4975); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal302_tree = (object)adaptor.Create(string_literal302, retval);
						adaptor.AddChild(root_0, string_literal302_tree);
					}
					PushFollow(FOLLOW_parExpression_in_statement4977);
					parExpression303 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression303.Tree, parExpression303, retval);
					char_literal304=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement4979); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal304_tree = (object)adaptor.Create(char_literal304, retval);
						adaptor.AddChild(root_0, char_literal304_tree);
					}

				}
					break;
				case 8 :
					// Java.g:986:9: trystatement
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_trystatement_in_statement4989);
					trystatement305 = trystatement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, trystatement305.Tree, trystatement305, retval);

				}
					break;
				case 9 :
					// Java.g:987:9: 'switch' parExpression '{' switchBlockStatementGroups '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal306=(IToken)Match(input,SWITCH,FOLLOW_SWITCH_in_statement4999); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal306_tree = (object)adaptor.Create(string_literal306, retval);
						adaptor.AddChild(root_0, string_literal306_tree);
					}
					PushFollow(FOLLOW_parExpression_in_statement5001);
					parExpression307 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression307.Tree, parExpression307, retval);
					char_literal308=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_statement5003); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal308_tree = (object)adaptor.Create(char_literal308, retval);
						adaptor.AddChild(root_0, char_literal308_tree);
					}
					PushFollow(FOLLOW_switchBlockStatementGroups_in_statement5005);
					switchBlockStatementGroups309 = switchBlockStatementGroups();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchBlockStatementGroups309.Tree, switchBlockStatementGroups309, retval);
					char_literal310=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_statement5007); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal310_tree = (object)adaptor.Create(char_literal310, retval);
						adaptor.AddChild(root_0, char_literal310_tree);
					}

				}
					break;
				case 10 :
					// Java.g:988:9: 'synchronized' parExpression block
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal311=(IToken)Match(input,SYNCHRONIZED,FOLLOW_SYNCHRONIZED_in_statement5017); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal311_tree = (object)adaptor.Create(string_literal311, retval);
						adaptor.AddChild(root_0, string_literal311_tree);
					}
					PushFollow(FOLLOW_parExpression_in_statement5019);
					parExpression312 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression312.Tree, parExpression312, retval);
					PushFollow(FOLLOW_block_in_statement5021);
					block313 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block313.Tree, block313, retval);

				}
					break;
				case 11 :
					// Java.g:989:9: 'return' ( expression )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal314=(IToken)Match(input,RETURN,FOLLOW_RETURN_in_statement5031); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal314_tree = (object)adaptor.Create(string_literal314, retval);
						adaptor.AddChild(root_0, string_literal314_tree);
					}
					// Java.g:989:18: ( expression )?
					int alt95 = 2;
					int LA95_0 = input.LA(1);

					if ( ((LA95_0 >= IDENTIFIER && LA95_0 <= NULL) || LA95_0 == BOOLEAN || LA95_0 == BYTE || LA95_0 == CHAR || LA95_0 == DOUBLE || LA95_0 == FLOAT || LA95_0 == INT || LA95_0 == LONG || LA95_0 == NEW || LA95_0 == SHORT || LA95_0 == SUPER || LA95_0 == THIS || LA95_0 == VOID || LA95_0 == LPAREN || (LA95_0 >= BANG && LA95_0 <= TILDE) || (LA95_0 >= PLUSPLUS && LA95_0 <= SUB)) )
					{
						alt95 = 1;
					}
					switch (alt95) 
					{
					case 1 :
						// Java.g:989:19: expression
					{
						PushFollow(FOLLOW_expression_in_statement5034);
						expression315 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression315.Tree, expression315, retval);

					}
						break;

					}

					char_literal316=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5039); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal316_tree = (object)adaptor.Create(char_literal316, retval);
						adaptor.AddChild(root_0, char_literal316_tree);
					}

				}
					break;
				case 12 :
					// Java.g:990:9: 'throw' expression ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal317=(IToken)Match(input,THROW,FOLLOW_THROW_in_statement5049); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal317_tree = (object)adaptor.Create(string_literal317, retval);
						adaptor.AddChild(root_0, string_literal317_tree);
					}
					PushFollow(FOLLOW_expression_in_statement5051);
					expression318 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression318.Tree, expression318, retval);
					char_literal319=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5053); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal319_tree = (object)adaptor.Create(char_literal319, retval);
						adaptor.AddChild(root_0, char_literal319_tree);
					}

				}
					break;
				case 13 :
					// Java.g:991:9: 'break' ( IDENTIFIER )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal320=(IToken)Match(input,BREAK,FOLLOW_BREAK_in_statement5063); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal320_tree = (object)adaptor.Create(string_literal320, retval);
						adaptor.AddChild(root_0, string_literal320_tree);
					}
					// Java.g:992:13: ( IDENTIFIER )?
					int alt96 = 2;
					int LA96_0 = input.LA(1);

					if ( (LA96_0 == IDENTIFIER) )
					{
						alt96 = 1;
					}
					switch (alt96) 
					{
					case 1 :
						// Java.g:992:14: IDENTIFIER
					{
						IDENTIFIER321=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_statement5078); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{IDENTIFIER321_tree = (object)adaptor.Create(IDENTIFIER321, retval);
							adaptor.AddChild(root_0, IDENTIFIER321_tree);
						}

					}
						break;

					}

					char_literal322=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5095); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal322_tree = (object)adaptor.Create(char_literal322, retval);
						adaptor.AddChild(root_0, char_literal322_tree);
					}

				}
					break;
				case 14 :
					// Java.g:994:9: 'continue' ( IDENTIFIER )? ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal323=(IToken)Match(input,CONTINUE,FOLLOW_CONTINUE_in_statement5105); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal323_tree = (object)adaptor.Create(string_literal323, retval);
						adaptor.AddChild(root_0, string_literal323_tree);
					}
					// Java.g:995:13: ( IDENTIFIER )?
					int alt97 = 2;
					int LA97_0 = input.LA(1);

					if ( (LA97_0 == IDENTIFIER) )
					{
						alt97 = 1;
					}
					switch (alt97) 
					{
					case 1 :
						// Java.g:995:14: IDENTIFIER
					{
						IDENTIFIER324=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_statement5120); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{IDENTIFIER324_tree = (object)adaptor.Create(IDENTIFIER324, retval);
							adaptor.AddChild(root_0, IDENTIFIER324_tree);
						}

					}
						break;

					}

					char_literal325=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5137); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal325_tree = (object)adaptor.Create(char_literal325, retval);
						adaptor.AddChild(root_0, char_literal325_tree);
					}

				}
					break;
				case 15 :
					// Java.g:997:9: expression ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_expression_in_statement5147);
					expression326 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression326.Tree, expression326, retval);
					char_literal327=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5150); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal327_tree = (object)adaptor.Create(char_literal327, retval);
						adaptor.AddChild(root_0, char_literal327_tree);
					}

				}
					break;
				case 16 :
					// Java.g:998:9: IDENTIFIER ':' statement
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER328=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_statement5165); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER328_tree = (object)adaptor.Create(IDENTIFIER328, retval);
						adaptor.AddChild(root_0, IDENTIFIER328_tree);
					}
					char_literal329=(IToken)Match(input,COLON,FOLLOW_COLON_in_statement5167); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal329_tree = (object)adaptor.Create(char_literal329, retval);
						adaptor.AddChild(root_0, char_literal329_tree);
					}
					PushFollow(FOLLOW_statement_in_statement5169);
					statement330 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement330.Tree, statement330, retval);

				}
					break;
				case 17 :
					// Java.g:999:9: ';'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal331=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_statement5179); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal331_tree = (object)adaptor.Create(char_literal331, retval);
						adaptor.AddChild(root_0, char_literal331_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 58, statement_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "statement"

		public class switchBlockStatementGroups_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "switchBlockStatementGroups"
		// Java.g:1003:1: switchBlockStatementGroups : ( switchBlockStatementGroup )* ;
		public JavaParser.switchBlockStatementGroups_return switchBlockStatementGroups() // throws RecognitionException [1]
		{   
			JavaParser.switchBlockStatementGroups_return retval = new JavaParser.switchBlockStatementGroups_return();
			retval.Start = input.LT(1);
			int switchBlockStatementGroups_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.switchBlockStatementGroup_return switchBlockStatementGroup332 = default(JavaParser.switchBlockStatementGroup_return);



			const string elementName = "switchBlockStatementGroups"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 59) ) 
				{
					return retval; 
				}
				// Java.g:1006:5: ( ( switchBlockStatementGroup )* )
				// Java.g:1006:9: ( switchBlockStatementGroup )*
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:1006:9: ( switchBlockStatementGroup )*
					do 
					{
						int alt99 = 2;
						int LA99_0 = input.LA(1);

						if ( (LA99_0 == CASE || LA99_0 == DEFAULT) )
						{
							alt99 = 1;
						}


						switch (alt99) 
						{
						case 1 :
							// Java.g:1006:10: switchBlockStatementGroup
						{
							PushFollow(FOLLOW_switchBlockStatementGroup_in_switchBlockStatementGroups5210);
							switchBlockStatementGroup332 = switchBlockStatementGroup();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchBlockStatementGroup332.Tree, switchBlockStatementGroup332, retval);

						}
							break;

						default:
							goto loop99;
						}
					} while (true);

					loop99:
					;	// Stops C# compiler whining that label 'loop99' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 59, switchBlockStatementGroups_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "switchBlockStatementGroups"

		public class switchBlockStatementGroup_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "switchBlockStatementGroup"
		// Java.g:1009:1: switchBlockStatementGroup : switchLabel ( blockStatement )* ;
		public JavaParser.switchBlockStatementGroup_return switchBlockStatementGroup() // throws RecognitionException [1]
		{   
			JavaParser.switchBlockStatementGroup_return retval = new JavaParser.switchBlockStatementGroup_return();
			retval.Start = input.LT(1);
			int switchBlockStatementGroup_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.switchLabel_return switchLabel333 = default(JavaParser.switchLabel_return);

			JavaParser.blockStatement_return blockStatement334 = default(JavaParser.blockStatement_return);



			const string elementName = "switchBlockStatementGroup"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 60) ) 
				{
					return retval; 
				}
				// Java.g:1012:5: ( switchLabel ( blockStatement )* )
				// Java.g:1013:9: switchLabel ( blockStatement )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_switchLabel_in_switchBlockStatementGroup5248);
					switchLabel333 = switchLabel();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchLabel333.Tree, switchLabel333, retval);
					// Java.g:1014:9: ( blockStatement )*
					do 
					{
						int alt100 = 2;
						int LA100_0 = input.LA(1);

						if ( ((LA100_0 >= IDENTIFIER && LA100_0 <= NULL) || (LA100_0 >= ABSTRACT && LA100_0 <= BYTE) || (LA100_0 >= CHAR && LA100_0 <= CLASS) || LA100_0 == CONTINUE || (LA100_0 >= DO && LA100_0 <= DOUBLE) || LA100_0 == ENUM || LA100_0 == FINAL || (LA100_0 >= FLOAT && LA100_0 <= FOR) || LA100_0 == IF || (LA100_0 >= INT && LA100_0 <= NEW) || (LA100_0 >= PRIVATE && LA100_0 <= THROW) || (LA100_0 >= TRANSIENT && LA100_0 <= LPAREN) || LA100_0 == LBRACE || LA100_0 == SEMI || (LA100_0 >= BANG && LA100_0 <= TILDE) || (LA100_0 >= PLUSPLUS && LA100_0 <= SUB) || LA100_0 == MONKEYS_AT || LA100_0 == LT) )
						{
							alt100 = 1;
						}


						switch (alt100) 
						{
						case 1 :
							// Java.g:1014:10: blockStatement
						{
							PushFollow(FOLLOW_blockStatement_in_switchBlockStatementGroup5259);
							blockStatement334 = blockStatement();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, blockStatement334.Tree, blockStatement334, retval);

						}
							break;

						default:
							goto loop100;
						}
					} while (true);

					loop100:
					;	// Stops C# compiler whining that label 'loop100' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 60, switchBlockStatementGroup_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "switchBlockStatementGroup"

		public class switchLabel_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "switchLabel"
		// Java.g:1018:1: switchLabel : ( 'case' expression ':' | 'default' ':' );
		public JavaParser.switchLabel_return switchLabel() // throws RecognitionException [1]
		{   
			JavaParser.switchLabel_return retval = new JavaParser.switchLabel_return();
			retval.Start = input.LT(1);
			int switchLabel_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal335 = null;
			IToken char_literal337 = null;
			IToken string_literal338 = null;
			IToken char_literal339 = null;
			JavaParser.expression_return expression336 = default(JavaParser.expression_return);


			object string_literal335_tree=null;
			object char_literal337_tree=null;
			object string_literal338_tree=null;
			object char_literal339_tree=null;

			const string elementName = "switchLabel"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 61) ) 
				{
					return retval; 
				}
				// Java.g:1021:5: ( 'case' expression ':' | 'default' ':' )
				int alt101 = 2;
				int LA101_0 = input.LA(1);

				if ( (LA101_0 == CASE) )
				{
					alt101 = 1;
				}
				else if ( (LA101_0 == DEFAULT) )
				{
					alt101 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d101s0 =
						new NoViableAltException("", 101, 0, input);

					throw nvae_d101s0;
				}
				switch (alt101) 
				{
				case 1 :
					// Java.g:1021:9: 'case' expression ':'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal335=(IToken)Match(input,CASE,FOLLOW_CASE_in_switchLabel5299); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal335_tree = (object)adaptor.Create(string_literal335, retval);
						adaptor.AddChild(root_0, string_literal335_tree);
					}
					PushFollow(FOLLOW_expression_in_switchLabel5301);
					expression336 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression336.Tree, expression336, retval);
					char_literal337=(IToken)Match(input,COLON,FOLLOW_COLON_in_switchLabel5303); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal337_tree = (object)adaptor.Create(char_literal337, retval);
						adaptor.AddChild(root_0, char_literal337_tree);
					}

				}
					break;
				case 2 :
					// Java.g:1022:9: 'default' ':'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal338=(IToken)Match(input,DEFAULT,FOLLOW_DEFAULT_in_switchLabel5313); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal338_tree = (object)adaptor.Create(string_literal338, retval);
						adaptor.AddChild(root_0, string_literal338_tree);
					}
					char_literal339=(IToken)Match(input,COLON,FOLLOW_COLON_in_switchLabel5315); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal339_tree = (object)adaptor.Create(char_literal339, retval);
						adaptor.AddChild(root_0, char_literal339_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 61, switchLabel_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "switchLabel"

		public class trystatement_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "trystatement"
		// Java.g:1026:1: trystatement : 'try' block ( catches 'finally' block | catches | 'finally' block ) ;
		public JavaParser.trystatement_return trystatement() // throws RecognitionException [1]
		{   
			JavaParser.trystatement_return retval = new JavaParser.trystatement_return();
			retval.Start = input.LT(1);
			int trystatement_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal340 = null;
			IToken string_literal343 = null;
			IToken string_literal346 = null;
			JavaParser.block_return block341 = default(JavaParser.block_return);

			JavaParser.catches_return catches342 = default(JavaParser.catches_return);

			JavaParser.block_return block344 = default(JavaParser.block_return);

			JavaParser.catches_return catches345 = default(JavaParser.catches_return);

			JavaParser.block_return block347 = default(JavaParser.block_return);


			object string_literal340_tree=null;
			object string_literal343_tree=null;
			object string_literal346_tree=null;

			const string elementName = "trystatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 62) ) 
				{
					return retval; 
				}
				// Java.g:1029:5: ( 'try' block ( catches 'finally' block | catches | 'finally' block ) )
				// Java.g:1029:9: 'try' block ( catches 'finally' block | catches | 'finally' block )
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal340=(IToken)Match(input,TRY,FOLLOW_TRY_in_trystatement5345); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal340_tree = (object)adaptor.Create(string_literal340, retval);
						adaptor.AddChild(root_0, string_literal340_tree);
					}
					PushFollow(FOLLOW_block_in_trystatement5347);
					block341 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block341.Tree, block341, retval);
					// Java.g:1030:9: ( catches 'finally' block | catches | 'finally' block )
					int alt102 = 3;
					int LA102_0 = input.LA(1);

					if ( (LA102_0 == CATCH) )
					{
						int LA102_1 = input.LA(2);

						if ( (synpred153_Java()) )
						{
							alt102 = 1;
						}
						else if ( (synpred154_Java()) )
						{
							alt102 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d102s1 =
								new NoViableAltException("", 102, 1, input);

							throw nvae_d102s1;
						}
					}
					else if ( (LA102_0 == FINALLY) )
					{
						alt102 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d102s0 =
							new NoViableAltException("", 102, 0, input);

						throw nvae_d102s0;
					}
					switch (alt102) 
					{
					case 1 :
						// Java.g:1030:13: catches 'finally' block
					{
						PushFollow(FOLLOW_catches_in_trystatement5361);
						catches342 = catches();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catches342.Tree, catches342, retval);
						string_literal343=(IToken)Match(input,FINALLY,FOLLOW_FINALLY_in_trystatement5363); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal343_tree = (object)adaptor.Create(string_literal343, retval);
							adaptor.AddChild(root_0, string_literal343_tree);
						}
						PushFollow(FOLLOW_block_in_trystatement5365);
						block344 = block();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block344.Tree, block344, retval);

					}
						break;
					case 2 :
						// Java.g:1031:13: catches
					{
						PushFollow(FOLLOW_catches_in_trystatement5379);
						catches345 = catches();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catches345.Tree, catches345, retval);

					}
						break;
					case 3 :
						// Java.g:1032:13: 'finally' block
					{
						string_literal346=(IToken)Match(input,FINALLY,FOLLOW_FINALLY_in_trystatement5393); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal346_tree = (object)adaptor.Create(string_literal346, retval);
							adaptor.AddChild(root_0, string_literal346_tree);
						}
						PushFollow(FOLLOW_block_in_trystatement5395);
						block347 = block();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block347.Tree, block347, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 62, trystatement_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "trystatement"

		public class catches_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "catches"
		// Java.g:1036:1: catches : catchClause ( catchClause )* ;
		public JavaParser.catches_return catches() // throws RecognitionException [1]
		{   
			JavaParser.catches_return retval = new JavaParser.catches_return();
			retval.Start = input.LT(1);
			int catches_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.catchClause_return catchClause348 = default(JavaParser.catchClause_return);

			JavaParser.catchClause_return catchClause349 = default(JavaParser.catchClause_return);



			const string elementName = "catches"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 63) ) 
				{
					return retval; 
				}
				// Java.g:1039:5: ( catchClause ( catchClause )* )
				// Java.g:1039:9: catchClause ( catchClause )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_catchClause_in_catches5435);
					catchClause348 = catchClause();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catchClause348.Tree, catchClause348, retval);
					// Java.g:1040:9: ( catchClause )*
					do 
					{
						int alt103 = 2;
						int LA103_0 = input.LA(1);

						if ( (LA103_0 == CATCH) )
						{
							alt103 = 1;
						}


						switch (alt103) 
						{
						case 1 :
							// Java.g:1040:10: catchClause
						{
							PushFollow(FOLLOW_catchClause_in_catches5446);
							catchClause349 = catchClause();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catchClause349.Tree, catchClause349, retval);

						}
							break;

						default:
							goto loop103;
						}
					} while (true);

					loop103:
					;	// Stops C# compiler whining that label 'loop103' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 63, catches_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "catches"

		public class catchClause_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "catchClause"
		// Java.g:1044:1: catchClause : 'catch' '(' formalParameter ')' block ;
		public JavaParser.catchClause_return catchClause() // throws RecognitionException [1]
		{   
			JavaParser.catchClause_return retval = new JavaParser.catchClause_return();
			retval.Start = input.LT(1);
			int catchClause_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal350 = null;
			IToken char_literal351 = null;
			IToken char_literal353 = null;
			JavaParser.formalParameter_return formalParameter352 = default(JavaParser.formalParameter_return);

			JavaParser.block_return block354 = default(JavaParser.block_return);


			object string_literal350_tree=null;
			object char_literal351_tree=null;
			object char_literal353_tree=null;

			const string elementName = "catchClause"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 64) ) 
				{
					return retval; 
				}
				// Java.g:1047:5: ( 'catch' '(' formalParameter ')' block )
				// Java.g:1047:9: 'catch' '(' formalParameter ')' block
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal350=(IToken)Match(input,CATCH,FOLLOW_CATCH_in_catchClause5486); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal350_tree = (object)adaptor.Create(string_literal350, retval);
						adaptor.AddChild(root_0, string_literal350_tree);
					}
					char_literal351=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_catchClause5488); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal351_tree = (object)adaptor.Create(char_literal351, retval);
						adaptor.AddChild(root_0, char_literal351_tree);
					}
					PushFollow(FOLLOW_formalParameter_in_catchClause5490);
					formalParameter352 = formalParameter();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameter352.Tree, formalParameter352, retval);
					char_literal353=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_catchClause5500); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal353_tree = (object)adaptor.Create(char_literal353, retval);
						adaptor.AddChild(root_0, char_literal353_tree);
					}
					PushFollow(FOLLOW_block_in_catchClause5502);
					block354 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block354.Tree, block354, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 64, catchClause_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "catchClause"

		public class formalParameter_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "formalParameter"
		// Java.g:1051:1: formalParameter : variableModifiers type IDENTIFIER ( '[' ']' )* ;
		public JavaParser.formalParameter_return formalParameter() // throws RecognitionException [1]
		{   
			JavaParser.formalParameter_return retval = new JavaParser.formalParameter_return();
			retval.Start = input.LT(1);
			int formalParameter_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER357 = null;
			IToken char_literal358 = null;
			IToken char_literal359 = null;
			JavaParser.variableModifiers_return variableModifiers355 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type356 = default(JavaParser.type_return);


			object IDENTIFIER357_tree=null;
			object char_literal358_tree=null;
			object char_literal359_tree=null;

			const string elementName = "formalParameter"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 65) ) 
				{
					return retval; 
				}
				// Java.g:1054:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* )
				// Java.g:1054:9: variableModifiers type IDENTIFIER ( '[' ']' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_variableModifiers_in_formalParameter5532);
					variableModifiers355 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers355.Tree, variableModifiers355, retval);
					PushFollow(FOLLOW_type_in_formalParameter5534);
					type356 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type356.Tree, type356, retval);
					IDENTIFIER357=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_formalParameter5536); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER357_tree = (object)adaptor.Create(IDENTIFIER357, retval);
						adaptor.AddChild(root_0, IDENTIFIER357_tree);
					}
					// Java.g:1055:9: ( '[' ']' )*
					do 
					{
						int alt104 = 2;
						int LA104_0 = input.LA(1);

						if ( (LA104_0 == LBRACKET) )
						{
							alt104 = 1;
						}


						switch (alt104) 
						{
						case 1 :
							// Java.g:1055:10: '[' ']'
						{
							char_literal358=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_formalParameter5547); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal358_tree = (object)adaptor.Create(char_literal358, retval);
								adaptor.AddChild(root_0, char_literal358_tree);
							}
							char_literal359=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_formalParameter5549); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal359_tree = (object)adaptor.Create(char_literal359, retval);
								adaptor.AddChild(root_0, char_literal359_tree);
							}

						}
							break;

						default:
							goto loop104;
						}
					} while (true);

					loop104:
					;	// Stops C# compiler whining that label 'loop104' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 65, formalParameter_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "formalParameter"

		public class forstatement_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "forstatement"
		// Java.g:1059:1: forstatement : ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement | 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement );
		public JavaParser.forstatement_return forstatement() // throws RecognitionException [1]
		{   
			JavaParser.forstatement_return retval = new JavaParser.forstatement_return();
			retval.Start = input.LT(1);
			int forstatement_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal360 = null;
			IToken char_literal361 = null;
			IToken IDENTIFIER364 = null;
			IToken char_literal365 = null;
			IToken char_literal367 = null;
			IToken string_literal369 = null;
			IToken char_literal370 = null;
			IToken char_literal372 = null;
			IToken char_literal374 = null;
			IToken char_literal376 = null;
			JavaParser.variableModifiers_return variableModifiers362 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type363 = default(JavaParser.type_return);

			JavaParser.expression_return expression366 = default(JavaParser.expression_return);

			JavaParser.statement_return statement368 = default(JavaParser.statement_return);

			JavaParser.forInit_return forInit371 = default(JavaParser.forInit_return);

			JavaParser.expression_return expression373 = default(JavaParser.expression_return);

			JavaParser.expressionList_return expressionList375 = default(JavaParser.expressionList_return);

			JavaParser.statement_return statement377 = default(JavaParser.statement_return);


			object string_literal360_tree=null;
			object char_literal361_tree=null;
			object IDENTIFIER364_tree=null;
			object char_literal365_tree=null;
			object char_literal367_tree=null;
			object string_literal369_tree=null;
			object char_literal370_tree=null;
			object char_literal372_tree=null;
			object char_literal374_tree=null;
			object char_literal376_tree=null;

			const string elementName = "forstatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 66) ) 
				{
					return retval; 
				}
				// Java.g:1062:5: ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement | 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement )
				int alt108 = 2;
				int LA108_0 = input.LA(1);

				if ( (LA108_0 == FOR) )
				{
					int LA108_1 = input.LA(2);

					if ( (synpred157_Java()) )
					{
						alt108 = 1;
					}
					else if ( (true) )
					{
						alt108 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d108s1 =
							new NoViableAltException("", 108, 1, input);

						throw nvae_d108s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d108s0 =
						new NoViableAltException("", 108, 0, input);

					throw nvae_d108s0;
				}
				switch (alt108) 
				{
				case 1 :
					// Java.g:1064:9: 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal360=(IToken)Match(input,FOR,FOLLOW_FOR_in_forstatement5607); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal360_tree = (object)adaptor.Create(string_literal360, retval);
						adaptor.AddChild(root_0, string_literal360_tree);
					}
					char_literal361=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_forstatement5609); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal361_tree = (object)adaptor.Create(char_literal361, retval);
						adaptor.AddChild(root_0, char_literal361_tree);
					}
					PushFollow(FOLLOW_variableModifiers_in_forstatement5611);
					variableModifiers362 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers362.Tree, variableModifiers362, retval);
					PushFollow(FOLLOW_type_in_forstatement5613);
					type363 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type363.Tree, type363, retval);
					IDENTIFIER364=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_forstatement5615); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER364_tree = (object)adaptor.Create(IDENTIFIER364, retval);
						adaptor.AddChild(root_0, IDENTIFIER364_tree);
					}
					char_literal365=(IToken)Match(input,COLON,FOLLOW_COLON_in_forstatement5617); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal365_tree = (object)adaptor.Create(char_literal365, retval);
						adaptor.AddChild(root_0, char_literal365_tree);
					}
					PushFollow(FOLLOW_expression_in_forstatement5628);
					expression366 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression366.Tree, expression366, retval);
					char_literal367=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_forstatement5630); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal367_tree = (object)adaptor.Create(char_literal367, retval);
						adaptor.AddChild(root_0, char_literal367_tree);
					}
					PushFollow(FOLLOW_statement_in_forstatement5632);
					statement368 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement368.Tree, statement368, retval);

				}
					break;
				case 2 :
					// Java.g:1068:9: 'for' '(' ( forInit )? ';' ( expression )? ';' ( expressionList )? ')' statement
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal369=(IToken)Match(input,FOR,FOLLOW_FOR_in_forstatement5664); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal369_tree = (object)adaptor.Create(string_literal369, retval);
						adaptor.AddChild(root_0, string_literal369_tree);
					}
					char_literal370=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_forstatement5666); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal370_tree = (object)adaptor.Create(char_literal370, retval);
						adaptor.AddChild(root_0, char_literal370_tree);
					}
					// Java.g:1069:17: ( forInit )?
					int alt105 = 2;
					int LA105_0 = input.LA(1);

					if ( ((LA105_0 >= IDENTIFIER && LA105_0 <= NULL) || LA105_0 == BOOLEAN || LA105_0 == BYTE || LA105_0 == CHAR || LA105_0 == DOUBLE || LA105_0 == FINAL || LA105_0 == FLOAT || LA105_0 == INT || LA105_0 == LONG || LA105_0 == NEW || LA105_0 == SHORT || LA105_0 == SUPER || LA105_0 == THIS || LA105_0 == VOID || LA105_0 == LPAREN || (LA105_0 >= BANG && LA105_0 <= TILDE) || (LA105_0 >= PLUSPLUS && LA105_0 <= SUB) || LA105_0 == MONKEYS_AT) )
					{
						alt105 = 1;
					}
					switch (alt105) 
					{
					case 1 :
						// Java.g:1069:18: forInit
					{
						PushFollow(FOLLOW_forInit_in_forstatement5686);
						forInit371 = forInit();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInit371.Tree, forInit371, retval);

					}
						break;

					}

					char_literal372=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_forstatement5707); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal372_tree = (object)adaptor.Create(char_literal372, retval);
						adaptor.AddChild(root_0, char_literal372_tree);
					}
					// Java.g:1071:17: ( expression )?
					int alt106 = 2;
					int LA106_0 = input.LA(1);

					if ( ((LA106_0 >= IDENTIFIER && LA106_0 <= NULL) || LA106_0 == BOOLEAN || LA106_0 == BYTE || LA106_0 == CHAR || LA106_0 == DOUBLE || LA106_0 == FLOAT || LA106_0 == INT || LA106_0 == LONG || LA106_0 == NEW || LA106_0 == SHORT || LA106_0 == SUPER || LA106_0 == THIS || LA106_0 == VOID || LA106_0 == LPAREN || (LA106_0 >= BANG && LA106_0 <= TILDE) || (LA106_0 >= PLUSPLUS && LA106_0 <= SUB)) )
					{
						alt106 = 1;
					}
					switch (alt106) 
					{
					case 1 :
						// Java.g:1071:18: expression
					{
						PushFollow(FOLLOW_expression_in_forstatement5727);
						expression373 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression373.Tree, expression373, retval);

					}
						break;

					}

					char_literal374=(IToken)Match(input,SEMI,FOLLOW_SEMI_in_forstatement5748); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal374_tree = (object)adaptor.Create(char_literal374, retval);
						adaptor.AddChild(root_0, char_literal374_tree);
					}
					// Java.g:1073:17: ( expressionList )?
					int alt107 = 2;
					int LA107_0 = input.LA(1);

					if ( ((LA107_0 >= IDENTIFIER && LA107_0 <= NULL) || LA107_0 == BOOLEAN || LA107_0 == BYTE || LA107_0 == CHAR || LA107_0 == DOUBLE || LA107_0 == FLOAT || LA107_0 == INT || LA107_0 == LONG || LA107_0 == NEW || LA107_0 == SHORT || LA107_0 == SUPER || LA107_0 == THIS || LA107_0 == VOID || LA107_0 == LPAREN || (LA107_0 >= BANG && LA107_0 <= TILDE) || (LA107_0 >= PLUSPLUS && LA107_0 <= SUB)) )
					{
						alt107 = 1;
					}
					switch (alt107) 
					{
					case 1 :
						// Java.g:1073:18: expressionList
					{
						PushFollow(FOLLOW_expressionList_in_forstatement5768);
						expressionList375 = expressionList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionList375.Tree, expressionList375, retval);

					}
						break;

					}

					char_literal376=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_forstatement5789); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal376_tree = (object)adaptor.Create(char_literal376, retval);
						adaptor.AddChild(root_0, char_literal376_tree);
					}
					PushFollow(FOLLOW_statement_in_forstatement5791);
					statement377 = statement();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement377.Tree, statement377, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 66, forstatement_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "forstatement"

		public class forInit_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "forInit"
		// Java.g:1077:1: forInit : ( localVariableDeclaration | expressionList );
		public JavaParser.forInit_return forInit() // throws RecognitionException [1]
		{   
			JavaParser.forInit_return retval = new JavaParser.forInit_return();
			retval.Start = input.LT(1);
			int forInit_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.localVariableDeclaration_return localVariableDeclaration378 = default(JavaParser.localVariableDeclaration_return);

			JavaParser.expressionList_return expressionList379 = default(JavaParser.expressionList_return);



			const string elementName = "forInit"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 67) ) 
				{
					return retval; 
				}
				// Java.g:1080:5: ( localVariableDeclaration | expressionList )
				int alt109 = 2;
				alt109 = dfa109.Predict(input);
				switch (alt109) 
				{
				case 1 :
					// Java.g:1080:9: localVariableDeclaration
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_localVariableDeclaration_in_forInit5820);
					localVariableDeclaration378 = localVariableDeclaration();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, localVariableDeclaration378.Tree, localVariableDeclaration378, retval);

				}
					break;
				case 2 :
					// Java.g:1081:9: expressionList
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_expressionList_in_forInit5830);
					expressionList379 = expressionList();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionList379.Tree, expressionList379, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 67, forInit_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "forInit"

		public class parExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "parExpression"
		// Java.g:1084:1: parExpression : '(' expression ')' ;
		public JavaParser.parExpression_return parExpression() // throws RecognitionException [1]
		{   
			JavaParser.parExpression_return retval = new JavaParser.parExpression_return();
			retval.Start = input.LT(1);
			int parExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal380 = null;
			IToken char_literal382 = null;
			JavaParser.expression_return expression381 = default(JavaParser.expression_return);


			object char_literal380_tree=null;
			object char_literal382_tree=null;

			const string elementName = "parExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 68) ) 
				{
					return retval; 
				}
				// Java.g:1087:5: ( '(' expression ')' )
				// Java.g:1087:9: '(' expression ')'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal380=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_parExpression5859); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal380_tree = (object)adaptor.Create(char_literal380, retval);
						adaptor.AddChild(root_0, char_literal380_tree);
					}
					PushFollow(FOLLOW_expression_in_parExpression5861);
					expression381 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression381.Tree, expression381, retval);
					char_literal382=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_parExpression5863); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal382_tree = (object)adaptor.Create(char_literal382, retval);
						adaptor.AddChild(root_0, char_literal382_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 68, parExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "parExpression"

		public class expressionList_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "expressionList"
		// Java.g:1090:1: expressionList : expression ( ',' expression )* ;
		public JavaParser.expressionList_return expressionList() // throws RecognitionException [1]
		{   
			JavaParser.expressionList_return retval = new JavaParser.expressionList_return();
			retval.Start = input.LT(1);
			int expressionList_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal384 = null;
			JavaParser.expression_return expression383 = default(JavaParser.expression_return);

			JavaParser.expression_return expression385 = default(JavaParser.expression_return);


			object char_literal384_tree=null;

			const string elementName = "expressionList"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 69) ) 
				{
					return retval; 
				}
				// Java.g:1093:5: ( expression ( ',' expression )* )
				// Java.g:1093:9: expression ( ',' expression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_expression_in_expressionList5892);
					expression383 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression383.Tree, expression383, retval);
					// Java.g:1094:9: ( ',' expression )*
					do 
					{
						int alt110 = 2;
						int LA110_0 = input.LA(1);

						if ( (LA110_0 == COMMA) )
						{
							alt110 = 1;
						}


						switch (alt110) 
						{
						case 1 :
							// Java.g:1094:10: ',' expression
						{
							char_literal384=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_expressionList5903); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal384_tree = (object)adaptor.Create(char_literal384, retval);
								adaptor.AddChild(root_0, char_literal384_tree);
							}
							PushFollow(FOLLOW_expression_in_expressionList5905);
							expression385 = expression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression385.Tree, expression385, retval);

						}
							break;

						default:
							goto loop110;
						}
					} while (true);

					loop110:
					;	// Stops C# compiler whining that label 'loop110' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 69, expressionList_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "expressionList"

		public class expression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "expression"
		// Java.g:1099:1: expression : conditionalExpression ( assignmentOperator expression )? ;
		public JavaParser.expression_return expression() // throws RecognitionException [1]
		{   
			JavaParser.expression_return retval = new JavaParser.expression_return();
			retval.Start = input.LT(1);
			int expression_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.conditionalExpression_return conditionalExpression386 = default(JavaParser.conditionalExpression_return);

			JavaParser.assignmentOperator_return assignmentOperator387 = default(JavaParser.assignmentOperator_return);

			JavaParser.expression_return expression388 = default(JavaParser.expression_return);



			const string elementName = "expression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 70) ) 
				{
					return retval; 
				}
				// Java.g:1102:5: ( conditionalExpression ( assignmentOperator expression )? )
				// Java.g:1102:9: conditionalExpression ( assignmentOperator expression )?
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_conditionalExpression_in_expression5946);
					conditionalExpression386 = conditionalExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression386.Tree, conditionalExpression386, retval);
					// Java.g:1103:9: ( assignmentOperator expression )?
					int alt111 = 2;
					int LA111_0 = input.LA(1);

					if ( (LA111_0 == EQ || (LA111_0 >= PLUSEQ && LA111_0 <= PERCENTEQ) || (LA111_0 >= GT && LA111_0 <= LT)) )
					{
						alt111 = 1;
					}
					switch (alt111) 
					{
					case 1 :
						// Java.g:1103:10: assignmentOperator expression
					{
						PushFollow(FOLLOW_assignmentOperator_in_expression5957);
						assignmentOperator387 = assignmentOperator();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator387.Tree, assignmentOperator387, retval);
						PushFollow(FOLLOW_expression_in_expression5959);
						expression388 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression388.Tree, expression388, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 70, expression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "expression"

		public class assignmentOperator_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "assignmentOperator"
		// Java.g:1108:1: assignmentOperator : ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' );
		public JavaParser.assignmentOperator_return assignmentOperator() // throws RecognitionException [1]
		{   
			JavaParser.assignmentOperator_return retval = new JavaParser.assignmentOperator_return();
			retval.Start = input.LT(1);
			int assignmentOperator_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal389 = null;
			IToken string_literal390 = null;
			IToken string_literal391 = null;
			IToken string_literal392 = null;
			IToken string_literal393 = null;
			IToken string_literal394 = null;
			IToken string_literal395 = null;
			IToken string_literal396 = null;
			IToken string_literal397 = null;
			IToken char_literal398 = null;
			IToken char_literal399 = null;
			IToken char_literal400 = null;
			IToken char_literal401 = null;
			IToken char_literal402 = null;
			IToken char_literal403 = null;
			IToken char_literal404 = null;
			IToken char_literal405 = null;
			IToken char_literal406 = null;
			IToken char_literal407 = null;

			object char_literal389_tree=null;
			object string_literal390_tree=null;
			object string_literal391_tree=null;
			object string_literal392_tree=null;
			object string_literal393_tree=null;
			object string_literal394_tree=null;
			object string_literal395_tree=null;
			object string_literal396_tree=null;
			object string_literal397_tree=null;
			object char_literal398_tree=null;
			object char_literal399_tree=null;
			object char_literal400_tree=null;
			object char_literal401_tree=null;
			object char_literal402_tree=null;
			object char_literal403_tree=null;
			object char_literal404_tree=null;
			object char_literal405_tree=null;
			object char_literal406_tree=null;
			object char_literal407_tree=null;

			const string elementName = "assignmentOperator"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 71) ) 
				{
					return retval; 
				}
				// Java.g:1111:5: ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' )
				int alt112 = 12;
				alt112 = dfa112.Predict(input);
				switch (alt112) 
				{
				case 1 :
					// Java.g:1111:9: '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal389=(IToken)Match(input,EQ,FOLLOW_EQ_in_assignmentOperator6000); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal389_tree = (object)adaptor.Create(char_literal389, retval);
						adaptor.AddChild(root_0, char_literal389_tree);
					}

				}
					break;
				case 2 :
					// Java.g:1112:9: '+='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal390=(IToken)Match(input,PLUSEQ,FOLLOW_PLUSEQ_in_assignmentOperator6010); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal390_tree = (object)adaptor.Create(string_literal390, retval);
						adaptor.AddChild(root_0, string_literal390_tree);
					}

				}
					break;
				case 3 :
					// Java.g:1113:9: '-='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal391=(IToken)Match(input,SUBEQ,FOLLOW_SUBEQ_in_assignmentOperator6020); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal391_tree = (object)adaptor.Create(string_literal391, retval);
						adaptor.AddChild(root_0, string_literal391_tree);
					}

				}
					break;
				case 4 :
					// Java.g:1114:9: '*='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal392=(IToken)Match(input,STAREQ,FOLLOW_STAREQ_in_assignmentOperator6030); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal392_tree = (object)adaptor.Create(string_literal392, retval);
						adaptor.AddChild(root_0, string_literal392_tree);
					}

				}
					break;
				case 5 :
					// Java.g:1115:9: '/='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal393=(IToken)Match(input,SLASHEQ,FOLLOW_SLASHEQ_in_assignmentOperator6040); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal393_tree = (object)adaptor.Create(string_literal393, retval);
						adaptor.AddChild(root_0, string_literal393_tree);
					}

				}
					break;
				case 6 :
					// Java.g:1116:9: '&='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal394=(IToken)Match(input,AMPEQ,FOLLOW_AMPEQ_in_assignmentOperator6050); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal394_tree = (object)adaptor.Create(string_literal394, retval);
						adaptor.AddChild(root_0, string_literal394_tree);
					}

				}
					break;
				case 7 :
					// Java.g:1117:9: '|='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal395=(IToken)Match(input,BAREQ,FOLLOW_BAREQ_in_assignmentOperator6060); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal395_tree = (object)adaptor.Create(string_literal395, retval);
						adaptor.AddChild(root_0, string_literal395_tree);
					}

				}
					break;
				case 8 :
					// Java.g:1118:9: '^='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal396=(IToken)Match(input,CARETEQ,FOLLOW_CARETEQ_in_assignmentOperator6070); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal396_tree = (object)adaptor.Create(string_literal396, retval);
						adaptor.AddChild(root_0, string_literal396_tree);
					}

				}
					break;
				case 9 :
					// Java.g:1119:9: '%='
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal397=(IToken)Match(input,PERCENTEQ,FOLLOW_PERCENTEQ_in_assignmentOperator6080); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal397_tree = (object)adaptor.Create(string_literal397, retval);
						adaptor.AddChild(root_0, string_literal397_tree);
					}

				}
					break;
				case 10 :
					// Java.g:1120:10: '<' '<' '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal398=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentOperator6091); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal398_tree = (object)adaptor.Create(char_literal398, retval);
						adaptor.AddChild(root_0, char_literal398_tree);
					}
					char_literal399=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentOperator6093); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal399_tree = (object)adaptor.Create(char_literal399, retval);
						adaptor.AddChild(root_0, char_literal399_tree);
					}
					char_literal400=(IToken)Match(input,EQ,FOLLOW_EQ_in_assignmentOperator6095); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal400_tree = (object)adaptor.Create(char_literal400, retval);
						adaptor.AddChild(root_0, char_literal400_tree);
					}

				}
					break;
				case 11 :
					// Java.g:1121:10: '>' '>' '>' '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal401=(IToken)Match(input,GT,FOLLOW_GT_in_assignmentOperator6106); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal401_tree = (object)adaptor.Create(char_literal401, retval);
						adaptor.AddChild(root_0, char_literal401_tree);
					}
					char_literal402=(IToken)Match(input,GT,FOLLOW_GT_in_assignmentOperator6108); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal402_tree = (object)adaptor.Create(char_literal402, retval);
						adaptor.AddChild(root_0, char_literal402_tree);
					}
					char_literal403=(IToken)Match(input,GT,FOLLOW_GT_in_assignmentOperator6110); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal403_tree = (object)adaptor.Create(char_literal403, retval);
						adaptor.AddChild(root_0, char_literal403_tree);
					}
					char_literal404=(IToken)Match(input,EQ,FOLLOW_EQ_in_assignmentOperator6112); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal404_tree = (object)adaptor.Create(char_literal404, retval);
						adaptor.AddChild(root_0, char_literal404_tree);
					}

				}
					break;
				case 12 :
					// Java.g:1122:10: '>' '>' '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal405=(IToken)Match(input,GT,FOLLOW_GT_in_assignmentOperator6123); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal405_tree = (object)adaptor.Create(char_literal405, retval);
						adaptor.AddChild(root_0, char_literal405_tree);
					}
					char_literal406=(IToken)Match(input,GT,FOLLOW_GT_in_assignmentOperator6125); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal406_tree = (object)adaptor.Create(char_literal406, retval);
						adaptor.AddChild(root_0, char_literal406_tree);
					}
					char_literal407=(IToken)Match(input,EQ,FOLLOW_EQ_in_assignmentOperator6127); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal407_tree = (object)adaptor.Create(char_literal407, retval);
						adaptor.AddChild(root_0, char_literal407_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 71, assignmentOperator_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "assignmentOperator"

		public class conditionalExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "conditionalExpression"
		// Java.g:1126:1: conditionalExpression : conditionalOrExpression ( '?' expression ':' conditionalExpression )? ;
		public JavaParser.conditionalExpression_return conditionalExpression() // throws RecognitionException [1]
		{   
			JavaParser.conditionalExpression_return retval = new JavaParser.conditionalExpression_return();
			retval.Start = input.LT(1);
			int conditionalExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal409 = null;
			IToken char_literal411 = null;
			JavaParser.conditionalOrExpression_return conditionalOrExpression408 = default(JavaParser.conditionalOrExpression_return);

			JavaParser.expression_return expression410 = default(JavaParser.expression_return);

			JavaParser.conditionalExpression_return conditionalExpression412 = default(JavaParser.conditionalExpression_return);


			object char_literal409_tree=null;
			object char_literal411_tree=null;

			const string elementName = "conditionalExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 72) ) 
				{
					return retval; 
				}
				// Java.g:1129:5: ( conditionalOrExpression ( '?' expression ':' conditionalExpression )? )
				// Java.g:1129:9: conditionalOrExpression ( '?' expression ':' conditionalExpression )?
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_conditionalOrExpression_in_conditionalExpression6157);
					conditionalOrExpression408 = conditionalOrExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalOrExpression408.Tree, conditionalOrExpression408, retval);
					// Java.g:1130:9: ( '?' expression ':' conditionalExpression )?
					int alt113 = 2;
					int LA113_0 = input.LA(1);

					if ( (LA113_0 == QUES) )
					{
						alt113 = 1;
					}
					switch (alt113) 
					{
					case 1 :
						// Java.g:1130:10: '?' expression ':' conditionalExpression
					{
						char_literal409=(IToken)Match(input,QUES,FOLLOW_QUES_in_conditionalExpression6168); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal409_tree = (object)adaptor.Create(char_literal409, retval);
							adaptor.AddChild(root_0, char_literal409_tree);
						}
						PushFollow(FOLLOW_expression_in_conditionalExpression6170);
						expression410 = expression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression410.Tree, expression410, retval);
						char_literal411=(IToken)Match(input,COLON,FOLLOW_COLON_in_conditionalExpression6172); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal411_tree = (object)adaptor.Create(char_literal411, retval);
							adaptor.AddChild(root_0, char_literal411_tree);
						}
						PushFollow(FOLLOW_conditionalExpression_in_conditionalExpression6174);
						conditionalExpression412 = conditionalExpression();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression412.Tree, conditionalExpression412, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 72, conditionalExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "conditionalExpression"

		public class conditionalOrExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "conditionalOrExpression"
		// Java.g:1134:1: conditionalOrExpression : conditionalAndExpression ( '||' conditionalAndExpression )* ;
		public JavaParser.conditionalOrExpression_return conditionalOrExpression() // throws RecognitionException [1]
		{   
			JavaParser.conditionalOrExpression_return retval = new JavaParser.conditionalOrExpression_return();
			retval.Start = input.LT(1);
			int conditionalOrExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal414 = null;
			JavaParser.conditionalAndExpression_return conditionalAndExpression413 = default(JavaParser.conditionalAndExpression_return);

			JavaParser.conditionalAndExpression_return conditionalAndExpression415 = default(JavaParser.conditionalAndExpression_return);


			object string_literal414_tree=null;

			const string elementName = "conditionalOrExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 73) ) 
				{
					return retval; 
				}
				// Java.g:1137:5: ( conditionalAndExpression ( '||' conditionalAndExpression )* )
				// Java.g:1137:9: conditionalAndExpression ( '||' conditionalAndExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_conditionalAndExpression_in_conditionalOrExpression6214);
					conditionalAndExpression413 = conditionalAndExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalAndExpression413.Tree, conditionalAndExpression413, retval);
					// Java.g:1138:9: ( '||' conditionalAndExpression )*
					do 
					{
						int alt114 = 2;
						int LA114_0 = input.LA(1);

						if ( (LA114_0 == BARBAR) )
						{
							alt114 = 1;
						}


						switch (alt114) 
						{
						case 1 :
							// Java.g:1138:10: '||' conditionalAndExpression
						{
							string_literal414=(IToken)Match(input,BARBAR,FOLLOW_BARBAR_in_conditionalOrExpression6225); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal414_tree = (object)adaptor.Create(string_literal414, retval);
								adaptor.AddChild(root_0, string_literal414_tree);
							}
							PushFollow(FOLLOW_conditionalAndExpression_in_conditionalOrExpression6227);
							conditionalAndExpression415 = conditionalAndExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalAndExpression415.Tree, conditionalAndExpression415, retval);

						}
							break;

						default:
							goto loop114;
						}
					} while (true);

					loop114:
					;	// Stops C# compiler whining that label 'loop114' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 73, conditionalOrExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "conditionalOrExpression"

		public class conditionalAndExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "conditionalAndExpression"
		// Java.g:1142:1: conditionalAndExpression : inclusiveOrExpression ( '&&' inclusiveOrExpression )* ;
		public JavaParser.conditionalAndExpression_return conditionalAndExpression() // throws RecognitionException [1]
		{   
			JavaParser.conditionalAndExpression_return retval = new JavaParser.conditionalAndExpression_return();
			retval.Start = input.LT(1);
			int conditionalAndExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal417 = null;
			JavaParser.inclusiveOrExpression_return inclusiveOrExpression416 = default(JavaParser.inclusiveOrExpression_return);

			JavaParser.inclusiveOrExpression_return inclusiveOrExpression418 = default(JavaParser.inclusiveOrExpression_return);


			object string_literal417_tree=null;

			const string elementName = "conditionalAndExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 74) ) 
				{
					return retval; 
				}
				// Java.g:1145:5: ( inclusiveOrExpression ( '&&' inclusiveOrExpression )* )
				// Java.g:1145:9: inclusiveOrExpression ( '&&' inclusiveOrExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_inclusiveOrExpression_in_conditionalAndExpression6267);
					inclusiveOrExpression416 = inclusiveOrExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusiveOrExpression416.Tree, inclusiveOrExpression416, retval);
					// Java.g:1146:9: ( '&&' inclusiveOrExpression )*
					do 
					{
						int alt115 = 2;
						int LA115_0 = input.LA(1);

						if ( (LA115_0 == AMPAMP) )
						{
							alt115 = 1;
						}


						switch (alt115) 
						{
						case 1 :
							// Java.g:1146:10: '&&' inclusiveOrExpression
						{
							string_literal417=(IToken)Match(input,AMPAMP,FOLLOW_AMPAMP_in_conditionalAndExpression6278); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal417_tree = (object)adaptor.Create(string_literal417, retval);
								adaptor.AddChild(root_0, string_literal417_tree);
							}
							PushFollow(FOLLOW_inclusiveOrExpression_in_conditionalAndExpression6280);
							inclusiveOrExpression418 = inclusiveOrExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusiveOrExpression418.Tree, inclusiveOrExpression418, retval);

						}
							break;

						default:
							goto loop115;
						}
					} while (true);

					loop115:
					;	// Stops C# compiler whining that label 'loop115' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 74, conditionalAndExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "conditionalAndExpression"

		public class inclusiveOrExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "inclusiveOrExpression"
		// Java.g:1150:1: inclusiveOrExpression : exclusiveOrExpression ( '|' exclusiveOrExpression )* ;
		public JavaParser.inclusiveOrExpression_return inclusiveOrExpression() // throws RecognitionException [1]
		{   
			JavaParser.inclusiveOrExpression_return retval = new JavaParser.inclusiveOrExpression_return();
			retval.Start = input.LT(1);
			int inclusiveOrExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal420 = null;
			JavaParser.exclusiveOrExpression_return exclusiveOrExpression419 = default(JavaParser.exclusiveOrExpression_return);

			JavaParser.exclusiveOrExpression_return exclusiveOrExpression421 = default(JavaParser.exclusiveOrExpression_return);


			object char_literal420_tree=null;

			const string elementName = "inclusiveOrExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 75) ) 
				{
					return retval; 
				}
				// Java.g:1153:5: ( exclusiveOrExpression ( '|' exclusiveOrExpression )* )
				// Java.g:1153:9: exclusiveOrExpression ( '|' exclusiveOrExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_exclusiveOrExpression_in_inclusiveOrExpression6320);
					exclusiveOrExpression419 = exclusiveOrExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusiveOrExpression419.Tree, exclusiveOrExpression419, retval);
					// Java.g:1154:9: ( '|' exclusiveOrExpression )*
					do 
					{
						int alt116 = 2;
						int LA116_0 = input.LA(1);

						if ( (LA116_0 == BAR) )
						{
							alt116 = 1;
						}


						switch (alt116) 
						{
						case 1 :
							// Java.g:1154:10: '|' exclusiveOrExpression
						{
							char_literal420=(IToken)Match(input,BAR,FOLLOW_BAR_in_inclusiveOrExpression6331); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal420_tree = (object)adaptor.Create(char_literal420, retval);
								adaptor.AddChild(root_0, char_literal420_tree);
							}
							PushFollow(FOLLOW_exclusiveOrExpression_in_inclusiveOrExpression6333);
							exclusiveOrExpression421 = exclusiveOrExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusiveOrExpression421.Tree, exclusiveOrExpression421, retval);

						}
							break;

						default:
							goto loop116;
						}
					} while (true);

					loop116:
					;	// Stops C# compiler whining that label 'loop116' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 75, inclusiveOrExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "inclusiveOrExpression"

		public class exclusiveOrExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "exclusiveOrExpression"
		// Java.g:1158:1: exclusiveOrExpression : andExpression ( '^' andExpression )* ;
		public JavaParser.exclusiveOrExpression_return exclusiveOrExpression() // throws RecognitionException [1]
		{   
			JavaParser.exclusiveOrExpression_return retval = new JavaParser.exclusiveOrExpression_return();
			retval.Start = input.LT(1);
			int exclusiveOrExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal423 = null;
			JavaParser.andExpression_return andExpression422 = default(JavaParser.andExpression_return);

			JavaParser.andExpression_return andExpression424 = default(JavaParser.andExpression_return);


			object char_literal423_tree=null;

			const string elementName = "exclusiveOrExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 76) ) 
				{
					return retval; 
				}
				// Java.g:1161:5: ( andExpression ( '^' andExpression )* )
				// Java.g:1161:9: andExpression ( '^' andExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_andExpression_in_exclusiveOrExpression6373);
					andExpression422 = andExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, andExpression422.Tree, andExpression422, retval);
					// Java.g:1162:9: ( '^' andExpression )*
					do 
					{
						int alt117 = 2;
						int LA117_0 = input.LA(1);

						if ( (LA117_0 == CARET) )
						{
							alt117 = 1;
						}


						switch (alt117) 
						{
						case 1 :
							// Java.g:1162:10: '^' andExpression
						{
							char_literal423=(IToken)Match(input,CARET,FOLLOW_CARET_in_exclusiveOrExpression6384); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal423_tree = (object)adaptor.Create(char_literal423, retval);
								adaptor.AddChild(root_0, char_literal423_tree);
							}
							PushFollow(FOLLOW_andExpression_in_exclusiveOrExpression6386);
							andExpression424 = andExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, andExpression424.Tree, andExpression424, retval);

						}
							break;

						default:
							goto loop117;
						}
					} while (true);

					loop117:
					;	// Stops C# compiler whining that label 'loop117' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 76, exclusiveOrExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "exclusiveOrExpression"

		public class andExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "andExpression"
		// Java.g:1166:1: andExpression : equalityExpression ( '&' equalityExpression )* ;
		public JavaParser.andExpression_return andExpression() // throws RecognitionException [1]
		{   
			JavaParser.andExpression_return retval = new JavaParser.andExpression_return();
			retval.Start = input.LT(1);
			int andExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal426 = null;
			JavaParser.equalityExpression_return equalityExpression425 = default(JavaParser.equalityExpression_return);

			JavaParser.equalityExpression_return equalityExpression427 = default(JavaParser.equalityExpression_return);


			object char_literal426_tree=null;

			const string elementName = "andExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 77) ) 
				{
					return retval; 
				}
				// Java.g:1169:5: ( equalityExpression ( '&' equalityExpression )* )
				// Java.g:1169:9: equalityExpression ( '&' equalityExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_equalityExpression_in_andExpression6426);
					equalityExpression425 = equalityExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression425.Tree, equalityExpression425, retval);
					// Java.g:1170:9: ( '&' equalityExpression )*
					do 
					{
						int alt118 = 2;
						int LA118_0 = input.LA(1);

						if ( (LA118_0 == AMP) )
						{
							alt118 = 1;
						}


						switch (alt118) 
						{
						case 1 :
							// Java.g:1170:10: '&' equalityExpression
						{
							char_literal426=(IToken)Match(input,AMP,FOLLOW_AMP_in_andExpression6437); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal426_tree = (object)adaptor.Create(char_literal426, retval);
								adaptor.AddChild(root_0, char_literal426_tree);
							}
							PushFollow(FOLLOW_equalityExpression_in_andExpression6439);
							equalityExpression427 = equalityExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression427.Tree, equalityExpression427, retval);

						}
							break;

						default:
							goto loop118;
						}
					} while (true);

					loop118:
					;	// Stops C# compiler whining that label 'loop118' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 77, andExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "andExpression"

		public class equalityExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "equalityExpression"
		// Java.g:1174:1: equalityExpression : instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )* ;
		public JavaParser.equalityExpression_return equalityExpression() // throws RecognitionException [1]
		{   
			JavaParser.equalityExpression_return retval = new JavaParser.equalityExpression_return();
			retval.Start = input.LT(1);
			int equalityExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken set429 = null;
			JavaParser.instanceOfExpression_return instanceOfExpression428 = default(JavaParser.instanceOfExpression_return);

			JavaParser.instanceOfExpression_return instanceOfExpression430 = default(JavaParser.instanceOfExpression_return);


			object set429_tree=null;

			const string elementName = "equalityExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 78) ) 
				{
					return retval; 
				}
				// Java.g:1177:5: ( instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )* )
				// Java.g:1177:9: instanceOfExpression ( ( '==' | '!=' ) instanceOfExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_instanceOfExpression_in_equalityExpression6479);
					instanceOfExpression428 = instanceOfExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, instanceOfExpression428.Tree, instanceOfExpression428, retval);
					// Java.g:1178:9: ( ( '==' | '!=' ) instanceOfExpression )*
					do 
					{
						int alt119 = 2;
						int LA119_0 = input.LA(1);

						if ( (LA119_0 == EQEQ || LA119_0 == BANGEQ) )
						{
							alt119 = 1;
						}


						switch (alt119) 
						{
						case 1 :
							// Java.g:1179:13: ( '==' | '!=' ) instanceOfExpression
						{
							set429 = (IToken)input.LT(1);
							if ( input.LA(1) == EQEQ || input.LA(1) == BANGEQ ) 
							{
								input.Consume();
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set429, retval));
								state.errorRecovery = false;state.failed = false;
							}
							else 
							{
								if ( state.backtracking > 0 ) {state.failed = true; return retval;}
								MismatchedSetException mse = new MismatchedSetException(null,input);
								throw mse;
							}

							PushFollow(FOLLOW_instanceOfExpression_in_equalityExpression6556);
							instanceOfExpression430 = instanceOfExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, instanceOfExpression430.Tree, instanceOfExpression430, retval);

						}
							break;

						default:
							goto loop119;
						}
					} while (true);

					loop119:
					;	// Stops C# compiler whining that label 'loop119' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 78, equalityExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "equalityExpression"

		public class instanceOfExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "instanceOfExpression"
		// Java.g:1186:1: instanceOfExpression : relationalExpression ( 'instanceof' type )? ;
		public JavaParser.instanceOfExpression_return instanceOfExpression() // throws RecognitionException [1]
		{   
			JavaParser.instanceOfExpression_return retval = new JavaParser.instanceOfExpression_return();
			retval.Start = input.LT(1);
			int instanceOfExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal432 = null;
			JavaParser.relationalExpression_return relationalExpression431 = default(JavaParser.relationalExpression_return);

			JavaParser.type_return type433 = default(JavaParser.type_return);


			object string_literal432_tree=null;

			const string elementName = "instanceOfExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 79) ) 
				{
					return retval; 
				}
				// Java.g:1189:5: ( relationalExpression ( 'instanceof' type )? )
				// Java.g:1189:9: relationalExpression ( 'instanceof' type )?
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_relationalExpression_in_instanceOfExpression6596);
					relationalExpression431 = relationalExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression431.Tree, relationalExpression431, retval);
					// Java.g:1190:9: ( 'instanceof' type )?
					int alt120 = 2;
					int LA120_0 = input.LA(1);

					if ( (LA120_0 == INSTANCEOF) )
					{
						alt120 = 1;
					}
					switch (alt120) 
					{
					case 1 :
						// Java.g:1190:10: 'instanceof' type
					{
						string_literal432=(IToken)Match(input,INSTANCEOF,FOLLOW_INSTANCEOF_in_instanceOfExpression6607); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal432_tree = (object)adaptor.Create(string_literal432, retval);
							adaptor.AddChild(root_0, string_literal432_tree);
						}
						PushFollow(FOLLOW_type_in_instanceOfExpression6609);
						type433 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type433.Tree, type433, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 79, instanceOfExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "instanceOfExpression"

		public class relationalExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "relationalExpression"
		// Java.g:1194:1: relationalExpression : shiftExpression ( relationalOp shiftExpression )* ;
		public JavaParser.relationalExpression_return relationalExpression() // throws RecognitionException [1]
		{   
			JavaParser.relationalExpression_return retval = new JavaParser.relationalExpression_return();
			retval.Start = input.LT(1);
			int relationalExpression_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.shiftExpression_return shiftExpression434 = default(JavaParser.shiftExpression_return);

			JavaParser.relationalOp_return relationalOp435 = default(JavaParser.relationalOp_return);

			JavaParser.shiftExpression_return shiftExpression436 = default(JavaParser.shiftExpression_return);



			const string elementName = "relationalExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 80) ) 
				{
					return retval; 
				}
				// Java.g:1197:5: ( shiftExpression ( relationalOp shiftExpression )* )
				// Java.g:1197:9: shiftExpression ( relationalOp shiftExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_shiftExpression_in_relationalExpression6649);
					shiftExpression434 = shiftExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression434.Tree, shiftExpression434, retval);
					// Java.g:1198:9: ( relationalOp shiftExpression )*
					do 
					{
						int alt121 = 2;
						int LA121_0 = input.LA(1);

						if ( (LA121_0 == LT) )
						{
							int LA121_2 = input.LA(2);

							if ( ((LA121_2 >= IDENTIFIER && LA121_2 <= NULL) || LA121_2 == BOOLEAN || LA121_2 == BYTE || LA121_2 == CHAR || LA121_2 == DOUBLE || LA121_2 == FLOAT || LA121_2 == INT || LA121_2 == LONG || LA121_2 == NEW || LA121_2 == SHORT || LA121_2 == SUPER || LA121_2 == THIS || LA121_2 == VOID || LA121_2 == LPAREN || (LA121_2 >= EQ && LA121_2 <= TILDE) || (LA121_2 >= PLUSPLUS && LA121_2 <= SUB)) )
							{
								alt121 = 1;
							}


						}
						else if ( (LA121_0 == GT) )
						{
							int LA121_3 = input.LA(2);

							if ( ((LA121_3 >= IDENTIFIER && LA121_3 <= NULL) || LA121_3 == BOOLEAN || LA121_3 == BYTE || LA121_3 == CHAR || LA121_3 == DOUBLE || LA121_3 == FLOAT || LA121_3 == INT || LA121_3 == LONG || LA121_3 == NEW || LA121_3 == SHORT || LA121_3 == SUPER || LA121_3 == THIS || LA121_3 == VOID || LA121_3 == LPAREN || (LA121_3 >= EQ && LA121_3 <= TILDE) || (LA121_3 >= PLUSPLUS && LA121_3 <= SUB)) )
							{
								alt121 = 1;
							}


						}


						switch (alt121) 
						{
						case 1 :
							// Java.g:1198:10: relationalOp shiftExpression
						{
							PushFollow(FOLLOW_relationalOp_in_relationalExpression6660);
							relationalOp435 = relationalOp();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalOp435.Tree, relationalOp435, retval);
							PushFollow(FOLLOW_shiftExpression_in_relationalExpression6662);
							shiftExpression436 = shiftExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression436.Tree, shiftExpression436, retval);

						}
							break;

						default:
							goto loop121;
						}
					} while (true);

					loop121:
					;	// Stops C# compiler whining that label 'loop121' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 80, relationalExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "relationalExpression"

		public class relationalOp_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "relationalOp"
		// Java.g:1202:1: relationalOp : ( '<' '=' | '>' '=' | '<' | '>' );
		public JavaParser.relationalOp_return relationalOp() // throws RecognitionException [1]
		{   
			JavaParser.relationalOp_return retval = new JavaParser.relationalOp_return();
			retval.Start = input.LT(1);
			int relationalOp_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal437 = null;
			IToken char_literal438 = null;
			IToken char_literal439 = null;
			IToken char_literal440 = null;
			IToken char_literal441 = null;
			IToken char_literal442 = null;

			object char_literal437_tree=null;
			object char_literal438_tree=null;
			object char_literal439_tree=null;
			object char_literal440_tree=null;
			object char_literal441_tree=null;
			object char_literal442_tree=null;

			const string elementName = "relationalOp"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 81) ) 
				{
					return retval; 
				}
				// Java.g:1205:5: ( '<' '=' | '>' '=' | '<' | '>' )
				int alt122 = 4;
				int LA122_0 = input.LA(1);

				if ( (LA122_0 == LT) )
				{
					int LA122_1 = input.LA(2);

					if ( (LA122_1 == EQ) )
					{
						alt122 = 1;
					}
					else if ( ((LA122_1 >= IDENTIFIER && LA122_1 <= NULL) || LA122_1 == BOOLEAN || LA122_1 == BYTE || LA122_1 == CHAR || LA122_1 == DOUBLE || LA122_1 == FLOAT || LA122_1 == INT || LA122_1 == LONG || LA122_1 == NEW || LA122_1 == SHORT || LA122_1 == SUPER || LA122_1 == THIS || LA122_1 == VOID || LA122_1 == LPAREN || (LA122_1 >= BANG && LA122_1 <= TILDE) || (LA122_1 >= PLUSPLUS && LA122_1 <= SUB)) )
					{
						alt122 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d122s1 =
							new NoViableAltException("", 122, 1, input);

						throw nvae_d122s1;
					}
				}
				else if ( (LA122_0 == GT) )
				{
					int LA122_2 = input.LA(2);

					if ( (LA122_2 == EQ) )
					{
						alt122 = 2;
					}
					else if ( ((LA122_2 >= IDENTIFIER && LA122_2 <= NULL) || LA122_2 == BOOLEAN || LA122_2 == BYTE || LA122_2 == CHAR || LA122_2 == DOUBLE || LA122_2 == FLOAT || LA122_2 == INT || LA122_2 == LONG || LA122_2 == NEW || LA122_2 == SHORT || LA122_2 == SUPER || LA122_2 == THIS || LA122_2 == VOID || LA122_2 == LPAREN || (LA122_2 >= BANG && LA122_2 <= TILDE) || (LA122_2 >= PLUSPLUS && LA122_2 <= SUB)) )
					{
						alt122 = 4;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d122s2 =
							new NoViableAltException("", 122, 2, input);

						throw nvae_d122s2;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d122s0 =
						new NoViableAltException("", 122, 0, input);

					throw nvae_d122s0;
				}
				switch (alt122) 
				{
				case 1 :
					// Java.g:1205:10: '<' '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal437=(IToken)Match(input,LT,FOLLOW_LT_in_relationalOp6703); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal437_tree = (object)adaptor.Create(char_literal437, retval);
						adaptor.AddChild(root_0, char_literal437_tree);
					}
					char_literal438=(IToken)Match(input,EQ,FOLLOW_EQ_in_relationalOp6705); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal438_tree = (object)adaptor.Create(char_literal438, retval);
						adaptor.AddChild(root_0, char_literal438_tree);
					}

				}
					break;
				case 2 :
					// Java.g:1206:10: '>' '='
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal439=(IToken)Match(input,GT,FOLLOW_GT_in_relationalOp6716); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal439_tree = (object)adaptor.Create(char_literal439, retval);
						adaptor.AddChild(root_0, char_literal439_tree);
					}
					char_literal440=(IToken)Match(input,EQ,FOLLOW_EQ_in_relationalOp6718); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal440_tree = (object)adaptor.Create(char_literal440, retval);
						adaptor.AddChild(root_0, char_literal440_tree);
					}

				}
					break;
				case 3 :
					// Java.g:1207:9: '<'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal441=(IToken)Match(input,LT,FOLLOW_LT_in_relationalOp6728); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal441_tree = (object)adaptor.Create(char_literal441, retval);
						adaptor.AddChild(root_0, char_literal441_tree);
					}

				}
					break;
				case 4 :
					// Java.g:1208:9: '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal442=(IToken)Match(input,GT,FOLLOW_GT_in_relationalOp6738); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal442_tree = (object)adaptor.Create(char_literal442, retval);
						adaptor.AddChild(root_0, char_literal442_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 81, relationalOp_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "relationalOp"

		public class shiftExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "shiftExpression"
		// Java.g:1211:1: shiftExpression : additiveExpression ( shiftOp additiveExpression )* ;
		public JavaParser.shiftExpression_return shiftExpression() // throws RecognitionException [1]
		{   
			JavaParser.shiftExpression_return retval = new JavaParser.shiftExpression_return();
			retval.Start = input.LT(1);
			int shiftExpression_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.additiveExpression_return additiveExpression443 = default(JavaParser.additiveExpression_return);

			JavaParser.shiftOp_return shiftOp444 = default(JavaParser.shiftOp_return);

			JavaParser.additiveExpression_return additiveExpression445 = default(JavaParser.additiveExpression_return);



			const string elementName = "shiftExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 82) ) 
				{
					return retval; 
				}
				// Java.g:1214:5: ( additiveExpression ( shiftOp additiveExpression )* )
				// Java.g:1214:9: additiveExpression ( shiftOp additiveExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_additiveExpression_in_shiftExpression6767);
					additiveExpression443 = additiveExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression443.Tree, additiveExpression443, retval);
					// Java.g:1215:9: ( shiftOp additiveExpression )*
					do 
					{
						int alt123 = 2;
						int LA123_0 = input.LA(1);

						if ( (LA123_0 == LT) )
						{
							int LA123_1 = input.LA(2);

							if ( (LA123_1 == LT) )
							{
								int LA123_4 = input.LA(3);

								if ( ((LA123_4 >= IDENTIFIER && LA123_4 <= NULL) || LA123_4 == BOOLEAN || LA123_4 == BYTE || LA123_4 == CHAR || LA123_4 == DOUBLE || LA123_4 == FLOAT || LA123_4 == INT || LA123_4 == LONG || LA123_4 == NEW || LA123_4 == SHORT || LA123_4 == SUPER || LA123_4 == THIS || LA123_4 == VOID || LA123_4 == LPAREN || (LA123_4 >= BANG && LA123_4 <= TILDE) || (LA123_4 >= PLUSPLUS && LA123_4 <= SUB)) )
								{
									alt123 = 1;
								}


							}


						}
						else if ( (LA123_0 == GT) )
						{
							int LA123_2 = input.LA(2);

							if ( (LA123_2 == GT) )
							{
								int LA123_5 = input.LA(3);

								if ( (LA123_5 == GT) )
								{
									int LA123_7 = input.LA(4);

									if ( ((LA123_7 >= IDENTIFIER && LA123_7 <= NULL) || LA123_7 == BOOLEAN || LA123_7 == BYTE || LA123_7 == CHAR || LA123_7 == DOUBLE || LA123_7 == FLOAT || LA123_7 == INT || LA123_7 == LONG || LA123_7 == NEW || LA123_7 == SHORT || LA123_7 == SUPER || LA123_7 == THIS || LA123_7 == VOID || LA123_7 == LPAREN || (LA123_7 >= BANG && LA123_7 <= TILDE) || (LA123_7 >= PLUSPLUS && LA123_7 <= SUB)) )
									{
										alt123 = 1;
									}


								}
								else if ( ((LA123_5 >= IDENTIFIER && LA123_5 <= NULL) || LA123_5 == BOOLEAN || LA123_5 == BYTE || LA123_5 == CHAR || LA123_5 == DOUBLE || LA123_5 == FLOAT || LA123_5 == INT || LA123_5 == LONG || LA123_5 == NEW || LA123_5 == SHORT || LA123_5 == SUPER || LA123_5 == THIS || LA123_5 == VOID || LA123_5 == LPAREN || (LA123_5 >= BANG && LA123_5 <= TILDE) || (LA123_5 >= PLUSPLUS && LA123_5 <= SUB)) )
								{
									alt123 = 1;
								}


							}


						}


						switch (alt123) 
						{
						case 1 :
							// Java.g:1215:10: shiftOp additiveExpression
						{
							PushFollow(FOLLOW_shiftOp_in_shiftExpression6778);
							shiftOp444 = shiftOp();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftOp444.Tree, shiftOp444, retval);
							PushFollow(FOLLOW_additiveExpression_in_shiftExpression6780);
							additiveExpression445 = additiveExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression445.Tree, additiveExpression445, retval);

						}
							break;

						default:
							goto loop123;
						}
					} while (true);

					loop123:
					;	// Stops C# compiler whining that label 'loop123' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 82, shiftExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "shiftExpression"

		public class shiftOp_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "shiftOp"
		// Java.g:1220:1: shiftOp : ( '<' '<' | '>' '>' '>' | '>' '>' );
		public JavaParser.shiftOp_return shiftOp() // throws RecognitionException [1]
		{   
			JavaParser.shiftOp_return retval = new JavaParser.shiftOp_return();
			retval.Start = input.LT(1);
			int shiftOp_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal446 = null;
			IToken char_literal447 = null;
			IToken char_literal448 = null;
			IToken char_literal449 = null;
			IToken char_literal450 = null;
			IToken char_literal451 = null;
			IToken char_literal452 = null;

			object char_literal446_tree=null;
			object char_literal447_tree=null;
			object char_literal448_tree=null;
			object char_literal449_tree=null;
			object char_literal450_tree=null;
			object char_literal451_tree=null;
			object char_literal452_tree=null;

			const string elementName = "shiftOp"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 83) ) 
				{
					return retval; 
				}
				// Java.g:1223:5: ( '<' '<' | '>' '>' '>' | '>' '>' )
				int alt124 = 3;
				int LA124_0 = input.LA(1);

				if ( (LA124_0 == LT) )
				{
					alt124 = 1;
				}
				else if ( (LA124_0 == GT) )
				{
					int LA124_2 = input.LA(2);

					if ( (LA124_2 == GT) )
					{
						int LA124_3 = input.LA(3);

						if ( (LA124_3 == GT) )
						{
							alt124 = 2;
						}
						else if ( ((LA124_3 >= IDENTIFIER && LA124_3 <= NULL) || LA124_3 == BOOLEAN || LA124_3 == BYTE || LA124_3 == CHAR || LA124_3 == DOUBLE || LA124_3 == FLOAT || LA124_3 == INT || LA124_3 == LONG || LA124_3 == NEW || LA124_3 == SHORT || LA124_3 == SUPER || LA124_3 == THIS || LA124_3 == VOID || LA124_3 == LPAREN || (LA124_3 >= BANG && LA124_3 <= TILDE) || (LA124_3 >= PLUSPLUS && LA124_3 <= SUB)) )
						{
							alt124 = 3;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d124s3 =
								new NoViableAltException("", 124, 3, input);

							throw nvae_d124s3;
						}
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d124s2 =
							new NoViableAltException("", 124, 2, input);

						throw nvae_d124s2;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d124s0 =
						new NoViableAltException("", 124, 0, input);

					throw nvae_d124s0;
				}
				switch (alt124) 
				{
				case 1 :
					// Java.g:1223:10: '<' '<'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal446=(IToken)Match(input,LT,FOLLOW_LT_in_shiftOp6822); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal446_tree = (object)adaptor.Create(char_literal446, retval);
						adaptor.AddChild(root_0, char_literal446_tree);
					}
					char_literal447=(IToken)Match(input,LT,FOLLOW_LT_in_shiftOp6824); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal447_tree = (object)adaptor.Create(char_literal447, retval);
						adaptor.AddChild(root_0, char_literal447_tree);
					}

				}
					break;
				case 2 :
					// Java.g:1224:10: '>' '>' '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal448=(IToken)Match(input,GT,FOLLOW_GT_in_shiftOp6835); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal448_tree = (object)adaptor.Create(char_literal448, retval);
						adaptor.AddChild(root_0, char_literal448_tree);
					}
					char_literal449=(IToken)Match(input,GT,FOLLOW_GT_in_shiftOp6837); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal449_tree = (object)adaptor.Create(char_literal449, retval);
						adaptor.AddChild(root_0, char_literal449_tree);
					}
					char_literal450=(IToken)Match(input,GT,FOLLOW_GT_in_shiftOp6839); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal450_tree = (object)adaptor.Create(char_literal450, retval);
						adaptor.AddChild(root_0, char_literal450_tree);
					}

				}
					break;
				case 3 :
					// Java.g:1225:10: '>' '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal451=(IToken)Match(input,GT,FOLLOW_GT_in_shiftOp6850); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal451_tree = (object)adaptor.Create(char_literal451, retval);
						adaptor.AddChild(root_0, char_literal451_tree);
					}
					char_literal452=(IToken)Match(input,GT,FOLLOW_GT_in_shiftOp6852); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal452_tree = (object)adaptor.Create(char_literal452, retval);
						adaptor.AddChild(root_0, char_literal452_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 83, shiftOp_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "shiftOp"

		public class additiveExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "additiveExpression"
		// Java.g:1229:1: additiveExpression : multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* ;
		public JavaParser.additiveExpression_return additiveExpression() // throws RecognitionException [1]
		{   
			JavaParser.additiveExpression_return retval = new JavaParser.additiveExpression_return();
			retval.Start = input.LT(1);
			int additiveExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken set454 = null;
			JavaParser.multiplicativeExpression_return multiplicativeExpression453 = default(JavaParser.multiplicativeExpression_return);

			JavaParser.multiplicativeExpression_return multiplicativeExpression455 = default(JavaParser.multiplicativeExpression_return);


			object set454_tree=null;

			const string elementName = "additiveExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 84) ) 
				{
					return retval; 
				}
				// Java.g:1232:5: ( multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )* )
				// Java.g:1232:9: multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression6882);
					multiplicativeExpression453 = multiplicativeExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression453.Tree, multiplicativeExpression453, retval);
					// Java.g:1233:9: ( ( '+' | '-' ) multiplicativeExpression )*
					do 
					{
						int alt125 = 2;
						int LA125_0 = input.LA(1);

						if ( ((LA125_0 >= PLUS && LA125_0 <= SUB)) )
						{
							alt125 = 1;
						}


						switch (alt125) 
						{
						case 1 :
							// Java.g:1234:13: ( '+' | '-' ) multiplicativeExpression
						{
							set454 = (IToken)input.LT(1);
							if ( (input.LA(1) >= PLUS && input.LA(1) <= SUB) ) 
							{
								input.Consume();
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set454, retval));
								state.errorRecovery = false;state.failed = false;
							}
							else 
							{
								if ( state.backtracking > 0 ) {state.failed = true; return retval;}
								MismatchedSetException mse = new MismatchedSetException(null,input);
								throw mse;
							}

							PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression6959);
							multiplicativeExpression455 = multiplicativeExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression455.Tree, multiplicativeExpression455, retval);

						}
							break;

						default:
							goto loop125;
						}
					} while (true);

					loop125:
					;	// Stops C# compiler whining that label 'loop125' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 84, additiveExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "additiveExpression"

		public class multiplicativeExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "multiplicativeExpression"
		// Java.g:1241:1: multiplicativeExpression : unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )* ;
		public JavaParser.multiplicativeExpression_return multiplicativeExpression() // throws RecognitionException [1]
		{   
			JavaParser.multiplicativeExpression_return retval = new JavaParser.multiplicativeExpression_return();
			retval.Start = input.LT(1);
			int multiplicativeExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken set457 = null;
			JavaParser.unaryExpression_return unaryExpression456 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpression_return unaryExpression458 = default(JavaParser.unaryExpression_return);


			object set457_tree=null;

			const string elementName = "multiplicativeExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 85) ) 
				{
					return retval; 
				}
				// Java.g:1244:5: ( unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )* )
				// Java.g:1245:9: unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )*
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression7006);
					unaryExpression456 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression456.Tree, unaryExpression456, retval);
					// Java.g:1246:9: ( ( '*' | '/' | '%' ) unaryExpression )*
					do 
					{
						int alt126 = 2;
						int LA126_0 = input.LA(1);

						if ( ((LA126_0 >= STAR && LA126_0 <= SLASH) || LA126_0 == PERCENT) )
						{
							alt126 = 1;
						}


						switch (alt126) 
						{
						case 1 :
							// Java.g:1247:13: ( '*' | '/' | '%' ) unaryExpression
						{
							set457 = (IToken)input.LT(1);
							if ( (input.LA(1) >= STAR && input.LA(1) <= SLASH) || input.LA(1) == PERCENT ) 
							{
								input.Consume();
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set457, retval));
								state.errorRecovery = false;state.failed = false;
							}
							else 
							{
								if ( state.backtracking > 0 ) {state.failed = true; return retval;}
								MismatchedSetException mse = new MismatchedSetException(null,input);
								throw mse;
							}

							PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression7101);
							unaryExpression458 = unaryExpression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression458.Tree, unaryExpression458, retval);

						}
							break;

						default:
							goto loop126;
						}
					} while (true);

					loop126:
					;	// Stops C# compiler whining that label 'loop126' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 85, multiplicativeExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "multiplicativeExpression"

		public class unaryExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "unaryExpression"
		// Java.g:1255:1: unaryExpression : ( '+' unaryExpression | '-' unaryExpression | '++' unaryExpression | '--' unaryExpression | unaryExpressionNotPlusMinus );
		public JavaParser.unaryExpression_return unaryExpression() // throws RecognitionException [1]
		{   
			JavaParser.unaryExpression_return retval = new JavaParser.unaryExpression_return();
			retval.Start = input.LT(1);
			int unaryExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal459 = null;
			IToken char_literal461 = null;
			IToken string_literal463 = null;
			IToken string_literal465 = null;
			JavaParser.unaryExpression_return unaryExpression460 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpression_return unaryExpression462 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpression_return unaryExpression464 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpression_return unaryExpression466 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus467 = default(JavaParser.unaryExpressionNotPlusMinus_return);


			object char_literal459_tree=null;
			object char_literal461_tree=null;
			object string_literal463_tree=null;
			object string_literal465_tree=null;

			const string elementName = "unaryExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 86) ) 
				{
					return retval; 
				}
				// Java.g:1262:5: ( '+' unaryExpression | '-' unaryExpression | '++' unaryExpression | '--' unaryExpression | unaryExpressionNotPlusMinus )
				int alt127 = 5;
				switch ( input.LA(1) ) 
				{
				case PLUS:
				{
					alt127 = 1;
				}
					break;
				case SUB:
				{
					alt127 = 2;
				}
					break;
				case PLUSPLUS:
				{
					alt127 = 3;
				}
					break;
				case SUBSUB:
				{
					alt127 = 4;
				}
					break;
				case IDENTIFIER:
				case INTLITERAL:
				case LONGLITERAL:
				case FLOATLITERAL:
				case DOUBLELITERAL:
				case CHARLITERAL:
				case STRINGLITERAL:
				case TRUE:
				case FALSE:
				case NULL:
				case BOOLEAN:
				case BYTE:
				case CHAR:
				case DOUBLE:
				case FLOAT:
				case INT:
				case LONG:
				case NEW:
				case SHORT:
				case SUPER:
				case THIS:
				case VOID:
				case LPAREN:
				case BANG:
				case TILDE:
				{
					alt127 = 5;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d127s0 =
						new NoViableAltException("", 127, 0, input);

					throw nvae_d127s0;
				}

				switch (alt127) 
				{
				case 1 :
					// Java.g:1262:9: '+' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal459=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_unaryExpression7143); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal459_tree = (object)adaptor.Create(char_literal459, retval);
						adaptor.AddChild(root_0, char_literal459_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpression7146);
					unaryExpression460 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression460.Tree, unaryExpression460, retval);

				}
					break;
				case 2 :
					// Java.g:1263:9: '-' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal461=(IToken)Match(input,SUB,FOLLOW_SUB_in_unaryExpression7156); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal461_tree = (object)adaptor.Create(char_literal461, retval);
						adaptor.AddChild(root_0, char_literal461_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpression7158);
					unaryExpression462 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression462.Tree, unaryExpression462, retval);

				}
					break;
				case 3 :
					// Java.g:1264:9: '++' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal463=(IToken)Match(input,PLUSPLUS,FOLLOW_PLUSPLUS_in_unaryExpression7168); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal463_tree = (object)adaptor.Create(string_literal463, retval);
						adaptor.AddChild(root_0, string_literal463_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpression7170);
					unaryExpression464 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression464.Tree, unaryExpression464, retval);

				}
					break;
				case 4 :
					// Java.g:1265:9: '--' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal465=(IToken)Match(input,SUBSUB,FOLLOW_SUBSUB_in_unaryExpression7180); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal465_tree = (object)adaptor.Create(string_literal465, retval);
						adaptor.AddChild(root_0, string_literal465_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpression7182);
					unaryExpression466 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression466.Tree, unaryExpression466, retval);

				}
					break;
				case 5 :
					// Java.g:1266:9: unaryExpressionNotPlusMinus
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_unaryExpressionNotPlusMinus_in_unaryExpression7192);
					unaryExpressionNotPlusMinus467 = unaryExpressionNotPlusMinus();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpressionNotPlusMinus467.Tree, unaryExpressionNotPlusMinus467, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 86, unaryExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "unaryExpression"

		public class unaryExpressionNotPlusMinus_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "unaryExpressionNotPlusMinus"
		// Java.g:1269:1: unaryExpressionNotPlusMinus : ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? );
		public JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus() // throws RecognitionException [1]
		{   
			JavaParser.unaryExpressionNotPlusMinus_return retval = new JavaParser.unaryExpressionNotPlusMinus_return();
			retval.Start = input.LT(1);
			int unaryExpressionNotPlusMinus_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal468 = null;
			IToken char_literal470 = null;
			IToken set475 = null;
			JavaParser.unaryExpression_return unaryExpression469 = default(JavaParser.unaryExpression_return);

			JavaParser.unaryExpression_return unaryExpression471 = default(JavaParser.unaryExpression_return);

			JavaParser.castExpression_return castExpression472 = default(JavaParser.castExpression_return);

			JavaParser.primary_return primary473 = default(JavaParser.primary_return);

			JavaParser.selector_return selector474 = default(JavaParser.selector_return);


			object char_literal468_tree=null;
			object char_literal470_tree=null;
			object set475_tree=null;

			const string elementName = "unaryExpressionNotPlusMinus"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 87) ) 
				{
					return retval; 
				}
				// Java.g:1272:5: ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? )
				int alt130 = 4;
				alt130 = dfa130.Predict(input);
				switch (alt130) 
				{
				case 1 :
					// Java.g:1272:9: '~' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal468=(IToken)Match(input,TILDE,FOLLOW_TILDE_in_unaryExpressionNotPlusMinus7221); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal468_tree = (object)adaptor.Create(char_literal468, retval);
						adaptor.AddChild(root_0, char_literal468_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpressionNotPlusMinus7223);
					unaryExpression469 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression469.Tree, unaryExpression469, retval);

				}
					break;
				case 2 :
					// Java.g:1273:9: '!' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal470=(IToken)Match(input,BANG,FOLLOW_BANG_in_unaryExpressionNotPlusMinus7233); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal470_tree = (object)adaptor.Create(char_literal470, retval);
						adaptor.AddChild(root_0, char_literal470_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_unaryExpressionNotPlusMinus7235);
					unaryExpression471 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression471.Tree, unaryExpression471, retval);

				}
					break;
				case 3 :
					// Java.g:1274:9: castExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_castExpression_in_unaryExpressionNotPlusMinus7245);
					castExpression472 = castExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, castExpression472.Tree, castExpression472, retval);

				}
					break;
				case 4 :
					// Java.g:1275:9: primary ( selector )* ( '++' | '--' )?
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_primary_in_unaryExpressionNotPlusMinus7255);
					primary473 = primary();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primary473.Tree, primary473, retval);
					// Java.g:1276:9: ( selector )*
					do 
					{
						int alt128 = 2;
						int LA128_0 = input.LA(1);

						if ( (LA128_0 == LBRACKET || LA128_0 == DOT) )
						{
							alt128 = 1;
						}


						switch (alt128) 
						{
						case 1 :
							// Java.g:1276:10: selector
						{
							PushFollow(FOLLOW_selector_in_unaryExpressionNotPlusMinus7266);
							selector474 = selector();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, selector474.Tree, selector474, retval);

						}
							break;

						default:
							goto loop128;
						}
					} while (true);

					loop128:
					;	// Stops C# compiler whining that label 'loop128' has no statements

					// Java.g:1278:9: ( '++' | '--' )?
					int alt129 = 2;
					int LA129_0 = input.LA(1);

					if ( ((LA129_0 >= PLUSPLUS && LA129_0 <= SUBSUB)) )
					{
						alt129 = 1;
					}
					switch (alt129) 
					{
					case 1 :
						// Java.g:
					{
						set475 = (IToken)input.LT(1);
						if ( (input.LA(1) >= PLUSPLUS && input.LA(1) <= SUBSUB) ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set475, retval));
							state.errorRecovery = false;state.failed = false;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							MismatchedSetException mse = new MismatchedSetException(null,input);
							throw mse;
						}


					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 87, unaryExpressionNotPlusMinus_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "unaryExpressionNotPlusMinus"

		public class castExpression_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "castExpression"
		// Java.g:1283:1: castExpression : ( '(' primitiveType ')' unaryExpression | '(' type ')' unaryExpressionNotPlusMinus );
		public JavaParser.castExpression_return castExpression() // throws RecognitionException [1]
		{   
			JavaParser.castExpression_return retval = new JavaParser.castExpression_return();
			retval.Start = input.LT(1);
			int castExpression_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal476 = null;
			IToken char_literal478 = null;
			IToken char_literal480 = null;
			IToken char_literal482 = null;
			JavaParser.primitiveType_return primitiveType477 = default(JavaParser.primitiveType_return);

			JavaParser.unaryExpression_return unaryExpression479 = default(JavaParser.unaryExpression_return);

			JavaParser.type_return type481 = default(JavaParser.type_return);

			JavaParser.unaryExpressionNotPlusMinus_return unaryExpressionNotPlusMinus483 = default(JavaParser.unaryExpressionNotPlusMinus_return);


			object char_literal476_tree=null;
			object char_literal478_tree=null;
			object char_literal480_tree=null;
			object char_literal482_tree=null;

			const string elementName = "castExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 88) ) 
				{
					return retval; 
				}
				// Java.g:1286:5: ( '(' primitiveType ')' unaryExpression | '(' type ')' unaryExpressionNotPlusMinus )
				int alt131 = 2;
				int LA131_0 = input.LA(1);

				if ( (LA131_0 == LPAREN) )
				{
					int LA131_1 = input.LA(2);

					if ( (synpred206_Java()) )
					{
						alt131 = 1;
					}
					else if ( (true) )
					{
						alt131 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d131s1 =
							new NoViableAltException("", 131, 1, input);

						throw nvae_d131s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d131s0 =
						new NoViableAltException("", 131, 0, input);

					throw nvae_d131s0;
				}
				switch (alt131) 
				{
				case 1 :
					// Java.g:1286:9: '(' primitiveType ')' unaryExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal476=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_castExpression7345); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal476_tree = (object)adaptor.Create(char_literal476, retval);
						adaptor.AddChild(root_0, char_literal476_tree);
					}
					PushFollow(FOLLOW_primitiveType_in_castExpression7347);
					primitiveType477 = primitiveType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primitiveType477.Tree, primitiveType477, retval);
					char_literal478=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_castExpression7349); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal478_tree = (object)adaptor.Create(char_literal478, retval);
						adaptor.AddChild(root_0, char_literal478_tree);
					}
					PushFollow(FOLLOW_unaryExpression_in_castExpression7351);
					unaryExpression479 = unaryExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression479.Tree, unaryExpression479, retval);

				}
					break;
				case 2 :
					// Java.g:1287:9: '(' type ')' unaryExpressionNotPlusMinus
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal480=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_castExpression7361); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal480_tree = (object)adaptor.Create(char_literal480, retval);
						adaptor.AddChild(root_0, char_literal480_tree);
					}
					PushFollow(FOLLOW_type_in_castExpression7363);
					type481 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type481.Tree, type481, retval);
					char_literal482=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_castExpression7365); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal482_tree = (object)adaptor.Create(char_literal482, retval);
						adaptor.AddChild(root_0, char_literal482_tree);
					}
					PushFollow(FOLLOW_unaryExpressionNotPlusMinus_in_castExpression7367);
					unaryExpressionNotPlusMinus483 = unaryExpressionNotPlusMinus();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpressionNotPlusMinus483.Tree, unaryExpressionNotPlusMinus483, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 88, castExpression_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "castExpression"

		public class primary_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "primary"
		// Java.g:1290:1: primary : ( parExpression | 'this' ( '.' IDENTIFIER )* ( identifierSuffix )? | IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )? | 'super' superSuffix | literal | creator | primitiveType ( '[' ']' )* '.' 'class' | 'void' '.' 'class' );
		public JavaParser.primary_return primary() // throws RecognitionException [1]
		{   
			JavaParser.primary_return retval = new JavaParser.primary_return();
			retval.Start = input.LT(1);
			int primary_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal485 = null;
			IToken char_literal486 = null;
			IToken IDENTIFIER487 = null;
			IToken IDENTIFIER489 = null;
			IToken char_literal490 = null;
			IToken IDENTIFIER491 = null;
			IToken string_literal493 = null;
			IToken char_literal498 = null;
			IToken char_literal499 = null;
			IToken char_literal500 = null;
			IToken string_literal501 = null;
			IToken string_literal502 = null;
			IToken char_literal503 = null;
			IToken string_literal504 = null;
			JavaParser.parExpression_return parExpression484 = default(JavaParser.parExpression_return);

			JavaParser.identifierSuffix_return identifierSuffix488 = default(JavaParser.identifierSuffix_return);

			JavaParser.identifierSuffix_return identifierSuffix492 = default(JavaParser.identifierSuffix_return);

			JavaParser.superSuffix_return superSuffix494 = default(JavaParser.superSuffix_return);

			JavaParser.literal_return literal495 = default(JavaParser.literal_return);

			JavaParser.creator_return creator496 = default(JavaParser.creator_return);

			JavaParser.primitiveType_return primitiveType497 = default(JavaParser.primitiveType_return);


			object string_literal485_tree=null;
			object char_literal486_tree=null;
			object IDENTIFIER487_tree=null;
			object IDENTIFIER489_tree=null;
			object char_literal490_tree=null;
			object IDENTIFIER491_tree=null;
			object string_literal493_tree=null;
			object char_literal498_tree=null;
			object char_literal499_tree=null;
			object char_literal500_tree=null;
			object string_literal501_tree=null;
			object string_literal502_tree=null;
			object char_literal503_tree=null;
			object string_literal504_tree=null;

			const string elementName = "primary"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 89) ) 
				{
					return retval; 
				}
				// Java.g:1296:5: ( parExpression | 'this' ( '.' IDENTIFIER )* ( identifierSuffix )? | IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )? | 'super' superSuffix | literal | creator | primitiveType ( '[' ']' )* '.' 'class' | 'void' '.' 'class' )
				int alt137 = 8;
				switch ( input.LA(1) ) 
				{
				case LPAREN:
				{
					alt137 = 1;
				}
					break;
				case THIS:
				{
					alt137 = 2;
				}
					break;
				case IDENTIFIER:
				{
					alt137 = 3;
				}
					break;
				case SUPER:
				{
					alt137 = 4;
				}
					break;
				case INTLITERAL:
				case LONGLITERAL:
				case FLOATLITERAL:
				case DOUBLELITERAL:
				case CHARLITERAL:
				case STRINGLITERAL:
				case TRUE:
				case FALSE:
				case NULL:
				{
					alt137 = 5;
				}
					break;
				case NEW:
				{
					alt137 = 6;
				}
					break;
				case BOOLEAN:
				case BYTE:
				case CHAR:
				case DOUBLE:
				case FLOAT:
				case INT:
				case LONG:
				case SHORT:
				{
					alt137 = 7;
				}
					break;
				case VOID:
				{
					alt137 = 8;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d137s0 =
						new NoViableAltException("", 137, 0, input);

					throw nvae_d137s0;
				}

				switch (alt137) 
				{
				case 1 :
					// Java.g:1296:9: parExpression
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_parExpression_in_primary7398);
					parExpression484 = parExpression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parExpression484.Tree, parExpression484, retval);

				}
					break;
				case 2 :
					// Java.g:1297:9: 'this' ( '.' IDENTIFIER )* ( identifierSuffix )?
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal485=(IToken)Match(input,THIS,FOLLOW_THIS_in_primary7420); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal485_tree = (object)adaptor.Create(string_literal485, retval);
						adaptor.AddChild(root_0, string_literal485_tree);
					}
					// Java.g:1298:9: ( '.' IDENTIFIER )*
					do 
					{
						int alt132 = 2;
						int LA132_0 = input.LA(1);

						if ( (LA132_0 == DOT) )
						{
							int LA132_2 = input.LA(2);

							if ( (LA132_2 == IDENTIFIER) )
							{
								int LA132_3 = input.LA(3);

								if ( (synpred208_Java()) )
								{
									alt132 = 1;
								}


							}


						}


						switch (alt132) 
						{
						case 1 :
							// Java.g:1298:10: '.' IDENTIFIER
						{
							char_literal486=(IToken)Match(input,DOT,FOLLOW_DOT_in_primary7431); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal486_tree = (object)adaptor.Create(char_literal486, retval);
								adaptor.AddChild(root_0, char_literal486_tree);
							}
							IDENTIFIER487=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_primary7433); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER487_tree = (object)adaptor.Create(IDENTIFIER487, retval);
								adaptor.AddChild(root_0, IDENTIFIER487_tree);
							}

						}
							break;

						default:
							goto loop132;
						}
					} while (true);

					loop132:
					;	// Stops C# compiler whining that label 'loop132' has no statements

					// Java.g:1300:9: ( identifierSuffix )?
					int alt133 = 2;
					alt133 = dfa133.Predict(input);
					switch (alt133) 
					{
					case 1 :
						// Java.g:1300:10: identifierSuffix
					{
						PushFollow(FOLLOW_identifierSuffix_in_primary7455);
						identifierSuffix488 = identifierSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, identifierSuffix488.Tree, identifierSuffix488, retval);

					}
						break;

					}


				}
					break;
				case 3 :
					// Java.g:1302:9: IDENTIFIER ( '.' IDENTIFIER )* ( identifierSuffix )?
				{
					root_0 = (object)adaptor.GetNilNode();

					IDENTIFIER489=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_primary7476); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER489_tree = (object)adaptor.Create(IDENTIFIER489, retval);
						adaptor.AddChild(root_0, IDENTIFIER489_tree);
					}
					// Java.g:1303:9: ( '.' IDENTIFIER )*
					do 
					{
						int alt134 = 2;
						int LA134_0 = input.LA(1);

						if ( (LA134_0 == DOT) )
						{
							int LA134_2 = input.LA(2);

							if ( (LA134_2 == IDENTIFIER) )
							{
								int LA134_3 = input.LA(3);

								if ( (synpred211_Java()) )
								{
									alt134 = 1;
								}


							}


						}


						switch (alt134) 
						{
						case 1 :
							// Java.g:1303:10: '.' IDENTIFIER
						{
							char_literal490=(IToken)Match(input,DOT,FOLLOW_DOT_in_primary7487); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal490_tree = (object)adaptor.Create(char_literal490, retval);
								adaptor.AddChild(root_0, char_literal490_tree);
							}
							IDENTIFIER491=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_primary7489); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{IDENTIFIER491_tree = (object)adaptor.Create(IDENTIFIER491, retval);
								adaptor.AddChild(root_0, IDENTIFIER491_tree);
							}

						}
							break;

						default:
							goto loop134;
						}
					} while (true);

					loop134:
					;	// Stops C# compiler whining that label 'loop134' has no statements

					// Java.g:1305:9: ( identifierSuffix )?
					int alt135 = 2;
					alt135 = dfa135.Predict(input);
					switch (alt135) 
					{
					case 1 :
						// Java.g:1305:10: identifierSuffix
					{
						PushFollow(FOLLOW_identifierSuffix_in_primary7511);
						identifierSuffix492 = identifierSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, identifierSuffix492.Tree, identifierSuffix492, retval);

					}
						break;

					}


				}
					break;
				case 4 :
					// Java.g:1307:9: 'super' superSuffix
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal493=(IToken)Match(input,SUPER,FOLLOW_SUPER_in_primary7532); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal493_tree = (object)adaptor.Create(string_literal493, retval);
						adaptor.AddChild(root_0, string_literal493_tree);
					}
					PushFollow(FOLLOW_superSuffix_in_primary7542);
					superSuffix494 = superSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, superSuffix494.Tree, superSuffix494, retval);

				}
					break;
				case 5 :
					// Java.g:1309:9: literal
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_literal_in_primary7552);
					literal495 = literal();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, literal495.Tree, literal495, retval);

				}
					break;
				case 6 :
					// Java.g:1310:9: creator
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_creator_in_primary7562);
					creator496 = creator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, creator496.Tree, creator496, retval);

				}
					break;
				case 7 :
					// Java.g:1311:9: primitiveType ( '[' ']' )* '.' 'class'
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_primitiveType_in_primary7572);
					primitiveType497 = primitiveType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primitiveType497.Tree, primitiveType497, retval);
					// Java.g:1312:9: ( '[' ']' )*
					do 
					{
						int alt136 = 2;
						int LA136_0 = input.LA(1);

						if ( (LA136_0 == LBRACKET) )
						{
							alt136 = 1;
						}


						switch (alt136) 
						{
						case 1 :
							// Java.g:1312:10: '[' ']'
						{
							char_literal498=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_primary7583); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal498_tree = (object)adaptor.Create(char_literal498, retval);
								adaptor.AddChild(root_0, char_literal498_tree);
							}
							char_literal499=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_primary7585); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal499_tree = (object)adaptor.Create(char_literal499, retval);
								adaptor.AddChild(root_0, char_literal499_tree);
							}

						}
							break;

						default:
							goto loop136;
						}
					} while (true);

					loop136:
					;	// Stops C# compiler whining that label 'loop136' has no statements

					char_literal500=(IToken)Match(input,DOT,FOLLOW_DOT_in_primary7606); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal500_tree = (object)adaptor.Create(char_literal500, retval);
						adaptor.AddChild(root_0, char_literal500_tree);
					}
					string_literal501=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_primary7608); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal501_tree = (object)adaptor.Create(string_literal501, retval);
						adaptor.AddChild(root_0, string_literal501_tree);
					}

				}
					break;
				case 8 :
					// Java.g:1315:9: 'void' '.' 'class'
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal502=(IToken)Match(input,VOID,FOLLOW_VOID_in_primary7618); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal502_tree = (object)adaptor.Create(string_literal502, retval);
						adaptor.AddChild(root_0, string_literal502_tree);
					}
					char_literal503=(IToken)Match(input,DOT,FOLLOW_DOT_in_primary7620); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal503_tree = (object)adaptor.Create(char_literal503, retval);
						adaptor.AddChild(root_0, char_literal503_tree);
					}
					string_literal504=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_primary7622); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal504_tree = (object)adaptor.Create(string_literal504, retval);
						adaptor.AddChild(root_0, string_literal504_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 89, primary_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "primary"

		public class superSuffix_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "superSuffix"
		// Java.g:1319:1: superSuffix : ( arguments | '.' ( typeArguments )? IDENTIFIER ( arguments )? );
		public JavaParser.superSuffix_return superSuffix() // throws RecognitionException [1]
		{   
			JavaParser.superSuffix_return retval = new JavaParser.superSuffix_return();
			retval.Start = input.LT(1);
			int superSuffix_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal506 = null;
			IToken IDENTIFIER508 = null;
			JavaParser.arguments_return arguments505 = default(JavaParser.arguments_return);

			JavaParser.typeArguments_return typeArguments507 = default(JavaParser.typeArguments_return);

			JavaParser.arguments_return arguments509 = default(JavaParser.arguments_return);


			object char_literal506_tree=null;
			object IDENTIFIER508_tree=null;

			const string elementName = "superSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 90) ) 
				{
					return retval; 
				}
				// Java.g:1322:5: ( arguments | '.' ( typeArguments )? IDENTIFIER ( arguments )? )
				int alt140 = 2;
				int LA140_0 = input.LA(1);

				if ( (LA140_0 == LPAREN) )
				{
					alt140 = 1;
				}
				else if ( (LA140_0 == DOT) )
				{
					alt140 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d140s0 =
						new NoViableAltException("", 140, 0, input);

					throw nvae_d140s0;
				}
				switch (alt140) 
				{
				case 1 :
					// Java.g:1322:9: arguments
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_arguments_in_superSuffix7656);
					arguments505 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments505.Tree, arguments505, retval);

				}
					break;
				case 2 :
					// Java.g:1323:9: '.' ( typeArguments )? IDENTIFIER ( arguments )?
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal506=(IToken)Match(input,DOT,FOLLOW_DOT_in_superSuffix7666); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal506_tree = (object)adaptor.Create(char_literal506, retval);
						adaptor.AddChild(root_0, char_literal506_tree);
					}
					// Java.g:1323:13: ( typeArguments )?
					int alt138 = 2;
					int LA138_0 = input.LA(1);

					if ( (LA138_0 == LT) )
					{
						alt138 = 1;
					}
					switch (alt138) 
					{
					case 1 :
						// Java.g:1323:14: typeArguments
					{
						PushFollow(FOLLOW_typeArguments_in_superSuffix7669);
						typeArguments507 = typeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArguments507.Tree, typeArguments507, retval);

					}
						break;

					}

					IDENTIFIER508=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_superSuffix7690); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER508_tree = (object)adaptor.Create(IDENTIFIER508, retval);
						adaptor.AddChild(root_0, IDENTIFIER508_tree);
					}
					// Java.g:1326:9: ( arguments )?
					int alt139 = 2;
					int LA139_0 = input.LA(1);

					if ( (LA139_0 == LPAREN) )
					{
						alt139 = 1;
					}
					switch (alt139) 
					{
					case 1 :
						// Java.g:1326:10: arguments
					{
						PushFollow(FOLLOW_arguments_in_superSuffix7701);
						arguments509 = arguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments509.Tree, arguments509, retval);

					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 90, superSuffix_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "superSuffix"

		public class identifierSuffix_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "identifierSuffix"
		// Java.g:1331:1: identifierSuffix : ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator );
		public JavaParser.identifierSuffix_return identifierSuffix() // throws RecognitionException [1]
		{   
			JavaParser.identifierSuffix_return retval = new JavaParser.identifierSuffix_return();
			retval.Start = input.LT(1);
			int identifierSuffix_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal510 = null;
			IToken char_literal511 = null;
			IToken char_literal512 = null;
			IToken string_literal513 = null;
			IToken char_literal514 = null;
			IToken char_literal516 = null;
			IToken char_literal518 = null;
			IToken string_literal519 = null;
			IToken char_literal520 = null;
			IToken IDENTIFIER522 = null;
			IToken char_literal524 = null;
			IToken string_literal525 = null;
			IToken char_literal526 = null;
			IToken string_literal527 = null;
			JavaParser.expression_return expression515 = default(JavaParser.expression_return);

			JavaParser.arguments_return arguments517 = default(JavaParser.arguments_return);

			JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments521 = default(JavaParser.nonWildcardTypeArguments_return);

			JavaParser.arguments_return arguments523 = default(JavaParser.arguments_return);

			JavaParser.arguments_return arguments528 = default(JavaParser.arguments_return);

			JavaParser.innerCreator_return innerCreator529 = default(JavaParser.innerCreator_return);


			object char_literal510_tree=null;
			object char_literal511_tree=null;
			object char_literal512_tree=null;
			object string_literal513_tree=null;
			object char_literal514_tree=null;
			object char_literal516_tree=null;
			object char_literal518_tree=null;
			object string_literal519_tree=null;
			object char_literal520_tree=null;
			object IDENTIFIER522_tree=null;
			object char_literal524_tree=null;
			object string_literal525_tree=null;
			object char_literal526_tree=null;
			object string_literal527_tree=null;

			const string elementName = "identifierSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 91) ) 
				{
					return retval; 
				}
				// Java.g:1334:5: ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator )
				int alt143 = 8;
				alt143 = dfa143.Predict(input);
				switch (alt143) 
				{
				case 1 :
					// Java.g:1334:9: ( '[' ']' )+ '.' 'class'
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:1334:9: ( '[' ']' )+
					int cnt141 = 0;
					do 
					{
						int alt141 = 2;
						int LA141_0 = input.LA(1);

						if ( (LA141_0 == LBRACKET) )
						{
							alt141 = 1;
						}


						switch (alt141) 
						{
						case 1 :
							// Java.g:1334:10: '[' ']'
						{
							char_literal510=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_identifierSuffix7743); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal510_tree = (object)adaptor.Create(char_literal510, retval);
								adaptor.AddChild(root_0, char_literal510_tree);
							}
							char_literal511=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_identifierSuffix7745); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal511_tree = (object)adaptor.Create(char_literal511, retval);
								adaptor.AddChild(root_0, char_literal511_tree);
							}

						}
							break;

						default:
							if ( cnt141 >= 1 ) goto loop141;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee141 =
								new EarlyExitException(141, input);
							throw eee141;
						}
						cnt141++;
					} while (true);

					loop141:
					;	// Stops C# compiler whining that label 'loop141' has no statements

					char_literal512=(IToken)Match(input,DOT,FOLLOW_DOT_in_identifierSuffix7766); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal512_tree = (object)adaptor.Create(char_literal512, retval);
						adaptor.AddChild(root_0, char_literal512_tree);
					}
					string_literal513=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_identifierSuffix7768); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal513_tree = (object)adaptor.Create(string_literal513, retval);
						adaptor.AddChild(root_0, string_literal513_tree);
					}

				}
					break;
				case 2 :
					// Java.g:1337:9: ( '[' expression ']' )+
				{
					root_0 = (object)adaptor.GetNilNode();

					// Java.g:1337:9: ( '[' expression ']' )+
					int cnt142 = 0;
					do 
					{
						int alt142 = 2;
						alt142 = dfa142.Predict(input);
						switch (alt142) 
						{
						case 1 :
							// Java.g:1337:10: '[' expression ']'
						{
							char_literal514=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_identifierSuffix7779); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal514_tree = (object)adaptor.Create(char_literal514, retval);
								adaptor.AddChild(root_0, char_literal514_tree);
							}
							PushFollow(FOLLOW_expression_in_identifierSuffix7781);
							expression515 = expression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression515.Tree, expression515, retval);
							char_literal516=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_identifierSuffix7783); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal516_tree = (object)adaptor.Create(char_literal516, retval);
								adaptor.AddChild(root_0, char_literal516_tree);
							}

						}
							break;

						default:
							if ( cnt142 >= 1 ) goto loop142;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee142 =
								new EarlyExitException(142, input);
							throw eee142;
						}
						cnt142++;
					} while (true);

					loop142:
					;	// Stops C# compiler whining that label 'loop142' has no statements


				}
					break;
				case 3 :
					// Java.g:1339:9: arguments
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_arguments_in_identifierSuffix7804);
					arguments517 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments517.Tree, arguments517, retval);

				}
					break;
				case 4 :
					// Java.g:1340:9: '.' 'class'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal518=(IToken)Match(input,DOT,FOLLOW_DOT_in_identifierSuffix7814); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal518_tree = (object)adaptor.Create(char_literal518, retval);
						adaptor.AddChild(root_0, char_literal518_tree);
					}
					string_literal519=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_identifierSuffix7816); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal519_tree = (object)adaptor.Create(string_literal519, retval);
						adaptor.AddChild(root_0, string_literal519_tree);
					}

				}
					break;
				case 5 :
					// Java.g:1341:9: '.' nonWildcardTypeArguments IDENTIFIER arguments
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal520=(IToken)Match(input,DOT,FOLLOW_DOT_in_identifierSuffix7826); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal520_tree = (object)adaptor.Create(char_literal520, retval);
						adaptor.AddChild(root_0, char_literal520_tree);
					}
					PushFollow(FOLLOW_nonWildcardTypeArguments_in_identifierSuffix7828);
					nonWildcardTypeArguments521 = nonWildcardTypeArguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, nonWildcardTypeArguments521.Tree, nonWildcardTypeArguments521, retval);
					IDENTIFIER522=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifierSuffix7830); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER522_tree = (object)adaptor.Create(IDENTIFIER522, retval);
						adaptor.AddChild(root_0, IDENTIFIER522_tree);
					}
					PushFollow(FOLLOW_arguments_in_identifierSuffix7832);
					arguments523 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments523.Tree, arguments523, retval);

				}
					break;
				case 6 :
					// Java.g:1342:9: '.' 'this'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal524=(IToken)Match(input,DOT,FOLLOW_DOT_in_identifierSuffix7842); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal524_tree = (object)adaptor.Create(char_literal524, retval);
						adaptor.AddChild(root_0, char_literal524_tree);
					}
					string_literal525=(IToken)Match(input,THIS,FOLLOW_THIS_in_identifierSuffix7844); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal525_tree = (object)adaptor.Create(string_literal525, retval);
						adaptor.AddChild(root_0, string_literal525_tree);
					}

				}
					break;
				case 7 :
					// Java.g:1343:9: '.' 'super' arguments
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal526=(IToken)Match(input,DOT,FOLLOW_DOT_in_identifierSuffix7854); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal526_tree = (object)adaptor.Create(char_literal526, retval);
						adaptor.AddChild(root_0, char_literal526_tree);
					}
					string_literal527=(IToken)Match(input,SUPER,FOLLOW_SUPER_in_identifierSuffix7856); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal527_tree = (object)adaptor.Create(string_literal527, retval);
						adaptor.AddChild(root_0, string_literal527_tree);
					}
					PushFollow(FOLLOW_arguments_in_identifierSuffix7858);
					arguments528 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments528.Tree, arguments528, retval);

				}
					break;
				case 8 :
					// Java.g:1344:9: innerCreator
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_innerCreator_in_identifierSuffix7868);
					innerCreator529 = innerCreator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, innerCreator529.Tree, innerCreator529, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 91, identifierSuffix_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "identifierSuffix"

		public class selector_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "selector"
		// Java.g:1348:1: selector : ( '.' IDENTIFIER ( arguments )? | '.' 'this' | '.' 'super' superSuffix | innerCreator | '[' expression ']' );
		public JavaParser.selector_return selector() // throws RecognitionException [1]
		{   
			JavaParser.selector_return retval = new JavaParser.selector_return();
			retval.Start = input.LT(1);
			int selector_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal530 = null;
			IToken IDENTIFIER531 = null;
			IToken char_literal533 = null;
			IToken string_literal534 = null;
			IToken char_literal535 = null;
			IToken string_literal536 = null;
			IToken char_literal539 = null;
			IToken char_literal541 = null;
			JavaParser.arguments_return arguments532 = default(JavaParser.arguments_return);

			JavaParser.superSuffix_return superSuffix537 = default(JavaParser.superSuffix_return);

			JavaParser.innerCreator_return innerCreator538 = default(JavaParser.innerCreator_return);

			JavaParser.expression_return expression540 = default(JavaParser.expression_return);


			object char_literal530_tree=null;
			object IDENTIFIER531_tree=null;
			object char_literal533_tree=null;
			object string_literal534_tree=null;
			object char_literal535_tree=null;
			object string_literal536_tree=null;
			object char_literal539_tree=null;
			object char_literal541_tree=null;

			const string elementName = "selector"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 92) ) 
				{
					return retval; 
				}
				// Java.g:1351:5: ( '.' IDENTIFIER ( arguments )? | '.' 'this' | '.' 'super' superSuffix | innerCreator | '[' expression ']' )
				int alt145 = 5;
				int LA145_0 = input.LA(1);

				if ( (LA145_0 == DOT) )
				{
					switch ( input.LA(2) ) 
					{
					case IDENTIFIER:
					{
						alt145 = 1;
					}
						break;
					case THIS:
					{
						alt145 = 2;
					}
						break;
					case SUPER:
					{
						alt145 = 3;
					}
						break;
					case NEW:
					{
						alt145 = 4;
					}
						break;
					default:
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d145s1 =
							new NoViableAltException("", 145, 1, input);

						throw nvae_d145s1;
					}

				}
				else if ( (LA145_0 == LBRACKET) )
				{
					alt145 = 5;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d145s0 =
						new NoViableAltException("", 145, 0, input);

					throw nvae_d145s0;
				}
				switch (alt145) 
				{
				case 1 :
					// Java.g:1351:9: '.' IDENTIFIER ( arguments )?
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal530=(IToken)Match(input,DOT,FOLLOW_DOT_in_selector7898); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal530_tree = (object)adaptor.Create(char_literal530, retval);
						adaptor.AddChild(root_0, char_literal530_tree);
					}
					IDENTIFIER531=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_selector7900); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER531_tree = (object)adaptor.Create(IDENTIFIER531, retval);
						adaptor.AddChild(root_0, IDENTIFIER531_tree);
					}
					// Java.g:1352:9: ( arguments )?
					int alt144 = 2;
					int LA144_0 = input.LA(1);

					if ( (LA144_0 == LPAREN) )
					{
						alt144 = 1;
					}
					switch (alt144) 
					{
					case 1 :
						// Java.g:1352:10: arguments
					{
						PushFollow(FOLLOW_arguments_in_selector7911);
						arguments532 = arguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments532.Tree, arguments532, retval);

					}
						break;

					}


				}
					break;
				case 2 :
					// Java.g:1354:9: '.' 'this'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal533=(IToken)Match(input,DOT,FOLLOW_DOT_in_selector7932); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal533_tree = (object)adaptor.Create(char_literal533, retval);
						adaptor.AddChild(root_0, char_literal533_tree);
					}
					string_literal534=(IToken)Match(input,THIS,FOLLOW_THIS_in_selector7934); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal534_tree = (object)adaptor.Create(string_literal534, retval);
						adaptor.AddChild(root_0, string_literal534_tree);
					}

				}
					break;
				case 3 :
					// Java.g:1355:9: '.' 'super' superSuffix
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal535=(IToken)Match(input,DOT,FOLLOW_DOT_in_selector7944); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal535_tree = (object)adaptor.Create(char_literal535, retval);
						adaptor.AddChild(root_0, char_literal535_tree);
					}
					string_literal536=(IToken)Match(input,SUPER,FOLLOW_SUPER_in_selector7946); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal536_tree = (object)adaptor.Create(string_literal536, retval);
						adaptor.AddChild(root_0, string_literal536_tree);
					}
					PushFollow(FOLLOW_superSuffix_in_selector7956);
					superSuffix537 = superSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, superSuffix537.Tree, superSuffix537, retval);

				}
					break;
				case 4 :
					// Java.g:1357:9: innerCreator
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_innerCreator_in_selector7966);
					innerCreator538 = innerCreator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, innerCreator538.Tree, innerCreator538, retval);

				}
					break;
				case 5 :
					// Java.g:1358:9: '[' expression ']'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal539=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_selector7976); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal539_tree = (object)adaptor.Create(char_literal539, retval);
						adaptor.AddChild(root_0, char_literal539_tree);
					}
					PushFollow(FOLLOW_expression_in_selector7978);
					expression540 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression540.Tree, expression540, retval);
					char_literal541=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_selector7980); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal541_tree = (object)adaptor.Create(char_literal541, retval);
						adaptor.AddChild(root_0, char_literal541_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 92, selector_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "selector"

		public class creator_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "creator"
		// Java.g:1361:1: creator : ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest | 'new' classOrInterfaceType classCreatorRest | arrayCreator );
		public JavaParser.creator_return creator() // throws RecognitionException [1]
		{   
			JavaParser.creator_return retval = new JavaParser.creator_return();
			retval.Start = input.LT(1);
			int creator_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal542 = null;
			IToken string_literal546 = null;
			JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments543 = default(JavaParser.nonWildcardTypeArguments_return);

			JavaParser.classOrInterfaceType_return classOrInterfaceType544 = default(JavaParser.classOrInterfaceType_return);

			JavaParser.classCreatorRest_return classCreatorRest545 = default(JavaParser.classCreatorRest_return);

			JavaParser.classOrInterfaceType_return classOrInterfaceType547 = default(JavaParser.classOrInterfaceType_return);

			JavaParser.classCreatorRest_return classCreatorRest548 = default(JavaParser.classCreatorRest_return);

			JavaParser.arrayCreator_return arrayCreator549 = default(JavaParser.arrayCreator_return);


			object string_literal542_tree=null;
			object string_literal546_tree=null;

			const string elementName = "creator"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 93) ) 
				{
					return retval; 
				}
				// Java.g:1364:5: ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest | 'new' classOrInterfaceType classCreatorRest | arrayCreator )
				int alt146 = 3;
				int LA146_0 = input.LA(1);

				if ( (LA146_0 == NEW) )
				{
					int LA146_1 = input.LA(2);

					if ( (synpred236_Java()) )
					{
						alt146 = 1;
					}
					else if ( (synpred237_Java()) )
					{
						alt146 = 2;
					}
					else if ( (true) )
					{
						alt146 = 3;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d146s1 =
							new NoViableAltException("", 146, 1, input);

						throw nvae_d146s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d146s0 =
						new NoViableAltException("", 146, 0, input);

					throw nvae_d146s0;
				}
				switch (alt146) 
				{
				case 1 :
					// Java.g:1364:9: 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal542=(IToken)Match(input,NEW,FOLLOW_NEW_in_creator8009); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal542_tree = (object)adaptor.Create(string_literal542, retval);
						adaptor.AddChild(root_0, string_literal542_tree);
					}
					PushFollow(FOLLOW_nonWildcardTypeArguments_in_creator8011);
					nonWildcardTypeArguments543 = nonWildcardTypeArguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, nonWildcardTypeArguments543.Tree, nonWildcardTypeArguments543, retval);
					PushFollow(FOLLOW_classOrInterfaceType_in_creator8013);
					classOrInterfaceType544 = classOrInterfaceType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceType544.Tree, classOrInterfaceType544, retval);
					PushFollow(FOLLOW_classCreatorRest_in_creator8015);
					classCreatorRest545 = classCreatorRest();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classCreatorRest545.Tree, classCreatorRest545, retval);

				}
					break;
				case 2 :
					// Java.g:1365:9: 'new' classOrInterfaceType classCreatorRest
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal546=(IToken)Match(input,NEW,FOLLOW_NEW_in_creator8025); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal546_tree = (object)adaptor.Create(string_literal546, retval);
						adaptor.AddChild(root_0, string_literal546_tree);
					}
					PushFollow(FOLLOW_classOrInterfaceType_in_creator8027);
					classOrInterfaceType547 = classOrInterfaceType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceType547.Tree, classOrInterfaceType547, retval);
					PushFollow(FOLLOW_classCreatorRest_in_creator8029);
					classCreatorRest548 = classCreatorRest();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classCreatorRest548.Tree, classCreatorRest548, retval);

				}
					break;
				case 3 :
					// Java.g:1366:9: arrayCreator
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_arrayCreator_in_creator8039);
					arrayCreator549 = arrayCreator();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayCreator549.Tree, arrayCreator549, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 93, creator_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "creator"

		public class arrayCreator_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "arrayCreator"
		// Java.g:1369:1: arrayCreator : ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer | 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )* );
		public JavaParser.arrayCreator_return arrayCreator() // throws RecognitionException [1]
		{   
			JavaParser.arrayCreator_return retval = new JavaParser.arrayCreator_return();
			retval.Start = input.LT(1);
			int arrayCreator_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal550 = null;
			IToken char_literal552 = null;
			IToken char_literal553 = null;
			IToken char_literal554 = null;
			IToken char_literal555 = null;
			IToken string_literal557 = null;
			IToken char_literal559 = null;
			IToken char_literal561 = null;
			IToken char_literal562 = null;
			IToken char_literal564 = null;
			IToken char_literal565 = null;
			IToken char_literal566 = null;
			JavaParser.createdName_return createdName551 = default(JavaParser.createdName_return);

			JavaParser.arrayInitializer_return arrayInitializer556 = default(JavaParser.arrayInitializer_return);

			JavaParser.createdName_return createdName558 = default(JavaParser.createdName_return);

			JavaParser.expression_return expression560 = default(JavaParser.expression_return);

			JavaParser.expression_return expression563 = default(JavaParser.expression_return);


			object string_literal550_tree=null;
			object char_literal552_tree=null;
			object char_literal553_tree=null;
			object char_literal554_tree=null;
			object char_literal555_tree=null;
			object string_literal557_tree=null;
			object char_literal559_tree=null;
			object char_literal561_tree=null;
			object char_literal562_tree=null;
			object char_literal564_tree=null;
			object char_literal565_tree=null;
			object char_literal566_tree=null;

			const string elementName = "arrayCreator"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 94) ) 
				{
					return retval; 
				}
				// Java.g:1372:5: ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer | 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )* )
				int alt150 = 2;
				int LA150_0 = input.LA(1);

				if ( (LA150_0 == NEW) )
				{
					int LA150_1 = input.LA(2);

					if ( (synpred239_Java()) )
					{
						alt150 = 1;
					}
					else if ( (true) )
					{
						alt150 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d150s1 =
							new NoViableAltException("", 150, 1, input);

						throw nvae_d150s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d150s0 =
						new NoViableAltException("", 150, 0, input);

					throw nvae_d150s0;
				}
				switch (alt150) 
				{
				case 1 :
					// Java.g:1372:9: 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal550=(IToken)Match(input,NEW,FOLLOW_NEW_in_arrayCreator8068); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal550_tree = (object)adaptor.Create(string_literal550, retval);
						adaptor.AddChild(root_0, string_literal550_tree);
					}
					PushFollow(FOLLOW_createdName_in_arrayCreator8070);
					createdName551 = createdName();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, createdName551.Tree, createdName551, retval);
					char_literal552=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_arrayCreator8080); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal552_tree = (object)adaptor.Create(char_literal552, retval);
						adaptor.AddChild(root_0, char_literal552_tree);
					}
					char_literal553=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_arrayCreator8082); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal553_tree = (object)adaptor.Create(char_literal553, retval);
						adaptor.AddChild(root_0, char_literal553_tree);
					}
					// Java.g:1374:9: ( '[' ']' )*
					do 
					{
						int alt147 = 2;
						int LA147_0 = input.LA(1);

						if ( (LA147_0 == LBRACKET) )
						{
							alt147 = 1;
						}


						switch (alt147) 
						{
						case 1 :
							// Java.g:1374:10: '[' ']'
						{
							char_literal554=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_arrayCreator8093); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal554_tree = (object)adaptor.Create(char_literal554, retval);
								adaptor.AddChild(root_0, char_literal554_tree);
							}
							char_literal555=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_arrayCreator8095); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal555_tree = (object)adaptor.Create(char_literal555, retval);
								adaptor.AddChild(root_0, char_literal555_tree);
							}

						}
							break;

						default:
							goto loop147;
						}
					} while (true);

					loop147:
					;	// Stops C# compiler whining that label 'loop147' has no statements

					PushFollow(FOLLOW_arrayInitializer_in_arrayCreator8116);
					arrayInitializer556 = arrayInitializer();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayInitializer556.Tree, arrayInitializer556, retval);

				}
					break;
				case 2 :
					// Java.g:1378:9: 'new' createdName '[' expression ']' ( '[' expression ']' )* ( '[' ']' )*
				{
					root_0 = (object)adaptor.GetNilNode();

					string_literal557=(IToken)Match(input,NEW,FOLLOW_NEW_in_arrayCreator8127); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal557_tree = (object)adaptor.Create(string_literal557, retval);
						adaptor.AddChild(root_0, string_literal557_tree);
					}
					PushFollow(FOLLOW_createdName_in_arrayCreator8129);
					createdName558 = createdName();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, createdName558.Tree, createdName558, retval);
					char_literal559=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_arrayCreator8139); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal559_tree = (object)adaptor.Create(char_literal559, retval);
						adaptor.AddChild(root_0, char_literal559_tree);
					}
					PushFollow(FOLLOW_expression_in_arrayCreator8141);
					expression560 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression560.Tree, expression560, retval);
					char_literal561=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_arrayCreator8151); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal561_tree = (object)adaptor.Create(char_literal561, retval);
						adaptor.AddChild(root_0, char_literal561_tree);
					}
					// Java.g:1381:9: ( '[' expression ']' )*
					do 
					{
						int alt148 = 2;
						alt148 = dfa148.Predict(input);
						switch (alt148) 
						{
						case 1 :
							// Java.g:1381:13: '[' expression ']'
						{
							char_literal562=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_arrayCreator8165); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal562_tree = (object)adaptor.Create(char_literal562, retval);
								adaptor.AddChild(root_0, char_literal562_tree);
							}
							PushFollow(FOLLOW_expression_in_arrayCreator8167);
							expression563 = expression();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression563.Tree, expression563, retval);
							char_literal564=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_arrayCreator8181); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal564_tree = (object)adaptor.Create(char_literal564, retval);
								adaptor.AddChild(root_0, char_literal564_tree);
							}

						}
							break;

						default:
							goto loop148;
						}
					} while (true);

					loop148:
					;	// Stops C# compiler whining that label 'loop148' has no statements

					// Java.g:1384:9: ( '[' ']' )*
					do 
					{
						int alt149 = 2;
						int LA149_0 = input.LA(1);

						if ( (LA149_0 == LBRACKET) )
						{
							int LA149_2 = input.LA(2);

							if ( (LA149_2 == RBRACKET) )
							{
								alt149 = 1;
							}


						}


						switch (alt149) 
						{
						case 1 :
							// Java.g:1384:10: '[' ']'
						{
							char_literal565=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_arrayCreator8203); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal565_tree = (object)adaptor.Create(char_literal565, retval);
								adaptor.AddChild(root_0, char_literal565_tree);
							}
							char_literal566=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_arrayCreator8205); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal566_tree = (object)adaptor.Create(char_literal566, retval);
								adaptor.AddChild(root_0, char_literal566_tree);
							}

						}
							break;

						default:
							goto loop149;
						}
					} while (true);

					loop149:
					;	// Stops C# compiler whining that label 'loop149' has no statements


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 94, arrayCreator_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "arrayCreator"

		public class variableInitializer_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "variableInitializer"
		// Java.g:1388:1: variableInitializer : ( arrayInitializer | expression );
		public JavaParser.variableInitializer_return variableInitializer() // throws RecognitionException [1]
		{   
			JavaParser.variableInitializer_return retval = new JavaParser.variableInitializer_return();
			retval.Start = input.LT(1);
			int variableInitializer_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.arrayInitializer_return arrayInitializer567 = default(JavaParser.arrayInitializer_return);

			JavaParser.expression_return expression568 = default(JavaParser.expression_return);



			const string elementName = "variableInitializer"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 95) ) 
				{
					return retval; 
				}
				// Java.g:1391:5: ( arrayInitializer | expression )
				int alt151 = 2;
				int LA151_0 = input.LA(1);

				if ( (LA151_0 == LBRACE) )
				{
					alt151 = 1;
				}
				else if ( ((LA151_0 >= IDENTIFIER && LA151_0 <= NULL) || LA151_0 == BOOLEAN || LA151_0 == BYTE || LA151_0 == CHAR || LA151_0 == DOUBLE || LA151_0 == FLOAT || LA151_0 == INT || LA151_0 == LONG || LA151_0 == NEW || LA151_0 == SHORT || LA151_0 == SUPER || LA151_0 == THIS || LA151_0 == VOID || LA151_0 == LPAREN || (LA151_0 >= BANG && LA151_0 <= TILDE) || (LA151_0 >= PLUSPLUS && LA151_0 <= SUB)) )
				{
					alt151 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d151s0 =
						new NoViableAltException("", 151, 0, input);

					throw nvae_d151s0;
				}
				switch (alt151) 
				{
				case 1 :
					// Java.g:1391:9: arrayInitializer
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_arrayInitializer_in_variableInitializer8245);
					arrayInitializer567 = arrayInitializer();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayInitializer567.Tree, arrayInitializer567, retval);

				}
					break;
				case 2 :
					// Java.g:1392:9: expression
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_expression_in_variableInitializer8255);
					expression568 = expression();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression568.Tree, expression568, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 95, variableInitializer_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "variableInitializer"

		public class arrayInitializer_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "arrayInitializer"
		// Java.g:1395:1: arrayInitializer : '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}' ;
		public JavaParser.arrayInitializer_return arrayInitializer() // throws RecognitionException [1]
		{   
			JavaParser.arrayInitializer_return retval = new JavaParser.arrayInitializer_return();
			retval.Start = input.LT(1);
			int arrayInitializer_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal569 = null;
			IToken char_literal571 = null;
			IToken char_literal573 = null;
			IToken char_literal574 = null;
			JavaParser.variableInitializer_return variableInitializer570 = default(JavaParser.variableInitializer_return);

			JavaParser.variableInitializer_return variableInitializer572 = default(JavaParser.variableInitializer_return);


			object char_literal569_tree=null;
			object char_literal571_tree=null;
			object char_literal573_tree=null;
			object char_literal574_tree=null;

			const string elementName = "arrayInitializer"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 96) ) 
				{
					return retval; 
				}
				// Java.g:1398:5: ( '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}' )
				// Java.g:1398:9: '{' ( variableInitializer ( ',' variableInitializer )* )? ( ',' )? '}'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal569=(IToken)Match(input,LBRACE,FOLLOW_LBRACE_in_arrayInitializer8284); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal569_tree = (object)adaptor.Create(char_literal569, retval);
						adaptor.AddChild(root_0, char_literal569_tree);
					}
					// Java.g:1399:13: ( variableInitializer ( ',' variableInitializer )* )?
					int alt153 = 2;
					int LA153_0 = input.LA(1);

					if ( ((LA153_0 >= IDENTIFIER && LA153_0 <= NULL) || LA153_0 == BOOLEAN || LA153_0 == BYTE || LA153_0 == CHAR || LA153_0 == DOUBLE || LA153_0 == FLOAT || LA153_0 == INT || LA153_0 == LONG || LA153_0 == NEW || LA153_0 == SHORT || LA153_0 == SUPER || LA153_0 == THIS || LA153_0 == VOID || LA153_0 == LPAREN || LA153_0 == LBRACE || (LA153_0 >= BANG && LA153_0 <= TILDE) || (LA153_0 >= PLUSPLUS && LA153_0 <= SUB)) )
					{
						alt153 = 1;
					}
					switch (alt153) 
					{
					case 1 :
						// Java.g:1399:14: variableInitializer ( ',' variableInitializer )*
					{
						PushFollow(FOLLOW_variableInitializer_in_arrayInitializer8300);
						variableInitializer570 = variableInitializer();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableInitializer570.Tree, variableInitializer570, retval);
						// Java.g:1400:17: ( ',' variableInitializer )*
						do 
						{
							int alt152 = 2;
							int LA152_0 = input.LA(1);

							if ( (LA152_0 == COMMA) )
							{
								int LA152_1 = input.LA(2);

								if ( ((LA152_1 >= IDENTIFIER && LA152_1 <= NULL) || LA152_1 == BOOLEAN || LA152_1 == BYTE || LA152_1 == CHAR || LA152_1 == DOUBLE || LA152_1 == FLOAT || LA152_1 == INT || LA152_1 == LONG || LA152_1 == NEW || LA152_1 == SHORT || LA152_1 == SUPER || LA152_1 == THIS || LA152_1 == VOID || LA152_1 == LPAREN || LA152_1 == LBRACE || (LA152_1 >= BANG && LA152_1 <= TILDE) || (LA152_1 >= PLUSPLUS && LA152_1 <= SUB)) )
								{
									alt152 = 1;
								}


							}


							switch (alt152) 
							{
							case 1 :
								// Java.g:1400:18: ',' variableInitializer
							{
								char_literal571=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_arrayInitializer8319); if (state.failed) return retval;
								if ( state.backtracking == 0 )
								{char_literal571_tree = (object)adaptor.Create(char_literal571, retval);
									adaptor.AddChild(root_0, char_literal571_tree);
								}
								PushFollow(FOLLOW_variableInitializer_in_arrayInitializer8321);
								variableInitializer572 = variableInitializer();
								state.followingStackPointer--;
								if (state.failed) return retval;
								if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableInitializer572.Tree, variableInitializer572, retval);

							}
								break;

							default:
								goto loop152;
							}
						} while (true);

						loop152:
						;	// Stops C# compiler whining that label 'loop152' has no statements


					}
						break;

					}

					// Java.g:1403:13: ( ',' )?
					int alt154 = 2;
					int LA154_0 = input.LA(1);

					if ( (LA154_0 == COMMA) )
					{
						alt154 = 1;
					}
					switch (alt154) 
					{
					case 1 :
						// Java.g:1403:14: ','
					{
						char_literal573=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_arrayInitializer8371); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal573_tree = (object)adaptor.Create(char_literal573, retval);
							adaptor.AddChild(root_0, char_literal573_tree);
						}

					}
						break;

					}

					char_literal574=(IToken)Match(input,RBRACE,FOLLOW_RBRACE_in_arrayInitializer8384); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal574_tree = (object)adaptor.Create(char_literal574, retval);
						adaptor.AddChild(root_0, char_literal574_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 96, arrayInitializer_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "arrayInitializer"

		public class createdName_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "createdName"
		// Java.g:1408:1: createdName : ( classOrInterfaceType | primitiveType );
		public JavaParser.createdName_return createdName() // throws RecognitionException [1]
		{   
			JavaParser.createdName_return retval = new JavaParser.createdName_return();
			retval.Start = input.LT(1);
			int createdName_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.classOrInterfaceType_return classOrInterfaceType575 = default(JavaParser.classOrInterfaceType_return);

			JavaParser.primitiveType_return primitiveType576 = default(JavaParser.primitiveType_return);



			const string elementName = "createdName"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 97) ) 
				{
					return retval; 
				}
				// Java.g:1411:5: ( classOrInterfaceType | primitiveType )
				int alt155 = 2;
				int LA155_0 = input.LA(1);

				if ( (LA155_0 == IDENTIFIER) )
				{
					alt155 = 1;
				}
				else if ( (LA155_0 == BOOLEAN || LA155_0 == BYTE || LA155_0 == CHAR || LA155_0 == DOUBLE || LA155_0 == FLOAT || LA155_0 == INT || LA155_0 == LONG || LA155_0 == SHORT) )
				{
					alt155 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d155s0 =
						new NoViableAltException("", 155, 0, input);

					throw nvae_d155s0;
				}
				switch (alt155) 
				{
				case 1 :
					// Java.g:1411:9: classOrInterfaceType
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_classOrInterfaceType_in_createdName8427);
					classOrInterfaceType575 = classOrInterfaceType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classOrInterfaceType575.Tree, classOrInterfaceType575, retval);

				}
					break;
				case 2 :
					// Java.g:1412:9: primitiveType
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_primitiveType_in_createdName8437);
					primitiveType576 = primitiveType();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primitiveType576.Tree, primitiveType576, retval);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 97, createdName_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "createdName"

		public class innerCreator_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "innerCreator"
		// Java.g:1415:1: innerCreator : '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest ;
		public JavaParser.innerCreator_return innerCreator() // throws RecognitionException [1]
		{   
			JavaParser.innerCreator_return retval = new JavaParser.innerCreator_return();
			retval.Start = input.LT(1);
			int innerCreator_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal577 = null;
			IToken string_literal578 = null;
			IToken IDENTIFIER580 = null;
			JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments579 = default(JavaParser.nonWildcardTypeArguments_return);

			JavaParser.typeArguments_return typeArguments581 = default(JavaParser.typeArguments_return);

			JavaParser.classCreatorRest_return classCreatorRest582 = default(JavaParser.classCreatorRest_return);


			object char_literal577_tree=null;
			object string_literal578_tree=null;
			object IDENTIFIER580_tree=null;

			const string elementName = "innerCreator"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 98) ) 
				{
					return retval; 
				}
				// Java.g:1418:5: ( '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest )
				// Java.g:1418:9: '.' 'new' ( nonWildcardTypeArguments )? IDENTIFIER ( typeArguments )? classCreatorRest
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal577=(IToken)Match(input,DOT,FOLLOW_DOT_in_innerCreator8466); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal577_tree = (object)adaptor.Create(char_literal577, retval);
						adaptor.AddChild(root_0, char_literal577_tree);
					}
					string_literal578=(IToken)Match(input,NEW,FOLLOW_NEW_in_innerCreator8468); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal578_tree = (object)adaptor.Create(string_literal578, retval);
						adaptor.AddChild(root_0, string_literal578_tree);
					}
					// Java.g:1419:9: ( nonWildcardTypeArguments )?
					int alt156 = 2;
					int LA156_0 = input.LA(1);

					if ( (LA156_0 == LT) )
					{
						alt156 = 1;
					}
					switch (alt156) 
					{
					case 1 :
						// Java.g:1419:10: nonWildcardTypeArguments
					{
						PushFollow(FOLLOW_nonWildcardTypeArguments_in_innerCreator8479);
						nonWildcardTypeArguments579 = nonWildcardTypeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, nonWildcardTypeArguments579.Tree, nonWildcardTypeArguments579, retval);

					}
						break;

					}

					IDENTIFIER580=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_innerCreator8500); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER580_tree = (object)adaptor.Create(IDENTIFIER580, retval);
						adaptor.AddChild(root_0, IDENTIFIER580_tree);
					}
					// Java.g:1422:9: ( typeArguments )?
					int alt157 = 2;
					int LA157_0 = input.LA(1);

					if ( (LA157_0 == LT) )
					{
						alt157 = 1;
					}
					switch (alt157) 
					{
					case 1 :
						// Java.g:1422:10: typeArguments
					{
						PushFollow(FOLLOW_typeArguments_in_innerCreator8511);
						typeArguments581 = typeArguments();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeArguments581.Tree, typeArguments581, retval);

					}
						break;

					}

					PushFollow(FOLLOW_classCreatorRest_in_innerCreator8532);
					classCreatorRest582 = classCreatorRest();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classCreatorRest582.Tree, classCreatorRest582, retval);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 98, innerCreator_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "innerCreator"

		public class classCreatorRest_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classCreatorRest"
		// Java.g:1428:1: classCreatorRest : arguments ( classBody )? ;
		public JavaParser.classCreatorRest_return classCreatorRest() // throws RecognitionException [1]
		{   
			JavaParser.classCreatorRest_return retval = new JavaParser.classCreatorRest_return();
			retval.Start = input.LT(1);
			int classCreatorRest_StartIndex = input.Index();
			object root_0 = null;

			JavaParser.arguments_return arguments583 = default(JavaParser.arguments_return);

			JavaParser.classBody_return classBody584 = default(JavaParser.classBody_return);



			const string elementName = "classCreatorRest"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 99) ) 
				{
					return retval; 
				}
				// Java.g:1431:5: ( arguments ( classBody )? )
				// Java.g:1431:9: arguments ( classBody )?
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_arguments_in_classCreatorRest8562);
					arguments583 = arguments();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments583.Tree, arguments583, retval);
					// Java.g:1432:9: ( classBody )?
					int alt158 = 2;
					int LA158_0 = input.LA(1);

					if ( (LA158_0 == LBRACE) )
					{
						alt158 = 1;
					}
					switch (alt158) 
					{
					case 1 :
						// Java.g:1432:10: classBody
					{
						PushFollow(FOLLOW_classBody_in_classCreatorRest8573);
						classBody584 = classBody();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, classBody584.Tree, classBody584, retval);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 99, classCreatorRest_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classCreatorRest"

		public class nonWildcardTypeArguments_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "nonWildcardTypeArguments"
		// Java.g:1437:1: nonWildcardTypeArguments : '<' typeList '>' ;
		public JavaParser.nonWildcardTypeArguments_return nonWildcardTypeArguments() // throws RecognitionException [1]
		{   
			JavaParser.nonWildcardTypeArguments_return retval = new JavaParser.nonWildcardTypeArguments_return();
			retval.Start = input.LT(1);
			int nonWildcardTypeArguments_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal585 = null;
			IToken char_literal587 = null;
			JavaParser.typeList_return typeList586 = default(JavaParser.typeList_return);


			object char_literal585_tree=null;
			object char_literal587_tree=null;

			const string elementName = "nonWildcardTypeArguments"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 100) ) 
				{
					return retval; 
				}
				// Java.g:1440:5: ( '<' typeList '>' )
				// Java.g:1440:9: '<' typeList '>'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal585=(IToken)Match(input,LT,FOLLOW_LT_in_nonWildcardTypeArguments8614); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal585_tree = (object)adaptor.Create(char_literal585, retval);
						adaptor.AddChild(root_0, char_literal585_tree);
					}
					PushFollow(FOLLOW_typeList_in_nonWildcardTypeArguments8616);
					typeList586 = typeList();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeList586.Tree, typeList586, retval);
					char_literal587=(IToken)Match(input,GT,FOLLOW_GT_in_nonWildcardTypeArguments8626); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal587_tree = (object)adaptor.Create(char_literal587, retval);
						adaptor.AddChild(root_0, char_literal587_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 100, nonWildcardTypeArguments_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "nonWildcardTypeArguments"

		public class arguments_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "arguments"
		// Java.g:1444:1: arguments : '(' ( expressionList )? ')' ;
		public JavaParser.arguments_return arguments() // throws RecognitionException [1]
		{   
			JavaParser.arguments_return retval = new JavaParser.arguments_return();
			retval.Start = input.LT(1);
			int arguments_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal588 = null;
			IToken char_literal590 = null;
			JavaParser.expressionList_return expressionList589 = default(JavaParser.expressionList_return);


			object char_literal588_tree=null;
			object char_literal590_tree=null;

			const string elementName = "arguments"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 101) ) 
				{
					return retval; 
				}
				// Java.g:1447:5: ( '(' ( expressionList )? ')' )
				// Java.g:1447:9: '(' ( expressionList )? ')'
				{
					root_0 = (object)adaptor.GetNilNode();

					char_literal588=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_arguments8655); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal588_tree = (object)adaptor.Create(char_literal588, retval);
						adaptor.AddChild(root_0, char_literal588_tree);
					}
					// Java.g:1447:13: ( expressionList )?
					int alt159 = 2;
					int LA159_0 = input.LA(1);

					if ( ((LA159_0 >= IDENTIFIER && LA159_0 <= NULL) || LA159_0 == BOOLEAN || LA159_0 == BYTE || LA159_0 == CHAR || LA159_0 == DOUBLE || LA159_0 == FLOAT || LA159_0 == INT || LA159_0 == LONG || LA159_0 == NEW || LA159_0 == SHORT || LA159_0 == SUPER || LA159_0 == THIS || LA159_0 == VOID || LA159_0 == LPAREN || (LA159_0 >= BANG && LA159_0 <= TILDE) || (LA159_0 >= PLUSPLUS && LA159_0 <= SUB)) )
					{
						alt159 = 1;
					}
					switch (alt159) 
					{
					case 1 :
						// Java.g:1447:14: expressionList
					{
						PushFollow(FOLLOW_expressionList_in_arguments8658);
						expressionList589 = expressionList();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionList589.Tree, expressionList589, retval);

					}
						break;

					}

					char_literal590=(IToken)Match(input,RPAREN,FOLLOW_RPAREN_in_arguments8671); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal590_tree = (object)adaptor.Create(char_literal590, retval);
						adaptor.AddChild(root_0, char_literal590_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 101, arguments_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "arguments"

		public class literal_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "literal"
		// Java.g:1451:1: literal : ( INTLITERAL | LONGLITERAL | FLOATLITERAL | DOUBLELITERAL | CHARLITERAL | STRINGLITERAL | TRUE | FALSE | NULL );
		public JavaParser.literal_return literal() // throws RecognitionException [1]
		{   
			JavaParser.literal_return retval = new JavaParser.literal_return();
			retval.Start = input.LT(1);
			int literal_StartIndex = input.Index();
			object root_0 = null;

			IToken set591 = null;

			object set591_tree=null;

			const string elementName = "literal"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 102) ) 
				{
					return retval; 
				}
				// Java.g:1454:5: ( INTLITERAL | LONGLITERAL | FLOATLITERAL | DOUBLELITERAL | CHARLITERAL | STRINGLITERAL | TRUE | FALSE | NULL )
				// Java.g:
				{
					root_0 = (object)adaptor.GetNilNode();

					set591 = (IToken)input.LT(1);
					if ( (input.LA(1) >= INTLITERAL && input.LA(1) <= NULL) ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set591, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 102, literal_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "literal"

		public class classHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "classHeader"
		// Java.g:1465:1: classHeader : modifiers 'class' IDENTIFIER ;
		public JavaParser.classHeader_return classHeader() // throws RecognitionException [1]
		{   
			JavaParser.classHeader_return retval = new JavaParser.classHeader_return();
			retval.Start = input.LT(1);
			int classHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal593 = null;
			IToken IDENTIFIER594 = null;
			JavaParser.modifiers_return modifiers592 = default(JavaParser.modifiers_return);


			object string_literal593_tree=null;
			object IDENTIFIER594_tree=null;

			const string elementName = "classHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 103) ) 
				{
					return retval; 
				}
				// Java.g:1472:5: ( modifiers 'class' IDENTIFIER )
				// Java.g:1472:9: modifiers 'class' IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_classHeader8813);
					modifiers592 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers592.Tree, modifiers592, retval);
					string_literal593=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_classHeader8815); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal593_tree = (object)adaptor.Create(string_literal593, retval);
						adaptor.AddChild(root_0, string_literal593_tree);
					}
					IDENTIFIER594=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_classHeader8817); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER594_tree = (object)adaptor.Create(IDENTIFIER594, retval);
						adaptor.AddChild(root_0, IDENTIFIER594_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 103, classHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "classHeader"

		public class enumHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "enumHeader"
		// Java.g:1475:1: enumHeader : modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER ;
		public JavaParser.enumHeader_return enumHeader() // throws RecognitionException [1]
		{   
			JavaParser.enumHeader_return retval = new JavaParser.enumHeader_return();
			retval.Start = input.LT(1);
			int enumHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken set596 = null;
			IToken IDENTIFIER597 = null;
			JavaParser.modifiers_return modifiers595 = default(JavaParser.modifiers_return);


			object set596_tree=null;
			object IDENTIFIER597_tree=null;

			const string elementName = "enumHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 104) ) 
				{
					return retval; 
				}
				// Java.g:1478:5: ( modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER )
				// Java.g:1478:9: modifiers ( 'enum' | IDENTIFIER ) IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_enumHeader8846);
					modifiers595 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers595.Tree, modifiers595, retval);
					set596 = (IToken)input.LT(1);
					if ( input.LA(1) == IDENTIFIER || input.LA(1) == ENUM ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set596, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}

					IDENTIFIER597=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enumHeader8854); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER597_tree = (object)adaptor.Create(IDENTIFIER597, retval);
						adaptor.AddChild(root_0, IDENTIFIER597_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 104, enumHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "enumHeader"

		public class interfaceHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "interfaceHeader"
		// Java.g:1481:1: interfaceHeader : modifiers 'interface' IDENTIFIER ;
		public JavaParser.interfaceHeader_return interfaceHeader() // throws RecognitionException [1]
		{   
			JavaParser.interfaceHeader_return retval = new JavaParser.interfaceHeader_return();
			retval.Start = input.LT(1);
			int interfaceHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal599 = null;
			IToken IDENTIFIER600 = null;
			JavaParser.modifiers_return modifiers598 = default(JavaParser.modifiers_return);


			object string_literal599_tree=null;
			object IDENTIFIER600_tree=null;

			const string elementName = "interfaceHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 105) ) 
				{
					return retval; 
				}
				// Java.g:1484:5: ( modifiers 'interface' IDENTIFIER )
				// Java.g:1484:9: modifiers 'interface' IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_interfaceHeader8883);
					modifiers598 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers598.Tree, modifiers598, retval);
					string_literal599=(IToken)Match(input,INTERFACE,FOLLOW_INTERFACE_in_interfaceHeader8885); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal599_tree = (object)adaptor.Create(string_literal599, retval);
						adaptor.AddChild(root_0, string_literal599_tree);
					}
					IDENTIFIER600=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_interfaceHeader8887); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER600_tree = (object)adaptor.Create(IDENTIFIER600, retval);
						adaptor.AddChild(root_0, IDENTIFIER600_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 105, interfaceHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "interfaceHeader"

		public class annotationHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "annotationHeader"
		// Java.g:1487:1: annotationHeader : modifiers '@' 'interface' IDENTIFIER ;
		public JavaParser.annotationHeader_return annotationHeader() // throws RecognitionException [1]
		{   
			JavaParser.annotationHeader_return retval = new JavaParser.annotationHeader_return();
			retval.Start = input.LT(1);
			int annotationHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken char_literal602 = null;
			IToken string_literal603 = null;
			IToken IDENTIFIER604 = null;
			JavaParser.modifiers_return modifiers601 = default(JavaParser.modifiers_return);


			object char_literal602_tree=null;
			object string_literal603_tree=null;
			object IDENTIFIER604_tree=null;

			const string elementName = "annotationHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 106) ) 
				{
					return retval; 
				}
				// Java.g:1490:5: ( modifiers '@' 'interface' IDENTIFIER )
				// Java.g:1490:9: modifiers '@' 'interface' IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_annotationHeader8916);
					modifiers601 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers601.Tree, modifiers601, retval);
					char_literal602=(IToken)Match(input,MONKEYS_AT,FOLLOW_MONKEYS_AT_in_annotationHeader8918); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal602_tree = (object)adaptor.Create(char_literal602, retval);
						adaptor.AddChild(root_0, char_literal602_tree);
					}
					string_literal603=(IToken)Match(input,INTERFACE,FOLLOW_INTERFACE_in_annotationHeader8920); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal603_tree = (object)adaptor.Create(string_literal603, retval);
						adaptor.AddChild(root_0, string_literal603_tree);
					}
					IDENTIFIER604=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_annotationHeader8922); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER604_tree = (object)adaptor.Create(IDENTIFIER604, retval);
						adaptor.AddChild(root_0, IDENTIFIER604_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 106, annotationHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "annotationHeader"

		public class typeHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "typeHeader"
		// Java.g:1493:1: typeHeader : modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER ;
		public JavaParser.typeHeader_return typeHeader() // throws RecognitionException [1]
		{   
			JavaParser.typeHeader_return retval = new JavaParser.typeHeader_return();
			retval.Start = input.LT(1);
			int typeHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal606 = null;
			IToken string_literal607 = null;
			IToken char_literal608 = null;
			IToken string_literal609 = null;
			IToken IDENTIFIER610 = null;
			JavaParser.modifiers_return modifiers605 = default(JavaParser.modifiers_return);


			object string_literal606_tree=null;
			object string_literal607_tree=null;
			object char_literal608_tree=null;
			object string_literal609_tree=null;
			object IDENTIFIER610_tree=null;

			const string elementName = "typeHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 107) ) 
				{
					return retval; 
				}
				// Java.g:1496:5: ( modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER )
				// Java.g:1496:9: modifiers ( 'class' | 'enum' | ( ( '@' )? 'interface' ) ) IDENTIFIER
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_typeHeader8951);
					modifiers605 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers605.Tree, modifiers605, retval);
					// Java.g:1496:19: ( 'class' | 'enum' | ( ( '@' )? 'interface' ) )
					int alt161 = 3;
					switch ( input.LA(1) ) 
					{
					case CLASS:
					{
						alt161 = 1;
					}
						break;
					case ENUM:
					{
						alt161 = 2;
					}
						break;
					case INTERFACE:
					case MONKEYS_AT:
					{
						alt161 = 3;
					}
						break;
					default:
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d161s0 =
							new NoViableAltException("", 161, 0, input);

						throw nvae_d161s0;
					}

					switch (alt161) 
					{
					case 1 :
						// Java.g:1496:20: 'class'
					{
						string_literal606=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_typeHeader8954); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal606_tree = (object)adaptor.Create(string_literal606, retval);
							adaptor.AddChild(root_0, string_literal606_tree);
						}

					}
						break;
					case 2 :
						// Java.g:1496:28: 'enum'
					{
						string_literal607=(IToken)Match(input,ENUM,FOLLOW_ENUM_in_typeHeader8956); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal607_tree = (object)adaptor.Create(string_literal607, retval);
							adaptor.AddChild(root_0, string_literal607_tree);
						}

					}
						break;
					case 3 :
						// Java.g:1496:35: ( ( '@' )? 'interface' )
					{
						// Java.g:1496:35: ( ( '@' )? 'interface' )
						// Java.g:1496:36: ( '@' )? 'interface'
						{
							// Java.g:1496:36: ( '@' )?
							int alt160 = 2;
							int LA160_0 = input.LA(1);

							if ( (LA160_0 == MONKEYS_AT) )
							{
								alt160 = 1;
							}
							switch (alt160) 
							{
							case 1 :
								// Java.g:0:0: '@'
							{
								char_literal608=(IToken)Match(input,MONKEYS_AT,FOLLOW_MONKEYS_AT_in_typeHeader8959); if (state.failed) return retval;
								if ( state.backtracking == 0 )
								{char_literal608_tree = (object)adaptor.Create(char_literal608, retval);
									adaptor.AddChild(root_0, char_literal608_tree);
								}

							}
								break;

							}

							string_literal609=(IToken)Match(input,INTERFACE,FOLLOW_INTERFACE_in_typeHeader8963); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{string_literal609_tree = (object)adaptor.Create(string_literal609, retval);
								adaptor.AddChild(root_0, string_literal609_tree);
							}

						}


					}
						break;

					}

					IDENTIFIER610=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_typeHeader8967); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER610_tree = (object)adaptor.Create(IDENTIFIER610, retval);
						adaptor.AddChild(root_0, IDENTIFIER610_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 107, typeHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "typeHeader"

		public class methodHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "methodHeader"
		// Java.g:1499:1: methodHeader : modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '(' ;
		public JavaParser.methodHeader_return methodHeader() // throws RecognitionException [1]
		{   
			JavaParser.methodHeader_return retval = new JavaParser.methodHeader_return();
			retval.Start = input.LT(1);
			int methodHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken string_literal614 = null;
			IToken IDENTIFIER615 = null;
			IToken char_literal616 = null;
			JavaParser.modifiers_return modifiers611 = default(JavaParser.modifiers_return);

			JavaParser.typeParameters_return typeParameters612 = default(JavaParser.typeParameters_return);

			JavaParser.type_return type613 = default(JavaParser.type_return);


			object string_literal614_tree=null;
			object IDENTIFIER615_tree=null;
			object char_literal616_tree=null;

			const string elementName = "methodHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 108) ) 
				{
					return retval; 
				}
				// Java.g:1502:5: ( modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '(' )
				// Java.g:1502:9: modifiers ( typeParameters )? ( type | 'void' )? IDENTIFIER '('
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_methodHeader8996);
					modifiers611 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers611.Tree, modifiers611, retval);
					// Java.g:1502:19: ( typeParameters )?
					int alt162 = 2;
					int LA162_0 = input.LA(1);

					if ( (LA162_0 == LT) )
					{
						alt162 = 1;
					}
					switch (alt162) 
					{
					case 1 :
						// Java.g:0:0: typeParameters
					{
						PushFollow(FOLLOW_typeParameters_in_methodHeader8998);
						typeParameters612 = typeParameters();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, typeParameters612.Tree, typeParameters612, retval);

					}
						break;

					}

					// Java.g:1502:35: ( type | 'void' )?
					int alt163 = 3;
					switch ( input.LA(1) ) 
					{
					case IDENTIFIER:
					{
						int LA163_1 = input.LA(2);

						if ( (LA163_1 == IDENTIFIER || LA163_1 == LBRACKET || LA163_1 == DOT || LA163_1 == LT) )
						{
							alt163 = 1;
						}
					}
						break;
					case BOOLEAN:
					case BYTE:
					case CHAR:
					case DOUBLE:
					case FLOAT:
					case INT:
					case LONG:
					case SHORT:
					{
						alt163 = 1;
					}
						break;
					case VOID:
					{
						alt163 = 2;
					}
						break;
					}

					switch (alt163) 
					{
					case 1 :
						// Java.g:1502:36: type
					{
						PushFollow(FOLLOW_type_in_methodHeader9002);
						type613 = type();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type613.Tree, type613, retval);

					}
						break;
					case 2 :
						// Java.g:1502:41: 'void'
					{
						string_literal614=(IToken)Match(input,VOID,FOLLOW_VOID_in_methodHeader9004); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal614_tree = (object)adaptor.Create(string_literal614, retval);
							adaptor.AddChild(root_0, string_literal614_tree);
						}

					}
						break;

					}

					IDENTIFIER615=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_methodHeader9008); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER615_tree = (object)adaptor.Create(IDENTIFIER615, retval);
						adaptor.AddChild(root_0, IDENTIFIER615_tree);
					}
					char_literal616=(IToken)Match(input,LPAREN,FOLLOW_LPAREN_in_methodHeader9010); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal616_tree = (object)adaptor.Create(char_literal616, retval);
						adaptor.AddChild(root_0, char_literal616_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 108, methodHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "methodHeader"

		public class fieldHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "fieldHeader"
		// Java.g:1505:1: fieldHeader : modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) ;
		public JavaParser.fieldHeader_return fieldHeader() // throws RecognitionException [1]
		{   
			JavaParser.fieldHeader_return retval = new JavaParser.fieldHeader_return();
			retval.Start = input.LT(1);
			int fieldHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER619 = null;
			IToken char_literal620 = null;
			IToken char_literal621 = null;
			IToken set622 = null;
			JavaParser.modifiers_return modifiers617 = default(JavaParser.modifiers_return);

			JavaParser.type_return type618 = default(JavaParser.type_return);


			object IDENTIFIER619_tree=null;
			object char_literal620_tree=null;
			object char_literal621_tree=null;
			object set622_tree=null;

			const string elementName = "fieldHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 109) ) 
				{
					return retval; 
				}
				// Java.g:1508:5: ( modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) )
				// Java.g:1508:9: modifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' )
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_modifiers_in_fieldHeader9039);
					modifiers617 = modifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, modifiers617.Tree, modifiers617, retval);
					PushFollow(FOLLOW_type_in_fieldHeader9041);
					type618 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type618.Tree, type618, retval);
					IDENTIFIER619=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_fieldHeader9043); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER619_tree = (object)adaptor.Create(IDENTIFIER619, retval);
						adaptor.AddChild(root_0, IDENTIFIER619_tree);
					}
					// Java.g:1508:35: ( '[' ']' )*
					do 
					{
						int alt164 = 2;
						int LA164_0 = input.LA(1);

						if ( (LA164_0 == LBRACKET) )
						{
							alt164 = 1;
						}


						switch (alt164) 
						{
						case 1 :
							// Java.g:1508:36: '[' ']'
						{
							char_literal620=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_fieldHeader9046); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal620_tree = (object)adaptor.Create(char_literal620, retval);
								adaptor.AddChild(root_0, char_literal620_tree);
							}
							char_literal621=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_fieldHeader9047); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal621_tree = (object)adaptor.Create(char_literal621, retval);
								adaptor.AddChild(root_0, char_literal621_tree);
							}

						}
							break;

						default:
							goto loop164;
						}
					} while (true);

					loop164:
					;	// Stops C# compiler whining that label 'loop164' has no statements

					set622 = (IToken)input.LT(1);
					if ( (input.LA(1) >= SEMI && input.LA(1) <= COMMA) || input.LA(1) == EQ ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set622, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 109, fieldHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "fieldHeader"

		public class localVariableHeader_return : XParserRuleReturnScope
		{
			private object tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (object) value; }
			}
		};

		// $ANTLR start "localVariableHeader"
		// Java.g:1511:1: localVariableHeader : variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) ;
		public JavaParser.localVariableHeader_return localVariableHeader() // throws RecognitionException [1]
		{   
			JavaParser.localVariableHeader_return retval = new JavaParser.localVariableHeader_return();
			retval.Start = input.LT(1);
			int localVariableHeader_StartIndex = input.Index();
			object root_0 = null;

			IToken IDENTIFIER625 = null;
			IToken char_literal626 = null;
			IToken char_literal627 = null;
			IToken set628 = null;
			JavaParser.variableModifiers_return variableModifiers623 = default(JavaParser.variableModifiers_return);

			JavaParser.type_return type624 = default(JavaParser.type_return);


			object IDENTIFIER625_tree=null;
			object char_literal626_tree=null;
			object char_literal627_tree=null;
			object set628_tree=null;

			const string elementName = "localVariableHeader"; var elementsIndex = Elements.Count; Elements.Add(null); 
			try 
			{
				if ( (state.backtracking > 0) && AlreadyParsedRule(input, 110) ) 
				{
					return retval; 
				}
				// Java.g:1514:5: ( variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' ) )
				// Java.g:1514:9: variableModifiers type IDENTIFIER ( '[' ']' )* ( '=' | ',' | ';' )
				{
					root_0 = (object)adaptor.GetNilNode();

					PushFollow(FOLLOW_variableModifiers_in_localVariableHeader9086);
					variableModifiers623 = variableModifiers();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableModifiers623.Tree, variableModifiers623, retval);
					PushFollow(FOLLOW_type_in_localVariableHeader9088);
					type624 = type();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type624.Tree, type624, retval);
					IDENTIFIER625=(IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_localVariableHeader9090); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{IDENTIFIER625_tree = (object)adaptor.Create(IDENTIFIER625, retval);
						adaptor.AddChild(root_0, IDENTIFIER625_tree);
					}
					// Java.g:1514:43: ( '[' ']' )*
					do 
					{
						int alt165 = 2;
						int LA165_0 = input.LA(1);

						if ( (LA165_0 == LBRACKET) )
						{
							alt165 = 1;
						}


						switch (alt165) 
						{
						case 1 :
							// Java.g:1514:44: '[' ']'
						{
							char_literal626=(IToken)Match(input,LBRACKET,FOLLOW_LBRACKET_in_localVariableHeader9093); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal626_tree = (object)adaptor.Create(char_literal626, retval);
								adaptor.AddChild(root_0, char_literal626_tree);
							}
							char_literal627=(IToken)Match(input,RBRACKET,FOLLOW_RBRACKET_in_localVariableHeader9094); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal627_tree = (object)adaptor.Create(char_literal627, retval);
								adaptor.AddChild(root_0, char_literal627_tree);
							}

						}
							break;

						default:
							goto loop165;
						}
					} while (true);

					loop165:
					;	// Stops C# compiler whining that label 'loop165' has no statements

					set628 = (IToken)input.LT(1);
					if ( (input.LA(1) >= SEMI && input.LA(1) <= COMMA) || input.LA(1) == EQ ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set628, retval));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{
					Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				if ( state.backtracking > 0 ) 
				{
					Memoize(input, 110, localVariableHeader_StartIndex); 
				}
			}
			return retval;
		}
		// $ANTLR end "localVariableHeader"

		// $ANTLR start "synpred2_Java"
		public void synpred2_Java_fragment() {
			// Java.g:317:13: ( ( annotations )? packageDeclaration )
			// Java.g:317:13: ( annotations )? packageDeclaration
			{
				// Java.g:317:13: ( annotations )?
				int alt166 = 2;
				int LA166_0 = input.LA(1);

				if ( (LA166_0 == MONKEYS_AT) )
				{
					alt166 = 1;
				}
				switch (alt166) 
				{
				case 1 :
					// Java.g:317:14: annotations
				{
					PushFollow(FOLLOW_annotations_in_synpred2_Java121);
					annotations();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				PushFollow(FOLLOW_packageDeclaration_in_synpred2_Java150);
				packageDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred2_Java"

		// $ANTLR start "synpred12_Java"
		public void synpred12_Java_fragment() {
			// Java.g:371:10: ( classDeclaration )
			// Java.g:371:10: classDeclaration
			{
				PushFollow(FOLLOW_classDeclaration_in_synpred12_Java552);
				classDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred12_Java"

		// $ANTLR start "synpred27_Java"
		public void synpred27_Java_fragment() {
			// Java.g:408:9: ( normalClassDeclaration )
			// Java.g:408:9: normalClassDeclaration
			{
				PushFollow(FOLLOW_normalClassDeclaration_in_synpred27_Java815);
				normalClassDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred27_Java"

		// $ANTLR start "synpred43_Java"
		public void synpred43_Java_fragment() {
			// Java.g:516:9: ( normalInterfaceDeclaration )
			// Java.g:516:9: normalInterfaceDeclaration
			{
				PushFollow(FOLLOW_normalInterfaceDeclaration_in_synpred43_Java1584);
				normalInterfaceDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred43_Java"

		// $ANTLR start "synpred52_Java"
		public void synpred52_Java_fragment() {
			// Java.g:570:10: ( fieldDeclaration )
			// Java.g:570:10: fieldDeclaration
			{
				PushFollow(FOLLOW_fieldDeclaration_in_synpred52_Java1968);
				fieldDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred52_Java"

		// $ANTLR start "synpred53_Java"
		public void synpred53_Java_fragment() {
			// Java.g:571:10: ( methodDeclaration )
			// Java.g:571:10: methodDeclaration
			{
				PushFollow(FOLLOW_methodDeclaration_in_synpred53_Java1979);
				methodDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred53_Java"

		// $ANTLR start "synpred54_Java"
		public void synpred54_Java_fragment() {
			// Java.g:572:10: ( classDeclaration )
			// Java.g:572:10: classDeclaration
			{
				PushFollow(FOLLOW_classDeclaration_in_synpred54_Java1990);
				classDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred54_Java"

		// $ANTLR start "synpred57_Java"
		public void synpred57_Java_fragment() {
			// Java.g:590:10: ( explicitConstructorInvocation )
			// Java.g:590:10: explicitConstructorInvocation
			{
				PushFollow(FOLLOW_explicitConstructorInvocation_in_synpred57_Java2136);
				explicitConstructorInvocation();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred57_Java"

		// $ANTLR start "synpred59_Java"
		public void synpred59_Java_fragment() {
			// Java.g:582:10: ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' )
			// Java.g:582:10: modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}'
			{
				PushFollow(FOLLOW_modifiers_in_synpred59_Java2048);
				modifiers();
				state.followingStackPointer--;
				if (state.failed) return ;
				// Java.g:583:9: ( typeParameters )?
				int alt169 = 2;
				int LA169_0 = input.LA(1);

				if ( (LA169_0 == LT) )
				{
					alt169 = 1;
				}
				switch (alt169) 
				{
				case 1 :
					// Java.g:583:10: typeParameters
				{
					PushFollow(FOLLOW_typeParameters_in_synpred59_Java2059);
					typeParameters();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred59_Java2080); if (state.failed) return ;
				PushFollow(FOLLOW_formalParameters_in_synpred59_Java2090);
				formalParameters();
				state.followingStackPointer--;
				if (state.failed) return ;
				// Java.g:587:9: ( 'throws' qualifiedNameList )?
				int alt170 = 2;
				int LA170_0 = input.LA(1);

				if ( (LA170_0 == THROWS) )
				{
					alt170 = 1;
				}
				switch (alt170) 
				{
				case 1 :
					// Java.g:587:10: 'throws' qualifiedNameList
				{
					Match(input,THROWS,FOLLOW_THROWS_in_synpred59_Java2101); if (state.failed) return ;
					PushFollow(FOLLOW_qualifiedNameList_in_synpred59_Java2103);
					qualifiedNameList();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				Match(input,LBRACE,FOLLOW_LBRACE_in_synpred59_Java2124); if (state.failed) return ;
				// Java.g:590:9: ( explicitConstructorInvocation )?
				int alt171 = 2;
				alt171 = dfa171.Predict(input);
				switch (alt171) 
				{
				case 1 :
					// Java.g:590:10: explicitConstructorInvocation
				{
					PushFollow(FOLLOW_explicitConstructorInvocation_in_synpred59_Java2136);
					explicitConstructorInvocation();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				// Java.g:592:9: ( blockStatement )*
				do 
				{
					int alt172 = 2;
					int LA172_0 = input.LA(1);

					if ( ((LA172_0 >= IDENTIFIER && LA172_0 <= NULL) || (LA172_0 >= ABSTRACT && LA172_0 <= BYTE) || (LA172_0 >= CHAR && LA172_0 <= CLASS) || LA172_0 == CONTINUE || (LA172_0 >= DO && LA172_0 <= DOUBLE) || LA172_0 == ENUM || LA172_0 == FINAL || (LA172_0 >= FLOAT && LA172_0 <= FOR) || LA172_0 == IF || (LA172_0 >= INT && LA172_0 <= NEW) || (LA172_0 >= PRIVATE && LA172_0 <= THROW) || (LA172_0 >= TRANSIENT && LA172_0 <= LPAREN) || LA172_0 == LBRACE || LA172_0 == SEMI || (LA172_0 >= BANG && LA172_0 <= TILDE) || (LA172_0 >= PLUSPLUS && LA172_0 <= SUB) || LA172_0 == MONKEYS_AT || LA172_0 == LT) )
					{
						alt172 = 1;
					}


					switch (alt172) 
					{
					case 1 :
						// Java.g:592:10: blockStatement
					{
						PushFollow(FOLLOW_blockStatement_in_synpred59_Java2158);
						blockStatement();
						state.followingStackPointer--;
						if (state.failed) return ;

					}
						break;

					default:
						goto loop172;
					}
				} while (true);

				loop172:
				;	// Stops C# compiler whining that label 'loop172' has no statements

				Match(input,RBRACE,FOLLOW_RBRACE_in_synpred59_Java2179); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred59_Java"

		// $ANTLR start "synpred68_Java"
		public void synpred68_Java_fragment() {
			// Java.g:642:9: ( interfaceFieldDeclaration )
			// Java.g:642:9: interfaceFieldDeclaration
			{
				PushFollow(FOLLOW_interfaceFieldDeclaration_in_synpred68_Java2581);
				interfaceFieldDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred68_Java"

		// $ANTLR start "synpred69_Java"
		public void synpred69_Java_fragment() {
			// Java.g:643:9: ( interfaceMethodDeclaration )
			// Java.g:643:9: interfaceMethodDeclaration
			{
				PushFollow(FOLLOW_interfaceMethodDeclaration_in_synpred69_Java2591);
				interfaceMethodDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred69_Java"

		// $ANTLR start "synpred70_Java"
		public void synpred70_Java_fragment() {
			// Java.g:644:9: ( interfaceDeclaration )
			// Java.g:644:9: interfaceDeclaration
			{
				PushFollow(FOLLOW_interfaceDeclaration_in_synpred70_Java2601);
				interfaceDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred70_Java"

		// $ANTLR start "synpred71_Java"
		public void synpred71_Java_fragment() {
			// Java.g:645:9: ( classDeclaration )
			// Java.g:645:9: classDeclaration
			{
				PushFollow(FOLLOW_classDeclaration_in_synpred71_Java2611);
				classDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred71_Java"

		// $ANTLR start "synpred96_Java"
		public void synpred96_Java_fragment() {
			// Java.g:760:9: ( ellipsisParameterDecl )
			// Java.g:760:9: ellipsisParameterDecl
			{
				PushFollow(FOLLOW_ellipsisParameterDecl_in_synpred96_Java3464);
				ellipsisParameterDecl();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred96_Java"

		// $ANTLR start "synpred98_Java"
		public void synpred98_Java_fragment() {
			// Java.g:761:9: ( normalParameterDecl ( ',' normalParameterDecl )* )
			// Java.g:761:9: normalParameterDecl ( ',' normalParameterDecl )*
			{
				PushFollow(FOLLOW_normalParameterDecl_in_synpred98_Java3474);
				normalParameterDecl();
				state.followingStackPointer--;
				if (state.failed) return ;
				// Java.g:762:9: ( ',' normalParameterDecl )*
				do 
				{
					int alt175 = 2;
					int LA175_0 = input.LA(1);

					if ( (LA175_0 == COMMA) )
					{
						alt175 = 1;
					}


					switch (alt175) 
					{
					case 1 :
						// Java.g:762:10: ',' normalParameterDecl
					{
						Match(input,COMMA,FOLLOW_COMMA_in_synpred98_Java3485); if (state.failed) return ;
						PushFollow(FOLLOW_normalParameterDecl_in_synpred98_Java3487);
						normalParameterDecl();
						state.followingStackPointer--;
						if (state.failed) return ;

					}
						break;

					default:
						goto loop175;
					}
				} while (true);

				loop175:
				;	// Stops C# compiler whining that label 'loop175' has no statements


			}
		}
		// $ANTLR end "synpred98_Java"

		// $ANTLR start "synpred99_Java"
		public void synpred99_Java_fragment() {
			// Java.g:764:10: ( normalParameterDecl ',' )
			// Java.g:764:10: normalParameterDecl ','
			{
				PushFollow(FOLLOW_normalParameterDecl_in_synpred99_Java3509);
				normalParameterDecl();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,COMMA,FOLLOW_COMMA_in_synpred99_Java3519); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred99_Java"

		// $ANTLR start "synpred103_Java"
		public void synpred103_Java_fragment() {
			// Java.g:790:9: ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' )
			// Java.g:790:9: ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';'
			{
				// Java.g:790:9: ( nonWildcardTypeArguments )?
				int alt176 = 2;
				int LA176_0 = input.LA(1);

				if ( (LA176_0 == LT) )
				{
					alt176 = 1;
				}
				switch (alt176) 
				{
				case 1 :
					// Java.g:790:10: nonWildcardTypeArguments
				{
					PushFollow(FOLLOW_nonWildcardTypeArguments_in_synpred103_Java3681);
					nonWildcardTypeArguments();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				if ( input.LA(1) == SUPER || input.LA(1) == THIS ) 
				{
					input.Consume();
					state.errorRecovery = false;state.failed = false;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return ;}
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				PushFollow(FOLLOW_arguments_in_synpred103_Java3739);
				arguments();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,SEMI,FOLLOW_SEMI_in_synpred103_Java3741); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred103_Java"

		// $ANTLR start "synpred117_Java"
		public void synpred117_Java_fragment() {
			// Java.g:897:9: ( annotationMethodDeclaration )
			// Java.g:897:9: annotationMethodDeclaration
			{
				PushFollow(FOLLOW_annotationMethodDeclaration_in_synpred117_Java4430);
				annotationMethodDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred117_Java"

		// $ANTLR start "synpred118_Java"
		public void synpred118_Java_fragment() {
			// Java.g:898:9: ( interfaceFieldDeclaration )
			// Java.g:898:9: interfaceFieldDeclaration
			{
				PushFollow(FOLLOW_interfaceFieldDeclaration_in_synpred118_Java4440);
				interfaceFieldDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred118_Java"

		// $ANTLR start "synpred119_Java"
		public void synpred119_Java_fragment() {
			// Java.g:899:9: ( normalClassDeclaration )
			// Java.g:899:9: normalClassDeclaration
			{
				PushFollow(FOLLOW_normalClassDeclaration_in_synpred119_Java4450);
				normalClassDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred119_Java"

		// $ANTLR start "synpred120_Java"
		public void synpred120_Java_fragment() {
			// Java.g:900:9: ( normalInterfaceDeclaration )
			// Java.g:900:9: normalInterfaceDeclaration
			{
				PushFollow(FOLLOW_normalInterfaceDeclaration_in_synpred120_Java4460);
				normalInterfaceDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred120_Java"

		// $ANTLR start "synpred121_Java"
		public void synpred121_Java_fragment() {
			// Java.g:901:9: ( enumDeclaration )
			// Java.g:901:9: enumDeclaration
			{
				PushFollow(FOLLOW_enumDeclaration_in_synpred121_Java4470);
				enumDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred121_Java"

		// $ANTLR start "synpred122_Java"
		public void synpred122_Java_fragment() {
			// Java.g:902:9: ( annotationTypeDeclaration )
			// Java.g:902:9: annotationTypeDeclaration
			{
				PushFollow(FOLLOW_annotationTypeDeclaration_in_synpred122_Java4480);
				annotationTypeDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred122_Java"

		// $ANTLR start "synpred125_Java"
		public void synpred125_Java_fragment() {
			// Java.g:951:9: ( localVariableDeclarationStatement )
			// Java.g:951:9: localVariableDeclarationStatement
			{
				PushFollow(FOLLOW_localVariableDeclarationStatement_in_synpred125_Java4665);
				localVariableDeclarationStatement();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred125_Java"

		// $ANTLR start "synpred126_Java"
		public void synpred126_Java_fragment() {
			// Java.g:952:9: ( classOrInterfaceDeclaration )
			// Java.g:952:9: classOrInterfaceDeclaration
			{
				PushFollow(FOLLOW_classOrInterfaceDeclaration_in_synpred126_Java4675);
				classOrInterfaceDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred126_Java"

		// $ANTLR start "synpred130_Java"
		public void synpred130_Java_fragment() {
			// Java.g:978:9: ( ( 'assert' ) expression ( ':' expression )? ';' )
			// Java.g:978:9: ( 'assert' ) expression ( ':' expression )? ';'
			{
				// Java.g:978:9: ( 'assert' )
				// Java.g:978:10: 'assert'
				{
					Match(input,ASSERT,FOLLOW_ASSERT_in_synpred130_Java4843); if (state.failed) return ;

				}

				PushFollow(FOLLOW_expression_in_synpred130_Java4863);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				// Java.g:980:20: ( ':' expression )?
				int alt179 = 2;
				int LA179_0 = input.LA(1);

				if ( (LA179_0 == COLON) )
				{
					alt179 = 1;
				}
				switch (alt179) 
				{
				case 1 :
					// Java.g:980:21: ':' expression
				{
					Match(input,COLON,FOLLOW_COLON_in_synpred130_Java4866); if (state.failed) return ;
					PushFollow(FOLLOW_expression_in_synpred130_Java4868);
					expression();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				Match(input,SEMI,FOLLOW_SEMI_in_synpred130_Java4872); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred130_Java"

		// $ANTLR start "synpred132_Java"
		public void synpred132_Java_fragment() {
			// Java.g:981:9: ( 'assert' expression ( ':' expression )? ';' )
			// Java.g:981:9: 'assert' expression ( ':' expression )? ';'
			{
				Match(input,ASSERT,FOLLOW_ASSERT_in_synpred132_Java4882); if (state.failed) return ;
				PushFollow(FOLLOW_expression_in_synpred132_Java4885);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				// Java.g:981:30: ( ':' expression )?
				int alt180 = 2;
				int LA180_0 = input.LA(1);

				if ( (LA180_0 == COLON) )
				{
					alt180 = 1;
				}
				switch (alt180) 
				{
				case 1 :
					// Java.g:981:31: ':' expression
				{
					Match(input,COLON,FOLLOW_COLON_in_synpred132_Java4888); if (state.failed) return ;
					PushFollow(FOLLOW_expression_in_synpred132_Java4890);
					expression();
					state.followingStackPointer--;
					if (state.failed) return ;

				}
					break;

				}

				Match(input,SEMI,FOLLOW_SEMI_in_synpred132_Java4894); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred132_Java"

		// $ANTLR start "synpred133_Java"
		public void synpred133_Java_fragment() {
			// Java.g:982:39: ( 'else' statement )
			// Java.g:982:39: 'else' statement
			{
				Match(input,ELSE,FOLLOW_ELSE_in_synpred133_Java4923); if (state.failed) return ;
				PushFollow(FOLLOW_statement_in_synpred133_Java4925);
				statement();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred133_Java"

		// $ANTLR start "synpred148_Java"
		public void synpred148_Java_fragment() {
			// Java.g:997:9: ( expression ';' )
			// Java.g:997:9: expression ';'
			{
				PushFollow(FOLLOW_expression_in_synpred148_Java5147);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,SEMI,FOLLOW_SEMI_in_synpred148_Java5150); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred148_Java"

		// $ANTLR start "synpred149_Java"
		public void synpred149_Java_fragment() {
			// Java.g:998:9: ( IDENTIFIER ':' statement )
			// Java.g:998:9: IDENTIFIER ':' statement
			{
				Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred149_Java5165); if (state.failed) return ;
				Match(input,COLON,FOLLOW_COLON_in_synpred149_Java5167); if (state.failed) return ;
				PushFollow(FOLLOW_statement_in_synpred149_Java5169);
				statement();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred149_Java"

		// $ANTLR start "synpred153_Java"
		public void synpred153_Java_fragment() {
			// Java.g:1030:13: ( catches 'finally' block )
			// Java.g:1030:13: catches 'finally' block
			{
				PushFollow(FOLLOW_catches_in_synpred153_Java5361);
				catches();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,FINALLY,FOLLOW_FINALLY_in_synpred153_Java5363); if (state.failed) return ;
				PushFollow(FOLLOW_block_in_synpred153_Java5365);
				block();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred153_Java"

		// $ANTLR start "synpred154_Java"
		public void synpred154_Java_fragment() {
			// Java.g:1031:13: ( catches )
			// Java.g:1031:13: catches
			{
				PushFollow(FOLLOW_catches_in_synpred154_Java5379);
				catches();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred154_Java"

		// $ANTLR start "synpred157_Java"
		public void synpred157_Java_fragment() {
			// Java.g:1064:9: ( 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement )
			// Java.g:1064:9: 'for' '(' variableModifiers type IDENTIFIER ':' expression ')' statement
			{
				Match(input,FOR,FOLLOW_FOR_in_synpred157_Java5607); if (state.failed) return ;
				Match(input,LPAREN,FOLLOW_LPAREN_in_synpred157_Java5609); if (state.failed) return ;
				PushFollow(FOLLOW_variableModifiers_in_synpred157_Java5611);
				variableModifiers();
				state.followingStackPointer--;
				if (state.failed) return ;
				PushFollow(FOLLOW_type_in_synpred157_Java5613);
				type();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred157_Java5615); if (state.failed) return ;
				Match(input,COLON,FOLLOW_COLON_in_synpred157_Java5617); if (state.failed) return ;
				PushFollow(FOLLOW_expression_in_synpred157_Java5628);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,RPAREN,FOLLOW_RPAREN_in_synpred157_Java5630); if (state.failed) return ;
				PushFollow(FOLLOW_statement_in_synpred157_Java5632);
				statement();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred157_Java"

		// $ANTLR start "synpred161_Java"
		public void synpred161_Java_fragment() {
			// Java.g:1080:9: ( localVariableDeclaration )
			// Java.g:1080:9: localVariableDeclaration
			{
				PushFollow(FOLLOW_localVariableDeclaration_in_synpred161_Java5820);
				localVariableDeclaration();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred161_Java"

		// $ANTLR start "synpred202_Java"
		public void synpred202_Java_fragment() {
			// Java.g:1274:9: ( castExpression )
			// Java.g:1274:9: castExpression
			{
				PushFollow(FOLLOW_castExpression_in_synpred202_Java7245);
				castExpression();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred202_Java"

		// $ANTLR start "synpred206_Java"
		public void synpred206_Java_fragment() {
			// Java.g:1286:9: ( '(' primitiveType ')' unaryExpression )
			// Java.g:1286:9: '(' primitiveType ')' unaryExpression
			{
				Match(input,LPAREN,FOLLOW_LPAREN_in_synpred206_Java7345); if (state.failed) return ;
				PushFollow(FOLLOW_primitiveType_in_synpred206_Java7347);
				primitiveType();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,RPAREN,FOLLOW_RPAREN_in_synpred206_Java7349); if (state.failed) return ;
				PushFollow(FOLLOW_unaryExpression_in_synpred206_Java7351);
				unaryExpression();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred206_Java"

		// $ANTLR start "synpred208_Java"
		public void synpred208_Java_fragment() {
			// Java.g:1298:10: ( '.' IDENTIFIER )
			// Java.g:1298:10: '.' IDENTIFIER
			{
				Match(input,DOT,FOLLOW_DOT_in_synpred208_Java7431); if (state.failed) return ;
				Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred208_Java7433); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred208_Java"

		// $ANTLR start "synpred209_Java"
		public void synpred209_Java_fragment() {
			// Java.g:1300:10: ( identifierSuffix )
			// Java.g:1300:10: identifierSuffix
			{
				PushFollow(FOLLOW_identifierSuffix_in_synpred209_Java7455);
				identifierSuffix();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred209_Java"

		// $ANTLR start "synpred211_Java"
		public void synpred211_Java_fragment() {
			// Java.g:1303:10: ( '.' IDENTIFIER )
			// Java.g:1303:10: '.' IDENTIFIER
			{
				Match(input,DOT,FOLLOW_DOT_in_synpred211_Java7487); if (state.failed) return ;
				Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred211_Java7489); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred211_Java"

		// $ANTLR start "synpred212_Java"
		public void synpred212_Java_fragment() {
			// Java.g:1305:10: ( identifierSuffix )
			// Java.g:1305:10: identifierSuffix
			{
				PushFollow(FOLLOW_identifierSuffix_in_synpred212_Java7511);
				identifierSuffix();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred212_Java"

		// $ANTLR start "synpred224_Java"
		public void synpred224_Java_fragment() {
			// Java.g:1337:10: ( '[' expression ']' )
			// Java.g:1337:10: '[' expression ']'
			{
				Match(input,LBRACKET,FOLLOW_LBRACKET_in_synpred224_Java7779); if (state.failed) return ;
				PushFollow(FOLLOW_expression_in_synpred224_Java7781);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,RBRACKET,FOLLOW_RBRACKET_in_synpred224_Java7783); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred224_Java"

		// $ANTLR start "synpred236_Java"
		public void synpred236_Java_fragment() {
			// Java.g:1364:9: ( 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest )
			// Java.g:1364:9: 'new' nonWildcardTypeArguments classOrInterfaceType classCreatorRest
			{
				Match(input,NEW,FOLLOW_NEW_in_synpred236_Java8009); if (state.failed) return ;
				PushFollow(FOLLOW_nonWildcardTypeArguments_in_synpred236_Java8011);
				nonWildcardTypeArguments();
				state.followingStackPointer--;
				if (state.failed) return ;
				PushFollow(FOLLOW_classOrInterfaceType_in_synpred236_Java8013);
				classOrInterfaceType();
				state.followingStackPointer--;
				if (state.failed) return ;
				PushFollow(FOLLOW_classCreatorRest_in_synpred236_Java8015);
				classCreatorRest();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred236_Java"

		// $ANTLR start "synpred237_Java"
		public void synpred237_Java_fragment() {
			// Java.g:1365:9: ( 'new' classOrInterfaceType classCreatorRest )
			// Java.g:1365:9: 'new' classOrInterfaceType classCreatorRest
			{
				Match(input,NEW,FOLLOW_NEW_in_synpred237_Java8025); if (state.failed) return ;
				PushFollow(FOLLOW_classOrInterfaceType_in_synpred237_Java8027);
				classOrInterfaceType();
				state.followingStackPointer--;
				if (state.failed) return ;
				PushFollow(FOLLOW_classCreatorRest_in_synpred237_Java8029);
				classCreatorRest();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred237_Java"

		// $ANTLR start "synpred239_Java"
		public void synpred239_Java_fragment() {
			// Java.g:1372:9: ( 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer )
			// Java.g:1372:9: 'new' createdName '[' ']' ( '[' ']' )* arrayInitializer
			{
				Match(input,NEW,FOLLOW_NEW_in_synpred239_Java8068); if (state.failed) return ;
				PushFollow(FOLLOW_createdName_in_synpred239_Java8070);
				createdName();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,LBRACKET,FOLLOW_LBRACKET_in_synpred239_Java8080); if (state.failed) return ;
				Match(input,RBRACKET,FOLLOW_RBRACKET_in_synpred239_Java8082); if (state.failed) return ;
				// Java.g:1374:9: ( '[' ']' )*
				do 
				{
					int alt193 = 2;
					int LA193_0 = input.LA(1);

					if ( (LA193_0 == LBRACKET) )
					{
						alt193 = 1;
					}


					switch (alt193) 
					{
					case 1 :
						// Java.g:1374:10: '[' ']'
					{
						Match(input,LBRACKET,FOLLOW_LBRACKET_in_synpred239_Java8093); if (state.failed) return ;
						Match(input,RBRACKET,FOLLOW_RBRACKET_in_synpred239_Java8095); if (state.failed) return ;

					}
						break;

					default:
						goto loop193;
					}
				} while (true);

				loop193:
				;	// Stops C# compiler whining that label 'loop193' has no statements

				PushFollow(FOLLOW_arrayInitializer_in_synpred239_Java8116);
				arrayInitializer();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred239_Java"

		// $ANTLR start "synpred240_Java"
		public void synpred240_Java_fragment() {
			// Java.g:1381:13: ( '[' expression ']' )
			// Java.g:1381:13: '[' expression ']'
			{
				Match(input,LBRACKET,FOLLOW_LBRACKET_in_synpred240_Java8165); if (state.failed) return ;
				PushFollow(FOLLOW_expression_in_synpred240_Java8167);
				expression();
				state.followingStackPointer--;
				if (state.failed) return ;
				Match(input,RBRACKET,FOLLOW_RBRACKET_in_synpred240_Java8181); if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred240_Java"

		// Delegated rules

		public bool synpred43_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred43_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred98_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred98_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred157_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred157_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred224_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred224_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred211_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred211_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred121_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred121_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred239_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred239_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred69_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred69_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred202_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred202_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred154_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred154_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred71_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred71_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred133_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred133_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred125_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred125_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred132_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred132_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred119_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred119_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred54_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred54_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred148_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred148_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred117_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred117_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred2_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred2_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred130_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred130_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred126_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred126_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred59_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred59_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred212_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred212_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred161_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred161_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred57_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred57_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred209_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred209_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred68_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred68_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred53_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred53_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred52_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred52_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred236_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred236_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred12_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred12_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred149_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred149_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred120_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred120_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred122_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred122_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred240_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred240_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred206_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred206_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred70_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred70_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred27_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred27_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred96_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred96_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred153_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred153_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred99_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred99_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred103_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred103_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred237_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred237_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred118_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred118_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred208_Java() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred208_Java_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}


		protected DFA2 dfa2;
		protected DFA12 dfa12;
		protected DFA13 dfa13;
		protected DFA15 dfa15;
		protected DFA31 dfa31;
		protected DFA39 dfa39;
		protected DFA49 dfa49;
		protected DFA42 dfa42;
		protected DFA53 dfa53;
		protected DFA76 dfa76;
		protected DFA87 dfa87;
		protected DFA90 dfa90;
		protected DFA98 dfa98;
		protected DFA109 dfa109;
		protected DFA112 dfa112;
		protected DFA130 dfa130;
		protected DFA133 dfa133;
		protected DFA135 dfa135;
		protected DFA143 dfa143;
		protected DFA142 dfa142;
		protected DFA148 dfa148;
		protected DFA171 dfa171;
		private void InitializeCyclicDFAs()
		{
			this.dfa2 = new DFA2(this);
			this.dfa12 = new DFA12(this);
			this.dfa13 = new DFA13(this);
			this.dfa15 = new DFA15(this);
			this.dfa31 = new DFA31(this);
			this.dfa39 = new DFA39(this);
			this.dfa49 = new DFA49(this);
			this.dfa42 = new DFA42(this);
			this.dfa53 = new DFA53(this);
			this.dfa76 = new DFA76(this);
			this.dfa87 = new DFA87(this);
			this.dfa90 = new DFA90(this);
			this.dfa98 = new DFA98(this);
			this.dfa109 = new DFA109(this);
			this.dfa112 = new DFA112(this);
			this.dfa130 = new DFA130(this);
			this.dfa133 = new DFA133(this);
			this.dfa135 = new DFA135(this);
			this.dfa143 = new DFA143(this);
			this.dfa142 = new DFA142(this);
			this.dfa148 = new DFA148(this);
			this.dfa171 = new DFA171(this);
			this.dfa2.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA2_SpecialStateTransition);
			this.dfa12.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA12_SpecialStateTransition);
			this.dfa15.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA15_SpecialStateTransition);
			this.dfa31.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA31_SpecialStateTransition);
			this.dfa39.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA39_SpecialStateTransition);
			this.dfa49.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA49_SpecialStateTransition);
			this.dfa42.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA42_SpecialStateTransition);
			this.dfa53.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA53_SpecialStateTransition);
			this.dfa76.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA76_SpecialStateTransition);
			this.dfa87.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA87_SpecialStateTransition);
			this.dfa90.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA90_SpecialStateTransition);
			this.dfa98.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA98_SpecialStateTransition);
			this.dfa109.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA109_SpecialStateTransition);
			this.dfa130.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA130_SpecialStateTransition);
			this.dfa133.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA133_SpecialStateTransition);
			this.dfa135.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA135_SpecialStateTransition);
			this.dfa142.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA142_SpecialStateTransition);
			this.dfa148.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA148_SpecialStateTransition);
			this.dfa171.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA171_SpecialStateTransition);
		}

		const string DFA2_eotS =
			"\x14\uffff";
		const string DFA2_eofS =
			"\x01\x03\x13\uffff";
		const string DFA2_minS =
			"\x01\x1a\x01\x00\x12\uffff";
		const string DFA2_maxS =
			"\x01\x70\x01\x00\x12\uffff";
		const string DFA2_acceptS =
			"\x02\uffff\x01\x01\x01\x02\x10\uffff";
		const string DFA2_specialS =
			"\x01\uffff\x01\x00\x12\uffff}>";
		static readonly string[] DFA2_transitionS = {
			"\x01\x03\x07\uffff\x01\x03\x06\uffff\x01\x03\x01\uffff\x01"+
				"\x03\x06\uffff\x01\x03\x02\uffff\x01\x03\x01\uffff\x01\x03\x01"+
					"\uffff\x01\x02\x03\x03\x02\uffff\x02\x03\x02\uffff\x01\x03\x03"+
						"\uffff\x01\x03\x02\uffff\x01\x03\x07\uffff\x01\x03\x1d\uffff"+
							"\x01\x01",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
		static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
		static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
		static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
		static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
		static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
		static readonly short[][] DFA2_transition = DFA.UnpackEncodedStringArray(DFA2_transitionS);

		protected class DFA2 : DFA
		{
			public DFA2(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 2;
				this.eot = DFA2_eot;
				this.eof = DFA2_eof;
				this.min = DFA2_min;
				this.max = DFA2_max;
				this.accept = DFA2_accept;
				this.special = DFA2_special;
				this.transition = DFA2_transition;

			}

			override public string Description
			{
				get { return "317:9: ( ( annotations )? packageDeclaration )?"; }
			}

		}


		protected internal int DFA2_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA2_1 = input.LA(1);

                   	 
				int index2_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred2_Java()) ) { s = 2; }

				else if ( (true) ) { s = 3; }

                   	 
				input.Seek(index2_1);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae2 =
				new NoViableAltException(dfa.Description, 2, _s, input);
			dfa.Error(nvae2);
			throw nvae2;
		}
		const string DFA12_eotS =
			"\x10\uffff";
		const string DFA12_eofS =
			"\x10\uffff";
		const string DFA12_minS =
			"\x01\x1a\x0c\x00\x03\uffff";
		const string DFA12_maxS =
			"\x01\x70\x0c\x00\x03\uffff";
		const string DFA12_acceptS =
			"\x0d\uffff\x01\x01\x01\uffff\x01\x02";
		const string DFA12_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x03\uffff}>";
		static readonly string[] DFA12_transitionS = {
			"\x01\x06\x07\uffff\x01\x0d\x06\uffff\x01\x0d\x01\uffff\x01"+
				"\x07\x09\uffff\x01\x0f\x01\uffff\x01\x08\x02\uffff\x01\x04\x01"+
					"\x03\x01\x02\x02\uffff\x01\x05\x01\x0c\x02\uffff\x01\x09\x03"+
						"\uffff\x01\x0a\x02\uffff\x01\x0b\x25\uffff\x01\x01",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			""
		};

		static readonly short[] DFA12_eot = DFA.UnpackEncodedString(DFA12_eotS);
		static readonly short[] DFA12_eof = DFA.UnpackEncodedString(DFA12_eofS);
		static readonly char[] DFA12_min = DFA.UnpackEncodedStringToUnsignedChars(DFA12_minS);
		static readonly char[] DFA12_max = DFA.UnpackEncodedStringToUnsignedChars(DFA12_maxS);
		static readonly short[] DFA12_accept = DFA.UnpackEncodedString(DFA12_acceptS);
		static readonly short[] DFA12_special = DFA.UnpackEncodedString(DFA12_specialS);
		static readonly short[][] DFA12_transition = DFA.UnpackEncodedStringArray(DFA12_transitionS);

		protected class DFA12 : DFA
		{
			public DFA12(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 12;
				this.eot = DFA12_eot;
				this.eof = DFA12_eof;
				this.min = DFA12_min;
				this.max = DFA12_max;
				this.accept = DFA12_accept;
				this.special = DFA12_special;
				this.transition = DFA12_transition;

			}

			override public string Description
			{
				get { return "368:1: classOrInterfaceDeclaration : ( classDeclaration | interfaceDeclaration );"; }
			}

		}


		protected internal int DFA12_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA12_1 = input.LA(1);

                   	 
				int index12_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA12_2 = input.LA(1);

                   	 
				int index12_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA12_3 = input.LA(1);

                   	 
				int index12_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA12_4 = input.LA(1);

                   	 
				int index12_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA12_5 = input.LA(1);

                   	 
				int index12_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA12_6 = input.LA(1);

                   	 
				int index12_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA12_7 = input.LA(1);

                   	 
				int index12_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA12_8 = input.LA(1);

                   	 
				int index12_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA12_9 = input.LA(1);

                   	 
				int index12_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA12_10 = input.LA(1);

                   	 
				int index12_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA12_11 = input.LA(1);

                   	 
				int index12_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA12_12 = input.LA(1);

                   	 
				int index12_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred12_Java()) ) { s = 13; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index12_12);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae12 =
				new NoViableAltException(dfa.Description, 12, _s, input);
			dfa.Error(nvae12);
			throw nvae12;
		}
		const string DFA13_eotS =
			"\x0f\uffff";
		const string DFA13_eofS =
			"\x0f\uffff";
		const string DFA13_minS =
			"\x01\x04\x01\uffff\x01\x04\x0c\uffff";
		const string DFA13_maxS =
			"\x01\x73\x01\uffff\x01\x35\x0c\uffff";
		const string DFA13_acceptS =
			"\x01\uffff\x01\x0d\x01\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x01";
		const string DFA13_specialS =
			"\x0f\uffff}>";
		static readonly string[] DFA13_transitionS = {
			"\x01\x01\x15\uffff\x01\x07\x01\uffff\x01\x01\x01\uffff\x01"+
				"\x01\x02\uffff\x02\x01\x04\uffff\x01\x01\x01\uffff\x01\x01\x01"+
					"\uffff\x01\x08\x01\uffff\x01\x01\x06\uffff\x03\x01\x01\x09\x02"+
						"\uffff\x01\x05\x01\x04\x01\x03\x01\uffff\x01\x01\x01\x06\x01"+
							"\x0d\x02\uffff\x01\x0a\x03\uffff\x01\x0b\x01\uffff\x01\x01\x01"+
								"\x0c\x25\uffff\x01\x02\x02\uffff\x01\x01",
			"",
			"\x01\x0e\x30\uffff\x01\x01",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA13_eot = DFA.UnpackEncodedString(DFA13_eotS);
		static readonly short[] DFA13_eof = DFA.UnpackEncodedString(DFA13_eofS);
		static readonly char[] DFA13_min = DFA.UnpackEncodedStringToUnsignedChars(DFA13_minS);
		static readonly char[] DFA13_max = DFA.UnpackEncodedStringToUnsignedChars(DFA13_maxS);
		static readonly short[] DFA13_accept = DFA.UnpackEncodedString(DFA13_acceptS);
		static readonly short[] DFA13_special = DFA.UnpackEncodedString(DFA13_specialS);
		static readonly short[][] DFA13_transition = DFA.UnpackEncodedStringArray(DFA13_transitionS);

		protected class DFA13 : DFA
		{
			public DFA13(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 13;
				this.eot = DFA13_eot;
				this.eof = DFA13_eof;
				this.min = DFA13_min;
				this.max = DFA13_max;
				this.accept = DFA13_accept;
				this.special = DFA13_special;
				this.transition = DFA13_transition;

			}

			override public string Description
			{
				get { return "()* loopback of 380:5: ( annotation | 'public' | 'protected' | 'private' | 'static' | 'abstract' | 'final' | 'native' | 'synchronized' | 'transient' | 'volatile' | 'strictfp' )*"; }
			}

		}

		const string DFA15_eotS =
			"\x0f\uffff";
		const string DFA15_eofS =
			"\x0f\uffff";
		const string DFA15_minS =
			"\x01\x1a\x0c\x00\x02\uffff";
		const string DFA15_maxS =
			"\x01\x70\x0c\x00\x02\uffff";
		const string DFA15_acceptS =
			"\x0d\uffff\x01\x01\x01\x02";
		const string DFA15_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x02\uffff}>";
		static readonly string[] DFA15_transitionS = {
			"\x01\x06\x07\uffff\x01\x0d\x06\uffff\x01\x0e\x01\uffff\x01"+
				"\x07\x0b\uffff\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x02"+
					"\uffff\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a\x02"+
						"\uffff\x01\x0b\x25\uffff\x01\x01",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			""
		};

		static readonly short[] DFA15_eot = DFA.UnpackEncodedString(DFA15_eotS);
		static readonly short[] DFA15_eof = DFA.UnpackEncodedString(DFA15_eofS);
		static readonly char[] DFA15_min = DFA.UnpackEncodedStringToUnsignedChars(DFA15_minS);
		static readonly char[] DFA15_max = DFA.UnpackEncodedStringToUnsignedChars(DFA15_maxS);
		static readonly short[] DFA15_accept = DFA.UnpackEncodedString(DFA15_acceptS);
		static readonly short[] DFA15_special = DFA.UnpackEncodedString(DFA15_specialS);
		static readonly short[][] DFA15_transition = DFA.UnpackEncodedStringArray(DFA15_transitionS);

		protected class DFA15 : DFA
		{
			public DFA15(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 15;
				this.eot = DFA15_eot;
				this.eof = DFA15_eof;
				this.min = DFA15_min;
				this.max = DFA15_max;
				this.accept = DFA15_accept;
				this.special = DFA15_special;
				this.transition = DFA15_transition;

			}

			override public string Description
			{
				get { return "405:1: classDeclaration : ( normalClassDeclaration | enumDeclaration );"; }
			}

		}


		protected internal int DFA15_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA15_1 = input.LA(1);

                   	 
				int index15_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA15_2 = input.LA(1);

                   	 
				int index15_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA15_3 = input.LA(1);

                   	 
				int index15_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA15_4 = input.LA(1);

                   	 
				int index15_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA15_5 = input.LA(1);

                   	 
				int index15_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA15_6 = input.LA(1);

                   	 
				int index15_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA15_7 = input.LA(1);

                   	 
				int index15_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA15_8 = input.LA(1);

                   	 
				int index15_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA15_9 = input.LA(1);

                   	 
				int index15_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA15_10 = input.LA(1);

                   	 
				int index15_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA15_11 = input.LA(1);

                   	 
				int index15_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA15_12 = input.LA(1);

                   	 
				int index15_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred27_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index15_12);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae15 =
				new NoViableAltException(dfa.Description, 15, _s, input);
			dfa.Error(nvae15);
			throw nvae15;
		}
		const string DFA31_eotS =
			"\x0f\uffff";
		const string DFA31_eofS =
			"\x0f\uffff";
		const string DFA31_minS =
			"\x01\x1a\x0c\x00\x02\uffff";
		const string DFA31_maxS =
			"\x01\x70\x0c\x00\x02\uffff";
		const string DFA31_acceptS =
			"\x0d\uffff\x01\x01\x01\x02";
		const string DFA31_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x02\uffff}>";
		static readonly string[] DFA31_transitionS = {
			"\x01\x06\x10\uffff\x01\x07\x09\uffff\x01\x0d\x01\uffff\x01"+
				"\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x02\uffff\x01\x05\x01"+
					"\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a\x02\uffff\x01\x0b\x25"+
						"\uffff\x01\x01",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			""
		};

		static readonly short[] DFA31_eot = DFA.UnpackEncodedString(DFA31_eotS);
		static readonly short[] DFA31_eof = DFA.UnpackEncodedString(DFA31_eofS);
		static readonly char[] DFA31_min = DFA.UnpackEncodedStringToUnsignedChars(DFA31_minS);
		static readonly char[] DFA31_max = DFA.UnpackEncodedStringToUnsignedChars(DFA31_maxS);
		static readonly short[] DFA31_accept = DFA.UnpackEncodedString(DFA31_acceptS);
		static readonly short[] DFA31_special = DFA.UnpackEncodedString(DFA31_specialS);
		static readonly short[][] DFA31_transition = DFA.UnpackEncodedStringArray(DFA31_transitionS);

		protected class DFA31 : DFA
		{
			public DFA31(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 31;
				this.eot = DFA31_eot;
				this.eof = DFA31_eof;
				this.min = DFA31_min;
				this.max = DFA31_max;
				this.accept = DFA31_accept;
				this.special = DFA31_special;
				this.transition = DFA31_transition;

			}

			override public string Description
			{
				get { return "513:1: interfaceDeclaration : ( normalInterfaceDeclaration | annotationTypeDeclaration );"; }
			}

		}


		protected internal int DFA31_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA31_1 = input.LA(1);

                   	 
				int index31_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA31_2 = input.LA(1);

                   	 
				int index31_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA31_3 = input.LA(1);

                   	 
				int index31_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA31_4 = input.LA(1);

                   	 
				int index31_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA31_5 = input.LA(1);

                   	 
				int index31_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA31_6 = input.LA(1);

                   	 
				int index31_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA31_7 = input.LA(1);

                   	 
				int index31_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA31_8 = input.LA(1);

                   	 
				int index31_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA31_9 = input.LA(1);

                   	 
				int index31_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA31_10 = input.LA(1);

                   	 
				int index31_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA31_11 = input.LA(1);

                   	 
				int index31_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA31_12 = input.LA(1);

                   	 
				int index31_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred43_Java()) ) { s = 13; }

				else if ( (true) ) { s = 14; }

                   	 
				input.Seek(index31_12);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae31 =
				new NoViableAltException(dfa.Description, 31, _s, input);
			dfa.Error(nvae31);
			throw nvae31;
		}
		const string DFA39_eotS =
			"\x15\uffff";
		const string DFA39_eofS =
			"\x15\uffff";
		const string DFA39_minS =
			"\x01\x04\x0e\x00\x06\uffff";
		const string DFA39_maxS =
			"\x01\x73\x0e\x00\x06\uffff";
		const string DFA39_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x03\x01\uffff\x01\x04\x01\x01";
		const string DFA39_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x06"+
					"\uffff}>";
		static readonly string[] DFA39_transitionS = {
			"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01"+
				"\x0e\x02\uffff\x01\x0e\x01\x11\x04\uffff\x01\x0e\x01\uffff\x01"+
					"\x11\x01\uffff\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01"+
						"\x13\x01\x0e\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff"+
							"\x01\x0e\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a"+
								"\x01\uffff\x01\x0f\x01\x0b\x25\uffff\x01\x01\x02\uffff\x01\x0f",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA39_eot = DFA.UnpackEncodedString(DFA39_eotS);
		static readonly short[] DFA39_eof = DFA.UnpackEncodedString(DFA39_eofS);
		static readonly char[] DFA39_min = DFA.UnpackEncodedStringToUnsignedChars(DFA39_minS);
		static readonly char[] DFA39_max = DFA.UnpackEncodedStringToUnsignedChars(DFA39_maxS);
		static readonly short[] DFA39_accept = DFA.UnpackEncodedString(DFA39_acceptS);
		static readonly short[] DFA39_special = DFA.UnpackEncodedString(DFA39_specialS);
		static readonly short[][] DFA39_transition = DFA.UnpackEncodedStringArray(DFA39_transitionS);

		protected class DFA39 : DFA
		{
			public DFA39(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 39;
				this.eot = DFA39_eot;
				this.eof = DFA39_eof;
				this.min = DFA39_min;
				this.max = DFA39_max;
				this.accept = DFA39_accept;
				this.special = DFA39_special;
				this.transition = DFA39_transition;

			}

			override public string Description
			{
				get { return "567:1: memberDecl : ( fieldDeclaration | methodDeclaration | classDeclaration | interfaceDeclaration );"; }
			}

		}


		protected internal int DFA39_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA39_1 = input.LA(1);

                   	 
				int index39_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA39_2 = input.LA(1);

                   	 
				int index39_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA39_3 = input.LA(1);

                   	 
				int index39_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA39_4 = input.LA(1);

                   	 
				int index39_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA39_5 = input.LA(1);

                   	 
				int index39_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA39_6 = input.LA(1);

                   	 
				int index39_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA39_7 = input.LA(1);

                   	 
				int index39_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA39_8 = input.LA(1);

                   	 
				int index39_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA39_9 = input.LA(1);

                   	 
				int index39_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA39_10 = input.LA(1);

                   	 
				int index39_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA39_11 = input.LA(1);

                   	 
				int index39_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA39_12 = input.LA(1);

                   	 
				int index39_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

				else if ( (synpred54_Java()) ) { s = 17; }

				else if ( (true) ) { s = 19; }

                   	 
				input.Seek(index39_12);
				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA39_13 = input.LA(1);

                   	 
				int index39_13 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

                   	 
				input.Seek(index39_13);
				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA39_14 = input.LA(1);

                   	 
				int index39_14 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred52_Java()) ) { s = 20; }

				else if ( (synpred53_Java()) ) { s = 15; }

                   	 
				input.Seek(index39_14);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae39 =
				new NoViableAltException(dfa.Description, 39, _s, input);
			dfa.Error(nvae39);
			throw nvae39;
		}
		const string DFA49_eotS =
			"\x12\uffff";
		const string DFA49_eofS =
			"\x12\uffff";
		const string DFA49_minS =
			"\x01\x04\x0e\x00\x03\uffff";
		const string DFA49_maxS =
			"\x01\x73\x0e\x00\x03\uffff";
		const string DFA49_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x01";
		const string DFA49_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x03"+
					"\uffff}>";
		static readonly string[] DFA49_transitionS = {
			"\x01\x0e\x15\uffff\x01\x06\x01\uffff\x01\x0f\x01\uffff\x01"+
				"\x0f\x02\uffff\x01\x0f\x05\uffff\x01\x0f\x03\uffff\x01\x07\x01"+
					"\uffff\x01\x0f\x06\uffff\x01\x0f\x01\uffff\x01\x0f\x01\x08\x02"+
						"\uffff\x01\x04\x01\x03\x01\x02\x01\uffff\x01\x0f\x01\x05\x01"+
							"\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a\x01\uffff\x01\x0f\x01"+
								"\x0b\x25\uffff\x01\x01\x02\uffff\x01\x0d",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			""
		};

		static readonly short[] DFA49_eot = DFA.UnpackEncodedString(DFA49_eotS);
		static readonly short[] DFA49_eof = DFA.UnpackEncodedString(DFA49_eofS);
		static readonly char[] DFA49_min = DFA.UnpackEncodedStringToUnsignedChars(DFA49_minS);
		static readonly char[] DFA49_max = DFA.UnpackEncodedStringToUnsignedChars(DFA49_maxS);
		static readonly short[] DFA49_accept = DFA.UnpackEncodedString(DFA49_acceptS);
		static readonly short[] DFA49_special = DFA.UnpackEncodedString(DFA49_specialS);
		static readonly short[][] DFA49_transition = DFA.UnpackEncodedStringArray(DFA49_transitionS);

		protected class DFA49 : DFA
		{
			public DFA49(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 49;
				this.eot = DFA49_eot;
				this.eof = DFA49_eof;
				this.min = DFA49_min;
				this.max = DFA49_max;
				this.accept = DFA49_accept;
				this.special = DFA49_special;
				this.transition = DFA49_transition;

			}

			override public string Description
			{
				get { return "577:1: methodDeclaration : ( modifiers ( typeParameters )? IDENTIFIER formalParameters ( 'throws' qualifiedNameList )? '{' ( explicitConstructorInvocation )? ( blockStatement )* '}' | modifiers ( typeParameters )? ( type | 'void' ) IDENTIFIER formalParameters ( '[' ']' )* ( 'throws' qualifiedNameList )? ( block | ';' ) );"; }
			}

		}


		protected internal int DFA49_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA49_1 = input.LA(1);

                   	 
				int index49_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA49_2 = input.LA(1);

                   	 
				int index49_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA49_3 = input.LA(1);

                   	 
				int index49_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA49_4 = input.LA(1);

                   	 
				int index49_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA49_5 = input.LA(1);

                   	 
				int index49_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA49_6 = input.LA(1);

                   	 
				int index49_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA49_7 = input.LA(1);

                   	 
				int index49_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA49_8 = input.LA(1);

                   	 
				int index49_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA49_9 = input.LA(1);

                   	 
				int index49_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA49_10 = input.LA(1);

                   	 
				int index49_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA49_11 = input.LA(1);

                   	 
				int index49_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA49_12 = input.LA(1);

                   	 
				int index49_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_12);
				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA49_13 = input.LA(1);

                   	 
				int index49_13 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_13);
				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA49_14 = input.LA(1);

                   	 
				int index49_14 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred59_Java()) ) { s = 17; }

				else if ( (true) ) { s = 15; }

                   	 
				input.Seek(index49_14);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae49 =
				new NoViableAltException(dfa.Description, 49, _s, input);
			dfa.Error(nvae49);
			throw nvae49;
		}
		const string DFA42_eotS =
			"\x2d\uffff";
		const string DFA42_eofS =
			"\x2d\uffff";
		const string DFA42_minS =
			"\x01\x04\x01\uffff\x08\x00\x23\uffff";
		const string DFA42_maxS =
			"\x01\x73\x01\uffff\x08\x00\x23\uffff";
		const string DFA42_acceptS =
			"\x01\uffff\x01\x01\x08\uffff\x01\x02\x22\uffff";
		const string DFA42_specialS =
			"\x02\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x23\uffff}>";
		static readonly string[] DFA42_transitionS = {
			"\x01\x05\x09\x06\x0c\uffff\x02\x0a\x01\x08\x01\x0a\x01\x08"+
				"\x02\uffff\x01\x08\x01\x0a\x01\uffff\x01\x0a\x01\uffff\x01\x0a"+
					"\x01\x08\x01\uffff\x01\x0a\x01\uffff\x01\x0a\x01\uffff\x01\x08"+
						"\x01\x0a\x01\uffff\x01\x0a\x03\uffff\x01\x08\x01\x0a\x01\x08"+
							"\x01\x0a\x01\x07\x01\uffff\x04\x0a\x01\x08\x02\x0a\x01\x04\x02"+
								"\x0a\x01\x02\x01\x0a\x01\uffff\x02\x0a\x01\x09\x02\x0a\x01\x03"+
									"\x01\uffff\x02\x0a\x02\uffff\x01\x0a\x04\uffff\x02\x0a\x05\uffff"+
										"\x04\x0a\x0e\uffff\x01\x0a\x02\uffff\x01\x01",
			"",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA42_eot = DFA.UnpackEncodedString(DFA42_eotS);
		static readonly short[] DFA42_eof = DFA.UnpackEncodedString(DFA42_eofS);
		static readonly char[] DFA42_min = DFA.UnpackEncodedStringToUnsignedChars(DFA42_minS);
		static readonly char[] DFA42_max = DFA.UnpackEncodedStringToUnsignedChars(DFA42_maxS);
		static readonly short[] DFA42_accept = DFA.UnpackEncodedString(DFA42_acceptS);
		static readonly short[] DFA42_special = DFA.UnpackEncodedString(DFA42_specialS);
		static readonly short[][] DFA42_transition = DFA.UnpackEncodedStringArray(DFA42_transitionS);

		protected class DFA42 : DFA
		{
			public DFA42(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 42;
				this.eot = DFA42_eot;
				this.eof = DFA42_eof;
				this.min = DFA42_min;
				this.max = DFA42_max;
				this.accept = DFA42_accept;
				this.special = DFA42_special;
				this.transition = DFA42_transition;

			}

			override public string Description
			{
				get { return "590:9: ( explicitConstructorInvocation )?"; }
			}

		}


		protected internal int DFA42_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA42_2 = input.LA(1);

                   	 
				int index42_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_2);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA42_3 = input.LA(1);

                   	 
				int index42_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_3);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA42_4 = input.LA(1);

                   	 
				int index42_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_4);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA42_5 = input.LA(1);

                   	 
				int index42_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_5);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA42_6 = input.LA(1);

                   	 
				int index42_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_6);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA42_7 = input.LA(1);

                   	 
				int index42_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_7);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA42_8 = input.LA(1);

                   	 
				int index42_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_8);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA42_9 = input.LA(1);

                   	 
				int index42_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index42_9);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae42 =
				new NoViableAltException(dfa.Description, 42, _s, input);
			dfa.Error(nvae42);
			throw nvae42;
		}
		const string DFA53_eotS =
			"\x16\uffff";
		const string DFA53_eofS =
			"\x16\uffff";
		const string DFA53_minS =
			"\x01\x04\x0e\x00\x07\uffff";
		const string DFA53_maxS =
			"\x01\x73\x0e\x00\x07\uffff";
		const string DFA53_acceptS =
			"\x0f\uffff\x01\x02\x01\uffff\x01\x03\x01\x04\x01\uffff\x01\x05"+
				"\x01\x01";
		const string DFA53_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x07"+
					"\uffff}>";
		static readonly string[] DFA53_transitionS = {
			"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01"+
				"\x0e\x02\uffff\x01\x0e\x01\x12\x04\uffff\x01\x0e\x01\uffff\x01"+
					"\x12\x01\uffff\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01"+
						"\x11\x01\x0e\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff"+
							"\x01\x0e\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a"+
								"\x01\uffff\x01\x0f\x01\x0b\x07\uffff\x01\x14\x1d\uffff\x01\x01"+
									"\x02\uffff\x01\x0f",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA53_eot = DFA.UnpackEncodedString(DFA53_eotS);
		static readonly short[] DFA53_eof = DFA.UnpackEncodedString(DFA53_eofS);
		static readonly char[] DFA53_min = DFA.UnpackEncodedStringToUnsignedChars(DFA53_minS);
		static readonly char[] DFA53_max = DFA.UnpackEncodedStringToUnsignedChars(DFA53_maxS);
		static readonly short[] DFA53_accept = DFA.UnpackEncodedString(DFA53_acceptS);
		static readonly short[] DFA53_special = DFA.UnpackEncodedString(DFA53_specialS);
		static readonly short[][] DFA53_transition = DFA.UnpackEncodedStringArray(DFA53_transitionS);

		protected class DFA53 : DFA
		{
			public DFA53(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 53;
				this.eot = DFA53_eot;
				this.eof = DFA53_eof;
				this.min = DFA53_min;
				this.max = DFA53_max;
				this.accept = DFA53_accept;
				this.special = DFA53_special;
				this.transition = DFA53_transition;

			}

			override public string Description
			{
				get { return "635:1: interfaceBodyDeclaration : ( interfaceFieldDeclaration | interfaceMethodDeclaration | interfaceDeclaration | classDeclaration | ';' );"; }
			}

		}


		protected internal int DFA53_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA53_1 = input.LA(1);

                   	 
				int index53_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA53_2 = input.LA(1);

                   	 
				int index53_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA53_3 = input.LA(1);

                   	 
				int index53_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA53_4 = input.LA(1);

                   	 
				int index53_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA53_5 = input.LA(1);

                   	 
				int index53_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA53_6 = input.LA(1);

                   	 
				int index53_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA53_7 = input.LA(1);

                   	 
				int index53_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA53_8 = input.LA(1);

                   	 
				int index53_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA53_9 = input.LA(1);

                   	 
				int index53_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA53_10 = input.LA(1);

                   	 
				int index53_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA53_11 = input.LA(1);

                   	 
				int index53_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA53_12 = input.LA(1);

                   	 
				int index53_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

				else if ( (synpred70_Java()) ) { s = 17; }

				else if ( (synpred71_Java()) ) { s = 18; }

                   	 
				input.Seek(index53_12);
				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA53_13 = input.LA(1);

                   	 
				int index53_13 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

                   	 
				input.Seek(index53_13);
				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA53_14 = input.LA(1);

                   	 
				int index53_14 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred68_Java()) ) { s = 21; }

				else if ( (synpred69_Java()) ) { s = 15; }

                   	 
				input.Seek(index53_14);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae53 =
				new NoViableAltException(dfa.Description, 53, _s, input);
			dfa.Error(nvae53);
			throw nvae53;
		}
		const string DFA76_eotS =
			"\x0a\uffff";
		const string DFA76_eofS =
			"\x0a\uffff";
		const string DFA76_minS =
			"\x01\x04\x01\uffff\x01\x00\x01\uffff\x01\x00\x05\uffff";
		const string DFA76_maxS =
			"\x01\x73\x01\uffff\x01\x00\x01\uffff\x01\x00\x05\uffff";
		const string DFA76_acceptS =
			"\x01\uffff\x01\x01\x01\uffff\x01\x02\x06\uffff";
		const string DFA76_specialS =
			"\x02\uffff\x01\x00\x01\uffff\x01\x01\x05\uffff}>";
		static readonly string[] DFA76_transitionS = {
			"\x0a\x03\x0e\uffff\x01\x03\x01\uffff\x01\x03\x02\uffff\x01"+
				"\x03\x05\uffff\x01\x03\x05\uffff\x01\x03\x06\uffff\x01\x03\x01"+
					"\uffff\x01\x03\x01\uffff\x01\x03\x05\uffff\x01\x03\x02\uffff"+
						"\x01\x04\x02\uffff\x01\x02\x04\uffff\x01\x03\x02\uffff\x01\x03"+
							"\x26\uffff\x01\x01",
			"",
			"\x01\uffff",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA76_eot = DFA.UnpackEncodedString(DFA76_eotS);
		static readonly short[] DFA76_eof = DFA.UnpackEncodedString(DFA76_eofS);
		static readonly char[] DFA76_min = DFA.UnpackEncodedStringToUnsignedChars(DFA76_minS);
		static readonly char[] DFA76_max = DFA.UnpackEncodedStringToUnsignedChars(DFA76_maxS);
		static readonly short[] DFA76_accept = DFA.UnpackEncodedString(DFA76_acceptS);
		static readonly short[] DFA76_special = DFA.UnpackEncodedString(DFA76_specialS);
		static readonly short[][] DFA76_transition = DFA.UnpackEncodedStringArray(DFA76_transitionS);

		protected class DFA76 : DFA
		{
			public DFA76(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 76;
				this.eot = DFA76_eot;
				this.eof = DFA76_eof;
				this.min = DFA76_min;
				this.max = DFA76_max;
				this.accept = DFA76_accept;
				this.special = DFA76_special;
				this.transition = DFA76_transition;

			}

			override public string Description
			{
				get { return "787:1: explicitConstructorInvocation : ( ( nonWildcardTypeArguments )? ( 'this' | 'super' ) arguments ';' | primary '.' ( nonWildcardTypeArguments )? 'super' arguments ';' );"; }
			}

		}


		protected internal int DFA76_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA76_2 = input.LA(1);

                   	 
				int index76_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred103_Java()) ) { s = 1; }

				else if ( (true) ) { s = 3; }

                   	 
				input.Seek(index76_2);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA76_4 = input.LA(1);

                   	 
				int index76_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred103_Java()) ) { s = 1; }

				else if ( (true) ) { s = 3; }

                   	 
				input.Seek(index76_4);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae76 =
				new NoViableAltException(dfa.Description, 76, _s, input);
			dfa.Error(nvae76);
			throw nvae76;
		}
		const string DFA87_eotS =
			"\x16\uffff";
		const string DFA87_eofS =
			"\x16\uffff";
		const string DFA87_minS =
			"\x01\x04\x0e\x00\x07\uffff";
		const string DFA87_maxS =
			"\x01\x70\x0e\x00\x07\uffff";
		const string DFA87_acceptS =
			"\x0f\uffff\x01\x03\x01\x04\x01\x05\x01\x07\x01\x01\x01\x02\x01"+
				"\x06";
		const string DFA87_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x07"+
					"\uffff}>";
		static readonly string[] DFA87_transitionS = {
			"\x01\x0d\x15\uffff\x01\x06\x01\uffff\x01\x0e\x01\uffff\x01"+
				"\x0e\x02\uffff\x01\x0e\x01\x0f\x04\uffff\x01\x0e\x01\uffff\x01"+
					"\x11\x01\uffff\x01\x07\x01\uffff\x01\x0e\x06\uffff\x01\x0e\x01"+
						"\x10\x01\x0e\x01\x08\x02\uffff\x01\x04\x01\x03\x01\x02\x01\uffff"+
							"\x01\x0e\x01\x05\x01\x0c\x02\uffff\x01\x09\x03\uffff\x01\x0a"+
								"\x02\uffff\x01\x0b\x07\uffff\x01\x12\x1d\uffff\x01\x01",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA87_eot = DFA.UnpackEncodedString(DFA87_eotS);
		static readonly short[] DFA87_eof = DFA.UnpackEncodedString(DFA87_eofS);
		static readonly char[] DFA87_min = DFA.UnpackEncodedStringToUnsignedChars(DFA87_minS);
		static readonly char[] DFA87_max = DFA.UnpackEncodedStringToUnsignedChars(DFA87_maxS);
		static readonly short[] DFA87_accept = DFA.UnpackEncodedString(DFA87_acceptS);
		static readonly short[] DFA87_special = DFA.UnpackEncodedString(DFA87_specialS);
		static readonly short[][] DFA87_transition = DFA.UnpackEncodedStringArray(DFA87_transitionS);

		protected class DFA87 : DFA
		{
			public DFA87(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 87;
				this.eot = DFA87_eot;
				this.eof = DFA87_eof;
				this.min = DFA87_min;
				this.max = DFA87_max;
				this.accept = DFA87_accept;
				this.special = DFA87_special;
				this.transition = DFA87_transition;

			}

			override public string Description
			{
				get { return "891:1: annotationTypeElementDeclaration : ( annotationMethodDeclaration | interfaceFieldDeclaration | normalClassDeclaration | normalInterfaceDeclaration | enumDeclaration | annotationTypeDeclaration | ';' );"; }
			}

		}


		protected internal int DFA87_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA87_1 = input.LA(1);

                   	 
				int index87_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA87_2 = input.LA(1);

                   	 
				int index87_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA87_3 = input.LA(1);

                   	 
				int index87_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA87_4 = input.LA(1);

                   	 
				int index87_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA87_5 = input.LA(1);

                   	 
				int index87_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_5);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA87_6 = input.LA(1);

                   	 
				int index87_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_6);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA87_7 = input.LA(1);

                   	 
				int index87_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_7);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA87_8 = input.LA(1);

                   	 
				int index87_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_8);
				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA87_9 = input.LA(1);

                   	 
				int index87_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_9);
				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA87_10 = input.LA(1);

                   	 
				int index87_10 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_10);
				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA87_11 = input.LA(1);

                   	 
				int index87_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_11);
				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA87_12 = input.LA(1);

                   	 
				int index87_12 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

				else if ( (synpred119_Java()) ) { s = 15; }

				else if ( (synpred120_Java()) ) { s = 16; }

				else if ( (synpred121_Java()) ) { s = 17; }

				else if ( (synpred122_Java()) ) { s = 21; }

                   	 
				input.Seek(index87_12);
				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA87_13 = input.LA(1);

                   	 
				int index87_13 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

                   	 
				input.Seek(index87_13);
				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA87_14 = input.LA(1);

                   	 
				int index87_14 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred117_Java()) ) { s = 19; }

				else if ( (synpred118_Java()) ) { s = 20; }

                   	 
				input.Seek(index87_14);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae87 =
				new NoViableAltException(dfa.Description, 87, _s, input);
			dfa.Error(nvae87);
			throw nvae87;
		}
		const string DFA90_eotS =
			"\x2c\uffff";
		const string DFA90_eofS =
			"\x2c\uffff";
		const string DFA90_minS =
			"\x01\x04\x04\x00\x06\uffff\x01\x00\x20\uffff";
		const string DFA90_maxS =
			"\x01\x70\x04\x00\x06\uffff\x01\x00\x20\uffff";
		const string DFA90_acceptS =
			"\x05\uffff\x01\x02\x0c\uffff\x01\x03\x18\uffff\x01\x01";
		const string DFA90_specialS =
			"\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x06\uffff\x01\x04\x20"+
				"\uffff}>";
		static readonly string[] DFA90_transitionS = {
			"\x01\x03\x09\x12\x0c\uffff\x01\x05\x01\x12\x01\x04\x01\x12"+
				"\x01\x04\x02\uffff\x01\x04\x01\x05\x01\uffff\x01\x12\x01\uffff"+
					"\x01\x12\x01\x04\x01\uffff\x01\x05\x01\uffff\x01\x01\x01\uffff"+
						"\x01\x04\x01\x12\x01\uffff\x01\x12\x03\uffff\x01\x04\x01\x05"+
							"\x01\x04\x01\x05\x01\x12\x01\uffff\x03\x05\x01\x12\x01\x04\x02"+
								"\x05\x02\x12\x01\x0b\x02\x12\x01\uffff\x01\x05\x02\x12\x01\x05"+
									"\x02\x12\x01\uffff\x01\x12\x03\uffff\x01\x12\x04\uffff\x02\x12"+
										"\x05\uffff\x04\x12\x0e\uffff\x01\x02",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA90_eot = DFA.UnpackEncodedString(DFA90_eotS);
		static readonly short[] DFA90_eof = DFA.UnpackEncodedString(DFA90_eofS);
		static readonly char[] DFA90_min = DFA.UnpackEncodedStringToUnsignedChars(DFA90_minS);
		static readonly char[] DFA90_max = DFA.UnpackEncodedStringToUnsignedChars(DFA90_maxS);
		static readonly short[] DFA90_accept = DFA.UnpackEncodedString(DFA90_acceptS);
		static readonly short[] DFA90_special = DFA.UnpackEncodedString(DFA90_specialS);
		static readonly short[][] DFA90_transition = DFA.UnpackEncodedStringArray(DFA90_transitionS);

		protected class DFA90 : DFA
		{
			public DFA90(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 90;
				this.eot = DFA90_eot;
				this.eof = DFA90_eof;
				this.min = DFA90_min;
				this.max = DFA90_max;
				this.accept = DFA90_accept;
				this.special = DFA90_special;
				this.transition = DFA90_transition;

			}

			override public string Description
			{
				get { return "948:1: blockStatement : ( localVariableDeclarationStatement | classOrInterfaceDeclaration | statement );"; }
			}

		}


		protected internal int DFA90_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA90_1 = input.LA(1);

                   	 
				int index90_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred125_Java()) ) { s = 43; }

				else if ( (synpred126_Java()) ) { s = 5; }

                   	 
				input.Seek(index90_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA90_2 = input.LA(1);

                   	 
				int index90_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred125_Java()) ) { s = 43; }

				else if ( (synpred126_Java()) ) { s = 5; }

                   	 
				input.Seek(index90_2);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA90_3 = input.LA(1);

                   	 
				int index90_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred125_Java()) ) { s = 43; }

				else if ( (true) ) { s = 18; }

                   	 
				input.Seek(index90_3);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA90_4 = input.LA(1);

                   	 
				int index90_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred125_Java()) ) { s = 43; }

				else if ( (true) ) { s = 18; }

                   	 
				input.Seek(index90_4);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA90_11 = input.LA(1);

                   	 
				int index90_11 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred126_Java()) ) { s = 5; }

				else if ( (true) ) { s = 18; }

                   	 
				input.Seek(index90_11);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae90 =
				new NoViableAltException(dfa.Description, 90, _s, input);
			dfa.Error(nvae90);
			throw nvae90;
		}
		const string DFA98_eotS =
			"\x20\uffff";
		const string DFA98_eofS =
			"\x20\uffff";
		const string DFA98_minS =
			"\x01\x04\x01\uffff\x01\x00\x13\uffff\x01\x00\x09\uffff";
		const string DFA98_maxS =
			"\x01\x61\x01\uffff\x01\x00\x13\uffff\x01\x00\x09\uffff";
		const string DFA98_acceptS =
			"\x01\uffff\x01\x01\x01\uffff\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
				"\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x0d"+
					"\uffff\x01\x11\x01\x02\x01\x03\x01\x10";
		const string DFA98_specialS =
			"\x02\uffff\x01\x00\x13\uffff\x01\x01\x09\uffff}>";
		static readonly string[] DFA98_transitionS = {
			"\x01\x16\x09\x0e\x0d\uffff\x01\x02\x01\x0e\x01\x0c\x01\x0e"+
				"\x02\uffff\x01\x0e\x02\uffff\x01\x0d\x01\uffff\x01\x06\x01\x0e"+
					"\x05\uffff\x01\x0e\x01\x04\x01\uffff\x01\x03\x03\uffff\x01\x0e"+
						"\x01\uffff\x01\x0e\x01\uffff\x01\x0e\x04\uffff\x01\x0a\x01\x0e"+
							"\x02\uffff\x01\x0e\x01\x08\x01\x09\x01\x0e\x01\x0b\x02\uffff"+
								"\x01\x07\x01\x0e\x01\uffff\x01\x05\x01\x0e\x01\uffff\x01\x01"+
									"\x03\uffff\x01\x1c\x04\uffff\x02\x0e\x05\uffff\x04\x0e",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA98_eot = DFA.UnpackEncodedString(DFA98_eotS);
		static readonly short[] DFA98_eof = DFA.UnpackEncodedString(DFA98_eofS);
		static readonly char[] DFA98_min = DFA.UnpackEncodedStringToUnsignedChars(DFA98_minS);
		static readonly char[] DFA98_max = DFA.UnpackEncodedStringToUnsignedChars(DFA98_maxS);
		static readonly short[] DFA98_accept = DFA.UnpackEncodedString(DFA98_acceptS);
		static readonly short[] DFA98_special = DFA.UnpackEncodedString(DFA98_specialS);
		static readonly short[][] DFA98_transition = DFA.UnpackEncodedStringArray(DFA98_transitionS);

		protected class DFA98 : DFA
		{
			public DFA98(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 98;
				this.eot = DFA98_eot;
				this.eof = DFA98_eof;
				this.min = DFA98_min;
				this.max = DFA98_max;
				this.accept = DFA98_accept;
				this.special = DFA98_special;
				this.transition = DFA98_transition;

			}

			override public string Description
			{
				get { return "973:1: statement : ( block | ( 'assert' ) expression ( ':' expression )? ';' | 'assert' expression ( ':' expression )? ';' | 'if' parExpression statement ( 'else' statement )? | forstatement | 'while' parExpression statement | 'do' statement 'while' parExpression ';' | trystatement | 'switch' parExpression '{' switchBlockStatementGroups '}' | 'synchronized' parExpression block | 'return' ( expression )? ';' | 'throw' expression ';' | 'break' ( IDENTIFIER )? ';' | 'continue' ( IDENTIFIER )? ';' | expression ';' | IDENTIFIER ':' statement | ';' );"; }
			}

		}


		protected internal int DFA98_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA98_2 = input.LA(1);

                   	 
				int index98_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred130_Java()) ) { s = 29; }

				else if ( (synpred132_Java()) ) { s = 30; }

                   	 
				input.Seek(index98_2);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA98_22 = input.LA(1);

                   	 
				int index98_22 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred148_Java()) ) { s = 14; }

				else if ( (synpred149_Java()) ) { s = 31; }

                   	 
				input.Seek(index98_22);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae98 =
				new NoViableAltException(dfa.Description, 98, _s, input);
			dfa.Error(nvae98);
			throw nvae98;
		}
		const string DFA109_eotS =
			"\x11\uffff";
		const string DFA109_eofS =
			"\x11\uffff";
		const string DFA109_minS =
			"\x01\x04\x02\uffff\x02\x00\x0c\uffff";
		const string DFA109_maxS =
			"\x01\x70\x02\uffff\x02\x00\x0c\uffff";
		const string DFA109_acceptS =
			"\x01\uffff\x01\x01\x03\uffff\x01\x02\x0b\uffff";
		const string DFA109_specialS =
			"\x03\uffff\x01\x00\x01\x01\x0c\uffff}>";
		static readonly string[] DFA109_transitionS = {
			"\x01\x03\x09\x05\x0e\uffff\x01\x04\x01\uffff\x01\x04\x02\uffff"+
				"\x01\x04\x05\uffff\x01\x04\x03\uffff\x01\x01\x01\uffff\x01\x04"+
					"\x06\uffff\x01\x04\x01\uffff\x01\x04\x01\uffff\x01\x05\x05\uffff"+
						"\x01\x04\x02\uffff\x01\x05\x02\uffff\x01\x05\x04\uffff\x01\x05"+
							"\x02\uffff\x01\x05\x0a\uffff\x02\x05\x05\uffff\x04\x05\x0e\uffff"+
								"\x01\x01",
			"",
			"",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA109_eot = DFA.UnpackEncodedString(DFA109_eotS);
		static readonly short[] DFA109_eof = DFA.UnpackEncodedString(DFA109_eofS);
		static readonly char[] DFA109_min = DFA.UnpackEncodedStringToUnsignedChars(DFA109_minS);
		static readonly char[] DFA109_max = DFA.UnpackEncodedStringToUnsignedChars(DFA109_maxS);
		static readonly short[] DFA109_accept = DFA.UnpackEncodedString(DFA109_acceptS);
		static readonly short[] DFA109_special = DFA.UnpackEncodedString(DFA109_specialS);
		static readonly short[][] DFA109_transition = DFA.UnpackEncodedStringArray(DFA109_transitionS);

		protected class DFA109 : DFA
		{
			public DFA109(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 109;
				this.eot = DFA109_eot;
				this.eof = DFA109_eof;
				this.min = DFA109_min;
				this.max = DFA109_max;
				this.accept = DFA109_accept;
				this.special = DFA109_special;
				this.transition = DFA109_transition;

			}

			override public string Description
			{
				get { return "1077:1: forInit : ( localVariableDeclaration | expressionList );"; }
			}

		}


		protected internal int DFA109_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA109_3 = input.LA(1);

                   	 
				int index109_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred161_Java()) ) { s = 1; }

				else if ( (true) ) { s = 5; }

                   	 
				input.Seek(index109_3);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA109_4 = input.LA(1);

                   	 
				int index109_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred161_Java()) ) { s = 1; }

				else if ( (true) ) { s = 5; }

                   	 
				input.Seek(index109_4);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae109 =
				new NoViableAltException(dfa.Description, 109, _s, input);
			dfa.Error(nvae109);
			throw nvae109;
		}
		const string DFA112_eotS =
			"\x0f\uffff";
		const string DFA112_eofS =
			"\x0f\uffff";
		const string DFA112_minS =
			"\x01\x56\x0a\uffff\x01\x72\x01\x56\x02\uffff";
		const string DFA112_maxS =
			"\x01\x73\x0a\uffff\x02\x72\x02\uffff";
		const string DFA112_acceptS =
			"\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
				"\x07\x01\x08\x01\x09\x01\x0a\x02\uffff\x01\x0b\x01\x0c";
		const string DFA112_specialS =
			"\x0f\uffff}>";
		static readonly string[] DFA112_transitionS = {
			"\x01\x01\x11\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
				"\x01\x07\x01\x08\x01\x09\x02\uffff\x01\x0b\x01\x0a",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x01\x0c",
			"\x01\x0e\x1b\uffff\x01\x0d",
			"",
			""
		};

		static readonly short[] DFA112_eot = DFA.UnpackEncodedString(DFA112_eotS);
		static readonly short[] DFA112_eof = DFA.UnpackEncodedString(DFA112_eofS);
		static readonly char[] DFA112_min = DFA.UnpackEncodedStringToUnsignedChars(DFA112_minS);
		static readonly char[] DFA112_max = DFA.UnpackEncodedStringToUnsignedChars(DFA112_maxS);
		static readonly short[] DFA112_accept = DFA.UnpackEncodedString(DFA112_acceptS);
		static readonly short[] DFA112_special = DFA.UnpackEncodedString(DFA112_specialS);
		static readonly short[][] DFA112_transition = DFA.UnpackEncodedStringArray(DFA112_transitionS);

		protected class DFA112 : DFA
		{
			public DFA112(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 112;
				this.eot = DFA112_eot;
				this.eof = DFA112_eof;
				this.min = DFA112_min;
				this.max = DFA112_max;
				this.accept = DFA112_accept;
				this.special = DFA112_special;
				this.transition = DFA112_transition;

			}

			override public string Description
			{
				get { return "1108:1: assignmentOperator : ( '=' | '+=' | '-=' | '*=' | '/=' | '&=' | '|=' | '^=' | '%=' | '<' '<' '=' | '>' '>' '>' '=' | '>' '>' '=' );"; }
			}

		}

		const string DFA130_eotS =
			"\x0c\uffff";
		const string DFA130_eofS =
			"\x0c\uffff";
		const string DFA130_minS =
			"\x01\x04\x02\uffff\x01\x00\x08\uffff";
		const string DFA130_maxS =
			"\x01\x58\x02\uffff\x01\x00\x08\uffff";
		const string DFA130_acceptS =
			"\x01\uffff\x01\x01\x01\x02\x01\uffff\x01\x04\x06\uffff\x01\x03";
		const string DFA130_specialS =
			"\x03\uffff\x01\x00\x08\uffff}>";
		static readonly string[] DFA130_transitionS = {
			"\x0a\x04\x0e\uffff\x01\x04\x01\uffff\x01\x04\x02\uffff\x01"+
				"\x04\x05\uffff\x01\x04\x05\uffff\x01\x04\x06\uffff\x01\x04\x01"+
					"\uffff\x01\x04\x01\uffff\x01\x04\x05\uffff\x01\x04\x02\uffff"+
						"\x01\x04\x02\uffff\x01\x04\x04\uffff\x01\x04\x02\uffff\x01\x03"+
							"\x0a\uffff\x01\x02\x01\x01",
			"",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA130_eot = DFA.UnpackEncodedString(DFA130_eotS);
		static readonly short[] DFA130_eof = DFA.UnpackEncodedString(DFA130_eofS);
		static readonly char[] DFA130_min = DFA.UnpackEncodedStringToUnsignedChars(DFA130_minS);
		static readonly char[] DFA130_max = DFA.UnpackEncodedStringToUnsignedChars(DFA130_maxS);
		static readonly short[] DFA130_accept = DFA.UnpackEncodedString(DFA130_acceptS);
		static readonly short[] DFA130_special = DFA.UnpackEncodedString(DFA130_specialS);
		static readonly short[][] DFA130_transition = DFA.UnpackEncodedStringArray(DFA130_transitionS);

		protected class DFA130 : DFA
		{
			public DFA130(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 130;
				this.eot = DFA130_eot;
				this.eof = DFA130_eof;
				this.min = DFA130_min;
				this.max = DFA130_max;
				this.accept = DFA130_accept;
				this.special = DFA130_special;
				this.transition = DFA130_transition;

			}

			override public string Description
			{
				get { return "1269:1: unaryExpressionNotPlusMinus : ( '~' unaryExpression | '!' unaryExpression | castExpression | primary ( selector )* ( '++' | '--' )? );"; }
			}

		}


		protected internal int DFA130_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA130_3 = input.LA(1);

                   	 
				int index130_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred202_Java()) ) { s = 11; }

				else if ( (true) ) { s = 4; }

                   	 
				input.Seek(index130_3);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae130 =
				new NoViableAltException(dfa.Description, 130, _s, input);
			dfa.Error(nvae130);
			throw nvae130;
		}
		const string DFA133_eotS =
			"\x21\uffff";
		const string DFA133_eofS =
			"\x01\x04\x20\uffff";
		const string DFA133_minS =
			"\x01\x33\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		const string DFA133_maxS =
			"\x01\x73\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		const string DFA133_acceptS =
			"\x02\uffff\x01\x01\x01\uffff\x01\x02\x1c\uffff";
		const string DFA133_specialS =
			"\x01\uffff\x01\x00\x01\uffff\x01\x01\x1d\uffff}>";
		static readonly string[] DFA133_transitionS = {
			"\x01\x04\x18\uffff\x01\x02\x01\x04\x01\uffff\x01\x04\x01\x01"+
				"\x03\x04\x01\x03\x01\uffff\x01\x04\x02\uffff\x17\x04\x01\uffff"+
					"\x03\x04",
			"\x01\uffff",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA133_eot = DFA.UnpackEncodedString(DFA133_eotS);
		static readonly short[] DFA133_eof = DFA.UnpackEncodedString(DFA133_eofS);
		static readonly char[] DFA133_min = DFA.UnpackEncodedStringToUnsignedChars(DFA133_minS);
		static readonly char[] DFA133_max = DFA.UnpackEncodedStringToUnsignedChars(DFA133_maxS);
		static readonly short[] DFA133_accept = DFA.UnpackEncodedString(DFA133_acceptS);
		static readonly short[] DFA133_special = DFA.UnpackEncodedString(DFA133_specialS);
		static readonly short[][] DFA133_transition = DFA.UnpackEncodedStringArray(DFA133_transitionS);

		protected class DFA133 : DFA
		{
			public DFA133(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 133;
				this.eot = DFA133_eot;
				this.eof = DFA133_eof;
				this.min = DFA133_min;
				this.max = DFA133_max;
				this.accept = DFA133_accept;
				this.special = DFA133_special;
				this.transition = DFA133_transition;

			}

			override public string Description
			{
				get { return "1300:9: ( identifierSuffix )?"; }
			}

		}


		protected internal int DFA133_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA133_1 = input.LA(1);

                   	 
				int index133_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred209_Java()) ) { s = 2; }

				else if ( (true) ) { s = 4; }

                   	 
				input.Seek(index133_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA133_3 = input.LA(1);

                   	 
				int index133_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred209_Java()) ) { s = 2; }

				else if ( (true) ) { s = 4; }

                   	 
				input.Seek(index133_3);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae133 =
				new NoViableAltException(dfa.Description, 133, _s, input);
			dfa.Error(nvae133);
			throw nvae133;
		}
		const string DFA135_eotS =
			"\x21\uffff";
		const string DFA135_eofS =
			"\x01\x04\x20\uffff";
		const string DFA135_minS =
			"\x01\x33\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		const string DFA135_maxS =
			"\x01\x73\x01\x00\x01\uffff\x01\x00\x1d\uffff";
		const string DFA135_acceptS =
			"\x02\uffff\x01\x01\x01\uffff\x01\x02\x1c\uffff";
		const string DFA135_specialS =
			"\x01\uffff\x01\x00\x01\uffff\x01\x01\x1d\uffff}>";
		static readonly string[] DFA135_transitionS = {
			"\x01\x04\x18\uffff\x01\x02\x01\x04\x01\uffff\x01\x04\x01\x01"+
				"\x03\x04\x01\x03\x01\uffff\x01\x04\x02\uffff\x17\x04\x01\uffff"+
					"\x03\x04",
			"\x01\uffff",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA135_eot = DFA.UnpackEncodedString(DFA135_eotS);
		static readonly short[] DFA135_eof = DFA.UnpackEncodedString(DFA135_eofS);
		static readonly char[] DFA135_min = DFA.UnpackEncodedStringToUnsignedChars(DFA135_minS);
		static readonly char[] DFA135_max = DFA.UnpackEncodedStringToUnsignedChars(DFA135_maxS);
		static readonly short[] DFA135_accept = DFA.UnpackEncodedString(DFA135_acceptS);
		static readonly short[] DFA135_special = DFA.UnpackEncodedString(DFA135_specialS);
		static readonly short[][] DFA135_transition = DFA.UnpackEncodedStringArray(DFA135_transitionS);

		protected class DFA135 : DFA
		{
			public DFA135(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 135;
				this.eot = DFA135_eot;
				this.eof = DFA135_eof;
				this.min = DFA135_min;
				this.max = DFA135_max;
				this.accept = DFA135_accept;
				this.special = DFA135_special;
				this.transition = DFA135_transition;

			}

			override public string Description
			{
				get { return "1305:9: ( identifierSuffix )?"; }
			}

		}


		protected internal int DFA135_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA135_1 = input.LA(1);

                   	 
				int index135_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred212_Java()) ) { s = 2; }

				else if ( (true) ) { s = 4; }

                   	 
				input.Seek(index135_1);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA135_3 = input.LA(1);

                   	 
				int index135_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred212_Java()) ) { s = 2; }

				else if ( (true) ) { s = 4; }

                   	 
				input.Seek(index135_3);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae135 =
				new NoViableAltException(dfa.Description, 135, _s, input);
			dfa.Error(nvae135);
			throw nvae135;
		}
		const string DFA143_eotS =
			"\x0b\uffff";
		const string DFA143_eofS =
			"\x0b\uffff";
		const string DFA143_minS =
			"\x01\x4c\x01\x04\x01\uffff\x01\x22\x07\uffff";
		const string DFA143_maxS =
			"\x01\x54\x01\x61\x01\uffff\x01\x73\x07\uffff";
		const string DFA143_acceptS =
			"\x02\uffff\x01\x03\x01\uffff\x01\x01\x01\x02\x01\x04\x01\x06\x01"+
				"\x07\x01\x08\x01\x05";
		const string DFA143_specialS =
			"\x0b\uffff}>";
		static readonly string[] DFA143_transitionS = {
			"\x01\x02\x03\uffff\x01\x01\x03\uffff\x01\x03",
			"\x0a\x05\x0e\uffff\x01\x05\x01\uffff\x01\x05\x02\uffff\x01"+
				"\x05\x05\uffff\x01\x05\x05\uffff\x01\x05\x06\uffff\x01\x05\x01"+
					"\uffff\x01\x05\x01\uffff\x01\x05\x05\uffff\x01\x05\x02\uffff"+
						"\x01\x05\x02\uffff\x01\x05\x04\uffff\x01\x05\x02\uffff\x01\x05"+
							"\x04\uffff\x01\x04\x05\uffff\x02\x05\x05\uffff\x04\x05",
			"",
			"\x01\x06\x15\uffff\x01\x09\x08\uffff\x01\x08\x02\uffff\x01"+
				"\x07\x2e\uffff\x01\x0a",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA143_eot = DFA.UnpackEncodedString(DFA143_eotS);
		static readonly short[] DFA143_eof = DFA.UnpackEncodedString(DFA143_eofS);
		static readonly char[] DFA143_min = DFA.UnpackEncodedStringToUnsignedChars(DFA143_minS);
		static readonly char[] DFA143_max = DFA.UnpackEncodedStringToUnsignedChars(DFA143_maxS);
		static readonly short[] DFA143_accept = DFA.UnpackEncodedString(DFA143_acceptS);
		static readonly short[] DFA143_special = DFA.UnpackEncodedString(DFA143_specialS);
		static readonly short[][] DFA143_transition = DFA.UnpackEncodedStringArray(DFA143_transitionS);

		protected class DFA143 : DFA
		{
			public DFA143(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 143;
				this.eot = DFA143_eot;
				this.eof = DFA143_eof;
				this.min = DFA143_min;
				this.max = DFA143_max;
				this.accept = DFA143_accept;
				this.special = DFA143_special;
				this.transition = DFA143_transition;

			}

			override public string Description
			{
				get { return "1331:1: identifierSuffix : ( ( '[' ']' )+ '.' 'class' | ( '[' expression ']' )+ | arguments | '.' 'class' | '.' nonWildcardTypeArguments IDENTIFIER arguments | '.' 'this' | '.' 'super' arguments | innerCreator );"; }
			}

		}

		const string DFA142_eotS =
			"\x21\uffff";
		const string DFA142_eofS =
			"\x01\x01\x20\uffff";
		const string DFA142_minS =
			"\x01\x33\x01\uffff\x01\x00\x1e\uffff";
		const string DFA142_maxS =
			"\x01\x73\x01\uffff\x01\x00\x1e\uffff";
		const string DFA142_acceptS =
			"\x01\uffff\x01\x02\x1e\uffff\x01\x01";
		const string DFA142_specialS =
			"\x02\uffff\x01\x00\x1e\uffff}>";
		static readonly string[] DFA142_transitionS = {
			"\x01\x01\x19\uffff\x01\x01\x01\uffff\x01\x01\x01\x02\x04\x01"+
				"\x01\uffff\x01\x01\x02\uffff\x17\x01\x01\uffff\x03\x01",
			"",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA142_eot = DFA.UnpackEncodedString(DFA142_eotS);
		static readonly short[] DFA142_eof = DFA.UnpackEncodedString(DFA142_eofS);
		static readonly char[] DFA142_min = DFA.UnpackEncodedStringToUnsignedChars(DFA142_minS);
		static readonly char[] DFA142_max = DFA.UnpackEncodedStringToUnsignedChars(DFA142_maxS);
		static readonly short[] DFA142_accept = DFA.UnpackEncodedString(DFA142_acceptS);
		static readonly short[] DFA142_special = DFA.UnpackEncodedString(DFA142_specialS);
		static readonly short[][] DFA142_transition = DFA.UnpackEncodedStringArray(DFA142_transitionS);

		protected class DFA142 : DFA
		{
			public DFA142(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 142;
				this.eot = DFA142_eot;
				this.eof = DFA142_eof;
				this.min = DFA142_min;
				this.max = DFA142_max;
				this.accept = DFA142_accept;
				this.special = DFA142_special;
				this.transition = DFA142_transition;

			}

			override public string Description
			{
				get { return "()+ loopback of 1337:9: ( '[' expression ']' )+"; }
			}

		}


		protected internal int DFA142_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA142_2 = input.LA(1);

                   	 
				int index142_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred224_Java()) ) { s = 32; }

				else if ( (true) ) { s = 1; }

                   	 
				input.Seek(index142_2);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae142 =
				new NoViableAltException(dfa.Description, 142, _s, input);
			dfa.Error(nvae142);
			throw nvae142;
		}
		const string DFA148_eotS =
			"\x21\uffff";
		const string DFA148_eofS =
			"\x01\x02\x20\uffff";
		const string DFA148_minS =
			"\x01\x33\x01\x00\x1f\uffff";
		const string DFA148_maxS =
			"\x01\x73\x01\x00\x1f\uffff";
		const string DFA148_acceptS =
			"\x02\uffff\x01\x02\x1d\uffff\x01\x01";
		const string DFA148_specialS =
			"\x01\uffff\x01\x00\x1f\uffff}>";
		static readonly string[] DFA148_transitionS = {
			"\x01\x02\x19\uffff\x01\x02\x01\uffff\x01\x02\x01\x01\x04\x02"+
				"\x01\uffff\x01\x02\x02\uffff\x17\x02\x01\uffff\x03\x02",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA148_eot = DFA.UnpackEncodedString(DFA148_eotS);
		static readonly short[] DFA148_eof = DFA.UnpackEncodedString(DFA148_eofS);
		static readonly char[] DFA148_min = DFA.UnpackEncodedStringToUnsignedChars(DFA148_minS);
		static readonly char[] DFA148_max = DFA.UnpackEncodedStringToUnsignedChars(DFA148_maxS);
		static readonly short[] DFA148_accept = DFA.UnpackEncodedString(DFA148_acceptS);
		static readonly short[] DFA148_special = DFA.UnpackEncodedString(DFA148_specialS);
		static readonly short[][] DFA148_transition = DFA.UnpackEncodedStringArray(DFA148_transitionS);

		protected class DFA148 : DFA
		{
			public DFA148(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 148;
				this.eot = DFA148_eot;
				this.eof = DFA148_eof;
				this.min = DFA148_min;
				this.max = DFA148_max;
				this.accept = DFA148_accept;
				this.special = DFA148_special;
				this.transition = DFA148_transition;

			}

			override public string Description
			{
				get { return "()* loopback of 1381:9: ( '[' expression ']' )*"; }
			}

		}


		protected internal int DFA148_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA148_1 = input.LA(1);

                   	 
				int index148_1 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred240_Java()) ) { s = 32; }

				else if ( (true) ) { s = 2; }

                   	 
				input.Seek(index148_1);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae148 =
				new NoViableAltException(dfa.Description, 148, _s, input);
			dfa.Error(nvae148);
			throw nvae148;
		}
		const string DFA171_eotS =
			"\x2d\uffff";
		const string DFA171_eofS =
			"\x2d\uffff";
		const string DFA171_minS =
			"\x01\x04\x01\uffff\x08\x00\x23\uffff";
		const string DFA171_maxS =
			"\x01\x73\x01\uffff\x08\x00\x23\uffff";
		const string DFA171_acceptS =
			"\x01\uffff\x01\x01\x08\uffff\x01\x02\x22\uffff";
		const string DFA171_specialS =
			"\x02\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
				"\x06\x01\x07\x23\uffff}>";
		static readonly string[] DFA171_transitionS = {
			"\x01\x05\x09\x06\x0c\uffff\x02\x0a\x01\x08\x01\x0a\x01\x08"+
				"\x02\uffff\x01\x08\x01\x0a\x01\uffff\x01\x0a\x01\uffff\x01\x0a"+
					"\x01\x08\x01\uffff\x01\x0a\x01\uffff\x01\x0a\x01\uffff\x01\x08"+
						"\x01\x0a\x01\uffff\x01\x0a\x03\uffff\x01\x08\x01\x0a\x01\x08"+
							"\x01\x0a\x01\x07\x01\uffff\x04\x0a\x01\x08\x02\x0a\x01\x04\x02"+
								"\x0a\x01\x02\x01\x0a\x01\uffff\x02\x0a\x01\x09\x02\x0a\x01\x03"+
									"\x01\uffff\x02\x0a\x02\uffff\x01\x0a\x04\uffff\x02\x0a\x05\uffff"+
										"\x04\x0a\x0e\uffff\x01\x0a\x02\uffff\x01\x01",
			"",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"\x01\uffff",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};

		static readonly short[] DFA171_eot = DFA.UnpackEncodedString(DFA171_eotS);
		static readonly short[] DFA171_eof = DFA.UnpackEncodedString(DFA171_eofS);
		static readonly char[] DFA171_min = DFA.UnpackEncodedStringToUnsignedChars(DFA171_minS);
		static readonly char[] DFA171_max = DFA.UnpackEncodedStringToUnsignedChars(DFA171_maxS);
		static readonly short[] DFA171_accept = DFA.UnpackEncodedString(DFA171_acceptS);
		static readonly short[] DFA171_special = DFA.UnpackEncodedString(DFA171_specialS);
		static readonly short[][] DFA171_transition = DFA.UnpackEncodedStringArray(DFA171_transitionS);

		protected class DFA171 : DFA
		{
			public DFA171(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 171;
				this.eot = DFA171_eot;
				this.eof = DFA171_eof;
				this.min = DFA171_min;
				this.max = DFA171_max;
				this.accept = DFA171_accept;
				this.special = DFA171_special;
				this.transition = DFA171_transition;

			}

			override public string Description
			{
				get { return "590:9: ( explicitConstructorInvocation )?"; }
			}

		}


		protected internal int DFA171_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA171_2 = input.LA(1);

                   	 
				int index171_2 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_2);
				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA171_3 = input.LA(1);

                   	 
				int index171_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_3);
				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA171_4 = input.LA(1);

                   	 
				int index171_4 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_4);
				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA171_5 = input.LA(1);

                   	 
				int index171_5 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_5);
				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA171_6 = input.LA(1);

                   	 
				int index171_6 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_6);
				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA171_7 = input.LA(1);

                   	 
				int index171_7 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_7);
				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA171_8 = input.LA(1);

                   	 
				int index171_8 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_8);
				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA171_9 = input.LA(1);

                   	 
				int index171_9 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred57_Java()) ) { s = 1; }

				else if ( (true) ) { s = 10; }

                   	 
				input.Seek(index171_9);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae171 =
				new NoViableAltException(dfa.Description, 171, _s, input);
			dfa.Error(nvae171);
			throw nvae171;
		}
 

		public static readonly BitSet FOLLOW_annotations_in_compilationUnit121 = new BitSet(new ulong[]{0x0200000000000000UL});
		public static readonly BitSet FOLLOW_packageDeclaration_in_compilationUnit150 = new BitSet(new ulong[]{0x9CA40A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet FOLLOW_importDeclaration_in_compilationUnit172 = new BitSet(new ulong[]{0x9CA40A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet FOLLOW_typeDeclaration_in_compilationUnit194 = new BitSet(new ulong[]{0x9CA00A0404000002UL,0x0001000000040489UL});
		public static readonly BitSet FOLLOW_PACKAGE_in_packageDeclaration234 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedName_in_packageDeclaration236 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_packageDeclaration246 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IMPORT_in_importDeclaration275 = new BitSet(new ulong[]{0x8000000000000010UL});
		public static readonly BitSet FOLLOW_STATIC_in_importDeclaration287 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_importDeclaration308 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_importDeclaration310 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000400000000UL});
		public static readonly BitSet FOLLOW_STAR_in_importDeclaration312 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_importDeclaration322 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IMPORT_in_importDeclaration339 = new BitSet(new ulong[]{0x8000000000000010UL});
		public static readonly BitSet FOLLOW_STATIC_in_importDeclaration351 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_importDeclaration372 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_importDeclaration383 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_importDeclaration385 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000140000UL});
		public static readonly BitSet FOLLOW_DOT_in_importDeclaration407 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000400000000UL});
		public static readonly BitSet FOLLOW_STAR_in_importDeclaration409 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_importDeclaration430 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_qualifiedImportName459 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_qualifiedImportName470 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_qualifiedImportName472 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_classOrInterfaceDeclaration_in_typeDeclaration512 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_typeDeclaration522 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_classOrInterfaceDeclaration552 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceDeclaration_in_classOrInterfaceDeclaration562 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotation_in_modifiers605 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_PUBLIC_in_modifiers615 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_PROTECTED_in_modifiers625 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_PRIVATE_in_modifiers635 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_STATIC_in_modifiers645 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_ABSTRACT_in_modifiers655 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_FINAL_in_modifiers665 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_NATIVE_in_modifiers675 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_SYNCHRONIZED_in_modifiers685 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_TRANSIENT_in_modifiers695 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_VOLATILE_in_modifiers705 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_STRICTFP_in_modifiers715 = new BitSet(new ulong[]{0x9C80080004000002UL,0x0001000000000489UL});
		public static readonly BitSet FOLLOW_FINAL_in_variableModifiers756 = new BitSet(new ulong[]{0x0000080000000002UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_annotation_in_variableModifiers770 = new BitSet(new ulong[]{0x0000080000000002UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_normalClassDeclaration_in_classDeclaration815 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_enumDeclaration_in_classDeclaration825 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_normalClassDeclaration854 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_normalClassDeclaration857 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_normalClassDeclaration859 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_typeParameters_in_normalClassDeclaration870 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_EXTENDS_in_normalClassDeclaration892 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_normalClassDeclaration894 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_IMPLEMENTS_in_normalClassDeclaration916 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_typeList_in_normalClassDeclaration918 = new BitSet(new ulong[]{0x0002040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_classBody_in_normalClassDeclaration951 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LT_in_typeParameters981 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_typeParameter_in_typeParameters995 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_typeParameters1010 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_typeParameter_in_typeParameters1012 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet FOLLOW_GT_in_typeParameters1037 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_typeParameter1066 = new BitSet(new ulong[]{0x0000040000000002UL});
		public static readonly BitSet FOLLOW_EXTENDS_in_typeParameter1077 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_typeBound_in_typeParameter1079 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_type_in_typeBound1120 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet FOLLOW_AMP_in_typeBound1131 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_typeBound1133 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet FOLLOW_modifiers_in_enumDeclaration1174 = new BitSet(new ulong[]{0x0000020000000000UL});
		public static readonly BitSet FOLLOW_ENUM_in_enumDeclaration1186 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_enumDeclaration1207 = new BitSet(new ulong[]{0x0002000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_IMPLEMENTS_in_enumDeclaration1218 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_typeList_in_enumDeclaration1220 = new BitSet(new ulong[]{0x0002000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_enumBody_in_enumDeclaration1241 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_enumBody1275 = new BitSet(new ulong[]{0x0000000000000010UL,0x00010000000C8000UL});
		public static readonly BitSet FOLLOW_enumConstants_in_enumBody1286 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C8000UL});
		public static readonly BitSet FOLLOW_COMMA_in_enumBody1308 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000048000UL});
		public static readonly BitSet FOLLOW_enumBodyDeclarations_in_enumBody1321 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_RBRACE_in_enumBody1343 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_enumConstant_in_enumConstants1372 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_enumConstants1383 = new BitSet(new ulong[]{0x0000000000000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_enumConstant_in_enumConstants1385 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_annotations_in_enumConstant1428 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_enumConstant1449 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000005000UL});
		public static readonly BitSet FOLLOW_arguments_in_enumConstant1460 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_classBody_in_enumConstant1482 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_enumBodyDeclarations1532 = new BitSet(new ulong[]{0xDCF02A8654000012UL,0x0009000000044689UL});
		public static readonly BitSet FOLLOW_classBodyDeclaration_in_enumBodyDeclarations1544 = new BitSet(new ulong[]{0xDCF02A8654000012UL,0x0009000000044689UL});
		public static readonly BitSet FOLLOW_normalInterfaceDeclaration_in_interfaceDeclaration1584 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotationTypeDeclaration_in_interfaceDeclaration1594 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_normalInterfaceDeclaration1627 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_INTERFACE_in_normalInterfaceDeclaration1629 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_normalInterfaceDeclaration1631 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_typeParameters_in_normalInterfaceDeclaration1642 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_EXTENDS_in_normalInterfaceDeclaration1664 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_typeList_in_normalInterfaceDeclaration1666 = new BitSet(new ulong[]{0x0000040000000000UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_interfaceBody_in_normalInterfaceDeclaration1687 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_type_in_typeList1716 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_typeList1727 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_typeList1729 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_LBRACE_in_classBody1769 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x000900000004C689UL});
		public static readonly BitSet FOLLOW_classBodyDeclaration_in_classBody1781 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x000900000004C689UL});
		public static readonly BitSet FOLLOW_RBRACE_in_classBody1803 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_interfaceBody1832 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0009000000048689UL});
		public static readonly BitSet FOLLOW_interfaceBodyDeclaration_in_interfaceBody1844 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0009000000048689UL});
		public static readonly BitSet FOLLOW_RBRACE_in_interfaceBody1866 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_classBodyDeclaration1895 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STATIC_in_classBodyDeclaration1906 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_classBodyDeclaration1928 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_memberDecl_in_classBodyDeclaration1938 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_fieldDeclaration_in_memberDecl1968 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_methodDeclaration_in_memberDecl1979 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_memberDecl1990 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceDeclaration_in_memberDecl2001 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_methodDeclaration2048 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_typeParameters_in_methodDeclaration2059 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_methodDeclaration2080 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_formalParameters_in_methodDeclaration2090 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004040UL});
		public static readonly BitSet FOLLOW_THROWS_in_methodDeclaration2101 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedNameList_in_methodDeclaration2103 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_LBRACE_in_methodDeclaration2124 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_explicitConstructorInvocation_in_methodDeclaration2136 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_blockStatement_in_methodDeclaration2158 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_RBRACE_in_methodDeclaration2179 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_methodDeclaration2189 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet FOLLOW_typeParameters_in_methodDeclaration2200 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet FOLLOW_type_in_methodDeclaration2222 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_VOID_in_methodDeclaration2236 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_methodDeclaration2256 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_formalParameters_in_methodDeclaration2266 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000054040UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_methodDeclaration2277 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_methodDeclaration2279 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000054040UL});
		public static readonly BitSet FOLLOW_THROWS_in_methodDeclaration2301 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedNameList_in_methodDeclaration2303 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000044000UL});
		public static readonly BitSet FOLLOW_block_in_methodDeclaration2358 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_methodDeclaration2372 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_fieldDeclaration2413 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_fieldDeclaration2423 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_fieldDeclaration2433 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet FOLLOW_COMMA_in_fieldDeclaration2444 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_fieldDeclaration2446 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet FOLLOW_SEMI_in_fieldDeclaration2467 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_variableDeclarator2496 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000410000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_variableDeclarator2507 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_variableDeclarator2509 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000410000UL});
		public static readonly BitSet FOLLOW_EQ_in_variableDeclarator2531 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1805212UL});
		public static readonly BitSet FOLLOW_variableInitializer_in_variableDeclarator2533 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceFieldDeclaration_in_interfaceBodyDeclaration2581 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceMethodDeclaration_in_interfaceBodyDeclaration2591 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceDeclaration_in_interfaceBodyDeclaration2601 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_interfaceBodyDeclaration2611 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_interfaceBodyDeclaration2621 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_interfaceMethodDeclaration2650 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet FOLLOW_typeParameters_in_interfaceMethodDeclaration2661 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet FOLLOW_type_in_interfaceMethodDeclaration2683 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_VOID_in_interfaceMethodDeclaration2694 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_interfaceMethodDeclaration2714 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_formalParameters_in_interfaceMethodDeclaration2724 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000050040UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_interfaceMethodDeclaration2735 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_interfaceMethodDeclaration2737 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000050040UL});
		public static readonly BitSet FOLLOW_THROWS_in_interfaceMethodDeclaration2759 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedNameList_in_interfaceMethodDeclaration2761 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_interfaceMethodDeclaration2774 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_interfaceFieldDeclaration2805 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_interfaceFieldDeclaration2807 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_interfaceFieldDeclaration2809 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet FOLLOW_COMMA_in_interfaceFieldDeclaration2820 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_interfaceFieldDeclaration2822 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000C0000UL});
		public static readonly BitSet FOLLOW_SEMI_in_interfaceFieldDeclaration2843 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_type2873 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_type2884 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_type2886 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_primitiveType_in_type2907 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_type2918 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_type2920 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_classOrInterfaceType2961 = new BitSet(new ulong[]{0x0000000000000002UL,0x0008000000100000UL});
		public static readonly BitSet FOLLOW_typeArguments_in_classOrInterfaceType2972 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_classOrInterfaceType2994 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_classOrInterfaceType2996 = new BitSet(new ulong[]{0x0000000000000002UL,0x0008000000100000UL});
		public static readonly BitSet FOLLOW_typeArguments_in_classOrInterfaceType3011 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_set_in_primitiveType0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LT_in_typeArguments3165 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000002000000UL});
		public static readonly BitSet FOLLOW_typeArgument_in_typeArguments3167 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_typeArguments3178 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000002000000UL});
		public static readonly BitSet FOLLOW_typeArgument_in_typeArguments3180 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000080000UL});
		public static readonly BitSet FOLLOW_GT_in_typeArguments3202 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_type_in_typeArgument3231 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_QUES_in_typeArgument3241 = new BitSet(new ulong[]{0x0000040000000002UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_typeArgument3265 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_typeArgument3309 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_qualifiedName_in_qualifiedNameList3349 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_qualifiedNameList3360 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedName_in_qualifiedNameList3362 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_formalParameters3402 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000002000UL});
		public static readonly BitSet FOLLOW_formalParameterDecls_in_formalParameters3413 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_formalParameters3435 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ellipsisParameterDecl_in_formalParameterDecls3464 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_formalParameterDecls3474 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_formalParameterDecls3485 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_formalParameterDecls3487 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_formalParameterDecls3509 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_formalParameterDecls3519 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_ellipsisParameterDecl_in_formalParameterDecls3541 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_normalParameterDecl3570 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_normalParameterDecl3572 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_normalParameterDecl3574 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_normalParameterDecl3585 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_normalParameterDecl3587 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_ellipsisParameterDecl3627 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_ellipsisParameterDecl3637 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000200000UL});
		public static readonly BitSet FOLLOW_ELLIPSIS_in_ellipsisParameterDecl3640 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_ellipsisParameterDecl3650 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_explicitConstructorInvocation3681 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000012UL});
		public static readonly BitSet FOLLOW_set_in_explicitConstructorInvocation3707 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_explicitConstructorInvocation3739 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_explicitConstructorInvocation3741 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_primary_in_explicitConstructorInvocation3752 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_explicitConstructorInvocation3762 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000002UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_explicitConstructorInvocation3773 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUPER_in_explicitConstructorInvocation3794 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_explicitConstructorInvocation3804 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_explicitConstructorInvocation3806 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_qualifiedName3835 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_qualifiedName3846 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_qualifiedName3848 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_annotation_in_annotations3889 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_MONKEYS_AT_in_annotation3931 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedName_in_annotation3933 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_annotation3947 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1807212UL});
		public static readonly BitSet FOLLOW_elementValuePairs_in_annotation3974 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_elementValue_in_annotation3998 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_annotation4034 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_elementValuePair_in_elementValuePairs4075 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_elementValuePairs4086 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_elementValuePair_in_elementValuePairs4088 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_elementValuePair4128 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_elementValuePair4130 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet FOLLOW_elementValue_in_elementValuePair4132 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_conditionalExpression_in_elementValue4161 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotation_in_elementValue4171 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_elementValueArrayInitializer_in_elementValue4181 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_elementValueArrayInitializer4210 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C188D212UL});
		public static readonly BitSet FOLLOW_elementValue_in_elementValueArrayInitializer4221 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet FOLLOW_COMMA_in_elementValueArrayInitializer4236 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet FOLLOW_elementValue_in_elementValueArrayInitializer4238 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet FOLLOW_COMMA_in_elementValueArrayInitializer4267 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_RBRACE_in_elementValueArrayInitializer4271 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_annotationTypeDeclaration4303 = new BitSet(new ulong[]{0x0000000000000000UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_MONKEYS_AT_in_annotationTypeDeclaration4305 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_INTERFACE_in_annotationTypeDeclaration4315 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_annotationTypeDeclaration4325 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_annotationTypeBody_in_annotationTypeDeclaration4335 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_annotationTypeBody4365 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0001000000048489UL});
		public static readonly BitSet FOLLOW_annotationTypeElementDeclaration_in_annotationTypeBody4377 = new BitSet(new ulong[]{0xDCF02A8654000010UL,0x0001000000048489UL});
		public static readonly BitSet FOLLOW_RBRACE_in_annotationTypeBody4399 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotationMethodDeclaration_in_annotationTypeElementDeclaration4430 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceFieldDeclaration_in_annotationTypeElementDeclaration4440 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalClassDeclaration_in_annotationTypeElementDeclaration4450 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalInterfaceDeclaration_in_annotationTypeElementDeclaration4460 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_enumDeclaration_in_annotationTypeElementDeclaration4470 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotationTypeDeclaration_in_annotationTypeElementDeclaration4480 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_annotationTypeElementDeclaration4490 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_annotationMethodDeclaration4519 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_annotationMethodDeclaration4521 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_annotationMethodDeclaration4523 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_annotationMethodDeclaration4533 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_annotationMethodDeclaration4535 = new BitSet(new ulong[]{0x0000002000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_DEFAULT_in_annotationMethodDeclaration4538 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00090003C1805212UL});
		public static readonly BitSet FOLLOW_elementValue_in_annotationMethodDeclaration4540 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_annotationMethodDeclaration4569 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_block4602 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_blockStatement_in_block4613 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_RBRACE_in_block4634 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_localVariableDeclarationStatement_in_blockStatement4665 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classOrInterfaceDeclaration_in_blockStatement4675 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_statement_in_blockStatement4685 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_localVariableDeclaration_in_localVariableDeclarationStatement4715 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_localVariableDeclarationStatement4725 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_localVariableDeclaration4754 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_localVariableDeclaration4756 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_localVariableDeclaration4766 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_localVariableDeclaration4777 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_variableDeclarator_in_localVariableDeclaration4779 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_block_in_statement4819 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ASSERT_in_statement4843 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_statement4863 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet FOLLOW_COLON_in_statement4866 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_statement4868 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement4872 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ASSERT_in_statement4882 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_statement4885 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet FOLLOW_COLON_in_statement4888 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_statement4890 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement4894 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IF_in_statement4916 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_parExpression_in_statement4918 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_statement4920 = new BitSet(new ulong[]{0x0000010000000002UL});
		public static readonly BitSet FOLLOW_ELSE_in_statement4923 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_statement4925 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_forstatement_in_statement4947 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_WHILE_in_statement4957 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_parExpression_in_statement4959 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_statement4961 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DO_in_statement4971 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_statement4973 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
		public static readonly BitSet FOLLOW_WHILE_in_statement4975 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_parExpression_in_statement4977 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement4979 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_trystatement_in_statement4989 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SWITCH_in_statement4999 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_parExpression_in_statement5001 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_LBRACE_in_statement5003 = new BitSet(new ulong[]{0x0000002080000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_switchBlockStatementGroups_in_statement5005 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_RBRACE_in_statement5007 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SYNCHRONIZED_in_statement5017 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_parExpression_in_statement5019 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_statement5021 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RETURN_in_statement5031 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1841212UL});
		public static readonly BitSet FOLLOW_expression_in_statement5034 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5039 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_THROW_in_statement5049 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_statement5051 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5053 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BREAK_in_statement5063 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_statement5078 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5095 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CONTINUE_in_statement5105 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_statement5120 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5137 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_expression_in_statement5147 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5150 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_statement5165 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_statement5167 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_statement5169 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMI_in_statement5179 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_switchBlockStatementGroup_in_switchBlockStatementGroups5210 = new BitSet(new ulong[]{0x0000002080000002UL});
		public static readonly BitSet FOLLOW_switchLabel_in_switchBlockStatementGroup5248 = new BitSet(new ulong[]{0xFDF16AD67C003FF2UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_blockStatement_in_switchBlockStatementGroup5259 = new BitSet(new ulong[]{0xFDF16AD67C003FF2UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_CASE_in_switchLabel5299 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_switchLabel5301 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_switchLabel5303 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DEFAULT_in_switchLabel5313 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_switchLabel5315 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TRY_in_trystatement5345 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_trystatement5347 = new BitSet(new ulong[]{0x0000100100000000UL});
		public static readonly BitSet FOLLOW_catches_in_trystatement5361 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet FOLLOW_FINALLY_in_trystatement5363 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_trystatement5365 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_catches_in_trystatement5379 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_FINALLY_in_trystatement5393 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_trystatement5395 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_catchClause_in_catches5435 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet FOLLOW_catchClause_in_catches5446 = new BitSet(new ulong[]{0x0000000100000002UL});
		public static readonly BitSet FOLLOW_CATCH_in_catchClause5486 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_catchClause5488 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_formalParameter_in_catchClause5490 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_catchClause5500 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_catchClause5502 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_formalParameter5532 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_formalParameter5534 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_formalParameter5536 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_formalParameter5547 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_formalParameter5549 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_FOR_in_forstatement5607 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_forstatement5609 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_forstatement5611 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_forstatement5613 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_forstatement5615 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_forstatement5617 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_forstatement5628 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_forstatement5630 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_forstatement5632 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_FOR_in_forstatement5664 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_forstatement5666 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1841212UL});
		public static readonly BitSet FOLLOW_forInit_in_forstatement5686 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_forstatement5707 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1841212UL});
		public static readonly BitSet FOLLOW_expression_in_forstatement5727 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_forstatement5748 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1803212UL});
		public static readonly BitSet FOLLOW_expressionList_in_forstatement5768 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_forstatement5789 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_forstatement5791 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_localVariableDeclaration_in_forInit5820 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_expressionList_in_forInit5830 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LPAREN_in_parExpression5859 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_parExpression5861 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_parExpression5863 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_expression_in_expressionList5892 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_expressionList5903 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_expressionList5905 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_conditionalExpression_in_expression5946 = new BitSet(new ulong[]{0x0000000000000002UL,0x000CFF0000400000UL});
		public static readonly BitSet FOLLOW_assignmentOperator_in_expression5957 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_expression5959 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_EQ_in_assignmentOperator6000 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_PLUSEQ_in_assignmentOperator6010 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUBEQ_in_assignmentOperator6020 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STAREQ_in_assignmentOperator6030 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SLASHEQ_in_assignmentOperator6040 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_AMPEQ_in_assignmentOperator6050 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BAREQ_in_assignmentOperator6060 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CARETEQ_in_assignmentOperator6070 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_PERCENTEQ_in_assignmentOperator6080 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LT_in_assignmentOperator6091 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_LT_in_assignmentOperator6093 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_assignmentOperator6095 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_assignmentOperator6106 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_assignmentOperator6108 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_assignmentOperator6110 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_assignmentOperator6112 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_assignmentOperator6123 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_assignmentOperator6125 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_assignmentOperator6127 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_conditionalOrExpression_in_conditionalExpression6157 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000002000000UL});
		public static readonly BitSet FOLLOW_QUES_in_conditionalExpression6168 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_conditionalExpression6170 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_conditionalExpression6172 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_conditionalExpression_in_conditionalExpression6174 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_conditionalAndExpression_in_conditionalOrExpression6214 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000020000000UL});
		public static readonly BitSet FOLLOW_BARBAR_in_conditionalOrExpression6225 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_conditionalAndExpression_in_conditionalOrExpression6227 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000020000000UL});
		public static readonly BitSet FOLLOW_inclusiveOrExpression_in_conditionalAndExpression6267 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000010000000UL});
		public static readonly BitSet FOLLOW_AMPAMP_in_conditionalAndExpression6278 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_inclusiveOrExpression_in_conditionalAndExpression6280 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000010000000UL});
		public static readonly BitSet FOLLOW_exclusiveOrExpression_in_inclusiveOrExpression6320 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
		public static readonly BitSet FOLLOW_BAR_in_inclusiveOrExpression6331 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_exclusiveOrExpression_in_inclusiveOrExpression6333 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
		public static readonly BitSet FOLLOW_andExpression_in_exclusiveOrExpression6373 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
		public static readonly BitSet FOLLOW_CARET_in_exclusiveOrExpression6384 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_andExpression_in_exclusiveOrExpression6386 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
		public static readonly BitSet FOLLOW_equalityExpression_in_andExpression6426 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet FOLLOW_AMP_in_andExpression6437 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_equalityExpression_in_andExpression6439 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
		public static readonly BitSet FOLLOW_instanceOfExpression_in_equalityExpression6479 = new BitSet(new ulong[]{0x0000000000000002UL,0x0002000008000000UL});
		public static readonly BitSet FOLLOW_set_in_equalityExpression6506 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_instanceOfExpression_in_equalityExpression6556 = new BitSet(new ulong[]{0x0000000000000002UL,0x0002000008000000UL});
		public static readonly BitSet FOLLOW_relationalExpression_in_instanceOfExpression6596 = new BitSet(new ulong[]{0x0008000000000002UL});
		public static readonly BitSet FOLLOW_INSTANCEOF_in_instanceOfExpression6607 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_instanceOfExpression6609 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression6649 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet FOLLOW_relationalOp_in_relationalExpression6660 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression6662 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet FOLLOW_LT_in_relationalOp6703 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_relationalOp6705 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_relationalOp6716 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000400000UL});
		public static readonly BitSet FOLLOW_EQ_in_relationalOp6718 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LT_in_relationalOp6728 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_relationalOp6738 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression6767 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet FOLLOW_shiftOp_in_shiftExpression6778 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression6780 = new BitSet(new ulong[]{0x0000000000000002UL,0x000C000000000000UL});
		public static readonly BitSet FOLLOW_LT_in_shiftOp6822 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_LT_in_shiftOp6824 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_shiftOp6835 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_shiftOp6837 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_shiftOp6839 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GT_in_shiftOp6850 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_shiftOp6852 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression6882 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000300000000UL});
		public static readonly BitSet FOLLOW_set_in_additiveExpression6909 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression6959 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000300000000UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression7006 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000008C00000000UL});
		public static readonly BitSet FOLLOW_set_in_multiplicativeExpression7033 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression7101 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000008C00000000UL});
		public static readonly BitSet FOLLOW_PLUS_in_unaryExpression7143 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression7146 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUB_in_unaryExpression7156 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression7158 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_PLUSPLUS_in_unaryExpression7168 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression7170 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUBSUB_in_unaryExpression7180 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression7182 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_unaryExpressionNotPlusMinus_in_unaryExpression7192 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TILDE_in_unaryExpressionNotPlusMinus7221 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpressionNotPlusMinus7223 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BANG_in_unaryExpressionNotPlusMinus7233 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpressionNotPlusMinus7235 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_castExpression_in_unaryExpressionNotPlusMinus7245 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_primary_in_unaryExpressionNotPlusMinus7255 = new BitSet(new ulong[]{0x0000000000000002UL,0x00000000C0110000UL});
		public static readonly BitSet FOLLOW_selector_in_unaryExpressionNotPlusMinus7266 = new BitSet(new ulong[]{0x0000000000000002UL,0x00000000C0110000UL});
		public static readonly BitSet FOLLOW_set_in_unaryExpressionNotPlusMinus7287 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LPAREN_in_castExpression7345 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_primitiveType_in_castExpression7347 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_castExpression7349 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_castExpression7351 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LPAREN_in_castExpression7361 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_castExpression7363 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_castExpression7365 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpressionNotPlusMinus_in_castExpression7367 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_parExpression_in_primary7398 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_THIS_in_primary7420 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet FOLLOW_DOT_in_primary7431 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_primary7433 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet FOLLOW_identifierSuffix_in_primary7455 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_primary7476 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet FOLLOW_DOT_in_primary7487 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_primary7489 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000111000UL});
		public static readonly BitSet FOLLOW_identifierSuffix_in_primary7511 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUPER_in_primary7532 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000101000UL});
		public static readonly BitSet FOLLOW_superSuffix_in_primary7542 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_literal_in_primary7552 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_creator_in_primary7562 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_primitiveType_in_primary7572 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_primary7583 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_primary7585 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet FOLLOW_DOT_in_primary7606 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_primary7608 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_VOID_in_primary7618 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_DOT_in_primary7620 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_primary7622 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_arguments_in_superSuffix7656 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_superSuffix7666 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_typeArguments_in_superSuffix7669 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_superSuffix7690 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_superSuffix7701 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_identifierSuffix7743 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_identifierSuffix7745 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000110000UL});
		public static readonly BitSet FOLLOW_DOT_in_identifierSuffix7766 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_identifierSuffix7768 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_identifierSuffix7779 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_identifierSuffix7781 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_identifierSuffix7783 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_arguments_in_identifierSuffix7804 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_identifierSuffix7814 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_identifierSuffix7816 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_identifierSuffix7826 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_identifierSuffix7828 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_identifierSuffix7830 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_identifierSuffix7832 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_identifierSuffix7842 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet FOLLOW_THIS_in_identifierSuffix7844 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_identifierSuffix7854 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUPER_in_identifierSuffix7856 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_identifierSuffix7858 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_innerCreator_in_identifierSuffix7868 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_selector7898 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_selector7900 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_selector7911 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_selector7932 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet FOLLOW_THIS_in_selector7934 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_selector7944 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SUPER_in_selector7946 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000101000UL});
		public static readonly BitSet FOLLOW_superSuffix_in_selector7956 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_innerCreator_in_selector7966 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_selector7976 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_selector7978 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_selector7980 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_creator8009 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_creator8011 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_creator8013 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_classCreatorRest_in_creator8015 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_creator8025 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_creator8027 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_classCreatorRest_in_creator8029 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_arrayCreator_in_creator8039 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_arrayCreator8068 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_createdName_in_arrayCreator8070 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_arrayCreator8080 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_arrayCreator8082 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_arrayCreator8093 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_arrayCreator8095 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet FOLLOW_arrayInitializer_in_arrayCreator8116 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_arrayCreator8127 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_createdName_in_arrayCreator8129 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_arrayCreator8139 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_arrayCreator8141 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_arrayCreator8151 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_arrayCreator8165 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_arrayCreator8167 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_arrayCreator8181 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_arrayCreator8203 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_arrayCreator8205 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_arrayInitializer_in_variableInitializer8245 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_expression_in_variableInitializer8255 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACE_in_arrayInitializer8284 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C188D212UL});
		public static readonly BitSet FOLLOW_variableInitializer_in_arrayInitializer8300 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet FOLLOW_COMMA_in_arrayInitializer8319 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1805212UL});
		public static readonly BitSet FOLLOW_variableInitializer_in_arrayInitializer8321 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000088000UL});
		public static readonly BitSet FOLLOW_COMMA_in_arrayInitializer8371 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_RBRACE_in_arrayInitializer8384 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_createdName8427 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_primitiveType_in_createdName8437 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_innerCreator8466 = new BitSet(new ulong[]{0x0100000000000000UL});
		public static readonly BitSet FOLLOW_NEW_in_innerCreator8468 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_innerCreator8479 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_innerCreator8500 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000001000UL});
		public static readonly BitSet FOLLOW_typeArguments_in_innerCreator8511 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_classCreatorRest_in_innerCreator8532 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_arguments_in_classCreatorRest8562 = new BitSet(new ulong[]{0x0002040000000002UL,0x0008000000004000UL});
		public static readonly BitSet FOLLOW_classBody_in_classCreatorRest8573 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LT_in_nonWildcardTypeArguments8614 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_typeList_in_nonWildcardTypeArguments8616 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
		public static readonly BitSet FOLLOW_GT_in_nonWildcardTypeArguments8626 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LPAREN_in_arguments8655 = new BitSet(new ulong[]{0x4150288250003FF0UL,0x00090003C1803212UL});
		public static readonly BitSet FOLLOW_expressionList_in_arguments8658 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_arguments8671 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_literal0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_classHeader8813 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_classHeader8815 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_classHeader8817 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_enumHeader8846 = new BitSet(new ulong[]{0x0000020000000010UL});
		public static readonly BitSet FOLLOW_set_in_enumHeader8848 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_enumHeader8854 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_interfaceHeader8883 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_INTERFACE_in_interfaceHeader8885 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_interfaceHeader8887 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_annotationHeader8916 = new BitSet(new ulong[]{0x0000000000000000UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_MONKEYS_AT_in_annotationHeader8918 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_INTERFACE_in_annotationHeader8920 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_annotationHeader8922 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_typeHeader8951 = new BitSet(new ulong[]{0x0020020400000000UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_CLASS_in_typeHeader8954 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_ENUM_in_typeHeader8956 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_MONKEYS_AT_in_typeHeader8959 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_INTERFACE_in_typeHeader8963 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_typeHeader8967 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_methodHeader8996 = new BitSet(new ulong[]{0x4050208250000010UL,0x0008000000000200UL});
		public static readonly BitSet FOLLOW_typeParameters_in_methodHeader8998 = new BitSet(new ulong[]{0x4050208250000010UL,0x0000000000000200UL});
		public static readonly BitSet FOLLOW_type_in_methodHeader9002 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_VOID_in_methodHeader9004 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_methodHeader9008 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_methodHeader9010 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_fieldHeader9039 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_fieldHeader9041 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_fieldHeader9043 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_fieldHeader9046 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_fieldHeader9047 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet FOLLOW_set_in_fieldHeader9051 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_localVariableHeader9086 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_localVariableHeader9088 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_localVariableHeader9090 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_localVariableHeader9093 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_localVariableHeader9094 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000004D0000UL});
		public static readonly BitSet FOLLOW_set_in_localVariableHeader9098 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotations_in_synpred2_Java121 = new BitSet(new ulong[]{0x0200000000000000UL});
		public static readonly BitSet FOLLOW_packageDeclaration_in_synpred2_Java150 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_synpred12_Java552 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalClassDeclaration_in_synpred27_Java815 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalInterfaceDeclaration_in_synpred43_Java1584 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_fieldDeclaration_in_synpred52_Java1968 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_methodDeclaration_in_synpred53_Java1979 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_synpred54_Java1990 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_explicitConstructorInvocation_in_synpred57_Java2136 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_modifiers_in_synpred59_Java2048 = new BitSet(new ulong[]{0x0000000000000010UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_typeParameters_in_synpred59_Java2059 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_synpred59_Java2080 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_formalParameters_in_synpred59_Java2090 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004040UL});
		public static readonly BitSet FOLLOW_THROWS_in_synpred59_Java2101 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_qualifiedNameList_in_synpred59_Java2103 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_LBRACE_in_synpred59_Java2124 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_explicitConstructorInvocation_in_synpred59_Java2136 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_blockStatement_in_synpred59_Java2158 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C184DFBFUL});
		public static readonly BitSet FOLLOW_RBRACE_in_synpred59_Java2179 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceFieldDeclaration_in_synpred68_Java2581 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceMethodDeclaration_in_synpred69_Java2591 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceDeclaration_in_synpred70_Java2601 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classDeclaration_in_synpred71_Java2611 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ellipsisParameterDecl_in_synpred96_Java3464 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_synpred98_Java3474 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_synpred98_Java3485 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_synpred98_Java3487 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_normalParameterDecl_in_synpred99_Java3509 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_COMMA_in_synpred99_Java3519 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_synpred103_Java3681 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000012UL});
		public static readonly BitSet FOLLOW_set_in_synpred103_Java3707 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_arguments_in_synpred103_Java3739 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_synpred103_Java3741 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotationMethodDeclaration_in_synpred117_Java4430 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_interfaceFieldDeclaration_in_synpred118_Java4440 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalClassDeclaration_in_synpred119_Java4450 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_normalInterfaceDeclaration_in_synpred120_Java4460 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_enumDeclaration_in_synpred121_Java4470 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_annotationTypeDeclaration_in_synpred122_Java4480 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_localVariableDeclarationStatement_in_synpred125_Java4665 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_classOrInterfaceDeclaration_in_synpred126_Java4675 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ASSERT_in_synpred130_Java4843 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred130_Java4863 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet FOLLOW_COLON_in_synpred130_Java4866 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred130_Java4868 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_synpred130_Java4872 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ASSERT_in_synpred132_Java4882 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred132_Java4885 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004040000UL});
		public static readonly BitSet FOLLOW_COLON_in_synpred132_Java4888 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred132_Java4890 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_synpred132_Java4894 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ELSE_in_synpred133_Java4923 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_synpred133_Java4925 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_expression_in_synpred148_Java5147 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_SEMI_in_synpred148_Java5150 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_synpred149_Java5165 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_synpred149_Java5167 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_synpred149_Java5169 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_catches_in_synpred153_Java5361 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet FOLLOW_FINALLY_in_synpred153_Java5363 = new BitSet(new ulong[]{0x8000000000000000UL,0x0000000000004000UL});
		public static readonly BitSet FOLLOW_block_in_synpred153_Java5365 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_catches_in_synpred154_Java5379 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_FOR_in_synpred157_Java5607 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_LPAREN_in_synpred157_Java5609 = new BitSet(new ulong[]{0x4050288250000010UL,0x0001000000000000UL});
		public static readonly BitSet FOLLOW_variableModifiers_in_synpred157_Java5611 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_type_in_synpred157_Java5613 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_synpred157_Java5615 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004000000UL});
		public static readonly BitSet FOLLOW_COLON_in_synpred157_Java5617 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred157_Java5628 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_synpred157_Java5630 = new BitSet(new ulong[]{0xFDF16AD67C003FF0UL,0x00090003C1845FBFUL});
		public static readonly BitSet FOLLOW_statement_in_synpred157_Java5632 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_localVariableDeclaration_in_synpred161_Java5820 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_castExpression_in_synpred202_Java7245 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LPAREN_in_synpred206_Java7345 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_primitiveType_in_synpred206_Java7347 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RPAREN_in_synpred206_Java7349 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_unaryExpression_in_synpred206_Java7351 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_synpred208_Java7431 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_synpred208_Java7433 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_identifierSuffix_in_synpred209_Java7455 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOT_in_synpred211_Java7487 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_IDENTIFIER_in_synpred211_Java7489 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_identifierSuffix_in_synpred212_Java7511 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_synpred224_Java7779 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred224_Java7781 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_synpred224_Java7783 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_synpred236_Java8009 = new BitSet(new ulong[]{0x0000000000000000UL,0x0008000000000000UL});
		public static readonly BitSet FOLLOW_nonWildcardTypeArguments_in_synpred236_Java8011 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_synpred236_Java8013 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_classCreatorRest_in_synpred236_Java8015 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_synpred237_Java8025 = new BitSet(new ulong[]{0x0000000000000010UL});
		public static readonly BitSet FOLLOW_classOrInterfaceType_in_synpred237_Java8027 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
		public static readonly BitSet FOLLOW_classCreatorRest_in_synpred237_Java8029 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_NEW_in_synpred239_Java8068 = new BitSet(new ulong[]{0x4050208250000010UL});
		public static readonly BitSet FOLLOW_createdName_in_synpred239_Java8070 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000010000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_synpred239_Java8080 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_synpred239_Java8082 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_synpred239_Java8093 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_synpred239_Java8095 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000014000UL});
		public static readonly BitSet FOLLOW_arrayInitializer_in_synpred239_Java8116 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LBRACKET_in_synpred240_Java8165 = new BitSet(new ulong[]{0x4150208250003FF0UL,0x00080003C1801212UL});
		public static readonly BitSet FOLLOW_expression_in_synpred240_Java8167 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_RBRACKET_in_synpred240_Java8181 = new BitSet(new ulong[]{0x0000000000000002UL});

	}
}
