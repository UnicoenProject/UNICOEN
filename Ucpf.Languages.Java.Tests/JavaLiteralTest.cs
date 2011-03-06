
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Code2Xml.Languages.Java.XmlGenerators;
using NUnit.Framework;
using Ucpf.Core.Model.Expressions.Literals;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests
{

    [TestFixture]
    public class JavaParseLiteralTest
    {
        [Test]
        [Ignore]
        [TestCase("'1'", "1")]
        [TestCase("\"1\"", "1")]
        //TODO: [TestCase("\"#{1}\"", "1")]
        //TODO: [TestCase("\"#{a}\"", "a")]
        public void ParseStringLiteral(string code, string expectation)
        {
            var ast = JavaXmlGenerator.Instance.Generate(code);
            var lit = JavaModelFactory.CreateStringLiteral(ast);
            Assert.That(lit.Value, Is.EqualTo(expectation));
        }

        [Test, Ignore]
        [TestCase("true", UnifiedBoolean.True)]
        [TestCase("false", UnifiedBoolean.False)]
        public void ParseBooleanLiteral(string code, UnifiedBoolean expectation)
        {
            var ast = JavaXmlGenerator.Instance.Generate(code);
            var lit = JavaModelFactory.CreateBooleanLiteral(ast);
            Assert.That(lit.Value, Is.EqualTo(expectation));
        }

        [Test, Ignore]
        [TestCase("1", 1)]
        public void ParseIntegerLiteral(string code, int expectation)
        {
            var ast = JavaXmlGenerator.Instance.Generate(code);
            var lit = JavaModelFactory.CreateIntegerLiteral(ast);
            Assert.That(lit.Value, Is.EqualTo((BigInteger)expectation));
        }

        [Test, Ignore]
        [TestCase("1.1", 1.1)]
        public void ParseDecimalLiteral(string code, double expectation)
        {
            var ast = JavaXmlGenerator.Instance.Generate(code);
            var lit = JavaModelFactory.CreateDecimalLiteral(ast);
            Assert.That(lit.Value, Is.EqualTo((decimal)expectation));
        }
    }
}
