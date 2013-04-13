using NUnit.Framework;
using Unicoen.Languages.Lua.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Languages.Lua.Tests {
    [TestFixture]
    public class LuaParserTest {
        [Test]
        public void ParseAssignment() {
            var prog = new LuaProgramGenerator().Generate("a = 1");
            var exp = prog.FirstDescendant<UnifiedBinaryExpression>();
            Assert.That(exp.Operator.Sign, Is.EqualTo("="));
        }
    }
}