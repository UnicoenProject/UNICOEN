using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using Paraiba.Xml.Linq;

namespace Paraiba.Xml.Tests.Linq {
	[TestFixture]
	public class XElementExtensionsTest {
		private static readonly XElement Root;
		private static readonly XElement A1Element;
		private static readonly XElement A2Element;
		private static readonly XElement B1Element;
		private static readonly XElement B_C1Element;
		private static readonly XElement D1Element;

		static XElementExtensionsTest() {
			Root = new XElement("e");
			A1Element = new XElement("a") { Value = "a1" };
			A2Element = new XElement("a") { Value = "a2" };
			B1Element = new XElement("b") { Value = "b1" };
			B_C1Element = new XElement("c") { Value = "c1" };
			D1Element = new XElement("d") { Value = "d1" };
			B1Element.Add(B_C1Element);
			Root.Add(A1Element, A2Element, B1Element, D1Element);
		}

		[Test]
		public void HasElement() {
			Assert.That(Root.HasElement(), Is.True);
		}

		[Test]
		public void HasElementForNoElement() {
			Assert.That(D1Element.HasElement(), Is.False);
		}

		[Test]
		[TestCase("d1", Result = true)]
		[TestCase("b1", Result = false)]
		public bool HasElementByContent(string content) {
			return Root.HasElementByContent(content);
		}

		[Test]
		[TestCase("b1c1", Result = true)]
		[TestCase("b1", Result = false)]
		public bool HasElementByValue(string value) {
			return Root.HasElementByValue(value);
		}

		[Test]
		[TestCase("d1", Result = true)]
		[TestCase("c", Result = false)]
		public bool HasContent(string name) {
			return D1Element.HasContent(name);
		}

		[Test]
		[TestCase("a", Result = true)]
		[TestCase("c", Result = false)]
		public bool HasElement(string name) {
			return Root.HasElement(name);
		}

		[Test]
		[TestCase("d1", Result = "d")]
		[TestCase("b1", Result = null)]
		public string ElementByContent(string content) {
			return Root.ElementByContent(content).SafeName();
		}

		[Test]
		public void ElementByContentShouldBeNotNull() {
			B1Element.ElementByContent().IsNotNull();
		}

		[Test]
		public void ElementByContentShouldBeNull() {
			B_C1Element.ElementByContent().IsNull();
		}

		[Test]
		[TestCase("b1c1", Result = "b")]
		[TestCase("b1", Result = null)]
		public string ElementByValue(string value) {
			return Root.ElementByValue(value).SafeName();
		}

		[Test]
		[TestCase("d1", Result = 1)]
		[TestCase("b1", Result = 0)]
		public int ElementsByContent(string content) {
			return Root.ElementsByContent(content).Count();
		}

		[Test]
		public void ElementsByContentShouldBeNotEmpty() {
			B1Element.ElementsByContent().Count().Is(1);
		}

		[Test]
		public void ElementsByContentShouldBeEmpty() {
			B_C1Element.ElementsByContent().Count().Is(0);
		}

		[Test]
		[TestCase("b1c1", Result = 1)]
		[TestCase("b1", Result = 0)]
		public int ElementsByValue(string value) {
			return Root.ElementsByValue(value).Count();
		}

		[Test]
		[TestCase("a", Result = "a")]
		[TestCase("b", Result = "b")]
		public string Name(string name) {
			return Root.Element(name).Name();
		}

		[Test]
		public void PreviousElement() {
			B1Element.PreviousElement().Value.Is("a2");
		}

		[Test]
		public void PreviousElementWithName() {
			D1Element.PreviousElement("a").Value.Is("a2");
		}

		[Test]
		public void PreviousElementOrDefault() {
			A1Element.PreviousElementOrDefault().Is((XElement)null);
		}

		[Test]
		public void PreviousElementOrDefaultWithName() {
			D1Element.PreviousElementOrDefault("d").Is((XElement)null);
		}

		[Test]
		public void PreviousElements() {
			D1Element.PreviousElements().Count().Is(3);
		}

		[Test]
		public void PreviousElementsWithName() {
			D1Element.PreviousElements("a").Count().Is(2);
		}

		[Test]
		public void PreviousElementsAndSelf() {
			D1Element.PreviousElementsAndSelf().Count().Is(4);
		}

		[Test]
		public void PreviousElementsAndSelfWithName() {
			D1Element.PreviousElementsAndSelf("d").Count().Is(1);
		}

		[Test]
		public void NextElement() {
			A2Element.NextElement().Name().Is("b");
		}

		[Test]
		public void NextElementWithName() {
			A2Element.NextElement("d").Name().Is("d");
		}

		[Test]
		public void NextElementOrDefault() {
			D1Element.NextElementOrDefault().Is((XElement)null);
		}

		[Test]
		public void NextElementOrDefaultWithName() {
			A1Element.NextElementOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void NextElements() {
			A1Element.NextElements().Count().Is(3);
		}

		[Test]
		public void NextElementsWithName() {
			A1Element.NextElements("a").Count().Is(1);
		}

		[Test]
		public void NextElementsAndSelf() {
			A1Element.NextElementsAndSelf().Count().Is(4);
		}

		[Test]
		public void NextElementsAndSelfWithName() {
			A1Element.NextElementsAndSelf("a").Count().Is(2);
		}

		[Test]
		public void FirstElement() {
			Root.FirstElement().Value.Is("a1");
		}

		[Test]
		public void FirstElementWithName() {
			Root.FirstElement("b").Value.Is("b1c1");
		}

		[Test]
		public void FirstElementOrDefault() {
			D1Element.FirstElementOrDefault().Is((XElement)null);
		}

		[Test]
		public void FirstElementOrDefaultWithName() {
			Root.FirstElementOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void LastElement() {
			Root.LastElement().Value.Is("d1");
		}

		[Test]
		public void LastElementWithName() {
			Root.LastElement("a").Value.Is("a2");
		}

		[Test]
		public void LastElementOrDefault() {
			D1Element.LastElementOrDefault().Is((XElement)null);
		}

		[Test]
		public void LastElementOrDefaultWithName() {
			Root.LastElementOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void NthElement() {
			Root.NthElement(1).Value.Is("a2");
		}

		[Test]
		public void NthElementWithName() {
			Root.NthElement("a", 1).Value.Is("a2");
		}

		[Test]
		public void NthElementOrDefault() {
			D1Element.NthElementOrDefault(5).Is((XElement)null);
		}

		[Test]
		public void NthElementOrDefaultWithName() {
			D1Element.NthElementOrDefault("a", 2).Is((XElement)null);
		}

		[Test]
		public void FirstElementBeforeSelf() {
			B1Element.FirstElementBeforeSelf().Value.Is("a1");
		}

		[Test]
		public void FirstElementBeforeSelfWithName() {
			B1Element.FirstElementBeforeSelf("a").Value.Is("a1");
		}

		[Test]
		public void FirstElementBeforeSelfOrDefault() {
			A1Element.FirstElementBeforeSelfOrDefault().Is((XElement)null);
		}

		[Test]
		public void FirstElementBeforeSelfOrDefaultWithName() {
			A1Element.FirstElementBeforeSelfOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void LastElementBeforeSelf() {
			B1Element.LastElementBeforeSelf().Value.Is("a2");
		}

		[Test]
		public void LastElementBeforeSelfWithName() {
			B1Element.LastElementBeforeSelf("a").Value.Is("a2");
		}

		[Test]
		public void LastElementBeforeSelfOrDefault() {
			A1Element.LastElementBeforeSelfOrDefault().Is((XElement)null);
		}

		[Test]
		public void LastElementBeforeSelfOrDefaultWithName() {
			A2Element.LastElementBeforeSelfOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void NthElementBeforeSelf() {
			B1Element.NthElementBeforeSelf(1).Value.Is("a2");
		}

		[Test]
		public void NthElementBeforeSelfWithName() {
			B1Element.NthElementBeforeSelf("a", 1).Value.Is("a2");
		}

		[Test]
		public void NthElementBeforeSelfOrDefault() {
			D1Element.NthElementBeforeSelfOrDefault(5).Is((XElement)null);
		}

		[Test]
		public void NthElementBeforeSelfOrDefaultWithName() {
			D1Element.NthElementBeforeSelfOrDefault("a", 2).Is((XElement)null);
		}

		[Test]
		public void FirstElementAfterSelf() {
			A1Element.FirstElementAfterSelf().Value.Is("a2");
		}

		[Test]
		public void FirstElementAfterSelfWithName() {
			A1Element.FirstElementAfterSelf("b").Value.Is("b1c1");
		}

		[Test]
		public void FirstElementAfterSelfOrDefault() {
			D1Element.FirstElementAfterSelfOrDefault().Is((XElement)null);
		}

		[Test]
		public void FirstElementAfterSelfOrDefaultWithName() {
			A1Element.FirstElementAfterSelfOrDefault("e").Is((XElement)null);
		}

		[Test]
		public void LastElementAfterSelf() {
			A1Element.LastElementAfterSelf().Value.Is("d1");
		}

		[Test]
		public void LastElementAfterSelfWithName() {
			A1Element.LastElementAfterSelf("b").Value.Is("b1c1");
		}

		[Test]
		public void LastElementAfterSelfOrDefault() {
			D1Element.LastElementAfterSelfOrDefault().Is((XElement)null);
		}

		[Test]
		public void LastElementAfterSelfOrDefaultWithName() {
			A2Element.LastElementAfterSelfOrDefault("a").Is((XElement)null);
		}

		[Test]
		public void NthElementAfterSelf() {
			A1Element.NthElementAfterSelf(1).Value.Is("b1c1");
		}

		[Test]
		public void NthElementAfterSelfWithName() {
			A1Element.NthElementAfterSelf("b", 0).Value.Is("b1c1");
		}

		[Test]
		public void NthElementAfterSelfOrDefault() {
			D1Element.NthElementAfterSelfOrDefault(5).Is((XElement)null);
		}

		[Test]
		public void NthElementAfterSelfOrDefaultWithName() {
			D1Element.NthElementAfterSelfOrDefault("b", 1).Is((XElement)null);
		}
	}
}