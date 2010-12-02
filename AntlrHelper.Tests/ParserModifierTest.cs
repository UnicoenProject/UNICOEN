using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AntlrHelper.Tests
{
	public class ParserModifierTest
	{
		[Test]
		public void JavaコードをCSharpコードに変換できる() {
			const string code =
				@"
if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
	((Symbols_scope)Symbols_stack.Peek()).types.add(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
	System.out.println(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
}
";
			const string expected =
				@"
if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
	((Symbols_scope)Symbols_stack.Peek()).types.add(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
	
}
";
			Assert.That(ParserModifier.ModifyFromJavaToCSharp(code), Is.EqualTo(expected));

		}


		[Test]
		public void 非終端ノード用のメソッドを置き換える() {
			const string code = @"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree);";
			const string expected = @"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree, leftHandSideExpression159, retval);";
			Assert.That(ParserModifier.ModifyForNonTerminalNode(code), Is.EqualTo(expected));
		}

		[Test]
		public void 終端ノード用のメソッドを置き換える() {
			const string code = @"{string_literal17_tree = (object)adaptor.Create(string_literal17);";
			const string expected = @"{string_literal17_tree = (object)adaptor.Create(string_literal17, retval);";
			Assert.That(ParserModifier.ModifyForTerminalNode(code), Is.EqualTo(expected));
		}

		[Test]
		public void ParserRuleReturnScopeを置き換える() {
			const string code = @"    public class compilationUnit_return : ParserRuleReturnScope";
			const string expected = @"    public class compilationUnit_return : XParserRuleReturnScope";
			Assert.That(ParserModifier.ModifyReturnScope(code), Is.EqualTo(expected));
		}

		[Test]
		public void CommonTreeAdapterを置き換える() {
			const string code = @"
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }";
			const string expected = @"
    protected XmlTreeAdaptor adaptor = new XmlTreeAdaptor();

    public XmlTreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }";
			Assert.That(ParserModifier.ModifyCommonTreeAdaptorRegex(code), Is.EqualTo(expected));
		}
	}
}
