using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.C.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Languages.C.Tests
{
	[TestFixture]
    public class CSmallTest
    {
        [Test]
        public void ParseReturn() {
            var code = "int main() { return 0; }";
            var prog = CProgramGenerator.Instance.Generate(code);
            var returns = prog.Descendants<UnifiedReturn>();
            Assert.That(returns.Count(), Is.EqualTo(1));
        }
	}
}
