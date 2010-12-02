using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AntlrHelper.Tests
{
	public class ModifierTest
	{
		[Test]
		public void 非終端ノード用のメソッドを置き換える() {
			const string code = @"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree);";
			const string expected = @"if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree, leftHandSideExpression159, retval);";
			Assert.That(Modifier.ModifyForNonTerminalNode(code), Is.EqualTo(expected));
		}

		[Test]
		public void 終端ノード用のメソッドを置き換える() {
			const string code = @"{string_literal17_tree = (object)adaptor.Create(string_literal17);";
			const string expected = @"{string_literal17_tree = (object)adaptor.Create(string_literal17, retval);";
			Assert.That(Modifier.ModifyForTerminalNode(code), Is.EqualTo(expected));
		}
	}
}
