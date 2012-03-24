using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java.ProgramGenerators;

namespace Unicoen.Languages.Java.Tests
{
	[TestFixture]
	public class JavaParserTest
	{
		[Test]
		public void ParseComment() {
			var prog = new JavaProgramGenerator().Generate("class A { } //abc");
			var comment = prog.Comments[0];
			var pos = comment.Position;
			Assert.That(comment.Content, Is.EqualTo("//abc"));
			Assert.That(pos.StartLine, Is.EqualTo(1));
			Assert.That(pos.StartPosition, Is.EqualTo(12));
			Assert.That(pos.EndLine, Is.EqualTo(1));
			Assert.That(pos.EndPosition, Is.EqualTo(17));
		}
	}
}
