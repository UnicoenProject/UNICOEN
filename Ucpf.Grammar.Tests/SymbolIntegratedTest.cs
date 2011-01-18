using System.Linq;
using NUnit.Framework;

namespace Ucpf.Grammar.Tests {
	[TestFixture]
	public class SymbolIntegratedTest {
		#region Setup/Teardown

		[SetUp]
		public void TestInitialize() {
			a = new Symbol("A");
			b = new Symbol("B");
			c = new Symbol("C");
			d = new Symbol("D");
			e = new Symbol("E");
			f = new Symbol("F");
			g = new Symbol("G");
			h = new Symbol("H");
			i = new Symbol("I");
			j = new Symbol("J");
			index = 0;
		}

		#endregion

		private Symbol a, b, c, d, e, f, g, h, i, j;
		private int index;
		private const int maxRepeat = 2;

		[Test]
		public void BC_l_D() {
			var exp = new OrSymbol(
				new Symbols(b, c),
				d
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, c }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B C) | D)"));
		}

		[Test]
		public void B_l_C_l_D() {
			var exp = new OrSymbol(
				new OrSymbol(b, c),
				d
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B | C) | D)"));
		}

		[Test]
		public void BlClD_ElFlG_HlI() {
			var exp = new Symbols(
				new OrSymbol(b, c, d),
				new OrSymbol(e, f, g),
				new OrSymbol(h, i)
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, e, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, e, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, e, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, f, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, f, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, f, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, g, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, g, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, g, h }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, e, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, e, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, e, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, f, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, f, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, f, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, g, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, g, i }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, g, i }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B | C | D) (E | F | G) (H | I))"));
		}

		[Test]
		public void BloColD_ElF() {
			var exp = new Symbols(
				new OrSymbol(b, new OptionSymbol(c), d),
				new OrSymbol(e, f)
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, f }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B | C? | D) (E | F))"));
		}

		[Test]
		public void BlpClpD_ElF() {
			var exp = new Symbols(
				new OrSymbol(b, new OneMoreRepeatSymbol(c), d),
				new OrSymbol(e, f)
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, c, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, c, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, f }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B | C+ | D) (E | F))"));
		}

		[Test]
		public void BlrCrlD_ElF() {
			var exp = new Symbols(
				new OrSymbol(b, new RepeatSymbol(c), d),
				new OrSymbol(e, f)
				);

			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, c, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, e }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { b, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { c, c, f }),
				Is.True);
			Assert.That(exp.Expand(index++, maxRepeat).SequenceEqual(new[] { d, f }),
				Is.True);
			Assert.That(exp.GetCount(maxRepeat), Is.EqualTo(index));
			Assert.That(exp.ToString(), Is.EqualTo("((B | C* | D) (E | F))"));
		}
	}
}